using Microsoft.EntityFrameworkCore;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Data.Concrete.EfCore.Context;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(OzelAkademiContext _appContext) : base(_appContext)
        {
        }
        OzelAkademiContext AppContext
        {
            get { return _dbContext as OzelAkademiContext; }
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = AppContext.Orders;
            return await orders.ToListAsync();
        }

        //public async task<list<order>> getallordersasync(string userıd = null, bool datesort = false)
        //{
        //    var orders = appcontext
        //        .orders
        //        .ınclude(o => o.orderıtems)
        //        .thenınclude(oi => oi.advert)
        //        .asqueryable();
        //    if (datesort)
        //    {
        //        orders = orders.orderbydescending(o => o.orderdate);
        //    }
        //    else
        //    {
        //        orders = orders.orderby(o => o.orderdate);
        //    }
        //    if (!string.ısnullorempty(userıd))
        //    {
        //        orders = orders.where(o => o.userıd == userıd);
        //    }
        //    return await orders.tolistasync();
        //}

        //public async Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false)
        //{
        //    var orders = AppContext
        //        .Orders
        //        .Include(o => o.OrderItems)
        //        .ThenInclude(oi => oi.Advert)
        //        .Where(o => o.NormalizedName.Contains(keyword))
        //        .AsQueryable();
        //    if (dateSort)
        //    {
        //        orders = orders.OrderByDescending(o => o.OrderDate);
        //    }
        //    else
        //    {
        //        orders = orders.OrderBy(o => o.OrderDate);
        //    }
        //    return await orders.ToListAsync();
        //}
    }
}
