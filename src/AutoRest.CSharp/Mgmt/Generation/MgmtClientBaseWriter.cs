﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Generation.Writers;
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
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected const string BaseUriProperty = "BaseUri";
        protected delegate void WriteMethodDelegate(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync);
        private string LibraryArmOperation { get; }
        protected bool IsArmCore { get; }
        protected CodeWriter _writer;
        protected override string RestClientAccessibility => "private";

        private MgmtTypeProvider This { get; }

        protected virtual string ArmClientReference { get; } = "Client";

        protected virtual bool UseField => true;

        public string FileName { get; }

        protected MgmtClientBaseWriter(CodeWriter writer, MgmtTypeProvider provider)
        {
            _writer = writer;
            This = provider;
            FileName = This.Type.Name;
            IsArmCore = Configuration.MgmtConfiguration.IsArmCore;
            LibraryArmOperation = $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}ArmOperation";
        }

        public virtual void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    WriteImplementations();
                }
            }
        }

        protected internal virtual void WriteImplementations()
        {
            WriteStaticMethods();

            WriteFields();

            WriteCtors();

            WriteProperties();

            WritePrivateHelpers();

            WriteChildResourceEntries();

            // Write other orphan operations with the parent of ResourceGroup
            foreach (var clientOperation in This.AllOperations)
            {
                WriteMethod(clientOperation, true);
                WriteMethod(clientOperation, false);
            }

            if (This.EnumerableInterfaces.Any())
                WriteEnumerables();
        }

        protected virtual void WritePrivateHelpers() { }
        protected virtual void WriteProperties() { }
        protected virtual void WriteStaticMethods() { }

        protected void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary($"{This.Description}");
            _writer.Append($"{This.Accessibility}");
            if (This.IsStatic)
                _writer.Append($" static");
            _writer.Append($" partial class {This.Type.Name}");
            if (This.GetImplementsList().Any())
            {
                _writer.Append($" : ");
                foreach (var type in This.GetImplementsList())
                {
                    _writer.Append($"{type:D},");
                }
                _writer.RemoveTrailingComma();
            }
            _writer.Line();
        }

        protected virtual void WriteCtors()
        {
            if (This.IsStatic)
                return;

            if (This.MockingCtor is not null)
            {
                _writer.WriteMethodDocumentation(This.MockingCtor);
                using (_writer.WriteMethodDeclaration(This.MockingCtor))
                {
                }
            }

            _writer.Line();
            if (This.ResourceDataCtor is not null)
            {
                _writer.WriteMethodDocumentation(This.ResourceDataCtor);
                using (_writer.WriteMethodDeclaration(This.ResourceDataCtor))
                {
                    _writer.Line($"HasData = true;");
                    _writer.Line($"_data = {This.DefaultResource!.ResourceDataParameter.Name};");
                }
            }

            _writer.Line();
            if (This.ArmClientCtor is not null)
            {
                _writer.Line();
                _writer.WriteMethodDocumentation(This.ArmClientCtor);
                using (_writer.WriteMethodDeclaration(This.ArmClientCtor))
                {
                    if (This is MgmtExtensionClient)
                        return;

                    foreach (var param in This.ExtraConstructorParameters)
                    {
                        _writer.Line($"_{param.Name} = {param.Name};");
                    }

                    foreach (var set in This.UniqueSets)
                    {
                        WriteRestClientConstructorPair(set.RestClient, set.Resource);
                    }
                    if (This.CanValidateResourceType)
                        WriteDebugValidate();
                }
            }
            _writer.Line();
        }

        private void WriteIEnumerable(CSharpType type)
        {
            _writer.Line();
            var enumeratorType = new CSharpType(typeof(IEnumerator<>), type.Arguments);
            _writer.Line($"{enumeratorType:I} {type:I}.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll().GetEnumerator();");
            }
            _writer.Line();
            _writer.Line($"{typeof(IEnumerator)} {typeof(IEnumerable)}.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll().GetEnumerator();");
            }
        }

        private void WriteIAsyncEnumerable(CSharpType type)
        {
            _writer.Line();
            var enumeratorType = new CSharpType(typeof(IAsyncEnumerator<>), type.Arguments);
            _writer.Line($"{enumeratorType:I} {type:I}.GetAsyncEnumerator({KnownParameters.CancellationTokenParameter.Type:I} {KnownParameters.CancellationTokenParameter.Name})");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAllAsync({KnownParameters.CancellationTokenParameter.Name}: {KnownParameters.CancellationTokenParameter.Name}).GetAsyncEnumerator({KnownParameters.CancellationTokenParameter.Name});");
            }
        }

        private void WriteEnumerables()
        {
            foreach (var type in This.EnumerableInterfaces)
            {
                if (type.Name.StartsWith("IEnumerable"))
                    WriteIEnumerable(type);
                if (type.Name.StartsWith("IAsyncEnumerable"))
                    WriteIAsyncEnumerable(type);
            }
        }

        protected void WriteRestClientConstructorPair(MgmtRestClient restClient, Resource? resource)
        {
            string? resourceName = resource?.Type.Name;
            FormattableString ctorString = ConstructClientDiagnostic(_writer, $"{GetProviderNamespaceFromReturnType(resourceName)}", DiagnosticOptionsProperty);
            string diagFieldName = GetDiagnosticFieldName(restClient, resource);
            _writer.Line($"{diagFieldName} = {ctorString};");
            string apiVersionText = string.Empty;
            if (resource is not null)
            {
                string apiVersionVariable = GetApiVersionVariableName(restClient, resource);
                _writer.Line($"TryGetApiVersion({resourceName}.ResourceType, out string {apiVersionVariable});");
                apiVersionText = $", {apiVersionVariable}";
            }
            _writer.Line($"{GetRestFieldName(restClient, resource)} = {GetRestConstructorString(restClient, apiVersionText)};");
        }

        protected virtual void WriteChildResourceEntries()
        {
            foreach (var resource in This.ChildResources)
            {
                _writer.Line();
                if (resource.IsSingleton)
                {
                    WriteSingletonResourceGetMethod(resource);
                }
                else if (resource.ResourceCollection is not null)
                {
                    WriteResourceCollectionGetMethod(resource);

                    if (!(This is MgmtExtensionClient)) // we don't need to generate `Get{Resource}` methods in ExtensionClient
                    {
                        WriteChildResourceGetMethod(resource.ResourceCollection, true);
                        WriteChildResourceGetMethod(resource.ResourceCollection, false);
                    }
                }
            }
            _writer.Line();
        }

        private void WriteSingletonResourceGetMethod(Resource resource)
        {
            var signature = new MethodSignature(
                $"Get{resource.Type.Name}",
                $"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.Type.Name}.",
                GetMethodModifiers(),
                resource.Type,
                $"Returns a <see cref=\"{resource.Type}\" /> object.",
                GetParametersForSingletonEntry());
            using (WriteCommonMethod(signature, null, false))
            {
                WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!, signature);
            }
        }

        private void WriteResourceCollectionGetMethod(Resource resource)
        {
            var resourceCollection = resource.ResourceCollection!;
            var signature = new MethodSignature(
                $"{GetResourceCollectionMethodName(resourceCollection)}",
                $"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {resource.Type.Name}.",
                GetMethodModifiers(),
                resourceCollection.Type,
                $"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.",
                GetParametersForCollectionEntry(resourceCollection));
            using (WriteCommonMethod(signature, null, false))
            {
                WriteResourceCollectionEntry(resourceCollection, signature);
            }
        }

        private void WriteChildResourceGetMethod(ResourceCollection resourceCollection, bool isAsync)
        {
            //TODO we need to figure out why Tenant is a child of Tenant, this shouldn't happen but this work around
            //will keep us from trying to make a call to [Resource]Collection inside [Resource]
            if (resourceCollection.ResourceName == This.ResourceName)
                return;

            var getOperation = resourceCollection.GetOperation;
            // Copy the original method signature with changes in name and modifier (e.g. when adding into extension class, the modifier should be static)
            var methodSignature = getOperation.MethodSignature with
            {
                // name after `Get{ResourceType}`
                Name = $"{getOperation.MethodSignature.Name}{resourceCollection.Resource.Type.Name}",
                Modifiers = GetMethodModifiers(),
                // There could be parameters to get resource collection
                Parameters = GetParametersForCollectionEntry(resourceCollection).Concat(GetParametersForResourceEntry(resourceCollection)).ToArray(),
            };

            _writer.Line();
            using (WriteCommonMethodWithoutValidation(methodSignature, getOperation.ReturnsDescription != null ? getOperation.ReturnsDescription(isAsync) : null, isAsync))
            {
                WriteResourceEntry(resourceCollection, isAsync);
            }
        }

        protected virtual void WriteResourceEntry(ResourceCollection resourceCollection, bool isAsync)
        {
            var operation = resourceCollection.GetOperation;
            string awaitText = isAsync & !operation.IsPagingOperation ? " await" : string.Empty;
            string configureAwait = isAsync & !operation.IsPagingOperation ? ".ConfigureAwait(false)" : string.Empty;
            var arguments = string.Join(", ", operation.MethodSignature.Parameters.Select(p => p.Name));
            _writer.Line($"return{awaitText} {GetResourceCollectionMethodName(resourceCollection)}({GetResourceCollectionMethodArgumentList(resourceCollection)}).{operation.MethodSignature.WithAsync(isAsync).Name}({arguments}){configureAwait};");
        }

        protected string GetResourceCollectionMethodName(ResourceCollection resourceCollection)
        {
            return $"Get{resourceCollection.Resource.Type.Name.ResourceNameToPlural()}";
        }

        protected string GetResourceCollectionMethodArgumentList(ResourceCollection resourceCollection)
        {
            return string.Join(", ", GetParametersForCollectionEntry(resourceCollection).Select(p => p.Name));
        }

        protected virtual void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix, MethodSignature signature)
        {
            // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
            // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
            _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, new {typeof(Azure.Core.ResourceIdentifier)}(Id.ToString() + \"/{singletonResourceIdSuffix}\"));");
        }

        protected virtual MethodSignatureModifiers GetMethodModifiers() => Public | Virtual;

        protected virtual Parameter[] GetParametersForSingletonEntry() => Array.Empty<Parameter>();

        protected virtual Parameter[] GetParametersForCollectionEntry(ResourceCollection resourceCollection)
        {
            return resourceCollection.ExtraConstructorParameters.ToArray();
        }

        protected Parameter[] GetParametersForResourceEntry(ResourceCollection resourceCollection)
        {
            return resourceCollection.GetOperation.MethodSignature.Parameters.ToArray();
        }

        protected virtual void WriteResourceCollectionEntry(ResourceCollection resourceCollection, MethodSignature signature)
        {
            // TODO: can we cache collection with extra constructor parameters
            if (resourceCollection.ExtraConstructorParameters.Count() > 0)
            {
                _writer.Append($"return new {resourceCollection.Type.Name}({ArmClientReference}, Id, ");
                foreach (var parameter in resourceCollection.ExtraConstructorParameters)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
            else
            {
                // for collections without extra constructor parameter, we can return a cached instance
                _writer.Line($"return GetCachedClient({ArmClientReference} => new {resourceCollection.Type.Name}({ArmClientReference}, Id));");
            }
        }

        protected void WriteStaticValidate(FormattableString validResourceType)
        {
            using (_writer.Scope($"internal static void ValidateResourceId({typeof(Azure.Core.ResourceIdentifier)} id)"))
            {
                _writer.Line($"if (id.ResourceType != {validResourceType})");
                _writer.Line($"throw new {typeof(ArgumentException)}(string.Format({typeof(CultureInfo)}.CurrentCulture, \"Invalid resource type {{0}} expected {{1}}\", id.ResourceType, {validResourceType}), nameof(id));");
            }
        }

        protected void WriteDebugValidate()
        {
            _writer.Line($"#if DEBUG");
            _writer.Line($"\t\t\tValidateResourceId(Id);");
            _writer.Line($"#endif");
        }

        protected void WriteFields()
        {
            foreach (var field in This.Fields)
            {
                _writer.WriteFieldDeclaration(field);
            }
            _writer.Line();
        }

        protected FormattableString GetProviderNamespaceFromReturnType(string? returnType)
        {
            if (returnType is null)
                return $"ProviderConstants.DefaultProviderNamespace";

            var resource = MgmtContext.Library.ArmResources.FirstOrDefault(resource => resource.Declaration.Name == returnType);
            if (resource is not null)
                return $"{returnType}.ResourceType.Namespace";

            if (MgmtContext.Library.TryGetTypeProvider(returnType, out var p) && p is ResourceData data)
                return $"{returnType.Substring(0, returnType.Length - 4)}.ResourceType.Namespace";

            return $"ProviderConstants.DefaultProviderNamespace";
        }

        protected FormattableString ConstructClientDiagnostic(CodeWriter writer, FormattableString providerNamespace, string diagnosticsOptionsVariable)
        {
            return $"new {typeof(ClientDiagnostics)}(\"{This.Type.Namespace}\", {providerNamespace}, {diagnosticsOptionsVariable})";
        }

        protected string GetRestConstructorString(MgmtRestClient restClient, string apiVersionVariable)
        {
            string subIdVariable = ", Id.SubscriptionId";
            if (!restClient.Parameters.Any(p => p.Name.Equals("subscriptionId")))
                subIdVariable = string.Empty;
            return $"new {restClient.Type.Name}({PipelineProperty}, {DiagnosticOptionsProperty}.ApplicationId{subIdVariable}, {BaseUriProperty}{apiVersionVariable})";
        }

        protected string GetRestClientName(MgmtRestOperation operation) => GetRestClientName(operation.RestClient, operation.Resource);
        private string GetRestClientName(MgmtRestClient client, Resource? resource)
        {
            var names = This.GetRestDiagNames(new NameSetKey(client, resource));
            return UseField ? names.RestField : names.RestProperty;
        }

        protected string GetDiagnosticName(MgmtRestOperation operation) => GetDiagnosticName(operation.RestClient, operation.Resource);
        private string GetDiagnosticName(MgmtRestClient client, Resource? resource)
        {
            var names = This.GetRestDiagNames(new NameSetKey(client, resource));
            return UseField ? names.DiagnosticField : names.DiagnosticProperty;
        }

        protected string GetRestPropertyName(MgmtRestClient client, Resource? resource) => This.GetRestDiagNames(new NameSetKey(client, resource)).RestProperty;
        protected string GetRestFieldName(MgmtRestClient client, Resource? resource) => This.GetRestDiagNames(new NameSetKey(client, resource)).RestField;
        protected string GetDiagnosticsPropertyName(MgmtRestClient client, Resource? resource) => This.GetRestDiagNames(new NameSetKey(client, resource)).DiagnosticProperty;
        protected string GetDiagnosticFieldName(MgmtRestClient client, Resource? resource) => This.GetRestDiagNames(new NameSetKey(client, resource)).DiagnosticField;
        protected virtual string GetApiVersionVariableName(MgmtRestClient client, Resource? resource) => This.GetRestDiagNames(new NameSetKey(client, resource)).ApiVersionVariable;

        protected internal static string GetConfigureAwait(bool isAsync)
        {
            return isAsync ? ".ConfigureAwait(false)" : string.Empty;
        }

        protected internal static string GetAsyncKeyword(bool isAsync)
        {
            return isAsync ? "async" : string.Empty;
        }

        protected internal static string GetAwait(bool isAsync)
        {
            return isAsync ? "await " : string.Empty;
        }

        protected internal static string GetNextLink(bool isNextPageFunc)
        {
            return isNextPageFunc ? "nextLink, " : string.Empty;
        }

        protected void WriteRequestPathAndOperationId(MgmtClientOperation clientOperation)
        {
            foreach (var operation in clientOperation)
            {
                _writer.Line($"/// RequestPath: {operation.RequestPath}");
                _writer.Line($"/// ContextualPath: {operation.ContextualPath}");
                _writer.Line($"/// OperationId: {operation.OperationId}");
            }
        }

        protected FormattableString GetResourceTypeExpression(ResourceTypeSegment resourceType)
        {
            if (resourceType == ResourceTypeSegment.ResourceGroup)
                return $"{typeof(ResourceGroup)}.ResourceType";
            if (resourceType == ResourceTypeSegment.Subscription)
                return $"{typeof(Subscription)}.ResourceType";
            if (resourceType == ResourceTypeSegment.Tenant)
                return $"{typeof(Tenant)}.ResourceType";
            if (resourceType == ResourceTypeSegment.ManagementGroup)
                return $"{typeof(ManagementGroup)}.ResourceType";

            if (!resourceType.IsConstant)
                throw new NotImplementedException($"ResourceType that contains variables are not supported yet");

            // find the corresponding class of this resource type. If we find only one, use the constant inside that class. If we have multiple, use the hard-coded magic string
            var candidates = MgmtContext.Library.ArmResources.Where(resource => resource.ResourceType == resourceType);
            if (candidates.Count() == 1)
            {
                return $"{candidates.First().Type}.ResourceType";
            }
            return $"\"{resourceType.SerializedType}\"";
        }

        protected virtual void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            var writeBody = GetMethodDelegate(clientOperation);
            using (WriteCommonMethod(clientOperation, isAsync))
            {
                var diagnostic = new Diagnostic($"{This.Type.Name}.{clientOperation.Name}", Array.Empty<DiagnosticAttribute>());
                writeBody(clientOperation, diagnostic, isAsync);
            }
        }

        protected Dictionary<string, WriteMethodDelegate> _customMethods = new Dictionary<string, WriteMethodDelegate>();
        private WriteMethodDelegate GetMethodDelegate(MgmtClientOperation clientOperation)
        {
            if (clientOperation.IsLongRunningOperation && clientOperation.IsPagingOperation)
                throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");

            if (!_customMethods.TryGetValue($"Write{clientOperation.Name}Body", out var function))
            {
                function = GetMethodDelegate(clientOperation.IsLongRunningOperation, clientOperation.IsPagingOperation);
            }

            return function;
        }

        protected virtual WriteMethodDelegate GetMethodDelegate(bool isLongRunning, bool isPaging)
            => (isLongRunning, isPaging) switch
            {
                (true, false) => WriteLROMethodBody,
                (false, true) => WritePagingMethodBody,
                (false, false) => WriteNormalMethodBody,
                _ => throw new InvalidOperationException("Unknown method combination"),
            };

        protected CodeWriter.CodeWriterScope WriteCommonMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            _writer.Line();
            var returnDescription = clientOperation.ReturnsDescription is not null ? clientOperation.ReturnsDescription(isAsync) : null;
            return WriteCommonMethod(clientOperation.MethodSignature, returnDescription, isAsync);
        }

        protected CodeWriter.CodeWriterScope WriteCommonMethod(MethodSignature signature, FormattableString? returnDescription, bool isAsync)
        {
            var scope = WriteCommonMethodWithoutValidation(signature, returnDescription, isAsync);
            if (This.Accessibility == "public")
                _writer.WriteParametersValidation(signature.Parameters);

            return scope;
        }

        private CodeWriter.CodeWriterScope WriteCommonMethodWithoutValidation(MethodSignature signature, FormattableString? returnDescription, bool isAsync)
        {
            _writer.WriteXmlDocumentationSummary($"{signature.Description}");
            _writer.WriteXmlDocumentationParameters(signature.Parameters);
            if (This.Accessibility == "public")
            {
                _writer.WriteXmlDocumentationNonEmptyParametersException(signature.Parameters);
                _writer.WriteXmlDocumentationRequiredParametersException(signature.Parameters);
            }

            FormattableString? returnDesc = returnDescription ?? signature.ReturnDescription;
            if (returnDesc is not null)
                _writer.WriteXmlDocumentationReturns(returnDesc);

            return _writer.WriteMethodDeclaration(signature.WithAsync(isAsync));
        }

        #region PagingMethod
        protected virtual void WritePagingMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here
            // TODO -- find a better way to get this type
            string clientDiagFieldName = GetDiagnosticName(clientOperation.OperationMappings.First().Value);
            // we need to write multiple branches for a paging method
            if (clientOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = clientOperation.OperationMappings.Keys.First();
                WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagFieldName, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], isAsync);
            }
            else
            {
                var keyword = "if";
                var escapeBranches = new List<RequestPath>();
                foreach ((var branch, var operation) in clientOperation.OperationMappings)
                {
                    // we need to identify the correct branch using the resource type, therefore we need first to determine the resource type is a constant
                    var resourceType = This.GetBranchResourceType(branch);
                    if (!resourceType.IsConstant)
                    {
                        escapeBranches.Add(branch);
                        continue;
                    }
                    using (_writer.Scope($"{keyword} ({This.BranchIdVariableName}.ResourceType == {GetResourceTypeExpression(resourceType)})"))
                    {
                        WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagFieldName, operation, clientOperation.ParameterMappings[branch], isAsync);
                    }
                    keyword = "else if";
                }
                if (escapeBranches.Count == 0)
                {
                    using (_writer.Scope($"else"))
                    {
                        _writer.Line($"throw new InvalidOperationException($\"{{{This.BranchIdVariableName}.ResourceType}} is not supported here\");");
                    }
                }
                else if (escapeBranches.Count == 1)
                {
                    var branch = escapeBranches.First();
                    using (_writer.Scope($"else"))
                    {
                        WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagFieldName, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], isAsync);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"It is impossible to identify which branch to go here using Id for request paths: [{string.Join(", ", escapeBranches)}]");
                }
            }
        }

        protected virtual void WritePagingMethodBranch(CSharpType itemType, Diagnostic diagnostic, string diagnosticVariable, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var pagingMethod = operation.PagingMethod!;
            var returnType = new CSharpType(typeof(Page<>), itemType).WrapAsync(async);

            using (_writer.Scope($"{GetAsyncKeyword(async)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                using (WriteDiagnosticScope(_writer, diagnostic, diagnosticVariable))
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
                    using (WriteDiagnosticScope(_writer, diagnostic, diagnosticVariable))
                    {
                        WritePageFunctionBody(itemType, pagingMethod, operation, parameterMappings, async, true);
                    }
                }
            }
            _writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        protected void WritePageFunctionBody(CSharpType itemType, PagingMethodWrapper pagingMethod, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool isAsync, bool isNextPageFunc)
        {
            var continuationTokenText = pagingMethod.NextLinkName != null ? $"response.Value.{pagingMethod.NextLinkName}" : "null";
            var response = new CodeWriterDeclaration("response");

            _writer.Append($"var {response:D} = {GetAwait(isAsync)} {GetRestClientName(operation)}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, isAsync)}({GetNextLink(isNextPageFunc)}");
            WriteArguments(_writer, parameterMappings);
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            _writer
                .Append($"return {typeof(Page)}.FromValues(response.Value")
                .AppendIf($".{pagingMethod.ItemName}", !pagingMethod.ItemName.IsNullOrEmpty());


            Resource? resource = MgmtContext.Library.ArmResources.FirstOrDefault(resource => resource.Type.Equals(itemType));
            // only when we are listing ourselves, we use Select to convert XXXResourceData to XXXResource
            if (resource is null)
                resource = operation.Resource is not null && operation.Resource.Type.Equals(itemType)
                    ? operation.Resource
                    : This.DefaultResource;
            if (resource is not null && resource.Type.Equals(itemType))
            {
                _writer.UseNamespace(typeof(Enumerable).Namespace!);

                var value = new CodeWriterDeclaration("value");
                _writer.Append($@".Select({value:D} => ");
                if (resource.ResourceData.ShouldSetResourceIdentifier)
                {
                    using (_writer.Scope())
                    {
                        _writer
                            .Line($"{value}.Id = {CreateResourceIdentifierExpression(resource, operation.RequestPath, parameterMappings, $"{value}")};")
                            .Line($"return new {itemType}({ArmClientReference}, {value});");
                    }
                }
                else
                {
                    _writer.Append($"new {itemType}({ArmClientReference}, {value})");
                }
                _writer.AppendRaw(")");
            }

            _writer.Line($", {continuationTokenText}, {response}.GetRawResponse());");
        }

        protected FormattableString CreateResourceIdentifierExpression(Resource resource, RequestPath requestPath, IEnumerable<ParameterMapping> parameterMappings, FormattableString dataExpression)
        {
            var methodWithLeastParameters = resource.CreateResourceIdentifierMethodSignature().Values.OrderBy(method => method.Parameters.Count).First();
            var cache = new List<ParameterMapping>(parameterMappings);

            var parameterInvocations = new List<FormattableString>();
            foreach (var reference in requestPath.Where(s => s.IsReference).Select(s => s.Reference))
            {
                var match = cache.First(p => reference.Name.Equals(p.Parameter.Name, StringComparison.InvariantCultureIgnoreCase) && reference.Type.Equals(p.Parameter.Type));
                cache.Remove(match);
                parameterInvocations.Add(match.IsPassThru ? $"{match.Parameter.Name}" : match.ValueExpression);
            }

            if (parameterInvocations.Count < methodWithLeastParameters.Parameters.Count)
            {
                if (resource.ResourceData.GetTypeOfName() != null)
                {
                    parameterInvocations.Add($"{dataExpression}.Name");
                }
                else
                {
                    throw new ErrorHelpers.ErrorException($"The resource data {resource.ResourceData.Type.Name} does not have a `Name` property, which is required when assigning non-resource as resources");
                }
            }

            return $"{resource.Type.Name}.CreateResourceIdentifier({parameterInvocations.Join(", ")})";
        }
        #endregion

        #region NormalMethod
        protected virtual void WriteNormalMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            // we need to write multiple branches for a normal method
            if (clientOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = clientOperation.OperationMappings.Keys.First();
                WriteNormalMethodBranch(clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], diagnostic, async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        protected virtual void WriteNormalMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, Diagnostic diagnostic, bool async)
        {
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(operation)))
            {
                var response = new CodeWriterDeclaration("response");
                _writer
                    .Append($"var {response:D} = {GetAwait(async)} ")
                    .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
                WriteArguments(_writer, parameterMappings);
                _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

                Resource? resource = MgmtContext.Library.ArmResources.FirstOrDefault(resource => resource.Type.Equals(operation.ReturnType.UnWrapResponse()));
                resource ??= operation.Resource != null && operation.Resource.Type.Equals(operation.ReturnType.UnWrapResponse()) ? operation.Resource : null;
                if (resource is not null)
                {
                    if (operation.ThrowIfNull)
                    {
                        _writer
                            .Line($"if ({response}.Value == null)")
                            .Line($"throw new {typeof(RequestFailedException)}({response}.GetRawResponse());");
                    }

                    if (resource.ResourceData.ShouldSetResourceIdentifier)
                    {
                        _writer.Line($"{response}.Value.Id = {CreateResourceIdentifierExpression(resource, operation.RequestPath, parameterMappings, $"{response}.Value")};");
                    }

                    _writer.Line($"return {typeof(Response)}.FromValue(new {resource.Type}({ArmClientReference}, {response}.Value), {response}.GetRawResponse());");
                }
                else
                {
                    _writer.Line($"return {response};");
                }
            }
        }
        #endregion

        #region LROMethod
        protected virtual void WriteLROMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool async)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            // TODO -- we need to write multiple branches for a LRO operation
            using (WriteDiagnosticScope(_writer, diagnostic, GetDiagnosticName(clientOperation.OperationMappings.Values.First())))
            {
                if (clientOperation.OperationMappings.Count == 1)
                {
                    // if we only have one branch, we would not need those if-else statements
                    var branch = clientOperation.OperationMappings.Keys.First();
                    WriteLROMethodBranch(clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], async);
                }
                else
                {
                    var keyword = "if";
                    var escapeBranches = new List<RequestPath>();
                    foreach ((var branch, var operation) in clientOperation.OperationMappings)
                    {
                        // we need to identify the correct branch using the resource type, therefore we need first to determine the resource type is a constant
                        var resourceType = This.GetBranchResourceType(branch);
                        if (!resourceType.IsConstant)
                        {
                            escapeBranches.Add(branch);
                            continue;
                        }
                        using (_writer.Scope($"{keyword} ({This.BranchIdVariableName}.ResourceType == {GetResourceTypeExpression(resourceType)})"))
                        {
                            WriteLROMethodBranch(operation, clientOperation.ParameterMappings[branch], async);
                        }
                        keyword = "else if";
                    }
                    if (escapeBranches.Count == 0)
                    {
                        using (_writer.Scope($"else"))
                        {
                            _writer.Line($"throw new InvalidOperationException($\"{{{This.BranchIdVariableName}.ResourceType}} is not supported here\");");
                        }
                    }
                    else if (escapeBranches.Count == 1)
                    {
                        var branch = escapeBranches.First();
                        using (_writer.Scope($"else"))
                        {
                            WriteLROMethodBranch(clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], async);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"It is impossible to identify which branch to go here using Id for request paths: [{string.Join(", ", escapeBranches)}]");
                    }
                }
            }
        }

        protected virtual void WriteLROMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(GetDiagnosticName(operation), PipelineProperty, operation, parameterMapping, async);
        }

        protected virtual void WriteLROResponse(string diagnosticsVariableName, string pipelineVariableName, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var operation = new {LibraryArmOperation}");
            if (operation.ReturnType.IsGenericType)
            {
                _writer.Append($"<{operation.MgmtReturnType}>");
            }
            _writer.Append($"(");
            if (operation.IsFakeLongRunningOperation)
            {
                if (operation.MgmtReturnType is not null)
                {
                    _writer.Append($"{typeof(Response)}.FromValue(new {operation.MgmtReturnType}({ArmClientReference}, response), response.GetRawResponse())");
                }
                else
                {
                    _writer.Append($"response");
                }
            }
            else
            {
                if (operation.OperationSource is not null)
                {
                    _writer.Append($"new {operation.OperationSource.TypeName}(");
                    if (MgmtContext.Library.CsharpTypeToResource.ContainsKey(operation.MgmtReturnType!))
                        _writer.Append($"{ArmClientReference}");
                    _writer.Append($"), ");
                }

                _writer.Append($"{diagnosticsVariableName}, {pipelineVariableName}, {GetRestClientName(operation)}.{RequestWriterHelpers.CreateRequestMethodName(operation.Method.Name)}(");
                WriteArguments(_writer, parameterMapping);
                _writer.RemoveTrailingComma();
                _writer.Append($").Request, response, {typeof(OperationFinalStateVia)}.{operation.FinalStateVia!}");
            }
            _writer.Line($");");
            var waitForCompletionMethod = operation.MgmtReturnType is null ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
            _writer.Line($"if (waitUntil == {typeof(WaitUntil)}.Completed)");
            _writer.Line($"{GetAwait(async)} operation.{CreateMethodName(waitForCompletionMethod, async)}(cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return operation;");
        }
        #endregion

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping, bool passNullForOptionalParameters = false)
        {
            foreach (var parameter in mapping)
            {
                if (!parameter.IsPassThru && parameter.Parameter.Type.IsEnum)
                    writer.UseNamespace(parameter.Parameter.Type.Namespace);

                if (parameter.IsPassThru)
                {
                    if (PagingMethod.IsPageSizeName(parameter.Parameter.Name))
                    {
                        // alway use the `pageSizeHint` parameter from `AsPages(pageSizeHint)`
                        if (PagingMethod.IsPageSizeType(parameter.Parameter.Type.FrameworkType))
                        {
                            writer.AppendRaw($"pageSizeHint, ");
                        }
                        else
                        {
                            Console.Error.WriteLine($"WARNING: Parameter '{parameter.Parameter.Name}' is like a page size parameter, but it's not a numeric type. Fix it or overwrite it if necessary.");
                            writer.Append($"{parameter.Parameter.Name}, ");
                        }
                    }
                    else
                    {
                        if (passNullForOptionalParameters && !parameter.Parameter.Validate)
                            writer.Append($"null, ");
                        else
                            writer.Append($"{parameter.Parameter.Name}, ");
                    }
                }
                else
                {
                    foreach (var @namespace in parameter.Usings)
                    {
                        writer.UseNamespace(@namespace);
                    }
                    writer.Append($"{parameter.ValueExpression}, ");
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
