using Autodesk.Revit.DB;
using Common_glTF_Exporter;

namespace Anker.GLTF.Exporter
{
    public static class AnkerGltfExporter
    {
        public static string Export(Document doc, string fileName)
        {
            return Common_glTF_Exporter.Exporter.Export(doc, fileName);
        }
    }
}
