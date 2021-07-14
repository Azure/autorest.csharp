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
using AutoRest.CSharp.Input;
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
    }
}
