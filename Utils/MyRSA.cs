using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace EBoxClient.Utils
{
    class MyRSA
    {
        private static string publicKey = "<RSAKeyValue><Modulus>gcVqR+IPprhT2cRCSKy776AnxFUmYLiCt1CoxGjY9H+KeaNTnrbcVF/iSiAOfDyAytEh207lL7YbWTkDS7TSRQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";



        private static string privateKey = "<RSAKeyValue><Modulus>gcVqR+IPprhT2cRCSKy776AnxFUmYLiCt1CoxGjY9H+KeaNTnrbcVF/iSiAOfDyAytEh207lL7YbWTkDS7TSRQ==</Modulus><Exponent>AQAB</Exponent><P>6G5Y92RylV70+FPEmyujT2xgHWV5ronjsqjagxLAcO8=</P><Q>ju4ha6GjRApzi6+2tqdGaef9bY8ZOxATR9eT8rOfiAs=</Q><DP>oA5tAV+QcEAFnYPB3cD9ItJUlamtU33s6LjSUHR3RM0=</DP><DQ>WjsQ1B7VsBWc/hkukr6lICS5g5msBvJOCbOZjcVBuCM=</DQ><InverseQ>GdlU6bqLrBgXjMW71gHGuVJmCqKv0cJyyICBXzUdwlk=</InverseQ><D>ZVYs9W8xe6aLTA13GVtR8wCkrSs1KehLoyzobV/Ws63T7TxwDTAGoEeFJjM0ZCERQ41l9E4tWzWCR+h8dPbaLQ==</D></RSAKeyValue>";


        //     private static string publicKey  =  "<RSAKeyValue><Modulus>6CdsXgYOyya/yQHTO96dB3gEurM2UQDDVGrZoe6RcAVTxAqDDf5LwPycZwtNOx3Cfy44/D5Mj86koPew5soFIz9sxPAHRF5hcqJoG+q+UfUYTHYCsMH2cnqGVtnQiE/PMRMmY0RwEfMIo+TDpq3QyO03MaEsDGf13sPw9YRXiac=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        //      private static string privateKey = "<RSAKeyValue><Modulus>6CdsXgYOyya/yQHTO96dB3gEurM2UQDDVGrZoe6RcAVTxAqDDf5LwPycZwtNOx3Cfy44/D5Mj86koPew5soFIz9sxPAHRF5hcqJoG+q+UfUYTHYCsMH2cnqGVtnQiE/PMRMmY0RwEfMIo+TDpq3QyO03MaEsDGf13sPw9YRXiac=</Modulus><Exponent>AQAB</Exponent><P>/aoce2r6tonjzt1IQI6FM4ysR40j/gKvt4dL411pUop1Zg61KvCm990M4uN6K8R/DUvAQdrRdVgzvvAxXD7ESw==</P><Q>6kqclrEunX/fmOleVTxG4oEpXY4IJumXkLpylNR3vhlXf6ZF9obEpGlq0N7sX2HBxa7T2a0WznOAb0si8FuelQ==</Q><DP>3XEvxB40GD5v/Rr4BENmzQW1MBFqpki6FUGrYiUd2My+iAW26nGDkUYMBdYHxUWYlIbYo6Tezc3d/oW40YqJ2Q==</DP><DQ>LK0XmQCmY/ArYgw2Kci5t51rluRrl4f5l+aFzO2K+9v3PGcndjAStUtIzBWGO1X3zktdKGgCLlIGDrLkMbM21Q==</DQ><InverseQ>GqC4Wwsk2fdvJ9dmgYlej8mTDBWg0Wm6aqb5kjncWK6WUa6CfD+XxfewIIq26+4Etm2A8IAtRdwPl4aPjSfWdA==</InverseQ><D>a1qfsDMY8DSxB2DCr7LX5rZHaZaqDXdO3GC01z8dHjI4dDVwOS5ZFZs7MCN3yViPsoRLccnVWcLzOkSQF4lgKfTq3IH40H5N4gg41as9GbD0g9FC3n5IT4VlVxn9ZdW+WQryoHdbiIAiNpFKxL/DIEERur4sE1Jt9VdZsH24CJE=</D></RSAKeyValue>";

        static public string Decrypt(string base64code)
        {
            try
            {

                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                RSA.FromXmlString(privateKey);



                byte[] encryptedData;

                byte[] decryptedData;

                encryptedData = Convert.FromBase64String(base64code);

                //  encryptedData = System.Text.Encoding.Default.GetBytes(base64code);

                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                //Display the decrypted plaintext to the console. 
                return Encoding.GetEncoding("UTF-8").GetString(decryptedData);

            }
            catch (Exception exc)
            {
                //Exceptions.LogException(exc);
                LogHelper.Log(exc.Message);
                return "";
            }
        }



        static public string Encrypt(string toEncryptString)
        {
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                //Create byte arrays to hold original, encrypted, and decrypted data.

                byte[] dataToEncrypt = ByteConverter.GetBytes(toEncryptString);
                dataToEncrypt = Encoding.UTF8.GetBytes(toEncryptString);
                byte[] encryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                RSA.FromXmlString(publicKey);



                //Pass the data to ENCRYPT, the public key information 
                //(using RSACryptoServiceProvider.ExportParameters(false),
                //and a boolean flag specifying no OAEP padding.

                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                string base64code = Convert.ToBase64String(encryptedData);
                return base64code;

            }
            catch (Exception exc)
            {
                LogHelper.Log(exc.Message);
                return "";
            }
        }



        static private byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.
                int i = DataToEncrypt.Length;
                int c = i / 53;
                int y = i % 53;
                c = y == 0 ? c : c + 1;
                int x = 0;
                i = 0;
                byte[] by = null;
                List<byte[]> dinosaurs = new List<byte[]>(c);
                for (int j = 0; j < c; j++)
                {
                    if (j != c - 1)
                    {
                        by = new byte[53];
                        Array.Copy(DataToEncrypt, x, by, 0, 53);
                        x = x + 53;
                    }
                    else
                    {
                        by = new byte[y];
                        Array.Copy(DataToEncrypt, x, by, 0, y);
                    }
                    by = RSA.Encrypt(by, DoOAEPPadding);
                    i = i + by.Length;
                    dinosaurs.Add(by);
                }
                by = new byte[i];
                i = 0;
                foreach (byte[] b in dinosaurs)
                {

                    Array.Copy(b, 0, by, i, b.Length);
                    i = i + b.Length;
                }
                return by;

            }
            catch (CryptographicException e)
            {
                LogHelper.Log("加密时发生异常 "+e.Message);
                return null;
            }
        }



        static private byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);


                int i = DataToDecrypt.Length;
                int l = i / 64;
                byte[] by = null;
                List<byte[]> dinosaurs = new List<byte[]>(l);
                i = 0;
                for (int j = 0; j < l; j++)
                {
                    by = new byte[64];
                    Array.Copy(DataToDecrypt, j * 64, by, 0, 64);
                    by = RSA.Decrypt(by, DoOAEPPadding);
                    dinosaurs.Add(by);
                    i = i + by.Length;
                }

                by = new byte[i];
                i = 0;
                foreach (byte[] b in dinosaurs)
                {
                    Array.Copy(b, 0, by, i, b.Length);
                    i = i + b.Length;
                }
                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return by;
            }
            catch (CryptographicException e)
            {
                LogHelper.Log("解密时发生异常 "+e.Message);
                return null;

            }

        }
        /*
        static void Main(string[] args)
        {

            String str = "和我方公司之间的交互采用RSA加解密";
            // String str1 = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes ( str ));
            // Console.WriteLine(str1);
            string encodeString = MyRSA.Encrypt(str);
            Console.WriteLine(encodeString);

            encodeString = "Y81hWwKskPEaMM+03HDhunC/XOzUneu8CfXlre7ExaXZ4m+iBfx452C2s8oVO7mpovNxTGFHzkG9c3VLGTHTEA==";
            string decode = MyRSA.Decrypt(encodeString);
            Console.WriteLine(decode);

            Console.ReadLine();
        }*/
    }
}
