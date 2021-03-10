// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Arm;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ArmResourceWriter
    {
        public void WriteResource(CodeWriter writer, ArmResource resource)
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
