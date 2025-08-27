using System;
using Autodesk.Revit.DB;

namespace Common_glTF_Exporter
{
    public enum MaterialsEnum
    {
        textures,
        materials,
        nonematerials
    }

    public static class Preferences
    {
        public static MaterialsEnum Materials { get; set; } = MaterialsEnum.nonematerials;
        public static bool Normals { get; set; } = false;
        public static bool Levels { get; set; } = false;
        public static bool Lights { get; set; } = false;
        public static bool Grids { get; set; } = false;
        public static bool BatchId { get; set; } = false;
        public static bool Properties { get; set; } = false;
        public static bool RelocateTo0 { get; set; } = false;
        public static bool FlipAxis { get; set; } = true;
        public static ForgeTypeId Units { get; set; } = UnitTypeId.Meters;
        public static string Path { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string FileName { get; set; } = "3dExport";
        public static int Runs { get; set; } = 0;
        public static string User { get; set; } = "user01";
        public static int Release { get; set; } = 0;
        public static bool IsRFA { get; set; } = false;
    }
}
