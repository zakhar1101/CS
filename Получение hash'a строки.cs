using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace gethash
{
    public class Class1
    {
        public static string GetHashSHA512(string pass)
        {
            byte[] tmpsource = Encoding.ASCII.GetBytes(pass); // получаем байты из строки
            SHA512 md5 = new SHA512CryptoServiceProvider();
            byte[] tmphash = md5.ComputeHash(tmpsource); // получаем массив байт
            return ByteArrayToString(tmphash); // конвертируем байты в hex
        }

        public static string GetHashMD5(string pass)
        {
            byte[] tmpsource = Encoding.ASCII.GetBytes(pass);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] tmphash = md5.ComputeHash(tmpsource);
            return ByteArrayToString(tmphash);

        }

        public static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }


    }
}
