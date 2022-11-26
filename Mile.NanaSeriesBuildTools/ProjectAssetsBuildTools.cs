using ImageMagick;
using System.Collections.Concurrent;

namespace Mile.NanaSeriesBuildTools
{
    public class ProjectAssetsBuildTools
    {
        public static void GenerateNanaZipAssets()
        {
            {
                string SourcePath = @"D:\Projects\MouriNaruto\NanaZip\Assets\OriginalAssets\NanaZip";

                string OutputPath = @"D:\Projects\MouriNaruto\NanaZip\Assets\PackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> ArchiveFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> SfxStubSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in AssetsUtils.AssetSizes)
                {
                    StandardSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "Standard",
                        AssetSize));
                    ContrastBlackSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastBlack",
                        AssetSize));
                    ContrastWhiteSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastWhite",
                        AssetSize));

                    ArchiveFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ArchiveFile",
                        AssetSize));

                    SfxStubSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "SelfExtractingExecutable",
                        AssetSize));
                }

                AssetsGenerator.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                AssetsGenerator.GeneratePackageFileAssociationImageAssets(
                    ArchiveFileSources,
                    OutputPath,
                    @"ArchiveFile");

                AssetsGenerator.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaZip.ico");

                AssetsGenerator.GenerateIconFile(
                    SfxStubSources,
                    OutputPath + @"\..\NanaZipSfx.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaZip.png");
            }

            {
                string SourcePath = @"D:\Projects\MouriNaruto\NanaZip\Assets\OriginalAssets\NanaZipPreview";

                string OutputPath = @"D:\Projects\MouriNaruto\NanaZip\Assets\PreviewPackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> ArchiveFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> SfxStubSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in AssetsUtils.AssetSizes)
                {
                    StandardSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "Standard",
                        AssetSize));
                    ContrastBlackSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastBlack",
                        AssetSize));
                    ContrastWhiteSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastWhite",
                        AssetSize));

                    ArchiveFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ArchiveFile",
                        AssetSize));

                    SfxStubSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "SelfExtractingExecutable",
                        AssetSize));
                }

                AssetsGenerator.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                AssetsGenerator.GeneratePackageFileAssociationImageAssets(
                    ArchiveFileSources,
                    OutputPath,
                    @"ArchiveFile");

                AssetsGenerator.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaZipPreview.ico");

                AssetsGenerator.GenerateIconFile(
                    SfxStubSources,
                    OutputPath + @"\..\NanaZipPreviewSfx.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaZipPreview.png");
            }
        }

        public static void GenerateNanaBoxAssets()
        {
            {
                string SourcePath = @"D:\Projects\MouriNaruto\NanaBox\Assets\OriginalAssets\NanaBox";

                string OutputPath = @"D:\Projects\MouriNaruto\NanaBox\Assets\PackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> ConfigurationFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in AssetsUtils.AssetSizes)
                {
                    StandardSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "Standard",
                        AssetSize));
                    ContrastBlackSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastBlack",
                        AssetSize));
                    ContrastWhiteSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastWhite",
                        AssetSize));

                    ConfigurationFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ConfigurationFile",
                        AssetSize));
                }

                AssetsGenerator.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                AssetsGenerator.GeneratePackageFileAssociationImageAssets(
                    ConfigurationFileSources,
                    OutputPath,
                    @"ConfigurationFile");

                AssetsGenerator.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaBox.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaBox.png");
            }

            {
                string SourcePath = @"D:\Projects\MouriNaruto\NanaBox\Assets\OriginalAssets\NanaBoxPreview";

                string OutputPath = @"D:\Projects\MouriNaruto\NanaBox\Assets\PreviewPackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> ConfigurationFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in AssetsUtils.AssetSizes)
                {
                    StandardSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "Standard",
                        AssetSize));
                    ContrastBlackSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastBlack",
                        AssetSize));
                    ContrastWhiteSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ContrastWhite",
                        AssetSize));

                    ConfigurationFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "ConfigurationFile",
                        AssetSize));
                }

                AssetsGenerator.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                AssetsGenerator.GeneratePackageFileAssociationImageAssets(
                    ConfigurationFileSources,
                    OutputPath,
                    @"ConfigurationFile");

                AssetsGenerator.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaBoxPreview.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaBoxPreview.png");
            }
        }
    }
}
