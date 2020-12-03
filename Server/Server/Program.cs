using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP); //Soket oluşturulmaktadır.
                s.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.185"), 600)); //Bağlantı uç noktası oluşturulmaktadır.(IP adresi ,bağlantı noktası numarası yani port)
                s.Listen(9); //Kuyruğun uzunluğunu belirtmektedir.
                Socket client = s.Accept(); //Bu metot gelecek olan clientı kabul etme demek , sockette clientı tanımlamaktadır.
                NetworkStream ns = new NetworkStream(client);
                StreamReader sr = new StreamReader(ns);
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
                ns.Close();
                s.Shutdown(SocketShutdown.Receive);//Veri alışverişi kesilmektedir.
                client.Shutdown(SocketShutdown.Receive);//
            }
            catch (SocketException exc)
            {
                Console.WriteLine("Hata oluştu");
            }
            Console.Read();
        }
    }
}
