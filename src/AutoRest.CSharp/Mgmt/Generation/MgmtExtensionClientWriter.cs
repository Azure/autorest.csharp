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
    internal sealed class MgmtExtensionClientWriter : MgmtClientBaseWriter
    {
        protected override bool UseField => false;

        private MgmtExtensionClient This { get; }

        public MgmtExtensionClientWriter(MgmtExtensionClient extensions)
            : base(new CodeWriter(), extensions)
        {
            This = extensions;
        }

        protected override void WritePrivateHelpers()
        {
            _writer.Line();
            using (_writer.Scope($"private string GetApiVersionOrNull({typeof(ResourceType)} resourceType)"))
            {
                _writer.Line($"TryGetApiVersion(resourceType, out string apiVersion);");
                _writer.Line($"return apiVersion;");
            }
        }

        protected override void WriteProperties()
        {
            _writer.Line();
            foreach (var set in This.UniqueSets)
            {
                WriterPropertySet(set.RestClient, set.Resource);
            }
        }

        private void WriterPropertySet(MgmtRestClient client, Resource? resource)
        {
            var resourceTypeExpression = ConstructResourceTypeExpression(resource);
            var diagPropertyName = GetDiagnosticsPropertyName(client, resource);
            FormattableString diagOptionsCtor = ConstructClientDiagnostic(_writer, GetProviderNamespaceFromReturnType(resourceTypeExpression), DiagnosticsProperty);
            _writer.Line($"private {typeof(ClientDiagnostics)} {diagPropertyName} => {GetDiagnosticFieldName(client, resource)} ??= {diagOptionsCtor};");
            var apiVersionExpression = resourceTypeExpression == null ? null : (FormattableString)$"GetApiVersionOrNull({resourceTypeExpression})";
            var restCtor = GetRestConstructorString(client, apiVersionExpression);
            _writer.Line($"private {client.Type} {GetRestPropertyName(client, resource)} => {GetRestFieldName(client, resource)} ??= {restCtor};");
        }
    }
}
