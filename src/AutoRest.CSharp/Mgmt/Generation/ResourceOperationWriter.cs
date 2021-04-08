// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation)
        {
            string[] Libraries = { "System", "System.Collections.Generic", "System.Threading", "System.Threading.Tasks", "Azure.ResourceManager.Core" };
            foreach (string lib in Libraries)
            {
                writer.Line($"using {lib};");
            }
            writer.Line();

            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name} : ResourceOperationsBase<{resourceOperation.ResourceName}>"))
                {
                    WriteClientCtors(writer, resourceOperation);
                    WriteClientProperties(writer, resourceOperation);
                    WriteClientMethods(writer, resourceOperation);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {resourceOperation.Type.Name} for mocking.");
            using (writer.Scope($"protected {resourceOperation.Type.Name:D}()"))
            {

            }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.Line($"private static readonly ResourceType ResourceType = \"{resourceOperation.Type.Namespace}/{resourceOperation.Type.Name}\";");
            writer.Line($"protected override ResourceType ValidResourceType => ResourceType;");
            }

        private void WriteClientMethods(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override ArmResponse<{resourceOperation.ResourceName}> Get(CancellationToken cancellationToken = default)"))
            {
                writer.Line($"throw new NotImplementedException();");
            }

            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override Task<ArmResponse<{resourceOperation.ResourceName}>> GetAsync(CancellationToken cancellationToken = default)"))
            {
                writer.Line($"throw new NotImplementedException();");
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("A collection of location that may take multiple service requests to iterate over.");
            using (writer.Scope($"public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)"))
            {
                writer.Line($"return ListAvailableLocations(ResourceType);");
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("An async collection of location that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationException(typeof(InvalidOperationException), "The default subscription id is null.");
            using (writer.Scope($"public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)"))
            {
                writer.Line($"return await ListAvailableLocationsAsync(ResourceType, cancellationToken);");
            }
            writer.Line();
        }
    }
}
