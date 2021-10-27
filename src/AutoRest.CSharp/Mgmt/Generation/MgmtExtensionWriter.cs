﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.AutoRest.Plugins;
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
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        protected BuildContext<MgmtOutputLibrary> Context { get; }
        protected MgmtConfiguration Configuration => Context.Configuration.MgmtConfiguration;

        public MgmtExtensionWriter(BuildContext<MgmtOutputLibrary> context)
        {
            Context = context;
        }

        public abstract void WriteExtension();

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
                writer.Append($"return new {restClient.Type}(clientDiagnostics, pipeline, clientOptions, ");
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

        protected void WriteGetResourceCollectionMethod(CodeWriter writer, ResourceCollection collection)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {collection.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{collection.Type.Name}\" /> object.");
            using (writer.Scope($"public static {collection.Type} Get{collection.Resource.Type.Name.ToPlural()}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                writer.Line($"return new {collection.Type}({ExtensionOperationVariableName});");
            }
        }

        protected void WriteGetSingletonResourceMethod(CodeWriter writer, Resource resource, string singletonResourceSuffix)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (writer.Scope($"public static {resource.Type} Get{resource.Type.Name}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                writer.Line($"return new {resource.Type}({ExtensionOperationVariableName}, {ExtensionOperationVariableName}.Id + \"/{singletonResourceSuffix}\");");
            }
        }

        protected void WriteExtensionClientMethod(CodeWriter writer, OperationGroup operationGroup, ClientMethod clientMethod, string methodName, bool async, MgmtRestClient restClient)
        {
            (var bodyType, bool isResourceList, bool wasResourceData) = clientMethod.RestClientMethod.GetBodyTypeForList(operationGroup, Context);
            var responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);
            responseType = responseType.WrapAsync(async);

            var methodParameters = BuildParameterMapping(clientMethod.RestClientMethod).Where(m => m.IsPassThru).Select(m => m.Parameter);

            writer.WriteXmlDocumentationSummary($"{clientMethod.Description}");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");

            foreach (var parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters.ToArray());
            // writer.WriteXmlDocumentationReturns("placeholder"); // TODO -- determine what to put here

            // write the signature of this function
            writer.Append($"public static {GetAsyncKeyword(async)} {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(methodParameters.ToArray());

                writer.Append($"return {GetAwait(async)} {ExtensionOperationVariableName}.UseClientContext({GetAsyncKeyword(async)} (baseUri, credential, options, pipeline) =>");
                using (writer.Scope())
                {
                    var clientDiagnostics = new CodeWriterDeclaration("clientDiagnostics");
                    var restOperations = new CodeWriterDeclaration("restOperations");

                    writer.Line($"var {clientDiagnostics:D} = new {typeof(ClientDiagnostics)}(options);");
                    // TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    // subscriptionId might not always be needed. For example `RestOperations` does not have it.
                    var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? $", {ExtensionOperationVariableName}.Id.SubscriptionId" : "";
                    writer.Line($"var {restOperations:D} = Get{restClient.Type.Name}(clientDiagnostics, credential, options, pipeline{subIdIfNeeded}, baseUri);");

                    using (WriteDiagnosticScope(writer, new Diagnostic($"{TypeNameOfThis}.{methodName}"), clientDiagnostics.ActualName))
                    {
                        writer.Append($"var response = {GetAwait(async)} ");

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
                            // first we need to validate that is this function listing this resource itself, or list something else
                            var elementType = bodyType!.Arguments.First();
                            if (Context.Library.TryGetArmResource(operationGroup, out var resource)
                                && resource.Type.EqualsByName(elementType))
                            {
                                writer.UseNamespace("System.Linq");

                                var converter = $".Select(data => new {Context.Library.GetArmResource(operationGroup).Declaration.Name}(subscription, data)).ToArray()";
                                writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value{converter} as {bodyType}, response.GetRawResponse())");
                            }
                            else
                            {
                                writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value, response.GetRawResponse())");
                            }
                        }
                        else
                        {
                            writer.Append($"return response");
                        }

                        writer.Line($";");
                    }
                }
                writer.Append($"){(async? ".ConfigureAwait(false)": string.Empty)};");
            }

            writer.Line();
        }

        protected void WriteExtensionPagingMethod(CodeWriter writer, CSharpType pageType, MgmtRestClient restClient, PagingMethod pagingMethod, string methodName, FormattableString converter, bool async)
        {
            writer.WriteXmlDocumentationSummary($"Lists the {pageType.Name.ToPlural()} for this <see cref=\"{ExtensionOperationVariableType}\" />.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");

            var methodParameters = BuildParameterMapping(pagingMethod.Method).Where(m => m.IsPassThru).Select(m => m.Parameter);
            foreach (var parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters.ToArray());

            var responseType = pageType.WrapPageable(async);

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

                    writer.Line($"var {clientDiagnostics:D} = new {typeof(ClientDiagnostics)}(options);");
                    // TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    // subscriptionId might not always be needed. For example `RestOperations` does not have it.
                    var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? $", {ExtensionOperationVariableName}.Id.SubscriptionId" : "";
                    writer.Line($"var {restOperations:D} = Get{restClient.Type.Name}(clientDiagnostics, credential, options, pipeline{subIdIfNeeded}, baseUri);");

                    WritePagingOperationBody(writer, pagingMethod, pageType, restOperations.ActualName,
                        new Diagnostic($"{TypeNameOfThis}.{methodName}"), clientDiagnostics.ActualName,
                            converter, async);
                }
                writer.Append($");");
            }
            writer.Line();
        }

        protected virtual void WriteExtensionGetResourceFromIdMethod(CodeWriter writer, Resource resource)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it but with no data.");
            writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationParameter("id", $"The resource ID of the resource to get.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (writer.Scope($"public static {resource.Type} Get{resource.Type.Name}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, {typeof(ResourceIdentifier)} id)"))
            {
                writer.Line($"return new {resource.Type}({ExtensionOperationVariableName}, id);");
            }
        }
    }
}
