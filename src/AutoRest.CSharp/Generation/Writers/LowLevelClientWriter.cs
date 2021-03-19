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

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelClientWriter
    {
        public void WriteClient(CodeWriter writer, RestClient client, BuildContext context)
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
                        WriteClientMethod(writer, clientMethod, true);
                        WriteClientMethod(writer, clientMethod, false);
                        WriteClientMethodRequest(writer, clientMethod);
                    }
                }
            }
        }

        private void WriteClientMethodRequest(CodeWriter writer, RestClientMethod clientMethod)
        {
            RequestClientWriter.WriteRequestCreation(writer, clientMethod, lowLevel: true);
        }

        private void WriteClientMethod(CodeWriter writer, RestClientMethod clientMethod, bool async)
        {
            var parameters = clientMethod.Parameters;

            CSharpType? bodyType = clientMethod.ReturnType;
            var responseType = async ? new CSharpType(typeof(Task<Response>)) : new CSharpType(typeof(Response));

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
            writer.Append($"public virtual {asyncText} {responseType} {methodName}(RequestContent body, ");

            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.Append($"{typeof(Azure.Core.Request)} req = {RequestClientWriter.CreateRequestMethodName(clientMethod.Name)}(body, ");

                foreach (var parameter in clientMethod.Parameters)
                {
                     writer.Append($"{parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
                writer.Line();

                if (async)
                {
                    writer.Line($"return await {PipelineField:I}.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"return {PipelineField:I}.SendRequest(req, cancellationToken);");
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

        private bool HasKeyAuth (BuildContext context) => context.Configuration.CredentialTypes.Contains("AzureKeyCredential", StringComparer.OrdinalIgnoreCase);
        private bool HasTokenAuth (BuildContext context) => context.Configuration.CredentialTypes.Contains("TokenCredential", StringComparer.OrdinalIgnoreCase);

        private void WriteClientFields(CodeWriter writer, RestClient client, BuildContext context)
        {
            // Endpoint can either be Uri or string
            var endpointType = client.Parameters.First(x => x.Name == EndpointParameter).Type;

            writer.Line($"private readonly {endpointType.Name} {EndpointProperty};");
            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            var apiVersion = client.Parameters.FirstOrDefault(x => x.IsApiVersionParameter);
            if (apiVersion?.DefaultValue != null)
            {
                writer.Line($"private readonly string {apiVersion.Name} = {apiVersion.DefaultValue!.Value.Value:L};");
            }

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
            writer.Line();
        }

        private void WriteClientCtors(CodeWriter writer, RestClient client, BuildContext context)
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

        private void WriteEmptyConstructor (CodeWriter writer, RestClient client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private void WriteSimplifiedConstructor (CodeWriter writer, RestClient client, bool keyCredential)
        {
            var ctorParams = client.GetConstructorParameters(keyCredential ? typeof(AzureKeyCredential) : typeof(TokenCredential));

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
            writer.Append($")");

            // The full ctor params can be in a different order, the options are not necessarily at the end
            var fullCtorParams = client.GetConstructorParameters(keyCredential ? typeof(AzureKeyCredential) : typeof(TokenCredential), true);
            writer.Append($": this(");
            foreach (Parameter parameter in fullCtorParams)
            {
                if (parameter.Type.Name != "ProtocolClientOptions") {
                    writer.Append($"{parameter.Name:D}");
                }
                else {
                    writer.Append($"new {typeof(Azure.Core.ProtocolClientOptions)}()");
                }
                writer.AppendRaw(", ");
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
            }
            writer.Line();
        }

        private void WriteFullConstructor (CodeWriter writer, RestClient client, bool keyCredential)
        {
            var ctorParams = client.GetConstructorParameters(keyCredential ? typeof(AzureKeyCredential) : typeof(TokenCredential), true);

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
                writer.WriteParameterNullChecks (client.Parameters);
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
