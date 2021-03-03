// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelClientWriter
    {
        public void WriteClient(CodeWriter writer, Client client, BuildContext context)
        {
            var cs = client.Type;
            using (writer.Namespace(cs.Namespace + ".Protocol"))
            {
                writer.WriteXmlDocumentationSummary(client.Description);
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client, context);
                    WriteClientCtors(writer, client);

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
            CSharpType? bodyType = clientMethod.RestClientMethod.ReturnType;
            string responseType = async ? "Task<DynamicResponse>" : "DynamicResponse";

            if (async)
            {
                writer.UseNamespace("System.Threading.Tasks");
            }
            writer.UseNamespace("Azure");
            writer.UseNamespace("Azure.Core");

            var parameters = clientMethod.RestClientMethod.Parameters;
            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            for (int i = 0 ; i < parameters.Length; ++i)
            {
                if (i == 0)
                {
                    writer.WriteXmlDocumentationParameter("body", "The request body");
                }
                else
                {
                    Parameter parameter = parameters[i];
                    writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
                }
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public virtual {asyncText} {responseType} {methodName}(");


            for (int i = 0 ; i < parameters.Length; ++i)
            {
                if (i == 0)
                {
                    writer.Append($"{(useDynamic ? "dynamic" : "JsonData")} body, ");
                }
                else
                {
                    writer.WriteParameter(parameters[i]);
                }
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.Append($"DynamicRequest req = {RequestClientWriter.CreateRequestMethodName(clientMethod.Name)}(");
                foreach (var parameter in clientMethod.RestClientMethod.Parameters.Skip(1))
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

        private void WriteClientFields(CodeWriter writer, Client client, BuildContext context)
        {
            writer.Line($"private readonly string {EndpointProperty};");
            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            if (context.Configuration.CredentialTypes.Contains("AzureKeyCredential", StringComparer.OrdinalIgnoreCase))
            {
                writer.Line($"private const string AuthorizationHeader = \"{context.Configuration.CredentialHeaderName}\";\n");
            }
        }

        private void WriteClientCtors(CodeWriter writer, Client client)
        {
            WriteEmptyConstructor(writer, client);
            WriteSimplifiedConstructor(writer, client);
            WriteFullConstructor(writer, client);
        }

        private void WriteEmptyConstructor (CodeWriter writer, Client client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private void WriteSimplifiedConstructor (CodeWriter writer, Client client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            writer.WriteXmlDocumentationParameter(KeyCredentialVariable, "The credentials to use.");

            writer.Append($"public {client.Type.Name:D}(");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Append($", AzureKeyCredential {KeyCredentialVariable}");
            writer.Line($") : this(endpoint, credential, new {typeof(Azure.Core.ProtocolClientOptions)}())");
            using (writer.Scope())
            {
            }
            writer.Line();
        }

        private void WriteFullConstructor (CodeWriter writer, Client client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            writer.WriteXmlDocumentationParameter(KeyCredentialVariable, "The credentials to use.");
            writer.WriteXmlDocumentationParameter(ProtocolOptions, "Options to control the underlying operations.");

            writer.Append($"internal {client.Type.Name:D}(");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Append($", AzureKeyCredential {KeyCredentialVariable}");
            writer.Append($", {typeof(Azure.Core.ProtocolClientOptions)} {ProtocolOptions}");
            writer.Line($")");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks (client.RestClient.Parameters);
                using (writer.Scope($"if ({KeyCredentialVariable} == null)"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({KeyCredentialVariable}));");
                }
                writer.Line($"this.{EndpointProperty} = {EndpointParameter};");
                writer.Line($"{PipelineField} =  {typeof(HttpPipelineBuilder)}.Build({ProtocolOptions}, new {typeof(AzureKeyCredentialPolicy)}({KeyCredentialVariable}, AuthorizationHeader));");
            }
            writer.Line();
        }
    }
}
