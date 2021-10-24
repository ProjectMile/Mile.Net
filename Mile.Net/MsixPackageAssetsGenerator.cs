using ImageMagick;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mile.Net
{
    public class MsixPackageAssetsGenerator
    {
        private struct AssetType
        {
            public string Name;
            public int Width;
            public int Height;
            public int IconSize;

            public AssetType(string Name, int Width, int Height, int IconSize)
            {
                this.Name = Name;
                this.Width = Width;
                this.Height = Height;
                this.IconSize = IconSize;
            }
        }

        private static int CeilToEven(int i)
        {
            return (i % 2 == 0) ? (i) : (i + 1);
        }

        public static void GenerateApplicationImageAssets(
            string contrastStandardImagePath,
            string contrastBlackImagePath,
            string contrastWhiteImagePath,
            string outputAssetsPath)
        {
            ConcurrentBag<AssetType> allAssetSizes =
                new ConcurrentBag<AssetType>();
            {
                AssetType[] assetTypes = new AssetType[]
                {
                    new AssetType("LargeTile", 310, 310, 96),
                    new AssetType("LockScreenLogo", 24, 24, 24),
                    new AssetType("SmallTile", 71, 71, 36),
                    //new AssetType("SplashScreen", 620, 300, 96),
                    new AssetType("Square44x44Logo", 44, 44, 32),
                    new AssetType("Square150x150Logo", 150, 150, 48),
                    new AssetType("StoreLogo", 50, 50, 36),
                    new AssetType("Wide310x150Logo", 310, 150, 48)
                };

                double[] scales = new double[]
                {
                    1.0, 1.25, 1.5, 2.0, 4.0
                };

                int[] altForms = new int[]
                {
                    16, 20, 24, 30, 32, 36, 40, 48, 60, 64, 72, 80, 96, 256
                };

                foreach (AssetType assetType in assetTypes)
                {
                    foreach (double scale in scales)
                    {
                        allAssetSizes.Add(new AssetType(
                            string.Format(
                                "{0}.scale-{1}",
                                assetType.Name,
                                Convert.ToInt32(scale * 100)),
                            Convert.ToInt32(Math.Round(
                                assetType.Width * scale,
                                MidpointRounding.ToPositiveInfinity)),
                            Convert.ToInt32(Math.Round(
                                assetType.Height * scale,
                                MidpointRounding.ToPositiveInfinity)),
                            CeilToEven(
                                Convert.ToInt32(assetType.IconSize * scale))));
                    }
                }

                foreach (int altForm in altForms)
                {
                    string baseName = string.Format(
                        "Square44x44Logo.targetsize-{0}",
                        altForm);

                    allAssetSizes.Add(new AssetType(
                           baseName,
                           altForm,
                           altForm,
                           altForm));

                    allAssetSizes.Add(new AssetType(
                           baseName + "_altform-unplated",
                           altForm,
                           altForm,
                           altForm));

                    allAssetSizes.Add(new AssetType(
                           baseName + "_altform-lightunplated",
                           altForm,
                           altForm,
                           altForm));
                }
            }

            MagickImage imageContrastStandard =
                new MagickImage(contrastStandardImagePath);
            MagickImage imageContrastBlack =
                new MagickImage(contrastBlackImagePath);
            MagickImage imageContrastWhite =
                new MagickImage(contrastWhiteImagePath);

            List<Task> tasks = new List<Task>();

            foreach (AssetType item in allAssetSizes)
            {
                tasks.Add(Task.Run(async () =>
                {
                    MagickImage sourceImage = new MagickImage(
                        imageContrastStandard);

                    MagickGeometry size = new MagickGeometry(
                        item.IconSize,
                        item.IconSize);

                    size.IgnoreAspectRatio = true;
                    sourceImage.Resize(size);

                    MagickImage targetImage = new MagickImage(
                        MagickColors.Transparent,
                        item.Width,
                        item.Height);
                    targetImage.Composite(
                        sourceImage,
                        Gravity.Center,
                        CompositeOperator.Over);
                    targetImage.Write(
                        string.Format(
                            @"{0}\{1}.png",
                            outputAssetsPath,
                            item.Name));
                }));

                tasks.Add(Task.Run(async () =>
                {
                    MagickImage sourceImage = new MagickImage(
                        imageContrastBlack);

                    MagickGeometry size = new MagickGeometry(
                        item.IconSize,
                        item.IconSize);

                    size.IgnoreAspectRatio = true;
                    sourceImage.Resize(size);

                    MagickImage targetImage = new MagickImage(
                        MagickColors.Transparent,
                        item.Width,
                        item.Height);
                    targetImage.Composite(
                        sourceImage,
                        Gravity.Center,
                        CompositeOperator.Over);
                    targetImage.Write(
                        string.Format(
                            @"{0}\{1}_contrast-black.png",
                            outputAssetsPath,
                            item.Name));
                }));

                tasks.Add(Task.Run(async () =>
                {
                    MagickImage sourceImage = new MagickImage(
                        imageContrastWhite);

                    MagickGeometry size = new MagickGeometry(
                        item.IconSize,
                        item.IconSize);

                    size.IgnoreAspectRatio = true;
                    sourceImage.Resize(size);

                    MagickImage targetImage = new MagickImage(
                        MagickColors.Transparent,
                        item.Width,
                        item.Height);
                    targetImage.Composite(
                        sourceImage,
                        Gravity.Center,
                        CompositeOperator.Over);
                    targetImage.Write(
                        string.Format(
                            @"{0}\{1}_contrast-white.png",
                            outputAssetsPath,
                            item.Name));
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }

        public static void GenerateFileAssociationImageAssets(
            string fileAssociationImagePath,
            string outputAssetsPath,
            string outputAssetsPrefix)
        {
            int[] altForms = new int[]
            {
                16, 20, 24, 32, 40, 48, 64, 256
            };

            MagickImage imageArchiveFile =
                new MagickImage(fileAssociationImagePath); 

            List<Task> tasks = new List<Task>();

            foreach (int item in altForms)
            {
                tasks.Add(Task.Run(async () =>
                {
                    MagickImage sourceImage = new MagickImage(
                    imageArchiveFile);

                    MagickGeometry size = new MagickGeometry(
                        item,
                        item);

                    size.IgnoreAspectRatio = true;
                    sourceImage.Resize(size);

                    MagickImage targetImage = new MagickImage(
                        MagickColors.Transparent,
                        item,
                        item);
                    targetImage.Composite(
                        sourceImage,
                        Gravity.Center,
                        CompositeOperator.Over);
                    targetImage.Write(
                        string.Format(
                            @"{0}\{1}.targetsize-{2}.png",
                            outputAssetsPath,
                            outputAssetsPrefix,
                            item));
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
