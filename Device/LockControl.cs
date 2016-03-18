using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using EBoxClient.Utils;



namespace EBoxClient.Device.lc
{
    class LockControl
    {
        SerialPort serialPort;

        public bool OpenPort(string portName)
        {
            try
            {
                serialPort = new SerialPort();
                serialPort.PortName = "COM" + portName;
                serialPort.BaudRate = 38400;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.ReadTimeout = 200;
                serialPort.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool unLock(int cabinetId, string lockId)
        {
            DateTime startTime = DateTime.Now;
            int lockIdInt = int.Parse(lockId);
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(0xA0 + cabinetId);
            bytes[1] = 0x03;
            bytes[2] = (byte)int.Parse(lockId);
            bytes[3] = (byte)(((bytes[0] + bytes[1] + bytes[2]) ^ 0xFF) % 0x100);
            LogHelper.Log("LockControl:unLock:" + bytes[0] + "," + bytes[1] + "," + bytes[2] + "," + bytes[3]);

            try
            {
                serialPort.Write(bytes, 0, 4);
                /**
                while (true)
                {
                    int[] resultIntArray = getLockStatusBytes(cabinetId);
                    long resultInt = parseStatusInt(resultIntArray);
                    if (checkStatus(resultInt, lockIdInt))
                    {
                        break;
                    }
                    if (((DateTime.Now - startTime).Milliseconds) > 5 * 1000)
                    {
                        break;
                    }
                }
                */
                return true;
            }

            catch (Exception e)
            {
                LogHelper.Log(e);
                return false;
            }
        }

        public int[] getLockStatusBytes(int cabinetId)
        {

            int[] returnBytes = new int[9];
            byte[] bytes = new byte[4];
            int count = 0;
            try
            {

                bytes[0] = (byte)(0xA0 + cabinetId);
                bytes[1] = 0x03;
                bytes[2] = 0xAA;
                bytes[3] = (byte)(((bytes[0] + bytes[1] + bytes[2]) ^ 0xFF) % 0x100);
                LogHelper.Log("getLockStatus:" + bytes[0] + "," + bytes[1] + "," + bytes[2] + "," + bytes[3]);
                serialPort.Write(bytes, 0, 4);

                //int flag = 0;

                while (true)
                {
                    int readtemp = serialPort.ReadByte();
                    returnBytes[count++] = readtemp;
                    if (count == 9)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.Log(e);
                LogHelper.Log("LockControl:getStatusBytes:count:" + count + ",data:" + returnBytes[0] + "," + returnBytes[1] + "," + returnBytes[2] + "," + returnBytes[3] + "," + returnBytes[4] + "," + returnBytes[5] + "," + returnBytes[6] + "," + returnBytes[7] + "," + returnBytes[8]);
                returnBytes = new int[9];
                returnBytes[0] = bytes[0];
                returnBytes[1] = 0x08;
                returnBytes[2] = 0xFF;
                returnBytes[3] = 0xFF;
                returnBytes[4] = 0xFF;
                returnBytes[5] = 0x00;
                returnBytes[6] = 0x00;
                returnBytes[7] = 0x00;
                returnBytes[8] = (((bytes[0] + 0x305) ^ 0xFF) % 0x100);
            }

            return returnBytes;
        }

        public long parseStatusInt(int[] bytes)
        {
            return (bytes[4] * 0x100 + bytes[3]) * 0x100 + bytes[2];
        }

        public Boolean checkStatus(long statusInt, int doorId)
        {
            return (statusInt & (1 << doorId)) == 0;
        }

        public String getLockStatus(int cabinetId)
        {
            int[] returnBytes = new int[9];

            byte[] bytes = new byte[4];
            bytes[0] = (byte)(0xA0 + cabinetId);
            bytes[1] = 0x03;
            bytes[2] = 0xAA;
            bytes[3] = (byte)(((bytes[0] + bytes[1] + bytes[2]) ^ 0xFF) % 0x100);
            try
            {
                LogHelper.Log("getLockStatus:" + bytes[0] + "," + bytes[1] + "," + bytes[2] + "," + bytes[3]);
                serialPort.Write(bytes, 0, 4);

                //int flag = 0;
                int count = 0;
                while (true)
                {
               
                    int readtemp = serialPort.ReadByte();
                    returnBytes[count++] = readtemp;
                    if (count == 9)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.Log(e);
                returnBytes = new int[9];
                returnBytes[0] = bytes[0];
                returnBytes[1] = 0x08;
                returnBytes[2] = 0xFF;
                returnBytes[3] = 0xFF;
                returnBytes[4] = 0xFF;
                returnBytes[5] = 0x00;
                returnBytes[6] = 0x00;
                returnBytes[7] = 0x00;
                returnBytes[8] = (((bytes[0] + 0x305) ^ 0xFF) % 0x100);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("A");
            sb.Append(Convert.ToString((cabinetId), 16).ToUpper());
            sb.Append(":");
            for (int i = 2; i < 5; i++)
            {
                string binaryStr = Convert.ToString(returnBytes[i], 2);
                Array binaryArray = binaryStr.ToArray();
                int size = binaryArray.Length;
                int count = size;
                for (int j = 0; j < 8; j++)
                {
                    if (count > 0)
                    {
                        count--;
                        sb.Append(binaryArray.GetValue(count));
                    }
                    else
                    {
                        sb.Append(0);
                    }
                    if (j < 7 || i < 4)
                    {
                        sb.Append(",");
                    }
                }
            }
            return sb.ToString();

        }
    }
}
