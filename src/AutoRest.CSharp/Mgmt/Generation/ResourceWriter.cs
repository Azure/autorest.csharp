// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter
    {
        public void WriteResource(CodeWriter writer, Resource resource)
        {
            var cs = resource.Type;

            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(resource.Description);
                using (writer.Scope($"{resource.Declaration.Accessibility} class {cs.Name} : {cs.Name}Operations"))
                {
                    // Write Data property
                }
            }
        }
    }
}
