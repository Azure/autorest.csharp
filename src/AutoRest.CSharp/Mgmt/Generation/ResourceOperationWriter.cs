// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation)
        {
            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name} : ResourceOperationsBase<{resourceOperation.ResourceIdentifierType}, {resourceOperation.ResourceName}>"))
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

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of <see cref = \"{resourceOperation.Type.Name}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            writer.WriteXmlDocumentationParameter("id", "The identifier of the resource that is the target of operations.");
            using (writer.Scope($"protected {resourceOperation.Type.Name:D}({typeof(ResourceOperationsBase)} options, {resourceOperation.ResourceIdentifierType} id) : base(options, id)"))
            {

            }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.Line($"private static readonly {typeof(ResourceType)} ResourceType = \"{resourceOperation.Type.Namespace}/{resourceOperation.Type.Name}\";");
            writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => ResourceType;");
            }

        private void WriteClientMethods(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override {typeof(ArmResponse)}<{resourceOperation.ResourceName}> Get({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override Task<ArmResponse<{resourceOperation.ResourceName}>> GetAsync({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new {typeof(NotImplementedException)}();");
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("A collection of location that may take multiple service requests to iterate over.");
            using (writer.Scope($"public {typeof(IEnumerable<LocationData>)} ListAvailableLocations({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return ListAvailableLocations(ResourceType);");
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("An async collection of location that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationException(typeof(InvalidOperationException), "The default subscription id is null.");
            using (writer.Scope($"public async {typeof(Task<IEnumerable<LocationData>>)} ListAvailableLocationsAsync({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return await ListAvailableLocationsAsync(ResourceType, cancellationToken);");
            }
            writer.Line();
        }
    }
}
