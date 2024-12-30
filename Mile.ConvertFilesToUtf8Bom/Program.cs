using System.Text;

namespace Mile.ConvertFilesToUtf8Bom
{
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

        static void Main(string[] args)
        {
            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Aria2\Mile.Aria2.Library");

            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\NanaZip.Codecs");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\NanaZip.Core");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Windows.Internal\Mile.Internal\Mile.Internal.Implementation");

            //ConvertFilesToUtf8Bom(@"D:\Projects\halalcloud\halalcloud-client\HalalCloud.BaiduBce");

            //ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Dokany\Mile.Dokany");

            ConvertFilesToUtf8Bom(@"D:\Projects\ProjectMile\Mile.Uefi\Specification");

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
