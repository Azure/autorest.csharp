﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
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
        internal delegate void WritePageFuncBody(CodeWriter writer, CodeWriterDeclaration messageVariable, RestClientMethod operation, string pipelineName, bool async);
        internal delegate void WriteStatusCodeImplementation(CodeWriter writer, string messageVariable, RestClientMethod operation, bool async, FieldDeclaration fieldDeclaration);

        public void WriteClient(CodeWriter writer, DataPlaneRestClient restClient)
        {
            var responseClassifierTypes = new List<LowLevelClientWriter.ResponseClassifierType>();

            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}", scopeDeclarations: restClient.Fields.ScopeDeclarations))
                {
                    writer.WriteFieldDeclarations(restClient.Fields);
                    WriteClientCtor(writer, restClient);
                    foreach (var method in restClient.Methods)
                    {
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", restClient.Fields, null, false, restClient.Parameters);
                        WriteOperation(writer, method, restClient.Fields.PipelineField.Name, true, WritePageFuncBodyWithSend, "", WriteStatusCodeSwitch, restClient.Fields.GetFieldByParameter(KnownParameters.ClientDiagnostics));
                        WriteOperation(writer, method, restClient.Fields.PipelineField.Name, false, WritePageFuncBodyWithSend, "", WriteStatusCodeSwitch, restClient.Fields.GetFieldByParameter(KnownParameters.ClientDiagnostics));
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

            var longRunning = protocolMethod.LongRunning;
            if (longRunning != null)
            {
                LowLevelClientWriter.WriteLongRunningOperationMethod(writer, protocolMethod, restClient.Fields, longRunning, true);
                LowLevelClientWriter.WriteLongRunningOperationMethod(writer, protocolMethod, restClient.Fields, longRunning, false);
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

        public static void WriteOperation(CodeWriter writer, RestClientMethod operation, string pipelineName, bool async, WritePageFuncBody writePageFuncBody, string methodNameSuffix = "", WriteStatusCodeImplementation? writeStatusCodeImplementation = null, FieldDeclaration? fieldDeclaration = null)
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

            var parameters = operation.Parameters.Any(p => p.Name == KnownParameters.RequestContext.Name) ?
                operation.Parameters.ToList().Where(p => p.Name != KnownParameters.RequestContext.Name).Append(KnownParameters.CancellationTokenParameter).ToArray() :
                operation.Parameters.Append(KnownParameters.CancellationTokenParameter).ToArray();
            var method = new MethodSignature($"{operation.Name}{methodNameSuffix}", operation.Summary, operation.Description, MethodSignatureModifiers.Public, returnType, null, parameters).WithAsync(async);

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
                writePageFuncBody(writer, messageVariable, operation, pipelineName, async);

                if (writeStatusCodeImplementation != null && fieldDeclaration != null)
                {
                    writeStatusCodeImplementation(writer, messageVariable.ActualName, operation, async, fieldDeclaration);
                }
            }
            writer.Line();
        }

        public static void WritePageFuncBodyWithSend(CodeWriter writer, CodeWriterDeclaration messageVariable, RestClientMethod operation, string pipelineName, bool async)
        {
            var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);

            writer
                .Line($"using var {messageVariable:D} = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});")
                .WriteMethodCall(async, $"{pipelineName}.SendAsync", $"{pipelineName}.Send", $"{messageVariable}, {KnownParameters.CancellationTokenParameter.Name}");
        }

        public static void WritePageFuncBodyWithProcessMessage(CodeWriter writer, CodeWriterDeclaration messageVariable, RestClientMethod operation, string pipelineName, bool async)
        {
            var contextVariable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            writer.Line($"{typeof(RequestContext)} {contextVariable:D} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");

            var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);
            var responseVariable = new CodeWriterDeclaration("response");

            writer
                .Line($"using var {messageVariable:D} = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});")
                .Append($"{typeof(Response)} {responseVariable:D} = ")
                .WriteMethodCall(async, $"{pipelineName}.ProcessMessageAsync", $"{pipelineName}.ProcessMessage", $"{messageVariable}, {KnownParameters.RequestContext.Name}");

            writer.Line($"return {typeof(Response)}.{nameof(Response.FromValue)}({operation.ReturnType}.FromResponse({responseVariable:I}), {responseVariable:I});");
        }

        public static void WriteStatusCodeSwitch(CodeWriter writer, string messageVariable, RestClientMethod operation, bool async, FieldDeclaration fieldDeclaration)
        {
            ResponseWriterHelpers.WriteStatusCodeSwitch(writer, messageVariable, operation, async, fieldDeclaration);
        }
    }
}
