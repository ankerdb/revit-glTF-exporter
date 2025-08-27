using System.Collections.Generic;
using Revit_glTF_Exporter;

namespace Common_glTF_Exporter.Transform
{
    public static class ModelScale
    {
        public static List<double> Get()
        {
            double scale = Util.ConvertFeetToUnitTypeId();
            return new List<double> { scale, scale, scale };
        }
    }
}
