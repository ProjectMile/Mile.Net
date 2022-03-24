using Mile.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace Mile.NanaZipProjectXmlGenerator
{
    public class Program
    {
        [DllImport(@"kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern ushort LocaleNameToLCID(string lpName, uint dwFlags);

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

        static SortedDictionary<int, string> ParseSevenZipLanguageFile(
            string path)
        {
            SortedDictionary<int, string> Result = new();

            int resourceID = 0;

            foreach (string line in File.ReadLines(path))
            {
                if (line.StartsWith(';'))
                {
                    continue;
                }

                if (int.TryParse(line, out var val))
                {
                    resourceID = val;
                }
                else if (line.Length > 0)
                {
                    Result.Add(resourceID, line);
                    ++resourceID;
                }
                else
                {
                    ++resourceID;
                }
            }
            return Result;
        }

        static string ConvertSevenZipLanguageFilesToModernResources()
        {
            string ReswTemplatePath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\ItemTemplates\WapProj\1033\Resw\Resources.resw";
            string NanaZipSourceRoot = @"D:\Projects\MouriNaruto\NanaZip\";
            string SevenZipLangRoot = $@"{NanaZipSourceRoot}\SevenZip\Lang\";
            string NanaZipStringsRoot = $@"{NanaZipSourceRoot}\NanaZipPackage\Strings\";

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

            string Result = "";

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

                foreach (var item in ParseSevenZipLanguageFile(txtFile))
                {
                    XmlElement data = resw.CreateElement("data");

                    data.SetAttribute("name", $"Resource{item.Key}");
                    data.SetAttribute("xml:space", "preserve");

                    XmlElement dataValue = resw.CreateElement("value");
                    dataValue.InnerText = item.Value;

                    data.AppendChild(dataValue);

                    resw.DocumentElement.AppendChild(data);
                }

                string resourcePath = $@"{NanaZipStringsRoot}\{langName}\";
                Directory.CreateDirectory(resourcePath);
                resw.Save($@"{resourcePath}\Legacy.resw");

                Result += $"{langName};";
            }

            return Result;
        }

        static void ConvertSevenZipLanguageFilesToSfxSelfContain()
        {
            string NanaZipSourceRoot = @"D:\Projects\MouriNaruto\NanaZip\";
            string SevenZipLangRoot = $@"{NanaZipSourceRoot}\SevenZip\Lang\";
            string NanaZipSfxRoot = $@"{NanaZipSourceRoot}\NanaZipSfxWindows\";
            string[] SfxResHeader =
            {
                $@"{NanaZipSourceRoot}\SevenZip\CPP\7zip\Bundles\SFXWin\resource.h",
                $@"{NanaZipSourceRoot}\SevenZip\CPP\7zip\UI\FileManager\ProgressDialog2Res.h",
                $@"{NanaZipSourceRoot}\SevenZip\CPP\7zip\UI\GUI\ExtractDialogRes.h",
                $@"{NanaZipSourceRoot}\SevenZip\CPP\7zip\UI\FileManager\OverwriteDialogRes.h",
                $@"{NanaZipSourceRoot}\SevenZip\CPP\7zip\UI\GUI\ExtractRes.h",
            };
            SortedDictionary<int, string> resourceDefine = new()
            {
                { 1012, "IDS_PROP_MTIME" }
            };

            int formatLength = 0;
            foreach (string headerFile in SfxResHeader)
            {
                foreach (string line in File.ReadLines(headerFile))
                {
                    if (!line.StartsWith("#define IDS_") && !line.StartsWith("#define IDT_"))
                    {
                        continue;
                    }
                    string[] splitLine = line.Split(
                        ' ',
                        StringSplitOptions.RemoveEmptyEntries |
                        StringSplitOptions.TrimEntries);
                    int.TryParse(splitLine[2], out int resourceID);
                    if (resourceID < 400)
                    {
                        continue;
                    }
                    else
                    {
                        resourceDefine.Add(resourceID, splitLine[1]);
                    }
                }
            }
            foreach (string strLength in resourceDefine.Values)
            {
                formatLength = Math.Max(formatLength, strLength.Length);
            }
            formatLength = (formatLength / 4 + 1) * 4;

            SortedDictionary<string, string> langMapping = new()
            {
                { "eu", "eu-es" },
                { "ku-ckb", "ku-arab" },
                { "mng", "mn-mong" },
                { "nb", "nb-no" },
                { "nn", "nn-no" },
                { "sr-spc", "sr-cyrl" },
                { "sr-spl", "sr-Latn" },
                { "va", "ca-es-valencia" },
                { "zh-cn", "zh-Hans" },
            };

            LinkedList<string> resourceContent = new();
            foreach (string headerFile in SfxResHeader)
            {
                resourceContent.AddLast($"#include \"{Path.GetFileName(headerFile)}\"");
            }
            resourceContent.AddLast("");
            foreach (string txtFile in Directory.GetFiles(SevenZipLangRoot))
            {
                string fileName = Path.GetFileName(txtFile);

                string langName = Path.GetFileNameWithoutExtension(txtFile);
                if (langMapping.ContainsKey(langName))
                {
                    langMapping.TryGetValue(langName, out langName);
                }

                uint dwFlags = langName.Contains('-') ? (uint)0x00000000 : 0x08000000;
                ushort LCID = LocaleNameToLCID(langName, dwFlags);
                ushort primaryLanguageID = (ushort)(LCID & (ushort)0x03FF);
                ushort subLanguageID = (ushort)(LCID >> 10);

                if (primaryLanguageID == 0x00)
                {
                    Console.WriteLine($"Error: Unsupported Language: {langName}");
                    continue;
                }

                SortedDictionary<int, string> stringMap = ParseSevenZipLanguageFile(txtFile);
                resourceContent.AddLast($"// {fileName} - {langName} - [{stringMap[1]} ({stringMap[2]})]");
                resourceContent.AddLast($"LANGUAGE 0x{primaryLanguageID:X2}, 0x{subLanguageID:X2}");
                resourceContent.AddLast("STRINGTABLE");
                resourceContent.AddLast("BEGIN");

                foreach (KeyValuePair<int, string> item in resourceDefine)
                {
                    try
                    {
                        resourceContent.AddLast(string.Format(
                            "    {0}L\"{1}\"",
                            item.Value.PadRight(formatLength, ' '),
                            stringMap[item.Key].Replace("\"", "\"\"")
                            ));
                    }
                    catch
                    {
                        Console.WriteLine($"Warning: Missing Resource ID{item.Key} in {fileName}");
                        continue;
                    }
                }

                resourceContent.AddLast("END");
                resourceContent.AddLast("");
            }
            File.WriteAllLines(
                $@"{NanaZipSfxRoot}\NanaZipSfxWindows.rc",
                resourceContent,
                Encoding.Unicode);
        }

        public static void Main(string[] args)
        {
            //GenerateSharedSevenZipZStandardProject();

            //string Result = GenerateArchiveTypesManifestDefinitions();

            //SwitchToPreview();
            //SwitchToRelease();

            //ConvertFilesToUtf8Bom(@"D:\Projects\MouriNaruto\NanaZip\SevenZip");

            //string Result = ConvertSevenZipLanguageFilesToModernResources();

            ConvertSevenZipLanguageFilesToSfxSelfContain();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
