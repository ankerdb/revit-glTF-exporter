using System;
using System.Collections.Generic;
using System.IO;
using Common_glTF_Exporter.Utils;
using dracowrapper;

namespace Common_glTF_Exporter.Export
{
    public static class Draco
    {
        public static void Compress()
        {
            try
            {
                ExportLog.Write("Starting Draco Compression");

                List<string> files = new List<string>();
                string fileToCompress = Path.Combine(Exporter.exportOptions.TempDirectory, Exporter.exportOptions.GlbFileName);
                string fileToCompressTemp = Path.Combine(Exporter.exportOptions.TempDirectory, "Temp.glb");
                files.Add(fileToCompress);

                // Use unified Draco_transcoder approach with original default settings
                var decoder = new GltfDecoder();
                var res = decoder.DecodeFromFileToScene(fileToCompress);
                var scene = res.Value();

                DracoCompressionOptions options = new DracoCompressionOptions();

                SceneUtils.SetDracoCompressionOptions(options, scene);

                var encoder = new GltfEncoder();
                encoder.EncodeSceneToFile(scene, fileToCompressTemp);

                // Replace original file with compressed version
                files.ForEach(x => File.Delete(x));
                File.Move(fileToCompressTemp, fileToCompress);
                ExportLog.Write("Draco Compression finished");
            }
            catch (Exception ex)
            {
                ExportLog.Write("Draco Compression failed");
                ExportLog.WriteException(ex);
            }
        }
    }
}