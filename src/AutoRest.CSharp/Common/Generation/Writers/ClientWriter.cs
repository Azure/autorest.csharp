// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
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
        protected const string RestClientVariable = "restClient";
        protected const string PipelineVariable = "pipeline";
        protected const string PipelineProperty = "Pipeline";
        protected const string PipelineField = "_" + PipelineVariable;

        protected virtual string RestClientAccessibility => "internal";

        protected virtual string RestClientField => "RestClient";

        protected string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        protected void WriteClientFields(CodeWriter writer, RestClient client, bool writePipelineField)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            if (writePipelineField)
                writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            writer.Append($"{RestClientAccessibility} {client.Type} {RestClientField}").LineRaw(" { get; }");
        }

        protected void WriteDiagnosticScope(CodeWriter writer, Diagnostic diagnostic, string clientDiagnosticsParam, CodeWriterDelegate inner, bool catch404 = false)
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
            if (catch404)
            {
                using (writer.Scope($"catch ({typeof(RequestFailedException)} e) when (e.Status == 404)"))
                {
                    writer.Line($"return null;");
                }
            }
            using (writer.Scope($"catch ({typeof(Exception)} e)"))
            {
                writer.Line($"{scopeVariable}.Failed(e);");
                writer.Line($"throw;");
            }
        }

        protected void WriteSLROMethod(CodeWriter writer, RestClientMethod clientMethod, Parameter[] parameters, Diagnostic diagnostic, bool isAsync, bool isVirtual, CSharpType? returnType, string? methodName = null)
        {
            Debug.Assert(clientMethod.Operation != null);

            methodName = methodName ?? clientMethod.Name;

            writer.Line();
            writer.WriteXmlDocumentationSummary($"{clientMethod.Description}");

            //var parameterMapping = BuildParameterMapping(clientMethod);
            //var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters.ToArray());

            // CSharpType? returnType = GetLROReturnType(clientMethod, context);
            CSharpType responseType = returnType != null ?
                new CSharpType(typeof(Response<>), returnType) :
                typeof(Response);
            responseType = responseType.WrapAsync(isAsync);

            writer.Append($"public {GetAsyncKeyword(isAsync)} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, isAsync)}(");
            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters.ToArray());

                // Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var operation = new CodeWriterDeclaration("operation");
                    writer.Append($"var {operation:D} = {GetAwait(isAsync)}");
                    writer.Append($"{CreateMethodName($"Start{methodName}", isAsync)}(");
                    WriteArguments(writer, clientMethod);
                    writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

                    writer.Append($"return {GetAwait(isAsync)}");
                    var waitForCompletionMethod = returnType == null && isAsync ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
                    writer.Line($"{operation}.{CreateMethodName(waitForCompletionMethod, isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
                });
                writer.Line();
            }
        }

        protected virtual void WriteArguments(CodeWriter writer, RestClientMethod clientMethod)
        {
            foreach (var parameter in clientMethod.Parameters)
            {
                writer.Append($"{parameter.Name}, ");
            }
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

        protected internal string GetConfigureAwait(bool isAsync)
        {
            return isAsync ? ".ConfigureAwait(false)" : string.Empty;
        }
    }
}
