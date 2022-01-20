// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using SubscriptionExtensions = AutoRest.CSharp.Mgmt.Output.SubscriptionExtensions;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class SubscriptionExtensionsWriter : MgmtExtensionWriter
    {
        public SubscriptionExtensionsWriter(CodeWriter writer, SubscriptionExtensions subscriptionExtensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, subscriptionExtensions, context, typeof(Subscription))
        {
        }

        protected override string Description => "A class to add extension methods to Subscription.";
        protected override string ExtensionOperationVariableName => "subscription";

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    WriteProviderDefaultNamespace(_writer);

                    // Write resource collection entries
                    WriteChildResourceEntries();

                    WriteExtensionClientGet();

                    var resourcesWithGetAllAsGenericMethod = new HashSet<Resource>();
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        WriteMethodWrapper(clientOperation, true);
                        WriteMethodWrapper(clientOperation, false);

                        // we only check if a resource needs a GetByName method when it has a List operation in the subscription extension.
                        // If its parent is Subscription, we will have a GetCollection method of that resource, which contains a GetAllAsGenericResource serves the same purpose.
                        if (CheckGetAllAsGenericMethod(clientOperation, out var resource))
                        {
                            // in case that a resource has multiple list methods at the subscription level (for instance one ListBySusbcription and one ListByLocation, location is not an available parent therefore it will show up here)
                            if (resourcesWithGetAllAsGenericMethod.Contains(resource))
                                continue;
                            WriteGetAllResourcesAsGenericMethodWrapper(resource, true);
                            WriteGetAllResourcesAsGenericMethodWrapper(resource, false);
                            resourcesWithGetAllAsGenericMethod.Add(resource);
                        }
                    }
                }
            }
        }

        private void WriteExtensionClientGet()
        {
            _writer.Line();
            using (_writer.Scope($"private static {ExtensionOperationVariableType.Name}ExtensionClient GetExtensionClient({ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                using (_writer.Scope($"return {ExtensionOperationVariableName}.GetCachedClient((armClient) =>"))
                {
                    _writer.Line($"return new {ExtensionOperationVariableType.Name}ExtensionClient(armClient, {ExtensionOperationVariableName}.Id);");
                }
                _writer.Line($");");
            }
        }

        protected void WriteMethodWrapper(MgmtClientOperation clientOperation, bool async)
        {
            // we need to identify this operation belongs to which category: NormalMethod, NormalListMethod, LROMethod or PagingMethod
            if (clientOperation.IsLongRunningOperation() && !clientOperation.IsPagingOperation(Context))
            {
                // this is a non-pageable long-running operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType!, async, false, true, WriteLROMethodSignature);
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
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, GetActualItemType(clientOperation, itemType), async, true, false, WritePagingMethodSignature);
            }
            else if (clientOperation.IsListOperation(Context, out var itemType))
            {
                // this is a normal list operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, GetActualItemType(clientOperation, itemType), async, true, false, WritePagingMethodSignature);
            }
            else
            {
                // this is a normal operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType!, async, false, false, WriteNormalMethodSignature);
            }
        }

        private CSharpType GetActualItemType(MgmtClientOperation clientOperation, CSharpType itemType)
        {
            var wrapResource = WrapResourceDataType(itemType, clientOperation.First());
            CSharpType actualItemType = wrapResource?.Type ?? itemType;
            return actualItemType;
        }

        private void WriteMethodWrapperImpl(
            MgmtClientOperation clientOperation,
            string methodName,
            CSharpType itemType,
            bool async,
            bool isPaging,
            bool isLro,
            Action<CSharpType, string, IReadOnlyList<Parameter>, bool, string, bool> signatureMethod)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            signatureMethod(itemType, methodName, methodParameters, async, "public", true);
            using (_writer.Scope())
            {
                WriteMethodBodyWrapper(methodName, methodParameters, async, isPaging, isLro);
            }
        }

        protected override void WritePagingMethodSignature(CSharpType actualItemType, string methodName, IReadOnlyList<Parameter> methodParameters,
            bool async, string accessibility = "public", bool isVirtual = true)
        {
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = actualItemType.WrapPageable(async);
            _writer.Append($"{accessibility} static {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }
        protected override void WriteLROMethodSignature(CSharpType returnType, string methodName, IReadOnlyList<Parameter> methodParameters, bool async,
            string accessibility = "public", bool isVirtual = true)
        {
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            _writer.Append($"{accessibility} static {GetAsyncKeyword(async)} {returnType.WrapAsync(async)} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");
            _writer.Append($"bool waitForCompletion, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }

            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        protected override void WriteNormalMethodSignature(CSharpType responseType, string methodName, IReadOnlyList<Parameter> methodParameters,
            bool async, string accessibility = "public", bool isVirtual = true)
        {
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            _writer.Append($"{accessibility} static {GetAsyncKeyword(async)} {responseType.WrapAsync(async)} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        private void WriteGetAllResourcesAsGenericMethodWrapper(Resource resource, bool isAsync)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {resource.ResourceName.LastWordToPlural()} for a <see cref=\"{typeof(Subscription)}\" /> represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(Subscription)}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = typeof(GenericResource).WrapPageable(isAsync);
            string methodName = CreateMethodName($"Get{resource.Type.Name.ResourceNameToPlural()}AsGenericResources", isAsync);
            using (_writer.Scope($"public static {responseType} {methodName}(this {typeof(Subscription)} subscription, {typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                _writer.Line($"return GetExtensionClient({ExtensionOperationVariableName}).{methodName}(filter, expand, top, cancellationToken);");
            }
        }

        private void WriteMethodBodyWrapper(string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging, bool isLro)
        {
            string asyncText = isAsync ? "Async" : string.Empty;
            string configureAwait = isAsync & !isPaging ? ".ConfigureAwait(false)" : string.Empty;
            string awaitText = isAsync & !isPaging ? " await" : string.Empty;
            _writer.Append($"return{awaitText} GetExtensionClient({ExtensionOperationVariableName}).{methodName}{asyncText}(");
            bool isFirst = true;
            if (isLro)
            {
                _writer.Append($"waitForCompletion");
                isFirst = false;
            }
            foreach (var parameter in methodParameters)
            {
                if (!isFirst)
                {
                    _writer.Append($", ");
                }
                _writer.Append($"{parameter.Name}");
                isFirst = false;
            }
            if (!isFirst)
                _writer.Append($", ");
            _writer.Line($"cancellationToken){configureAwait};");
        }
    }
}
