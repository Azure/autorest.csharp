// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        public static ResourceWriter GetWriter(CodeWriter writer, Resource resource) => resource switch
        {
            BaseResource baseResource => new BaseResourceWriter(writer, baseResource),
            _ => new ResourceWriter(writer, resource),
        };

        private Resource This { get; }

        protected internal ResourceWriter(CodeWriter writer, Resource resource) : base(writer, resource)
        {
            This = resource;
        }

        protected override void InitializeCustomMethodWriters()
        {
            foreach (var operation in This.CommonOperations.Keys)
            {
                // TODO -- determine whether we need to write this method here
                _customMethods.Add($"Write{operation.Name}Body", WriteRedirectMethodBody);
            }

            // add the tag writing methods if they are not added by the common operations above
            if (!_customMethods.TryAdd(nameof(WriteAddTagBody), WriteAddTagBody))
                _customMethods.Add("WriteAddTagCoreBody", WriteAddTagBody);
            if (!_customMethods.TryAdd(nameof(WriteSetTagsBody), WriteSetTagsBody))
                _customMethods.Add("WriteSetTagsCoreBody", WriteSetTagsBody);
            if (!_customMethods.TryAdd(nameof(WriteRemoveTagBody), WriteRemoveTagBody))
                _customMethods.Add("WriteRemoveTagCoreBody", WriteRemoveTagBody);
        }

        protected override void WriteStaticMethods()
        {
            WriteCreateResourceIdentifierMethods();
            _writer.Line();
        }

        private void WriteCreateResourceIdentifierMethods()
        {
            var method = This.CreateResourceIdentifierMethodSignature;
            var requestPath = This.RequestPath;
            _writer.WriteXmlDocumentationSummary($"{method.Description}");
            using (_writer.WriteMethodDeclaration(method))
            {
                // Storage has inconsistent definitions:
                // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L58
                // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L146
                // so here we have to use `Seqment.BuildSerializedSegments` instead of `RequestPath.SerializedPath` which could be from `RestClientMethod.Operation.GetHttpPath`
                var resourceId = new CodeWriterDeclaration("resourceId");
                _writer.Append($"var {resourceId:D} = ");
                _writer.AppendRaw("$\"");
                var first = true;
                foreach (var segment in requestPath)
                {
                    if (first)
                    {
                        first = false;
                        // If first segment is "{var}", then we should not add leading "/". Instead, we should let callers to specify, e.g. "{scope}/providers/Microsoft.Resources/..." v.s. "/subscriptions/{subscriptionId}/..."
                        if (!requestPath.Any() || requestPath.First().IsConstant)
                            _writer.AppendRaw("/");
                    }
                    else
                        _writer.AppendRaw("/");
                    if (segment.IsConstant)
                        _writer.AppendRaw(segment.ConstantValue);
                    else
                        _writer.Append($"{{{segment.ReferenceName:I}}}");
                }
                _writer.LineRaw("\";");
                _writer.Line($"return new {method.ReturnType?.Name}({resourceId:I});");
            }
        }

        protected override void WriteProperties()
        {
            if (This.CanValidateResourceType)
            {
                _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");
                _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
                _writer.Line();
            }

            if (This.CanSetResourceData)
            {
                _writer.WriteXmlDocumentationSummary($"Gets whether or not the current instance has data.");
                _writer.Line($"public virtual bool HasData {{ get; }}");
                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Gets the data representing this Feature.");
                _writer.WriteXmlDocumentationException(typeof(InvalidOperationException), $"Throws if there is no data loaded in the current instance.");
                using (_writer.Scope($"public virtual {This.ResourceData.Type} Data"))
                {
                    using (_writer.Scope($"get"))
                    {
                        _writer.Line($"if (!HasData)");
                        _writer.Line($"throw new {typeof(InvalidOperationException)}(\"The current instance does not have data, you must call Get first.\");");
                        _writer.Line($"return _data;");
                    }
                }
            }

            if (This.CanValidateResourceType)
            {
                _writer.Line();
                WriteStaticValidate($"ResourceType");
            }
        }

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            // check if this operation is a common operation from the base resource
            if (This.CommonOperations.TryGetValue(clientOperation, out var coreOperation))
            {
                // if it is common, we have two operations, one of them is core, the other is the public operation calling that core
                // first we write the core method with the implementation
                base.WriteMethod(coreOperation, isAsync);
                _writer.Line();
                base.WriteMethod(clientOperation, isAsync);
                _writer.Line();
            }
            else
            {
                // if this method is not common, we just return to the routine course
                base.WriteMethod(clientOperation, isAsync);
            }
        }

        private void WriteRedirectMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            // we should always get the corresponding core operation for this operation
            var coreOperation = This.CommonOperations[clientOperation];
            if (coreOperation.ReturnType.Equals(clientOperation.ReturnType))
            {
                // since the return types are the same, we just call the method and return it
                _writer.Append($"return ")
                        .AppendRawIf("await ", isAsync && !clientOperation.IsPagingOperation)
                        .Append($"base.{CreateMethodName(clientOperation.Name, isAsync)}(");
                foreach (var parameter in clientOperation.MethodParameters)
                {
                    _writer.AppendRaw(parameter.Name).AppendRaw(",");
                }
                _writer.RemoveTrailingComma();
                _writer.AppendRaw(")")
                    .AppendRawIf(".ConfigureAwait(false)", isAsync && !clientOperation.IsPagingOperation)
                    .LineRaw(";");
            }
            else
            {
                var result = new CodeWriterDeclaration("result");
                _writer.Append($"var {result:D} = ")
                    .AppendRawIf("await ", isAsync && !clientOperation.IsPagingOperation)
                    .Append($"{CreateMethodName(coreOperation.Name, isAsync)}(");
                foreach (var parameter in coreOperation.MethodParameters)
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

        private void WritePolymorphicResponse(MgmtClientOperation clientOperation, FormattableString variableName)
        {
            // unwrap the result and wrap it again
            if (clientOperation.IsLongRunningOperation)
            {
                WritePolymorphicLROResponse(variableName, clientOperation);
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
                _writer.Line($"return {typeof(Response)}.FromValue(({clientOperation.MgmtReturnType}){variableName}.Value, {variableName}.GetRawResponse());");
            }
        }
        private void WritePolymorphicLROResponse(FormattableString variableName, MgmtClientOperation clientOperation)
        {
            if (clientOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = clientOperation.OperationMappings.Keys.First();
                WritePolymorphicLROResponseBranch(variableName, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch]);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch LRO response for polymorphic resource not supported yet");
            }
        }

        private void WritePolymorphicLROResponseBranch(FormattableString variableName, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping)
        {
            if (operation.IsFakeLongRunningOperation)
            {
                _writer.Append($"return new {LibraryArmOperation}<{operation.MgmtReturnType!}>(")
                    .Append($"{typeof(Response)}.FromValue(({operation.MgmtReturnType!}){variableName}.Value, {variableName}.GetRawResponse())")
                    .LineRaw(");");
            }
            else
            {
                // if we wait for completion in core, we do not have to wait again, just rewrap the lro object
                using (_writer.Scope($"if (waitUntil == {typeof(WaitUntil)}.Completed)"))
                {
                    _writer.Append($"return new {LibraryArmOperation}<{operation.MgmtReturnType!}>(")
                        .Append($"{typeof(Response)}.FromValue(({operation.MgmtReturnType!}){variableName}.Value, {variableName}.GetRawResponse())")
                        .LineRaw(");");
                }

                if (operation.InterimOperation is not null)
                {
                    _writer.Append($"var operation = new {operation.InterimOperation.TypeName}");
                }
                else
                {
                    _writer.Append($"var operation = new {LibraryArmOperation}<{operation.MgmtReturnType!}>");
                }
                _writer.Append($"(");
                if (operation.OperationSource is not null)
                {
                    _writer.Append($"new {operation.OperationSource.TypeName}(")
                        .AppendIf($"{ArmClientReference}", operation.OperationSource.IsReturningResource)
                        .Append($"), ");
                }

                _writer.Append($"{GetDiagnosticName(operation)}, {PipelineProperty}, {GetRestClientName(operation)}.{RequestWriterHelpers.CreateRequestMethodName(operation.Method.Name)}(");
                WriteArguments(_writer, parameterMapping);
                _writer.RemoveTrailingComma();
                _writer.Append($").Request, {variableName}.GetRawResponse(), {typeof(OperationFinalStateVia)}.{operation.FinalStateVia!}");
                _writer.Line($");");

                _writer.LineRaw("return operation;");
            }
        }

        private void WriteAddTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    WriteGetOriginalFromTagResource(isAsync, "[key] = value");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, "[key] = value");
                }
            }
            _writer.Line();
        }

        private void WriteSetTagsBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    if (isAsync)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"GetTagResource().{CreateMethodName("Delete", isAsync)}({typeof(WaitUntil)}.Completed, cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");
                    WriteGetOriginalFromTagResource(isAsync, ".ReplaceWith(tags)");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, ".ReplaceWith(tags)", true);
                }
            }
            _writer.Line();
        }

        private void WriteRemoveTagBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(This.GetOperation.OperationMappings.Values.First())))
            {
                using (_writer.Scope(GetTagResourceCheckString(isAsync)))
                {
                    WriteGetOriginalFromTagResource(isAsync, ".Remove(key)");
                    WriteTaggableCommonMethod(isAsync);
                }
                using (_writer.Scope($"else"))
                {
                    WriteTaggableCommonMethodFromPutOrPatch(isAsync, ".Remove(key)");
                }
            }
            _writer.Line();
        }

        private static FormattableString GetTagResourceCheckString(bool isAsync)
        {
            var awaitStr = isAsync ? "await " : String.Empty;
            var configureStr = isAsync ? ".ConfigureAwait(false)" : String.Empty;
            return $"if({awaitStr} {CreateMethodName("CanUseTagResource", isAsync)}(cancellationToken: cancellationToken){configureStr})";
        }

        private void WriteGetOriginalFromTagResource(bool isAsync, string setCode)
        {
            _writer.Append($"var originalTags = ");
            if (isAsync)
            {
                _writer.Append($"await ");
            }
            _writer.Line($"GetTagResource().{CreateMethodName("Get", isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
            _writer.Line($"originalTags.Value.Data.TagValues{setCode};");
        }

        private void WriteTaggableCommonMethodFromPutOrPatch(bool isAsync, string setCode, bool isSetTags = false)
        {
            if (This.UpdateOperation is null && This.CreateOperation is null)
                throw new InvalidOperationException($"Unexpected null update method for resource {This.ResourceName} while its marked as taggable");
            var updateOperation = (This.UpdateOperation ?? This.CreateOperation)!;
            if (This.CommonOperations.TryGetValue(updateOperation, out var coreOperation))
            {
                // if we have the corresponding core version of this operation, use it instead
                updateOperation = coreOperation;
            }
            var getOperation = This.GetOperation;
            if (This.CommonOperations.TryGetValue(getOperation, out coreOperation))
            {
                // if we have the corresponding core version of this operation, use it instead
                getOperation = coreOperation;
            }
            var updateMethodName = updateOperation.Name;

            var configureStr = isAsync ? ".ConfigureAwait(false)" : String.Empty;
            var awaitStr = isAsync ? "await " : String.Empty;
            _writer.Line($"var current = ({awaitStr}{CreateMethodName(getOperation.Name, isAsync)}(cancellationToken: cancellationToken){configureStr}).Value.Data;");

            var lroParamStr = updateOperation.IsLongRunningOperation ? "WaitUntil.Completed, " : String.Empty;

            var parameters = updateOperation.IsLongRunningOperation ? updateOperation.MethodSignature.Parameters.Skip(1) : updateOperation.MethodSignature.Parameters;
            var bodyParamType = parameters.First().Type;
            string bodyParamName = "current";
            //if we are using PATCH always minimize what we pass in the body to what we actually want to change
            if (!bodyParamType.Equals(This.ResourceData.Type) || updateOperation.OperationMappings.Values.First().Operation.GetHttpMethod() == HttpMethod.Patch)
            {
                bodyParamName = "patch";
                if (bodyParamType.Implementation is ObjectType objectType)
                {
                    Configuration.MgmtConfiguration.PatchInitializerCustomization.TryGetValue(bodyParamType.Name, out var customizations);
                    customizations ??= new Dictionary<string, string>();
                    _writer.Append($"var patch = new {bodyParamType}(");
                    foreach (var parameter in objectType.InitializationConstructor.Signature.Parameters)
                    {
                        var varName = parameter.Name.FirstCharToUpperCase();
                        if (customizations.TryGetValue(varName, out var customization))
                        {
                            _writer.Append($"{customization}");
                        }
                        else
                        {
                            _writer.Append($"current.{varName}, ");
                        }
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Line($");");
                }
                else
                {
                    _writer.Line($"var patch = new {bodyParamType}();");
                }
                if (!isSetTags)
                {
                    using (_writer.Scope($"foreach(var tag in current.Tags)"))
                    {
                        _writer.Line($"patch.Tags.Add(tag);");
                    }
                }
                Configuration.MgmtConfiguration.UpdateRequiredCopy.TryGetValue(This.ResourceName, out var properties);
                if (properties is not null)
                {
                    foreach (var property in properties.Split(','))
                    {
                        _writer.Line($"patch.{property} = current.{property};");
                    }
                }
            }

            _writer.Line($"{bodyParamName}.Tags{setCode};");
            _writer.Line($"var result = {awaitStr}{CreateMethodName(updateMethodName, isAsync)}({lroParamStr}{bodyParamName}, cancellationToken: cancellationToken){configureStr};");
            if (updateOperation.IsLongRunningOperation)
            {
                if (updateOperation.ReturnType.Arguments.Length == 0)
                {
                    _writer.Line($"return {awaitStr}{CreateMethodName(getOperation.Name, isAsync)}(cancellationToken: cancellationToken){configureStr};");
                }
                else
                {
                    _writer.Line($"return Response.FromValue(result.Value, result.GetRawResponse());");
                }
            }
            else
            {
                _writer.Line($"return result;");
            }
        }

        private void WriteTaggableCommonMethod(bool isAsync)
        {
            _writer.Line($"{GetAwait(isAsync)} GetTagResource().{CreateMethodName("CreateOrUpdate", isAsync)}({typeof(WaitUntil)}.Completed, originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            var getOperation = This.GetOperation!;
            if (This.CommonOperations.TryGetValue(getOperation, out var coreOperation))
            {
                getOperation = coreOperation;
            }
            // we need to write multiple branches for a normal method
            if (getOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = getOperation.OperationMappings.Keys.First();
                WriteTaggableCommonMethodBranch(getOperation.OperationMappings[branch], getOperation.ParameterMappings[branch], isAsync);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteTaggableCommonMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool isAsync)
        {
            var originalResponse = new CodeWriterDeclaration("originalResponse");
            _writer
                .Append($"var {originalResponse:D} = {GetAwait(isAsync)} ")
                .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, isAsync)}(");

            WriteArguments(_writer, parameterMappings, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

            if (This.ResourceData.ShouldSetResourceIdentifier)
            {
                _writer.Line($"{originalResponse}.Value.Id = {CreateResourceIdentifierExpression(This, operation.RequestPath, parameterMappings, $"{originalResponse}.Value")};");
            }

            var valueConverter = operation.GetValueConverter($"{ArmClientReference}", $"{originalResponse}.Value");
            if (valueConverter != null)
            {
                _writer.Line($"return {typeof(Response)}.FromValue({valueConverter}, {originalResponse}.GetRawResponse());");
            }
            else
            {
                _writer.Line($"return {originalResponse}");
            }
        }
    }
}
