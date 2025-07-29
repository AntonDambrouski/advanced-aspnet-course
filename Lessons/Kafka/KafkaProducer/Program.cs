
using Confluent.Kafka;

var producerConfig = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
	SecurityProtocol = SecurityProtocol.Plaintext,
};

using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();
var topic = "test-topic";

while (true)
{
    var message = Console.ReadLine();
    if (string.IsNullOrEmpty(message))
    {
        return;
    }

	try
	{
		var messageToSend = new Message<Null, string>
		{
			Value = message,
		};

		var result = producer.ProduceAsync(topic, messageToSend);
		Console.WriteLine($"Message '{message}' sent to topic '{topic}' at offset {result.Result.Offset}.");
    }
	catch (Exception ex)
	{

        Console.WriteLine($"Unable to deliver message. Reason: {ex.Message}");
	}
}