// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelClientWriter
    {
        public void WriteClient(CodeWriter writer, Client client, BuildContext context)
        {
            var cs = client.Type;
            // Client type should have public constructor with equivalent parameters not taking ClientOptions type as last argument
            writer.Line ($"#pragma warning disable AZC0007\n");

            using (writer.Namespace(cs.Namespace + ".Protocol"))
            {
                writer.WriteXmlDocumentationSummary(client.Description);
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client, context);
                    WriteClientCtors(writer, client, context);

                    foreach (var clientMethod in client.Methods)
                    {
                        WriteClientMethod(writer, clientMethod, true, false);
                        WriteClientMethod(writer, clientMethod, true, true);
                        WriteClientMethod(writer, clientMethod, false, false);
                        WriteClientMethod(writer, clientMethod, false, true);
                        WriteClientMethodRequest(writer, clientMethod);
                    }

                    writer.Line();
                    writer.Line($"private static JsonData ToJsonData(object value)");
                    writer.Line($"{{");
                    writer.Line($"    if (value is JsonData)");
                    writer.Line($"    {{");
                    writer.Line($"        return (JsonData)value;");
                    writer.Line($"    }}");
                    writer.Line($"    return new JsonData(value);");
                    writer.Line($"}}");
                }
            }
        }

        private void WriteClientMethodRequest(CodeWriter writer, ClientMethod clientMethod)
        {
            RequestClientWriter.WriteRequestCreation(writer, clientMethod.RestClientMethod, lowLevel: true);
        }

        private void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, bool async, bool useDynamic)
        {
            var parameters = clientMethod.RestClientMethod.Parameters;

            CSharpType? bodyType = clientMethod.RestClientMethod.ReturnType;
            string responseType = async ? "Task<DynamicResponse>" : "DynamicResponse";

            if (async)
            {
                writer.UseNamespace("System.Threading.Tasks");
            }
            writer.UseNamespace("Azure");
            writer.UseNamespace("Azure.Core");

            writer.WriteXmlDocumentationSummary(clientMethod.Description);
            writer.WriteXmlDocumentationParameter("body", "The request body");
            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public virtual {asyncText} {responseType} {methodName}(");
            writer.Append($"{(useDynamic ? "dynamic" : "JsonData")} body, ");


            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.Append($"DynamicRequest req = {RequestClientWriter.CreateRequestMethodName(clientMethod.Name)}(");
                foreach (var parameter in clientMethod.RestClientMethod.Parameters)
                {
                     writer.Append($"{parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
                writer.Line();

                if (useDynamic)
                {
                    writer.Line($"req.Content = {typeof(Azure.Core.DynamicContent)}.Create(ToJsonData(body));");
                }
                else
                {
                    writer.Line($"req.Content = {typeof(Azure.Core.DynamicContent)}.Create(body);");
                }

                if (async)
                {
                    writer.Line($"return await req.SendAsync(cancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"return req.Send(cancellationToken);");
                }
            }

            writer.Line();
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private const string EndpointProperty = "endpoint";
        private const string EndpointParameter = "endpoint";
        private const string PipelineVariable = "pipeline";
        private const string PipelineField = "_" + PipelineVariable;
        private const string KeyCredentialVariable = "credential";
        private const string ProtocolOptions = "options";
        private const string AuthorizationHeaderConstant = "AuthorizationHeader";
        private const string ScopesConstant = "AuthorizationScopes";
        private const string APIConstant = "apiVersion";

        private bool HasKeyAuth (BuildContext context) => context.Configuration.CredentialTypes.Contains("AzureKeyCredential", StringComparer.OrdinalIgnoreCase);
        private bool HasTokenAuth (BuildContext context) => context.Configuration.CredentialTypes.Contains("TokenCredential", StringComparer.OrdinalIgnoreCase);

        private void WriteClientFields(CodeWriter writer, Client client, BuildContext context)
        {
            writer.Line($"private readonly string {EndpointProperty};");
            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            var apiVersion = client.RestClient.Parameters.FirstOrDefault(x => x.IsApiVersionParameter);
            if (apiVersion?.DefaultValue != null)
            {
                writer.Line($"private readonly string {APIConstant} = \"{apiVersion.DefaultValue!.Value.Value}\";");
            }

            if (HasKeyAuth (context))
            {
                writer.Line($"private const string {AuthorizationHeaderConstant} = \"{context.Configuration.CredentialHeaderName}\";");
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
            writer.Line();
        }

        private void WriteClientCtors(CodeWriter writer, Client client, BuildContext context)
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
                WriteSimplifiedConstructor(writer, client, true);
                WriteFullConstructor(writer, client, true);
            }
            if (hasTokenAuth)
            {
                WriteSimplifiedConstructor(writer, client, false);
                WriteFullConstructor(writer, client, false);
            }
        }

        private void WriteEmptyConstructor (CodeWriter writer, Client client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private void WriteSimplifiedConstructor (CodeWriter writer, Client client, bool keyCredential)
        {
            var ctorParams = client.GetClientConstructorParameters(keyCredential ? typeof(AzureKeyCredential) : typeof(TokenCredential));

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.Append($"public {client.Type.Name:D}(");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($") : this(endpoint, credential, new {typeof(Azure.Core.ProtocolClientOptions)}())");
            using (writer.Scope())
            {
            }
            writer.Line();
        }

        private void WriteFullConstructor (CodeWriter writer, Client client, bool keyCredential)
        {
            var ctorParams = client.GetClientConstructorParameters(keyCredential ? typeof(AzureKeyCredential) : typeof(TokenCredential), true);

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.Append($"internal {client.Type.Name:D}(");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($")");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks (client.RestClient.Parameters);
                using (writer.Scope($"if ({KeyCredentialVariable} == null)"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({KeyCredentialVariable}));");
                }
                writer.Line($"this.{EndpointProperty} = {EndpointParameter};");
                if (keyCredential)
                {
                    writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({ProtocolOptions}, new {typeof(AzureKeyCredentialPolicy)}({KeyCredentialVariable}, {AuthorizationHeaderConstant}));");
                }
                else
                {
                    writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({ProtocolOptions}, new {typeof(BearerTokenAuthenticationPolicy)}({KeyCredentialVariable}, {ScopesConstant}));");
                }
            }
            writer.Line();
        }
    }
}
