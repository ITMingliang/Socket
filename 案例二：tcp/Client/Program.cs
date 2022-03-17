using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("启动一个Socket客户端链接....");
                int port = 2023;
                string host = "127.0.0.1";//服务器端ip地址 
                IPAddress ip = IPAddress.Parse(host);
                IPEndPoint ipe = new IPEndPoint(ip, port);
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(ipe); //开启链接以后，是长链接； 
               
                while (true)
                {
                    Console.WriteLine("请输入发送到服务器的信息：");
                    string sendStr = Console.ReadLine();
                    if (sendStr == "exit")
                        break;

                    byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
                    clientSocket.Send(sendBytes);

                    //receive message
                    string recStr = "";
                    byte[] recBytes = new byte[4096];
                    //监控传递过来的消息；
                    int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
                    recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
                    Console.WriteLine($"服务器返回：{recStr}");
                }

                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
