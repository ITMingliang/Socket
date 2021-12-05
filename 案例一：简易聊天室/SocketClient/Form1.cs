using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class fm_server : Form
    {
        public fm_server()
        {
            InitializeComponent();
        }

        //将远程连接的客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        private void fm_server_Load(object sender, EventArgs e)
        {
            //取消跨主线程访问控件检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void btClearMsg_Click(object sender, EventArgs e)
        {
            tbReceiveContent.Text = "";
        }
        Socket socketSend;
        private void btConnect_Click(object sender, EventArgs e)
        {
            //创建负责通信的Socket
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress serverip = IPAddress.Parse(tbServerIP.Text);
            //创建端口对象
            IPEndPoint point = new IPEndPoint(serverip, Convert.ToInt32(tbPort.Text));
            //获取要连接的远程服务器应用程序的ip地址和端口号
            socketSend.Connect(point);
            ShowMsg("连接成功！");
            //开启一个新的线程，不停的接收服务器发来的消息
            Thread th = new Thread(Receive);
            th.IsBackground = true;
            th.Start();


        }

        /// <summary>
        /// 客户端向服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSendMsg_Click(object sender, EventArgs e)
        {
            string str = tbSendContent.Text.Trim();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            //socketSend.Send(buffer);
            List<byte> list = new List<byte>();
            list.Add(0);
            list.AddRange(buffer);
            //将泛型集合转换为数组
            byte[] newbuffer = list.ToArray();
            socketSend.Send(newbuffer);
        }

        private void btSelecctFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\mingliang\Desktop\TEST\Send";
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            tbFilePath.Text = ofd.FileName;
        }

        private void btZD_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 2;
            socketSend.Send(buffer);
        }

        private void btSendFile_Click(object sender, EventArgs e)
        {
            //获取发送文件的路径
            string filepath = tbFilePath.Text;
            using (FileStream fsRead = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);
                byte[] newbuffer = list.ToArray();
                socketSend.Send(newbuffer, 0, r + 1, SocketFlags.None);
            }
        }

        public void ShowMsg(string str)
        {
            tbReceiveContent.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 不停的接收服务器发来的消息
        /// </summary>
        void Receive()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                //接收数组的实际长度
                int r = socketSend.Receive(buffer);
                if (r==0)
                {
                    break;
                }
                //发送消息
                if (buffer[0] == 0)
                {
                    //字节转为字符串
                    string str = Encoding.UTF8.GetString(buffer, 1, r - 1);
                    ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                }
                //发送文件
                else if (buffer[0] == 1)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.InitialDirectory = @"C:\Users\mingliang\Desktop\TEST\Receive";
                    sfd.Title = "请选择保存文件的目录";
                    sfd.Filter = "所有文件|*.*";
                    sfd.ShowDialog(this);
                    //保存文件
                    string savepath = sfd.FileName;
                    using (FileStream fswrite =new FileStream (savepath,FileMode.OpenOrCreate,FileAccess.Write))
                    {
                        fswrite.Write(buffer, 1, r - 1);
                    }
                    MessageBox.Show("保存成功~");

                }
                //抖动窗口
                else if (buffer[0] == 2)
                {
                    ZD();
                }
               
            }
        }
        void ZD()
        {
            for (int i = 0; i < 50; i++)
            {
                this.Location = new Point(200, 200);
                this.Location = new Point(230, 230);
            }
        }


    }
}
