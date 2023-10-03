using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetCoreNetwork
{
    public class UDPClient
    {
        private int _port;
        private UdpClient _client;
        private IPAddress _ipAddress;
        //private static IPEndPoint _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

        public UDPClient(IPAddress ipAddress, int port)
        {
            _port = port;
            _ipAddress = ipAddress;
            _client = new UdpClient();
        }


        public void Connect()
        {
            _client.Connect(_ipAddress, _port);
        }


        public async Task SendAsync(string message)
        {
            var bytes = Encoding.ASCII.GetBytes(message);
            await _client.SendAsync(bytes, bytes.Length);
        }

        public async Task<string> RecieveAsync()
        {
            var recieveResult = await _client.ReceiveAsync();
            var buffer = recieveResult.Buffer;
            return Encoding.ASCII.GetString(buffer);
        }

        //public void Send(string message)
        //{
        //    var bytes = Encoding.ASCII.GetBytes(message);
        //    _client.Send(bytes, bytes.Length);
        //}


        //public string Recieve()
        //{
        //    var bytes = _client.Receive(ref _remoteIpEndPoint);
        //    return Encoding.ASCII.GetString(bytes);
        //}

    }
}