using Mile.Net;
using System;

namespace Mile.ModernProjectAssetsGenerator
{
    class Program
    {
        static void NanaZipProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\NanaZip\Assets\";
            string outputPath = @"D:\Projects\MouriNaruto\NanaZip\Assets\PackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaZip_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaZip_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaZip_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaZip_HighResolution_ArchiveFile.png",
                outputPath,
                @"ArchiveFile");

            outputPath = @"D:\Projects\MouriNaruto\NanaZip\Assets\PreviewPackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaZipPreview_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaZipPreview_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaZipPreview_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaZipPreview_HighResolution_ArchiveFile.png",
                outputPath,
                @"ArchiveFile");
        }

        static void NagisaProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\Nagisa\Assets\";
            string outputPath = @"D:\TemporaryWorkspace\NagisaWorkspace";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"Nagisa_HighResolution_ContrastStandard.png",
                sourceRoot + @"Nagisa_HighResolution_ContrastBlack.png",
                sourceRoot + @"Nagisa_HighResolution_ContrastWhite.png",
                outputPath);
        }

        static void Main(string[] args)
        {
            NanaZipProject();
            //NagisaProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
