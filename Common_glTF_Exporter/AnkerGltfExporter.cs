using Autodesk.Revit.DB;
using Common_glTF_Exporter;
using System;
using System.IO;

namespace Anker.GLTF.Exporter
{
    public static class AnkerGltfExporter
    {
        public static bool Export(Document doc, ExportOptions? options = null)
        {
            return Common_glTF_Exporter.Exporter.Export(doc, options ?? new ExportOptions());
        }

        public enum MaterialsExportMode
        {
            Textures,
            Materials,
            None
        }

        public enum  Compression
        {
            None,
            Draco,
            MeshOpt
        }

        public class ExportOptions
        {
            public MaterialsExportMode Materials { get; set; } = MaterialsExportMode.None;
            public bool Normals { get; set; } = false;
            public bool Levels { get; set; } = false;
            public bool Grids { get; set; } = false;
            public bool BatchId { get; set; } = false;
            public bool Properties { get; set; } = false;
            public bool RelocateTo0 { get; set; } = false;
            public bool FlipAxis { get; set; } = false;
            public ForgeTypeId Units { get; set; } = UnitTypeId.Meters;
            public Compression Compress { get; set; } = Compression.None;
            public string TempDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Anker/CustomGltfExporter");
            public string GlbFileName { get; set; } = "";
            public string TxtFileName { get; set; } = "gltf_export_log.txt";
        }
    }
}
 