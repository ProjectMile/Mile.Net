using System.Text;

namespace Mile.NanaBoxProjectXmlGenerator
{
    internal class Program
    {
        static void SwitchToPreview()
        {
            string NanaBoxSourceRoot = @"D:\Projects\MouriNaruto\NanaBox";

            {
                string Path = string.Format(
                    @"{0}\NanaBoxPackage\Package.appxmanifest",
                    NanaBoxSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "DisplayName=\"NanaBox\"",
                    "DisplayName=\"NanaBox Preview\"");
                Content = Content.Replace(
                    "Name=\"40174MouriNaruto.NanaBox\"",
                    "Name=\"40174MouriNaruto.NanaBoxPreview\"");
                Content = Content.Replace(
                    "<DisplayName>NanaBox</DisplayName>",
                    "<DisplayName>NanaBox Preview</DisplayName>");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }
        }

        static void SwitchToRelease()
        {
            string NanaBoxSourceRoot = @"D:\Projects\MouriNaruto\NanaBox";

            {
                string Path = string.Format(
                    @"{0}\NanaBoxPackage\Package.appxmanifest",
                    NanaBoxSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "DisplayName=\"NanaBox Preview\"",
                    "DisplayName=\"NanaBox\"");
                Content = Content.Replace(
                    "Name=\"40174MouriNaruto.NanaBoxPreview\"",
                    "Name=\"40174MouriNaruto.NanaBox\"");
                Content = Content.Replace(
                    "<DisplayName>NanaBox Preview</DisplayName>",
                    "<DisplayName>NanaBox</DisplayName>");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }
        }

        static string GeneratePackageManifestResourceIdentities()
        {
            string Result = "";

            DirectoryInfo folder = new DirectoryInfo(
                @"D:\Projects\MouriNaruto\NanaBox\NanaBox\Strings");

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
            SwitchToPreview();
            //SwitchToRelease();

            //string Result = GeneratePackageManifestResourceIdentities();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
