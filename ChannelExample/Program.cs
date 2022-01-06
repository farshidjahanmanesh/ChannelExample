
using System.Threading.Channels;

var myChannel = Channel.CreateUnbounded<int>();
var reader = myChannel.Reader;
var writer = myChannel.Writer;
var random = new Random();
Task.Run(async () =>
{
    foreach (var i in Enumerable.Range(0, 10))
    {
        await writer.WriteAsync(random.Next(100));
        await Task.Delay(1000);
    }
    writer.Complete();
});

await foreach (var item in reader.ReadAllAsync())
{
    Console.WriteLine("number is :" + item);
}

Console.WriteLine("--------------------The End-------------------------");