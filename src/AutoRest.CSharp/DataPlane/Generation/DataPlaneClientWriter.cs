// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class DataPlaneClientWriter : ClientWriter
    {
        public void WriteClient(CodeWriter writer, DataPlaneClient client, DataPlaneOutputLibrary library)
        {
            var cs = client.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{client.Description}");
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client.RestClient, true);
                    WriteClientCtors(writer, client, library);

                    foreach (var pagingMethod in client.RestClient.Methods.OrderBy(m => m.Order).SelectMany(m => m.Convenience))
                    {
                        WriteMethod(writer, pagingMethod);
                    }
                }
            }
        }

        private string CreateStartOperationName(string name, bool async) => $"Start{name}{(async ? "Async" : string.Empty)}";

        private const string EndpointVariable = "endpoint";
        private const string CredentialVariable = "credential";
        private const string OptionsVariable = "options";

        private void WriteClientCtors(CodeWriter writer, DataPlaneClient client, DataPlaneOutputLibrary library)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();

            var clientOptionsName = library.ClientOptions!.Declaration.Name;

            if (library.Authentication.ApiKey != null)
            {
                CSharpType credentialType = typeof(AzureKeyCredential);
                var ctorParams = RestClientBuilder.GetConstructorParameters(client.RestClient.ClientParameters, credentialType);
                writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
                foreach (Parameter parameter in ctorParams)
                {
                    writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
                }
                writer.WriteXmlDocumentationParameter(OptionsVariable, $"The options for configuring the client.");

                writer.Append($"public {client.Type.Name:D}(");
                foreach (Parameter parameter in ctorParams)
                {
                    writer.WriteParameter(parameter);
                }
                writer.Append($" {clientOptionsName} {OptionsVariable} = null)");

                using (writer.Scope())
                {
                    writer.WriteParameterNullChecks(ctorParams);
                    writer.Line();

                    writer.Line($"{OptionsVariable} ??= new {clientOptionsName}();");
                    writer.Line($"{ClientDiagnosticsField.GetReferenceFormattable()} = new {typeof(ClientDiagnostics)}({OptionsVariable});");
                    writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new {typeof(AzureKeyCredentialPolicy)}({CredentialVariable}, \"{library.Authentication.ApiKey.Name}\"));");
                    writer.Append($"this.RestClient = new {client.RestClient.Type}(");
                    foreach (var parameter in client.RestClient.Parameters)
                    {
                        if (parameter.IsApiVersionParameter)
                        {
                            writer.Append($"{OptionsVariable}.Version, ");
                        }
                        else if (parameter == KnownParameters.ClientDiagnostics)
                        {
                            writer.Append($"{ClientDiagnosticsField.GetReferenceFormattable()}, ");
                        }
                        else if (parameter == KnownParameters.Pipeline)
                        {
                            writer.Append($"{PipelineField}, ");
                        }
                        else
                        {
                            writer.Append($"{parameter.Name}, ");
                        }
                    }
                    writer.RemoveTrailingComma();
                    writer.Append($");");
                }
                writer.Line();
            }

            if (library.Authentication.OAuth2 != null)
            {
                CSharpType credentialType = typeof(TokenCredential);
                var ctorParams = RestClientBuilder.GetConstructorParameters(client.RestClient.ClientParameters, credentialType);
                writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
                foreach (Parameter parameter in ctorParams)
                {
                    writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
                }
                writer.WriteXmlDocumentationParameter(OptionsVariable, $"The options for configuring the client.");

                writer.Append($"public {client.Type.Name:D}(");
                foreach (Parameter parameter in ctorParams)
                {
                    writer.WriteParameter(parameter);
                }
                writer.Append($" {clientOptionsName} {OptionsVariable} = null)");

                using (writer.Scope())
                {
                    writer.WriteParameterNullChecks(ctorParams);
                    writer.Line();

                    writer.Line($"{OptionsVariable} ??= new {clientOptionsName}();");
                    writer.Line($"{ClientDiagnosticsField.GetReferenceFormattable()} = new {typeof(ClientDiagnostics)}({OptionsVariable});");
                    var scopesParam = new CodeWriterDeclaration("scopes");
                    writer.Append($"string[] {scopesParam:D} = ");
                    writer.Append($"{{ ");
                    foreach (var credentialScope in library.Authentication.OAuth2.Scopes)
                    {
                        writer.Append($"{credentialScope:L}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Line($"}};");

                    writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new {typeof(BearerTokenAuthenticationPolicy)}({CredentialVariable}, {scopesParam}));");
                    writer.Append($"this.RestClient = new {client.RestClient.Type}(");
                    foreach (var parameter in client.RestClient.Parameters)
                    {
                        if (parameter.IsApiVersionParameter)
                        {
                            writer.Append($"{OptionsVariable}.Version, ");
                        }
                        else if (parameter == KnownParameters.ClientDiagnostics)
                        {
                            writer.Append($"{ClientDiagnosticsField.GetReferenceFormattable()}, ");
                        }
                        else if (parameter == KnownParameters.Pipeline)
                        {
                            writer.Append($"{PipelineField}, ");
                        }
                        else
                        {
                            writer.Append($"{parameter.Name}, ");
                        }
                    }
                    writer.RemoveTrailingComma();
                    writer.Append($");");
                }
                writer.Line();
            }

            var internalConstructor = BuildInternalConstructor(client);
            writer.WriteMethodDocumentation(internalConstructor);
            using (writer.WriteMethodDeclaration(internalConstructor))
            {
                writer
                    .Line($"this.RestClient = new {client.RestClient.Type}({client.RestClient.Parameters.GetIdentifiersFormattable()});")
                    .Line($"{ClientDiagnosticsField.GetReferenceFormattable()} = {KnownParameters.ClientDiagnostics.Name:I};")
                    .Line($"{PipelineField} = {KnownParameters.Pipeline.Name:I};");
            }
            writer.Line();
        }

        private void WriteMethod(CodeWriter writer, Method method)
        {
            writer.WriteXmlDocumentationSummary($"{method.Signature.SummaryText}");

            foreach (Parameter parameter in method.Signature.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }

            writer.WriteXmlDocumentationRequiredParametersException(method.Signature.Parameters);
            writer.WriteXmlDocumentation("remarks", $"{method.Signature.DescriptionText}");
            using (writer.WriteMethodDeclaration(method.Signature))
            {
                writer.WriteMethodBodyStatement(method.Body!);
            }
            writer.Line();
        }

        private void WriteStartOperationOperation(CodeWriter writer, LongRunningOperationMethod lroMethod, bool async)
        {
            RestClientMethod originalMethod = lroMethod.StartMethod;
            CSharpType returnType = async ? new CSharpType(typeof(Task<>), lroMethod.Operation.Type) : lroMethod.Operation.Type;
            var parameters = originalMethod.Parameters;

            writer.WriteXmlDocumentationSummary($"{originalMethod.SummaryText}");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);
            writer.WriteXmlDocumentation("remarks", $"{originalMethod.DescriptionText}");

            string asyncText = async ? "async " : string.Empty;
            writer.Append($"{lroMethod.Accessibility} virtual {asyncText}{returnType} {CreateStartOperationName(lroMethod.Name, async)}(");
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                using (writer.WriteDiagnosticScope(lroMethod.Diagnostics, ClientDiagnosticsField))
                {
                    string awaitText = async ? "await" : string.Empty;
                    string configureText = async ? ".ConfigureAwait(false)" : string.Empty;
                    writer.Append($"var originalResponse = {awaitText} RestClient.{CreateMethodName(originalMethod.Name, async)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    writer.Line($"cancellationToken){configureText};");

                    writer.Append($"return new {lroMethod.Operation.Type}({ClientDiagnosticsField.GetReferenceFormattable()}, {PipelineField}, RestClient.{RequestWriterHelpers.CreateRequestMethodName(originalMethod.Name)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Append($").Request, originalResponse");

                    var nextPageMethod = lroMethod.Operation.NextPageMethodName;
                    if (nextPageMethod != null)
                    {
                        writer.Append($", (_, nextLink) => RestClient.{nextPageMethod}(nextLink, {parameters.GetIdentifiersFormattable()})");
                    }

                    writer.Line($");");
                }

            }
            writer.Line();
        }

        private static ConstructorSignature BuildInternalConstructor(DataPlaneClient client)
        {
            var constructorParameters = new[]{KnownParameters.ClientDiagnostics, KnownParameters.Pipeline}.Union(client.RestClient.Parameters).ToArray();
            var name = client.Declaration.Name;
            return new ConstructorSignature(name, $"Initializes a new instance of {name}", null, MethodSignatureModifiers.Internal, constructorParameters);
        }
    }
}
