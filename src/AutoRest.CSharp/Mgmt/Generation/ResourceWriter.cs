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
            writer.UseNamespaces(new string[] { "Azure.ResourceManager.Core" });

            var cs = resource.Type;

            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(resource.Description);
                using (writer.Scope($"{resource.Declaration.Accessibility} class {cs.Name} : {cs.Name}Operations"))
                {
                    // Write Data property
                    WriteConstrcutors(writer, resource);
                    WriteDataProperty(writer, resource);
                }
            }
        }

        private void WriteConstrcutors(CodeWriter writer, Resource resource)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{resource.Type.Name}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            writer.WriteXmlDocumentationParameter("resource", "The resource that is the target of operations.");
            // todo: should not hard code logic of how Data class is named here
            using (writer.Scope($"internal {resource.Type.Name}(ResourceOperationsBase options, {resource.Type.Name}Data resource) : base(options, resource.Id)"))
            {
                writer.Line($"Data = resource;");
            }
        }

        private void WriteDataProperty(CodeWriter writer, Resource resource)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Gets or sets the availability set data.");
            // todo: should not hard code logic of how Data class is named here
            writer.LineRaw($"public {resource.Type.Name}Data Data {{ get; private set; }}");
        }
    }
}
