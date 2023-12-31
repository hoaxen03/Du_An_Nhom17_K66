using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_Quy_Core_API;
using Quan_Ly_Quy_Core_API.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quan_Ly_Quy_Core_API.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddHttpClient<IFundService, FundService>(client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5077/api/Student");
//});
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Configure the HTTP request pipeline.
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
