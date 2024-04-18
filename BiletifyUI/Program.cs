using Biletify.Business.Abstract;
using Biletify.Business.Concrete;
using Biletify.Data.Abstract;
using Biletify.Data.Concrete.EfCore.Contexts;
using Biletify.Data.Concrete.EfCore.Repositories;
using Biletify.Data.Concrete.Repositories;
using Biletify.Entity.Concrete.Identity;
using Biletify.Shared.Helpers.Abstract;
using Biletify.Shared.Helpers.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BiletifyDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
);

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<BiletifyDbContext>()
    .AddDefaultTokenProviders();



builder.Services.Configure<IdentityOptions>(options =>
{
    #region Parola

    options.Password.RequiredLength = 6; 
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true; 
    options.Password.RequireUppercase = true; 
    options.Password.RequireLowercase = true; 
                                              

    #endregion

    #region Hesap Kilitleme Ayarlarý

    options.Lockout.MaxFailedAccessAttempts = 3; 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15); 

    #endregion

    #region Diðer Ayarlar

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false; 

    #endregion
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.LogoutPath = "/";
    options.AccessDeniedPath = "/User/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(2);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        Name = "Biletify.Security.Cookie",
        SameSite = SameSiteMode.Strict,
        HttpOnly = true
    };

});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();



builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();




builder.Services.AddScoped<IImageHelper, ImageHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();




app.MapAreaControllerRoute(
    name:"admin",
    areaName:"Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
