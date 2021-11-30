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

        static void SwitchToCanary()
        {
            string ManifestPath =
                @"D:\Projects\MouriNaruto\NanaZip\NanaZipPackage\Package.appxmanifest";

            string ManifestContent = File.ReadAllText(
                ManifestPath,
                Encoding.UTF8);
            ManifestContent = ManifestContent.Replace(
                "DisplayName=\"NanaZip\"",
                "DisplayName=\"NanaZip (Canary)\"");
            ManifestContent =  ManifestContent.Replace(
                "Name=\"40174MouriNaruto.NanaZip\"",
                "Name=\"40174MouriNaruto.NanaZip.Canary\"");
            File.WriteAllText(
                ManifestPath,
                ManifestContent,
                Encoding.UTF8);
        }

        static void SwitchToRelease()
        {
            string ManifestPath =
                @"D:\Projects\MouriNaruto\NanaZip\NanaZipPackage\Package.appxmanifest";

            string ManifestContent = File.ReadAllText(
                ManifestPath,
                Encoding.UTF8);
            ManifestContent = ManifestContent.Replace(
                "DisplayName=\"NanaZip (Canary)\"",
                "DisplayName=\"NanaZip\"");
            ManifestContent = ManifestContent.Replace(
                "Name=\"40174MouriNaruto.NanaZip.Canary\"",
                "Name=\"40174MouriNaruto.NanaZip\"");
            File.WriteAllText(
                ManifestPath,
                ManifestContent,
                Encoding.UTF8);
        }

        public static void Main(string[] args)
        {
            //GenerateSharedSevenZipZStandardProject();

            //string Result = GenerateArchiveTypesManifestDefinitions();

            SwitchToCanary();
            //SwitchToRelease();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
