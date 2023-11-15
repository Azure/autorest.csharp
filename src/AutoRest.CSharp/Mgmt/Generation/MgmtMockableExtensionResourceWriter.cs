// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtMockableExtensionResourceWriter : MgmtClientBaseWriter
    {
        public static MgmtMockableExtensionResourceWriter GetWriter(MgmtMockableExtension extensionClient, IEnumerable<Resource> armResources) => extensionClient switch
        {
            MgmtMockableArmClient armClientExtensionClient => new ArmClientMockingExtensionWriter(armClientExtensionClient, armResources),
            _ => new MgmtMockableExtensionResourceWriter(extensionClient, armResources)
        };

        protected override bool UseField => false;

        private MgmtMockableExtension This { get; }

        public MgmtMockableExtensionResourceWriter(MgmtMockableExtension extensions, IEnumerable<Resource> armResources) : base(new CodeWriter(), extensions, armResources)
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
            _writer.Line($"private {Configuration.ApiTypes.ClientDiagnosticsType} {diagPropertyName} => {GetDiagnosticFieldName(client, resource)} ??= {diagOptionsCtor};");
            var apiVersionExpression = resourceTypeExpression == null ? null : (FormattableString)$"GetApiVersionOrNull({resourceTypeExpression})";
            var restCtor = GetRestConstructorString(client, apiVersionExpression);
            _writer.Line($"private {client.Type} {GetRestPropertyName(client, resource)} => {GetRestFieldName(client, resource)} ??= {restCtor};");
        }
    }
}
