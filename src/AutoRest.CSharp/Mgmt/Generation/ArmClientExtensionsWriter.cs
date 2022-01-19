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
        public ArmClientExtensionsWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context, bool isArmCore = false) : base(writer, extensions, context, isArmCore)
        {
        }
        protected override string Description => IsArmCore ? "The entry point for all ARM clients." : "A class to add extension methods to ArmClient.";
        protected override string ExtensionOperationVariableName => IsArmCore ? "this" : "armClient";

        protected override Type ExtensionOperationVariableType => typeof(ArmClient);

        public override void Write()
        {
            var theNamespace = IsArmCore ? "Azure.ResourceManager" : Context.DefaultNamespace;
            var staticKeyWord = IsArmCore ? string.Empty : "static ";
            var className = IsArmCore ? nameof(ArmClient) : TypeNameOfThis;
            using (_writer.Namespace(theNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} {staticKeyWord}partial class {className}"))
                {
                    foreach (var resource in Context.Library.ArmResources)
                    {
                        _writer.Line($"#region {resource.Type.Name}");
                        WriteGetResourceFromIdMethod(_writer, resource);
                        _writer.LineRaw("#endregion");
                        _writer.Line();
                    }
                }
            }
        }

        protected void WriteGetResourceFromIdMethod(CodeWriter writer, Resource resource)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it but with no data.");
            if (!IsArmCore)
            {
                writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            }
            writer.WriteXmlDocumentationParameter("id", $"The resource ID of the resource to get.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ";
            using (writer.Scope($"public {modifier} {resource.Type} Get{resource.Type.Name}({instanceParameter}{typeof(Azure.Core.ResourceIdentifier)} id)"))
            {
                writer.Line($"{resource.Type.Name}.ValidateResourceId(id);");
                writer.Line($"return new {resource.Type.Name}({ContextProperty}, id);");
            }
        }
    }
}
