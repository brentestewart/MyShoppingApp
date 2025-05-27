using MyShoppingApp.WebApp.Components;
using MyShoppingApp.Infrastructure;
using MyShoppingApp.WebApp.Stores;
using MyShoppingApp.WebApp.Users;
using MyShoppingApp.WebApp.Groups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register infrastructure services (including Supabase) via extension method
var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:Key"];
builder.Services.AddInfrastructureServices(supabaseUrl, supabaseKey);

// Register ViewModels
builder.Services.AddTransient<StoreListViewModel>();
builder.Services.AddTransient<CreateStoreViewModel>();
builder.Services.AddTransient<EditStoreViewModel>();
builder.Services.AddTransient<StoreDetailsViewModel>();
builder.Services.AddTransient<UserListViewModel>();
builder.Services.AddTransient<UserCreateViewModel>();
builder.Services.AddTransient<UserEditViewModel>();
builder.Services.AddTransient<GroupListViewModel>();
builder.Services.AddTransient<GroupCreateViewModel>();
builder.Services.AddTransient<GroupEditViewModel>();

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
