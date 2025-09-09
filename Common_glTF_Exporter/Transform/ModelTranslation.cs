using System.Collections.Generic;
using Autodesk.Revit.DB;
using Common_glTF_Exporter.Utils;
using Revit_glTF_Exporter;

namespace Common_glTF_Exporter.Transform
{
    public static class ModelTranslation
    {
        public static List<float> GetPointToRelocate(Document doc, double scale)
        {
            
            if (Exporter.exportOptions.RelocateTo0)
            {
                List<Element> elementsOnActiveView = new List<Element>();
                if (doc.IsFamilyDocument)
                {
                    elementsOnActiveView = Collectors.AllVisibleElementsByViewRfa(doc, doc.ActiveView);
                }
                else
                {
                    elementsOnActiveView = Collectors.AllVisibleElementsByView(doc, doc.ActiveView);
                }

                var bb = Util.GetElementsBoundingBox(doc.ActiveView, elementsOnActiveView);
                
                if (Exporter.exportOptions.FlipAxis)
                {
                    double pointX = -scale * ((bb.Min.X + bb.Max.X) / 2);
                    double pointy = -scale * bb.Min.Z;
                    double pointz = -scale * ((bb.Min.Y + bb.Max.Y) / 2);
                    return new List<float> { (float)pointX, (float)pointy, -(float)pointz };
                }
                else
                {
                    double pointX = -scale * ((bb.Min.X + bb.Max.X) / 2);
                    double pointy = -scale * ((bb.Min.Z + bb.Max.Z) / 2);
                    double pointz = -scale * bb.Min.Y;
                    return new List<float> { (float)pointX, (float)pointz, (float)pointy };
                }
            }

            return new List<float> { 0, 0, 0 };
        }
    }
}
