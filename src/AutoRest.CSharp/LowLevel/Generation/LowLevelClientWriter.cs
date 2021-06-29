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
using AutoRest.CSharp.Input;
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

        private void WriteClientMethodRequest(CodeWriter writer, LowLevelClientMethod clientMethod)
        {
            writer.WriteXmlDocumentationSummary($"Create Request for <see cref=\"{clientMethod.Name}\"/> and <see cref=\"{clientMethod.Name}Async\"/> operations.");
            foreach (Parameter parameter in clientMethod.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            RequestWriterHelpers.WriteRequestCreation(writer, clientMethod, lowLevel: true, "private");
        }

        private void WriteClientMethod(CodeWriter writer, LowLevelClientMethod clientMethod, bool async)
        {
            var parameters = clientMethod.Parameters;

            var responseType = async ? new CSharpType(typeof(Task<Response>)) : new CSharpType(typeof(Response));

            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            if (clientMethod.SchemaDocumentations != null)
            {
                writer.LineRaw("/// <remarks>");

                foreach (var schemaDoc in clientMethod.SchemaDocumentations)
                {
                    writer.Line($"/// Schema for <c>{schemaDoc.SchemaName}</c>:");
                    writer.LineRaw("/// <list type=\"table\">");
                    writer.LineRaw("///   <listheader>");
                    writer.LineRaw("///     <term>Name</term>");
                    writer.LineRaw("///     <term>Type</term>");
                    writer.LineRaw("///     <term>Required</term>");
                    writer.LineRaw("///     <term>Description</term>");
                    writer.LineRaw("///   </listheader>");
                    foreach (var row in schemaDoc.DocumentationRows)
                    {
                        writer.LineRaw("///   <item>");
                        writer.Line($"///     <term>{row.Name}</term>");
                        writer.Line($"///     <term>{row.Type}</term>");
                        writer.Line($"///     <term>{(row.Required ? "Yes" : "")}</term>");
                        if (string.IsNullOrEmpty(row.Description))
                        {
                            writer.Line($"///    <term></term>");
                        }
                        else
                        {
                            writer.WriteDocumentationLines("    <term>", "</term>", row.Description);
                        }
                        writer.LineRaw("///   </item>");
                    }
                    writer.LineRaw("/// </list>");
                }

                writer.LineRaw("/// </remarks>");
            }

            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Line($"#pragma warning disable AZC0002");
            writer.Append($"{clientMethod.Accessibility} virtual {asyncText} {responseType} {methodName}(");

            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            writer.Line($"#pragma warning restore AZC0002");

            using (writer.Scope())
            {
                writer.Line($"options ??= new {typeof(Azure.RequestOptions)}();");

                writer.Append($"{typeof(Azure.Core.HttpMessage)} message = {RequestWriterHelpers.CreateRequestMethodName(clientMethod.Name)}(");

                foreach (var parameter in clientMethod.Parameters)
                {
                     writer.Append($"{parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
                writer.Line();

                using (writer.Scope($"if (options.PerCallPolicy != null)"))
                {
                    writer.Line($"message.SetProperty (\"RequestOptionsPerCallPolicyCallback\", options.PerCallPolicy);");
                }

                var scopeVariable = new CodeWriterDeclaration("scope");
                writer.Line($"using var {scopeVariable:D} = {ClientDiagnosticsField}.CreateScope({clientMethod.Diagnostics.ScopeName:L});");

                writer.Line($"{scopeVariable}.Start();");

                using (writer.Scope($"try"))
                {
                    if (async)
                    {
                        writer.Line($"await {PipelineField:I}.SendAsync(message, options.CancellationToken).ConfigureAwait(false);");
                    }
                    else
                    {
                        writer.Line($"{PipelineField:I}.Send(message, options.CancellationToken);");
                    }

                    using (writer.Scope($"if (options.StatusOption == ResponseStatusOption.Default)"))
                    {
                        WriteStatusCodeSwitch(writer, clientMethod, async);
                    }
                    using (writer.Scope($"else"))
                    {
                        writer.Line($"return message.Response;");
                    }
                }

                using (writer.Scope($"catch ({typeof(Exception)} e)"))
                {
                    writer.Line($"{scopeVariable}.Failed(e);");
                    writer.Line($"throw;");
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
                    writer.Line($"return message.Response;");
                }

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
        private const string CredentialVariable = "credential";
        private const string OptionsVariable = "options";
        private const string APIVersionField = "apiVersion";
        private const string AuthorizationHeaderConstant = "AuthorizationHeader";
        private const string ScopesConstant = "AuthorizationScopes";
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;
        private const string KeyAuthField = "_keyCredential";
        private const string TokenAuthField = "_tokenCredential";

        private void WriteClientFields(CodeWriter writer, LowLevelRestClient client, BuildContext context)
        {
            writer.WriteXmlDocumentationSummary("The HTTP pipeline for sending and receiving REST requests and responses.");
            writer.Append($"public virtual {typeof(HttpPipeline)} {PipelineField}");
            writer.AppendRaw("{ get; }\n");

            foreach (var scheme in context.CodeModel.Security.GetSchemesOrAnonymous())
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme azureKeySecurityScheme:
                        writer.Line($"private const string {AuthorizationHeaderConstant} = {azureKeySecurityScheme.HeaderName:L};");
                        writer.Line($"private readonly {typeof(AzureKeyCredential)}? {KeyAuthField};");
                        break;
                    case AADTokenSecurityScheme aadTokenSecurityScheme:
                        writer.Append($"private readonly string[] {ScopesConstant} = ");
                        writer.Append($"{{ ");
                        foreach (var credentialScope in aadTokenSecurityScheme.Scopes)
                        {
                            writer.Append($"{credentialScope:L}, ");
                        }
                        writer.RemoveTrailingComma();
                        writer.Line($"}};");
                        writer.Line($"private readonly {typeof(TokenCredential)}? {TokenAuthField};");
                        break;
                }
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

            foreach (var scheme in context.CodeModel.Security.GetSchemesOrAnonymous())
            {
                WriteConstructor(writer, client, scheme, context);
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

        private CSharpType? GetCredentialType (SecurityScheme scheme)
        {
            switch (scheme)
            {
                case AzureKeySecurityScheme azureKeySecurityScheme:
                    return typeof(AzureKeyCredential);
                case AADTokenSecurityScheme aadTokenSecurityScheme:
                    return typeof(TokenCredential);
                case NoAuthSecurity noAuthSecurityScheme:
                    return null;
                default:
                    throw new NotImplementedException ($"Unknown security scheme: {scheme.GetType()}");
            }
        }

        private void WriteConstructor (CodeWriter writer, LowLevelRestClient client, SecurityScheme securityScheme, BuildContext context)
        {
            var ctorParams = client.GetConstructorParameters(GetCredentialType (securityScheme));

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
                if (securityScheme is AzureKeySecurityScheme)
                {
                    writer.Line($"{KeyAuthField} = {CredentialVariable};");
                    writer.Line($"var {authPolicy:D} = new {typeof(AzureKeyCredentialPolicy)}({KeyAuthField}, {AuthorizationHeaderConstant});");
                }
                else if (securityScheme is AADTokenSecurityScheme)
                {
                    writer.Line($"{TokenAuthField} = {CredentialVariable};");
                    writer.Line($"var {authPolicy:D} = new {typeof(BearerTokenAuthenticationPolicy)}({TokenAuthField}, {ScopesConstant});");
                }

                writer.Append($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new HttpPipelinePolicy[] ");
                writer.AppendRaw("{");
                writer.Append($" new {typeof(LowLevelCallbackPolicy)}() ");
                writer.AppendRaw("}, ");
                if (securityScheme is NoAuthSecurity)
                {
                    writer.AppendRaw("Array.Empty<HttpPipelinePolicy>()");
                }
                else
                {
                    writer.AppendRaw("new HttpPipelinePolicy[] {");
                    writer.Append($" {authPolicy:I} ");
                    writer.AppendRaw("}");
                }
                writer.LineRaw(", new ResponseClassifier());");

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
