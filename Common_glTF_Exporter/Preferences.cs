using System;
using System.IO;
using Autodesk.Revit.DB;

namespace Common_glTF_Exporter
{
    internal enum MaterialsEnum
    {
        textures,
        materials,
        nonematerials
    }

    internal static class Preferences
    {
        public static MaterialsEnum Materials { get; set; } = MaterialsEnum.nonematerials;
        public static bool Normals { get; set; } = false;
        public static bool Levels { get; set; } = false;
        public static bool Grids { get; set; } = false;
        public static bool BatchId { get; set; } = false;
        public static bool Properties { get; set; } = false;
        public static bool RelocateTo0 { get; set; } = false;
        public static bool FlipAxis { get; set; } = true;
        public static ForgeTypeId Units { get; set; } = UnitTypeId.Meters;
        public static string TempDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Anker/CustomGltfExporter");
        public static string FileName { get; set; } = "";
    }
}
