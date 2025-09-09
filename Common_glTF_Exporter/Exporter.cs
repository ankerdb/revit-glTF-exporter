using Autodesk.Revit.DB;
using Common_glTF_Exporter.Core;
using Common_glTF_Exporter.Materials;
using Common_glTF_Exporter.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using Anker.GLTF.Exporter;

namespace Common_glTF_Exporter
{
    internal static class Exporter
    {
        internal static Document CurrentDocument;
        internal static List<string> TexturePaths = new List<string>();
        internal static AnkerGltfExporter.ExportOptions exportOptions = new AnkerGltfExporter.ExportOptions();
        internal static bool Export(Document doc, AnkerGltfExporter.ExportOptions options)
        {
            exportOptions = options;
            if (!Directory.Exists(exportOptions.TempDirectory))
            {
                Directory.CreateDirectory(exportOptions.TempDirectory);
            }
            ExportLog.StartLog();
            CurrentDocument = doc;
            exportOptions.GlbFileName = string.IsNullOrEmpty(exportOptions.GlbFileName)
            ? "export.glb"
            : exportOptions.GlbFileName.EndsWith(".glb", StringComparison.OrdinalIgnoreCase)
                ? exportOptions.GlbFileName
                : $"{exportOptions.GlbFileName}.glb";
            Autodesk.Revit.DB.View view = doc.ActiveView;

            try
            {

                if (view == null || view.GetType().Name != "View3D")
                {
                    ExportLog.WriteException(new Exception("Wrong View, You must be in a 3D view to export"));
                    return false;
                }
                TexturePaths = TextureLocation.GetPaths();

                List<Element> elementsInView = Collectors.AllVisibleElementsByView(doc, view);

                if (!doc.IsFamilyDocument && elementsInView.Count == 0)
                {
                    ExportLog.WriteException(new Exception("There are no valid elements to export in this view"));
                    return false;
                }

                ExportLog.Write($"Element count - {elementsInView.Count}");

                GLTFExportContext ctx = new GLTFExportContext(doc, view);
                CustomExporter exporter = new CustomExporter(doc, ctx);
                exporter.ShouldStopOnError = false;

                exporter.Export(view);
                ExportLog.Write("Writing to file...");
                ExportLog.EndLog();
                return true;
            }
            catch (Exception ex)
            {
                ExportLog.Write("Export failed");
                ExportLog.WriteException(ex);
                return false;
            }
        }
    }
}
