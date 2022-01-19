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
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        protected MgmtExtensions _extensions;

        protected bool IsArmCore;
        public MgmtExtensionWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context, bool isArmCore = false) : base(writer, extensions, context)
        {
            _extensions = extensions;
            IsArmCore = isArmCore;
        }

        protected abstract string Description { get; }
        protected abstract string ExtensionOperationVariableName { get; }
        protected abstract Type ExtensionOperationVariableType { get; }

        protected override string IdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string BranchIdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string ContextProperty => ExtensionOperationVariableName;

        protected void WriteDefaultNamespace(CodeWriter writer)
        {
            writer.Line($"private static string _defaultRpNamespace = {typeof(ClientDiagnostics)}.GetResourceProviderNamespace(typeof({TypeNameOfThis}).Assembly);");
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
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it.");
            if (!IsArmCore)
            {
                _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            }
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {ExtensionOperationVariableType} {ExtensionOperationVariableName}";
            using (_writer.Scope($"public {modifier} {resource.Type.Name} Get{resource.Type.Name}({instanceParameter})"))
            {
                _writer.Line($"return new {resource.Type.Name}({ExtensionOperationVariableName}, new {typeof(Azure.Core.ResourceIdentifier)}({ExtensionOperationVariableName}.Id + \"/{singletonResourceSuffix}\"));");
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
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = clientOperation.ReturnType!; // LRO return type will never be null

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteLROMethodSignature(lroObjectType, methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, async))
                {
                    var diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientDiagnosticsAssignment("options", clientOperation.ReturnType?.Name);

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
            WriteRestOperationAssignment(operation);
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, ClientDiagnosticsVariable, "pipeline", operation, parameterMapping, async);
        }

        protected override void WritePagingMethod(MgmtClientOperation clientOperation, CSharpType itemType, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            var pagingMethod = clientOperation.First().GetPagingMethod(Context)!;
            var wrapResource = WrapResourceDataType(itemType, clientOperation.First());
            var actualItemType = wrapResource?.Type ?? itemType;

            _writer.WriteXmlDocumentationSummary($"Lists the {actualItemType.Name.LastWordToPlural()} for this <see cref=\"{ExtensionOperationVariableType}\" />.");
            WritePagingMethodSignature(actualItemType, methodName, methodParameters, async, clientOperation.Accessibility, false);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                // the wrapper for paging method will never be async
                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, false))
                {
                    var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WritePagingMethodBody(itemType, diagnostic, operationMappings, parameterMappings, async);
                }
            }
            _writer.Line();
        }

        protected override void WritePagingMethodBody(CSharpType itemType, Diagnostic diagnostic, IDictionary<RequestPath, MgmtRestOperation> operationMappings, IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // if we only have one branch, we would not need those if-else statements
            var branch = operationMappings.Keys.First();
            WritePagingMethodBranch(itemType, diagnostic, ClientDiagnosticsVariable, operationMappings[branch], parameterMappings[branch], async);
        }

        protected override void WritePagingMethodBranch(CSharpType itemType, Diagnostic diagnostic, string diagnosticVariable, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            WriteClientDiagnosticsAssignment("options", itemType.Name);

            WriteRestOperationAssignment(operation);

            base.WritePagingMethodBranch(itemType, diagnostic, diagnosticVariable, operation, parameterMappings, async);
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
            _writer.Append($"{accessibility} static {GetAsyncKeyword(async)} {responseType} {CreateMethodName(methodName, async)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
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

                using (WriteExtensionContextScope(_writer, ExtensionOperationVariableName, async))
                {
                    var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientDiagnosticsAssignment("options", clientOperation.ReturnType?.Name);

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
            WriteRestOperationAssignment(operation);

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

        private void WriteClientDiagnosticsAssignment(string optionsVariable, string? providerNamespace)
        {
            var namespaceToUse = providerNamespace;
            if (providerNamespace is null)
            {
                namespaceToUse = "_defaultRpNamespace";
            }
            else
            {
                var data = Context.Library.ResourceData.FirstOrDefault(data => data.Declaration.Name == providerNamespace);
                if (data is not null)
                {
                    namespaceToUse = $"{providerNamespace.Substring(0, providerNamespace.Length - 4)}.ResourceType.Namespace";
                }
                else
                {
                    var resource = Context.Library.ArmResources.FirstOrDefault(resource => resource.Declaration.Name == providerNamespace);
                    if (resource is not null)
                    {
                        namespaceToUse = $"{providerNamespace}.ResourceType.Namespace";
                    }
                    else
                    {
                        namespaceToUse = "_defaultRpNamespace";
                    }
                }
            }
            _writer.Line($"var {ClientDiagnosticsVariable} = new {typeof(ClientDiagnostics)}(\"{_extensions.Declaration.Namespace}\", {namespaceToUse}, diagnosticOptions);");
        }

        private void WriteRestOperationAssignment(MgmtRestOperation operation)
        {
            var resource = operation.Resource;
            var restClient = operation.RestClient;
            Func<MgmtRestClient, string> getSubId = (restClient) =>
            {
                return restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? $", {ExtensionOperationVariableName}.Id.SubscriptionId" : "";
            };
            if (resource != null)
            {
                WriteRestClientConstructionForResource(resource, new MgmtRestClient[] { restClient }, getSubId, ClientDiagnosticsVariable, "diagnosticOptions", $"armClient", "pipeline", "baseUri", "Get", true);
            }
            else
            {
                _writer.Line($"{restClient.Type.Name} {GetRestClientVariableName(restClient)} = Get{restClient.Type.Name}({ClientDiagnosticsVariable}, pipeline, diagnosticOptions.ApplicationId{getSubId(restClient)}, baseUri);");
            }
        }

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            // we should never have a branch in the operations in an extension class, therefore throwing an exception here
            throw new InvalidOperationException();
        }

        protected static IDisposable WriteExtensionContextScope(CodeWriter writer, string extensionVariableName, bool async)
        {
            writer.Append($"return {GetAwait(async)} {extensionVariableName}.UseClientContext({GetAsyncKeyword(async)} (armClient, baseUri, diagnosticOptions, pipeline) =>");
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
