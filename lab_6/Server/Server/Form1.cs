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

namespace Server
{
    public partial class Form1 : Form
    {
        private int port = 5555;
        static string filePath = "D:\\Университет\\3 курс\\6 семестр\\РСОИ\\rsoi_labs\\lab_6\\Server\\data.txt";

        TcpListener listener = null;
        Socket socket = null;
        NetworkStream ns = null;
        ASCIIEncoding ae = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            socket = listener.AcceptSocket();

            if (socket.Connected) {
                ns = new NetworkStream(socket);
                ae = new ASCIIEncoding();

                ThreadClass threadClass = new ThreadClass();
                Thread thread = threadClass.Start(ns, filePath, this);
            }
        }
    }

    public class ThreadClass {
        Form1 form = null;
        NetworkStream ns = null;
        ASCIIEncoding ae = null;

        string filePath = "";

        public Thread Start(NetworkStream ns, string filePath, Form1 form)
        {
            this.ns = ns;
            ae = new ASCIIEncoding();

            this.form = form;

            Thread thread = new Thread(new ThreadStart(ThreadOperations));
            thread.Start();

            return thread;
        }

        public void ThreadOperations() {
            byte[] received = new byte[256];
            byte[] sent = new byte[256]; 

            ns.Read(received, 0, received.Length);
            String s1 = ae.GetString(received);

            String cmd = s1.Substring(0, s1.IndexOf("|", 0));
            String data = "";

            switch (cmd)
            {
                case "1": data = getDataFromFile(); break;
                default: return;
            }

            sent = ae.GetBytes(data);
            ns.Write(sent, 0, sent.Length); 
        }

        private string getDataFromFile()
        {
            StreamReader sr = null;
            string data = "";

            try
            {
                sr = new StreamReader(filePath, System.Text.Encoding.Default);
                data = sr.ReadToEnd();

            }
            catch
            {
                Console.WriteLine("Ошибка при чтении");
            }
            finally
            {
                sr.Close();
            }

            return data;
        }

    }
}
