// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Common.Output.Builders;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelClientWriter
    {
        public void WriteClient(CodeWriter writer, LowLevelRestClient client, BuildContext context)
        {
            var cs = client.Type;
            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary(client.Description);
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client, context);
                    WriteClientCtors(writer, client, context);

                    foreach (var clientMethod in client.Methods)
                    {
                        WriteClientMethod(writer, clientMethod, true);
                        WriteClientMethod(writer, clientMethod, false);
                        WriteClientMethodRequest(writer, clientMethod);
                    }
                }
            }
        }

        private void WriteClientMethodRequest(CodeWriter writer, RestClientMethod clientMethod)
        {
            writer.WriteXmlDocumentationSummary($"Create Request for <see cref=\"{clientMethod.Name}\"/> and <see cref=\"{clientMethod.Name}Async\"/> operations.");
            foreach (Parameter parameter in clientMethod.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            RequestWriterHelpers.WriteRequestCreation(writer, clientMethod, lowLevel: true, "private");
        }

        private void WriteClientMethod(CodeWriter writer, RestClientMethod clientMethod, bool async)
        {
            var parameters = clientMethod.Parameters;

            var responseType = async ? new CSharpType(typeof(Task<Response>)) : new CSharpType(typeof(Response));

            writer.WriteXmlDocumentationSummary(clientMethod.Description);
            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"{clientMethod.Accessibility} virtual {asyncText} {responseType} {methodName}(");

            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($")");

            using (writer.Scope())
            {
                writer.Line($"requestOptions ??= new {typeof(Azure.RequestOptions)}();");

                writer.Append($"{typeof(Azure.Core.HttpMessage)} message = {RequestWriterHelpers.CreateRequestMethodName(clientMethod.Name)}(");

                foreach (var parameter in clientMethod.Parameters)
                {
                     writer.Append($"{parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
                writer.Line();

                using (writer.Scope($"if (requestOptions.PerCallPolicy != null)"))
                {
                    writer.Line($"message.SetProperty (\"RequestOptionsPerCallPolicyCallback\", requestOptions.PerCallPolicy);");
                }

                if (async)
                {
                    writer.Line($"await {PipelineField:I}.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"{PipelineField:I}.Send(message, requestOptions.CancellationToken);");
                }

                using (writer.Scope($"if (requestOptions.StatusOption == ResponseStatusOption.Default)"))
                {
                    WriteStatusCodeSwitch(writer, clientMethod, async);
                }
                using (writer.Scope($"else"))
                {
                    writer.Line($"return message.Response;");
                }
            }

            writer.Line();
        }

        private void WriteStatusCodeSwitch(CodeWriter writer, RestClientMethod clientMethod, bool async)
        {
             using (writer.Scope($"switch (message.Response.Status)"))
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
                }
                writer.Line($"return message.Response;");

                writer.Line($"default:");
                if (async)
                {
                    writer.Line($"throw await {ClientDiagnosticsField}.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw {ClientDiagnosticsField}.CreateRequestFailedException(message.Response);");
                }
            }
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private const string PipelineField = "Pipeline";
        private const string KeyCredentialVariable = "credential";
        private const string OptionsVariable = "options";
        private const string APIVersionField = "apiVersion";
        private const string AuthorizationHeaderConstant = "AuthorizationHeader";
        private const string ScopesConstant = "AuthorizationScopes";
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;

        private bool HasKeyAuth (BuildContext context) => context.Configuration.CredentialTypes.Contains("AzureKeyCredential", StringComparer.OrdinalIgnoreCase);
        private bool HasTokenAuth (BuildContext context) => context.Configuration.CredentialTypes.Contains("TokenCredential", StringComparer.OrdinalIgnoreCase);

        private void WriteClientFields(CodeWriter writer, LowLevelRestClient client, BuildContext context)
        {
            writer.WriteXmlDocumentationSummary("The HTTP pipeline for sending and receiving REST requests and responses.");
            writer.Append($"public virtual {typeof(HttpPipeline)} {PipelineField}");
            writer.AppendRaw("{ get; }\n");

            if (HasKeyAuth (context))
            {
                writer.Line($"private const string {AuthorizationHeaderConstant} = {context.Configuration.CredentialHeaderName:L};");
            }
            if (HasTokenAuth (context))
            {
                writer.Append($"private readonly string[] {ScopesConstant} = ");
                writer.Append($"{{ ");
                foreach (var credentialScope in context.Configuration.CredentialScopes)
                {
                    writer.Append($"{credentialScope:L}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($"}};");
            }

            foreach (Parameter clientParameter in client.Parameters)
            {
                writer.Line($"private {clientParameter.Type} {clientParameter.Name};");
            }

            writer.Line($"private readonly string {APIVersionField};");
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");

            writer.Line();
        }

        private void WriteClientCtors(CodeWriter writer, LowLevelRestClient client, BuildContext context)
        {
            WriteEmptyConstructor(writer, client);

            bool hasKeyAuth = HasKeyAuth (context);
            bool hasTokenAuth = HasTokenAuth (context);
            if (!hasKeyAuth && !hasTokenAuth)
            {
                throw new InvalidOperationException ("Has neither Key or Token credential-types?");
            }

            if (hasKeyAuth)
            {
                WriteConstructor(writer, client, true, context);
            }
            if (hasTokenAuth)
            {
                WriteConstructor(writer, client, false, context);
            }
        }

        private void WriteEmptyConstructor (CodeWriter writer, LowLevelRestClient client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private void WriteConstructor (CodeWriter writer, LowLevelRestClient client, bool keyCredential, BuildContext context)
        {
            var ctorParams = client.GetConstructorParameters(keyCredential ? typeof(AzureKeyCredential) : typeof(TokenCredential));

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            writer.WriteXmlDocumentationParameter(OptionsVariable, "The options for configuring the client.");

            var clientOptionsName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            writer.Append($"public {client.Type.Name:D}(");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteParameter(parameter);
            }
            writer.Append($" {clientOptionsName}ClientOptions {OptionsVariable} = null)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks (ctorParams);
                writer.Line();

                writer.Line($"{OptionsVariable} ??= new {clientOptionsName}ClientOptions();");
                writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}({OptionsVariable});");


                var authPolicy = new CodeWriterDeclaration("authPolicy");
                if (keyCredential)
                {
                    writer.Line($"var {authPolicy:D} = new {typeof(AzureKeyCredentialPolicy)}({KeyCredentialVariable}, {AuthorizationHeaderConstant});");
                }
                else
                {
                    writer.Line($"var {authPolicy:D} = new {typeof(BearerTokenAuthenticationPolicy)}({KeyCredentialVariable}, {ScopesConstant});");
                }
                var policies = new CodeWriterDeclaration("policies");

                writer.Append($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new HttpPipelinePolicy[] ");
                writer.AppendRaw("{");
                writer.Append($" {authPolicy:I}, ");
                writer.Append($" new {typeof(LowLevelCallbackPolicy)}() ");

                writer.LineRaw("});");

                foreach (Parameter clientParameter in client.Parameters)
                {
                    writer.Line($"this.{clientParameter.Name} = {clientParameter.Name};");
                }
                writer.Line($"this.{APIVersionField} = {OptionsVariable}.Version;");
            }
            writer.Line();
        }
    }
}
