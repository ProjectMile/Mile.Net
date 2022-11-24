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
    }
}
