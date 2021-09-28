// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceGroupExtensionsWriter : MgmtExtensionWriter
    {
        private ResourceGroupExtensions _resourceGroupExtensions;
        public ResourceGroupExtensionsWriter(CodeWriter writer, ResourceGroupExtensions resourceGroupExtensions, BuildContext<MgmtOutputLibrary> context) : base(writer, context)
        {
            _resourceGroupExtensions = resourceGroupExtensions;
        }

        protected override string Description => "A class to add extension methods to ResourceGroup.";

        protected override CSharpType TypeOfThis => _resourceGroupExtensions.Type;

        protected override string ExtensionOperationVariableName => "resourceGroup";

        protected override Type ExtensionOperationVariableType => typeof(ResourceGroup);

        protected override TypeProvider This => _resourceGroupExtensions;

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource container entries
                    WriteChildResourceEntries(TypeNameOfThis); // TODO -- this is incorrect

                    // Write RestOperations
                    foreach (var restClient in _resourceGroupExtensions.RestClients)
                    {
                        WriteGetRestOperations(restClient);
                    }

                    // Write other orphan operations with the parent of ResourceGroup
                    foreach (var clientOperation in _resourceGroupExtensions.ClientOperations)
                    {
                        WriteExtensionMethod(clientOperation, clientOperation.Name, true);
                        WriteExtensionMethod(clientOperation, clientOperation.Name, false);
                    }

                    //var mgmtExtensionOperations = Context.Library.GetNonResourceOperations(ResourceTypeBuilder.ResourceGroups);

                    //foreach (var mgmtExtensionOperation in mgmtExtensionOperations)
                    //{
                    //    _writer.Line($"#region {mgmtExtensionOperation.SchemaName}");
                    //WriteGetRestOperations(_writer, mgmtExtensionOperation.RestClient);

                    //    // despite that we should only have one method, but we still using an IEnumerable
                    //    foreach (var pagingMethod in mgmtExtensionOperation.PagingMethods)
                    //    {
                    //WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", true);
                    //        WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", false);
                    //    }

                    //    foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                    //    {
                    //WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, true, mgmtExtensionOperation.RestClient);
                    //        WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, false, mgmtExtensionOperation.RestClient);
                    //    }

                    //    _writer.LineRaw("#endregion");
                    //    _writer.Line();
                    //}
                }
            }
        }

        protected void WriteExtensionMethod(MgmtClientOperation operation, string methodName, bool async)
        {
            if (operation.IsLongRunningOperation())
            {
                //WriteLROMethod(operation, methodName, async);
            }
            else if (operation.IsPagingOperation(Context))
            {
                WritePagingMethod(operation, methodName, async);
            }
            else
            {
                //WriteNormalMethod(operation, methodName, async);
            }
        }

        protected void WriteExtensionContextScope(CodeWriterDelegate inner)
        {
            _writer.Append($"return {ExtensionOperationVariableName}.UseClientContext((baseUri, credential, options, pipeline) =>");
            using (_writer.Scope())
            {
                inner(_writer);
            }
            _writer.Append($");");
        }

        protected override void WritePagingMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Method.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();

            var pagingMethod = clientOperation.First().GetPagingMethod(Context)!;
            var itemType = pagingMethod.PagingResponse.ItemType;

            _writer.WriteXmlDocumentationSummary($"Lists the {itemType.Name.ToPlural()} for this <see cref=\"{ExtensionOperationVariableType}\" />.");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);

            var responseType = itemType.WrapPageable(async);

            _writer.Append($"public static {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                WriteExtensionContextScope(writer =>
                {
                    // TODO -- find a way to put these in
                    //writer.Line($"var clientDiagnostics = new {typeof(ClientDiagnostics)}(options);");
                    //// TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    //// subscriptionId might not always be needed. For example `RestOperations` does not have it.
                    //var subIdIfNeeded = operation.RestClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? $", {ExtensionOperationVariableName}.Id.SubscriptionId" : "";
                    //writer.Line($"var restOperations = Get{operation.RestClient.Type.Name}(clientDiagnostics, credential, options, pipeline{subIdIfNeeded}, baseUri);");

                    var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WritePagingMethodBody(_writer, itemType, diagnostic, operationMappings, parameterMappings, async);
                });
            }
            _writer.Line();
        }

        /// <summary>
        /// The RestClients in the extension classes are all local variables
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        protected override string GetRestClientVariableName(RestClient client)
        {
            return "restOperations";
        }

        protected void WriteExtensionLROMethod(MgmtRestOperation operation, string methodName, bool async)
        {

        }

        protected void WriteExtensionNormalMethod(MgmtRestOperation operation, string methodName, bool async)
        {

        }
    }
}
