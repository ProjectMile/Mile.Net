namespace Mile.NanaSeriesBuildTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProjectAssetsBuildTools.GenerateNanaZipAssets();
            //ProjectAssetsBuildTools.GenerateNanaBoxAssets();
            ProjectAssetsBuildTools.GenerateNanaGetAssets();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
