using System.Net.Sockets;
using System.Text;

namespace NetCoreNetwork
{
    public class UDPListener
    {
        private int _port;
        private UdpClient _listener;

        public UDPListener(int port)
        {
            _port = port;
            _listener = new UdpClient(port);
        }

        public async Task<string> RecieveAsync()
        {
            var recieveResult = await _listener.ReceiveAsync();
            var buffer = recieveResult.Buffer;
            return Encoding.ASCII.GetString(buffer);
        }
    }
}