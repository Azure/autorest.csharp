// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        protected MgmtExtensions _extensions;
        public MgmtExtensionWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context) : base(writer, extensions, context)
        {
            _extensions = extensions;
        }

        protected abstract string Description { get; }
        protected abstract string ExtensionOperationVariableName { get; }
        protected abstract Type ExtensionOperationVariableType { get; }

        protected override string IdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string BranchIdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string ContextProperty => ExtensionOperationVariableName;

        protected void WriteGetRestOperations(MgmtRestClient restClient)
        {
            _writer.Line();
            _writer.Append($"private static {restClient.Type} Get{restClient.Type.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(TokenCredential)} credential, {typeof(ArmClientOptions)} clientOptions, {typeof(HttpPipeline)} pipeline, ");
            // TODO: Use https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783 rest client parameters
            foreach (var parameter in restClient.Parameters)
            {
                if (parameter.IsApiVersionParameter)
                {
                    continue;
                }
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Append($")");

            using (_writer.Scope())
            {
                _writer.Append($"return new {restClient.Type}(clientDiagnostics, pipeline, clientOptions, ");
                foreach (var parameter in restClient.Parameters)
                {
                    if (parameter.IsApiVersionParameter)
                    {
                        continue;
                    }
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
            _writer.Line();
        }

        protected override void WriteResourceCollectionEntry(Resource resource)
        {
            var collection = resource.ResourceCollection;
            if (collection == null)
                throw new InvalidOperationException($"We are about to write a {resource.Type.Name} resource entry, but it does not have a collection, this cannot happen");
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {collection.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationParameters(collection.ExtraConstructorParameters);
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{collection.Type}\" /> object.");

            _writer.Append($"public static {collection.Type.Name} Get{resource.Type.Name.ResourceNameToPlural()}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in collection.ExtraConstructorParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Line($")");
            using (_writer.Scope())
            {
                _writer.Append($"return new {collection.Type.Name}({ExtensionOperationVariableName}, ");
                foreach (var parameter in collection.ExtraConstructorParameters)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceSuffix)
        {
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (_writer.Scope($"public static {resource.Type.Name} Get{resource.Type.Name}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                _writer.Line($"return new {resource.Type.Name}({ExtensionOperationVariableName}, new {typeof(ResourceIdentifier)}({ExtensionOperationVariableName}.Id + \"/{singletonResourceSuffix}\"));");
            }
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

        protected override void WriteLROMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            // we can only make this an SLRO when all of the methods are not really long
            bool isSLRO = !clientOperation.IsLongRunningReallyLong();
            methodName = isSLRO ? methodName : $"Start{methodName}";

            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = GetLROObjectType(clientOperation.First().Operation, async);
            var responseType = lroObjectType.WrapAsync(async);

            WriteLROMethodSignature(responseType, methodName, methodParameters, async, isSLRO, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, async))
                {
                    var diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientDiagnosticsAssignment("options");

                    using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsVariable))
                    {
                        WriteLROMethodBody(lroObjectType, operationMappings, parameterMappings, async);
                    }
                    _writer.Line();
                }
            }
        }

        protected override void WriteLROMethodBranch(CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            WriteRestOperationAssignment(operation.RestClient);
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, ClientDiagnosticsVariable, "pipeline", operation, parameterMapping, async);
        }

        protected override void WritePagingMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            var pagingMethod = clientOperation.First().GetPagingMethod(Context)!;
            var itemType = pagingMethod.PagingResponse.ItemType;
            var wrapResource = WrapResourceDataType(itemType, clientOperation.First());
            var actualItemType = wrapResource?.Type ?? itemType;

            _writer.WriteXmlDocumentationSummary($"Lists the {actualItemType.Name.LastWordToPlural()} for this <see cref=\"{ExtensionOperationVariableType}\" />.");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);

            WritePagingMethodSignature(actualItemType.WrapPageable(async), methodName, methodParameters, async, clientOperation.Accessibility, false);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                // the wrapper for paging method will never be async
                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, false))
                {
                    var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WritePagingMethodBody(itemType, diagnostic, operationMappings, parameterMappings, async);
                }
            }
            _writer.Line();
        }

        protected override void WritePagingMethodBranch(CSharpType itemType, Diagnostic diagnostic, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings,
            bool async)
        {
            var pagingMethod = operation.GetPagingMethod(Context)!;
            var wrapResource = WrapResourceDataType(itemType, operation);
            var actualItemType = wrapResource?.Type ?? itemType;
            var returnType = new CSharpType(typeof(Page<>), actualItemType).WrapAsync(async);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";

            WriteClientDiagnosticsAssignment("options");

            WriteRestOperationAssignment(operation.RestClient);

            using (_writer.Scope($"{GetAsyncKeyword(async)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsVariable))
                {
                    WritePageFunctionBody(itemType, pagingMethod, operation, parameterMappings, async, false);
                }
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (_writer.Scope($"{GetAsyncKeyword(async)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsVariable))
                    {
                        WritePageFunctionBody(itemType, pagingMethod, operation, parameterMappings, async, true);
                    }
                }
            }
            _writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        protected override void WritePagingMethodSignature(CSharpType responseType, string methodName, IEnumerable<Parameter> methodParameters,
            bool async, string accessibility = "public", bool isVirtual = true)
        {
            _writer.Append($"{accessibility} static {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        protected override void WriteLROMethodSignature(CSharpType responseType, string methodName, IEnumerable<Parameter> methodParameters, bool async,
            bool isSLRO, string accessibility = "public", bool isVirtual = true)
        {
            _writer.Append($"{accessibility} static {GetAsyncKeyword(async)} {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }

            var defaultWaitForCompletion = isSLRO ? "true" : "false";
            _writer.Line($"bool waitForCompletion = {defaultWaitForCompletion}, {typeof(CancellationToken)} cancellationToken = default)");
        }

        protected override void WriteNormalMethodSignature(CSharpType responseType, string methodName, IEnumerable<Parameter> methodParameters,
            bool async, string accessibility = "public", bool isVirtual = true)
        {
            _writer.Append($"{accessibility} static {GetAsyncKeyword(async)} {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        protected override void WriteNormalListMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            CSharpType itemType, string methodName, bool async)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            var wrapResource = WrapResourceDataType(itemType, clientOperation.First());
            var actualItemType = wrapResource?.Type ?? itemType;
            var returnType = new CSharpType(typeof(IReadOnlyList<>), actualItemType);

            WriteNormalMethodSignature(GetResponseType(returnType, async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, async))
                {
                    var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientDiagnosticsAssignment("options");

                    using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsVariable))
                    {
                        WriteNormalListMethodBody(_writer, itemType, operationMappings, parameterMappings, async);
                    }
                    _writer.Line();
                }
            }
        }

        protected override void WriteNormalListMethodBranch(CodeWriter writer, CSharpType itemType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            WriteRestOperationAssignment(operation.RestClient);

            base.WriteNormalListMethodBranch(writer, itemType, operation, parameterMappings, async);
        }

        protected override void WriteNormalMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            var returnType = WrapResourceDataType(clientOperation.ReturnType, clientOperation.First())?.Type ?? clientOperation.ReturnType;

            WriteNormalMethodSignature(GetResponseType(returnType, async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, async))
                {
                    var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientDiagnosticsAssignment("options");

                    using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsVariable))
                    {
                        WriteNormalMethodBody(operationMappings, parameterMappings, async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull);
                    }
                    _writer.Line();
                }
            }
        }

        protected override void WriteNormalMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            WriteRestOperationAssignment(operation.RestClient);

            base.WriteNormalMethodBranch(operation, parameterMappings, async, shouldThrowExceptionWhenNull);
        }

        /// <summary>
        /// In the extension class, we need to find the correct resource class that links to this resource data, if this is a resource data
        /// </summary>
        /// <param name="type"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected override Resource? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation))
                return null;

            // we need to find the correct resource type that links with this resource data
            var candidates = new List<RequestPath>();
            foreach (var resource in Context.Library.ArmResources)
            {
                foreach (var operationSet in resource.OperationSets)
                {
                    var resourceRequestPath = operationSet.GetRequestPath(Context);
                    // TODO -- verify if this has the same prefix after the scope is trimeed
                    if (operation.RequestPath.TrimScope().IsAncestorOf(resourceRequestPath.TrimScope()))
                        candidates.Add(resourceRequestPath);
                }
            }

            // we should have a list of candidates, return the original type if there is no candidates
            if (candidates.Count == 0)
                return null;

            var selectedResourcePath = candidates.OrderBy(path => path.Count).First();

            return Context.Library.GetArmResource(selectedResourcePath);
        }

        /// <summary>
        /// In the extension class, we need to check the type is a resource data or not
        /// </summary>
        /// <param name="type"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (type == null || type.IsFrameworkType)
                return false;

            return Context.Library.TryGetTypeProvider(type.Name, out var provider)
                && provider is ResourceData;
        }

        private void WriteClientDiagnosticsAssignment(string optionsVariable)
        {
            _writer.Line($"var {ClientDiagnosticsVariable} = new {typeof(ClientDiagnostics)}({optionsVariable});");
        }

        private void WriteRestOperationAssignment(MgmtRestClient restClient)
        {
            var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? $", {ExtensionOperationVariableName}.Id.SubscriptionId" : "";
            _writer.Line($"var {GetRestClientVariableName(restClient)} = Get{restClient.Type.Name}({ClientDiagnosticsVariable}, credential, options, pipeline{subIdIfNeeded}, baseUri);");
        }

        protected override Models.ResourceType GetBranchResourceType(RequestPath branch)
        {
            // we should never have a branch in the operations in an extension class, therefore throwing an exception here
            throw new InvalidOperationException();
        }

        protected static IDisposable WriteExtensionContextScope(CodeWriter writer, string extensionVariableName, bool async)
        {
            writer.Append($"return {GetAwait(async)} {extensionVariableName}.UseClientContext({GetAsyncKeyword(async)} (baseUri, credential, options, pipeline) =>");
            return new ExtensionContextScope(writer.Scope(), writer, async);
        }

        private class ExtensionContextScope : IDisposable
        {
            private readonly CodeWriter.CodeWriterScope _scope;
            private readonly CodeWriter _writer;
            private readonly bool _async;

            public ExtensionContextScope(CodeWriter.CodeWriterScope scope, CodeWriter writer, bool async)
            {
                _scope = scope;
                _writer = writer;
                _async = async;
            }

            public void Dispose()
            {
                _scope.Dispose();

                _writer.Line($"){GetConfigureAwait(_async)};");
            }
        }
    }
}
