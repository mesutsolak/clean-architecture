namespace App.Bus;

public static class BusExtensions
{
    public static IServiceCollection AddBusExt(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceBusOption = configuration.GetSection(nameof(ServiceBusOption)).Get<ServiceBusOption>();

        services.AddScoped<IServiceBus, ServiceBus>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<ProductAddedEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(serviceBusOption!.Url), h => { });

                cfg.ReceiveEndpoint(ServiceBusConst.ProductAddedEventQueueName, x =>
                {
                    x.ConfigureConsumer<ProductAddedEventConsumer>(context);
                });
            });
        });

        return services;
    }
}
