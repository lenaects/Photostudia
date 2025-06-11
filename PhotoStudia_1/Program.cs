using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PhotoStudia_1.Services;
using PhotoStudia_1.Models;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);
// Добавляем логирование
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Логирование в консоль

builder.Services.AddScoped<PhotographerState>();
builder.Services.AddScoped<AdminState>();
builder.Services.AddSingleton<PhotographerState>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

builder.Services.AddDbContextFactory<PhotostudiaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<PhotostudiaContext>(options =>
    options.UseNpgsql("Host=195.19.93.77;Port=5432;Database=Photostudia;Username=adminuser;Password=AdminPassword123;Trust Server Certificate=true"));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
