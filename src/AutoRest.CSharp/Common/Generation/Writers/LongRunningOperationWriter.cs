// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Request = Azure.Core.Request;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LongRunningOperationWriter
    {
        public void Write(CodeWriter writer, LongRunningOperation operation)
        {
            var responseVariable = "response";
            var pagingResponse = operation.PagingResponse;

            var cs = operation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{operation.Description}");
                var interfaceType = GetInterfaceType(operation);
                var baseType = GetBaseType(operation);
                var helperType = GetHelperType(operation);

                writer.Append($"{operation.Declaration.Accessibility} partial class {cs.Name}: {baseType}");
                if (interfaceType != null)
                {
                    writer.Append($", {interfaceType}");
                }

                using (writer.Scope())
                {
                    WriteFields(writer, operation, pagingResponse, helperType);

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name} for mocking.");
                    using (writer.Scope($"protected {cs.Name:D}()"))
                    {
                    }

                    writer.Line();

                    WriteConstructor(writer, operation, pagingResponse, cs, helperType);
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override string Id => _operation.Id;");
                    writer.Line();

                    WriteValueProperty(writer, operation);

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override bool HasCompleted => _operation.HasCompleted;");
                    writer.Line();

                    if (operation.ResultType != null)
                    {
                        writer.WriteXmlDocumentationInheritDoc();
                        writer.Line($"public override bool HasValue => _operation.HasValue;");
                        writer.Line();
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.GetRawResponse();");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(ValueTask<Response>)} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                    writer.Line();

                    WriteWaitForCompletionVariants(writer, operation);
                    writer.Line();

                    WriteCreateResult(writer, operation, responseVariable, pagingResponse, interfaceType);

                    if (pagingResponse != null)
                    {
                        writer.Line();

                        Debug.Assert(operation.ResultSerialization != null);

                        var funcType = new CSharpType(typeof(Task<>), pagingResponse.PageType);
                        var itemPropertyName = pagingResponse.ItemProperty.Declaration.Name;
                        var nextLinkPropertyName = pagingResponse.NextLinkProperty?.Declaration.Name;

                        using (writer.Scope($"private async {funcType} GetNextPage({typeof(string)} nextLink, {typeof(CancellationToken)} cancellationToken)"))
                        {
                            writer.Line($"{typeof(Response)} {responseVariable} = await _nextPageFunc(nextLink).ConfigureAwait(false);");
                            writer.Line($"{pagingResponse.ResponseType} nextPageResult;");
                            writer.WriteDeserializationForMethods(
                                operation.ResultSerialization,
                                async: true,
                                (w, v) => w.Line($"nextPageResult = {v};"),
                                responseVariable);

                            writer.Line($"return {typeof(Page)}.FromValues(nextPageResult.{itemPropertyName}, nextPageResult.{nextLinkPropertyName}, {responseVariable});");
                        }
                    }
                }
            }
        }

        protected virtual CSharpType? GetInterfaceType(LongRunningOperation operation)
        {
            return operation.ResultType != null ? new CSharpType(typeof(IOperationSource<>), operation.ResultType) : null;
        }

        protected virtual CSharpType GetBaseType(LongRunningOperation operation)
        {
            return operation.ResultType != null ? new CSharpType(typeof(Operation<>), operation.ResultType) : new CSharpType(typeof(Operation));
        }

        protected virtual CSharpType GetValueTaskType(LongRunningOperation operation)
        {
            return operation.ResultType != null ? new CSharpType(typeof(Response<>), operation.ResultType) : new CSharpType(typeof(Response));
        }

        protected virtual CSharpType GetHelperType(LongRunningOperation operation)
        {
            return operation.ResultType != null ? new CSharpType(typeof(OperationInternals<>), operation.ResultType) : new CSharpType(typeof(OperationInternals));
        }

        protected virtual void WriteFields(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType helperType)
        {
            writer.Line($"private readonly {helperType} _operation;");

            if (pagingResponse != null)
            {
                writer.Line($"private readonly {typeof(Func<string, Task<Response>>)} _nextPageFunc;");
            }
        }

        protected virtual void WriteConstructor(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType lroType, CSharpType helperType)
        {
            writer.Append($"internal {lroType.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response");

            if (pagingResponse != null)
            {
                writer.Append($", {typeof(Func<string, Task<Response>>)} nextPageFunc");
            }
            writer.Line($")");

            using (writer.Scope())
            {
                writer.Append($"_operation = new {helperType}(");
                if (operation.ResultType != null)
                {
                    writer.Append($"this, ");
                }
                writer.Line($"clientDiagnostics, pipeline, request, response, { typeof(OperationFinalStateVia)}.{ operation.FinalStateVia}, { operation.Diagnostics.ScopeName:L});");

                if (pagingResponse != null)
                {
                    writer.Line($"_nextPageFunc = nextPageFunc;");
                }
            }
        }

        protected virtual void WriteValueProperty(CodeWriter writer, LongRunningOperation operation)
        {
            if (operation.ResultType != null)
            {
                writer.WriteXmlDocumentationInheritDoc();
                writer.Line($"public override {operation.ResultType} Value => _operation.Value;");
                writer.Line();
            }
        }

        protected virtual void WriteWaitForCompletionVariants(CodeWriter writer, LongRunningOperation operation)
        {
            var valueTaskType = GetValueTaskType(operation);
            var waitForCompletionType = new CSharpType(typeof(ValueTask<>), valueTaskType);
            var waitForCompleteMethodName = operation.ResultType != null ? "WaitForCompletionAsync" : "WaitForCompletionResponseAsync";

            writer.WriteXmlDocumentationInheritDoc();
            writer.Line($"public override {waitForCompletionType} {waitForCompleteMethodName}({typeof(CancellationToken)} cancellationToken = default) => _operation.{waitForCompleteMethodName}(cancellationToken);");
            writer.Line();

            writer.WriteXmlDocumentationInheritDoc();
            writer.Line($"public override {waitForCompletionType} {waitForCompleteMethodName}({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.{waitForCompleteMethodName}(pollingInterval, cancellationToken);");
            writer.Line();
        }

        protected virtual void WriteCreateResult(CodeWriter writer, LongRunningOperation operation, string responseVariable, PagingResponseInfo? pagingResponse, CSharpType? interfaceType)
        {
            if (operation.ResultType != null)
            {
                using (writer.Scope($"{operation.ResultType} {interfaceType}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    WriteCreateResultImpl(false, writer, operation, responseVariable, pagingResponse);
                }
                writer.Line();

                using (writer.Scope($"async {new CSharpType(typeof(ValueTask<>), operation.ResultType)} {interfaceType}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    WriteCreateResultImpl(true, writer, operation, responseVariable, pagingResponse);
                }
            }
        }

        protected void WriteCreateResultImpl(bool async, CodeWriter writer, LongRunningOperation operation, string responseVariable, PagingResponseInfo? pagingResponse, Action<CodeWriter, CodeWriterDelegate>? valueCallback = null)
        {
            // default value callback, just write a return statement
            valueCallback ??= (w, v) => w.Line($"return {v};");

            if (operation.ResultSerialization != null)
            {
                if (pagingResponse != null)
                {
                    var itemPropertyName = pagingResponse.ItemProperty.Declaration.Name;
                    var nextLinkPropertyName = pagingResponse.NextLinkProperty?.Declaration.Name;

                    writer.Line($"{pagingResponse.ResponseType} firstPageResult;");
                    writer.WriteDeserializationForMethods(
                        operation.ResultSerialization,
                        async: async,
                        (w, v) => w.Line($"firstPageResult = {v};"),
                        responseVariable);

                    writer.Line($"{pagingResponse.PageType} firstPage = {typeof(Page)}.FromValues(firstPageResult.{itemPropertyName}, firstPageResult.{nextLinkPropertyName}, {responseVariable});");
                    writer.Line();

                    valueCallback(writer, w => w.Append($"{typeof(PageableHelpers)}.CreateAsyncEnumerable(_ => Task.FromResult(firstPage), (nextLink, _) => GetNextPage(nextLink, cancellationToken))"));
                }
                else
                {
                    writer.WriteDeserializationForMethods(
                        operation.ResultSerialization,
                        async: async,
                        valueCallback,
                        responseVariable);
                }
            }
            else
            {
                if (async)
                {
                    valueCallback(writer, w => w.Append($"await new {typeof(ValueTask<Response>)}({responseVariable}).ConfigureAwait(false)"));
                }
                else
                {
                    valueCallback(writer, w => w.Append($"{responseVariable}"));
                }
            }
        }
    }
}
