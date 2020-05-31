using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Syroot.Windows.IO;

namespace TP2
{
    public partial class Form1 : Form
    {
        private string _data;

        public Form1()
        {
            InitializeComponent();
            TimerCOM.Enabled = true;
        }

        private void ComList()
        {
            var i = 0;
            var comPorts = false;

            if (comboBox1.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (var s in SerialPort.GetPortNames())
                {
                    if (comboBox1.Items[i++].Equals(s) == false)
                    {
                        comPorts = true;
                    }
                }
            }
            else
            {
                comPorts = true;
            }

            if (comPorts == false)
            {
                return;
            }

            comboBox1.Items.Clear();

            foreach (var s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void TimerCOM_Tick(object sender, EventArgs e)
        {
            ComList();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.Open();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }

                if (!serialPort1.IsOpen) return;

                ButtonConnect.Text = "Desconectar";
                comboBox1.Enabled = false;
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    comboBox1.Enabled = true;
                    ButtonConnect.Text = "Connectar";
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(textBoxEnviar.Text);
            }
        }

        private void BtLigar_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) return;

            var thread = new Thread(new ThreadStart(DoWork));
            thread.Start();
        }

        private void DoWork()
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                var output = DateTime.Now + ":";
                textBoxReceber.AppendText(output);
                textBoxReceber.AppendText(Environment.NewLine);
                serialPort1.Write("0");
            }));

            try
            {
                while (serialPort1.ReadByte() != -1)
                {
                    _data = serialPort1.ReadLine();

                    //corre na ui thread
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        textBoxReceber.AppendText(_data);
                        textBoxReceber.AppendText(Environment.NewLine);
                    }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var outputPath = new KnownFolder(KnownFolderType.Downloads).Path;
                outputPath += @"\data.txt";
                System.IO.File.WriteAllText(outputPath, textBoxReceber.Text);
                MessageBox.Show(@"Informação guardada");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                throw;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            var messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
        }
    }
}