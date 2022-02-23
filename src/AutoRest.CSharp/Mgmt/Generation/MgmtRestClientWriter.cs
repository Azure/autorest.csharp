// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using Azure.ResourceManager.Core;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtRestClientWriter
    {
        private const string UserAgentVariable = "userAgent";
        private const string UserAgentField = "_" + UserAgentVariable;

        private static readonly Parameter ClientDiagnosticsParameter = new("clientDiagnostics", "The handler for diagnostic messaging in the client", new CSharpType(typeof(ClientDiagnostics)), null, false);
        private static readonly Parameter PipelineParameter = new("pipeline", "The HTTP pipeline for sending and receiving REST requests and responses", new CSharpType(typeof(HttpPipeline)), null, false);
        private static readonly Parameter ApplicationIdParameter = new("applicationId", "The application id to use for user agent", new CSharpType(typeof(string)), null, false);
        private static readonly Parameter CancellationTokenParameter = new("cancellationToken", "The cancellation token to use", new CSharpType(typeof(CancellationToken)), Constant.NewInstanceOf(typeof(CancellationToken)), true);
        private static readonly Parameter MessageParameter = new("message", null, new CSharpType(typeof(HttpMessage)), null, false);

        public void WriteClient(CodeWriter writer, MgmtRestClient restClient)
        {
            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}"))
                {
                    WriteClientFields(writer, restClient);
                    WriteClientCtor(writer, restClient);

                    foreach (var method in restClient.Methods)
                    {
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", restClient.Fields, null, true, restClient.Parameters);
                        if (!method.Operation.IsLongRunning)
                        {
                            WriteOperation(writer, restClient, method, true);
                            WriteOperation(writer, restClient, method, false);
                        }
                    }
                }
            }
        }

        protected void WriteClientFields(CodeWriter writer, MgmtRestClient restClient)
        {
            writer.Line($"private readonly {typeof(string)} {UserAgentField};");
            writer.WriteFieldDeclarations(restClient.Fields);
        }

        private static void WriteClientCtor(CodeWriter writer, MgmtRestClient restClient)
        {
            var constructorParameters = new[]{ ClientDiagnosticsParameter, PipelineParameter, ApplicationIdParameter }.Concat(restClient.Parameters).ToArray();
            var constructor = new ConstructorSignature(restClient.Type.Name, $"Initializes a new instance of {restClient.Type.Name}", "public", constructorParameters);

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
                writer.Line($"{UserAgentField} = {typeof(HttpMessageUtilities)}.GetUserAgentName(this, {ApplicationIdParameter.Name});");
            }
            writer.Line();
        }

        private static void WriteOperation(CodeWriter writer, MgmtRestClient restClient, RestClientMethod operation, bool async)
        {
            var returnType = operation.ReturnType != null
                ? new CSharpType(typeof(Response<>), operation.ReturnType)
                : new CSharpType(typeof(Response));

            var parameters = operation.Parameters.Append(CancellationTokenParameter).ToArray();
            var method = new MethodSignature(operation.Name, operation.Description, operation.Accessibility, returnType, null, parameters);

            if (async)
            {
                method = method.MakeAsync();
            }

            writer.WriteMethodDocumentation(method);
            using (writer.WriteMethodDeclaration(method))
            {
                writer.WriteParametersValidation(parameters);
                var messageVariable = new CodeWriterDeclaration("message");
                var requestMethodName = RequestWriterHelpers.CreateRequestMethodName(operation.Name);

                writer
                    .Line($"using var {messageVariable:D} = {requestMethodName}({operation.Parameters.GetIdentifiersFormattable()});")
                    .WriteMethodCall(async, $"{restClient.Fields.PipelineField.Name}.SendAsync", $"{restClient.Fields.PipelineField.Name}.Send", $"{messageVariable}, {CancellationTokenParameter.Name}");

                ResponseWriterHelpers.WriteStatusCodeSwitch(writer, messageVariable.ActualName, operation, async);
            }
        }
    }
}
