using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetCoreNetwork
{
    public class UDPListener
    {
        private int _port;
        private UdpClient _listener;
        private IPEndPoint _remoteIpEndPoint;


        public UDPListener(int port)
        {
            _port = port;
            _listener = new UdpClient(port);
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public async Task<string> RecieveAsync()
        {
            var recieveResult = await _listener.ReceiveAsync();
            var buffer = recieveResult.Buffer;
            return Encoding.ASCII.GetString(buffer);
        }

        public string Recieve()
        {
            var bytes = _listener.Receive(ref _remoteIpEndPoint);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}