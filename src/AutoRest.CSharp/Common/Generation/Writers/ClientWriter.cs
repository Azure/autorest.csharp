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
        protected const string PipelineProperty = "Pipeline";
        protected const string PipelineField = "_" + PipelineVariable;

        protected string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        protected void WriteClientFields(CodeWriter writer, RestClient client, bool writePipelineField)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            if (writePipelineField)
                writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            writer.Append($"internal {client.Type} RestClient").LineRaw(" { get; }");
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
