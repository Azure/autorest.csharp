// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class OldArmClientExtensionsWriter : OldMgmtExtensionWriter
    {
        private OldMgmtExtensions This { get; }

        public OldArmClientExtensionsWriter(ArmClientExtensions extensions) : this(new CodeWriter(), extensions)
        {
        }

        public OldArmClientExtensionsWriter(CodeWriter writer, ArmClientExtensions extensions) : base(writer, extensions)
        {
            This = extensions;
        }

        protected internal override void WriteImplementations()
        {
            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                _writer.Line($"#region {resource.Type.Name}");
                WriteGetResourceFromIdMethod(resource);
                _writer.LineRaw("#endregion");
                _writer.Line();
            }
        }

        protected void WriteGetResourceFromIdMethod(Resource resource)
        {
            List<FormattableString> lines = new List<FormattableString>();
            string an = resource.Type.Name.StartsWithVowel() ? "an" : "a";
            lines.Add($"Gets an object representing {an} <see cref=\"{resource.Type}\" /> along with the instance operations that can be performed on it but with no data.");
            lines.Add($"You can use <see cref=\"{resource.Type}.CreateResourceIdentifier\" /> to create {an} <see cref=\"{resource.Type}\" /> <see cref=\"{typeof(ResourceIdentifier)}\" /> from its components.");
            _writer.WriteXmlDocumentationSummary(FormattableStringHelpers.Join(lines, "\r\n"));
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
                    using (_writer.Scope($"return {This.ExtensionParameter.Name}.GetResourceClient<{resource.Type}>(() =>"))
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
