// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class PolymorphicResourceWriter : ResourceWriter
    {
        private Resource This { get; }
        private BaseResource BaseResource { get; }
        public PolymorphicResourceWriter(CodeWriter writer, Resource resource) : base(writer, resource)
        {
            This = resource;
            Debug.Assert(resource.BaseResource != null);
            BaseResource = resource.BaseResource;
        }

        protected override void WriteCtors()
        {
            if (This.IsStatic)
                return;

            if (This.MockingCtor is not null)
            {
                _writer.WriteMethodDocumentation(This.MockingCtor);
                using (_writer.WriteMethodDeclaration(This.MockingCtor))
                {
                }
            }

            _writer.Line();
            if (This.ResourceDataCtor is not null)
            {
                _writer.WriteMethodDocumentation(This.ResourceDataCtor);
                using (_writer.WriteMethodDeclaration(This.ResourceDataCtor))
                {
                }
            }

            _writer.Line();
            if (This.ArmClientCtor is not null)
            {
                _writer.Line();
                _writer.WriteMethodDocumentation(This.ArmClientCtor);
                using (_writer.WriteMethodDeclaration(This.ArmClientCtor))
                {
                    foreach (var param in This.ExtraConstructorParameters)
                    {
                        _writer.Line($"_{param.Name} = {param.Name};");
                    }

                    foreach (var set in This.UniqueSets)
                    {
                        WriteRestClientConstructorPair(set.RestClient, set.Resource);
                    }
                    if (This.CanValidateResourceType)
                        WriteDebugValidate();
                }
            }
            _writer.Line();
        }

        protected override void WriteProperties()
        {
            // TODO -- use the actual extensible enum
            _writer.LineRaw("// TODO -- change it to the real extensible enum discriminator");
            _writer.Line($"protected override string Type => \"{This.Type.Name}\";");
            _writer.Line();

            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
            _writer.Line();

            WriteStaticValidate($"ResourceType");
        }

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            // check if this operation is included in one of the common operation
            var commonOperation = BaseResource.CommonOperations.FirstOrDefault(operation => operation.Contains(clientOperation));
            if (commonOperation == null)
            {
                base.WriteMethod(clientOperation, isAsync);
            }
            else
            {
                // this method writes two methods
                // first is the override of the abstract Core method
                // the other is the non-virtual actual method which calls the Core method and wrap the result again
                WritePolymorphicMethod(clientOperation, commonOperation, isAsync);
            }
        }

        private void WritePolymorphicMethod(MgmtClientOperation clientOperation, MgmtCommonOperation commonOperation, bool isAsync)
        {
            // write the implementation into the Core method instead
            var writeBody = GetMethodDelegate(clientOperation);
            var coreSignature = commonOperation.CoreMethodSignature with
            {
                Modifiers = MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override
            };
            using (WriteCommonMethodWithoutValidation(coreSignature, null, isAsync))
            {
                var diagnostic = new Diagnostic($"{This.Type.Name}.{clientOperation.Name}", Array.Empty<DiagnosticAttribute>());
                writeBody(clientOperation, diagnostic, isAsync);
            }

            _writer.Line();

            var signature = clientOperation.MethodSignature with
            {
                Modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.New
            };
            var returnsDescription = clientOperation.ReturnsDescription?.Invoke(isAsync);
            using (WriteCommonMethodWithoutValidation(signature, returnsDescription, isAsync, enableAttributes: true, attributes: new[] { new ForwardsClientCallsAttribute() }))
            {
                var value = new CodeWriterDeclaration("value");
                _writer.Append($"var {value:D} = ")
                    .AppendRawIf("await ", isAsync)
                    .Append($"{CreateMethodName(coreSignature.Name, isAsync)}(");
                foreach (var parameter in coreSignature.Parameters)
                {
                    _writer.AppendRaw(parameter.Name).AppendRaw(",");
                }
                _writer.RemoveTrailingComma();
                _writer.LineRaw(");");

                if (commonOperation.ReturnType.Equals(clientOperation.ReturnType))
                {
                    _writer.Line($"return {value};");
                }
                else
                {
                    // unwrap the result and wrap it again
                    if (clientOperation.IsLongRunningOperation)
                    {
                        _writer.Line($"TODO");
                    }
                    else if (clientOperation.IsPagingOperation)
                    {
                        _writer.Line($"TODO");
                    }
                    else
                    {
                        _writer.Line($"return {typeof(Response)}.FromValue(({clientOperation.ReturnType.UnWrapResponse()}){value}.Value, {value}.GetRawResponse());");
                    }
                }
            }

            _writer.Line();
        }
    }
}
