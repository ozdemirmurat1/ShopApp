using ShopApp2.DataAccess.Abstract;
using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp2.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDal:EfCoreGenericRepository<Order,ShopApp2Context>,IOrderDal
    {

    }
}
