using Kcg.Interface;
using Kcg.Models;
using Kcg.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KcgContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("KcgDatabase")));




// 原來是這樣
// builder.Services.AddScoped<NewsService>();
// 如果有介面的話改這樣
 builder.Services.AddScoped<INewsService, NewsService>();
// 改成sql處理資料
//builder.Services.AddScoped<INewsService, NewsSqlService>();

builder.Services.AddTransient<DITransient>();

builder.Services.AddScoped<DIScoped>();

builder.Services.AddSingleton<DISingleton>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
