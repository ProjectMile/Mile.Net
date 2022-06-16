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

        static void NanaGetProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\NanaGet\Assets\";
            string outputPath = @"D:\Projects\MouriNaruto\NanaGet\Assets\PackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaGet_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaGet_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaGet_HighResolution_ContrastWhite.png",
                outputPath);
        }

        static void NanaBoxProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\NanaBox\Assets\";
            string outputPath = @"D:\Projects\MouriNaruto\NanaBox\Assets\PackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaBox_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaBox_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaBox_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaBox_HighResolution_ConfigurationFile.png",
                outputPath,
                @"ConfigurationFile");

            outputPath = @"D:\Projects\MouriNaruto\NanaBox\Assets\PreviewPackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaBoxPreview_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaBoxPreview_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaBoxPreview_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaBoxPreview_HighResolution_ConfigurationFile.png",
                outputPath,
                @"ConfigurationFile");
        }

        static void Main(string[] args)
        {
            //NanaZipProject();
            //NanaGetProject();
            NanaBoxProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
