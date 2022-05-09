using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp2.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
    }
}
