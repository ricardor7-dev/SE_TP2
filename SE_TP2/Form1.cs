using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Syroot.Windows.IO;

namespace SE_TP2
{
    public partial class MainForm : Form
    {
        private SerialPort port;
        private DateTime dateTime;
        private string in_data;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = porta.Text;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.DataReceived += portDataReceveid;

            try
            {
                port.Open();
                data.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                throw;
            }


        }

        void portDataReceveid(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = port.ReadLine();

            this.Invoke(new EventHandler(displayDataEvent));
        }

        private void displayDataEvent(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;
            string time = dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
            data.Text = time + "\t" + in_data + "\n";

            int dataValue = Convert.ToInt32(in_data);

            
        }

        private void stop_Click(object sender, EventArgs e)
        {
            try
            {
                port.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                throw;
            }
        }

        private void saveClick(object sender, EventArgs e)
        {
            try
            {
                var outputPath = new KnownFolder(KnownFolderType.Downloads).Path;
                outputPath += @"\data.txt";
                System.IO.File.WriteAllText(outputPath, data.Text);
                MessageBox.Show(@"Informação guardada");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                throw;
            }
        }
    }
}
