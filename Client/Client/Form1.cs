using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Client
{
    public partial class Form1 : Form
    {

        myClient client;
        Thread startClientThread;
        Thread handleMessageThread;
        Thread blockProcessThread;
        Thread checkConnectionThread;


        public Form1()
        {
            InitializeComponent();

            startClientThread = new Thread(startClient);
            startClientThread.IsBackground = true;
            startClientThread.Start();
        }

        private void startClient()
        {
            client = new myClient("127.0.0.1", 27015);

            this.Invoke(new MethodInvoker(delegate()
            {
                history.Items.Add("Send " + client.name);
            }));

            handleMessageThread = new Thread(handleMessage);
            handleMessageThread.IsBackground = true;
            handleMessageThread.Start();

            blockProcessThread = new Thread(blockProcess);
            blockProcessThread.IsBackground = true;
            blockProcessThread.Start();
        }

        private void blockProcess()
        {
            while (true)
            {
                while (client.isRun)
                {
                    for (int i = 0; i < client.numberOfLockedProcess; i++)
                    {
                        foreach (Process proc in Process.GetProcessesByName(client.lockedProcessList[i]))
                        {
                            try
                            {
                                proc.Kill();
                            }
                            catch
                            {
                                ;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1);
                }
            }
        }

        private void handleMessage()
        {
            while (true)
            {
                while (client.isRun)
                {

                    Byte[] bytes;

                    bytes = client.receiveMessage();

                    if (bytes != null)
                    {
                        String data = System.Text.Encoding.ASCII.GetString(bytes);

                        this.Invoke(new MethodInvoker(delegate()
                            {
                                history.Items.Add("Recv: " + data);
                            }));

                        if (data.StartsWith("getinfo"))
                        {
                            //client.sendMessage(System.Text.Encoding.ASCII.GetBytes("info"));
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                history.Items.Add("Send: info");
                            }));

                            User me = new User();
                            data = "info#" + 
                                "Computer name: \t" + me.name + "#" +
                                "Local IP: \t\t" + me.localIP + "#" +
                                "OS name: \t" + me.OSName + "#" +
                                "OS type: \t\t" + me.OSType + "#" +
                                "CPU name: \t" + me.cpu + "#" +
                                "CPU frequency: \t" + me.cpuFreq + "#" +
                                "Memory RAM: \t" + me.ram + "#" +
                                "Video name: \t" + me.video;

                            client.sendMessage(System.Text.Encoding.ASCII.GetBytes(data));
                        }

                        if (data.StartsWith("getprocesslist"))
                        {
                            data = "processlist#";
                            //client.sendMessage(System.Text.Encoding.ASCII.GetBytes("processlist"));
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                history.Items.Add("Send: processlist");
                            }));

                            Process[] processlist = Process.GetProcesses();
                            foreach (Process theprocess in processlist)
                            {
                                data += theprocess.ProcessName + '#';
                            }
                            client.sendMessage(System.Text.Encoding.ASCII.GetBytes(data));
                        }

                        if (data.StartsWith("getlockedprocess"))
                        {
                            data = "lockedprocess#";
                            //client.sendMessage(System.Text.Encoding.ASCII.GetBytes("lockedprocess"));
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                history.Items.Add("Send: lockedprocess");
                            }));

                            for (int i = 0; i < client.numberOfLockedProcess; i++)
                            {
                                data += client.lockedProcessList[i] + '#';
                            }
                            client.sendMessage(System.Text.Encoding.ASCII.GetBytes(data));
                        }

                        if (data.StartsWith("getimage"))
                        {
                            client.sendMessage(System.Text.Encoding.ASCII.GetBytes("image"));
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                history.Items.Add("Send: image");
                            }));

                            client.sendMessage(client.GetDesktopImageAsBytes());
                        }

                        if (data.StartsWith("lockprocess"))
                        {
                            int i = 12, j = i;
                            while (data[j++] != '\0') ;
                            StringBuilder processName = new StringBuilder(data, i, j - i - 1, 64);
                            client.lockedProcessList[client.numberOfLockedProcess++] = processName.ToString();
                        }

                        if (data.StartsWith("unlockprocess"))
                        {
                            int i = 14, j, k = i;
                            while (data[k++] != '\0') ;
                            StringBuilder processName = new StringBuilder(data, i, k - i - 1, 64);
                            for (j = 0; j < client.numberOfLockedProcess; j++)
                                if (client.lockedProcessList[j] == processName.ToString())
                                {
                                    for (; j < client.numberOfLockedProcess - 1; j++)
                                        client.lockedProcessList[j] = client.lockedProcessList[j + 1];
                                    client.numberOfLockedProcess--;
                                }
                        }

                        if (data.StartsWith("lockscreen"))
                        {
                            this.Invoke(new MethodInvoker(delegate()
                                {
                                    this.TopMost = true;
                                    this.FormBorderStyle = FormBorderStyle.None;
                                    this.WindowState = FormWindowState.Maximized;
                                    BlockInput(true);
                                }));
                        }

                        if (data.StartsWith("unlockscreen"))
                        {
                            this.Invoke(new MethodInvoker(delegate()
                                {
                                    this.TopMost = false;
                                    this.FormBorderStyle = FormBorderStyle.Sizable;
                                    this.WindowState = FormWindowState.Normal;
                                    BlockInput(false);
                                }));
                        }

                        if (data.StartsWith("logoff"))
                        {
                            var p = new ProcessStartInfo("shutdown", "/l");
                            Process.Start(p);
                        }

                        if (data.StartsWith("shutdown"))
                        {
                            var p = new ProcessStartInfo("shutdown", "/s /f /t 60");
                            Process.Start(p);
                        }
                    } // bytes != null
                } // is run
                Thread.Sleep(10);
            } // while true
        } // handlemessage

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void BlockInput([In, MarshalAs(UnmanagedType.Bool)]bool fBlockIt);

        private void checkConnection()
        {
            while (true)
            {
                Int32 check = client.sendMessage(System.Text.Encoding.ASCII.GetBytes("somestring"));
                if (check == 0 || !client.isRun)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    this.Close(); //to turn off current app
                }
                Thread.Sleep(7000);
            }
        }
    } // form1
}
