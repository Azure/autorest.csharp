// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceContainerWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteContainer(CodeWriter writer, ResourceContainer resourceContainer)
        {
            var cs = resourceContainer.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceContainer.Description);
                using (writer.Scope($"{resourceContainer.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteContainerCtors(writer, resourceContainer);

                    WriteContainerProperties(writer, resourceContainer);
                }
            }
        }

        private void WriteContainerCtors(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {resourceContainer.Type.Name} for mocking.");
            using (writer.Scope($"protected {resourceContainer.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private void WriteContainerProperties(CodeWriter writer, ResourceContainer resourceContainer)
        {
            var resourceType = resourceContainer.GetValidResourceValue();

            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            if (!resourceType.Contains(".ResourceType"))
            {
                resourceType = $"\"{resourceType}\"";
            }

            writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
            writer.Line($"protected {typeof(ResourceType)} ValidResourceType => {resourceType};");
        }
    }
}
