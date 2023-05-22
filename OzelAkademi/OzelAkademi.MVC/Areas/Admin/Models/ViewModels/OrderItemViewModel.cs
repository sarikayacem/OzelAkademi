using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int AdvertId { get; set; }
        public string AdvertName { get; set; }
        public string AdvertUrl { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Range(1, 10)]
        public int Quantity { get; set; }
    }
}
