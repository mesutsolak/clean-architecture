﻿namespace App.Bus;

public class ServiceBus(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider) : IServiceBus
{
    public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IEventOrMessage
    {
        await publishEndpoint.Publish(@event, cancellationToken);
    }

    public async Task SendAsync<T>(T message, string queueName, CancellationToken cancellationToken = default) where T : IEventOrMessage
    {
        var endPoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));

        await endPoint.Send(message,cancellationToken);
    }
}
