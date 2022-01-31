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
        protected override bool UseField => false;

        private MgmtExtensionClient This { get; }

        public ResourceExtensionWriter(MgmtExtensionClient extensions, BuildContext<MgmtOutputLibrary> context)
            : base(new CodeWriter(), extensions, context)
        {
            This = extensions;
        }

        protected override void WritePrivateHelpers()
        {
            _writer.Line();
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

        private void WriterPropertySet(MgmtRestClient client, Resource? resource)
        {
            string? resourceName = resource?.Type.Name;
            string diagPropertyName = GetDiagnosticsPropertyName(client, resource);
            FormattableString diagOptionsCtor = ConstructClientDiagnostic(_writer, GetProviderNamespaceFromReturnType(resourceName), DiagnosticOptionsProperty);
            _writer.Line($"private {typeof(ClientDiagnostics)} {diagPropertyName} => {GetDiagnosticFieldName(client, resource)} ??= {diagOptionsCtor};");
            string apiVersionString = resourceName == null ? string.Empty : $", GetApiVersionOrNull({resourceName}.ResourceType)";
            string restCtor = GetRestConstructorString(client, diagPropertyName, apiVersionString);
            _writer.Line($"private {client.Type} {GetRestPropertyName(client, resource)} => {GetRestFieldName(client, resource)} ??= {restCtor};");
        }
    }
}
