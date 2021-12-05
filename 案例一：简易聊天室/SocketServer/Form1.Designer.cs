
namespace SocketServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btSendMsg = new System.Windows.Forms.Button();
            this.btZD = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.tbSendContent = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSendFile = new System.Windows.Forms.Button();
            this.btListener = new System.Windows.Forms.Button();
            this.tbReceiveContent = new System.Windows.Forms.RichTextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSelecctFile = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClients = new System.Windows.Forms.ComboBox();
            this.btClearMsg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSendMsg
            // 
            this.btSendMsg.Location = new System.Drawing.Point(522, 284);
            this.btSendMsg.Name = "btSendMsg";
            this.btSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btSendMsg.TabIndex = 32;
            this.btSendMsg.Text = "发送消息";
            this.btSendMsg.UseVisualStyleBackColor = true;
            this.btSendMsg.Click += new System.EventHandler(this.btSendMsg_Click);
            // 
            // btZD
            // 
            this.btZD.Location = new System.Drawing.Point(522, 397);
            this.btZD.Name = "btZD";
            this.btZD.Size = new System.Drawing.Size(75, 23);
            this.btZD.TabIndex = 31;
            this.btZD.Text = "震动窗口";
            this.btZD.UseVisualStyleBackColor = true;
            this.btZD.Click += new System.EventHandler(this.btZD_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(166, 365);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(325, 21);
            this.tbFilePath.TabIndex = 30;
            // 
            // tbSendContent
            // 
            this.tbSendContent.Location = new System.Drawing.Point(166, 281);
            this.tbSendContent.Name = "tbSendContent";
            this.tbSendContent.Size = new System.Drawing.Size(325, 47);
            this.tbSendContent.TabIndex = 29;
            this.tbSendContent.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "文件地址：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "发送消息：";
            // 
            // btSendFile
            // 
            this.btSendFile.Location = new System.Drawing.Point(630, 365);
            this.btSendFile.Name = "btSendFile";
            this.btSendFile.Size = new System.Drawing.Size(75, 23);
            this.btSendFile.TabIndex = 26;
            this.btSendFile.Text = "发送文件";
            this.btSendFile.UseVisualStyleBackColor = true;
            this.btSendFile.Click += new System.EventHandler(this.btSendFile_Click);
            // 
            // btListener
            // 
            this.btListener.Location = new System.Drawing.Point(533, 38);
            this.btListener.Name = "btListener";
            this.btListener.Size = new System.Drawing.Size(75, 23);
            this.btListener.TabIndex = 25;
            this.btListener.Text = "开始监听";
            this.btListener.UseVisualStyleBackColor = true;
            this.btListener.Click += new System.EventHandler(this.btListener_Click);
            // 
            // tbReceiveContent
            // 
            this.tbReceiveContent.Location = new System.Drawing.Point(103, 76);
            this.tbReceiveContent.Name = "tbReceiveContent";
            this.tbReceiveContent.Size = new System.Drawing.Size(388, 130);
            this.tbReceiveContent.TabIndex = 24;
            this.tbReceiveContent.Text = "";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(166, 38);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(194, 21);
            this.tbIP.TabIndex = 22;
            this.tbIP.Text = "192.168.1.20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "IP/端口：";
            // 
            // btSelecctFile
            // 
            this.btSelecctFile.Location = new System.Drawing.Point(522, 363);
            this.btSelecctFile.Name = "btSelecctFile";
            this.btSelecctFile.Size = new System.Drawing.Size(75, 23);
            this.btSelecctFile.TabIndex = 18;
            this.btSelecctFile.Text = "选择文件";
            this.btSelecctFile.UseVisualStyleBackColor = true;
            this.btSelecctFile.Click += new System.EventHandler(this.btSelecctFile_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(378, 38);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(80, 21);
            this.tbPort.TabIndex = 17;
            this.tbPort.Text = "2021";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "发送对象：";
            // 
            // cbClients
            // 
            this.cbClients.FormattingEnabled = true;
            this.cbClients.Location = new System.Drawing.Point(166, 242);
            this.cbClients.Name = "cbClients";
            this.cbClients.Size = new System.Drawing.Size(325, 20);
            this.cbClients.TabIndex = 34;
            // 
            // btClearMsg
            // 
            this.btClearMsg.Location = new System.Drawing.Point(533, 90);
            this.btClearMsg.Name = "btClearMsg";
            this.btClearMsg.Size = new System.Drawing.Size(75, 23);
            this.btClearMsg.TabIndex = 35;
            this.btClearMsg.Text = "清空消息";
            this.btClearMsg.UseVisualStyleBackColor = true;
            this.btClearMsg.Click += new System.EventHandler(this.btClearMsg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btClearMsg);
            this.Controls.Add(this.cbClients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSendMsg);
            this.Controls.Add(this.btZD);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.tbSendContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSendFile);
            this.Controls.Add(this.btListener);
            this.Controls.Add(this.tbReceiveContent);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSelecctFile);
            this.Controls.Add(this.tbPort);
            this.Name = "Form1";
            this.Text = "SocketServer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSendMsg;
        private System.Windows.Forms.Button btZD;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.RichTextBox tbSendContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSendFile;
        private System.Windows.Forms.Button btListener;
        private System.Windows.Forms.RichTextBox tbReceiveContent;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSelecctFile;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClients;
        private System.Windows.Forms.Button btClearMsg;
    }
}

