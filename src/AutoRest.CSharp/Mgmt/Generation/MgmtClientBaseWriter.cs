// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
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
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Operation = AutoRest.CSharp.Input.Operation;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected const string BaseUriProperty = "BaseUri";

        protected bool IsArmCore;
        protected CodeWriter _writer;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected BuildContext<MgmtOutputLibrary> Context { get; }
        protected MgmtConfiguration Config => Context.Configuration.MgmtConfiguration;
        protected bool ShowRequestPathAndOperationId => Config.MgmtDebug.ShowRequestPath;

        internal static readonly Parameter CancellationTokenParameter = new Parameter(
            "cancellationToken",
            "The cancellation token to use.",
            typeof(CancellationToken),
            Constant.NewInstanceOf(typeof(CancellationToken)),
            false);

        internal static readonly Parameter WaitForCompletionParameter = new Parameter(
            "waitForCompletion",
            "Waits for the completion of the long running operations.",
            typeof(bool),
            null,
            false);

        private MgmtTypeProvider This { get; }

        protected virtual string BranchIdVariableName => "Id";

        protected virtual string ArmClientReference { get; } = "ArmClient";

        protected virtual bool UseField => true;

        public string FileName { get; }

        protected MgmtClientBaseWriter(CodeWriter writer, MgmtTypeProvider provider, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            Context = context;
            This = provider;
            FileName = This.Type.Name;
            IsArmCore = context.Configuration.MgmtConfiguration.IsArmCore;
        }

        public virtual void Write()
        {
            using (_writer.Namespace(This.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    WriteStaticMethods();

                    WriteFields(_writer);

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

                    WriteCustomMethods();

                    if (This.EnumerableInterfaces.Any())
                        WriteEnumerables();
                }
            }
        }
        protected virtual void WritePrivateHelpers() { }
        protected virtual void WriteProperties() { }
        protected virtual void WriteStaticMethods() { }
        protected virtual void WriteCustomMethods() { }

        protected void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary($"{This.Description}");
            _writer.Append($"{This.Accessibility}");
            if (This.IsStatic)
                _writer.Append($" static");
            _writer.Append($" partial class {This.Type.Name:D}");
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

            _writer.WriteMethodDocumentation(This.MockingCtor);
            using (_writer.WriteMethodDeclaration(This.MockingCtor))
            {
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
                    //if (_resourceCollection.ResourceTypes.SelectMany(p => p.Value).Distinct() == 1)
                    WriteDebugValidate(_writer);
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
            _writer.Line($"{enumeratorType:I} {type:I}.GetAsyncEnumerator({CancellationTokenParameter.Type:I} {CancellationTokenParameter.Name})");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAllAsync({CancellationTokenParameter.Name}: {CancellationTokenParameter.Name}).GetAsyncEnumerator({CancellationTokenParameter.Name});");
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
                _writer.Line($"{ArmClientReference}.TryGetApiVersion({resourceName}.ResourceType, out string {apiVersionVariable});");
                apiVersionText = $", {apiVersionVariable}";
            }
            _writer.Line($"{GetRestFieldName(restClient, resource)} = {GetRestConstructorString(restClient, diagFieldName, apiVersionText)};");
        }

        protected virtual void WriteChildResourceEntries()
        {
            foreach (var resource in This.ChildResources)
            {
                _writer.Line();
                if (resource.IsSingleton)
                {
                    WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!);
                }
                else if (resource.ResourceCollection is not null)
                {
                    WriteResourceCollectionEntry(resource.ResourceCollection);
                }
            }
            _writer.Line();
        }

        protected virtual void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type}\" /> object.");
            using (_writer.Scope($"public virtual {resource.Type.Name} Get{resource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, new {typeof(Azure.Core.ResourceIdentifier)}(Id.ToString() + \"/{singletonResourceIdSuffix}\"));");
            }
        }

        protected virtual void WriteResourceCollectionEntry(ResourceCollection resourceCollection)
        {
            var resource = resourceCollection.Resource;
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {resource.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.");
            _writer.WriteXmlDocumentationParameters(resourceCollection.ExtraConstructorParameters);
            var extraConstructorParameters = resourceCollection.ExtraConstructorParameters;
            _writer.Append($"public virtual {resourceCollection.Type} Get{resource.Type.Name.ResourceNameToPlural()}(");
            foreach (var parameter in resourceCollection.ExtraConstructorParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Line($")");
            using (_writer.Scope())
            {
                _writer.Append($"return new {resourceCollection.Type.Name}({ArmClientReference}, Id, ");
                foreach (var parameter in resourceCollection.ExtraConstructorParameters)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
        }

        protected void WriteStaticValidate(FormattableString validResourceType, CodeWriter writer)
        {
            using (writer.Scope($"internal static void ValidateResourceId({typeof(Azure.Core.ResourceIdentifier)} id)"))
            {
                writer.Line($"if (id.ResourceType != {validResourceType})");
                writer.Line($"throw new {typeof(ArgumentException)}(string.Format({typeof(CultureInfo)}.CurrentCulture, \"Invalid resource type {{0}} expected {{1}}\", id.ResourceType, {validResourceType}), nameof(id));");
            }
        }

        protected void WriteDebugValidate(CodeWriter writer)
        {
            writer.Line($"#if DEBUG");
            writer.Line($"\t\t\tValidateResourceId(Id);");
            writer.Line($"#endif");
        }

        protected void WriteFields(CodeWriter writer)
        {
            foreach (var field in This.Fields)
            {
                writer.WriteFieldDeclaration(field);
            }
            writer.Line();
        }

        protected FormattableString GetProviderNamespaceFromReturnType(string? returnType)
        {
            if (returnType is null)
                return $"ProviderConstants.DefaultProviderNamespace";

            var resource = Context.Library.ArmResources.FirstOrDefault(resource => resource.Declaration.Name == returnType);
            if (resource is not null)
                return $"{returnType}.ResourceType.Namespace";

            if (Context.Library.TryGetTypeProvider(returnType, out var p) && p is ResourceData data)
                return $"{returnType.Substring(0, returnType.Length - 4)}.ResourceType.Namespace";

            return $"ProviderConstants.DefaultProviderNamespace";
        }

        protected FormattableString ConstructClientDiagnostic(CodeWriter writer, FormattableString providerNamespace, string diagnosticsOptionsVariable)
        {
            return $"new {typeof(ClientDiagnostics)}(\"{This.Type.Namespace}\", {providerNamespace}, {diagnosticsOptionsVariable})";
        }

        protected string GetRestConstructorString(
            MgmtRestClient restClient,
            string clientDiagVariable,
            string apiVersionVariable)
        {
            string subIdVariable = ", Id.SubscriptionId";
            if (!restClient.Parameters.Any(p => p.Name.Equals("subscriptionId")))
                subIdVariable = string.Empty;
            return $"new {restClient.Type.Name}({clientDiagVariable}, {PipelineProperty}, {DiagnosticOptionsProperty}.ApplicationId{subIdVariable}, {BaseUriProperty}{apiVersionVariable})";
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
            var candidates = Context.Library.ArmResources.Where(resource => resource.ResourceType == resourceType);
            if (candidates.Count() == 1)
            {
                return $"{candidates.First().Type}.ResourceType";
            }
            return $"\"{resourceType.SerializedType}\"";
        }

        protected virtual void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
            => WriteCommomMethod(clientOperation, isAsync, GetMethodDelegate(clientOperation));

        protected Dictionary<string, Action<MgmtClientOperation, Diagnostic, bool>> _customMethods = new Dictionary<string, Action<MgmtClientOperation, Diagnostic, bool>>();
        private Action<MgmtClientOperation, Diagnostic, bool> GetMethodDelegate(MgmtClientOperation clientOperation)
        {
            if (!_customMethods.TryGetValue($"Write{clientOperation.Name}Body", out var function))
            {
                function = GetMethodDelegate(clientOperation.IsLongRunningOperation, clientOperation.IsPagingOperation);
                if (function is null)
                    throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");
            }

            return function;
        }

        private Action<MgmtClientOperation, Diagnostic, bool>? GetMethodDelegate(bool isLongRunning, bool isPaging)
            => (isLongRunning, isPaging) switch
        {
            (true, true) => null,
            (true, false) => WriteLROMethodBody,
            (false, true) => WritePagingMethodBody,
            (false, false) => WriteNormalMethodBody
        };

        protected void WriteCommomMethod(MgmtClientOperation clientOperation, bool isAsync, Action<MgmtClientOperation, Diagnostic, bool> methodDelegate)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            _writer.WriteXmlDocumentationParameters(clientOperation.MethodParameters);
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(clientOperation.MethodParameters);

            if (clientOperation.ReturnsDescription is not null)
                _writer.WriteXmlDocumentationReturns(clientOperation.ReturnsDescription(isAsync));

            using (_writer.WriteMethodDeclaration(clientOperation.MethodSignature, isAsync))
            {
                _writer.WriteParameterNullOrEmptyChecks(clientOperation.MethodParameters);

                var diagnostic = new Diagnostic($"{This.Type.Name}.{clientOperation.Name}", Array.Empty<DiagnosticAttribute>());
                methodDelegate(clientOperation, diagnostic, isAsync);
            }
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
                    using (_writer.Scope($"{keyword} ({BranchIdVariableName}.ResourceType == {GetResourceTypeExpression(resourceType)})"))
                    {
                        WritePagingMethodBranch(clientOperation.ReturnType, diagnostic, clientDiagFieldName, operation, clientOperation.ParameterMappings[branch], isAsync);
                    }
                    keyword = "else if";
                }
                if (escapeBranches.Count == 0)
                {
                    using (_writer.Scope($"else"))
                    {
                        _writer.Line($"throw new InvalidOperationException($\"{{{BranchIdVariableName}.ResourceType}} is not supported here\");");
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

            // only when we are listing ourselves, we use Select to convert XXXResourceData to XXXResource
            Resource? resource = operation.Resource is not null && operation.Resource.Type.Equals(itemType)
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
            var methodWithLeastParameters = resource.CreateResourceIdentifierMethodSignature().Values.OrderBy(method => method.Parameters.Length).First();
            var cache = new List<ParameterMapping>(parameterMappings);

            var parameterInvocations = new List<FormattableString>();
            foreach (var reference in requestPath.Where(s => s.IsReference).Select(s => s.Reference))
            {
                var match = cache.First(p => reference.Name.Equals(p.Parameter.Name, StringComparison.InvariantCultureIgnoreCase) && reference.Type.Equals(p.Parameter.Type));
                cache.Remove(match);
                parameterInvocations.Add(match.IsPassThru ? $"{match.Parameter.Name}" : match.ValueExpression);
            }

            if (parameterInvocations.Count < methodWithLeastParameters.Parameters.Length)
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

                if (operation.Resource != null && operation.Resource.Type.Equals(operation.ReturnType.UnWrapResponse()))
                {
                    if (operation.ThrowIfNull)
                    {
                        _writer.Line($"if ({response}.Value == null)");
                        _writer.Line($"throw {GetAwait(async)} {GetDiagnosticName(operation)}.{CreateMethodName("CreateRequestFailedException", async)}({response}.GetRawResponse()){GetConfigureAwait(async)};");
                    }

                    if (operation.Resource.ResourceData.ShouldSetResourceIdentifier)
                    {
                        _writer.Line($"{response}.Value.Id = {CreateResourceIdentifierExpression(operation.Resource, operation.RequestPath, parameterMappings, $"{response}.Value")};");
                    }

                    _writer.Line($"return {typeof(Response)}.FromValue(new {operation.Resource.Type}({ArmClientReference}, {response}.Value), {response}.GetRawResponse());");
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
                    WriteLROMethodBranch(clientOperation.ReturnType, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], async);
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
                        using (_writer.Scope($"{keyword} ({BranchIdVariableName}.ResourceType == {GetResourceTypeExpression(resourceType)})"))
                        {
                            WriteLROMethodBranch(clientOperation.ReturnType, operation, clientOperation.ParameterMappings[branch], async);
                        }
                        keyword = "else if";
                    }
                    if (escapeBranches.Count == 0)
                    {
                        using (_writer.Scope($"else"))
                        {
                            _writer.Line($"throw new InvalidOperationException($\"{{{BranchIdVariableName}.ResourceType}} is not supported here\");");
                        }
                    }
                    else if (escapeBranches.Count == 1)
                    {
                        var branch = escapeBranches.First();
                        using (_writer.Scope($"else"))
                        {
                            WriteLROMethodBranch(clientOperation.ReturnType, clientOperation.OperationMappings[branch], clientOperation.ParameterMappings[branch], async);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"It is impossible to identify which branch to go here using Id for request paths: [{string.Join(", ", escapeBranches)}]");
                    }
                }
            }
        }

        protected virtual void WriteLROMethodBranch(CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, GetDiagnosticName(operation), PipelineProperty, operation, parameterMapping, async);
        }

        protected virtual void WriteLROResponse(CSharpType lroObjectType, string diagnosticsVariableName, string pipelineVariableName, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var operation = new {lroObjectType}(");

            if (operation.Operation.IsLongRunning)
            {
                var longRunningOperation = Context.Library.GetLongRunningOperation(lroObjectType);
                if (longRunningOperation.WrapperResource != null)
                {
                    _writer.Append($"{ArmClientReference}, ");
                }
                _writer.Append($"{diagnosticsVariableName}, {pipelineVariableName}, {GetRestClientName(operation)}.{RequestWriterHelpers.CreateRequestMethodName(operation.Method.Name)}(");
                WriteArguments(_writer, parameterMapping);
                _writer.RemoveTrailingComma();
                _writer.Append($").Request, ");
            }
            else
            {
                var nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(lroObjectType);
                // need to check implementation type as some delete operation uses ResourceData.
                if (nonLongRunningOperation.ResultType != null && nonLongRunningOperation.ResultType.Implementation.GetType() == typeof(Resource))
                {
                    _writer.Append($"{ArmClientReference}, ");
                }
            }
            _writer.Line($"response);");
            CSharpType? lroResultType = GetLROResultType(lroObjectType, operation.Operation);
            var waitForCompletionMethod = lroResultType == null ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
            _writer.Line($"if (waitForCompletion)");
            _writer.Line($"{GetAwait(async)} operation.{CreateMethodName(waitForCompletionMethod, async)}(cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return operation;");
        }
        #endregion

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping, bool passNullForOptionalParameters = false)
        {
            foreach (var parameter in mapping)
            {
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
                        if (passNullForOptionalParameters && !parameter.Parameter.ValidateNotNull)
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

        protected CSharpType? GetLROResultType(CSharpType lroObjectType, Operation operation)
        {
            CSharpType? returnType = null;
            if (operation.IsLongRunning)
            {
                var longRunningOperation = Context.Library.GetLongRunningOperation(lroObjectType);
                returnType = longRunningOperation.WrapperResource?.Type ?? longRunningOperation.ResultType;
            }
            else
            {
                var nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(lroObjectType);
                returnType = nonLongRunningOperation.ResultType;
            }

            return returnType;
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
