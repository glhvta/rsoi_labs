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
                    ClientObject clientObject = new ClientObject(client, filePath);

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
        private string filePath = "";

        public ClientObject(TcpClient tcpClient, string filePath)
        {
            this.client = tcpClient;
            this.filePath = filePath;
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
                    string responseData = cmd;

                    switch (cmd)
                    {
                        case "view": responseData = getDataFromFile(); break;
                        case "add": {
                            appendDataToFile(message); 
                            responseData = "Данные были добавлены!\r\n" + getDataFromFile(); 
                            break;
                        }
                        default: break;
                    }

                    response = Encoding.Unicode.GetBytes(responseData);
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

        /**
         *  File processing logic
         */

        /**
         *  Read all file data
         *  @return string data
         */
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

        /**
         *  Add new item to the file
         *  
         *  @param string - data
         *  If split by '|' name = data[1], cost = data[2]
         *  
         *  @return string data
         */
        private void appendDataToFile(string data)
        {
            string[] dataArr = data.Split(new[] { '|' });
            StreamWriter sw = null;

            try
            {
                string name = dataArr[1];
                string cost = dataArr[2];

                sw = new StreamWriter(filePath, true, System.Text.Encoding.Default);
                sw.WriteLine(Config.numberCount++ + ": " + name + "  $" + cost);
            }
            catch
            {
                Console.WriteLine("Ошибка при записи в файл:(");
            }
            finally
            {
                sw.Close();
            }
        }

    }

    /**
     *As a way to control numbers of icecreams 
     */
    public class Config
    {
        public static int numberCount = 1;
    }

}
