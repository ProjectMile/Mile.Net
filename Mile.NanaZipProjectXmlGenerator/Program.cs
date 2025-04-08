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

        static string GenerateArchiveTypesManifestDefinitions()
        {
            string[] ArchiveTypes = new string[]
            {
                "001",
                "7z",
                "apfs",
                "arj",
                "br",
                "bz2",
                "bzip2",
                "cab",
                "cbr",
                "cbz",
                "cpio",
                "deb",
                "dmg",
                "esd",
                "fat",
                "gz",
                "gzip",
                "hfs",
                "hfsx",
                "iso",
                "lha",
                "liz",
                "lz",
                "lz4",
                "lz5",
                "lzh",
                "lzma",
                "lzma2",
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
                "tlz4",
                "tlz5",
                "tpz",
                "txz",
                "tzst",
                "tzstd",
                "vhd",
                "vhdx",
                "wim",
                "xar",
                "xz",
                "z",
                "zip",
                "zst",
                "zstd"
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
                "          <uap3:FileTypeAssociation Name=\"fileassociations\" Parameters=\"&quot;%1&quot;\">\r\n" +
                "            <uap:Logo>Assets\\ArchiveFile.png</uap:Logo>\r\n" +
                "            <uap:SupportedFileTypes>\r\n" +
                "{0}" +
                "              <uap10:FileType>*</uap10:FileType>\r\n" +
                "            </uap:SupportedFileTypes>\r\n" +
                "          </uap3:FileTypeAssociation>\r\n" +
                "        </uap:Extension>\r\n",
                Result);
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
            string ReswTemplatePath = @"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\ItemTemplates\WapProj\1033\Resw\Resources.resw";
            string SevenZipLangRoot = $@"D:\Projects\MouriNaruto\NanaZipLegacyLang";
            string NanaZipStringsRoot = $@"D:\Projects\MouriNaruto\NanaZip\NanaZipPackage\Strings\";

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
              
                    string result = item.Value;
                    result = result.Replace("\\r", "\r");
                    result = result.Replace("\\n", "\n");

                    XmlElement dataValue = resw.CreateElement("value");
                    dataValue.InnerText = result;

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
            string SevenZipLangRoot = $@"D:\Projects\MouriNaruto\NanaZipLegacyLang";
            string NanaZipSfxRoot = $@"D:\Projects\MouriNaruto\NanaZip\NanaZipSfxWindows\";
            //string[] SfxResHeader = {};
            SortedDictionary<int, string> resourceDefine = new()
            {
                { 401, "REDIRECTED_IDOK" },
                { 402, "REDIRECTED_IDCANCEL" },
                { 406, "REDIRECTED_IDYES" },
                { 407, "REDIRECTED_IDNO" },

                { 444, "IDB_PROGRESS_BACKGROUND" },
                { 446, "IDB_PAUSE" },
                { 3900, "IDT_PROGRESS_ELAPSED" },
                { 3901, "IDT_PROGRESS_REMAINING" },
                { 1032, "IDT_PROGRESS_FILES" },
                { 3906, "IDT_PROGRESS_ERRORS" },
                { 3902, "IDT_PROGRESS_TOTAL" },
                { 3903, "IDT_PROGRESS_SPEED" },
                { 3904, "IDT_PROGRESS_PROCESSED" },
                { 1008, "IDT_PROGRESS_PACKED" },
                { 3905, "IDT_PROGRESS_RATIO" },

                { 3401, "IDT_EXTRACT_EXTRACT_TO" },

                { 3500, "IDD_OVERWRITE" },
                { 3501, "IDT_OVERWRITE_HEADER" },
                { 3502, "IDT_OVERWRITE_QUESTION_BEGIN" },
                { 3503, "IDT_OVERWRITE_QUESTION_END" },
                { 440, "IDB_YES_TO_ALL" },
                { 3505, "IDB_AUTO_RENAME" },
                { 441, "IDB_NO_TO_ALL" },

                { 3800, "IDD_PASSWORD" },
                { 3801, "IDT_PASSWORD_ENTER" },
                { 3803, "IDX_PASSWORD_SHOW" },

                { 408, "IDS_CLOSE" },
                { 411, "IDS_CONTINUE" },

                { 445, "IDS_PROGRESS_FOREGROUND" },
                { 447, "IDS_PROGRESS_PAUSED" },

                { 448, "IDS_PROGRESS_ASK_CANCEL" },

                { 1012, "IDS_PROP_MTIME" },

                { 3000, "IDS_MEM_ERROR" },
                { 3003, "IDS_CANNOT_CREATE_FOLDER" },
                { 3004, "IDS_UPDATE_NOT_SUPPORTED" },
                { 3005, "IDS_CANT_OPEN_ARCHIVE" },
                { 3006, "IDS_CANT_OPEN_ENCRYPTED_ARCHIVE" },
                { 3007, "IDS_UNSUPPORTED_ARCHIVE_TYPE" },

                { 3017, "IDS_CANT_OPEN_AS_TYPE" },
                { 3018, "IDS_IS_OPEN_AS_TYPE" },
                { 3019, "IDS_IS_OPEN_WITH_OFFSET" },

                { 3300, "IDS_PROGRESS_EXTRACTING" },

                { 3325, "IDS_PROGRESS_SKIPPING" },

                { 3402, "IDS_EXTRACT_SET_FOLDER" },

                { 3411, "IDS_EXTRACT_PATHS_FULL" },
                { 3412, "IDS_EXTRACT_PATHS_NO" },
                { 3413, "IDS_EXTRACT_PATHS_ABS" },
                { 3414, "IDS_PATH_MODE_RELAT" },
                { 3421, "IDS_EXTRACT_OVERWRITE_ASK" },
                { 3422, "IDS_EXTRACT_OVERWRITE_WITHOUT_PROMPT" },
                { 3423, "IDS_EXTRACT_OVERWRITE_SKIP_EXISTING" },

                { 3424, "IDS_EXTRACT_OVERWRITE_RENAME" },
                { 3425, "IDS_EXTRACT_OVERWRITE_RENAME_EXISTING" },

                { 3504, "IDS_FILE_SIZE" },

                { 3700, "IDS_EXTRACT_MESSAGE_UNSUPPORTED_METHOD" },
                { 3701, "IDS_EXTRACT_MESSAGE_DATA_ERROR" },
                { 3702, "IDS_EXTRACT_MESSAGE_CRC_ERROR" },
                { 3703, "IDS_EXTRACT_MESSAGE_DATA_ERROR_ENCRYPTED" },
                { 3704, "IDS_EXTRACT_MESSAGE_CRC_ERROR_ENCRYPTED" },
                { 3710, "IDS_EXTRACT_MSG_WRONG_PSW_GUESS" },

                { 3721, "IDS_EXTRACT_MSG_UNSUPPORTED_METHOD" },
                { 3722, "IDS_EXTRACT_MSG_DATA_ERROR" },
                { 3723, "IDS_EXTRACT_MSG_CRC_ERROR" },
                { 3724, "IDS_EXTRACT_MSG_UNAVAILABLE_DATA" },
                { 3725, "IDS_EXTRACT_MSG_UEXPECTED_END" },
                { 3726, "IDS_EXTRACT_MSG_DATA_AFTER_END" },
                { 3727, "IDS_EXTRACT_MSG_IS_NOT_ARC" },

                { 3728, "IDS_EXTRACT_MSG_HEADERS_ERROR" },
                { 3729, "IDS_EXTRACT_MSG_WRONG_PSW_CLAIM" },

                { 3763, "IDS_OPEN_MSG_UNAVAILABLE_START" },
                { 3764, "IDS_OPEN_MSG_UNCONFIRMED_START" },
                { 3768, "IDS_OPEN_MSG_UNSUPPORTED_FEATURE" },
            };

            int formatLength = 0;
            //foreach (string headerFile in SfxResHeader)
            //{
            //    foreach (string line in File.ReadLines(headerFile))
            //    {
            //        if (!line.StartsWith("#define IDS_") && !line.StartsWith("#define IDT_"))
            //        {
            //            continue;
            //        }
            //        string[] splitLine = line.Split(
            //            ' ',
            //            StringSplitOptions.RemoveEmptyEntries |
            //            StringSplitOptions.TrimEntries);
            //        int.TryParse(splitLine[2], out int resourceID);
            //        if (resourceID < 400)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            resourceDefine.Add(resourceID, splitLine[1]);
            //        }
            //    }
            //}

            LinkedList<string> resourceHeader = new();

            foreach (string strLength in resourceDefine.Values)
            {
                formatLength = Math.Max(formatLength, strLength.Length);
            }
            formatLength = (formatLength / 4 + 1) * 4;

            foreach (KeyValuePair<int, string> item in resourceDefine)
            {
                resourceHeader.AddLast($"#define {item.Value.PadRight(formatLength, ' ')}{item.Key}");
            }
            File.WriteAllLines(
                $@"{NanaZipSfxRoot}\NanaZipSfxWindowsResources.h",
                resourceHeader,
                Encoding.UTF8);

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
            //foreach (string headerFile in SfxResHeader)
            //{
            //    resourceContent.AddLast($"#include \"{Path.GetFileName(headerFile)}\"");
            //}
            resourceContent.AddLast($"#include \"NanaZipSfxWindowsResources.h\"");
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
                            "    {0}\"{1}\"",
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
                $@"{NanaZipSfxRoot}\NanaZipSfxWindowsResources.rc",
                resourceContent,
                Encoding.Unicode);
        }

        public static void Main(string[] args)
        {
            //string Result = GenerateArchiveTypesManifestDefinitions();

            //string Result = ConvertSevenZipLanguageFilesToModernResources();
            //ConvertSevenZipLanguageFilesToSfxSelfContain();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
