namespace CleanApp.API.Consumers;

public class ProductAddedEventConsumer : IConsumer<ProductAddedEvent>
{
    public Task Consume(ConsumeContext<ProductAddedEvent> context)
    {
        Console.WriteLine($"Gelen Event :{context.Message.Id} - {context.Message.Name} - {context.Message.Price}");

        return Task.CompletedTask;
    }
}
