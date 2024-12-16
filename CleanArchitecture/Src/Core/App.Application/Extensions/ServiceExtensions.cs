namespace App.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<ICategoryService, CategoryService>();

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddScoped(typeof(NotFoundFilter<,>));

        //services.AddExceptionHandler<CriticalExceptionHandler>();

        //services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }
}
