using Kcg.Interface;
using Kcg.Models;
using Kcg.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KcgContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("KcgDatabase")));




// ��ӬO�o��
// builder.Services.AddScoped<NewsService>();
// �p�G���������ܧ�o��
 builder.Services.AddScoped<INewsService, NewsService>();
// �令sql�B�z���
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
