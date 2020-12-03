using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Program b = new Program();
            b.DataInput();
            Console.Read();

        }
        public void DataInput(){
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);// Soket oluşturulmaktadır.
            s.Connect(IPAddress.Parse("192.168.1.185"), 600);//Aynı Ip adresi ve porta bağlamaktayız.192.168.1.185 127.0.0.1
            byte[] buffer = Encoding.ASCII.GetBytes(Console.ReadLine());//Ekrana girilecek değer dönüşümü yapılmaktadır.Stream kullanıldığı için veriler byte şeklinde gönderilmektedir.
            s.Send(buffer);
            s.Close();
        }

    }
}
