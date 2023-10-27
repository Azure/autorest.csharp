// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal sealed class ArmClientExtensionWriter : MgmtExtensionWriter
    {
        private ArmClientExtension This { get; }

        public ArmClientExtensionWriter(ArmClientExtension extension) : this(new CodeWriter(), extension)
        {
        }

        public ArmClientExtensionWriter(CodeWriter writer, ArmClientExtension extension) : base(writer, extension)
        {
            This = extension;
        }

        protected internal override void WriteImplementations()
        {
            base.WriteImplementations();

            foreach (var method in This.ArmResourceMethods)
            {
                _writer.WriteMethodDocumentation(method.Signature);
                _writer.WriteMethod(method);
            }
        }

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            using (_writer.WriteCommonMethod(clientOperation.MethodSignature, null, isAsync, This.Accessibility == "public", SkipParameterValidation))
            {
                WriteMethodBodyWrapper(clientOperation.MethodSignature, isAsync, clientOperation.IsPagingOperation);
            }
            _writer.Line();
        }

        private void WriteGetResourceFromIdMethod(Resource resource)
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
            using (_writer.Scope($"public {modifier} {resource.Type} Get{resource.Type.Name}({instanceParameter}{typeof(ResourceIdentifier)} id)"))
            {
                if (!IsArmCore)
                {
                    _writer.AppendRaw("return ")
                        .Append($"{This.MockableExtension.FactoryMethodName}({This.ExtensionParameter.Name}).Get{resource.Type.Name}(id);");
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
