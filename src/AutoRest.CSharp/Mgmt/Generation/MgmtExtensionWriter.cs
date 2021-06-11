// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        public abstract void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context);

        protected abstract string ExtensionOperationVariableName { get; }
        protected abstract Type ExtensionOperationVariableType { get; }

        protected void WriteGetRestOperations(CodeWriter writer, MgmtRestClient restClient)
        {
            writer.Append($"private static {restClient.Type} Get{restClient.Type.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(TokenCredential)} credential, {typeof(ArmClientOptions)} clientOptions, {typeof(HttpPipeline)} pipeline, ");
            // TODO: Use https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783 rest client parameters
            foreach (var parameter in restClient.Parameters)
            {
                if (parameter.IsApiVersionParameter)
                {
                    continue;
                }
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            using (writer.Scope())
            {
                writer.Append($"return new {restClient.Type}(clientDiagnostics, pipeline, ");
                foreach (var parameter in restClient.Parameters)
                {
                    if (parameter.IsApiVersionParameter)
                    {
                        continue;
                    }
                    writer.Append($"{parameter.Name}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($");");
            }
            writer.Line();
        }

        protected void WriteClientMethod(CodeWriter writer, MgmtRestClient restClient, ClientMethod clientMethod, IEnumerable<string> omittedParameterInvocations, IEnumerable<Parameter> methodParameters, bool async)
        {
            var responseType = clientMethod.ResponseType(async);

            writer.WriteXmlDocumentationSummary(clientMethod.Description);
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters.ToArray());
            writer.WriteXmlDocumentationReturns("placeholder"); // TODO -- determine what to put here

            // write the signature of this function
            writer.Append($"public static {responseType} {CreateMethodName(clientMethod.Name, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(methodParameters.ToArray());

                writer.Append($"return {ExtensionOperationVariableName}.UseClientContext((baseUri, credential, options, pipeline) =>");
                using (writer.Scope())
                {
                    var clientDiagnostics = new CodeWriterDeclaration("clientDiagnostics");
                    var restOperations = new CodeWriterDeclaration("restOperations");

                    writer.Line($"var {clientDiagnostics:D} = new {typeof(ClientDiagnostics)}(options);");
                    // TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    writer.Line($"var {restOperations:D} = Get{restClient.Type.Name}(clientDiagnostics, credential, options, pipeline, {ExtensionOperationVariableName}.Id.SubscriptionId, baseUri);");

                    writer.Append($"return {CreateMethodName(clientMethod.Name, async)}({clientDiagnostics}, {restOperations}, ");
                    foreach (var parameterName in omittedParameterInvocations)
                    {
                        writer.Append($"{parameterName}, ");
                    }
                    foreach (var parameter in methodParameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.AppendRaw("cancellationToken);");
                }
                writer.Append($");");
            }

            writer.Line();
        }

        protected void WriteListMethod(CodeWriter writer, CSharpType pageType, MgmtRestClient restClient, PagingMethod pagingMethod,
            IEnumerable<string> omittedParameterInvocations, IEnumerable<Parameter> methodParameters, bool async, bool needResourceWrapper)
        {
            writer.WriteXmlDocumentationSummary($"Lists the {pageType.Name}s for this {ExtensionOperationVariableType}.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");

            foreach (var parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters.ToArray());

            var responseType = pageType.WrapPageable(async);
            var methodName = $"List{pageType.Name}";

            writer.Append($"public static {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(methodParameters.ToArray());

                writer.Append($"return {ExtensionOperationVariableName}.UseClientContext((baseUri, credential, options, pipeline) =>");
                using (writer.Scope())
                {
                    var clientDiagnostics = new CodeWriterDeclaration("clientDiagnostics");
                    var restOperations = new CodeWriterDeclaration("restOperations");
                    var result = new CodeWriterDeclaration("result");

                    writer.Line($"var {clientDiagnostics:D} = new {typeof(ClientDiagnostics)}(options);");
                    // TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    writer.Line($"var {restOperations:D} = Get{restClient.Type.Name}(clientDiagnostics, credential, options, pipeline, {ExtensionOperationVariableName}.Id.SubscriptionId, baseUri);");

                    writer.Append($"var {result:D} = {CreateMethodName(pagingMethod.Name, async)}({clientDiagnostics}, {restOperations}, ");
                    foreach (var parameterName in omittedParameterInvocations)
                    {
                        writer.Append($"{parameterName}, ");
                    }
                    foreach (var parameter in methodParameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.LineRaw("cancellationToken);");

                    if (needResourceWrapper)
                    {
                        CSharpType[] arguments = { pagingMethod.PagingResponse.ItemType, pageType };
                        CSharpType returnType = async ? new CSharpType(typeof(PhWrappingAsyncPageable<,>), arguments) : new CSharpType(typeof(PhWrappingPageable<,>), arguments);
                        writer.Line($"return new {returnType}(");
                        writer.Line($"{result},");
                        writer.Line($"s => new {pageType}(subscription, s));");
                    }
                    else
                    {
                        writer.Line($"return {result};");
                    }
                }
                writer.Append($");");
            }
            writer.Line();
        }

        protected void WriteClientOperation(CodeWriter writer, MgmtRestClient restClient, ClientMethod clientMethod, bool async)
        {
            var bodyType = clientMethod.BodyType();
            var responseType = clientMethod.ResponseType(async);

            var parameters = clientMethod.RestClientMethod.Parameters;

            writer.WriteXmlDocumentationSummary(clientMethod.Description);
            writer.WriteXmlDocumentationParameter("clientDiagnostics", "The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter("restOperations", "Resource client operations.");
            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            // write the function declaration
            writer.Append($"private static {AsyncKeyword(async)} {responseType} {CreateMethodName(clientMethod.Name, async)}({typeof(ClientDiagnostics)} clientDiagnostics, {restClient.Type} restOperations,");

            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);
                WriteDiagnosticScope(writer, clientMethod.Diagnostics, "clientDiagnostics", writer =>
                {
                    writer.Append($"return (");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    var parameterNames = parameters.Select(p => p.Name);
                    writer.Append($"{"restOperations"}.{CreateMethodName(clientMethod.RestClientMethod.Name, async)}(");
                    foreach (var parameter in parameterNames)
                    {
                        writer.Append($"{parameter:I}, ");
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

        protected void WritePagingOperation(CodeWriter writer, MgmtRestClient restClient, PagingMethod pagingMethod, bool async)
        {
            // Paging method signature
            var responseType = pagingMethod.ResponseType(async);
            var parameters = pagingMethod.Method.Parameters;

            writer.WriteXmlDocumentationSummary(pagingMethod.Method.Description);
            writer.WriteXmlDocumentationParameter("clientDiagnostics", "The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter("restOperations", "Resource client operations.");

            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            writer.Append($"private static {responseType} {CreateMethodName(pagingMethod.Name, async)}({typeof(ClientDiagnostics)} clientDiagnostics, {restClient.Type} restOperations,");

            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            // Paging method definiton
            WritePagingOperationDefinition(writer, pagingMethod, async, "restOperations", "clientDiagnostics");
        }
    }
}
