// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class ClientWriter
    {
        protected const string ClientDiagnosticsVariable = "clientDiagnostics";
        protected const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;
        protected const string PipelineVariable = "pipeline";
        protected const string PipelineProperty = "Pipeline";
        protected const string PipelineField = "_" + PipelineVariable;
        protected const string DiagnosticOptionsProperty = "DiagnosticOptions";

        protected virtual string RestClientAccessibility => "internal";

        protected virtual string RestClientField => "RestClient";

        protected static string CreateMethodName(string name, bool async) => async ? $"{name}Async" : name;

        protected void WriteClientFields(CodeWriter writer, RestClient client, bool writePipelineField)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            if (writePipelineField)
                writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            writer.Append($"{RestClientAccessibility} {client.Type} {RestClientField}").LineRaw(" { get; }");
        }

        protected static IDisposable WriteDiagnosticScope(CodeWriter writer, Diagnostic diagnostic, string clientDiagnosticsParam)
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
            return new DiagnosticScope(writer.Scope($"try"), scopeVariable, writer);
        }

        private class DiagnosticScope : IDisposable
        {
            private readonly CodeWriter.CodeWriterScope _scope;
            private readonly CodeWriterDeclaration _scopeVariable;
            private readonly CodeWriter _writer;

            public DiagnosticScope(CodeWriter.CodeWriterScope scope, CodeWriterDeclaration scopeVariable, CodeWriter writer)
            {
                _scope = scope;
                _scopeVariable = scopeVariable;
                _writer = writer;
            }

            public void Dispose()
            {
                _scope.Dispose();
                using (_writer.Scope($"catch ({typeof(Exception)} e)"))
                {
                    _writer.Line($"{_scopeVariable}.Failed(e);");
                    _writer.Line($"throw;");
                }
            }
        }
    }
}
