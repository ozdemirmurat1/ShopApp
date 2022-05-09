using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ShopApp2.Business.Abstract;
using ShopApp2.Presentation.Extensions;
using ShopApp2.Presentation.Identity;
using ShopApp2.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;  // Login işlemlerinde kullanılır.
        private IEmailSender _emailSender;
        private ICartService _cartService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser
            {
                UserName=model.Username,
                Email=model.Email,
                FullName=model.FullName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // generate toke
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId=user.Id,
                    token=code
                });

                // send email

                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı onaylayınız.", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:498847{callbackUrl}'>tıklayınız.</a>");

                TempData.Put("message", new ResultMessage()
                {
                    Title="Hesap Onayı",
                    Message="E-posta adresinize gelen link ile hesabınızı onaylayınız.",
                    Css="warning"
                });
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu lütfen tekrar deneyiniz.");
            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel() {
                ReturnUrl=ReturnUrl
            });
        }

        [HttpPost]
       
        public async Task<IActionResult> Login(LoginModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user =  _userManager.FindByEmailAsync(model.Email).Result;
            if (user==null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamış.");
                return View(model);
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen hesabınızı email ile onaylayınız");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Oturum Açıldı",
                    Message = "Hesabınız güvenli bir şekilde açıldı",
                    Css = "success"
                });
                return Redirect(model.ReturnUrl ?? "/");
            }
            ModelState.AddModelError("", "Email veya parola yanlış");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData.Put("message", new ResultMessage()
            {
                Title = "Oturum Kapatıldı",
                Message = "Hesabınız güvenli bir şekilde sonlandırıldı",
                Css = "warning"
            });

            return Redirect("/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId==null || token==null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Hesap onayı için bilgileriniz yanlış",
                    Css = "danger"
                });
                return Redirect("/");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    // create cart object
                   
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = "Hesabınız başarıyla onaylanmıştır",
                        Css = "success"
                    });
                    return RedirectToAction("Login");
                }                               
            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = "Hesabınız onaylanamadı",
                Css = "danger"
            });
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Forgot Password",
                    Message = "Bilgileriniz hatalı",
                    Css = "warning"
                });

                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user==null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Forgot Password",
                    Message = "Eposta adresi ile bir kullanıcı bulunamadı",
                    Css = "warning"
                });

                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {               
                token = code
            });

            // send email

            await _emailSender.SendEmailAsync(Email, "Reset Password", $"Lütfen parolanızı onaylamak için linke <a href='http://localhost:498847{callbackUrl}'>tıklayınız.</a>");

            TempData.Put("message", new ResultMessage()
            {
                Title = "Forgot Password",
                Message = "Parola yenilemek için hesabınıza mail gönderildi",
                Css = "warning"
            });
            return RedirectToAction("Login", "Account");

            
        }
        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            if (token==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel()
            {
                Token=token
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user==null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
