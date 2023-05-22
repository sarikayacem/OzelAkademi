using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Entity.Concrete
{
    public class Order
    {
        public int  Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumOrderType OrderType { get; set; }

    }
    public enum EnumOrderState
    {
        Waiting=0,
        Unpaid=1,
        Completed=2
    }
    public enum EnumOrderType
    {
        CreditCard=0,
        Eft=1
    }
}
