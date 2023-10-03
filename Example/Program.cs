


using NetCoreNetwork;
using System.Net;


class UDPExample
{
    private UDPClient _client;
    private UDPListener _listener;


    public UDPExample(int port)
    {
        var loopBack = IPAddress.Loopback;

        _listener = new UDPListener(port);
        _client = new UDPClient(loopBack, port);
    }

    public void Run()
    {
        var sendAsyncLoopTask = SendAsyncLoop();
        var receiveAsyncLoopTask = ReceiveAsyncLoop();
    }



    private async Task ReceiveAsyncLoop()
    {
        await Console.Out.WriteLineAsync("ReceiveAsyncLoop");
        while (true)
        {
            var response = await _listener.RecieveAsync();
            await Console.Out.WriteLineAsync($"Response: {response}");
        }
    }


    private async Task SendAsyncLoop()
    {
        await Console.Out.WriteLineAsync("SendAsyncLoop");

        _client.Connect();
        while (true)
        {
            await Console.Out.WriteLineAsync("Send message: ");
            var message = await Task.Run(() => Console.In.ReadLine());
            await _client.SendAsync(message);
        }
    }
}


class Program
{
    public static void Main(string[] args)
    {
        new UDPExample(12000).Run();


        Console.WriteLine("Here...");

        while (true)
        {

        }
    }


    private static async Task Firkant()
    {
        await Console.Out.WriteLineAsync("Firkant");
    }

    private static async Task Test()
    {
        await Console.Out.WriteLineAsync("Test");

        await Task.Delay(1000);

        await Console.Out.WriteLineAsync("Test Done");
    }

}