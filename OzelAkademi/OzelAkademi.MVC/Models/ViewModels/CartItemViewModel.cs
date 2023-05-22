namespace OzelAkademi.MVC.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int AdvertId { get; set; }
        public string AdvertName { get; set; }
        public string AdvertUrl { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
