// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        public abstract void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context);

        protected abstract string Description { get; }
        protected virtual string Accessibility => "public";
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

        protected void WriteExtensionClientMethod(CodeWriter writer, OperationGroup operationGroup, ClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async, string restClientName)
        {
            (var bodyType, bool isResourceList) = clientMethod.RestClientMethod.GetBodyTypeForList(operationGroup, context);
            var responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);
            responseType = responseType.WrapAsync(async);

            var methodParameters = BuildParameterMapping(clientMethod.RestClientMethod).Where(m => m.IsPassThru).Select(m => m.Parameter);

            writer.WriteXmlDocumentationSummary(clientMethod.Description);
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");

            foreach (var parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters.ToArray());
            // writer.WriteXmlDocumentationReturns("placeholder"); // TODO -- determine what to put here

            // write the signature of this function
            writer.Append($"public static {AsyncKeyword(async)} {responseType} {CreateMethodName(clientMethod.Name, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(methodParameters.ToArray());

                writer.Append($"return {AwaitKeyword(async)} {ExtensionOperationVariableName}.UseClientContext({AsyncKeyword(async)} (baseUri, credential, options, pipeline) =>");
                using (writer.Scope())
                {
                    var clientDiagnostics = new CodeWriterDeclaration("clientDiagnostics");
                    var restOperations = new CodeWriterDeclaration("restOperations");

                    writer.Line($"var {clientDiagnostics:D} = new {typeof(ClientDiagnostics)}(options);");
                    // TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    writer.Line($"var {restOperations:D} = Get{restClientName}(clientDiagnostics, credential, options, pipeline, {ExtensionOperationVariableName}.Id.SubscriptionId, baseUri);");

                    WriteDiagnosticScope(writer, clientMethod.Diagnostics, clientDiagnostics.ActualName, writer =>
                    {
                        writer.Append($"var response = {AwaitKeyword(async)} ");

                        writer.Append($"{restOperations}.{CreateMethodName(clientMethod.RestClientMethod.Name, async)}(");
                        BuildAndWriteParameters(writer, clientMethod.RestClientMethod);
                        writer.Append($"cancellationToken)");

                        if (async)
                        {
                            writer.Append($".ConfigureAwait(false)");
                        }

                        if (clientMethod.GetBodyType() == null && clientMethod.RestClientMethod.HeaderModel != null)
                        {
                            writer.Append($".GetRawResponse()");
                        }

                        writer.Line($";");

                        if (isResourceList)
                        {
                            writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value, response.GetRawResponse())");
                        }
                        else
                        {
                            writer.Append($"return response");
                        }

                        writer.Line($";");
                    });
                }
                writer.Append($"){(async? ".ConfigureAwait(false)":"")};");
            }

            writer.Line();
        }

        protected void WriteExtensionPagingMethod(CodeWriter writer, CSharpType pageType, MgmtRestClient restClient, PagingMethod pagingMethod, FormattableString converter, bool async)
        {
            writer.WriteXmlDocumentationSummary($"Lists the {pageType.Name.ToPlural()} for this {ExtensionOperationVariableType.Name}.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");

            var methodParameters = BuildParameterMapping(pagingMethod.Method).Where(m => m.IsPassThru).Select(m => m.Parameter);
            foreach (var parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters.ToArray());

            var responseType = pageType.WrapPageable(async);

            writer.Append($"public static {responseType} {CreateMethodName(pagingMethod.Name, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
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

                    WritePagingOperationBody(writer, pagingMethod, pageType, restOperations.ActualName,
                        new Diagnostic($"{TypeNameOfThis}.{pagingMethod.Name}"), clientDiagnostics.ActualName,
                            converter, async);
                }
                writer.Append($");");
            }
            writer.Line();
        }
    }
}
