using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using MvcDemo4.BL.Interface;
using MvcDemo4.BL.Mapper;
using MvcDemo4.BL.Repository;
using MvcDemo4.DAL.Database;
using MvcDemo4.DAL.Extend;
using MvcDemo4.Language;
using Newtonsoft.Json.Serialization;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization();

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(SharedResource));
});


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
//    {
//        options.LoginPath = new PathString("/Account/Login");
//        options.AccessDeniedPath = new PathString("/Account/Login");
//    }); 



builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();

builder.Services.AddScoped<IEmployeeRep,EmployeeRep>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });


var connectionstring = builder.Configuration.GetConnectionString("DefualtConnection");

builder.Services.AddDbContextPool<DbContainer>(options=>options.UseSqlServer(connectionstring));


builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

builder.Services.AddMvc().AddNToastNotifyToastr(
    new NToastNotify.ToastrOptions()
    {
        ProgressBar=true,
        PositionClass=ToastPositions.TopRight,
        PreventDuplicates=true,
        CloseButton=true
    });

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<DbContainer>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);




//builder.Services.AddAuthentication();
var app = builder.Build();

var supportedCultures = new[] {
                      new CultureInfo("ar-EG"),
                      new CultureInfo("en-US"),
                };


app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index }/{id?}");


//app.UseMvc(routes =>
//{
//    routes.MapRoute(
//        name: "default",
//        template: "{controller=Home}/{action=Index}/{id?}");
//});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Account}/{action=Login}/{id?}");
});

app.Run();
