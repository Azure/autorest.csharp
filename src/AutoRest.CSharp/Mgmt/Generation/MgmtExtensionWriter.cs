// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
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

        protected override void WriteResourceContainerEntry(Resource resource)
        {
            var container = resource.ResourceContainer;
            if (container == null)
                throw new InvalidOperationException($"We are about to write a {resource.ResourceName} resource entry, but it does not have a container, this cannot happen");
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {container.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{container.Type}\" /> object.");
            using (_writer.Scope($"public static {container.Type.Name} Get{resource.ResourceName.ToPlural()}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                _writer.Line($"return new {container.Type.Name}({ExtensionOperationVariableName});");
            }
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceSuffix)
        {
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type}\" /> object.");
            using (_writer.Scope($"public static {resource.Type.Name} Get{resource.ResourceName}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                _writer.Line($"return new {resource.Type.Name}({ExtensionOperationVariableName}, {ExtensionOperationVariableName}.Id + \"/{singletonResourceSuffix}\");");
            }
        }

        protected override string GetMethodName(MgmtClientOperation clientOperation)
        {
            // we should always have only one operation in extension classes
            Debug.Assert(clientOperation.Count == 1);
            var operation = clientOperation.First();

            if (operation.IsListMethod(out var itemType, out var extraScope))
            {
                if (!Context.Library.TryGetTypeProvider(itemType.Name, out var provider))
                    throw new InvalidOperationException($"Cannot find type {itemType.Name}");

                // even if we are list a resource data under the subscription, we could have different scopes. The most common case is that we are listing under "subscriptions/locations"
                var suffix = GetOperationNameExtraScopeSuffix(extraScope);
                var by = string.IsNullOrEmpty(suffix) ? string.Empty : "By";

                var itemName = provider is ResourceData data ?
                    Context.Library.FindResources(data).First().ResourceName :
                    itemType.Name;
                return $"Get{itemName.ToPlural()}{by}{suffix}";
            }

            // if this is not a list method, we also need to rename this operation to avoid method name collision
            var operationSet = Context.Library.GetOperationSet(operation.RequestPath);
            var operationGroup = operationSet[operation.Operation];

            return $"{operation.Name}{operationGroup.Key.ToSingular()}";
        }

        private string GetOperationNameExtraScopeSuffix(IEnumerable<Segment> extraScope)
        {
            return string.Join("", extraScope.Select(segment => segment.IsConstant ? segment.ConstantValue.ToSingular() : segment.ReferenceName).Select(segment => segment.FirstCharToUpperCase()));
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

            WritePagingMethodSignature(responseType, methodName, methodParameters, async, clientOperation.Accessibility, false);

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
            var returnType = new CSharpType(typeof(Page<>), itemType).WrapAsync(async);

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
            var returnType = new CSharpType(typeof(IReadOnlyList<>), WrapResourceDataType(itemType)!);

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
            var returnType = WrapResourceDataType(clientOperation.ReturnType);

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

        private void WriteClientDiagnosticsAssignment(string optionsVariable)
        {
            _writer.Line($"var {ClientDiagnosticsVariable} = new {typeof(ClientDiagnostics)}({optionsVariable});");
        }

        private void WriteRestOperationAssignment(MgmtRestClient restClient)
        {
            var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? $", {ExtensionOperationVariableName}.Id.SubscriptionId" : "";
            _writer.Line($"var {GetRestClientVariableName(restClient)} = Get{restClient.Type.Name}({ClientDiagnosticsVariable}, credential, options, pipeline{subIdIfNeeded}, baseUri);");
        }

        //protected void WriteExtensionContextScope(CodeWriterDelegate inner, bool async)
        //{
        //    _writer.Append($"return {GetAwait(async)} {ExtensionOperationVariableName}.UseClientContext({GetAsyncKeyword(async)} (baseUri, credential, options, pipeline) =>");
        //    using (_writer.Scope())
        //    {
        //        inner(_writer);
        //    }
        //    _writer.Append($"){GetConfigureAwait(async)};");
        //}

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
