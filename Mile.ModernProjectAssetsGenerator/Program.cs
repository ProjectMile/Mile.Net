using Mile.Net;
using System;

namespace Mile.ModernProjectAssetsGenerator
{
    class Program
    {
        static void NanaGetProject()
        {
            string sourceRoot = @"D:\Projects\MouriNaruto\NanaGet\Assets\";
            string outputPath = @"D:\Projects\MouriNaruto\NanaGet\Assets\PackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaGet_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaGet_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaGet_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaGet_HighResolution_MetadataFile.png",
                outputPath,
                @"MetadataFile");

            outputPath = @"D:\Projects\MouriNaruto\NanaGet\Assets\PreviewPackageAssets";

            MsixPackageAssetsGenerator.GenerateApplicationImageAssets(
                sourceRoot + @"NanaGetPreview_HighResolution_ContrastStandard.png",
                sourceRoot + @"NanaGetPreview_HighResolution_ContrastBlack.png",
                sourceRoot + @"NanaGetPreview_HighResolution_ContrastWhite.png",
                outputPath);

            MsixPackageAssetsGenerator.GenerateFileAssociationImageAssets(
                sourceRoot + @"NanaGetPreview_HighResolution_MetadataFile.png",
                outputPath,
                @"MetadataFile");
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
            NanaGetProject();
            //NanaBoxProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
