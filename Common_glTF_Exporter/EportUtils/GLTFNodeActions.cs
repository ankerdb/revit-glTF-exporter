using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using Revit_glTF_Exporter;
using Common_glTF_Exporter.Core;
using Common_glTF_Exporter.Utils;

namespace Common_glTF_Exporter.EportUtils
{
    public static class GLTFNodeActions
    {
        public static GLTFNode CreateGLTFNodeFromElement(Element currentElement)
        {
            // create a new node for the element
            GLTFNode newNode = new GLTFNode();
            newNode.name = Util.ElementDescription(currentElement);

            if (Preferences.Properties)
            {
                // get the extras for this element
                GLTFExtras extras = new GLTFExtras
                {
                    uniqueId = currentElement.UniqueId,
                    parameters = Util.GetElementParameters(currentElement, true)
                };

                if (currentElement.Category != null)
                {
                    extras.elementCategory = currentElement.Category.Name;
                }

                extras.elementId = CompUnits.GetIdValue(currentElement.Id);
                newNode.extras = extras;
            }

            return newNode;
        }
    }
}
