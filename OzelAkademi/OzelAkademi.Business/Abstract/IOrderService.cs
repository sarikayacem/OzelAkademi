using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Abstract
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
        Task<List<Order>> GetAllAsync();
        //Task<List<Order>> GetAllOrdersAsync(string userId=null, bool dateSort=false);
        //Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false);
    }
}
