using CoolStore.DataAccess.Data;
using CoolStore.DataAccess.Repository.IRepository;
using CoolStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolStore.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository 
    {

        private ApplicationDBContext _db;
        public ShoppingCartRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        void Update(ShoppingCart shoppingCart)
        {
            _db.ShopppingCarts.Update(shoppingCart);
        }
    }
}
