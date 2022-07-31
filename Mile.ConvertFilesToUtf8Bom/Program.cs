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
                    (item.Extension != ".rc" &&
                    item.Extension != ".sh" &&
                    item.Extension != ".asm"))
                {
                    try
                    {
                        File.WriteAllText(
                            item.FullName,
                            File.ReadAllText(item.FullName, Encoding.UTF8),
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
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\SevenZip");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\BLAKE3");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\Brotli");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\Lizard");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\LZ4");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\LZ5");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\RHash");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\xxHash");
            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\ThirdParty\Zstandard");

            ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaRun\ThirdParty\Detours");

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
