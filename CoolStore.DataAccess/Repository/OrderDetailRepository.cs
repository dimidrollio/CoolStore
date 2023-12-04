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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDBContext _db;
        public OrderDetailRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetail orderDetail)
        {
            _db.OrderDetails.Update(orderDetail);
        }
    }
}
