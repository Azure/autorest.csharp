// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Operation = AutoRest.CSharp.Input.Operation;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected const string BaseUriField = "BaseUri";

        protected CodeWriter _writer;
        protected override string RestClientField => "_" + RestClientVariable;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected BuildContext<MgmtOutputLibrary> Context { get; }
        protected MgmtConfiguration Config => Context.Configuration.MgmtConfiguration;

        private MgmtTypeProvider _provider;
        protected virtual MgmtTypeProvider This => _provider;
        protected virtual CSharpType TypeOfThis => This.Type;
        /// <summary>
        /// ClassName is the name of the class which this writer is writing
        /// </summary>
        protected virtual string TypeNameOfThis => TypeOfThis.Name;

        protected virtual string Accessibility => "public";

        protected virtual string IdVariableName => "Id";

        protected MgmtClientBaseWriter(CodeWriter writer, MgmtTypeProvider provider, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            Context = context;
            _provider = provider;
        }

        public abstract void Write();

        protected virtual void WriteChildResourceEntries()
        {
            foreach (var resource in This.ChildResources)
            {
                _writer.Line();
                _writer.Line($"#region {resource.ResourceName}");
                if (resource.IsSingleton)
                    WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!);
                else
                    WriteResourceContainerEntry(resource);
                _writer.Line($"#endregion");
            }
        }

        protected abstract void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix);

        protected abstract void WriteResourceContainerEntry(Resource resource);

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace(typeof(Task).Namespace!);
        }

        protected void WriteFields(CodeWriter writer, IEnumerable<RestClient> clients)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            foreach (var client in clients)
            {
                // we might have multiple rest client field, if we combined multiple request together in one resource in case of extension resources
                writer.Line($"{RestClientAccessibility} readonly {client.Type} {GetRestClientVariableName(client)};");
            }
        }

        protected virtual string GetRestClientVariableName(RestClient client)
        {
            return $"_{client.OperationGroup.Key.ToVariableName()}RestClient";
        }

        protected internal CSharpType GetResponseType(CSharpType? returnType, bool async)
        {
            if (returnType == null)
                return typeof(Response).WrapAsync(async);

            return returnType.WrapResponse(async);
        }

        protected internal string GetConfigureAwait(bool isAsync)
        {
            return isAsync ? ".ConfigureAwait(false)" : string.Empty;
        }

        protected internal string GetVirtual(bool isVirtual)
        {
            return isVirtual ? "virtual" : string.Empty;
        }

        protected internal string GetAsyncKeyword(bool isAsync)
        {
            return isAsync ? "async" : string.Empty;
        }

        protected internal string GetAsyncSuffix(bool isAsync)
        {
            return isAsync ? "Async" : string.Empty;
        }

        protected internal string GetAwait(bool isAsync)
        {
            return isAsync ? "await " : string.Empty;
        }

        protected internal string GetNextLink(bool isNextPageFunc)
        {
            return isNextPageFunc ? "nextLink, " : string.Empty;
        }

        protected internal string GetOverride(bool isInheritedMethod, bool isVirtual = false)
        {
            return isInheritedMethod ? "override" : GetVirtual(isVirtual);
        }

        protected virtual void WriteMethod(MgmtClientOperation clientOperation, bool async, string? methodName = null)
        {
            methodName ??= GetMethodName(clientOperation);
            // we need to identify this operation belongs to which category: NormalMethod, LROMethod or PagingMethod
            if (clientOperation.IsLongRunningOperation())
            {
                // this is a long-running operation
                WriteLROMethod(clientOperation, methodName, async);
            }
            else if (clientOperation.IsPagingOperation(Context))
            {
                // this is a paging operation
                WritePagingMethod(clientOperation, methodName, async);
            }
            else
            {
                // this is a normal operation
                WriteNormalMethod(clientOperation, methodName, async);
            }
        }

        protected virtual string GetMethodName(MgmtClientOperation clientOperation)
        {
            return clientOperation.Name;
        }

        protected virtual void WritePagingMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");

            // TODO -- find a better way to get this type
            var itemType = clientOperation.First(restOperation => restOperation.IsPagingOperation(Context)).GetPagingMethod(Context)!.PagingResponse.ItemType;
            itemType = WrapResourceDataType(itemType)!;
            _writer.WriteXmlDocumentationReturns($"{(async ? "An async" : "A")} collection of <see cref=\"{itemType.Name}\" /> that may take multiple service requests to iterate over.");

            WritePagingMethodSignature(_writer, itemType.WrapPageable(async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WritePagingMethodBody(_writer, itemType, diagnostic, operationMappings, parameterMappings, async);
            }
        }

        protected void WritePagingMethodBody(CodeWriter writer, CSharpType itemType, Diagnostic diagnostic,
            IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // we need to write multiple branches for a paging method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WritePagingMethodBranch(writer, itemType, diagnostic, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch GET not supported yet");
            }
        }

        protected virtual void WritePagingMethodBranch(CodeWriter writer, CSharpType itemType, Diagnostic diagnostic, MgmtRestOperation operation,
            IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var pagingMethod = operation.GetPagingMethod(Context)!;
            var returnType = new CSharpType(typeof(Page<>), itemType).WrapAsync(async);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            using (writer.Scope($"{GetAsyncKeyword(async)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    WritePageFunctionBody(writer, itemType, pagingMethod, operation, parameterMappings, async, false);
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (writer.Scope($"{GetAsyncKeyword(async)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                    {
                        WritePageFunctionBody(writer, itemType, pagingMethod, operation, parameterMappings, async, true);
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        protected void WritePageFunctionBody(CodeWriter writer, CSharpType itemType, PagingMethod pagingMethod, MgmtRestOperation operation,
            IEnumerable<ParameterMapping> parameterMappings, bool isAsync, bool isNextPageFunc)
        {
            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";

            writer.Append($"var response = {GetAwait(isAsync)} {GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, isAsync)}({GetNextLink(isNextPageFunc)}");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            // only when we are listing ourselves, we use Select to convert XXXResourceData to XXXResource
            var converter = string.Empty;
            if (itemType != pagingMethod.PagingResponse.ItemType)
            {
                writer.UseNamespace("System.Linq");
                converter = $".Select(value => new {itemType.Name}({ContextProperty}, value))";
            }
            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}{converter}, {continuationTokenText}, response.GetRawResponse());");
        }

        protected virtual void WriteNormalMethodSignature(CodeWriter writer, CSharpType responseType, string methodName, IEnumerable<Parameter> methodParameters,
            bool async, string accessibility = "public", bool isVirtual = true)
        {
            writer.Append($"{accessibility} {GetAsyncKeyword(async)} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, async)}(");

            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        protected virtual void WritePagingMethodSignature(CodeWriter writer, CSharpType responseType, string methodName, IEnumerable<Parameter> methodParameters,
            bool async, string accessibility = "public", bool isVirtual = true)
        {
            writer.Append($"{accessibility} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, async)}(");

            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        protected virtual void WriteLROMethodSignature(CodeWriter writer, CSharpType responseType, string methodName, IEnumerable<Parameter> methodParameters,
            bool async, bool isSLRO, string accessibility = "public", bool isVirtual = true)
        {
            writer.Append($"{accessibility} {GetAsyncKeyword(async)} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, async)}(");
            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }

            var defaultWaitForCompletion = isSLRO ? "true" : "false";
            writer.Line($"bool waitForCompletion = {defaultWaitForCompletion}, {typeof(CancellationToken)} cancellationToken = default)");
        }

        protected virtual void WriteNormalMethod(MgmtClientOperation clientOperation, string methodName, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            var returnType = WrapResourceDataType(clientOperation.ReturnType);

            WriteNormalMethodSignature(_writer, GetResponseType(returnType, async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);
                var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField,
                    writer => WriteNormalMethodBody(writer, operationMappings, parameterMappings, async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull));
                _writer.Line();
            }
        }

        protected virtual void WriteNormalMethodBody(CodeWriter writer, IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            // we need to write multiple branches for a normal method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteNormalMethodBranch(writer, operationMappings[branch], parameterMappings[branch], async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        protected virtual void WriteNormalMethodBranch(CodeWriter writer, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            writer.Append($"var response = {GetAwait(async)} ");
            writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteNormalMethodResponse(writer, operation, async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull);
        }

        protected virtual void WriteNormalMethodResponse(CodeWriter writer, MgmtRestOperation operation, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            if (IsResourceDataType(operation.ReturnType))
            {
                if (shouldThrowExceptionWhenNull)
                {
                    writer.Line($"if (response.Value == null)");
                    writer.Line($"throw {GetAwait(async)} {ClientDiagnosticsField}.{CreateMethodName("CreateRequestFailedException", async)}(response.GetRawResponse()){GetConfigureAwait(async)};");
                }
                writer.Line($"return {typeof(Response)}.FromValue(new {WrapResourceDataType(operation.ReturnType)}({ContextProperty}, response.Value), response.GetRawResponse());");
            }
            else
            {
                writer.Line($"return response;");
            }
        }

        protected virtual void WriteLROMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();

            // we can only make this an SLRO when all of the methods are not really long
            bool isSLRO = !clientOperation.IsLongRunningReallyLong();
            methodName = isSLRO ? methodName : $"Start{methodName}";

            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = GetLROObjectType(clientOperation.First().Operation, async);
            var responseType = lroObjectType.WrapAsync(async);

            WriteLROMethodSignature(_writer, responseType, methodName, methodParameters, async, isSLRO, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField,
                    writer => WriteLROMethodBody(writer, lroObjectType, operationMappings, parameterMappings, async));
                _writer.Line();
            }
        }

        protected virtual void WriteLROMethodBody(CodeWriter writer, CSharpType lroObjectType, IDictionary<RequestPath, MgmtRestOperation> operationMapping,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // TODO -- we need to write multiple branches for a LRO operation
            if (operationMapping.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMapping.Keys.First();
                WriteLROMethodBranch(writer, lroObjectType, operationMapping[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch LRO not supported yet");
            }
        }

        protected virtual void WriteLROMethodBranch(CodeWriter writer, CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            writer.Append($"var response = {GetAwait(async)} ");
            writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(writer, parameterMapping);
            writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(writer, lroObjectType, operation, parameterMapping, async);
        }

        protected virtual CSharpType? WrapResourceDataType(CSharpType? returnType)
        {
            return returnType;
        }

        protected virtual bool IsResourceDataType(CSharpType? returnType)
        {
            return false;
        }

        protected CSharpType GetLROObjectType(Operation operation, bool async)
        {
            var lroObjectType = operation.IsLongRunning
                ? Context.Library.GetLongRunningOperation(operation).Type
                : Context.Library.GetNonLongRunningOperation(operation).Type;
            return lroObjectType;
        }

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping, bool passNullForOptionalParameters = false)
        {
            foreach (var parameter in mapping)
            {
                if (parameter.IsPassThru)
                {
                    if (PagingMethod.IsPageSizeName(parameter.Parameter.Name))
                    {
                        // alway use the `pageSizeHint` parameter from `AsPages(pageSizeHint)`
                        if (PagingMethod.IsPageSizeType(parameter.Parameter.Type.FrameworkType))
                        {
                            writer.AppendRaw($"pageSizeHint, ");
                        }
                        else
                        {
                            Console.Error.WriteLine($"WARNING: Parameter '{parameter.Parameter.Name}' is like a page size parameter, but it's not a numeric type. Fix it or overwrite it if necessary.");
                            writer.Append($"{parameter.Parameter.Name}, ");
                        }
                    }
                    else
                    {
                        if (passNullForOptionalParameters && !parameter.Parameter.ValidateNotNull)
                            writer.Append($"null, ");
                        else
                            writer.Append($"{parameter.Parameter.Name}, ");
                    }
                }
                else
                {
                    writer.Append($"{parameter.ValueExpression}, ");
                }
            }
        }

        protected CSharpType? GetLROResultType(Input.Operation operation)
        {
            CSharpType? returnType = null;
            if (operation.IsLongRunning)
            {
                LongRunningOperation lro = Context.Library.GetLongRunningOperation(operation);
                MgmtLongRunningOperation longRunningOperation = AsMgmtOperation(lro);
                returnType = longRunningOperation.WrapperType != null ? longRunningOperation.WrapperType : longRunningOperation.ResultType;
            }
            else
            {
                NonLongRunningOperation nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(operation);
                returnType = nonLongRunningOperation.ResultType;
            }

            return returnType;
        }

        protected MgmtLongRunningOperation AsMgmtOperation(LongRunningOperation operation)
        {
            var mgmtOperation = operation as MgmtLongRunningOperation;
            Debug.Assert(mgmtOperation != null);
            return mgmtOperation;
        }

        protected virtual void WriteLROResponse(CodeWriter writer, CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            writer.Append($"var operation = new {lroObjectType}(");

            if (operation.Operation.IsLongRunning)
            {
                var longRunningOperation = AsMgmtOperation(Context.Library.GetLongRunningOperation(operation.Operation));
                if (longRunningOperation.WrapperType != null)
                {
                    writer.Append($"{ContextProperty}, ");
                }
                writer.Append($"{ClientDiagnosticsField}, {PipelineProperty}, {GetRestClientVariableName(operation.RestClient)}.{RequestWriterHelpers.CreateRequestMethodName(operation.Name)}(");
                WriteArguments(writer, parameterMapping);
                writer.RemoveTrailingComma();
                writer.Append($").Request, ");
            }
            else
            {
                var nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(operation.Operation);
                // need to check implementation type as some delete operation uses ResourceData.
                if (nonLongRunningOperation.ResultType != null && nonLongRunningOperation.ResultType.Implementation.GetType() == typeof(Resource))
                {
                    writer.Append($"{ContextProperty}, ");
                }
            }
            writer.Line($"response);");
            CSharpType? lroResultType = GetLROResultType(operation.Operation);
            var waitForCompletionMethod = lroResultType == null && async ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
            writer.Line($"if (waitForCompletion)");
            writer.Line($"{GetAwait(async)} operation.{CreateMethodName(waitForCompletionMethod, async)}(cancellationToken){GetConfigureAwait(async)};");
            writer.Line($"return operation;");
        }
    }
}
