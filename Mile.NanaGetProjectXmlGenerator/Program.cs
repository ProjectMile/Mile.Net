using System.IO;
using System.Text;

namespace Mile.NanaGetProjectXmlGenerator
{
    internal class Program
    {
        static string GeneratePackageManifestResourceIdentities()
        {
            string Result = "";

            DirectoryInfo folder = new DirectoryInfo(
                @"D:\Projects\MouriNaruto\NanaGet\NanaGetPackage\Strings");

            foreach (var item in folder.GetDirectories())
            {
                Result += string.Format(
                    "    <Resource Language=\"{0}\" />\r\n",
                    item.Name);
            }

            int[] Scales = new int[]
            {
                100, 125, 150, 200, 400
            };

            foreach (var scale in Scales)
            {
                Result += string.Format(
                    "    <Resource uap:Scale=\"{0}\" />\r\n",
                    scale.ToString());
            }

            return Result;
        }

        static void Main(string[] args)
        {
            //string Result = GeneratePackageManifestResourceIdentities();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
