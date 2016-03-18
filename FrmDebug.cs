using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EBoxClient
{
    public partial class FrmDebug : Form
    {
        public FrmDebug()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            txtInfo.AppendText(string.Format("{0}: {1}", Utils.DateTimeUtils.DateTimeString(),
                       txtCmd.Text + Environment.NewLine));
            txtCmd.SelectAll();
            txtInfo.AppendText(Debugger.Instance.Excute(txtCmd.Text) + Environment.NewLine);
            txtInfo.ScrollToCaret();
        }

        private void FrmDebug_Load(object sender, EventArgs e)
        {
            Debugger.Instance.AfterClientStreamRead += new Action<System.Net.Sockets.NetworkStream, string>(Instance_AfterClientStreamRead);
            Debugger.Instance.AfterServerStreamRead += new Action<System.Net.Sockets.NetworkStream, string>(Instance_AfterServerStreamRead);
            Debugger.Instance.BeforeClientStreamWrite += new Action<System.Net.Sockets.NetworkStream, string, byte[]>(Instance_BeforeClientStreamWrite);
            Debugger.Instance.BeforeServerStreamWrite += new Action<System.Net.Sockets.NetworkStream, string, byte[]>(Instance_BeforeServerStreamWrite);
            Debugger.Instance.OnServerStart += new Action<System.Net.Sockets.TcpListener>(Instance_OnServerStart);
            Debugger.Instance.OnClientConnnected += new Action<System.Net.Sockets.TcpClient>(Instance_OnClientConnnected);
        }

        void Instance_OnClientConnnected(System.Net.Sockets.TcpClient obj)
        {
            Invoke(new Action(() =>
            {
                txtInfo.AppendText(string.Format("[0]: {1}", Utils.DateTimeUtils.DateTimeString(),
                    "新客户端已连接！" + Environment.NewLine));
            }));
            Utils.LogHelper.Log(string.Format("[0]: {1}", Utils.DateTimeUtils.DateTimeString(),
                    "新客户端已连接！" + Environment.NewLine));
        }

        void Instance_OnServerStart(System.Net.Sockets.TcpListener obj)
        {
            Invoke(new Action(() =>
            {
                txtInfo.AppendText(string.Format("{0}: {1}", Utils.DateTimeUtils.DateTimeString(),
                    "服务器启动！" + Environment.NewLine));
            }));
            Utils.LogHelper.Log(string.Format("{0}: {1}", Utils.DateTimeUtils.DateTimeString(),
                    "服务器启动！" + Environment.NewLine));
        }

        void Instance_BeforeServerStreamWrite(System.Net.Sockets.NetworkStream arg1, string arg2, byte[] arg3)
        {
            //Invoke(new Action(() =>
            //{
            //    txtInfo.AppendText("Server Write: " + arg2 + Environment.NewLine);
            //}));
            Utils.LogHelper.Log("Server Write: " + arg2 + Environment.NewLine);
        }
        void Instance_BeforeClientStreamWrite(System.Net.Sockets.NetworkStream arg1, string arg2, byte[] arg3)
        {
            //Invoke(new Action(() =>
            //{
            //    txtInfo.AppendText("Client Write" + arg2 + Environment.NewLine);
            //}));
            Utils.LogHelper.Log("Client Write: " + arg2 + Environment.NewLine);
        }

        void Instance_AfterServerStreamRead(System.Net.Sockets.NetworkStream arg1, string arg2)
        {
            //this.Invoke(new Action(() =>
            //{
            //    txtInfo.AppendText("Server Read" + arg2 + Environment.NewLine);
            //}));
            Utils.LogHelper.Log("Server Read: " + arg2 + Environment.NewLine);
        }

        void Instance_AfterClientStreamRead(System.Net.Sockets.NetworkStream arg1, string arg2)
        {
            //Invoke(new Action(() =>
            //{
            //    txtInfo.AppendText("Client Read" + arg2 + Environment.NewLine);
            //}));
            Utils.LogHelper.Log("Client Read: " + arg2 + Environment.NewLine);
        }
    }
}
