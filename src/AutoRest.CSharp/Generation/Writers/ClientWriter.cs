// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ClientWriter
    {

        public static void WriteClientOptions(CodeWriter writer, Client client, BuildContext context)
        {
            var cs = client.Type;
            var @namespace = cs.Namespace;
            var apiVersions = context.CodeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .Select(v => (Version: v, Name: ToVersionProperty(v)))
                .ToArray();

            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"Client options for {cs.Name}.");
                using (writer.Scope($"public class {cs.Name}Options: {typeof(ClientOptions)}"))
                {
                    writer.Line($"private const ServiceVersion LatestVersion = ServiceVersion.{apiVersions.Last().Name};");
                    writer.Line();
                    writer.WriteXmlDocumentationSummary("The version of the service to use.");
                    using (writer.Scope($"public enum ServiceVersion"))
                    {
                        int i = 1;
                        foreach (var apiVersion in apiVersions)
                        {
                            writer.WriteXmlDocumentationSummary($"Service version \"{apiVersion.Version}\"");
                            writer.Line($"{apiVersion.Name} = {i:L},");
                            i++;
                        }
                    }

                    writer.Line();
                    writer.Line($"internal string Version {{ get; }}");
                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes new instance of {cs.Name}Options.");
                    using (writer.Scope($"public {cs.Name}Options(ServiceVersion version = LatestVersion)"))
                    {
                        writer.Append($"Version = version ");
                        using (writer.Scope($"switch", end: "};"))
                        {
                            foreach (var apiVersion in apiVersions)
                            {
                                writer.Line($"ServiceVersion.{apiVersion.Name} => {apiVersion.Version:L},");
                            }

                            writer.Line($"_ => throw new {typeof(NotSupportedException)}()");
                        }
                    }
                }
            }
        }

        private static string ToVersionProperty(string s)
        {
            return "V" + s.Replace(".", "_").Replace('-', '_');
        }

        public void WriteClient(CodeWriter writer, Client client, Configuration configuration)
        {
            var cs = client.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(client.Description);
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client);
                    WriteClientCtors(writer, client, configuration);

                    foreach (var clientMethod in client.Methods)
                    {
                        WriteClientMethod(writer, clientMethod, true);
                        WriteClientMethod(writer, clientMethod, false);
                    }

                    foreach (var pagingMethod in client.PagingMethods)
                    {
                        WritePagingOperation(writer, pagingMethod, true);
                        WritePagingOperation(writer, pagingMethod, false);
                    }

                    foreach (var longRunningOperation in client.LongRunningOperationMethods)
                    {
                        WriteStartOperationOperation(writer, longRunningOperation, true);
                        WriteStartOperationOperation(writer, longRunningOperation, false);
                    }
                }
            }
        }

        private void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, bool async)
        {
            CSharpType? bodyType = clientMethod.RestClientMethod.ReturnType;
            CSharpType responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);

            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var parameters = clientMethod.RestClientMethod.Parameters;
            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public virtual {asyncText} {responseType} {methodName}(");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteDiagnosticScope(writer, clientMethod.Diagnostics, writer =>
                {
                    writer.Append($"return (");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    writer.Append($"RestClient.{CreateMethodName(clientMethod.RestClientMethod.Name, async)}(");
                    foreach (var parameter in clientMethod.RestClientMethod.Parameters)
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Append($")");

                    if (bodyType == null && clientMethod.RestClientMethod.HeaderModel != null)
                    {
                        writer.Append($".GetRawResponse()");
                    }

                    writer.Line($";");
                });
            }

            writer.Line();
        }

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private string CreateStartOperationName(string name, bool async) => $"Start{name}{(async ? "Async" : string.Empty)}";

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;
        private const string PipelineVariable = "pipeline";
        private const string PipelineField = "_" + PipelineVariable;
        private const string EndpointVariable = "endpoint";
        private const string CredentialVariable = "credential";
        private const string OptionsVariable = "options";

        private void WriteClientFields(CodeWriter writer, Client client)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            writer.Append($"internal {client.RestClient.Type} RestClient").LineRaw(" { get; }");
        }

        private void WriteClientCtors(CodeWriter writer, Client client, Configuration configuration)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();

            if (configuration.CredentialTypes.Contains("AzureKeyCredential", StringComparer.OrdinalIgnoreCase))
            {
                writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
                writer.WriteXmlDocumentationParameter(EndpointVariable, "server parameter.");
                writer.WriteXmlDocumentationParameter(CredentialVariable, "A credential used to authenticate to an Azure Service..");
                writer.WriteXmlDocumentationParameter(OptionsVariable, "The options for configuring the client.");
                writer.Append($"public {client.Type.Name:D}({typeof(Uri)} {EndpointVariable}, {typeof(AzureKeyCredential)} {CredentialVariable}, {client.Type.Name}Options {OptionsVariable} = null)");
                using (writer.Scope())
                {
                    writer.Line($"{typeof(Argument)}.AssertNotNull({EndpointVariable}, nameof({EndpointVariable}));");
                    writer.Line($"{typeof(Argument)}.AssertNotNull({CredentialVariable}, nameof({CredentialVariable}));");
                    writer.Line();

                    writer.Line($"{OptionsVariable} ??= new {client.Type.Name}Options();");
                    writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}({OptionsVariable});");
                    writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new {typeof(AzureKeyCredentialPolicy)}({CredentialVariable}, \"api-key\"));");
                    writer.Append($"this.RestClient = new {client.RestClient.Type}({ClientDiagnosticsField}, {PipelineField}, {EndpointVariable});");
                }
                writer.Line();
            }

            if (configuration.CredentialTypes.Contains("TokenCredential", StringComparer.OrdinalIgnoreCase))
            {
                writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
                writer.WriteXmlDocumentationParameter(EndpointVariable, "server parameter.");
                writer.WriteXmlDocumentationParameter(CredentialVariable, "A credential used to authenticate to an Azure Service.");
                writer.WriteXmlDocumentationParameter(OptionsVariable, "The options for configuring the client.");
                writer.Append($"public {client.Type.Name:D}({typeof(Uri)} {EndpointVariable}, {typeof(TokenCredential)} {CredentialVariable}, {client.Type.Name}Options {OptionsVariable} = null)");
                using (writer.Scope())
                {
                    writer.Line($"{typeof(Argument)}.AssertNotNull({EndpointVariable}, nameof({EndpointVariable}));");
                    writer.Line($"{typeof(Argument)}.AssertNotNull({CredentialVariable}, nameof({CredentialVariable}));");
                    writer.Line();

                    writer.Line($"{OptionsVariable} ??= new {client.Type.Name}Options();");
                    writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}({OptionsVariable});");
                    var scopesParam = new CodeWriterDeclaration("scopes");
                    string scope = "";
                    if (configuration.CredentialScopes != null)
                    {
                        if (configuration.CredentialScopes.Length == 1)
                        {
                            scope = $"\"{configuration.CredentialScopes[0]}\"";
                        }
                        else
                        {
                            string scopesArr = "{\"" + string.Join("\", \"", configuration.CredentialScopes) + "\"}";
                            writer.Line($"string[] {scopesParam:D} = {scopesArr};");
                            scope = scopesParam.ActualName;
                        }
                    }
                    writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new {typeof(BearerTokenAuthenticationPolicy)}({CredentialVariable}, {scope}));");
                    writer.Append($"this.RestClient = new {client.RestClient.Type}({ClientDiagnosticsField}, {PipelineField}, {EndpointVariable});");
                }
                writer.Line();
            }

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            writer.WriteXmlDocumentationParameter(ClientDiagnosticsVariable, "The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter(PipelineVariable, "The HTTP pipeline for sending and receiving REST requests and responses.");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.Append($"internal {client.Type.Name:D}({typeof(ClientDiagnostics)} {ClientDiagnosticsVariable}, {typeof(HttpPipeline)} {PipelineVariable},");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                writer.Append($"this.RestClient = new {client.RestClient.Type}({ClientDiagnosticsVariable}, {PipelineVariable}, ");
                foreach (var parameter in client.RestClient.Parameters)
                {
                    writer.Append($"{parameter.Name}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($");");

                writer.Line($"{ClientDiagnosticsField} = {ClientDiagnosticsVariable};");
                writer.Line($"{PipelineField} = {PipelineVariable};");
            }
            writer.Line();
        }

        private void WritePagingOperation(CodeWriter writer, PagingMethod pagingMethod, bool async)
        {
            var pageType = pagingMethod.PagingResponse.ItemType;
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var parameters = pagingMethod.Method.Parameters;

            writer.WriteXmlDocumentationSummary(pagingMethod.Method.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            writer.Append($"public virtual {responseType} {CreateMethodName(pagingMethod.Name, async)}(");
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                var pageWrappedType = new CSharpType(typeof(Page<>), pageType);
                var funcType = async ? new CSharpType(typeof(Task<>), pageWrappedType) : pageWrappedType;

                var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
                var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

                var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
                var asyncText = async ? "async" : string.Empty;
                var awaitText = async ? "await" : string.Empty;
                var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
                using (writer.Scope($"{asyncText} {funcType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, pagingMethod.Diagnostics, writer =>
                    {
                        writer.Append($"var response = {awaitText} RestClient.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                        foreach (Parameter parameter in parameters)
                        {
                            writer.Append($"{parameter.Name}, ");
                        }

                        writer.Line($"cancellationToken){configureAwaitText};");
                        writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}, {continuationTokenText}, response.GetRawResponse());");
                    });
                }

                var nextPageFunctionName = "null";
                if (pagingMethod.NextPageMethod != null)
                {
                    nextPageFunctionName = "NextPageFunc";
                    var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                    using (writer.Scope($"{asyncText} {funcType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                    {
                        WriteDiagnosticScope(writer, pagingMethod.Diagnostics, writer =>
                        {
                            writer.Append($"var response = {awaitText} RestClient.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(");
                            foreach (Parameter parameter in nextPageParameters)
                            {
                                writer.Append($"{parameter.Name}, ");
                            }
                            writer.Line($"cancellationToken){configureAwaitText};");
                            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}, {continuationTokenText}, response.GetRawResponse());");
                        });
                    }
                }
                writer.Line($"return {typeof(PageableHelpers)}.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
            }
            writer.Line();
        }

        private void WriteDiagnosticScope(CodeWriter writer, Diagnostic diagnostic, CodeWriterDelegate inner)
        {
            var scopeVariable = new CodeWriterDeclaration("scope");

            writer.Line($"using var {scopeVariable:D} = {ClientDiagnosticsField}.CreateScope({diagnostic.ScopeName:L});");
            foreach (DiagnosticAttribute diagnosticScopeAttributes in diagnostic.Attributes)
            {
                writer.Append($"{scopeVariable}.AddAttribute({diagnosticScopeAttributes.Name:L},");
                writer.WriteReferenceOrConstant(diagnosticScopeAttributes.Value);
                writer.Line($");");
            }

            writer.Line($"{scopeVariable}.Start();");

            using (writer.Scope($"try"))
            {
                inner(writer);
            }

            using (writer.Scope($"catch ({typeof(Exception)} e)"))
            {
                writer.Line($"{scopeVariable}.Failed(e);");
                writer.Line($"throw;");
            }
        }

        private void WriteStartOperationOperation(CodeWriter writer, LongRunningOperationMethod lroMethod, bool async)
        {
            RestClientMethod originalMethod = lroMethod.StartMethod;
            CSharpType returnType = async ? new CSharpType(typeof(Task<>), lroMethod.Operation.Type) : lroMethod.Operation.Type;
            Parameter[] parameters = originalMethod.Parameters;

            writer.WriteXmlDocumentationSummary(originalMethod.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            string asyncText = async ? "async " : string.Empty;
            writer.Append($"public virtual {asyncText}{returnType} {CreateStartOperationName(lroMethod.Name, async)}(");
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                WriteDiagnosticScope(writer, lroMethod.Diagnostics, writer =>
                {
                    string awaitText = async ? "await" : string.Empty;
                    string configureText = async ? ".ConfigureAwait(false)" : string.Empty;
                    writer.Append($"var originalResponse = {awaitText} RestClient.{CreateMethodName(originalMethod.Name, async)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    writer.Line($"cancellationToken){configureText};");

                    writer.Append($"return new {lroMethod.Operation.Type}({ClientDiagnosticsField}, {PipelineField}, RestClient.{CreateRequestMethodName(originalMethod.Name)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Append($").Request, originalResponse");

                    var nextPageMethod = lroMethod.Operation.NextPageMethod;
                    if (nextPageMethod != null)
                    {
                        writer.Append($", nextLink => RestClient.{CreateMethodName(nextPageMethod.Name, true)}(nextLink, ");

                        foreach (Parameter parameter in parameters)
                        {
                            writer.Append($"{parameter.Name}, ");
                        }

                        writer.Append($"cancellationToken)");
                    }

                    writer.Line($");");
                });

            }
            writer.Line();
        }
    }
}
