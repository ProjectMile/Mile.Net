using System.Security.Cryptography;
using System.Text;

namespace Mile.ConvertFilesToUtf8Bom
{
    public static class AesHelper
    {
        private const string DefaultKey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASC";

        public static string EncryptData(string aesData)
        {
            string key = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASC";
            return EncryptData(aesData, key);
        }

        public static string EncryptData(string aesData, string key)
        {
            if (string.IsNullOrEmpty(aesData))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(key))
            {
                key = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASC";
            }
            return Convert.ToBase64String(Encrypt(new UTF8Encoding().GetBytes(aesData), key));
        }

        public static string DecryptData(string encryptedData)
        {
            string key = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASC";
            return DecryptData(encryptedData, key);
        }

        public static string DecryptData(string encryptedData, string key)
        {
            if (string.IsNullOrEmpty(encryptedData))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(key))
            {
                key = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASC";
            }
            try
            {
                string[] array = encryptedData.Split('\n');
                List<byte> list = new List<byte>();
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    byte[] collection = DecryptToBytes(array2[i], key);
                    list.AddRange(collection);
                }
                return Encoding.UTF8.GetString(list.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static byte[] DecryptToBytes(string data, string key)
        {
            return Decrypt(Convert.FromBase64String(data), key);
        }

        private static byte[] Encrypt(byte[] decodeBytes, string key)
        {
            using Aes aes = Aes.Create();
            aes.Key = CheckKey(key);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            byte[] array = Array.Empty<byte>();
            aes.GenerateIV();
            array = aes.IV;
            using ICryptoTransform cryptoTransform = aes.CreateEncryptor();
            byte[] second = cryptoTransform.TransformFinalBlock(decodeBytes, 0, decodeBytes.Length);
            aes.Clear();
            return array.Concat(second).ToArray();
        }

        private static byte[] Decrypt(byte[] encodeBytes, string key)
        {
            using Aes aes = Aes.Create();
            aes.Key = CheckKey(key);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            byte[] array = new byte[16];
            byte[] array2 = new byte[encodeBytes.Length - 16];
            Array.Copy(encodeBytes, 0, array, 0, 16);
            aes.IV = array;
            Array.Copy(encodeBytes, 16, array2, 0, array2.Length);
            encodeBytes = array2;
            using ICryptoTransform cryptoTransform = aes.CreateDecryptor();
            byte[] result = cryptoTransform.TransformFinalBlock(encodeBytes, 0, encodeBytes.Length);
            aes.Clear();
            return result;
        }

        private static byte[] CheckKey(string key)
        {
            byte[] array = new byte[32];
            byte[] array2;
            try
            {
                array2 = Convert.FromBase64String(key);
            }
            catch (FormatException)
            {
                array2 = new UTF8Encoding().GetBytes(key);
            }
            if (array2.Length < 32)
            {
                Array.Copy(array2, 0, array, 0, array2.Length);
            }
            else if (array2.Length > 32)
            {
                Array.Copy(array2, 0, array, 0, 32);
            }
            else
            {
                array = array2;
            }
            return array;
        }
    }

    internal class Program
    {
        static void ConvertFilesToUtf8Bom(
            string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (var item in folder.GetDirectories())
            {
                if (item.Name == "Lang")
                {
                    continue;
                }

                ConvertFilesToUtf8Bom(item.FullName);
            }

            foreach (var item in folder.GetFiles())
            {
                if (item.Extension == ".c" ||
                    item.Extension == ".c++" ||
                    item.Extension == ".cc" ||
                    item.Extension == ".cpp" ||
                    item.Extension == ".cxx" ||
                    item.Extension == ".h" ||
                    item.Extension == ".h++" ||
                    item.Extension == ".hh" ||
                    item.Extension == ".hpp" ||
                    item.Extension == ".hxx" ||
                    item.Extension == ".idl" ||
                    item.Extension == ".inl" ||
                    item.Extension == ".ipp" ||
                    item.Extension == ".i" ||
                    item.Extension == ".tlh" ||
                    item.Extension == ".tli" ||
                    item.Extension == ".xaml" ||
                    item.Extension == ".resw" ||
                    item.Extension == ".manifest" ||
                    item.Extension == ".props" ||
                    item.Extension == ".targets" ||                      
                    item.Extension == ".md")
                {
                    try
                    {
                        File.WriteAllText(
                            item.FullName,
                            File.ReadAllText(
                                item.FullName,
                                Encoding.UTF8).ReplaceLineEndings("\r\n"),
                            Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            "{0}: {1}",
                            item.FullName,
                            ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        static void ConvertFilesToUtf8(
           string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);

            foreach (var item in folder.GetDirectories())
            {
                if (item.Name == "Lang")
                {
                    continue;
                }

                ConvertFilesToUtf8(item.FullName);
            }

            foreach (var item in folder.GetFiles())
            {
                if (item.Extension == ".c" ||
                    item.Extension == ".c++" ||
                    item.Extension == ".cc" ||
                    item.Extension == ".cpp" ||
                    item.Extension == ".cxx" ||
                    item.Extension == ".h" ||
                    item.Extension == ".h++" ||
                    item.Extension == ".hh" ||
                    item.Extension == ".hpp" ||
                    item.Extension == ".hxx" ||
                    item.Extension == ".idl" ||
                    item.Extension == ".inl" ||
                    item.Extension == ".ipp" ||
                    item.Extension == ".i" ||
                    item.Extension == ".tlh" ||
                    item.Extension == ".tli" ||
                    item.Extension == ".xaml" ||
                    item.Extension == ".resw" ||
                    item.Extension == ".manifest" ||
                    item.Extension == ".props" ||
                    item.Extension == ".targets" ||
                    item.Extension == ".md")
                {
                    try
                    {
                        File.WriteAllText(
                            item.FullName,
                            File.ReadAllText(
                                item.FullName,
                                Encoding.UTF8).ReplaceLineEndings("\r\n"),
                            new UTF8Encoding(false));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            "{0}: {1}",
                            item.FullName,
                            ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        static void Main(string[] args)
        {
            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Aria2\Mile.Aria2.Library");

            ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\NanaZip.Codecs");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\NanaZip.Core");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\NanaZip.Universal");
            //ConvertFilesToUtf8(@"D:\Projects\MouriNaruto\SevenZipMainline");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Windows.Internal\Mile.Internal\Mile.Internal.Implementation");

            //ConvertFilesToUtf8Bom(@"D:\Projects\halalcloud\halalcloud-client\HalalCloud.BaiduBce");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Dokany\Mile.Dokany");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Detours\Mile.Detours");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Uefi\Specification");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Json\Mile.Json\Mile.Json.Implementation");

            //ConvertFilesToUtf8Bom(@"D:\Projects\qietv\QieLivePlugin\QieLivePlugin\OBS\Include");

            //string RawContent = File.ReadAllText(
            //    @"C:\ProgramData\Windows Master Store\MSPCManagerCT.dat");

            //string Content = AesHelper.DecryptData(RawContent);

            //File.WriteAllText(
            //    @"D:\MSPCManagerCT.json",
            //    Content,
            //    Encoding.UTF8);

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
