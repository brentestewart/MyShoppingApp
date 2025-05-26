using MyShoppingApp.Web.Components;
using MyShoppingApp.Application.Interfaces;
using MyShoppingApp.Infrastructure.Services;
using MyShoppingApp.Web.Core.ViewModels;
using Supabase;
using System.Reflection;
using MyShoppingApp.Web.Stores;
using MyShoppingApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register infrastructure services (including Supabase) via extension method
var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:Key"];
builder.Services.AddInfrastructureServices(supabaseUrl, supabaseKey);

// Register ViewModels explicitly
builder.Services.AddTransient<StoreListViewModel>();
builder.Services.AddTransient<StoreDetailsViewModel>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
