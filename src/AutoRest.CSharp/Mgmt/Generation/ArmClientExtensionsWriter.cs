// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ArmClientExtensionsWriter : MgmtExtensionWriter
    {
        private MgmtExtensions This { get; }

        public ArmClientExtensionsWriter(MgmtExtensions extensions)
            : base(extensions)
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
                    foreach (var resource in MgmtContext.Library.ArmResources)
                    {
                        _writer.Line($"#region {resource.Type.Name}");
                        WriteGetResourceFromIdMethod(resource);
                        _writer.LineRaw("#endregion");
                        _writer.Line();
                    }
                }
            }
        }

        protected void WriteGetResourceFromIdMethod(Resource resource)
        {
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it but with no data.");
            if (!IsArmCore)
            {
                _writer.WriteXmlDocumentationParameter($"{This.ExtensionParameter.Name}", $"The <see cref=\"{This.ExtensionParameter.Type}\" /> instance the method will execute against.");
            }
            _writer.WriteXmlDocumentationParameter("id", $"The resource ID of the resource to get.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {This.ExtensionParameter.Type.Name} {This.ExtensionParameter.Name}, ";
            using (_writer.Scope($"public {modifier} {resource.Type} Get{resource.Type.Name}({instanceParameter}{typeof(Azure.Core.ResourceIdentifier)} id)"))
            {
                if (!IsArmCore)
                {
                    using (_writer.Scope($"return {This.ExtensionParameter.Name}.GetClient<{resource.Type}>(() =>"))
                    {
                        WriteGetter(resource, $"{ArmClientReference.ToVariableName()}");
                    }
                    _writer.Line($");");
                }
                else
                {
                    WriteGetter(resource, "this");
                }
            }
        }

        private void WriteGetter(Resource resource, string armVariable)
        {
            _writer.Line($"{resource.Type.Name}.ValidateResourceId(id);");
            _writer.Line($"return new {resource.Type.Name}({armVariable}, id);");
        }
    }
}
