using Mile.Net;
using System;

namespace Mile.LvglProjectXmlGenerator
{
    class Program
    {
        static void MileUefiProject()
        {
            string rootPath =
                @"D:\Projects\ProjectMile\Mile.Uefi\Mile.Uefi.Playground";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lvgl",
                rootPath + @"\",
                rootPath,
                @"LVGL.Portable");
        }

        static void Main(string[] args)
        {
            //MileUefiProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
