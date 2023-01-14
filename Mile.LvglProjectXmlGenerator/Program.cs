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

        static void LvglWindowsProject()
        {
            string rootPath =
                @"D:\Projects\lvgl\lv_port_windows\LVGL.Windows";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lvgl",
                rootPath + @"\",
                rootPath,
                @"LVGL.Portable");
        }

        static void Main(string[] args)
        {
            //MileUefiProject();
            //LvglWindowsProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
