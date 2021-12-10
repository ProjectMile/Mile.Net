using Mile.Net;
using System;
using System.IO;
using System.Text;

namespace Mile.NanaZipProjectXmlGenerator
{
    public class Program
    {
        static void GenerateSharedSevenZipZStandardProject()
        {
            string rootPath =
                @"D:\Projects\MouriNaruto\NanaZip\SevenZip\C";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\",
                rootPath + @"\",
                rootPath,
                @"../NanaZip.Shared.SevenZipZStandard.Files");
        }

        static string GenerateArchiveTypesManifestDefinitions()
        {
            string[] ArchiveTypes = new string[]
            {
                "001",
                "7z",
                "arj",
                "bz2",
                "bzip2",
                "cab",
                "cpio",
                "deb",
                "dmg",
                "esd",
                "fat",
                "gz",
                "gzip",
                "hfs",
                "iso",
                "lha",
                "liz",
                "lz",
                "lz4",
                "lz5",
                "lzh",
                "lzma",
                "ntfs",
                "rar",
                "rpm",
                "squashfs",
                "swm",
                "tar",
                "taz",
                "tbz",
                "tbz2",
                "tgz",
                "tlz",
                "tpz",
                "txz",
                "vhd",
                "wim",
                "xar",
                "xz",
                "z",
                "zip",
                "zst"
            };

            string Result = "";

            foreach (var ArchiveType in ArchiveTypes)
            {
                Result += string.Format(
                    "        <uap:Extension Category=\"windows.fileTypeAssociation\">\r\n" +
                    "          <uap:FileTypeAssociation Name=\"archivetype_{0}\">\r\n" +
                    "            <uap:Logo>Assets\\ArchiveFile.png</uap:Logo>\r\n" +
                    "            <uap:DisplayName>NanaZip - {0} Archive</uap:DisplayName>\r\n" +
                    "            <uap:SupportedFileTypes>\r\n" +
                    "              <uap:FileType>.{0}</uap:FileType>\r\n" +
                    "            </uap:SupportedFileTypes>\r\n" +
                    "          </uap:FileTypeAssociation>\r\n" +
                    "        </uap:Extension>\r\n",
                    ArchiveType);
            }

            return Result;
        }

        static void SwitchToPreview()
        {
            string NanaZipSourceRoot = @"D:\Projects\MouriNaruto\NanaZip";

            {
                string Path = string.Format(
                    @"{0}\NanaZipPackage\Package.appxmanifest",
                    NanaZipSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "DisplayName=\"NanaZip\"",
                    "DisplayName=\"NanaZip Preview\"");
                Content =  Content.Replace(
                    "Name=\"40174MouriNaruto.NanaZip\"",
                    "Name=\"40174MouriNaruto.NanaZipPreview\"");
                Content =  Content.Replace(
                    "<DisplayName>NanaZip</DisplayName>",
                    "<DisplayName>NanaZip Preview</DisplayName>");
                Content =  Content.Replace(
                    "CAE3F1D4-7765-4D98-A060-52CD14D56EAB",
                    "469D94E9-6AF4-4395-B396-99B1308F8CE5");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }

            {
                string Path = string.Format(
                    @"{0}\NanaZipShellExtension\NanaZipShellExtension.cpp",
                    NanaZipSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "return ::SHStrDupW(L\"NanaZip\", ppszName);",
                    "return ::SHStrDupW(L\"NanaZip Preview\", ppszName);");
                Content =  Content.Replace(
                    "CAE3F1D4-7765-4D98-A060-52CD14D56EAB",
                    "469D94E9-6AF4-4395-B396-99B1308F8CE5");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }
        }

        static void SwitchToRelease()
        {
            string NanaZipSourceRoot = @"D:\Projects\MouriNaruto\NanaZip";

            {
                string Path = string.Format(
                    @"{0}\NanaZipPackage\Package.appxmanifest",
                    NanaZipSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "DisplayName=\"NanaZip Preview\"",
                    "DisplayName=\"NanaZip\"");
                Content = Content.Replace(
                    "Name=\"40174MouriNaruto.NanaZipPreview\"",
                    "Name=\"40174MouriNaruto.NanaZip\"");
                Content =  Content.Replace(
                    "<DisplayName>NanaZip Preview</DisplayName>",
                    "<DisplayName>NanaZip</DisplayName>");
                Content =  Content.Replace(
                    "469D94E9-6AF4-4395-B396-99B1308F8CE5",
                    "CAE3F1D4-7765-4D98-A060-52CD14D56EAB");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }

            {
                string Path = string.Format(
                    @"{0}\NanaZipShellExtension\NanaZipShellExtension.cpp",
                    NanaZipSourceRoot);
                string Content = File.ReadAllText(
                    Path,
                    Encoding.UTF8);
                Content = Content.Replace(
                    "return ::SHStrDupW(L\"NanaZip Preview\", ppszName);",
                    "return ::SHStrDupW(L\"NanaZip\", ppszName);");
                Content =  Content.Replace(
                    "469D94E9-6AF4-4395-B396-99B1308F8CE5",
                    "CAE3F1D4-7765-4D98-A060-52CD14D56EAB");
                File.WriteAllText(
                    Path,
                    Content,
                    Encoding.UTF8);
            }
        }

        public static void Main(string[] args)
        {
            //GenerateSharedSevenZipZStandardProject();

            //string Result = GenerateArchiveTypesManifestDefinitions();

            SwitchToPreview();
            //SwitchToRelease();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
