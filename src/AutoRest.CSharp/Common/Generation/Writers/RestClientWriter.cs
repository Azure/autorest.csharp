// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using Response = Azure.Response;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class RestClientWriter
    {
        public void WriteClient(CodeWriter writer, RestClient restClient)
        {
            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}", scopeDeclarations: restClient.Fields.ScopeDeclarations))
                {
                    var responseClassifierTypes = new List<ResponseClassifierType>();
                    writer.WriteFieldDeclarations(restClient.Fields);
                    WriteClientCtor(writer, restClient);

                    foreach (var legacyMethod in restClient.Methods)
                    {
                        writer.WriteMethod(legacyMethod.CreateMessageMethod);

                        WriteOperation(writer, legacyMethod.RestClientMethod, restClient.Fields, true);
                        WriteOperation(writer, legacyMethod.RestClientMethod, restClient.Fields, false);
                        if (legacyMethod.ProtocolMethod is {} protocolMethod)
                        {
                            LowLevelClientWriter.WriteProtocolMethods(writer, restClient.Fields, protocolMethod);
                            responseClassifierTypes.Add(protocolMethod.ResponseClassifier);
                        }
                    }

                    LowLevelClientWriter.WriteResponseClassifierMethod(writer, responseClassifierTypes.Distinct());
                }
            }
        }

        private static void WriteClientCtor(CodeWriter writer, RestClient restClient)
        {
            var constructor = restClient.Constructor;
            writer.WriteMethodDocumentation(constructor);
            using (writer.WriteMethodDeclaration(constructor))
            {
                foreach (Parameter clientParameter in constructor.Parameters)
                {
                    var field = restClient.Fields.GetFieldByParameter(clientParameter);
                    if (field != null)
                    {
                        writer.WriteVariableAssignmentWithNullCheck($"{field.Name}", clientParameter);
                    }
                }
            }
            writer.Line();
        }

        private static void WriteOperation(CodeWriter writer, RestClientMethod operation, ClientFields fields, bool async)
        {
            using var methodScope = writer.AmbientScope();

            CSharpType? bodyType = operation.ReturnType;
            CSharpType? headerModelType = operation.HeaderModel?.Type;
            CSharpType returnType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };

            var parameters = operation.Parameters.Where(p => p.Name != KnownParameters.RequestContext.Name).Append(KnownParameters.CancellationTokenParameter).ToArray();
            var method = new MethodSignature(operation.Name, operation.Summary, operation.Description, MethodSignatureModifiers.Public, returnType, null, parameters).WithAsync(async);

            writer.WriteXmlDocumentationSummary($"{method.SummaryText}")
                .WriteXmlDocumentationParameters(method.Parameters)
                .WriteXmlDocumentationRequiredParametersException(method.Parameters)
                .WriteXmlDocumentation("remarks", $"{method.DescriptionText}");

            if (method.ReturnDescription != null)
            {
                writer.WriteXmlDocumentationReturns(method.ReturnDescription);
            }
            using (writer.WriteMethodDeclaration(method))
            {
                writer.WriteParameterNullChecks(parameters);
                var messageVariable = new CodeWriterDeclaration("message");
                WriteFuncBodyWithSend(writer, messageVariable, operation, fields.PipelineField.Name, async);
                WriteStatusCodeSwitch(writer, messageVariable, operation, async, fields.ClientDiagnosticsProperty);
            }
            writer.Line();
        }

        private static void WriteFuncBodyWithSend(CodeWriter writer, CodeWriterDeclaration messageVariable, RestClientMethod operation, string pipelineName, bool async)
        {
            var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);

            writer
                .Line($"using var {messageVariable:D} = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});")
                .WriteMethodCall(async, $"{pipelineName}.SendAsync", $"{pipelineName}.Send", $"{messageVariable}, {KnownParameters.CancellationTokenParameter.Name}");
        }

        private static void WriteStatusCodeSwitch(CodeWriter writer, CodeWriterDeclaration messageVariable, RestClientMethod operation, bool async, FieldDeclaration clientDiagnosticsField)
        {
            ResponseWriterHelpers.WriteStatusCodeSwitch(writer, $"{messageVariable.ActualName}", operation, async, clientDiagnosticsField);
        }
    }
}
