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
                    var uniqueSets = WriteFields(_writer, _extensions.ClientOperations, false);
                    _writer.Line();

                    WriteCtor();
                    _writer.Line();

                    WriteProperties(uniqueSets);
                    _writer.Line();

                    WritePrivateHelpers();
                    _writer.Line();

                    WriteChildResourceEntries(true);

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
                _writer.Line($"{ArmClientReference}.TryGetApiVersion(resourceType, out string apiVersion);");
                _writer.Line($"return apiVersion;");
            }
        }

        private void WriteProperties(HashSet<NameSetKey> uniqueSets)
        {
            foreach (var set in uniqueSets)
            {
                WriterPropertySet(set.RestClient, set.Resource);
            }
        }

        private void WriterPropertySet(MgmtRestClient client, Resource? resource)
        {
            string? resourceName = resource?.Type.Name;
            string diagPropertyName = GetClientDiagnosticsPropertyName(client, resource);
            FormattableString diagOptionsCtor = ConstructClientDiagnostic(_writer, GetProviderNamespaceFromReturnType(resourceName), DiagnosticOptionsProperty);
            _writer.Line($"private {typeof(ClientDiagnostics)} {diagPropertyName} => {GetClientDiagnosticFieldName(client, resource)} ??= {diagOptionsCtor};");
            string apiVersionString = resourceName == null ? string.Empty : $", GetApiVersionOrNull({resourceName}.ResourceType)";
            string restCtor = GetRestConstructorString(client, diagPropertyName, apiVersionString);
            _writer.Line($"private {client.Type} {GetRestPropertyName(client, resource)} => {GetRestFieldName(client, resource)} ??= {restCtor};");
        }

        private void WriteCtor()
        {
            // write "armClient + id" constructor
            var clientOptionsConstructor = new ConstructorSignature(
                Name: TypeOfThis.Name,
                Description: $"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class.",
                Modifiers: "internal",
                Parameters: new[] { Resource.ArmClientParameter, Resource.ResourceIdentifierParameter },
                Initializer: new(
                    isBase: true,
                    arguments: new[] { Resource.ArmClientParameter, Resource.ResourceIdentifierParameter })
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
                _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}({ArmClientReference}.GetSubscription(Id), {filters}, expand, top, cancellationToken);");
            }
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceSuffix)
        {
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (_writer.Scope($"public virtual {resource.Type.Name} Get{resource.Type.Name}()"))
            {
                _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, new {typeof(Azure.Core.ResourceIdentifier)}(Id + \"/{singletonResourceSuffix}\"));");
            }
        }
    }
}
