using System;
using System.Collections.Generic;

using Autodesk.Revit.DB;
using Common_glTF_Exporter.Materials;
using Common_glTF_Exporter.Utils;
using Common_glTF_Exporter.Core;

namespace Common_glTF_Exporter
{
    public class Exporter
    {
        public void Export(Document doc)
        {
            ExportLog.StartLog();
            Autodesk.Revit.DB.View view = doc.ActiveView;

            if (view == null || view.GetType().Name != "View3D")
            {
                ExportLog.WriteException(new Exception("Wrong View, You must be in a 3D view to export"));
                return;
            }
            var texturePaths = TextureLocation.GetPaths();

            List<Element> elementsInView = Collectors.AllVisibleElementsByView(doc, view);

            if (!doc.IsFamilyDocument && elementsInView.Count == 0)
            {
                ExportLog.WriteException(new Exception("There are no valid elements to export in this view"));
                return;
            }

            ExportLog.Write($"{elementsInView.Count} elements will be exported");

            GLTFExportContext ctx = new GLTFExportContext(doc, view);
            CustomExporter exporter = new CustomExporter(doc, ctx);
            exporter.ShouldStopOnError = false;

            exporter.Export(view);
            ExportLog.EndLog();
        }
    }
}
