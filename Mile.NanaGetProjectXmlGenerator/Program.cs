using System.IO;
using System.Text;

namespace Mile.NanaGetProjectXmlGenerator
{
    internal class Program
    {
        static void SwitchToPreview()
        {
            string NanaGetSourceRoot = @"D:\Projects\MouriNaruto\NanaGet";

            {
                string Path = string.Format(
                    @"{0}\NanaGetPackage\Package.appxmanifest",
                    NanaGetSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "DisplayName=\"NanaGet\"",
                    "DisplayName=\"NanaGet Preview\"");
                Content = Content.Replace(
                    "Name=\"40174MouriNaruto.NanaGet\"",
                    "Name=\"40174MouriNaruto.NanaGetPreview\"");
                Content = Content.Replace(
                    "<DisplayName>NanaGet</DisplayName>",
                    "<DisplayName>NanaGet Preview</DisplayName>");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }
        }

        static void SwitchToRelease()
        {
            string NanaGetSourceRoot = @"D:\Projects\MouriNaruto\NanaGet";

            {
                string Path = string.Format(
                    @"{0}\NanaGetPackage\Package.appxmanifest",
                    NanaGetSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "DisplayName=\"NanaGet Preview\"",
                    "DisplayName=\"NanaGet\"");
                Content = Content.Replace(
                    "Name=\"40174MouriNaruto.NanaGetPreview\"",
                    "Name=\"40174MouriNaruto.NanaGet\"");
                Content = Content.Replace(
                    "<DisplayName>NanaGet Preview</DisplayName>",
                    "<DisplayName>NanaGet</DisplayName>");
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
            //SwitchToPreview();
            //SwitchToRelease();

            string Result = GeneratePackageManifestResourceIdentities();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
