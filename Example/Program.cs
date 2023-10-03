


using NetCoreNetwork;
using System.Net;
using System.Net.Sockets;

class UDPExample
{
    private UDPClient _client;
    private UDPListener _listener;


    public UDPExample()
    {
        var loopBack = IPAddress.Loopback;

        _listener = new UDPListener(12000);
        _client = new UDPClient(loopBack, 12000);
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
        var loopBack = IPAddress.Loopback;

        var client = new UDPClient(loopBack, 12000);
        var listener = new UDPListener(12000);

        client.Connect();

        new Thread(() =>
        {
            while (true)
            {
                client.Send("Hegne");
            }
        }).Start();



        new Thread(() =>
        {
            while (true)
            {
                var request = listener.Recieve();
                Console.WriteLine(request);
            }
        }).Start();


        Console.WriteLine("Press any key to close...");
        Console.ReadKey();
    }


   

}