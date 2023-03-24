// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Output.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using static AutoRest.CSharp.Output.Models.MethodBodyLines;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected const string EndpointProperty = "Endpoint";
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

            WriteOperations();

            if (This.EnumerableInterfaces.Any())
                WriteEnumerables();
        }

        protected virtual void WritePrivateHelpers() { }
        protected virtual void WriteProperties() { }
        protected virtual void WriteStaticMethods() { }

        protected virtual void WriteOperations()
        {
            foreach (var clientOperation in This.AllOperations)
            {
                WriteMethod(clientOperation, true);
                WriteMethod(clientOperation, false);
            }
        }

        protected void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary(This.Description);
            _writer.AppendRaw(This.Accessibility)
                .AppendRawIf(" static", This.IsStatic)
                .Append($" partial class {This.Type.Name}");
            if (This.GetImplements().Any())
            {
                _writer.Append($" : ");
                foreach (var type in This.GetImplements())
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

        private string GetEnumerableArgValue()
        {
            string value = string.Empty;
            if (This is ResourceCollection collection)
            {
                if (collection.GetAllOperation?.IsPropertyBagOperation == true)
                {
                    value = "options: null";
                }
            }
            return value;
        }

        private void WriteIEnumerable(CSharpType type)
        {
            _writer.Line();
            var enumeratorType = new CSharpType(typeof(IEnumerator<>), type.Arguments);
            _writer.Line($"{enumeratorType:I} {type:I}.GetEnumerator()");
            string argValue = GetEnumerableArgValue();
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll({argValue}).GetEnumerator();");
            }
            _writer.Line();
            _writer.Line($"{typeof(IEnumerator)} {typeof(IEnumerable)}.GetEnumerator()");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAll({argValue}).GetEnumerator();");
            }
        }

        private void WriteIAsyncEnumerable(CSharpType type)
        {
            _writer.Line();
            var enumeratorType = new CSharpType(typeof(IAsyncEnumerator<>), type.Arguments);
            _writer.Line($"{enumeratorType:I} {type:I}.GetAsyncEnumerator({KnownParameters.CancellationTokenParameter.Type:I} {KnownParameters.CancellationTokenParameter.Name})");
            string argValue = GetEnumerableArgValue();
            using (_writer.Scope())
            {
                _writer.Line($"return GetAllAsync({(argValue == string.Empty ? string.Empty : argValue + ", ")}{KnownParameters.CancellationTokenParameter.Name}: {KnownParameters.CancellationTokenParameter.Name}).GetAsyncEnumerator({KnownParameters.CancellationTokenParameter.Name});");
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

        private void WriteRestClientConstructorPair(MgmtRestClient restClient, Resource? resource)
        {
            var resourceTypeExpression = ConstructResourceTypeExpression(resource);
            var ctorString = ConstructClientDiagnostic(_writer, $"{GetProviderNamespaceFromReturnType(resourceTypeExpression)}", DiagnosticsProperty);
            var diagFieldName = GetDiagnosticFieldName(restClient, resource);
            _writer.Line($"{diagFieldName} = {ctorString};");
            string apiVersionText = string.Empty;
            if (resourceTypeExpression is not null)
            {
                string apiVersionVariable = GetApiVersionVariableName(restClient, resource);
                _writer.Line($"TryGetApiVersion({resourceTypeExpression}, out string {apiVersionVariable});");
                apiVersionText = $", {apiVersionVariable}";
            }
            _writer.Line($"{GetRestFieldName(restClient, resource)} = {GetRestConstructorString(restClient, apiVersionText)};");
        }

        protected FormattableString? ConstructResourceTypeExpression(Resource? resource)
        {
            if (resource != null)
                return $"{resource.Type.Name}.ResourceType";
            return null;
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

        protected virtual void WriteSingletonResourceGetMethod(Resource resource)
        {
            var signature = new MethodSignature(
                $"Get{resource.ResourceName}",
                null,
                $"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.ResourceName}.",
                GetMethodModifiers(),
                resource.Type,
                $"Returns a <see cref=\"{resource.Type}\" /> object.",
                GetParametersForSingletonEntry());
            using (_writer.WriteCommonMethod(signature, null, false, This.Accessibility == "public"))
            {
                WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!, signature);
            }
        }

        protected virtual void WriteResourceCollectionGetMethod(Resource resource)
        {
            var resourceCollection = resource.ResourceCollection!;
            var signature = new MethodSignature(
                $"{GetResourceCollectionMethodName(resourceCollection)}",
                null,
                $"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {This.ResourceName}.",
                GetMethodModifiers(),
                resourceCollection.Type,
                $"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.",
                GetParametersForCollectionEntry(resourceCollection));
            using (_writer.WriteCommonMethod(signature, null, false, This.Accessibility == "public"))
            {
                WriteResourceCollectionEntry(resourceCollection, signature);
            }
        }

        protected virtual void WriteChildResourceGetMethod(ResourceCollection resourceCollection, bool isAsync)
        {
            var getOperation = resourceCollection.GetOperation;
            // Copy the original method signature with changes in name and modifier (e.g. when adding into extension class, the modifier should be static)
            var methodSignature = getOperation.MethodSignature with
            {
                // name after `Get{ResourceName}`
                Name = $"{getOperation.MethodSignature.Name}{resourceCollection.Resource.ResourceName}",
                Modifiers = GetMethodModifiers(),
                // There could be parameters to get resource collection
                Parameters = GetParametersForCollectionEntry(resourceCollection).Concat(GetParametersForResourceEntry(resourceCollection)).Distinct().ToArray(),
                Attributes = new[]{new CSharpAttribute(typeof(ForwardsClientCallsAttribute))}
            };

            _writer.Line();
            using (_writer.WriteCommonMethodWithoutValidation(methodSignature, getOperation.ReturnsDescription?.Invoke(isAsync), isAsync, This.Accessibility == "public"))
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
            return $"Get{resourceCollection.Resource.ResourceName.ResourceNameToPlural()}";
        }

        protected string GetResourceCollectionMethodArgumentList(ResourceCollection resourceCollection)
        {
            return string.Join(", ", GetParametersForCollectionEntry(resourceCollection).Select(p => p.Name));
        }

        protected virtual void WriteSingletonResourceEntry(Resource resource, SingletonResourceSuffix singletonResourceIdSuffix, MethodSignature signature)
        {
            // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
            // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
            _writer.UseNamespace(typeof(ResourceIdentifier).Namespace!);
            _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, {singletonResourceIdSuffix.BuildResourceIdentifier($"Id")});");
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
            if (resourceCollection.ExtraConstructorParameters.Any())
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
                _writer.WriteField(field);
            }
            _writer.Line();
        }

        protected FormattableString GetProviderNamespaceFromReturnType(FormattableString? resourceTypeExpression)
        {
            if (resourceTypeExpression is not null)
                return $"{resourceTypeExpression}.Namespace";

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
            return $"new {restClient.Type.Name}({PipelineProperty}, {DiagnosticsProperty}.ApplicationId{subIdVariable}, {EndpointProperty}{apiVersionVariable})";
        }

        protected string GetRestClientName(MgmtRestOperation operation) => GetRestClientName(operation.RestClient, operation.Resource);
        private string GetRestClientName(MgmtRestClient client, Resource? resource)
        {
            var names = This.GetRestDiagNames(new NameSetKey(client, resource));
            return UseField ? names.RestField : names.RestProperty;
        }

        protected Reference GetDiagnosticReference(MgmtRestOperation operation) => new Reference(GetDiagnosticName(operation.RestClient, operation.Resource), typeof(ClientDiagnostics));
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

        protected FormattableString GetResourceTypeExpression(ResourceTypeSegment resourceType)
        {
            if (resourceType == ResourceTypeSegment.ResourceGroup)
                return $"{typeof(ResourceGroupResource)}.ResourceType";
            if (resourceType == ResourceTypeSegment.Subscription)
                return $"{typeof(SubscriptionResource)}.ResourceType";
            if (resourceType == ResourceTypeSegment.Tenant)
                return $"{typeof(TenantResource)}.ResourceType";
            if (resourceType == ResourceTypeSegment.ManagementGroup)
                return $"{typeof(ManagementGroupResource)}.ResourceType";

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
                (true, true) => WritePagingLROMethodBody,
            };

        private void WritePagingLROMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");
        }

        protected IDisposable WriteCommonMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            _writer.Line();
            var returnDescription = clientOperation.ReturnsDescription?.Invoke(isAsync);
            return _writer.WriteCommonMethod(clientOperation.MethodSignature, returnDescription, isAsync, This.Accessibility == "public");
        }

        #region PagingMethod
        protected virtual void WritePagingMethodBody(MgmtClientOperation clientOperation, Diagnostic diagnostic, bool isAsync)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here
            // TODO -- find a better way to get this type
            var clientDiagField = GetDiagnosticReference(clientOperation.OperationMappings.First().Value);
            // we need to write multiple branches for a paging method
            if (clientOperation.OperationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = clientOperation.OperationMappings.Keys.First();
                WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagField, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], isAsync);
            }
            else
            {
                var keyword = "if";
                var escapeBranches = new List<RequestPath>();
                foreach (var (branch, operation) in clientOperation.OperationMappings)
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
                        WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagField, operation, clientOperation.ParameterMappings[branch], isAsync);
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
                        WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagField, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], isAsync);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"It is impossible to identify which branch to go here using Id for request paths: [{string.Join(", ", escapeBranches)}]");
                }
            }
        }

        protected void WritePagingMethodBranch(CSharpType itemType, Diagnostic diagnostic, Reference clientDiagnosticsReference, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var pagingMethod = operation.PagingMethod!;
            var firstPageRequestArguments = GetArguments(_writer, parameterMappings);
            var restClient = new FormattableStringToExpression($"{GetRestClientName(operation)}");

            _writer.WriteLine(Declare.FirstPageRequest(restClient, RequestWriterHelpers.CreateRequestMethodName(pagingMethod.Method), firstPageRequestArguments, out var firstPageRequest));
            CodeWriterDeclaration? nextPageRequest = null;
            if (pagingMethod.NextPageMethod is {} nextPageMethod)
            {
                var nextPageRequestArguments = firstPageRequestArguments.Prepend(KnownParameters.NextLink);
                _writer.WriteLine(Declare.NextPageRequest(restClient, RequestWriterHelpers.CreateRequestMethodName(nextPageMethod), nextPageRequestArguments, out nextPageRequest));
            }

            var clientDiagnostics = new FormattableStringToExpression($"{clientDiagnosticsReference.Name}");
            var pipeline = new FormattableStringToExpression($"Pipeline");
            var scopeName = diagnostic.ScopeName;
            var itemName = pagingMethod.ItemName;
            var nextLinkName = pagingMethod.NextLinkName;
            _writer.WriteLine(Return(Call.PageableHelpers.CreatePageable(firstPageRequest, nextPageRequest, clientDiagnostics, pipeline, itemType, scopeName, itemName, nextLinkName, KnownParameters.CancellationTokenParameter, async)));
        }

        protected ValueExpression CallCreateResourceIdentifier(Resource resource, RequestPath requestPath, IEnumerable<ParameterMapping> parameterMappings, CodeWriterDeclaration response)
        {
            var methodWithLeastParameters = resource.CreateResourceIdentifierMethodSignature;
            var cache = new List<ParameterMapping>(parameterMappings);

            var parameterInvocations = new List<ValueExpression>();
            foreach (var reference in requestPath.Where(s => s.IsReference).Select(s => s.Reference))
            {
                var match = cache.First(p => reference.Name.Equals(p.Parameter.Name, StringComparison.InvariantCultureIgnoreCase) && reference.Type.Equals(p.Parameter.Type));
                cache.Remove(match);
                parameterInvocations.Add(match.IsPassThru ? match.Parameter : match.ValueExpression);
            }

            if (parameterInvocations.Count < methodWithLeastParameters.Parameters.Count)
            {
                if (resource.ResourceData.GetTypeOfName() != null)
                {
                    parameterInvocations.Add(GetResponseValueName(response));
                }
                else
                {
                    throw new ErrorHelpers.ErrorException($"The resource data {resource.ResourceData.Type.Name} does not have a `Name` property, which is required when assigning non-resource as resources");
                }
            }

            return new StaticMethodCallExpression(resource.Type, "CreateResourceIdentifier", parameterInvocations);
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
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(operation)))
            {
                var response = new CodeWriterDeclaration("response");
                _writer
                    .Append($"var {response:D} = {GetAwait(async)} ")
                    .Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
                WriteArguments(_writer, parameterMappings);
                _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

                if (operation.ThrowIfNull)
                {
                    _writer
                        .Line($"if ({response}.Value == null)")
                        .Line($"throw new {typeof(RequestFailedException)}({response}.GetRawResponse());");
                }
                var realReturnType = operation.MgmtReturnType;
                if (realReturnType != null && realReturnType.TryCastResource(out var resource) && resource.ResourceData.ShouldSetResourceIdentifier)
                {
                    _writer.WriteLine(Assign.ResponseValueId(response, CallCreateResourceIdentifier(resource, operation.RequestPath, parameterMappings, response)));
                }

                // the case that we did not need to wrap the result
                var valueConverter = operation.GetValueConverter($"{ArmClientReference}", $"{response}.Value");
                if (valueConverter != null)
                {
                    _writer.Line($"return {typeof(Response)}.FromValue({valueConverter}, {response}.GetRawResponse());");
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
            using (_writer.WriteDiagnosticScope(diagnostic, GetDiagnosticReference(clientOperation.OperationMappings.Values.First())))
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

            WriteLROResponse(GetDiagnosticReference(operation).Name, PipelineProperty, operation, parameterMapping, async);
        }

        protected virtual void WriteLROResponse(string diagnosticsVariableName, string pipelineVariableName, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool isAsync)
        {
            if (operation.InterimOperation is not null)
            {
                _writer.Append($"var operation = new {operation.InterimOperation.TypeName}");
            }
            else
            {
                _writer.Append($"var operation = new {LibraryArmOperation}");
                if (operation.ReturnType.IsGenericType)
                {
                    _writer.Append($"<{operation.MgmtReturnType}>");
                }
            }
            _writer.Append($"(");
            if (operation.IsFakeLongRunningOperation)
            {
                var valueConverter = operation.GetValueConverter($"{ArmClientReference}", $"response");
                if (valueConverter != null)
                {
                    _writer.Append($"{typeof(Response)}.FromValue({valueConverter}, response.GetRawResponse())");
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
                    _writer.Append($"new {operation.OperationSource.TypeName}(")
                        .AppendIf($"{ArmClientReference}", operation.MgmtReturnType!.TryCastResource(out _))
                        .Append($"), ");
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
            _writer.Line($"{GetAwait(isAsync)} operation.{CreateMethodName(waitForCompletionMethod, isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
            _writer.Line($"return operation;");
        }
        #endregion

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping, bool passNullForOptionalParameters = false)
        {
            var arguments = GetArguments(writer, mapping, passNullForOptionalParameters);
            if (arguments.Any())
            {
                foreach (var argument in arguments)
                {
                    writer.WriteValueExpression(argument);
                    writer.AppendRaw(", ");
                }
            }
        }

        private static List<ValueExpression> GetArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping, bool passNullForOptionalParameters = false)
        {
            var args = new List<ValueExpression>();
            foreach (var parameter in mapping)
            {
                if (parameter.IsPassThru)
                {
                    if (PagingMethod.IsPageSizeName(parameter.Parameter.Name))
                    {
                        // always use the `pageSizeHint` parameter from `AsPages(pageSizeHint)`
                        if (PagingMethod.IsPageSizeType(parameter.Parameter.Type.FrameworkType))
                        {
                            args.Add(new FormattableStringToExpression($"pageSizeHint"));
                        }
                        else
                        {
                            Console.Error.WriteLine($"WARNING: Parameter '{parameter.Parameter.Name}' is like a page size parameter, but it's not a numeric type. Fix it or overwrite it if necessary.");
                            if (parameter.Parameter.IsPropertyBag)
                                args.Add(parameter.ValueExpression);
                            else
                                args.Add(parameter.Parameter);
                        }
                    }
                    else
                    {
                        if (passNullForOptionalParameters && parameter.Parameter.Validation == Validation.None)
                            args.Add(ValueExpressions.Null);
                        else if (parameter.Parameter.IsPropertyBag)
                            args.Add(parameter.ValueExpression);
                        else
                            args.Add(parameter.Parameter);
                    }
                }
                else
                {
                    if (parameter.Parameter.Type.IsEnum)
                    {
                        writer.UseNamespace(parameter.Parameter.Type.Namespace);
                    }

                    foreach (var @namespace in parameter.Usings)
                    {
                        writer.UseNamespace(@namespace);
                    }

                    args.Add(parameter.ValueExpression);
                }
            }

            return args;
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
