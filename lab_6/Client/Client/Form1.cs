using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading; 

namespace Client
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            String res = "1|";
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TcpClient tcp_client = null;
            NetworkStream stream = null;

            try
            {
                tcp_client = new TcpClient("localhost", 5555);

                stream = tcp_client.GetStream();
                String res = "1|blablabla";

                byte[] sentData = Encoding.Unicode.GetBytes(res);
                byte[] recievedData = new byte[256];

                stream.Write(sentData, 0, sentData.Length);
                stream.Read(recievedData, 0, recievedData.Length);

                textBox1.Text = Encoding.Unicode.GetString(recievedData);
            }
            catch
            {
                Console.Write("error");
            }
            finally {
                tcp_client.Close();
            }
        }
    }
}
