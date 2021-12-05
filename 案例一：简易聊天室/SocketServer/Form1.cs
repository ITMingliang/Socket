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

namespace SocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //将远程连接的客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        private void btListener_Click(object sender, EventArgs e)
        {
            //在服务器端创建一个负责监听IP地址和端口的Socket
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any; // IPAddress.Parse(tbIP.Text);
            //创建端口对象
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(tbPort.Text));
            //监听
            socketWatch.Bind(point);
            ShowMsg("监听成功");
            //设置监听最大客户端数量
            socketWatch.Listen(10);
            ////等待客户端的连接，并创建一个负责通信的Socket
            //Socket socketSend = socketWatch.Accept();
            //ShowMsg(socketSend.RemoteEndPoint.ToString()+":"+"连接成功！");

            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketWatch);

        }

        /// <summary>
        /// 等待客户端的连接，并创建一个负责通信的Socket
        /// </summary>
        /// <param name="socketWatch"></param>
        void Listen( object o)
        {
            //object 转为 Socket
            Socket socketWatch = o as Socket;
            //等待客户端的连接，并创建一个负责通信的Socket
            while (true)
            {
                try
                {
                    Socket socketSend = socketWatch.Accept();
                    //将远程的连接的客户端的IP地址和Socket存入集合中
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    //将远程的连接的客户端的IP地址和Socket加入到下拉框
                    cbClients.Items.Add(socketSend.RemoteEndPoint.ToString());
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功！");

                    Thread th = new Thread(Receive);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch (Exception)
                {
                }
            }

        }

        void Receive(object o)
        {
            Socket socketSend = o as Socket;
            while (true)
            {
                try
                {
                    //客户端连接成功后，服务器应嘎爱接收客户发来的消息
                    byte[] buffer = new byte[104 * 1024 * 3];
                    //返回实际接收的有效字节长度
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    if (buffer[0]==0)
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
                        sfd.ShowDialog(this);//加this
                        //保存文件
                        string savepath = sfd.FileName;
                        using (FileStream fswrite = new FileStream(savepath, FileMode.OpenOrCreate, FileAccess.Write))
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
                catch (Exception)
                {
                }
            }
        }
        private void btSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                string str = tbSendContent.Text.Trim();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newbuffer = list.ToArray();
                //获取用户在下拉框中选中的ip地址
                string ip = cbClients.SelectedItem.ToString();
                dicSocket[ip].Send(newbuffer);

            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 发送震动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btZD_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 2;
            dicSocket[cbClients.SelectedItem.ToString()].Send(buffer);
        }
        void ZD()
        {
            for (int i = 0; i < 50; i++)
            {
                this.Location = new Point(200,200);
                this.Location = new Point(230, 230);
            }
        }


        private void btSendFile_Click(object sender, EventArgs e)
        {
            //获取发送文件的路径
            string filepath = tbFilePath.Text;
            using (FileStream fsRead=new FileStream(filepath,FileMode.Open,FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);
                byte[] newbuffer = list.ToArray();
                dicSocket[cbClients.SelectedItem.ToString()].Send(newbuffer, 0,r+1,SocketFlags.None); 
               
            }
        }

      /// <summary>
      /// 选择发送的文件
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void btSelecctFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\mingliang\Desktop\TEST\Send";
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            tbFilePath.Text = ofd.FileName;
        }

        public void ShowMsg(string str)
        {
            tbReceiveContent.AppendText(str+"\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨主线程访问控件检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btClearMsg_Click(object sender, EventArgs e)
        {
            tbReceiveContent.Text = "";
        }
    }
}
