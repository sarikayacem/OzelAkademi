using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Business.Concrete;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Data.Concrete.EfCore;
using OzelAkademi.Data.Concrete.EfCore.Context;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.EmailServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OzelAkademiContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<OzelAkademiContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // Þifre içinde rakam olmalý
    options.Password.RequireLowercase = true; // Þifre içinde küçük harf olmalý
    options.Password.RequireUppercase = true; // Þifre içinde büyük harf olmalý
    options.Password.RequireNonAlphanumeric = true; // Þifre içinde Alfanumerik olmayan karakter barýndýrmalý Örnek: Qwe123.

    options.Lockout.MaxFailedAccessAttempts = 3; //Üst üste izin verilecek hatalý giriþ sayýsý
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //Kilitlenmiþ hesaba 5 dk sonra giriþ yapýlabilsin

    options.User.RequireUniqueEmail = true; // Sistemde kaydý bulunmayan bir email adresi ile kayýt olunabilir
    options.SignIn.RequireConfirmedEmail = false; //Email onayý pasif
    options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon numarasý onayý pasif
});

builder.Services.ConfigureApplicationCookie(options =>
{
    //options.LoginPath = "/account/login"; // login olabilmek için gerekli login sayfasý yönlendirmesi
    //options.LogoutPath = "account/logout"; //loguot olmasý durumunda gerekli yönlendirme
    options.AccessDeniedPath = "/account/accessdenied"; //Kullanýcýnýn yetkisi olmayan bir sayfaya giriþ yapmaya çalýþtýðýnda gerekli yönlendirme
    options.SlidingExpiration = true;//Cookie yaþam süresinin her istekte sýnýrlandýrmasýný saðlar.Default olarak 20 dk'dýr ama bu süre ayarlanabilir.
    options.ExpireTimeSpan = TimeSpan.FromDays(10); //Cookie yaþam süresi 10 gün olacak þekilde ayarlanmýþtýr.
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = ".OzelAkademi.Security.Cookie"
    };
});

builder.Services.AddScoped<IAdvertService, AdvertManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<ILessonService, LessonManager>();

builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<ITeacherService,TeacherManager>();
builder.Services.AddScoped<IStudentService, StudentManager>();

builder.Services.AddScoped<IAdvertRepository, EfCoreAdvertRepository>();
builder.Services.AddScoped<IImageRepository, EfCoreImageRepository>();
builder.Services.AddScoped<ILessonRepository, EfCoreLessonRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
builder.Services.AddScoped<ITeacherRepository,EfCoreTeacherRepository>();
builder.Services.AddScoped<IStudentRepository,EfCoreStudentRepository>();

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(options => new SmtpEmailSender(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Post"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"]
    ));

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 4;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseRouting();

app.UseAuthorization();

app.UseNotyf();


app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
