using ShopApp2.Business.Abstract;
using ShopApp2.DataAccess.Abstract;
using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp2.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void InitializeCart(string userId)
        {
            _cartDal.Create(new Cart()
            {
                UserId=userId
            });
        }
    }
}
