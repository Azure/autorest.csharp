// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public void WriteClient(CodeWriter writer, DataPlaneRestClient restClient)
        {
            var responseClassifierTypes = new List<LowLevelClientWriter.ResponseClassifierType>();

            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}"))
                {
                    writer.WriteFieldDeclarations(restClient.Fields);
                    WriteClientCtor(writer, restClient);
                    foreach (var method in restClient.Methods)
                    {
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", restClient.Fields, null, false, restClient.Parameters);
                        WriteOperation(writer, restClient, method, true);
                        WriteOperation(writer, restClient, method, false);
                        var protocolMethod = restClient.ProtocolMethods.FirstOrDefault(m => m.RequestMethod.Operation.Equals(method.Operation));
                        if (protocolMethod != null)
                        {
                            WriteProtocolMethods(writer, restClient, protocolMethod, responseClassifierTypes);
                        }
                    }

                    LowLevelClientWriter.WriteResponseClassifierMethod(writer, responseClassifierTypes);
                }
            }
        }

        private static void WriteProtocolMethods(CodeWriter writer, DataPlaneRestClient restClient, LowLevelClientMethod protocolMethod, List<LowLevelClientWriter.ResponseClassifierType> responseClassifierTypes)
        {
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

        private static void WriteClientCtor(CodeWriter writer, DataPlaneRestClient restClient)
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

        private static void WriteOperation(CodeWriter writer, DataPlaneRestClient restClient, RestClientMethod operation, bool async)
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

            var parameters = operation.Parameters.Append(KnownParameters.CancellationTokenParameter).ToArray();
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
                var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);

                writer
                    .Line($"using var {messageVariable:D} = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});")
                    .WriteMethodCall(async, $"{restClient.Fields.PipelineField.Name}.SendAsync", $"{restClient.Fields.PipelineField.Name}.Send", $"{messageVariable}, {KnownParameters.CancellationTokenParameter.Name}");

                ResponseWriterHelpers.WriteStatusCodeSwitch(writer, messageVariable.ActualName, operation, async, restClient.Fields.GetFieldByParameter(KnownParameters.ClientDiagnostics));
            }
            writer.Line();
        }
    }
}
