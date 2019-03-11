using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Server
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Byte[] bytes)
        {
            InitializeComponent();

            pictureBox1.Image = ConvertByteArrayToBitmap(bytes);
        }

        public Bitmap ConvertByteArrayToBitmap(byte[] receivedBytes)
        {
            MemoryStream ms = new MemoryStream(receivedBytes);
            return new Bitmap(ms, false);
        }
    }
}
