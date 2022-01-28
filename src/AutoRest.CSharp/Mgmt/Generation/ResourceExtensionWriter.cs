// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceExtensionWriter : MgmtClientBaseWriter
    {
        protected string ExtensionOperationVariableName => "this";

        protected override string ArmClientReference => "ArmClient";

        protected override bool UseRestClientField => false;

        private MgmtExtensionClient This { get; }

        public ResourceExtensionWriter(MgmtExtensionClient extensions, BuildContext<MgmtOutputLibrary> context)
            : base(new CodeWriter(), extensions, context)
        {
            This = extensions;
        }

        protected override void WritePrivateHelpers()
        {
            using (_writer.Scope($"private string GetApiVersionOrNull({typeof(ResourceType)} resourceType)"))
            {
                _writer.Line($"{ArmClientReference}.TryGetApiVersion(resourceType, out string apiVersion);");
                _writer.Line($"return apiVersion;");
            }
        }

        protected override void WriteProperties()
        {
            foreach (var set in This.UniqueSets)
            {
                WriterPropertySet(set.RestClient, set.Resource);
            }
        }

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            // we should never have a branch in the operations in an extension class, therefore throwing an exception here
            throw new InvalidOperationException();
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

        // private void WriteGetAllResourcesAsGenericMethod(Resource resource, bool async)
        // {
        //     _writer.Line();
        //     _writer.WriteXmlDocumentationSummary($"Filters the list of {resource.ResourceName.LastWordToPlural()} for a <see cref=\"{typeof(Subscription)}\" /> represented as generic resources.");
        //     _writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
        //     _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
        //     _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
        //     _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
        //     _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

        //     var responseType = typeof(GenericResource).WrapPageable(async);
        //     using (_writer.Scope($"public {responseType} {CreateMethodName($"Get{resource.Type.Name.ResourceNameToPlural()}AsGenericResources", async)}({typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
        //     {
        //         var filters = new CodeWriterDeclaration("filters");
        //         _writer.Line($"{typeof(ResourceFilterCollection)} {filters:D} = new({resource.Type}.ResourceType);");
        //         _writer.Line($"{filters}.SubstringFilter = filter;");
        //         _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}({ArmClientReference}.GetSubscription(Id), {filters}, expand, top, cancellationToken);");
        //     }
        // }

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
