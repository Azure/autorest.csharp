// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Request = Azure.Core.Request;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class LongRunningOperationWriter
    {
        public static void Write(CodeWriter writer, LongRunningOperation operation)
        {
            var responseVariable = "response";
            var pagingResponse = operation.PagingResponse;

            void WriteResultFunction(bool async)
            {
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

                        writer.Line($"return {typeof(PageableHelpers)}.CreateAsyncEnumerable(_ => Task.FromResult(firstPage), (nextLink, _) => GetNextPage(nextLink, cancellationToken));");
                    }
                    else
                    {
                        writer.WriteDeserializationForMethods(
                            operation.ResultSerialization,
                            async: async,
                            (w, v) => w.Line($"return {v};"),
                            responseVariable);
                    }
                }
                else
                {
                    if (async)
                    {
                        writer.Line($"return await new {typeof(ValueTask<Response>)}({responseVariable}).ConfigureAwait(false);");
                    }
                    else
                    {
                        writer.Line($"return {responseVariable};");
                    }
                }
            }

            var cs = operation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(operation.Description);
                var interfaceType = new CSharpType(typeof(IOperationSource<>), operation.ResultType);
                var baseType = new CSharpType(typeof(Operation<>), operation.ResultType);
                var waitForCompletionType = new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response<>), operation.ResultType));
                var helperType = new CSharpType(typeof(ArmOperationHelpers<>), operation.ResultType);

                using (writer.Scope($"{operation.Declaration.Accessibility} partial class {cs.Name}: {baseType}, {interfaceType}"))
                {
                    writer.Line($"private readonly {helperType} _operation;");

                    if (pagingResponse != null)
                    {
                        writer.Line($"private readonly {typeof(Func<string, Task<Response>>)} _nextPageFunc;");
                    }

                    writer.Append($"internal {cs.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response");

                    if (pagingResponse != null)
                    {
                        writer.Append($", {typeof(Func<string, Task<Response>>)} nextPageFunc");
                    }
                    writer.Line($")");

                    using (writer.Scope())
                    {
                        writer.Line($"_operation = new {helperType}(this, clientDiagnostics, pipeline, request, response, {typeof(OperationFinalStateVia)}.{operation.FinalStateVia}, {operation.Diagnostics.ScopeName:L});");

                        if (pagingResponse != null)
                        {
                            writer.Line($"_nextPageFunc = nextPageFunc;");
                        }
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override string Id => _operation.Id;");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {operation.ResultType} Value => _operation.Value;");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override bool HasCompleted => _operation.HasCompleted;");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override bool HasValue => _operation.HasValue;");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.GetRawResponse();");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(ValueTask<Response>)} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {waitForCompletionType} WaitForCompletionAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {waitForCompletionType} WaitForCompletionAsync({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);");
                    writer.Line();

                    using (writer.Scope($"{operation.ResultType} {interfaceType}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                    {
                        WriteResultFunction(false);
                    }
                    writer.Line();

                    using (writer.Scope($"async {new CSharpType(typeof(ValueTask<>), operation.ResultType)} {interfaceType}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                    {
                        WriteResultFunction(true);
                    }

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
    }
}
