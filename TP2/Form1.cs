using System;
using System.IO.Ports;
using System.Windows.Forms;
using Syroot.Windows.IO;

namespace TP2
{
    public partial class Form1 : Form
    {
        private string _rxString;
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

                //Escrever o menu
                this.Invoke(new EventHandler(WriteMenu));
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

        //resolver
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(textBoxEnviar.Text);
            }
            this.Invoke(new EventHandler(serialPort1_DataReceived));
        }

        private void serialPort1_DataReceived(object sender, EventArgs e)
        {
            _rxString = serialPort1.ReadExisting();
            _data = DateTime.Now + " " + ":" + " " + _rxString;
            textBoxReceber.AppendText(_data);

            this.Invoke(new EventHandler(trataDadoRecebido));
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            textBoxReceber.AppendText(_data);
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

        private void WriteMenu(object sender, EventArgs e)
        {
            var data = serialPort1.ReadExisting();
            data = DateTime.Now + " " + ":" + " " + data;
            textBoxReceber.AppendText(data);
        }
    }
}