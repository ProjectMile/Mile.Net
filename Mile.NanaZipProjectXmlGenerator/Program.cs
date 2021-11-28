using Mile.Net;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static void Main(string[] args)
        {
            //GenerateSharedSevenZipZStandardProject();

            string Result = GenerateArchiveTypesManifestDefinitions();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
