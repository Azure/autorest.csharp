// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmClientExtensionsWriter : MgmtExtensionWriter
    {
        public ArmClientExtensionsWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context) : base(writer, extensions, context)
        {
        }

        protected override string Description => "A class to add extension methods to ArmClient.";
        protected override string ExtensionOperationVariableName => "armClient";

        protected override Type ExtensionOperationVariableType => typeof(ArmClient);

        protected override TypeProvider This => _extensions;

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in Context.Library.ArmResources)
                    {
                        _writer.Line($"#region {resource.Type.Name}");
                        WriteExtensionGetResourceFromIdMethod(_writer, resource);
                        _writer.LineRaw("#endregion");
                        _writer.Line();
                    }

                }
            }
        }

        protected void WriteExtensionGetResourceFromIdMethod(CodeWriter writer, Resource resource)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it but with no data.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationParameter("id", $"The resource ID of the resource to get.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (writer.Scope($"public static {resource.Type} Get{resource.Type.Name}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, {typeof(ResourceIdentifier)} id)"))
            {
                writer.Line($"return {ExtensionOperationVariableName}.UseClientContext((uri, credential, clientOptions, pipeline) => new {resource.Type.Name}(clientOptions, credential, uri, pipeline, id));");
            }
        }
    }
}
