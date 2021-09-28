// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
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
    internal class LowLevelRestClientWriter
    {
        public void WriteClient(CodeWriter writer, RestClient restClient, Configuration configuration)
        {
            var cs = restClient.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{restClient.Description}");
                using (writer.Scope($"internal partial class {cs.Name}"))
                {
                    WriteClientFields(writer, restClient);

                    WriteClientCtor(writer, restClient, cs);

                    foreach (var method in restClient.Methods)
                    {
                        WriteRequestCreation(writer, method);
                        WriteOperation(writer, method, configuration, true);
                        WriteOperation(writer, method, configuration, false);
                    }
                }
            }
        }

        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;
        private const string PipelineVariable = "pipeline";
        private const string PipelineField = "_" + PipelineVariable;

        private void WriteClientFields(CodeWriter writer, RestClient restClient)
        {
            foreach (Parameter clientParameter in restClient.Parameters)
            {
                writer.Line($"private {clientParameter.Type} {clientParameter.Name};");
            }

            writer.Line($"private {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"private {typeof(HttpPipeline)} {PipelineField};");
            writer.Line();
        }

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
                    writer.WriteVariableAssignmentWithNullCheck($"this.{clientParameter.Name}", clientParameter);
                }

                writer.Line($"{ClientDiagnosticsField} = {ClientDiagnosticsVariable};");
                writer.Line($"{PipelineField} = {PipelineVariable};");
            }
            writer.Line();
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private void WriteRequestCreation(CodeWriter writer, RestClientMethod clientMethod)
        {
            RequestWriterHelpers.WriteRequestCreation(writer, clientMethod, "internal", false);
        }

        private static readonly CSharpType RequestOptionsParameterType = new CSharpType(typeof(RequestOptions), true);
        private static readonly Parameter RequestOptionsParameter = new Parameter("options", "The request options", RequestOptionsParameterType, Constant.Default(RequestOptionsParameterType), false);

        private void WriteOperation(CodeWriter writer, RestClientMethod operation, Configuration configuration, bool async)
        {
            using var methodScope = writer.AmbientScope();

            var headAsBoolean = operation.Request.HttpMethod == RequestMethod.Head && configuration.HeadAsBoolean == true;
            CSharpType responseType = headAsBoolean == true ? typeof(Response<bool>) : new CSharpType(typeof(Response));

            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;
            var parameters = operation.Parameters.Concat(new Parameter[] { RequestOptionsParameter }).ToArray();
            writer.WriteXmlDocumentationSummary($"{operation.Description}");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }

            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            var methodName = CreateMethodName(operation.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {methodName}(");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($")");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                writer.Line($"options ??= new {typeof(Azure.RequestOptions)}();");

                var messageVariable = new CodeWriterDeclaration("message");

                writer.Append($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(operation.Name)}(");

                foreach (var parameter in operation.Parameters)
                {
                    writer.Append($"{parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($");");

                writer.Line($"{typeof(RequestOptions)}.{nameof(RequestOptions.Apply)}(options, {messageVariable});");

                if (async)
                {
                    writer.Line($"await {PipelineField:I}.SendAsync({messageVariable}, options.CancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"{PipelineField:I}.Send({messageVariable}, options.CancellationToken);");
                }

                using (writer.Scope($"if (options.StatusOption == ResponseStatusOption.Default)"))
                {
                    WriteStatusCodeSwitch(writer, operation, async, messageVariable, false);
                }
                using (writer.Scope($"else"))
                {
                    if (headAsBoolean == true)
                    {
                        WriteStatusCodeSwitch(writer, operation, async, messageVariable, true);
                    }
                    else
                    {
                        writer.Line($"return {messageVariable}.{nameof(HttpMessage.Response)};");
                    }
                }
            }

            writer.Line();
        }

        private void WriteStatusCodeSwitch(CodeWriter writer, RestClientMethod clientMethod, bool async, CodeWriterDeclaration messageVariable, bool isNoThrow)
        {
            using (writer.Scope($"switch ({messageVariable}.{nameof(HttpMessage.Response)}.Status)"))
            {
                foreach (var response in clientMethod.Responses)
                {
                    var responseBody = response.ResponseBody;
                    var statusCodes = response.StatusCodes;

                    foreach (var statusCode in statusCodes)
                    {
                        if (statusCode.Code != null)
                        {
                            writer.Line($"case {statusCode.Code}:");
                        }
                        else
                        {
                            writer.Line($"case int s when s >= {statusCode.Family * 100:L} && s < {statusCode.Family * 100 + 100:L}:");
                        }
                    }
                    var returnType = clientMethod.ReturnType;
                    if (responseBody != null && responseBody is ConstantResponseBody body && returnType != null)
                    {
                        writer.Append($"return {typeof(Response)}.FromValue(");
                        writer.WriteReferenceOrConstant(body.Value);
                        writer.Append($", {messageVariable}.{nameof(HttpMessage.Response)});");
                    }
                    else
                    {
                        writer.Line($"return {messageVariable}.{nameof(HttpMessage.Response)};");
                    }
                }

                writer.Line($"default:");
                if (isNoThrow && clientMethod.ReturnType != null)
                {
                    writer.Append($"return new {new CSharpType(typeof(ErrorResponse<>), clientMethod.ReturnType)}({messageVariable}.{nameof(HttpMessage.Response)}, {GetException(async, messageVariable)});");
                }
                else
                {
                    writer.Append($"throw {GetException(async, messageVariable)};");
                }
            }
        }

        internal string GetException(bool isAsync, CodeWriterDeclaration messageVariable)
        {
            if (isAsync)
            {
                return $"await {ClientDiagnosticsField}.CreateRequestFailedExceptionAsync({messageVariable.ActualName}.{nameof(HttpMessage.Response)}).ConfigureAwait(false)";
            }
            else
            {
                return $"{ClientDiagnosticsField}.CreateRequestFailedException({messageVariable.ActualName}.{nameof(HttpMessage.Response)})";
            }
        }
    }
}
