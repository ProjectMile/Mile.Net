using Mile.Net;
using System;

namespace Mile.ModernProjectAssetsGenerator
{
    class Program
    {
        static void NanaZipProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\NanaZip\Assets\";
            string outputPath = @"D:\NanaZipWorkspace";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaZip_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaZip_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaZip_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaZip_HighResolution_ArchiveFile.png",
                outputPath,
                @"ArchiveFile");
        }

        static void NagisaProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\Nagisa\Assets\";
            string outputPath = @"D:\NagisaWorkspace";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"Nagisa_HighResolution_ContrastStandard.png",
                sourceRoot + @"Nagisa_HighResolution_ContrastBlack.png",
                sourceRoot + @"Nagisa_HighResolution_ContrastWhite.png",
                outputPath);
        }

        static void Main(string[] args)
        {
            //NanaZipProject();
            NagisaProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
