// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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

        protected static readonly Parameter CancellationTokenParameter = new Parameter(
            "cancellationToken",
            "The cancellation token to use.",
            typeof(CancellationToken),
            Constant.NewInstanceOf(typeof(CancellationToken)),
            false);

        protected static readonly Parameter WaitForCompletionParameter = new Parameter(
            "waitForCompletion",
            "Waits for the completion of the long running operations.",
            typeof(bool),
            null,
            false);

        private MgmtTypeProvider This { get; }

        protected virtual string IdVariableName => "Id";

        protected virtual string BranchIdVariableName => "Id";

        protected virtual string ArmClientReference => ContextProperty.IsNullOrEmpty() ? "ArmClient" : "armClient";

        protected virtual bool UseRestClientField => true;

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

                    WriteListAvailableLocations();

                    WriteTaggingMethods();
                }
            }
        }
        protected virtual void WritePrivateHelpers() { }
        protected virtual void WriteProperties() { }
        protected virtual void WriteStaticMethods() { }
        protected virtual void WriteListAvailableLocations() { }
        protected virtual void WriteTaggingMethods() { }

        protected void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary($"{This.Description}");
            _writer.Append($"{This.Accessibility}");
            if (This.IsStatic)
                _writer.Append($" static");
            _writer.Append($" partial class {This.Type.Name:D}");
            if (This.BaseType is not null)
                _writer.Append($" : {This.BaseType:D}");
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

        protected void WriteRestClientConstructorPair(MgmtRestClient restClient, Resource? resource)
        {
            string? resourceName = resource?.Type.Name;
            FormattableString ctorString = ConstructClientDiagnostic(_writer, $"{GetProviderNamespaceFromReturnType(resourceName)}", DiagnosticOptionsProperty);
            string diagFieldName = GetClientDiagnosticFieldName(restClient, resource);
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

        protected virtual void WriteChildResourceEntries(bool singletonOnly = false)
        {
            foreach (var resource in This.ChildResources)
            {
                _writer.Line();
                if (resource.IsSingleton)
                {
                    _writer.Line($"#region {resource.Type.Name}");
                    WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!);
                    _writer.Line($"#endregion");
                }
                else
                {
                    if (!singletonOnly)
                    {
                        _writer.Line($"#region {resource.Type.Name}");
                        WriteResourceCollectionEntry(resource);
                        _writer.Line($"#endregion");
                    }
                }
            }
            _writer.Line();
        }

        protected void WriteMockingCtor()
        {
            _writer.Line();
            // write protected default constructor
            var mockingConstructor = new ConstructorSignature(
                Name: This.Type.Name,
                Description: $"Initializes a new instance of the <see cref=\"{This.Type.Name}\"/> class for mocking.",
                Modifiers: "protected",
                Parameters: new Parameter[0]);
            _writer.WriteMethodDocumentation(mockingConstructor);
            using (_writer.WriteMethodDeclaration(mockingConstructor))
            { }
        }

        protected virtual void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {This.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type}\" /> object.");
            using (_writer.Scope($"public {GetVirtual(true)} {resource.Type.Name} Get{resource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {resource.Type.Name}({ArmClientReference}, new {typeof(Azure.Core.ResourceIdentifier)}(Id.ToString() + \"/{singletonResourceIdSuffix}\"));");
            }
        }

        protected virtual void WriteResourceCollectionEntry(Resource resource)
        {
            var collection = resource.ResourceCollection;
            if (collection == null)
                throw new InvalidOperationException($"We are about to write a {resource.Type.Name} resource entry in {resource.Type.Name} resource, but it does not have a collection, this cannot happen");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {resource.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {resource.Type.Name}.");
            _writer.WriteXmlDocumentationParameters(collection.ExtraConstructorParameters);
            var extraConstructorParameters = collection.ExtraConstructorParameters;
            _writer.Append($"public {GetVirtual(true)} {collection.Type} Get{resource.Type.Name.ResourceNameToPlural()}(");
            foreach (var parameter in collection.ExtraConstructorParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Line($")");
            using (_writer.Scope())
            {
                _writer.Append($"return new {collection.Type.Name}(this, ");
                foreach (var parameter in collection.ExtraConstructorParameters)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
        }

        protected virtual void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace(typeof(Task).Namespace!);
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

        private void WriteFields(CodeWriter writer, MgmtRestClient client, Resource? resource, bool useReadOnly)
        {
            string readOnly = useReadOnly ? " readonly" : string.Empty;
            writer.Line($"private{readOnly} {typeof(ClientDiagnostics)} {GetClientDiagnosticFieldName(client, resource)};");
            writer.Line($"{RestClientAccessibility}{readOnly} {client.Type} {GetRestFieldName(client, resource)};");
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

        protected string GetRestFieldOrPropertyName(MgmtRestOperation operation) => GetRestFieldOrPropertyName(operation.RestClient, operation.Resource);
        protected string GetRestFieldOrPropertyName(MgmtRestClient client, Resource? resource)
        {
            var names = GetRestDiagNames(client, resource);
            return UseRestClientField ? names.RestField : names.RestProperty;
        }

        protected string GetRestPropertyName(MgmtRestOperation operation) => GetRestDiagNames(operation.RestClient, operation.Resource).RestProperty;
        protected string GetRestPropertyName(MgmtRestClient client, Resource? resource) => GetRestDiagNames(client, resource).RestProperty;
        protected string GetRestFieldName(MgmtRestOperation operation) => GetRestDiagNames(operation.RestClient, operation.Resource).RestField;
        protected string GetRestFieldName(MgmtRestClient client, Resource? resource) => GetRestDiagNames(client, resource).RestField;
        protected string GetClientDiagnosticsPropertyName(MgmtRestOperation operation) => GetRestDiagNames(operation.RestClient, operation.Resource).DiagnosticProperty;
        protected string GetClientDiagnosticsPropertyName(MgmtRestClient client, Resource? resource) => GetRestDiagNames(client, resource).DiagnosticProperty;
        protected string GetClientDiagnosticFieldName(MgmtRestOperation operation) => GetRestDiagNames(operation.RestClient, operation.Resource).DiagnosticField;
        protected string GetClientDiagnosticFieldName(MgmtRestClient client, Resource? resource) => GetRestDiagNames(client, resource).DiagnosticField;
        protected virtual string GetApiVersionVariableName(MgmtRestClient client, Resource? resource) => GetRestDiagNames(client, resource).ApiVersionVariable;

        private NameSet GetRestDiagNames(MgmtRestClient client, Resource? resource) => This.GetRestDiagNames(new NameSetKey(client, resource));

        protected internal static CSharpType GetResponseType(CSharpType? returnType, bool async)
        {
            if (returnType == null)
                return typeof(Response).WrapAsync(async);

            return returnType.WrapResponse(async);
        }

        protected internal static string GetConfigureAwait(bool isAsync)
        {
            return isAsync ? ".ConfigureAwait(false)" : string.Empty;
        }

        protected internal static string GetVirtual(bool isVirtual)
        {
            return isVirtual ? "virtual" : string.Empty;
        }

        protected internal static string GetAsyncKeyword(bool isAsync)
        {
            return isAsync ? "async" : string.Empty;
        }

        protected internal static string GetAsyncSuffix(bool isAsync)
        {
            return isAsync ? "Async" : string.Empty;
        }

        protected internal static string GetAwait(bool isAsync)
        {
            return isAsync ? "await " : string.Empty;
        }

        protected internal static string GetNextLink(bool isNextPageFunc)
        {
            return isNextPageFunc ? "nextLink, " : string.Empty;
        }

        protected internal static string GetOverride(bool isInheritedMethod, bool isVirtual = false)
        {
            return isInheritedMethod ? "override" : GetVirtual(isVirtual);
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
        {
            // we need to identify this operation belongs to which category: NormalMethod, NormalListMethod, LROMethod or PagingMethod
            if (clientOperation.IsLongRunningOperation && !clientOperation.IsPagingOperation)
            {
                // this is a non-pageable long-running operation
                WriteLROMethod(clientOperation, isAsync);
            }
            else if (clientOperation.IsLongRunningOperation && clientOperation.IsPagingOperation)
            {
                // this is a pageable long-running operation
                throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");
            }
            else if (clientOperation.IsPagingOperation)
            {
                // this is a paging operation
                WritePagingMethod(clientOperation, clientOperation.ReturnType!, isAsync);
            }
            else if (clientOperation.IsListOperation)
            {
                // this is a normal list operation
                WritePagingMethod(clientOperation, clientOperation.ReturnType!, isAsync);
            }
            else
            {
                // this is a normal operation
                WriteNormalMethod(clientOperation, isAsync);
            }
        }

        #region PagingMethod
        protected void WritePagingMethod(MgmtClientOperation clientOperation, CSharpType itemType, bool async)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);

            WritePagingMethod(clientOperation, itemType, operationMappings, parameterMappings, methodParameters, clientOperation.Name, async);
        }

        protected virtual void WritePagingMethod(MgmtClientOperation clientOperation, CSharpType itemType, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here
            // TODO -- find a better way to get this type
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WritePagingMethodSignature(itemType, methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                var diagnostic = new Diagnostic($"{This.Type.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WritePagingMethodBody(itemType, diagnostic, operationMappings, parameterMappings, async, clientOperation);
            }
        }

        protected virtual void WritePagingMethodBody(CSharpType itemType, Diagnostic diagnostic, IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async, MgmtClientOperation clientOperation)
        {
            // we need to write multiple branches for a paging method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WritePagingMethodBranch(itemType, diagnostic, GetClientDiagnosticFieldName(operationMappings[branch]), operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                var keyword = "if";
                var escapeBranches = new List<RequestPath>();
                foreach ((var branch, var operation) in operationMappings)
                {
                    // we need to identify the correct branch using the resource type, therefore we need first to determine the resource type is a constant
                    var resourceType = GetBranchResourceType(branch);
                    if (!resourceType.IsConstant)
                    {
                        escapeBranches.Add(branch);
                        continue;
                    }
                    using (_writer.Scope($"{keyword} ({BranchIdVariableName}.ResourceType == {GetResourceTypeExpression(resourceType)})"))
                    {
                        WritePagingMethodBranch(itemType, diagnostic, GetClientDiagnosticFieldName(clientOperation.RestClient, clientOperation.Resource), operation, parameterMappings[branch], async);
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
                        WritePagingMethodBranch(itemType, diagnostic, GetClientDiagnosticFieldName(operationMappings[branch]), operationMappings[branch], parameterMappings[branch], async);
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
            var pagingMethod = GetPagingMethod(operation);
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

        protected PagingMethodWrapper GetPagingMethod(MgmtRestOperation operation)
        {
            var pagingMethod = operation.GetPagingMethod();
            if (pagingMethod == null)
                return new PagingMethodWrapper(operation.Method);

            return new PagingMethodWrapper(pagingMethod);
        }

        protected void WritePageFunctionBody(CSharpType itemType, PagingMethodWrapper pagingMethod, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool isAsync, bool isNextPageFunc)
        {
            var continuationTokenText = pagingMethod.NextLinkName != null ? $"response.Value.{pagingMethod.NextLinkName}" : "null";
            var response = new CodeWriterDeclaration("response");

            _writer.Append($"var {response:D} = {GetAwait(isAsync)} {GetRestFieldOrPropertyName(operation)}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, isAsync)}({GetNextLink(isNextPageFunc)}");
            WriteArguments(_writer, parameterMappings);
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            _writer
                .Append($"return {typeof(Page)}.FromValues(response.Value")
                .AppendIf($".{pagingMethod.ItemName}", !pagingMethod.ItemName.IsNullOrEmpty());

            // only when we are listing ourselves, we use Select to convert XXXResourceData to XXXResource
            if (operation.Resource?.Type == itemType)
            {
                _writer.UseNamespace(typeof(Enumerable).Namespace!);

                var value = new CodeWriterDeclaration("value");
                _writer.Append($@".Select({value:D} => ");
                if (operation.Resource.ResourceData.ShouldSetResourceIdentifier)
                {
                    using (_writer.Scope())
                    {
                        _writer
                            .Line($"{value}.Id = {CreateResourceIdentifierExpression(operation.Resource, operation.RequestPath, parameterMappings, $"{value}")};")
                            .Line($"return new {operation.Resource.Type}({ArmClientReference}, {value});");
                    }
                }
                else
                {
                    _writer.Append($"new {operation.Resource.Type}({ArmClientReference}, {value})");
                }
                _writer.AppendRaw(")");
            }

            _writer.Line($", {continuationTokenText}, {response}.GetRawResponse());");
        }

        protected virtual void WritePagingMethodSignature(CSharpType actualItemType, string methodName, IReadOnlyList<Parameter> methodParameters, bool async,
            string accessibility = "public", bool isVirtual = true)
        {
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            _writer.WriteXmlDocumentationReturns($"{(async ? "An async" : "A")} collection of <see cref=\"{actualItemType.Name}\" /> that may take multiple service requests to iterate over.");

            var responseType = actualItemType.WrapPageable(async);
            _writer.Append($"{accessibility} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, async)}(");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
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

        protected class PagingMethodWrapper
        {
            public PagingMethodWrapper(PagingMethod pagingMethod)
            {
                Method = pagingMethod.Method;
                NextPageMethod = pagingMethod.NextPageMethod;
                NextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
                ItemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            }

            public PagingMethodWrapper(RestClientMethod method)
            {
                Method = method;
                NextPageMethod = null;
                NextLinkName = null;
                var valueProperty = "Value";
                if (method.ReturnType!.IsFrameworkType && method.ReturnType.FrameworkType == typeof(IReadOnlyList<>))
                    valueProperty = string.Empty;
                ItemName = valueProperty;
            }

            /// <summary>
            /// This is the underlying <see cref="RestClientMethod"/> of this paging method
            /// </summary>
            public RestClientMethod Method { get; }

            /// <summary>
            /// This is the REST method for getting next page if there is one
            /// </summary>
            public RestClientMethod? NextPageMethod { get; }

            /// <summary>
            /// This is the property name in the response body, usually the value of this is `Value`
            /// </summary>
            public string ItemName { get; }

            /// <summary>
            /// This is the name of the nextLink property if there is one.
            /// </summary>
            public string? NextLinkName { get; }
        }
        #endregion

        #region NormalMethod
        protected virtual void WriteNormalMethodSignature(CSharpType responseType, string methodName, IReadOnlyList<Parameter> methodParameters, bool async,
            string accessibility = "public", bool isVirtual = true)
        {
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            _writer.Append($"{accessibility} {GetAsyncKeyword(async)} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, async)}(");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        protected void WriteNormalMethod(MgmtClientOperation clientOperation, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);

            WriteNormalMethod(clientOperation, operationMappings, parameterMappings, methodParameters, clientOperation.Name, async, shouldThrowExceptionWhenNull);
        }

        protected virtual void WriteNormalMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteNormalMethodSignature(GetResponseType(clientOperation.ReturnType, async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);
                var diagnostic = new Diagnostic($"{This.Type.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, GetClientDiagnosticFieldName(operationMappings.Values.First())))
                {
                    WriteNormalMethodBody(operationMappings, parameterMappings, async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull);
                }
                _writer.Line();
            }
        }

        protected virtual void WriteNormalMethodBody(IDictionary<RequestPath, MgmtRestOperation> operationMappings, IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings,
            bool async, bool shouldThrowExceptionWhenNull = false)
        {
            // we need to write multiple branches for a normal method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteNormalMethodBranch(operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        protected virtual void WriteNormalMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var response = new CodeWriterDeclaration("response");
            _writer
                .Append($"var {response:D} = {GetAwait(async)} ")
                .Append($"{GetRestFieldOrPropertyName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMappings);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            if (operation.Resource != null)
            {
                if (operation.ThrowIfNull)
                {
                    _writer.Line($"if ({response}.Value == null)");
                    _writer.Line($"throw {GetAwait(async)} {GetClientDiagnosticFieldName(operation)}.{CreateMethodName("CreateRequestFailedException", async)}({response}.GetRawResponse()){GetConfigureAwait(async)};");
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
        #endregion

        #region LROMethod
        protected void WriteLROMethod(MgmtClientOperation clientOperation, bool async)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);

            WriteLROMethod(clientOperation, operationMappings, parameterMappings, methodParameters, clientOperation.Name, async);
        }

        protected virtual void WriteLROMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = clientOperation.ReturnType!; // the LRO operation cannot be null

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteLROMethodSignature(lroObjectType, methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                Diagnostic diagnostic = new Diagnostic($"{This.Type.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, GetClientDiagnosticFieldName(operationMappings.Values.First())))
                {
                    WriteLROMethodBody(lroObjectType, operationMappings, parameterMappings, async);
                }
                _writer.Line();
            }
        }

        protected abstract ResourceTypeSegment GetBranchResourceType(RequestPath branch);

        protected virtual void WriteLROMethodBody(CSharpType lroObjectType, IDictionary<RequestPath, MgmtRestOperation> operationMappings, IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // TODO -- we need to write multiple branches for a LRO operation
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteLROMethodBranch(lroObjectType, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                var keyword = "if";
                var escapeBranches = new List<RequestPath>();
                foreach ((var branch, var operation) in operationMappings)
                {
                    // we need to identify the correct branch using the resource type, therefore we need first to determine the resource type is a constant
                    var resourceType = GetBranchResourceType(branch);
                    if (!resourceType.IsConstant)
                    {
                        escapeBranches.Add(branch);
                        continue;
                    }
                    using (_writer.Scope($"{keyword} ({BranchIdVariableName}.ResourceType == {GetResourceTypeExpression(resourceType)})"))
                    {
                        WriteLROMethodBranch(lroObjectType, operation, parameterMappings[branch], async);
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
                        WriteLROMethodBranch(lroObjectType, operationMappings[branch], parameterMappings[branch], async);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"It is impossible to identify which branch to go here using Id for request paths: [{string.Join(", ", escapeBranches)}]");
                }
            }
        }

        protected virtual void WriteLROMethodBranch(CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestFieldOrPropertyName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, GetClientDiagnosticFieldName(operation), PipelineProperty, operation, parameterMapping, async);
        }

        protected virtual void WriteLROMethodSignature(CSharpType returnType, string methodName, IReadOnlyList<Parameter> methodParameters, bool async,
            string accessibility = "public", bool isVirtual = true)
        {
            _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            _writer.Append($"{accessibility} {GetAsyncKeyword(async)} {GetVirtual(isVirtual)} {returnType.WrapAsync(async)} {CreateMethodName(methodName, async)}(");
            _writer.Append($"bool waitForCompletion, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }

            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
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
                _writer.Append($"{diagnosticsVariableName}, {pipelineVariableName}, {GetRestFieldOrPropertyName(operation)}.{RequestWriterHelpers.CreateRequestMethodName(operation.Method.Name)}(");
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

        protected virtual void BuildParameters(MgmtClientOperation clientOperation, out Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            out Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, out List<Parameter> methodParameters)
        {
            // get the corresponding MgmtClientOperation mapping
            operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
            // build parameter mapping
            parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
        }

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
