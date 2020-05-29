namespace TP2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.textBoxEnviar = new System.Windows.Forms.TextBox();
            this.textBoxReceber = new System.Windows.Forms.TextBox();
            this.TimerCOM = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(12, 38);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(138, 21);
            this.ButtonConnect.TabIndex = 0;
            this.ButtonConnect.Text = "Conectar";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(156, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(12, 85);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(138, 21);
            this.btEnviar.TabIndex = 2;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // textBoxEnviar
            // 
            this.textBoxEnviar.Location = new System.Drawing.Point(156, 85);
            this.textBoxEnviar.Name = "textBoxEnviar";
            this.textBoxEnviar.Size = new System.Drawing.Size(136, 20);
            this.textBoxEnviar.TabIndex = 3;
            // 
            // textBoxReceber
            // 
            this.textBoxReceber.AcceptsReturn = true;
            this.textBoxReceber.AcceptsTab = true;
            this.textBoxReceber.Location = new System.Drawing.Point(12, 136);
            this.textBoxReceber.Multiline = true;
            this.textBoxReceber.Name = "textBoxReceber";
            this.textBoxReceber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceber.Size = new System.Drawing.Size(776, 302);
            this.textBoxReceber.TabIndex = 4;
            // 
            // TimerCOM
            // 
            this.TimerCOM.Interval = 1000;
            this.TimerCOM.Tick += new System.EventHandler(this.TimerCOM_Tick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(370, 39);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(138, 21);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBoxReceber);
            this.Controls.Add(this.textBoxEnviar);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ButtonConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox textBoxEnviar;
        private System.Windows.Forms.TextBox textBoxReceber;
        private System.Windows.Forms.Timer TimerCOM;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button saveButton;
    }
}

