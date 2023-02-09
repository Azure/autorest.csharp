// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using System.Collections.Generic;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtRestClientWriter
    {
        private const string UserAgentVariable = "userAgent";
        private const string UserAgentField = "_" + UserAgentVariable;

        public void WriteClient(CodeWriter writer, MgmtRestClient restClient)
        {
            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}"))
                {
                    WriteClientFields(writer, restClient);
                    WriteClientCtor(writer, restClient);

                    foreach (var (operation, method) in restClient.Methods)
                    {
                        // we will change the lro implemetation according to https://github.com/Azure/autorest.csharp/issues/3076#issuecomment-1421882331
                        bool isLongRunningOperation = operation.IsLongRunning;
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", restClient.Fields, null, true, restClient.Parameters, isLongRunningOperation ? true : false);
                        WriteOperation(writer, restClient, method, true, isLongRunningOperation);
                        WriteOperation(writer, restClient, method, false, isLongRunningOperation);
                    }
                }
            }
        }

        protected void WriteClientFields(CodeWriter writer, MgmtRestClient restClient)
        {
            writer.Line($"private readonly {typeof(TelemetryDetails)} {UserAgentField};");
            writer.WriteFieldDeclarations(restClient.Fields);
        }

        private static void WriteClientCtor(CodeWriter writer, MgmtRestClient restClient)
        {
            var constructorParameters = restClient.Parameters;
            var constructor = new ConstructorSignature(restClient.Type.Name, null, $"Initializes a new instance of {restClient.Type.Name}", MethodSignatureModifiers.Public, restClient.Parameters);

            writer.WriteMethodDocumentation(constructor);
            using (writer.WriteMethodDeclaration(constructor))
            {
                foreach (Parameter clientParameter in constructorParameters)
                {
                    var field = restClient.Fields.GetFieldByParameter(clientParameter);
                    if (field != null)
                    {
                        writer.WriteVariableAssignmentWithNullCheck($"{field.Name}", clientParameter);
                    }
                }
                writer.Line($"{UserAgentField} = new {typeof(TelemetryDetails)}(GetType().Assembly, {MgmtRestClient.ApplicationIdParameter.Name});");
            }
            writer.Line();
        }

        private static void WriteOperation(CodeWriter writer, MgmtRestClient restClient, RestClientMethod operation, bool async, bool isLongRunningOperation)
        {
            var returnType = operation.ReturnType != null
                ? new CSharpType(typeof(Response<>), operation.ReturnType)
                : new CSharpType(typeof(Response));

            var parameters = isLongRunningOperation
                ? new Parameter[] { KnownParameters.Message, KnownParameters.CancellationTokenParameter }
                : operation.Parameters.Append(KnownParameters.CancellationTokenParameter).ToArray();
            var method = new MethodSignature(operation.Name, operation.Summary, operation.Description, MethodSignatureModifiers.Public, returnType, null, parameters).WithAsync(async);

            writer
                .WriteXmlDocumentationSummary($"{method.Description}")
                .WriteMethodDocumentationSignature(method);

            using (writer.WriteMethodDeclaration(method))
            {
                writer.WriteParametersValidation(parameters);
                if (!isLongRunningOperation)
                {
                    var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);
                    writer.Line($"using var message = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});");
                }

                writer.WriteMethodCall(async, $"{restClient.Fields.PipelineField.Name}.SendAsync", $"{restClient.Fields.PipelineField.Name}.Send", $"{KnownParameters.Message.Name}, {KnownParameters.CancellationTokenParameter.Name}");

                ResponseWriterHelpers.WriteStatusCodeSwitch(writer, KnownParameters.Message.Name, operation, async, null);
            }
            writer.Line();
        }
    }
}
