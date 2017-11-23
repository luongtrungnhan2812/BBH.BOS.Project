using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Shared
{
    public class Utility
    {
        public static void WriteLog(string path, string message)
        {

            if (!File.Exists(path))
            {
                using (StreamWriter w = File.CreateText(path))
                {
                    Log(message, w);
                }
            }
            else
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    Log(message, w);
                }
            }
        }
        private static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\n" + DateTime.Now.ToString());
            w.WriteLine(" {0}", logMessage);
            w.WriteLine("-----------------------------------");
        }

        public static string EncodeString(string value)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(value);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
        public static string MaHoaMD5(string pass)
        {
            try
            {

                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] data = Encoding.UTF8.GetBytes(pass);
                data = md5.ComputeHash(data);
                StringBuilder buider = new StringBuilder();
                foreach (byte b in data)
                {
                    buider.Append(b.ToString("x2"));
                }
                return buider.ToString();
            }
            catch
            {
                return pass;
            }
        }
        public static string GenCode()
        {
            Random objRandom = new Random();
            string combination = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder captchaCode = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                captchaCode.Append(combination[objRandom.Next(combination.Length)]);
            }
            return captchaCode.ToString();
        }
        public static string GenQRCode(string strCode)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(5);
            return qrCodeImageAsBase64;
        }
    }
}
