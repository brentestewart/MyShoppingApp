using Microsoft.Extensions.DependencyInjection;
using MyShoppingApp.Application.Interfaces;
using Supabase;
using MyShoppingApp.Infrastructure.Services;

namespace MyShoppingApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string supabaseUrl, string supabaseKey)
    {
        services.AddSingleton(_ => new Client(supabaseUrl, supabaseKey));
        services.AddTransient<IStoreService, StoreService>();
        services.AddTransient<IItemService, ItemService>();
        services.AddTransient<IStoreItemService, StoreItemService>();
        services.AddTransient<IShoppingListService, ShoppingListService>();
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<IUserService, UserService>();
        return services;
    }
} 