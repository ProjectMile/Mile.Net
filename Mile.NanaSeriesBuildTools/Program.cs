namespace Mile.NanaSeriesBuildTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProjectAssetsBuildTools.GenerateNanaZipAssets();

            Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
