// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class PolymorphicResourceWriter : ResourceWriter
    {
        private BaseResource BaseResource { get; }
        public PolymorphicResourceWriter(CodeWriter writer, Resource resource) : base(writer, resource)
        {
            Debug.Assert(resource.PolymorphicOption != null);
            BaseResource = resource.PolymorphicOption.BaseResource;
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
            // TODO -- use the actual extensible enum -- or do we still need that?
            //_writer.LineRaw("// TODO -- change it to the real extensible enum discriminator");
            //_writer.Line($"protected override string Type => \"{This.Type.Name}\";");
            //_writer.Line();

            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
            _writer.Line();

            WriteStaticValidate($"ResourceType");
        }

        private bool IsCommonOperation(MgmtClientOperation? clientOperation, [MaybeNullWhen(false)] out MgmtCommonOperation commonOperation)
        {
            if (clientOperation == null)
            {
                commonOperation = null;
                return false;
            }
            // check if this operation is included in one of the common operation
            commonOperation = BaseResource.CommonOperations.FirstOrDefault(operation => operation.Contains(clientOperation));
            return commonOperation != null;
        }

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            // check if this operation is included in one of the common operation
            if (IsCommonOperation(clientOperation, out var commonOperation))
            {
                // this method writes two methods
                // first is the override of the abstract Core method
                // the other is the non-virtual actual method which calls the Core method and wrap the result again
                WritePolymorphicMethod(clientOperation, commonOperation, isAsync);
            }
            else
            {
                base.WriteMethod(clientOperation, isAsync);
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
                _writer.WriteParametersValidation(coreSignature.Parameters);
                var diagnostic = new Diagnostic($"{This.Type.Name}.{clientOperation.Name}", Array.Empty<DiagnosticAttribute>());
                writeBody(new MgmtClientOperationWrapper(clientOperation, coreSignature.ReturnType!), diagnostic, isAsync);
            }

            _writer.Line();

            // TODO -- add a configuration to control whether we need this virtual keyword. And if this configuration is on, we will generate this method with the "new" keyword nevertheless (for backward compat purpose)
            var signature = clientOperation.MethodSignature with
            {
                Modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.New | MethodSignatureModifiers.Virtual
            };
            // if this method is exactly the same as the Core method, we just need to redirect - which is the same implementation as the base resource, we do not need to write anything here
            // we only write this when it is not the same, which is the case of returning a polymorphic resource as a generic parameter (wrapped in either Response, ArmOperation or Pageable)
            // when this happens we should unwrap it and wrap it again
            if (!commonOperation.ReturnType.Equals(clientOperation.ReturnType))
            {
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

                    // unwrap the result and wrap it again
                    if (clientOperation.IsLongRunningOperation)
                    {
                        WritePolymorphicLROResponse(value, clientOperation.ReturnType, clientOperation);
                    }
                    else if (clientOperation.IsPagingOperation)
                    {
                        // in paging operation, we should never have a polymorphic return type case
                        // in this case, this method should be returning "Pageable<MyselfResource>". This operation should always be on the collection class instead of being written here in the resource class.
                        // therefore for paging operation, we just return the value variable: it should always have the same type as the return type of this method
                        _writer.Line($"return {value};");
                    }
                    else
                    {
                        _writer.Line($"return {typeof(Response)}.FromValue(({clientOperation.ReturnType.UnWrapResponse()}){value}.Value, {value}.GetRawResponse());");
                    }
                }
            }

            _writer.Line();
        }

        private void WritePolymorphicLROResponse(CodeWriterDeclaration value, CSharpType returnType, MgmtClientOperation clientOperation)
        {
            // if we wait for completion in core, we do not have to wait again, just rewrap the lro object
            using (_writer.Scope($"if (waitUntil == {typeof(WaitUntil)}.Completed)"))
            {
                // in this path, the return type should always be generic, otherwise the return type would be exactly the same and we will not go into this path
                Debug.Assert(clientOperation.ReturnType.IsGenericType);
                _writer.Append($"return new {LibraryArmOperation}<{clientOperation.ReturnType.UnWrapOperation()}>(")
                    .Append($"{typeof(Response)}.FromValue(({clientOperation.ReturnType.UnWrapOperation()}){value}.Value, {value}.GetRawResponse())")
                .LineRaw(");");
            }

            Debug.Assert(clientOperation.OperationMappings.Count == 1);
            var branch = clientOperation.OperationMappings.Keys.First();
            var operation = clientOperation.OperationMappings[branch];
            var parameterMapping = clientOperation.ParameterMappings[branch];
            var operationSource = operation.OperationSource;

            if (operation.InterimOperation is not null)
            {
                _writer.Append($"var operation = new {operation.InterimOperation.TypeName}");
            }
            else
            {
                _writer.Append($"var operation = new {LibraryArmOperation}");
                if (returnType.IsGenericType)
                {
                    _writer.Append($"<{returnType.UnWrapOperation()}>");
                }
            }
            _writer.Append($"(");
            if (operationSource is not null)
            {
                _writer.Append($"new {operationSource.TypeName}(");
                if (operationSource.IsReturningResource)
                    _writer.Append($"{ArmClientReference}");
                _writer.Append($"), ");
            }

            _writer.Append($"{GetDiagnosticName(operation)}, {PipelineProperty}, {GetRestClientName(operation)}.{RequestWriterHelpers.CreateRequestMethodName(operation.Method.Name)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.RemoveTrailingComma();
            _writer.Append($").Request, {value}.GetRawResponse(), {typeof(OperationFinalStateVia)}.{operation.FinalStateVia!}");
            _writer.Line($");");

            _writer.LineRaw("return operation;");
        }

        protected override string GetUpdateMethodName()
        {
            if (IsCommonOperation(This.UpdateOperation, out var commonOperation))
            {
                return $"{base.GetUpdateMethodName()}Core";
            }
            else
            {
                return base.GetUpdateMethodName();
            }
        }
    }
}
