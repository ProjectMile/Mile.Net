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

        static void Main(string[] args)
        {
            SwitchToPreview();
            //SwitchToRelease();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
