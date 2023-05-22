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
    options.Password.RequireDigit = true; // �ifre i�inde rakam olmal�
    options.Password.RequireLowercase = true; // �ifre i�inde k���k harf olmal�
    options.Password.RequireUppercase = true; // �ifre i�inde b�y�k harf olmal�
    options.Password.RequireNonAlphanumeric = true; // �ifre i�inde Alfanumerik olmayan karakter bar�nd�rmal� �rnek: Qwe123.

    options.Lockout.MaxFailedAccessAttempts = 3; //�st �ste izin verilecek hatal� giri� say�s�
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //Kilitlenmi� hesaba 5 dk sonra giri� yap�labilsin

    options.User.RequireUniqueEmail = true; // Sistemde kayd� bulunmayan bir email adresi ile kay�t olunabilir
    options.SignIn.RequireConfirmedEmail = false; //Email onay� pasif
    options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon numaras� onay� pasif
});

builder.Services.ConfigureApplicationCookie(options =>
{
    //options.LoginPath = "/account/login"; // login olabilmek i�in gerekli login sayfas� y�nlendirmesi
    //options.LogoutPath = "account/logout"; //loguot olmas� durumunda gerekli y�nlendirme
    options.AccessDeniedPath = "/account/accessdenied"; //Kullan�c�n�n yetkisi olmayan bir sayfaya giri� yapmaya �al��t���nda gerekli y�nlendirme
    options.SlidingExpiration = true;//Cookie ya�am s�resinin her istekte s�n�rland�rmas�n� sa�lar.Default olarak 20 dk'd�r ama bu s�re ayarlanabilir.
    options.ExpireTimeSpan = TimeSpan.FromDays(10); //Cookie ya�am s�resi 10 g�n olacak �ekilde ayarlanm��t�r.
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
