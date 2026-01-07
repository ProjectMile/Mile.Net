using ImageMagick;
using System.Diagnostics;

namespace Mile.Svg2Ico
{
    internal class Program
    {
        public static uint[] IconSizes = [ 16, 20, 24, 32, 40, 48, 64, 256 ];

        static void Main(string[] args)
        {
            string SourceSvgPath =
                //@"D:\Projects\halalcloud\halalcloud-client\Assets\HalalCloud.svg";
                @"D:\Projects\ProjectMile\Mile.Cirno\Assets\Mile.Cirno.svg";
            string OutputIcoPath =
                //@"D:\Projects\halalcloud\halalcloud-client\Assets\HalalCloud.ico";
                @"D:\Projects\ProjectMile\Mile.Cirno\Assets\Mile.Cirno.ico";

            string PngQuantPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "pngquant.exe");
            if (!File.Exists(PngQuantPath))
            {
                PngQuantPath = string.Empty;
            }    

            string TemporaryPngPath = Path.Combine(
                    Path.GetTempPath(),
                    "Mile.Svg2Ico",
                    Guid.NewGuid().ToString("N"));

            try
            {
                Directory.CreateDirectory(TemporaryPngPath);

                MagickImageCollection IconCollection = new MagickImageCollection();

                foreach (uint IconSize in IconSizes)
                {
                    MagickReadSettings Settings = new MagickReadSettings();
                    Settings.Format = MagickFormat.Svg;
                    Settings.BackgroundColor = MagickColors.Transparent;
                    Settings.Width = IconSize;
                    Settings.Height = IconSize;
                    MagickImage Image = new MagickImage(
                        SourceSvgPath,
                        Settings);
                    if (string.IsNullOrEmpty(PngQuantPath))
                    {
                        IconCollection.Add(Image);
                        continue;
                    }

                    string CurrentPngPath = Path.Combine(
                        TemporaryPngPath,
                        $"{IconSize}.png");
                    Image.Write(CurrentPngPath);

                    Process PngQuantProcess = new Process();
                    PngQuantProcess.StartInfo.FileName = PngQuantPath;
                    PngQuantProcess.StartInfo.WorkingDirectory = TemporaryPngPath;
                    PngQuantProcess.StartInfo.UseShellExecute = false;
                    PngQuantProcess.StartInfo.CreateNoWindow = true;
                    PngQuantProcess.StartInfo.RedirectStandardOutput = true;
                    PngQuantProcess.StartInfo.RedirectStandardError = true;
                    PngQuantProcess.StartInfo.Arguments = string.Format(
                        "--force --ext .png --quality 80-80 \"{0}\"",
                        CurrentPngPath);
                    PngQuantProcess.Start();
                    PngQuantProcess.WaitForExit();

                    MagickImage ProceededImage = new MagickImage(
                        CurrentPngPath);
                    IconCollection.Add(ProceededImage);
                }

                IconCollection.Write(OutputIcoPath);
            }
            finally
            {
                try
                {
                    if (Directory.Exists(TemporaryPngPath))
                    {
                        Directory.Delete(TemporaryPngPath, true);
                    }
                }
                catch
                {
                    // Do nothing
                }
            }

            Console.WriteLine(
               "Mile.Svg2Ico task has been completed.");
            Console.ReadKey();
        }
    }
}
