// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation, MgmtConfiguration config)
        {
            writer.UseNamespace(typeof(Task).Namespace!);

            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name} : ResourceOperationsBase<{resourceOperation.ResourceIdentifierType}, {resourceOperation.ResourceName}>"))
                {
                    WriteClientCtors(writer, resourceOperation);
                    WriteClientProperties(writer, resourceOperation, config);
                    WriteClientMethods(writer, resourceOperation);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation)
        {
            var typeOfThis = resourceOperation.Type.Name;

            // write "generic resource" constructor
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis:D}\"/> class.");
            writer.WriteXmlDocumentationParameter("genericOperations", @"An instance of <see cref=""GenericResourceOperations""/> that has an id for a {todo: availability set}.");
            using (writer.Scope($"internal {typeOfThis:D}({typeof(GenericResourceOperations)} genericOperations) : base(genericOperations, genericOperations.Id)"))
            { }

            // write "resource + id" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis:D}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations."); //todo: revise
            writer.WriteXmlDocumentationParameter("id", "The identifier of the resource that is the target of operations.");
            using (writer.Scope($"protected {typeOfThis:D}(ResourceOperationsBase options, {typeof(ResourceIdentifier)} id) : base(options, id)"))
            {
            }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation, MgmtConfiguration config)
        {
            writer.Line();
            writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{resourceOperation.OperationGroup.ResourceType(config)}\";");
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
