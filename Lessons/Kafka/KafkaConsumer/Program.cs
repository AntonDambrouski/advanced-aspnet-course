using Confluent.Kafka;

var groupId = args.First();
var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = groupId,
    AutoOffsetReset = AutoOffsetReset.Earliest,
    
};

using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
var topic = "test-topic";

consumer.Subscribe(topic);

Console.WriteLine($"Subscribed to topic '{topic}'. Waiting for messages...");
while (true)
{
    try
    {
        var consumedMessage = consumer.Consume();
        await Task.Delay(500);
        Console.WriteLine($"Consumed message '{consumedMessage.Message.Value}' at offset {consumedMessage.Offset} from topic '{consumedMessage.Topic}'.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unable to consume message. Reason: {ex.Message}");
    }
}