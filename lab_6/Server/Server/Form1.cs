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
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }

    }

    public class ClientObject
    {
        public TcpClient client;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64];
                byte[] response = new byte[1024];

                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    string cmd = message.Substring(0, message.IndexOf("|", 0));
                    string responseData = message;

                    /**switch (cmd)
                    {
                        case "1": responseData = getDataFromFile(); break;
                        default: return;
                    }*/

                    response = Encoding.Unicode.GetBytes(responseData.Trim().ToUpper());
                    stream.Write(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }

}

    /**public class ThreadClass
    {
        Form1 form = null;
        public TcpClient client;

        NetworkStream ns = null;
        ASCIIEncoding ae = null;

        string filePath = "";
 

        public Thread Start(NetworkStream ns, string filePath, Form1 form)
        {
            this.ns = ns;
            this.filePath = filePath;
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
            ns.Close();
        }

        private string getDataFromFile()
        {
            StreamReader sr = null;
            string data = "";

            try
            {
                sr = new StreamReader(this.filePath, System.Text.Encoding.Default);
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
}*/
