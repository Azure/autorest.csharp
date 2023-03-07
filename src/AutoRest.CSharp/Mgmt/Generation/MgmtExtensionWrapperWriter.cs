// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
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

            var generalExtensionParametr = new Parameter(
                "resource",
                null,
                typeof(ArmResource),
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
                    new[] { generalExtensionParametr });
                using (_writer.WriteMethodDeclaration(extensionClientSignature))
                {
                    using (_writer.Scope($"return {generalExtensionParametr.Name}.GetCachedClient(({ArmClientReference.ToVariableName()}) =>"))
                    {
                        _writer.Line($"return new {extensionClientSignature.ReturnType}({ArmClientReference.ToVariableName()}, {generalExtensionParametr.Name}.Id);");
                    }
                    _writer.Line($");");
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
