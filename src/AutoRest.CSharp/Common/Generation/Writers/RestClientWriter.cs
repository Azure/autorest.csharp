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
                        WriteRequestCreation(writer, method, restClient.Parameters, restClient.Fields);
                        WriteOperation(writer, method, true);
                        WriteOperation(writer, method, false);

                        if (protocolMethods != null)
                        {
                            var protocolMethodList = protocolMethods.Where(m => m.RequestMethod.Operation.Equals(method.Operation));
                            if (protocolMethodList != null && protocolMethodList.Count() == 1)
                            {
                                var protocolMethod = protocolMethodList.FirstOrDefault();
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
                                    if (!Configuration.AzureArm)
                                    {
                                        LowLevelClientWriter.WriteClientMethod(writer, protocolMethod, restClient.Fields, true);
                                        LowLevelClientWriter.WriteClientMethod(writer, protocolMethod, restClient.Fields, false);
                                    }
                                }
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

        private void WriteClientFields(CodeWriter writer, RestClient restClient)
        {
            WriteAdditionalFields(writer);
            foreach (var field in restClient.Fields)
            {
                writer.WriteFieldDeclaration(field);
            }

            writer.Line();
        }

        protected virtual void WriteAdditionalFields(CodeWriter writer)
        {
        }

        protected virtual void WriteAdditionalParameters(CodeWriter writer)
        {
        }

        protected virtual void WriteAdditionalXmlDocumentationParameters(CodeWriter writer)
        {
        }

        protected virtual void WriteAdditionalCtorBody(CodeWriter writer)
        {
        }

        protected virtual bool UseSDKUserAgent()
        {
            return false;
        }

        private void WriteClientCtor(CodeWriter writer, RestClient restClient, CSharpType cs)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
            writer.WriteXmlDocumentationParameter(ClientDiagnosticsVariable, $"The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter(PipelineVariable, $"The HTTP pipeline for sending and receiving REST requests and responses.");
            WriteAdditionalXmlDocumentationParameters(writer);
            foreach (Parameter parameter in restClient.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }

            writer.WriteXmlDocumentationRequiredParametersException(restClient.Parameters);

            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} {ClientDiagnosticsVariable}, {typeof(HttpPipeline)} {PipelineVariable},");
            WriteAdditionalParameters(writer);
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
                WriteAdditionalCtorBody(writer);
            }
            writer.Line();
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private void WriteRequestCreation(CodeWriter writer, RestClientMethod clientMethod, Parameter[] parameters, ClientFields fields)
        {
            RequestWriterHelpers.WriteRequestCreation(writer, clientMethod, "internal", fields, null, UseSDKUserAgent(), parameters);
        }

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

                WriteStatusCodeSwitch(writer, messageVariable, operation, async);
            }
            writer.Line();
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, CodeWriterDeclaration message, RestClientMethod operation, bool async)
        {
            string responseVariable = $"{message.ActualName}.Response";

            var returnType = operation.ReturnType;
            var headersModelType = operation.HeaderModel?.Type;

            ReturnKind kind;

            if (returnType != null && headersModelType != null)
            {
                kind = ReturnKind.HeadersAndValue;
            }
            else if (headersModelType != null)
            {
                kind = ReturnKind.Headers;
            }
            else if (returnType != null)
            {
                kind = ReturnKind.Value;
            }
            else
            {
                kind = ReturnKind.Response;
            }

            if (headersModelType != null)
            {
                writer.Line($"var headers = new {headersModelType}({responseVariable});");
            }

            using (writer.Scope($"switch ({responseVariable}.Status)"))
            {
                foreach (var response in operation.Responses)
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

                    using (responseBody != null ? writer.Scope() : default)
                    {
                        ReferenceOrConstant value = default;

                        var valueVariable = new CodeWriterDeclaration("value");
                        switch (responseBody)
                        {
                            case ObjectResponseBody objectResponseBody:
                                writer.Line($"{responseBody.Type} {valueVariable:D} = default;");
                                writer.WriteDeserializationForMethods(
                                    objectResponseBody.Serialization,
                                    async,
                                    (w, v) => w.Line($"{valueVariable} = {v};"),
                                    responseVariable);
                                value = new Reference(valueVariable.ActualName, responseBody.Type);
                                break;
                            case StreamResponseBody _:
                                writer.Line($"var {valueVariable:D} = {message}.ExtractResponseContent();");
                                value = new Reference(valueVariable.ActualName, responseBody.Type);
                                break;
                            case ConstantResponseBody body:
                                writer.Append($"{returnType} {valueVariable:D} = ");
                                writer.WriteReferenceOrConstant(body.Value);
                                writer.Line($";");
                                value = new Reference(valueVariable.ActualName, responseBody.Type);
                                break;
                            case StringResponseBody _:
                                var streamReaderVariable = new CodeWriterDeclaration("streamReader");
                                writer.Line($"{typeof(StreamReader)} {streamReaderVariable:D} = new {typeof(StreamReader)}({message}.Response.ContentStream);");
                                writer.Append($"{returnType} {valueVariable:D} = ");
                                if (async)
                                {
                                    writer.Line($"await {streamReaderVariable}.ReadToEndAsync().ConfigureAwait(false);");
                                }
                                else
                                {
                                    writer.Line($"{streamReaderVariable}.ReadToEnd();");
                                }
                                value = new Reference(valueVariable.ActualName, responseBody.Type);
                                break;
                            default:
                                {
                                    if (returnType != null)
                                    {
                                        value = Constant.Default(returnType.WithNullable(true));
                                    }

                                    break;
                                }
                        }

                        switch (kind)
                        {
                            case ReturnKind.Response:
                                writer.Append($"return {responseVariable};");
                                break;
                            case ReturnKind.Headers:
                                writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue(headers, {responseVariable});");
                                break;
                            case ReturnKind.HeadersAndValue:
                                writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue");
                                if (!Equals(responseBody?.Type, operation.ReturnType))
                                {
                                    writer.Append($"<{operation.ReturnType}, {headersModelType}>");
                                }
                                writer.Append($"(");
                                writer.WriteReferenceOrConstant(value);
                                writer.Append($", headers, {responseVariable});");
                                break;
                            case ReturnKind.Value:
                                writer.Append($"return {typeof(Response)}.FromValue");
                                if (!Equals(responseBody?.Type, operation.ReturnType))
                                {
                                    writer.Append($"<{operation.ReturnType}>");
                                }
                                writer.Append($"(");
                                writer.WriteReferenceOrConstant(value);
                                writer.Append($", {responseVariable});");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                writer
                    .Line($"default:")
                    .Line($"throw new {typeof(RequestFailedException)}({responseVariable});");
            }
        }

        private enum ReturnKind
        {
            Response,
            Headers,
            HeadersAndValue,
            Value
        }
    }
}
