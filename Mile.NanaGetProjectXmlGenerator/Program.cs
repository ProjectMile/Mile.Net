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

        static void Main(string[] args)
        {
            SwitchToPreview();
            //SwitchToRelease();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
