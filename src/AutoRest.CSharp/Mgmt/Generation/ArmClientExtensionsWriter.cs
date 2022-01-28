// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmClientExtensionsWriter : MgmtExtensionWriter
    {
        private MgmtExtensions This { get; }

        public ArmClientExtensionsWriter(MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context)
            : base(extensions, context)
        {
            This = extensions;
        }

        public override void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
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
