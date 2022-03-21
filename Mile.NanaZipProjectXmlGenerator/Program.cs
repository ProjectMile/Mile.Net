using Mile.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

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
                "vhdx",
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
                    "              <uap:FileType>.{0}</uap:FileType>\r\n",
                    ArchiveType);
            }

            return string.Format(
                "        <uap:Extension Category=\"windows.fileTypeAssociation\">\r\n" +
                "          <uap:FileTypeAssociation Name=\"fileassociations\">\r\n" +
                "            <uap:Logo>Assets\\ArchiveFile.png</uap:Logo>\r\n" +
                "            <uap:SupportedFileTypes>\r\n" +
                "{0}" +
                "            </uap:SupportedFileTypes>\r\n" +
                "            <uap2:SupportedVerbs>\r\n" +
                "              <uap3:Verb Id=\"open\" Parameters=\"&quot;%1&quot;\">open</uap3:Verb>\r\n" +
                "            </uap2:SupportedVerbs>\r\n" +
                "          </uap:FileTypeAssociation>\r\n" +
                "        </uap:Extension>\r\n",
                Result);
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
                    File.WriteAllText(
                        item.FullName,
                        File.ReadAllText(item.FullName, Encoding.UTF8),
                        Encoding.UTF8);
                }
                else
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        public static void ConvertSevenZipLanguageFilesToModernResources()
        {
            string ReswTemplatePath = @"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\ItemTemplates\WapProj\1033\Resw\Resources.resw";
            string NanaZipSourceRoot = @"D:\Projects\MouriNaruto\NanaZip\";
            string SevenZipLangRoot = $@"{NanaZipSourceRoot}\SevenZip\Lang\";
            string NanaZipReswRoot = $@"{NanaZipSourceRoot}\NanaZipPackage\Strings\";

            SortedSet<string> unspportedLang = new()
            {
                "an",
                "ast",
                "ba",
                "br",
                "co",
                "ext",
                "fur",
                "io",
                "kaa",
                "kab",
                "ku",
                "lij",
                "mng2",
                "sa"
            };

            Dictionary<string, string> langMapping = new()
            {
                { "az", "az-arab" },
                { "ku-ckb", "ku-arab" },
                { "ky", "ky-kg" },
                { "mn", "mn-cyrl" },
                { "mng", "mn-mong" },
                { "sr-spc", "sr-cyrl" },
                { "sr-spl", "sr-Latn" },
                { "tg", "tg-arab" },
                { "tk", "tk-cyrl" },
                { "tt", "tt-arab" },
                { "ug", "ug-arab" },
                { "uz", "uz-latn" },
                { "va", "ca-es-valencia" },
                { "yo", "yo-latn" },
                { "zh-cn", "zh-Hans" },
                { "zh-tw", "zh-Hant" },
            };

            foreach (var txtFile in Directory.GetFiles(SevenZipLangRoot))
            {
                string langName = Path.GetFileNameWithoutExtension(txtFile);
                if (unspportedLang.Contains(langName)) { continue; }
                if (langMapping.ContainsKey(langName))
                {
                    langMapping.TryGetValue(langName, out langName);
                }

                XmlDocument resw = new();
                resw.Load(ReswTemplatePath);
                int resourceID = new();

                foreach (string line in File.ReadLines(txtFile))
                {
                    if (line.StartsWith(';')) { continue; }
                    if (int.TryParse(line, out var val))
                    {
                        resourceID = val;
                    }
                    else if (line.Length > 0)
                    {
                        XmlElement data = resw.CreateElement("data");
                        data.SetAttribute("name", $"Resource{resourceID}");
                        data.SetAttribute("xml:space", "preserve");

                        XmlElement dataValue = resw.CreateElement("value");
                        dataValue.InnerText = line;

                        data.AppendChild(dataValue);
                        resw.DocumentElement.AppendChild(data);

                        resourceID++;
                    }
                }
                
                string resourcePath = $@"{NanaZipReswRoot}\{langName}\";
                Directory.CreateDirectory(resourcePath);
                resw.Save($@"{resourcePath}\Legacy.resw");
            }
        }

        public static void Main(string[] args)
        {
            //GenerateSharedSevenZipZStandardProject();

            //string Result = GenerateArchiveTypesManifestDefinitions();

            //SwitchToPreview();
            //SwitchToRelease();

            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\SevenZip");

            ConvertSevenZipLanguageFilesToModernResources();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
