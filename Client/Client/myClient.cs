using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Client
{
    class myClient
    {
        public Int32 port;
        public String Addr;
        public TcpClient client;
        public NetworkStream stream;
        public String name;
        public String[] lockedProcessList = new String[256];
        public Int32 numberOfLockedProcess = 0;
        public Boolean isRun;

        public myClient(String ip, Int32 p)
        {
            Addr = ip;
            port = p;
            name = System.Net.Dns.GetHostName();

            while (isRun == false)
            {
                try
                {
                    client = new TcpClient(ip, p);
                    stream = client.GetStream();

                    isRun = true;
                }
                catch
                {
                    isRun = false;
                }
                Thread.Sleep(10);
            }

            sendMessage(System.Text.Encoding.ASCII.GetBytes(name));
        }


        public void stop()
        {
            stream.Close();
            client.Close();

            isRun = false;
        }


        public Byte[] receiveMessage()
        {
            if (isRun)
            {
                try
                {
                    Byte[] bytes = new Byte[1024 * 1024];

                    stream.Read(bytes, 0, bytes.Length);
                    return bytes;
                }
                catch
                {
                    isRun = false;
                    return null;
                }
            }
            return null;
        }


        public Int32 sendMessage(Byte[] bytes)
        {
            if (isRun)
            {
                try
                {
                    stream.Write(bytes, 0, bytes.Length);
                    return 1;
                }
                catch { return 0; }
            }
            return 0;
        }

        public Byte[] GetDesktopImageAsBytes()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height);
            Graphics graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            return (Byte[])new ImageConverter().ConvertTo(screenshot, typeof(Byte[]));
        }
    }
}
