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
using YamlDotNet.Core.Tokens;
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
                    // for usual resources, this constructor will do the following:
                    // 1. call this(Client, data.Id)
                    // 2. set data
                    // but for the polymorphic resources, we cannot do this in this procedure because the Data and HasData property are defined in base resource, and they are not settable here
                    // to set them, we can only call the base constructor
                    // but doing this, we lose the ability to call this(Client, data.Id) because we are calling base(Client, data) to set the Data and HasData property
                    // therefore the only option we have here is to duplicate the logic in this(Client, data.Id)
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
            var coreSignature = commonOperation.GetCoreMethodOverrideSignature(clientOperation);
            using (WriteCommonMethodWithoutValidation(coreSignature, null, isAsync))
            {
                _writer.WriteParametersValidation(coreSignature.Parameters);
                var diagnostic = new Diagnostic($"{This.Type.Name}.{coreSignature.Name}", Array.Empty<DiagnosticAttribute>());
                writeBody(new MgmtClientOperationWrapper(clientOperation, coreSignature.ReturnType!), diagnostic, isAsync);
            }

            _writer.Line();

            var signature = commonOperation.GetNewMethodSignature(clientOperation);
            // first we check if the return type of this method is the same as the core method
            // if they are not the same, we need to call the core method first, and add the corresponding conversion
            if (!commonOperation.ReturnType.Equals(clientOperation.ReturnType))
            {
                var returnsDescription = clientOperation.ReturnsDescription?.Invoke(isAsync);
                using (WriteCommonMethodWithoutValidation(signature, returnsDescription, isAsync, enableAttributes: true, attributes: new[] { new ForwardsClientCallsAttribute() }))
                {
                    var result = new CodeWriterDeclaration("result");
                    _writer.Append($"var {result:D} = ")
                        .AppendRawIf("await ", isAsync && !clientOperation.IsPagingOperation)
                        .Append($"{CreateMethodName(coreSignature.Name, isAsync)}(");
                    foreach (var parameter in coreSignature.Parameters)
                    {
                        _writer.AppendRaw(parameter.Name).AppendRaw(",");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.AppendRaw(")")
                        .AppendRawIf(".ConfigureAwait(false)", isAsync && !clientOperation.IsPagingOperation)
                        .LineRaw(";");

                    WritePolymorphicResponse(clientOperation, $"{result}");
                }
            }
            // if the return type of this method is exactly the same as the core method, we just need to call the core method, which is the same implementation as in the base resource
            // we do not need to write it again here
            // therefore here we check if the method has virtual keyword (this should come from configuration)
            // if it has virtual keyword for backward compatibility, we have to write the method. But for implementation, we just call base
            else if (signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual))
            {
                var returnsDescription = clientOperation.ReturnsDescription?.Invoke(isAsync);
                using (WriteCommonMethodWithoutValidation(signature, returnsDescription, isAsync, enableAttributes: true, attributes: new[] { new ForwardsClientCallsAttribute() }))
                {
                    _writer.Append($"return ")
                        .AppendRawIf("await ", isAsync && !clientOperation.IsPagingOperation)
                        .Append($"base.{CreateMethodName(signature.Name, isAsync)}(");
                    foreach (var parameter in signature.Parameters)
                    {
                        _writer.AppendRaw(parameter.Name).AppendRaw(",");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.AppendRaw(")")
                        .AppendRawIf(".ConfigureAwait(false)", isAsync && !clientOperation.IsPagingOperation)
                        .LineRaw(";");
                }
            }

            _writer.Line();
        }

        private void WritePolymorphicResponse(MgmtClientOperation clientOperation, FormattableString variableName)
        {
            // unwrap the result and wrap it again
            if (clientOperation.IsLongRunningOperation)
            {
                WritePolymorphicLROResponse(variableName, clientOperation.ReturnType, clientOperation);
            }
            else if (clientOperation.IsPagingOperation)
            {
                // in paging operation, we should never have a polymorphic return type case
                // in this case, this method should be returning "Pageable<MyselfResource>". This operation should always be on the collection class instead of being written here in the resource class.
                // therefore for paging operation, we just return the value variable: it should always have the same type as the return type of this method
                _writer.Line($"return {variableName};");
            }
            else
            {
                _writer.Line($"return {typeof(Response)}.FromValue(({clientOperation.ReturnType.UnWrapResponse()}){variableName}.Value, {variableName}.GetRawResponse());");
            }
        }

        private void WritePolymorphicLROResponse(FormattableString variableName, CSharpType returnType, MgmtClientOperation clientOperation)
        {
            // TODO -- we always assume this method only have one branch (for now). Maybe update this in the future so that it could support multiple branches
            Debug.Assert(clientOperation.OperationMappings.Count == 1);
            var branch = clientOperation.OperationMappings.Keys.First();
            var operation = clientOperation.OperationMappings[branch];
            var parameterMapping = clientOperation.ParameterMappings[branch];
            var operationSource = operation.OperationSource;

            // in this path, the return type should always be generic, otherwise the return type would be exactly the same and we will not go into this path
            Debug.Assert(returnType.IsGenericType);

            if (operation.IsFakeLongRunningOperation)
            {
                _writer.Append($"return new {LibraryArmOperation}<{returnType.UnWrapOperation()}>(")
                    .Append($"{typeof(Response)}.FromValue(({returnType.UnWrapOperation()}){variableName}.Value, {variableName}.GetRawResponse())")
                    .LineRaw(");");
            }
            else
            {
                // if we wait for completion in core, we do not have to wait again, just rewrap the lro object
                using (_writer.Scope($"if (waitUntil == {typeof(WaitUntil)}.Completed)"))
                {
                    _writer.Append($"return new {LibraryArmOperation}<{returnType.UnWrapOperation()}>(")
                        .Append($"{typeof(Response)}.FromValue(({returnType.UnWrapOperation()}){variableName}.Value, {variableName}.GetRawResponse())")
                        .LineRaw(");");
                }

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
                _writer.Append($").Request, {variableName}.GetRawResponse(), {typeof(OperationFinalStateVia)}.{operation.FinalStateVia!}");
                _writer.Line($");");

                _writer.LineRaw("return operation;");
            }
        }

        protected override void WriteTaggableCommonMethodResponseFromPutOrPatch(MgmtClientOperationWrapper tagOperationWrapper, MgmtClientOperation updateOperation, FormattableString variableName, bool isAsync)
        {
            if (IsCommonOperation(tagOperationWrapper.ClientOperation, out var commonOperation) && !commonOperation.ReturnType.Equals(updateOperation.ReturnType))
            {
                if (updateOperation.IsLongRunningOperation && updateOperation.ReturnType.Arguments.Length == 0)
                {
                    _writer.AppendRaw("return ")
                        .AppendRawIf("await ", isAsync)
                        .Append($"{CreateMethodName("Get", isAsync)}(cancellationToken: cancellationToken)")
                        .AppendRaw(".ConfigureAwait(false)")
                        .LineRaw(";");
                }
                else
                {
                    _writer.Line($"return {typeof(Response)}.FromValue(({tagOperationWrapper.ReturnType.UnWrapResponse()}){variableName}.Value, {variableName}.GetRawResponse());");
                }
            }
            else
            {
                base.WriteTaggableCommonMethodResponseFromPutOrPatch(tagOperationWrapper, updateOperation, variableName, isAsync);
            }
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
