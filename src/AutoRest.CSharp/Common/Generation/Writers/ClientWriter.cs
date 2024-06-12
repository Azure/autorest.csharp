﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class ClientWriter
    {
        protected const string ClientDiagnosticsVariable = "clientDiagnostics";
        protected const string PipelineVariable = "pipeline";
        protected const string PipelineProperty = "Pipeline";
        protected const string PipelineField = "_" + PipelineVariable;
        protected const string DiagnosticsProperty = "Diagnostics";

        protected static readonly Reference ClientDiagnosticsField = new Reference("_" + ClientDiagnosticsVariable, typeof(ClientDiagnostics));

        protected virtual string RestClientAccessibility => "internal";

        protected virtual string RestClientField => "RestClient";

        protected static string CreateMethodName(string name, bool async) => async ? $"{name}Async" : name;

        protected void WriteClientFields(CodeWriter writer, RestClient client, bool writePipelineField)
        {
            if (Configuration.IsBranded)
            {
                writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField.GetReferenceFormattable()};");
            }
            if (writePipelineField)
            {
                writer.Line($"private readonly {Configuration.ApiTypes.HttpPipelineType} {PipelineField};");
            }
            writer.Append($"{RestClientAccessibility} {client.Type} {RestClientField}").WriteLineRaw(" { get; }");
        }
    }
}
