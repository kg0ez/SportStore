using System;
using System.Net.Sockets;
using SportStore.Common;
using System.Text;
using System.Text.Json;
using SportStore.Serv.Services;

namespace SportStore.Serv.Handler
{
    public class ConnectionHandler
    {
        private TcpClient _tcpClient;
        private IActionClientService _actionClientService;

        public ConnectionHandler(TcpClient tcpClient, IActionClientService actionClientService)
        {
            _tcpClient = tcpClient;
            _actionClientService = actionClientService;
        }

        public void ConnectionWithClient()
        {
            NetworkStream stream = null;

            try
            {
                //Получение сетевого потока
                stream = _tcpClient.GetStream();

                byte[] buffer = new byte[_tcpClient.ReceiveBufferSize];

                StringBuilder response = new StringBuilder();
                int bytes = default;

                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    response.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);
                string json = response.ToString();

                var query = JsonSerializer.Deserialize<ServQuery>(json)!;

                json = QueryHandler.SearchType(query, _actionClientService);

                buffer = Encoding.Unicode.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);

            }

            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            finally
            {
                if (stream != null)
                    stream.Close();

                if (_tcpClient != null)
                    _tcpClient.Close();
            }
        }
    }
}

