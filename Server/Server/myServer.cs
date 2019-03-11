using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{

    class myClient
    {
        public string name;
        public TcpClient client;
    }

    class myServer
    {

        public Int32 port;
        public IPAddress Addr;
        public TcpListener server;
        public myClient[] clientsList = new myClient[256];
        public Int32 maxSlot;
        public Int32 numberOfConnectedClients = 0;
        public String name;
        public Boolean isRun = false;

        public myServer()
        {
            isRun = false;
        }

        public myServer(Int32 p, Int32 slot)
        {
            port = p;
            maxSlot = slot;

            Addr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(p);

            server.Start();

            isRun = true;
        }


        public void stop()
        {
            try
            {
                foreach (myClient client in clientsList)
                    client.client.Close();
            }
            catch { ; }

            server.Stop();

            isRun = false;
        }


        public myClient acceptClient()
        {
            if (numberOfConnectedClients < maxSlot)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    String name = receiveName(client);

                    Thread thread = new Thread(() => receiveMessage(client));
                    thread.IsBackground = true;
                    thread.Start();

                    myClient myclient = new myClient();
                    myclient.client = client;
                    myclient.name = name;
                    clientsList[numberOfConnectedClients++] = myclient;

                    return myclient;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public String receiveName(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            Byte[] bytes = new Byte[64];
            String data;

            stream.Read(bytes, 0, bytes.Length);
            data = System.Text.Encoding.ASCII.GetString(bytes);
            int i = 0;
            while (data[i++] != '\0') ;

            return data.Substring(0, i-1);
        }


        public Byte[] receiveMessage(TcpClient client)
        {
            if (isRun)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    Byte[] bytes = new Byte[1024 * 1024];

                    stream.Read(bytes, 0, bytes.Length);

                    return bytes;
                }
                catch
                {
                    // clientul s-a deconectat
                    return System.Text.Encoding.ASCII.GetBytes("-1");
                }
            }
            return System.Text.Encoding.ASCII.GetBytes("-1");
        }


        public Int32 sendMessage(TcpClient client, Byte[] bytes)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                stream.Write(bytes, 0, bytes.Length);
                return 1;
            }
            catch
            {
                return 0;
                // clientul s-a deconectat
            }
        }


        public void sendMessageToAll(Byte[] bytes)
        {
            for (int i = 0; i < numberOfConnectedClients; i++)
            {
                sendMessage(clientsList[i].client, bytes);
            }
        }

    } // myServer class
} // namespace Server
