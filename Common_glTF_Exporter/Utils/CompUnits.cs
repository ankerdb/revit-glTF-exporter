using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Autodesk.Revit.DB;

namespace Common_glTF_Exporter.Utils
{
    internal static class CompUnits
    {
#if REVIT2026
        public static string RevitVersion => "2026";
        public static long GetIdValue(ElementId id) => id?.Value ?? -1L;
        public static ElementId IdByLong(long id) => new ElementId(id);

#elif REVIT2025
        public static string RevitVersion => "2025";
        public static long GetIdValue(ElementId id) => id?.Value ?? -1L;
        public static ElementId IdByLong(long id) => new ElementId(id);

#elif REVIT2024
        public static string RevitVersion => "2024";
        public static long GetIdValue(ElementId id)
        {
            if (id == null)
                return -1L;

            return GetIdValue2024(id);
        }
        private static long GetIdValue2024(ElementId id)
        {
            var getIdValueDelegate = (Func<ElementId, long>) Delegate.CreateDelegate(
                    typeof(Func<ElementId, long>), null, typeof(ElementId).GetProperty("Value").GetMethod);

            return getIdValueDelegate(id);
        }

        public static ElementId IdByLong(long id) => IdByLong2024(id);
        private static ElementId IdByLong2024(long id)
        {
            var param = Expression.Parameter(typeof(long), "id");
            var ci = typeof(ElementId).GetConstructor(new[] { typeof(long) });
            var lambda = Expression.Lambda<Func<long, ElementId>>(
                Expression.New(ci, param), param);
            var idByLongFunc = lambda.Compile();
            return idByLongFunc(id);
        }

#elif REVIT2023
        public static string RevitVersion => "2023";
        public static long GetIdValue(ElementId id)
        {
            if (id == null)
                return -1L;

            return GetIdValue2023(id);
        }
        private static long GetIdValue2023(ElementId id) => id.IntegerValue;

        public static ElementId IdByLong(long id) => IdByLong2023(id);
        private static ElementId IdByLong2023(long id) => new ElementId((int)id);

#endif
    }
}
