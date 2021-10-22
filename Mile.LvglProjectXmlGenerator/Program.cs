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
                @"LVGL.Core");

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lv_demos",
                rootPath + @"\",
                rootPath,
                @"LVGL.Demonstrations");
        }

        static void MileLilyProject()
        {
            string rootPath =
                @"D:\Projects\ProjectMile\Mile.Lily\Mile.Lily";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lvgl",
                rootPath + @"\",
                rootPath,
                @"LVGL.Core");
        }

        static void LvglWindowsProject()
        {
            string rootPath =
                @"D:\Projects\lvgl\lv_port_windows\LVGL.Windows";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lvgl",
                rootPath + @"\",
                rootPath,
                @"LVGL.Core");

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lv_demos",
                rootPath + @"\",
                rootPath,
                @"LVGL.Demonstrations");
        }

        static void LvglSimulatorProject()
        {
            string rootPath =
                @"D:\Projects\lvgl\lv_sim_visual_studio\LVGL.Simulator";

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lvgl",
                rootPath + @"\",
                rootPath,
                @"LVGL.Core");

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lv_demos",
                rootPath + @"\",
                rootPath,
                @"LVGL.Demonstrations");

            VisualStudioCppItemsProjectGenerator.Generate(
                rootPath + @"\lv_drivers",
                rootPath + @"\",
                rootPath,
                @"LVGL.Drivers");
        }


        static void Main(string[] args)
        {
            //MileUefiProject();
            MileLilyProject();
            //LvglWindowsProject();
            //LvglSimulatorProject();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
