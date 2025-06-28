using Bussines.Abstract;
using Bussines.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using FluentValidation.AspNetCore;
using MvcWebUI.Helpers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, EfProductDal>();

builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ISepetService, SepetManager>();
builder.Services.AddScoped<ISepetSessionHelper, SepetSessionHelper>();
// scoped yaptýk çünkü eðer singelton yapsaydýk bütün kullanýcýlarýn sepeti ayný olurdu
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation(); // ModelState'i etkiler
builder.Services.AddFluentValidationClientsideAdapters(); // Ýstemci tarafý için (opsiyonel)



var app = builder.Build();

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
