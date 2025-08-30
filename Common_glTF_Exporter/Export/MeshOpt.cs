using Common_glTF_Exporter.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Common_glTF_Exporter.Export
{
    public static class MeshOpt
    {
        public static void Compress()
        {
            try
            {
                ExportLog.Write("Starting MeshOpt Compression");

                string fileToCompress = Path.Combine(Exporter.exportOptions.TempDirectory, Exporter.exportOptions.GlbFileName);
                string fileToCompressTemp = Path.Combine(Exporter.exportOptions.TempDirectory, "Temp.glb");
                string reportPath = Path.Combine(Exporter.exportOptions.TempDirectory, "meshopt_report.txt");

                Gltf.GltfSettings settings = Gltf.GltfSettings.defaults();

                Gltf.GltfPack.gltfpack(fileToCompress, fileToCompressTemp, reportPath, settings);

                if (File.Exists(fileToCompressTemp))
                {
                    File.Delete(fileToCompress);
                    File.Move(fileToCompressTemp, fileToCompress);
                    ExportLog.Write("MeshOpt compression completed successfully");
                }
                else
                {
                    ExportLog.Write("MeshOpt compression was not successful");
                }
            }
            catch (Exception ex)
            {
                ExportLog.Write("MeshOpt compression failed.");
                ExportLog.WriteException(ex);
            }
        }
    }
}