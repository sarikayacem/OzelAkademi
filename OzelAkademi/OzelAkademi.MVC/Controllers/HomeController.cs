using AspNetCoreHero.ToastNotification.Abstractions;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.EmailServices;
using OzelAkademi.MVC.Models;
using OzelAkademi.MVC.Models.ViewModels;
using System.Diagnostics;

namespace OzelAkademi.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly ILessonService _lessonService;
        private readonly IImageService _imageService;
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;


        public HomeController(IAdvertService advertService, ILessonService lessonService, IImageService imageService, IOrderService orderService, UserManager<User> userManager, INotyfService notyfService)
        {
            _advertService = advertService;
            _lessonService = lessonService;
            _imageService = imageService;
            _orderService = orderService;
            _userManager = userManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index(string lessonurl)
        {
            List<Advert> adverts = await _advertService.GetAllAdvertFullDataAsync(lessonurl);
            List<AdvertViewModel> advertViewModel = new List<AdvertViewModel>();
            var images = await _imageService.GetAllAsync();
            advertViewModel = adverts.Select(a => new AdvertViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Price = a.Price,
                Comment = a.Comment,
                CreatedDate = a.CreatedDate,
                ModifiedDate = a.ModifiedDate,
                Url = a.Url,
                Lesson = a.Lesson,
                Teacher = a.Teacher,
                ImageUrl = a.Teacher.User.Image.Url

            }).ToList();

            return View(advertViewModel);
        }
        public async Task<IActionResult> PrivatePage(string lessonurl)
        {
            List<Advert> adverts = await _advertService.GetAllAdvertFullDataAsync(lessonurl);
            List<AdvertViewModel> advertViewModel = new List<AdvertViewModel>();
            var images = await _imageService.GetAllAsync();
            advertViewModel = adverts.Select(a => new AdvertViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Price = a.Price,
                Comment = a.Comment,
                CreatedDate = a.CreatedDate,
                ModifiedDate = a.ModifiedDate,
                Url = a.Url,
                Lesson = a.Lesson,
                Teacher = a.Teacher,
                ImageUrl = a.Teacher.User.Image.Url

            }).ToList();
            return View(advertViewModel);
        }
        public async Task<IActionResult> OnlinePage(string lessonurl)
        {
            List<Advert> adverts = await _advertService.GetAllAdvertFullDataAsync(lessonurl);
            List<AdvertViewModel> advertViewModel = new List<AdvertViewModel>();
            var images = await _imageService.GetAllAsync();
            advertViewModel = adverts.Select(a => new AdvertViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Price = a.Price,
                Comment = a.Comment,
                CreatedDate = a.CreatedDate,
                ModifiedDate = a.ModifiedDate,
                Url = a.Url,
                Lesson = a.Lesson,
                Teacher = a.Teacher,
                ImageUrl = a.Teacher.User.Image.Url

            }).ToList();
            return View(advertViewModel);
        }
        public async Task<IActionResult> AdvertDetails(string name)
        {
            Advert advert = await _advertService.GetByNameAsync(name);
            var adverts = await _advertService.GetAllAdvertFullDataAsync(null);
            var images = await _imageService.GetAllAsync();

            AdvertDetailsPageViewModel advertDetailsPageViewModel = new AdvertDetailsPageViewModel()
            {
                AdvertDetail = new AdvertViewModel()
                {
                    Id = advert.Id,
                    Name = advert.Name,
                    Description = advert.Description,
                    Price = advert.Price,
                    Comment = advert.Comment,
                    Lesson = advert.Lesson,
                    Teacher = advert.Teacher,
                    ImageUrl = advert.Teacher.User.Image.Url
                },
                AllAdverts = adverts.Select(a => new AdvertViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Comment = a.Comment,
                    CreatedDate = a.CreatedDate,
                    ModifiedDate = a.ModifiedDate,
                    Url = a.Url,
                    Lesson = a.Lesson,
                    Teacher = a.Teacher,
                    ImageUrl = a.Teacher.User.Image.Url
                }).ToList()
            };
            return View(advertDetailsPageViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetPayment(int id)
        {
            var advert = await _advertService.GetAdvertFullDataAsync(id);
            var images = await _imageService.GetAllAsync();

            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Advert = advert,
                AdvertId = advert.Id,
                
            };

            return View(orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> GetPayment(OrderViewModel orderViewModel)
        {
            var advert = await _advertService.GetAdvertFullDataAsync(orderViewModel.Id);
            User user = await _userManager.GetUserAsync(User);
            orderViewModel.Advert = advert;
            if (ModelState.IsValid)
            {
                if (!CardNumberControl(orderViewModel.CardNumber))
                {
                    _notyfService.Error("Geçersiz Kart Numarası girdiniz. Kontrol ediniz.");
                    return View(orderViewModel);
                }
                Payment payment = await PaymentProcess(orderViewModel);
                if (payment.Status == "success")
                {
                    SaveOrder(orderViewModel, user.Id);
                    _notyfService.Success("Ödeme Başarılı :)");
                   return Redirect("/");
                }
                else
                {
                    _notyfService.Error("Bir sorun oluştu");
                }
            }
            orderViewModel = new OrderViewModel
            {
                Advert = advert,
                AdvertId = advert.Id,
            };
            return View(orderViewModel);

        }


        [NonAction]
        private async void SaveOrder(OrderViewModel orderViewModel, string userId)
        {
            Order order = new Order();
            order.OrderState = EnumOrderState.Completed;
            order.OrderType = EnumOrderType.CreditCard;
            order.OrderDate = DateTime.Now;
            order.AdvertId = orderViewModel.Advert.Id;
            order.UserId = userId;
            await _orderService.CreateAsync(order);
        }
        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i += 2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
        }
        private async Task<Payment> PaymentProcess(OrderViewModel orderViewModel)
        {
            
            User user =await _userManager.FindByNameAsync(User.Identity.Name);
            Options options = new Options();
            options.ApiKey = "sandbox-kAjkaD44V06cUkMB0D4B27czT9R07kSF";
            options.SecretKey = "sandbox-eVZnMsHUy2hT8Ixe9fSMmX2B4AFImKcY";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = new Random().Next(1000000, 9999999).ToString(),
                Price = Convert.ToInt32(orderViewModel.Advert.Price).ToString(),
                PaidPrice = Convert.ToInt32(orderViewModel.Advert.Price).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName = orderViewModel.CardName,
                    CardNumber = orderViewModel.CardNumber,
                    ExpireMonth = orderViewModel.ExpirationMonth,
                    ExpireYear = orderViewModel.ExpirationYear,
                    Cvc = orderViewModel.Cvc,
                    RegisterCard = 0
                },
                Buyer = new Buyer
                {
                    Id = "BY999",
                    Name = user.FirstName,
                    Surname = user.LastName,
                    Email = user.Email,
                    IdentityNumber = "00000000000",
                    RegistrationAddress = "WorldWideWeb",
                    Ip = "84.99.155.212",
                    City = "asd",
                    Country = "Türkiye",
                    ZipCode = "34700",
                    
                },
                ShippingAddress = new Address
                {
                    ContactName = orderViewModel.FirstName + " " + orderViewModel.LastName,
                    City = "as",
                    Country = "Türkiye",
                    Description = ""
                }
            };
            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            
               BasketItem basketItem = new BasketItem
                {
                    Id = orderViewModel.Advert.Teacher.Id.ToString(),
                    Name = orderViewModel.Advert.Teacher.User.FirstName,
                    Category1 = "Özel Ders",
                    ItemType = BasketItemType.VIRTUAL.ToString(),
                    Price = Convert.ToInt32(orderViewModel.Advert.Price).ToString()
                };
                basketItems.Add(basketItem);
            
            request.BasketItems = basketItems;
            Payment payment = Payment.Create(request, options);
            return payment;
        }
    }
}