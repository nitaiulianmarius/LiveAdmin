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
using Microsoft.VisualBasic;

namespace Server
{
    public partial class Form1 : Form
    {
        Form2 imageForm;
        Boolean isShow = false;
        myServer server;
        Thread acceptClientThread;
        Thread handleItemThread;
        Thread handleMessageThread;
        Thread checkConnectionThread;


        public Form1()
        {
            InitializeComponent();
            this.Width = 287;
            imageForm = new Form2();
            imageForm.Show(); imageForm.Hide();


            server = new myServer(27015, 32);

            acceptClientThread = new Thread(acceptClient);
            acceptClientThread.IsBackground = true;
            acceptClientThread.Start();

            handleItemThread = new Thread(handleItem);
            handleItemThread.IsBackground = true;
            handleItemThread.Start();

            handleMessageThread = new Thread(handleMessage);
            handleMessageThread.IsBackground = true;
            handleMessageThread.Start();

            checkConnectionThread = new Thread(checkConnection);
            checkConnectionThread.IsBackground = true;
            //checkConnectionThread.Start();
        }

        private void getInfo_Click(object sender, EventArgs e)
        {
            label1.Text = "Computer information";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("getinfo"));
                    }
                }
            }
        }

        private void getProcessList_Click(object sender, EventArgs e)
        {
            label1.Text = "Process list";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("getprocesslist"));
                    }
                }
            }
        }

        private void getLockedProcess_Click(object sender, EventArgs e)
        {
            label1.Text = "Locked process";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("getlockedprocess"));
                    }
                }
            }
        }

        private void getImage_Click(object sender, EventArgs e)
        {
            label1.Text = "Receive image";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("getimage"));
                    }
                }
            }
        }

        private void ShowHide_Click(object sender, EventArgs e)
        {
            if(isShow)
            {
                this.Width = 287;
                isShow = false;
            }
            else
            {
                this.Width = 640;
                isShow = true;
            }
        }

        private void lockProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Process name:", "Lock process", "", -1, -1);
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("lockprocess " + input));
                    }
                }
            }
        }

        private void unlockProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Process name:", "Unlock process", "", -1, -1);
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("unlockprocess " + input));
                    }
                }
            }
        }

        private void lockScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("lockscreen"));
                    }
                }
            }
        }

        private void unlockScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("unlockscreen"));
                    }
                }
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("logoff"));
                    }
                }
            }
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                for (int i = 0; i < server.numberOfConnectedClients; i++)
                {
                    if (server.clientsList[i].name == item.Text)
                    {
                        server.sendMessage(server.clientsList[i].client, System.Text.Encoding.ASCII.GetBytes("shutdown"));
                    }
                }
            }
        }

        private void acceptClient()
        {
            while (true)
            {
                while (server.isRun == true)
                {
                    try
                    {
                        myClient client = new myClient();
                        client = server.acceptClient();

                        if (client != null)
                        {
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = client.name;
                                item.ImageIndex = 0;
                                listView1.Items.Add(item);
                            }));
                        }
                    }
                    catch
                    {
                        server.isRun = false;
                    }
                }
            }
        }

        private void handleItem()
        {
            while (true)
            {
                while (server.isRun)
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            label2.Text = "Connected clients: " + server.numberOfConnectedClients;

                            if (listView1.SelectedItems.Count == 1)
                            {
                                getInfo.Enabled = true;
                                getProcessList.Enabled = true;
                                getLockedProcess.Enabled = true;
                                getImage.Enabled = true;
                            }
                            else
                            {
                                getInfo.Enabled = false;
                                getProcessList.Enabled = false;
                                getLockedProcess.Enabled = false;
                                getImage.Enabled = false;
                            }
                        }));
                    }
                    catch { }

                    Thread.Sleep(10);
                }
            }
        }

        private void handleMessage()
        {
            while (true)
            {
                while (server.isRun)
                {
                    for (int i = 0; i < server.numberOfConnectedClients; i++)
                    {
                        Byte[] bytes = new Byte[1024 * 1024];
                        bytes = server.receiveMessage(server.clientsList[i].client);
                        String data = System.Text.Encoding.ASCII.GetString(bytes);
                        String[] message;

                        if (data.StartsWith("info"))
                        {
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                listBox1.Items.Clear();
                            }));
                            //bytes = server.receiveMessage(server.clientsList[i].client);
                            //data = System.Text.Encoding.ASCII.GetString(bytes);
                            message = data.Split('#');
                            foreach (String s in message)
                                this.Invoke(new MethodInvoker(delegate()
                                    {
                                        listBox1.Items.Add(s);
                                    }));
                        }

                        if (data.StartsWith("processlist"))
                        {
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                listBox1.Items.Clear();
                            }));
                            //bytes = server.receiveMessage(server.clientsList[i].client);
                            //data = System.Text.Encoding.ASCII.GetString(bytes);
                            message = data.Split('#');
                            foreach (String s in message)
                                this.Invoke(new MethodInvoker(delegate()
                                {
                                    listBox1.Items.Add(s);
                                }));
                        }

                        if (data.StartsWith("lockedprocess"))
                        {
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                listBox1.Items.Clear();
                            }));
                            bytes = server.receiveMessage(server.clientsList[i].client);
                            data = System.Text.Encoding.ASCII.GetString(bytes);
                            message = data.Split('#');
                            foreach (String s in message)
                                this.Invoke(new MethodInvoker(delegate()
                                {
                                    listBox1.Items.Add(s);
                                }));
                        }

                        if (data.StartsWith("image"))
                        {
                            bytes = server.receiveMessage(server.clientsList[i].client);
                            MessageBox.Show(bytes.Length.ToString());
                            Form2 f = new Form2(bytes);
                            imageForm.Invoke((MethodInvoker)delegate()
                            {
                                f.Show();
                            });
                        }
                    }
                } // while (isRun)
            } // while (true)
        } // void handleMessage()

        private void checkConnection()
        {
            while (true)
            {
                while (server.isRun)
                {
                    for (Int32 i = 0; i < server.numberOfConnectedClients; i++)
                    {
                        TcpClient client = server.clientsList[i].client;
                        String nume = server.clientsList[i].name;

                        Int32 check = server.sendMessage(client, System.Text.Encoding.ASCII.GetBytes("somestring"));

                        if (check == 0)
                        {
                            this.Invoke(new MethodInvoker(delegate()
                                {

                                    for (int k = listView1.Items.Count - 1; k >= 0; k--)
                                    {
                                        if (listView1.Items[k].Text == nume)
                                        {
                                            listView1.Items[k].Remove();
                                        }
                                    }


                                    Int32 j;
                                    for (j = 0; j < server.numberOfConnectedClients; j++)
                                        if (server.clientsList[j].client == client)
                                            break;
                                    for (; j < server.numberOfConnectedClients - 1; j++)
                                        server.clientsList[j] = server.clientsList[j + 1];
                                    server.numberOfConnectedClients--;
                                }));
                        }
                    }
                    Thread.Sleep(7000);
                }
                Thread.Sleep(10);
            }
        }
    }
}
