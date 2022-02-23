// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class RestClientWriter
    {
        public void WriteClient(CodeWriter writer, RestClient restClient, IReadOnlyList<LowLevelClientMethod>? protocolMethods = null)
        {
            var cs = restClient.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, restClient);
                    WriteClientCtor(writer, restClient, cs);

                    var responseClassifierTypes = new List<LowLevelClientWriter.ResponseClassifierType>();
                    foreach (var method in restClient.Methods)
                    {
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", restClient.Fields, null, false);
                        WriteOperation(writer, method, true);
                        WriteOperation(writer, method, false);

                        var protocolMethodList = protocolMethods?.Where(m => m.RequestMethod.Operation.Equals(method.Operation)).ToList();
                        if (protocolMethodList is {Count: 1})
                        {
                            var protocolMethod = protocolMethodList.First();
                            LowLevelClientWriter.WriteRequestCreationMethod(writer, protocolMethod.RequestMethod, restClient.Fields, responseClassifierTypes);

                            if (protocolMethod.IsLongRunning)
                            {
                                LowLevelClientWriter.WriteLongRunningOperationMethod(writer, protocolMethod, restClient.Fields, true);
                                LowLevelClientWriter.WriteLongRunningOperationMethod(writer, protocolMethod, restClient.Fields, false);
                            }
                            else if (protocolMethod.PagingInfo != null)
                            {
                                LowLevelClientWriter.WritePagingMethod(writer, protocolMethod, restClient.Fields, true);
                                LowLevelClientWriter.WritePagingMethod(writer, protocolMethod, restClient.Fields, false);
                            }
                            else
                            {
                                LowLevelClientWriter.WriteClientMethod(writer, protocolMethod, restClient.Fields, true);
                                LowLevelClientWriter.WriteClientMethod(writer, protocolMethod, restClient.Fields, false);
                            }
                        }
                    }

                    LowLevelClientWriter.WriteResponseClassifierMethod(writer, responseClassifierTypes);
                }
            }
        }

        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string ClientDiagnosticsField = "ClientDiagnostics";
        private const string PipelineVariable = "pipeline";
        private const string PipelineField = "_" + PipelineVariable;

        private void WriteClientFields(CodeWriter writer, RestClient restClient) => writer.WriteFieldDeclarations(restClient.Fields);

        private void WriteClientCtor(CodeWriter writer, RestClient restClient, CSharpType cs)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
            writer.WriteXmlDocumentationParameter(ClientDiagnosticsVariable, $"The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter(PipelineVariable, $"The HTTP pipeline for sending and receiving REST requests and responses.");
            foreach (Parameter parameter in restClient.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }

            writer.WriteXmlDocumentationRequiredParametersException(restClient.Parameters);

            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} {ClientDiagnosticsVariable}, {typeof(HttpPipeline)} {PipelineVariable},");
            foreach (Parameter clientParameter in restClient.Parameters)
            {
                writer.WriteParameter(clientParameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                foreach (Parameter clientParameter in restClient.Parameters)
                {
                    var field = restClient.Fields.GetFieldByParameter(clientParameter);
                    if (field != null)
                    {
                        writer.WriteVariableAssignmentWithNullCheck($"{field.Name}", clientParameter);
                    }
                }

                writer.Line($"{ClientDiagnosticsField} = {ClientDiagnosticsVariable};");
                writer.Line($"{PipelineField} = {PipelineVariable};");
            }
            writer.Line();
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private void WriteOperation(CodeWriter writer, RestClientMethod operation, bool async)
        {
            using var methodScope = writer.AmbientScope();

            CSharpType? bodyType = operation.ReturnType;
            CSharpType? headerModelType = operation.HeaderModel?.Type;
            CSharpType responseType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;
            var parameters = operation.Parameters;
            writer.WriteXmlDocumentationSummary($"{operation.Description}");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            var methodName = CreateMethodName(operation.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {methodName}(");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                var messageVariable = new CodeWriterDeclaration("message");
                var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);
                writer.Append($"using var {messageVariable:D} = {requestMethodName}(");

                foreach (Parameter parameter in parameters)
                {
                    writer.Append($"{parameter.Name:I}, ");
                }

                writer.RemoveTrailingComma();
                writer.Line($");");

                if (async)
                {
                    writer.Line($"await {PipelineField}.SendAsync({messageVariable}, cancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"{PipelineField}.Send({messageVariable}, cancellationToken);");
                }

                ResponseWriterHelpers.WriteStatusCodeSwitch(writer, messageVariable.ActualName, operation, async);
            }
            writer.Line();
        }
    }
}
