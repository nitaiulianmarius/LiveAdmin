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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Client
{
    class User
    {
        public string name;
        public string localIP;
        public string OSName;
        public string OSType;
        public string cpu;
        public string cpuFreq;
        public string ram;
        public string video;

        public User()
        {
            name = System.Net.Dns.GetHostName();
            localIP = LocalIPAddress();
            OSName = OSInfo.Name + " " + OSInfo.Edition + " " + OSInfo.ServicePack;
            OSType = "x" + OSInfo.Bits.ToString();
            cpu = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            cpuFreq = getClockSpeedCPU().ToString() + " Hz";
            ram = getRAM().ToString() + " Mb";
            video = getVideo();
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public uint getClockSpeedCPU()
        {
            var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            uint clockSpeed = new uint();
            foreach (var item in searcher.Get())
            {
                clockSpeed = (uint)item["MaxClockSpeed"];
            }
            return clockSpeed;
        }

        public ulong getRAM()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1048576;
        }

        public string getVideo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        graphicsCard = property.Value.ToString();
                    }
                }
            }
            return graphicsCard;
        }
    }
}
