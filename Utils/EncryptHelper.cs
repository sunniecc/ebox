using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;

namespace EBoxClient.Utils
{
    public class EncryptHelper
    {
        AsymmetricKeyParameter privateKey;
        AsymmetricKeyParameter publicKey;
        Org.BouncyCastle.Crypto.Engines.RsaEngine eng = new Org.BouncyCastle.Crypto.Engines.RsaEngine();
        Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding enc;

        public EncryptHelper()
        {
            enc = new Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding(eng);
            try
            {
                publicKey = PublicKeyFactory.CreateKey(Convert.FromBase64String(Setting.Instance.PublicKey));
                privateKey = PrivateKeyFactory.CreateKey(Convert.FromBase64String(Setting.Instance.PrivateKey));
            }
            catch (Exception ex)
            {
                LogHelper.Log("加载密钥失败", ex);
            }
            var c = Encoding.UTF8.GetBytes("阳历fasefasfasefasv");
            //var a = "RPWC2H7CDtHxSfUAtQMRBj66fS0+/dNtyqhph9hvilWgXdCgRVrQgzkAquH3Brw59a9qDW30Bpq9wjLtk1NclnhxSDh7/pXE0e/1eOVm/zUM0eWD4DHVI5q6AsJkf7APUCmV+T2VCimsaEogh9LOX1wZ097oPSOHYIRH5C/M7pCceiQws0MOucc1FTOy8HrXF0jvozi4KZXkpEyQXJkXJSchrLyebhAlJPgvfd0eybT4CWIBNSkNbYrgnG6D0CRJ9oqG5rEqDjengdfiOkGVOfrzKg2Uxsi5G+VggWy6BIs2IWVg4tEe9huBsBtZoomZa0cK192ADd0dGipvE6BndQ==";

            var en = RSAProcess(c, true, true);
            var b = RSAProcess(en, false, false);

            var str = Convert.ToBase64String(en);
            var de = RSAProcess(en, false, false);
            str = Encoding.UTF8.GetString(de, 0, de.Length);
        }

        public string encrypt(String str)
        {
            var c = Encoding.UTF8.GetBytes(str);
            var en = RSAProcess(c, true, true);
            return Convert.ToBase64String(en);
        }

        public string decrypt(string str)
        {
            var b = RSAProcess(Encoding.UTF8.GetBytes(str), false, false);
            return Convert.ToBase64String(b);
        }
        /// <summary>
        /// 报文加密解密入口
        /// </summary>
        /// <param name="data">处理报文</param>
        /// <param name="encrypt">true 加密处理  false 解密处理</param>
        /// <param name="usePublicKey">true 使用公钥处理 false使用私钥处理</param>
        /// <returns></returns>
        private byte[] RSAProcess(byte[] data, bool encrypt, bool usePublicKey)
        {
            try
            {
                enc.Init(encrypt, usePublicKey ? publicKey : privateKey);
                return enc.ProcessBlock(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                LogHelper.Log("RSA" + (usePublicKey ? "公钥" : "私钥") + (encrypt ? "加密" : "解密") + "失败", ex);
                return null;
            }
        }
    }
}
