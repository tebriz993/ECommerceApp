using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tech.DataAccess.Abstract.Products;
using Tech.DataAccess.Concrete.EntityFrameworkRepositories.Products;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.BusinessLogic.Ioc;
using FluentValidation.AspNetCore;
using Tech.BusinessLogic.ValidationRules.FluentValidations.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ICommonValidator>());
builder.Services
    .AddDbContext<TechContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

builder.Services.AddServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area}/{controller=Product}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
