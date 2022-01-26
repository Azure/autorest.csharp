// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Generation.Writers;
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
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter<MgmtExtensions>
    {
        protected MgmtExtensions _extensions;

        protected virtual string DiagnosticOptionsVariable { get; } = "diagnosticOptions";

        protected bool IsArmCore;
        public MgmtExtensionWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context, Type extensionType, bool isArmCore = false) : base(writer, extensions, context)
        {
            _extensions = extensions;
            IsArmCore = isArmCore;
            ExtensionOperationVariableType = extensionType;
            ExtensionParameter = new Parameter(
                ExtensionOperationVariableName,
                $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.",
                ExtensionOperationVariableType,
                null,
                false);
        }

        protected abstract string Description { get; }
        protected abstract string ExtensionOperationVariableName { get; }
        protected Type ExtensionOperationVariableType { get; }

        protected override string IdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string BranchIdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string ContextProperty => ExtensionOperationVariableName;

        protected Parameter ExtensionParameter { get; }

        protected void WriteMethodWrapper(MgmtClientOperation clientOperation, bool isAsync)
        {
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            if (!IsArmCore)
                methodParameters.Insert(0, ExtensionParameter);
            methodParameters.Add(CancellationTokenParameter);
            // we need to identify this operation belongs to which category: NormalMethod, NormalListMethod, LROMethod or PagingMethod
            if (clientOperation.IsLongRunningOperation() && !clientOperation.IsPagingOperation(Context))
            {
                methodParameters.Insert(1, WaitForCompletionParameter);
                if (clientOperation.ReturnType is null)
                    throw new InvalidOperationException($"LRO method had null return type {clientOperation.RestClient.Type.Name}.{clientOperation.Name}");
                // this is a non-pageable long-running operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType.WrapAsync(isAsync), methodParameters, isAsync, false);
            }
            else if (clientOperation.IsLongRunningOperation() && clientOperation.IsPagingOperation(Context))
            {
                // this is a pageable long-running operation
                throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");
            }
            else if (clientOperation.IsPagingOperation(Context))
            {
                // this is a paging operation
                var itemType = clientOperation.First(restOperation => restOperation.IsPagingOperation(Context)).GetPagingMethod(Context)!.PagingResponse.ItemType;
                itemType = GetActualItemType(clientOperation, itemType);
                if (itemType is null)
                    throw new InvalidOperationException($"Paging method had null item type {clientOperation.RestClient.Type.Name}.{clientOperation.Name}");
                CSharpType actualReturnType = itemType.WrapPageable(isAsync);
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, actualReturnType, methodParameters, isAsync, true);
            }
            else if (clientOperation.IsListOperation(Context, out var itemType))
            {
                // this is a normal list operation
                itemType = GetActualItemType(clientOperation, itemType);
                if (itemType is null)
                    throw new InvalidOperationException($"Paging method had null item type {clientOperation.RestClient.Type.Name}.{clientOperation.Name}");
                CSharpType actualReturnType = itemType.WrapPageable(isAsync);
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, actualReturnType, methodParameters, isAsync, true);
            }
            else
            {
                CSharpType actualReturnType = GetResponseType(GetActualItemType(clientOperation, clientOperation.ReturnType), isAsync);
                // this is a normal operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, actualReturnType, methodParameters, isAsync, false);
            }
        }

        private void WriteMethodSignatureWrapper(CSharpType actualItemType, string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging)
        {
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }

            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            if (isPaging)
                _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            string asyncText = isPaging ? string.Empty : GetAsyncKeyword(isAsync);
            string thisText = methodParameters.Count > 0 && methodParameters.First().Equals(ExtensionParameter) ? "this " : string.Empty;
            _writer.Append($"public static {asyncText} {actualItemType} {CreateMethodName(methodName, isAsync)}({thisText}");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }

            _writer.RemoveTrailingComma();
            _writer.Line($")");
        }

        private CSharpType? GetActualItemType(MgmtClientOperation clientOperation, CSharpType? itemType)
        {
            if (itemType is null)
                return null;

            var wrapResource = WrapResourceDataType(itemType, clientOperation.First());
            CSharpType actualItemType = wrapResource?.Type ?? itemType;
            return actualItemType;
        }

        protected void WriteExtensionClientGet()
        {
            _writer.Line();
            string staticText = IsArmCore ? string.Empty : "static ";
            FormattableString signatureParamText = IsArmCore ? (FormattableString)$"" : (FormattableString)$"{ExtensionOperationVariableType} {ExtensionOperationVariableName}";
            using (_writer.Scope($"private {staticText}{ExtensionOperationVariableType.Name}ExtensionClient GetExtensionClient({signatureParamText})"))
            {
                using (_writer.Scope($"return {ExtensionOperationVariableName}.GetCachedClient(({ArmClientReference}) =>"))
                {
                    _writer.Line($"return new {ExtensionOperationVariableType.Name}ExtensionClient({ArmClientReference}, {ExtensionOperationVariableName}.Id);");
                }
                _writer.Line($");");
            }
        }

        private void WriteMethodWrapperImpl(
            MgmtClientOperation clientOperation,
            string methodName,
            CSharpType itemType,
            IReadOnlyList<Parameter> methodParameters,
            bool async,
            bool isPaging)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            WriteMethodSignatureWrapper(itemType, methodName, methodParameters, async, isPaging);
            using (_writer.Scope())
            {
                WriteMethodBodyWrapper(methodName, methodParameters, async, isPaging);
            }
        }

        private void WriteMethodBodyWrapper(string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging)
        {
            string asyncText = isAsync ? "Async" : string.Empty;
            string configureAwait = isAsync & !isPaging ? ".ConfigureAwait(false)" : string.Empty;
            string awaitText = isAsync & !isPaging ? " await" : string.Empty;
            _writer.Append($"return{awaitText} GetExtensionClient({ExtensionOperationVariableName}).{methodName}{asyncText}(");

            foreach (var parameter in methodParameters.Skip(1))
            {
                _writer.Append($"{parameter.Name},");
            }

            _writer.RemoveTrailingComma();
            _writer.Line($"){configureAwait};");
        }

        protected void WriteGetRestOperations(MgmtRestClient restClient)
        {
            _writer.Line();
            _writer.Append($"private static {restClient.Type} Get{restClient.Type.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, string applicationId, ");
            // TODO: Use https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783 rest client parameters
            foreach (var parameter in restClient.Parameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Append($")");

            using (_writer.Scope())
            {
                _writer.Append($"return new {restClient.Type}(clientDiagnostics, pipeline, applicationId, ");
                foreach (var parameter in restClient.Parameters)
                {
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
            if (!IsArmCore)
            {
                _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            }
            _writer.WriteXmlDocumentationParameters(collection.ExtraConstructorParameters);
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{collection.Type}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ";
            _writer.Append($"public {modifier} {collection.Type.Name} Get{resource.Type.Name.ResourceNameToPlural()}({instanceParameter}");
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
            string methodName = $"Get{resource.Type.Name}";
            List<Parameter> parameters = new List<Parameter>();
            if (!IsArmCore)
                parameters.Add(ExtensionParameter);
            WriteMethodSignatureWrapper(resource.Type, methodName, parameters, isAsync: false, isPaging: false);
            using (_writer.Scope())
            {
                WriteMethodBodyWrapper(methodName, parameters, isAsync: false, isPaging: false);
            }
        }

        protected override void WriteLROMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = clientOperation.ReturnType!; // LRO return type will never be null

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteLROMethodSignature(lroObjectType, methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                var diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());

                using (WriteDiagnosticScope(_writer, diagnostic, GetClientDiagnosticsPropertyName(operationMappings.Values.First())))
                {
                    WriteLROMethodBody(lroObjectType, operationMappings, parameterMappings, async);
                }
                _writer.Line();
            }
        }

        protected override void WriteLROMethodBranch(CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestPropertyName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, GetClientDiagnosticsPropertyName(operation), "Pipeline", operation, parameterMapping, async);
        }

        // this method checks if the giving opertion corresponding to a list of resources. If it does, this resource will need a GetByName method.
        protected bool CheckGetAllAsGenericMethod(MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (clientOperation.First().IsListMethod(out var itemType))
            {
                if (Context.Library.TryGetTypeProvider(itemType.Name, out var provider) && provider is ResourceData data)
                {
                    var resourcesOfResourceData = Context.Library.FindResources(data);
                    // TODO -- what if we have multiple resources corresponds to the same resource data?
                    // We are not able to determine which resource this opertion belongs, since the list in subsrcirption operation does not have any parenting relationship with other operations.
                    // temporarily directly return and doing nothing when this happens
                    if (resourcesOfResourceData.Count() > 1)
                        return false;
                    // only one resource, this needs a GetByName method
                    resource = resourcesOfResourceData.First();
                    return true;
                }
            }

            return false;
        }

        protected override void WritePagingMethodBody(CSharpType itemType, Diagnostic diagnostic, IDictionary<RequestPath, MgmtRestOperation> operationMappings, IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async, MgmtClientOperation clientOperation)
        {
            // if we only have one branch, we would not need those if-else statements
            var branch = operationMappings.Keys.First();
            WritePagingMethodBranch(itemType, diagnostic, GetClientDiagnosticsPropertyName(operationMappings[branch]), operationMappings[branch], parameterMappings[branch], async);
        }

        protected override void WriteNormalMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            var returnType = WrapResourceDataType(clientOperation.ReturnType, clientOperation.First())?.Type ?? clientOperation.ReturnType;

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteNormalMethodSignature(GetResponseType(returnType, async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());

                using (WriteDiagnosticScope(_writer, diagnostic, GetClientDiagnosticsPropertyName(operationMappings.Values.First())))
                {
                    WriteNormalMethodBody(operationMappings, parameterMappings, async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull);
                }
                _writer.Line();
            }
        }

        /// <summary>
        /// In the extension class, we need to find the correct resource class that links to this resource data, if this is a resource data
        /// </summary>
        /// <param name="type"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected override Resource? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation, out var data))
                return null;

            // we need to find the correct resource type that links with this resource data
            var candidates = Context.Library.FindResources(data);

            // return null when there is no match
            if (!candidates.Any())
                return null;

            // when we only find one result, just return it.
            if (candidates.Count() == 1)
                return candidates.Single();

            // if there is more candidates than one, we are going to some more matching to see if we could determine one
            var resourceType = operation.RequestPath.GetResourceType(Config);
            var filteredResources = candidates.Where(resource => resource.ResourceType == resourceType);

            if (filteredResources.Count() == 1)
                return filteredResources.Single();

            return null;
        }

        /// <summary>
        /// In the extension class, we need to check the type is a resource data or not
        /// </summary>
        /// <param name="type"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = null;
            if (type == null || type.IsFrameworkType)
                return false;

            if (Context.Library.TryGetTypeProvider(type.Name, out var provider))
            {
                data = provider as ResourceData;
                return data != null;
            }
            return false;
        }

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            // we should never have a branch in the operations in an extension class, therefore throwing an exception here
            throw new InvalidOperationException();
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
