using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common_glTF_Exporter.Core;

namespace Common_glTF_Exporter.Export
{
    internal class GlbFile
    {
        public static void Create(List<GLTFBinaryData> binaryFileData, string json)
        {
            byte[] jsonChunk = GlbJsonInfo.Get(json);
            int lenggg = jsonChunk.Length;
            byte[] binChunk = GlbBinInfo.Get(binaryFileData);
            byte[] headerChunk = GlbHeaderInfo.Get(jsonChunk, binChunk);

            string fileDirectory = Path.Combine(Exporter.exportOptions.TempDirectory, Exporter.exportOptions.GlbFileName);
            byte[] exportArray = headerChunk.Concat(jsonChunk).Concat(binChunk).ToArray();

            File.WriteAllBytes(fileDirectory, exportArray);
        }
    }
}
