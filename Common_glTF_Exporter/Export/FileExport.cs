using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;
using Common_glTF_Exporter.Core;
using Newtonsoft.Json;
using Revit_glTF_Exporter;

namespace Common_glTF_Exporter.Export
{
    public static class FileExport
    {

        public static void Run(
            List<GLTFBufferView> bufferViews,
            List<GLTFBuffer> buffers,
            List<GLTFBinaryData> binaryFileData, List<GLTFScene> scenes,
            IndexedDictionary<GLTFNode> nodes,
            IndexedDictionary<GLTFMesh> meshes,
            IndexedDictionary<GLTFMaterial> materials,
            List<GLTFAccessor> accessors,
            List<GLTFTexture> textures,
            List<GLTFImage> images)
        {
            BufferConfig.Run(bufferViews, buffers);

            string gltfJson = GltfJson.Get(scenes, nodes.List, meshes.List, materials.List, buffers,
            bufferViews, accessors, textures, images);

            GlbFile.Create(binaryFileData, gltfJson);
        }
    }
}
