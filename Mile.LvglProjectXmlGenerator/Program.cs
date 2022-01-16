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

        static void LvglSimulatorProject()
        {
            string rootPath =
                @"D:\Projects\lvgl\lv_sim_visual_studio\LVGL.Simulator";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lvgl",
                rootPath + @"\",
                rootPath,
                @"LVGL.Portable");

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lv_drivers",
                rootPath + @"\",
                rootPath,
                @"LVGL.Drivers");
        }


        static void Main(string[] args)
        {
            MileUefiProject();
            //LvglWindowsProject();
            //LvglSimulatorProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
