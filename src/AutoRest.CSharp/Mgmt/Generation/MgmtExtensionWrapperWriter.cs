// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtExtensionWrapperWriter : MgmtClientBaseWriter
    {
        private MgmtExtensionWrapper This { get; }
        public MgmtExtensionWrapperWriter(MgmtExtensionWrapper extensionsWrapper) : base(new CodeWriter(), extensionsWrapper)
        {
            This = extensionsWrapper;
        }

        protected override void WritePrivateHelpers()
        {
            if (IsArmCore)
                return;

            var generalExtensionParameter = new Parameter(
                "resource",
                null,
                typeof(ArmResource),
                null,
                ValidationType.None,
                null);
            var armClientParameter = new Parameter(
                "client",
                null,
                typeof(ArmClient),
                null,
                ValidationType.None,
                null);
            var scopeParameter = new Parameter(
                "scope",
                null,
                typeof(ResourceIdentifier),
                null,
                ValidationType.None,
                null);
            foreach (var extensionClient in This.ExtensionClients)
            {
                if (extensionClient.IsEmpty)
                    continue;

                _writer.Line();

                var extensionClientSignature = new MethodSignature(
                    $"Get{extensionClient.Type.Name}",
                    null,
                    null,
                    Private | Static,
                    extensionClient.Type,
                    null,
                    new[] { generalExtensionParameter });
                using (_writer.WriteMethodDeclaration(extensionClientSignature))
                {
                    using (_writer.Scope($"return {generalExtensionParameter.Name}.GetCachedClient(client =>", newLine: false))
                    {
                        _writer.Line($"return new {extensionClientSignature.ReturnType}(client, {generalExtensionParameter.Name}.Id);");
                    }
                    _writer.LineRaw(");");
                }

                _writer.Line();

                var scopeExtensionClientSignature = new MethodSignature(
                    $"Get{extensionClient.Type.Name}",
                    null,
                    null,
                    Private | Static,
                    extensionClient.Type,
                    null,
                    new[] { armClientParameter, scopeParameter });
                using (_writer.WriteMethodDeclaration(scopeExtensionClientSignature))
                {
                    using (_writer.Scope($"return {armClientParameter.Name}.GetResourceClient(() => ", newLine: false))
                    {
                        _writer.Line($"return new {extensionClientSignature.ReturnType}({armClientParameter.Name}, {scopeParameter.Name});");
                    }
                    _writer.LineRaw(");");
                }
            }

            base.WritePrivateHelpers();
        }

        protected internal override void WriteImplementations()
        {
            WritePrivateHelpers();

            foreach (var extension in This.Extensions)
            {
                if (extension.IsEmpty)
                    continue;

                var extensionWriter = extension switch
                {
                    ArmClientExtension armClientExtension => new ArmClientExtensionWriter(_writer, armClientExtension),
                    _ when extension.ArmCoreType == typeof(ArmResource) => new ArmResourceExtensionWriter(_writer, extension),
                    _ => new MgmtExtensionWriter(_writer, extension)
                };
                extensionWriter.WriteImplementations();
                _writer.Line();
            }
        }
    }
}
