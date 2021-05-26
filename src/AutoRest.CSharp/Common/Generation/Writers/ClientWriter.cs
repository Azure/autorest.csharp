// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class ClientWriter
    {
        protected const string ClientDiagnosticsVariable = "clientDiagnostics";
        protected const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;
        protected const string PipelineVariable = "pipeline";
        protected const string PipelineField = "_" + PipelineVariable;

        protected string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        protected void WriteClientFields(CodeWriter writer, RestClient client)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            writer.Append($"internal {client.Type} RestClient").LineRaw(" { get; }");
        }

        protected void WritePagingOperationDefinition(CodeWriter writer, PagingMethod pagingMethod, bool async, string restClientParam, string clientDiagnosticsParam)
        {
            // Paging method definition
            var pageType = pagingMethod.PagingResponse.ItemType;
            var parameters = pagingMethod.Method.Parameters;
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                var pageWrappedType = new CSharpType(typeof(Page<>), pageType);
                var funcType = async ? new CSharpType(typeof(Task<>), pageWrappedType) : pageWrappedType;

                var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
                var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

                var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
                var asyncText = async ? "async" : string.Empty;
                var awaitText = async ? "await" : string.Empty;
                var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
                using (writer.Scope($"{asyncText} {funcType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, pagingMethod.Diagnostics, clientDiagnosticsParam, writer =>
                    {
                        writer.Append($"var response = {awaitText} {restClientParam}.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                        foreach (Parameter parameter in parameters)
                        {
                            writer.Append($"{parameter.Name}, ");
                        }

                        writer.Line($"cancellationToken){configureAwaitText};");
                        writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}, {continuationTokenText}, response.GetRawResponse());");
                    });
                }

                var nextPageFunctionName = "null";
                if (pagingMethod.NextPageMethod != null)
                {
                    nextPageFunctionName = "NextPageFunc";
                    var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                    using (writer.Scope($"{asyncText} {funcType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                    {
                        WriteDiagnosticScope(writer, pagingMethod.Diagnostics, clientDiagnosticsParam, writer =>
                        {
                            writer.Append($"var response = {awaitText} {restClientParam}.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(");
                            foreach (Parameter parameter in nextPageParameters)
                            {
                                writer.Append($"{parameter.Name}, ");
                            }
                            writer.Line($"cancellationToken){configureAwaitText};");
                            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}, {continuationTokenText}, response.GetRawResponse());");
                        });
                    }
                }
                writer.Line($"return {typeof(PageableHelpers)}.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
            }
            writer.Line();
        }

        protected void WriteDiagnosticScope(CodeWriter writer, Diagnostic diagnostic, string clientDiagnosticsParam, CodeWriterDelegate inner)
        {
            var scopeVariable = new CodeWriterDeclaration("scope");

            writer.Line($"using var {scopeVariable:D} = {clientDiagnosticsParam}.CreateScope({diagnostic.ScopeName:L});");
            foreach (DiagnosticAttribute diagnosticScopeAttributes in diagnostic.Attributes)
            {
                writer.Append($"{scopeVariable}.AddAttribute({diagnosticScopeAttributes.Name:L},");
                writer.WriteReferenceOrConstant(diagnosticScopeAttributes.Value);
                writer.Line($");");
            }

            writer.Line($"{scopeVariable}.Start();");

            using (writer.Scope($"try"))
            {
                inner(writer);
            }

            using (writer.Scope($"catch ({typeof(Exception)} e)"))
            {
                writer.Line($"{scopeVariable}.Failed(e);");
                writer.Line($"throw;");
            }
        }

        protected Parameter[] GetNonPathParameters(RestClientMethod clientMethod)
        {
            var pathParameters = GetPathParameters(clientMethod);

            List<Parameter> nonPathParameters = new List<Parameter>();
            foreach (Parameter parameter in clientMethod.Parameters)
            {
                if (!pathParameters.Contains(parameter))
                {
                    nonPathParameters.Add(parameter);
                }
            }

            return nonPathParameters.ToArray();
        }

        protected Parameter[] GetPathParameters(RestClientMethod clientMethod)
        {
            var pathParameters = clientMethod.Request.PathSegments.Where(m => m.Value.IsConstant == false && m.IsRaw == false);
            List<Parameter> pathParametersList = new List<Parameter>();
            foreach (var parameter in clientMethod.Parameters)
            {
                if (pathParameters.Any(p => p.Value.Reference.Type.Name == parameter.Type.Name &&
                p.Value.Reference.Name == parameter.Name))
                {
                    pathParametersList.Add(parameter);
                }
            }

            return pathParametersList.ToArray();
        }
    }
}
