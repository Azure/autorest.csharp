// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceExtensionWriter : MgmtExtensionWriter
    {
        protected override string Description => "An internal class to add extension methods to.";

        protected override string ExtensionOperationVariableName => "this";

        protected override string Accessibility => "internal";

        protected override string ArmClientReference => "ArmClient";

        protected override bool UseRestClientField => false;

        public ResourceExtensionWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context, Type extensionType)
            : base(writer, extensions, context, extensionType)
        {
        }

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} partial class {TypeNameOfThis} : {typeof(ArmResource)}"))
                {
                    WriteFields(_writer, This.RestClients, true, false);
                    _writer.Line();

                    WriteProviderDefaultNamespace(_writer);
                    _writer.Line();

                    WriteCtor();
                    _writer.Line();

                    WriteProperties();
                    _writer.Line();

                    WritePrivateHelpers();

                    var resourcesWithGetAllAsGenericMethod = new HashSet<Resource>();
                    // Write other orphan operations with the parent of ResourceGroup
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        WriteMethod(clientOperation, true);
                        WriteMethod(clientOperation, false);

                        // we only check if a resource needs a GetByName method when it has a List operation in the subscription extension.
                        // If its parent is Subscription, we will have a GetCollection method of that resource, which contains a GetAllAsGenericResource serves the same purpose.
                        if (CheckGetAllAsGenericMethod(clientOperation, out var resource))
                        {
                            // in case that a resource has multiple list methods at the subscription level (for instance one ListBySusbcription and one ListByLocation, location is not an available parent therefore it will show up here)
                            if (resourcesWithGetAllAsGenericMethod.Contains(resource))
                                continue;
                            WriteGetAllResourcesAsGenericMethod(resource, true);
                            WriteGetAllResourcesAsGenericMethod(resource, false);
                            resourcesWithGetAllAsGenericMethod.Add(resource);
                        }
                    }
                }
            }
        }

        private void WritePrivateHelpers()
        {
            using (_writer.Scope($"private string GetApiVersionOrNull({typeof(ResourceType)} resourceType)"))
            {
                _writer.Line($"ArmClient.TryGetApiVersion(resourceType, out string apiVersion);");
                _writer.Line($"return apiVersion;");
            }
        }

        private void WriteProperties()
        {
            foreach (var client in This.RestClients)
            {
                string diagOptionsCtor = ConstructClientDiagnostic(_writer, client.Resource?.ResourceName, DiagnosticOptionsProperty);
                _writer.Line($"private {typeof(ClientDiagnostics)} {GetClientDiagnosticsPropertyName(client)} => {GetClientDiagnosticFieldName(client)} ??= {diagOptionsCtor};");
                string apiVersionString = client.Resource == null ? string.Empty : $", GetApiVersionOrNull({client.Resource.ResourceName}.ResourceType)";
                string restCtor = GetRestConstructorString("new ", client, GetClientDiagnosticsPropertyName(client), PipelineProperty, DiagnosticOptionsProperty, ", Id.SubscriptionId", "BaseUri", apiVersionString);
                _writer.Line($"private {client.Type} {GetRestPropertyName(client)} => {GetRestFieldName(client)} ??= {restCtor};");
            }
        }

        private void WriteCtor()
        {
            // write "armClient + id" constructor
            var clientOptionsConstructor = new MethodSignature(
                name: TypeOfThis.Name,
                description: $"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class.",
                modifiers: "internal",
                parameters: new[] { Resource.ArmClientParameter, Resource.ResourceIdentifierParameter },
                baseMethod: new MethodSignature(
                    name: TypeOfThis.Name,
                    description: null,
                    modifiers: "protected",
                    parameters: new[] { Resource.ArmClientParameter, Resource.ResourceIdentifierParameter })
                );

            _writer.WriteMethodDocumentation(clientOptionsConstructor);
            using (_writer.WriteMethodDeclaration(clientOptionsConstructor))
            {
            }
        }

        private void WriteGetAllResourcesAsGenericMethod(Resource resource, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {resource.ResourceName.LastWordToPlural()} for a <see cref=\"{typeof(Subscription)}\" /> represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = typeof(GenericResource).WrapPageable(async);
            using (_writer.Scope($"public {responseType} {CreateMethodName($"Get{resource.Type.Name.ResourceNameToPlural()}AsGenericResources", async)}({typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                var filters = new CodeWriterDeclaration("filters");
                _writer.Line($"{typeof(ResourceFilterCollection)} {filters:D} = new({resource.Type}.ResourceType);");
                _writer.Line($"{filters}.SubstringFilter = filter;");
                _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}(ArmClient.GetSubscription(Id), {filters}, expand, top, cancellationToken);");
            }
        }
    }
}
