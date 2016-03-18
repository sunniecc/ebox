using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EBoxClient.Device;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using EBoxClient.Utils;

namespace EBoxClient
{
    public class Debugger
    {
        private Debugger() { }

        public static readonly Debugger Instance = new Debugger();
        public FrmMain Host { get; set; }
        public BoxDoor BoxDoor { get; set; }
        public ElcWeight ElcWeight { get; set; }
        public IDValidDevice IDValidDevice { get; set; }
        public ShenZhenPay ShenZhenPay { get; set; }

        public event Action<NetworkStream, string, byte[]> BeforeServerStreamWrite;
        public event Action<NetworkStream, string> AfterServerStreamRead;
        public event Action<NetworkStream, string, byte[]> BeforeClientStreamWrite;
        public event Action<NetworkStream, string> AfterClientStreamRead;
        public event Action<TcpListener> OnServerStart;
        public event Action<TcpClient> OnClientConnnected;

        public string Excute(string cmd)
        {
            if (cmd.ToLower() == "readid")
            {
                var id = DateTime.Now.Ticks.ToString();
                IDValidDevice.MockReadID(id + ",姓名" + DateTime.Now.Second);
                return string.Format("模拟读取到身份证：{0}", id);
            }
            else if (cmd.ToLower() == "server")
            {
                StartServer();
            }
            else if (cmd.ToLower().StartsWith("client"))
            {
                var arg = cmd.Substring("client".Length);
                if (string.IsNullOrEmpty(arg))
                {
                    if (client == null)
                    {
                        client = new TcpClient();
                        client.Connect("127.0.0.1", Setting.Instance.ServerPort);
                    }
                }
                else
                    ClientCmd(arg.Trim());
            }
            else if (cmd.ToLower().StartsWith("goto "))
            {
                var arg = cmd.Substring("goto ".Length);
                if (!string.IsNullOrEmpty(arg))
                {
                    Host.InvokeJs("geturl", new object[] { arg });
                }
            }
            else if (cmd.ToLower().StartsWith("mockserver "))
            {
                var arg = cmd.Substring("mockserver ".Length);
                TcpClientHelper.Instance.MockRecData(arg);
            }

            return string.Empty;
        }

        TcpClient client = null;
        public void ClientCmd(string arg)
        {
            var sm = client.GetStream();

            var buf = Encoding.UTF8.GetBytes(arg);
            var time = Utils.DateTimeUtils.DateTimeString();
            BeforeClientStreamWrite(sm, arg, buf);
            sm.Write(buf, 0, buf.Length);
            var rbuf = new byte[client.ReceiveBufferSize];
            sm.Read(rbuf, 0, rbuf.Length);
            var str = Encoding.UTF8.GetString(rbuf).Trim('\0');
            AfterClientStreamRead(sm, str);
        }

        public void StartServer()
        {
            TcpListener listener = new TcpListener(
                System.Net.IPAddress.Parse("127.0.0.1"), Setting.Instance.ServerPort);
            listener.Start();
            if (OnServerStart != null)
                OnServerStart(listener);

            var th = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    var client = listener.AcceptTcpClient();
                    if (OnClientConnnected != null)
                        OnClientConnnected(client);
                    var clientTh = new Thread(new ParameterizedThreadStart(p =>
                    {
                        var str = string.Empty;
                        while (str.ToLower().Trim() != "stop")
                        {
                            var c = (p as object[])[0] as TcpClient;
                            var sm = c.GetStream();
                            var host = ((p as object[])[1] as Control);
                            var rbuf = new byte[c.ReceiveBufferSize];
                            sm.Read(rbuf, 0, rbuf.Length);
                            str = Encoding.UTF8.GetString(rbuf).Trim('\0');
                            if (AfterServerStreamRead != null)
                                AfterServerStreamRead(sm, str);

                            var time = Utils.DateTimeUtils.DateTimeString();
                            var buf = Encoding.UTF8.GetBytes(time);
                            if (BeforeServerStreamWrite != null)
                                BeforeServerStreamWrite(sm, time, buf);
                            sm.Write(buf, 0, buf.Length);
                            sm.Flush();
                            Thread.Sleep(2000);
                        }
                    }));
                    clientTh.IsBackground = true;
                    clientTh.Start(new object[] { client, Host });
                }
            }));
            th.IsBackground = true;
            th.Start();
        }
    }
}
