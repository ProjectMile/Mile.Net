using ImageMagick;
using System.Collections.Concurrent;
using Mile.Project.Helpers;

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

                foreach (var AssetSize in ProjectAssetsUtilities.AssetSizes)
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

                ProjectAssetsUtilities.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                ProjectAssetsUtilities.GeneratePackageFileAssociationImageAssets(
                    ArchiveFileSources,
                    OutputPath,
                    @"ArchiveFile");

                ProjectAssetsUtilities.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaZip.ico");

                ProjectAssetsUtilities.GenerateIconFile(
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

                foreach (var AssetSize in ProjectAssetsUtilities.AssetSizes)
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

                ProjectAssetsUtilities.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                ProjectAssetsUtilities.GeneratePackageFileAssociationImageAssets(
                    ArchiveFileSources,
                    OutputPath,
                    @"ArchiveFile");

                ProjectAssetsUtilities.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaZipPreview.ico");

                ProjectAssetsUtilities.GenerateIconFile(
                    SfxStubSources,
                    OutputPath + @"\..\NanaZipPreviewSfx.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaZipPreview.png");
            }
        }

        public static void GenerateNanaGetAssets()
        {
            {
                string SourcePath = @"D:\Projects\MouriNaruto\NanaGet\Assets\OriginalAssets\NanaGet";

                string OutputPath = @"D:\Projects\MouriNaruto\NanaGet\Assets\PackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> MetadataFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in ProjectAssetsUtilities.AssetSizes)
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

                    MetadataFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "MetadataFile",
                        AssetSize));
                }

                ProjectAssetsUtilities.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                ProjectAssetsUtilities.GeneratePackageFileAssociationImageAssets(
                    MetadataFileSources,
                    OutputPath,
                    @"MetadataFile");

                ProjectAssetsUtilities.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaGet.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaGet.png");
            }

            {
                string SourcePath = @"D:\Projects\MouriNaruto\NanaGet\Assets\OriginalAssets\NanaGetPreview";

                string OutputPath = @"D:\Projects\MouriNaruto\NanaGet\Assets\PreviewPackageAssets";

                ConcurrentDictionary<int, MagickImage> StandardSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastBlackSources =
                    new ConcurrentDictionary<int, MagickImage>();
                ConcurrentDictionary<int, MagickImage> ContrastWhiteSources =
                    new ConcurrentDictionary<int, MagickImage>();

                ConcurrentDictionary<int, MagickImage> MetadataFileSources =
                    new ConcurrentDictionary<int, MagickImage>();

                foreach (var AssetSize in ProjectAssetsUtilities.AssetSizes)
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

                    MetadataFileSources[AssetSize] = new MagickImage(string.Format(
                        @"{0}\{1}\{1}_{2}.png",
                        SourcePath,
                        "MetadataFile",
                        AssetSize));
                }

                ProjectAssetsUtilities.GeneratePackageApplicationImageAssets(
                    StandardSources,
                    ContrastBlackSources,
                    ContrastWhiteSources,
                    OutputPath);

                ProjectAssetsUtilities.GeneratePackageFileAssociationImageAssets(
                    MetadataFileSources,
                    OutputPath,
                    @"MetadataFile");

                ProjectAssetsUtilities.GenerateIconFile(
                    StandardSources,
                    OutputPath + @"\..\NanaGetPreview.ico");

                StandardSources[64].Write(
                    OutputPath + @"\..\NanaGetPreview.png");
            }
        }
    }
}
