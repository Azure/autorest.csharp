// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter
    {
        public void WriteResource(CodeWriter writer, BuildContext<MgmtOutputLibrary> context, Resource resource)
        {
            using (writer.Namespace(resource.Type.Namespace))
            {
                var resourceOperation = context.Library.GetResourceOperation(resource.OperationGroup);
                writer.WriteXmlDocumentationSummary(resource.Description);
                using (writer.Scope($"{resource.Declaration.Accessibility} class {resource.Type.Name} : {resourceOperation.Type}"))
                {
                    var resourceData = context.Library.GetResourceData(resource.OperationGroup);
                    WriteConstructors(writer, context, resource, resourceData);
                    WriteDataProperty(writer, resource, resourceData);
                }
            }
        }

        private void WriteConstructors(CodeWriter writer, BuildContext<MgmtOutputLibrary> context, Resource resource, ResourceData resourceData)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{resource.Type.Name}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            writer.WriteXmlDocumentationParameter("resource", "The resource that is the target of operations.");
            // inherits the default constructor when it is not a resource
            var baseConstructor = context.Library.IsResource(resource.OperationGroup) ? " : base(options, resource.Id)" : string.Empty;
            using (writer.Scope($"internal {resource.Type.Name}({typeof(ResourceOperationsBase)} options, {resourceData.Type} resource){baseConstructor}"))
            {
            }
        }

        private void WriteDataProperty(CodeWriter writer, Resource resource, ResourceData resourceData)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Gets or sets the resource data.");
            writer.LineRaw($"public {resource.Type.Name} Data {{ get; private set; }}");
        }
    }
}
