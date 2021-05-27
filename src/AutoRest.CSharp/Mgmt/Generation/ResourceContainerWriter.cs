// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core.Resources;
using Azure;
using Azure.ResourceManager.Core;
using Azure.Core.Pipeline;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using System.Diagnostics;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource container.
    /// A resource container should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceContainerWriter : ClientWriter
    {
        private const string ClientDiagnosticsField = "_clientDiagnostics";
        private const string PipelineField = "_pipeline";
        private const string RestClientField = "_restClient";
        private const string _parentProperty = "Parent";
        private CodeWriter _writer;
        private ResourceContainer _resourceContainer;
        private ResourceData _resourceData;
        private MgmtRestClient _restClient;
        private Resource _resource;
        private ResourceOperation _resourceOperation;
        private MgmtOutputLibrary _library;

        public ResourceContainerWriter(CodeWriter writer, ResourceContainer resourceContainer, MgmtOutputLibrary library)
        {
            _writer = writer;
            _resourceContainer = resourceContainer;
            var operationGroup = resourceContainer.OperationGroup;
            _resourceData = library.GetResourceData(operationGroup);
            _restClient = library.GetRestClient(operationGroup);
            _resource = library.GetArmResource(operationGroup);
            _resourceOperation = library.GetResourceOperation(operationGroup);
            _library = library;
        }

        public void WriteContainer()
        {
            _writer.UseNamespace(typeof(Task).Namespace!); // Explicitly adding `System.Threading.Tasks` because
                                                           // at build time I don't have the type information inside Task<>

            var cs = _resourceContainer.Type;
            var @namespace = cs.Namespace;
            using (_writer.Namespace(@namespace))
            {
                _writer.WriteXmlDocumentationSummary(_resourceContainer.Description);
                string baseClass = FindRestClientMethodByPrefix("Get", out _)
                    ? $"ResourceContainerBase<{_resourceContainer.ResourceIdentifierType}, {_resource.Type.Name}, {_resourceData.Type.Name}>"
                    : $"ContainerBase<{_resourceContainer.ResourceIdentifierType}>";
                using (_writer.Scope($"{_resourceContainer.Declaration.Accessibility} partial class {cs.Name:D} : {baseClass}"))
                {
                    WriteContainerCtors();
                    WriteFields();
                    WriteIdProperty();
                    WriteContainerProperties();
                    WriteResourceOperations();
                    WriteBuilders();
                }
            }
        }

        private void WriteContainerCtors()
        {
            string typeOfThis = _resourceContainer.Type.Name;

            // write protected default constructor
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class for mocking.");
            using (_writer.Scope($"protected {typeOfThis}()"))
            { }

            // write "parent resource" constructor
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of {typeOfThis} class.");
            var parentArgument = "parent";
            _writer.WriteXmlDocumentationParameter(parentArgument, "The resource representing the parent resource.");
            using (_writer.Scope($"internal {typeOfThis}({typeof(ResourceOperationsBase)} {parentArgument}) : base({parentArgument})"))
            {
                _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                // todo: after a shared pipeline field is implemented in the base class, replace this with that
                _writer.Line($"{PipelineField} = {typeof(ManagementPipelineBuilder)}.Build(Credential, BaseUri, ClientOptions);");
            }
        }

        private void WriteFields()
        {
            _writer.Line();
            _writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            _writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Represents the REST operations.");
            // subscriptionId might not always be needed. For example `RestOperations` does not have it.
            var subIdIfNeeded = _restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? ", Id.SubscriptionId" : "";
            _writer.Line($"private {_restClient.Type} {RestClientField} => new {_restClient.Type}({ClientDiagnosticsField}, {PipelineField}{subIdIfNeeded});");
        }

        private void WriteIdProperty()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Typed Resource Identifier for the container.");
            _writer.Line($"public new {typeof(ResourceGroupResourceIdentifier)} Id => base.Id as {typeof(ResourceGroupResourceIdentifier)};");
        }

        private void WriteResourceOperations()
        {
            _writer.Line();
            _writer.LineRaw($"// Container level operations.");

            // To generate resource operations, we need to find out the correct REST client methods to call.
            // We must look for CreateOrUpdate by HTTP method because it may be named differently from `CreateOrUpdate`.
            if (FindRestClientMethodByHttpMethod(RequestMethod.Put, out var restClientMethod))
            {
                WriteCreateOrUpdateVariants(restClientMethod);
            }

            // We must look for Get by method name because HTTP GET may map to >1 methods (get/list)
            if (FindRestClientMethodByPrefix("Get", out restClientMethod))
            {
                WriteGetVariants(restClientMethod);
            }

            WriteListVariants();
        }

        private bool FindRestClientMethodByHttpMethod(RequestMethod httpMethod, out RestClientMethod restMethod)
        {
            restMethod = _restClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(httpMethod));
            return restMethod != null;
        }

        private bool FindRestClientMethodByPrefix(string prefix, out RestClientMethod restMethod)
        {
            restMethod = _restClient.Methods.FirstOrDefault(method => method.Name.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase));
            return restMethod != null;
        }

        private void WriteCreateOrUpdateVariants(RestClientMethod restClientMethod)
        {
            Debug.Assert(restClientMethod.Operation != null);
            var parameterMapping = BuildParameterMapping(restClientMethod);
            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"The operation to create or update a {_resource.Type.Name}. Please note some properties can be set only during creation.");
            WriteContainerMethodScope(false, $"{typeof(Response)}<{_resource.Type.Name}>", "CreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"return StartCreateOrUpdate(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw($"{parameter.Name}, ");
                }
                _writer.Line($"cancellationToken: cancellationToken).WaitForCompletion();");
            });

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"The operation to create or update a {_resource.Type.Name}. Please note some properties can be set only during creation.");
            WriteContainerMethodScope(true, $"{typeof(Task)}<{typeof(Response)}<{_resource.Type.Name}>>", "CreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var operation = await StartCreateOrUpdateAsync(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw($"{parameter.Name}, ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                _writer.Line($"return await operation.WaitForCompletionAsync().ConfigureAwait(false);");
            });

            var isLongRunning = restClientMethod.Operation.IsLongRunning;
            CSharpType lroObjectType = isLongRunning
                ? _library.GetLongRunningOperation(restClientMethod.Operation).Type
                : _library.GetNonLongRunningOperation(restClientMethod.Operation).Type;

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"The operation to create or update a {_resource.Type.Name}. Please note some properties can be set only during creation.");
            WriteContainerMethodScope(false, $"{lroObjectType.Name}", "StartCreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var originalResponse = {RestClientField}.{restClientMethod.Name}(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken);");
                if (isLongRunning)
                {
                    _writer.Append($"return new {lroObjectType}(");
                    _writer.Append($"{_parentProperty}, {ClientDiagnosticsField}, {PipelineField}, {RestClientField}.Create{restClientMethod.Name}Request(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Append($").Request,");
                    _writer.Line($"originalResponse);");
                }
                else
                {
                    _writer.Append($"return new {lroObjectType}(");
                    _writer.Append($"{_parentProperty},");
                    _writer.Line($"originalResponse);");
                }
            });

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"The operation to create or update a {_resource.Type.Name}. Please note some properties can be set only during creation.");
            WriteContainerMethodScope(true, $"{typeof(Task)}<{lroObjectType.Name}>", "StartCreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var originalResponse = await {RestClientField}.{restClientMethod.Name}Async(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                if (isLongRunning)
                {
                    _writer.Append($"return new {lroObjectType}(");
                    _writer.Append($"{_parentProperty}, {ClientDiagnosticsField}, {PipelineField}, {RestClientField}.Create{restClientMethod.Name}Request(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Append($").Request,");
                    _writer.Line($"originalResponse);");
                }
                else
                {
                    _writer.Append($"return new {lroObjectType}(");
                    _writer.Append($"{_parentProperty},");
                    _writer.Line($"originalResponse);");
                }
            });
        }

        /// <summary>
        /// Write some scaffolding for container operation methods.
        /// </summary>
        /// <param name="isAsync"></param>
        /// <param name="returnType">Must be string.</param>
        /// <param name="syncMethodName">Method name in its sync form.</param>
        /// <param name="parameters">Must not contain cancellationToken.</param>
        /// <param name="inner">Main logic of the method writer.</param>
        /// <param name="isOverride"></param>
        private void WriteContainerMethodScope(bool isAsync, FormattableString returnType, string syncMethodName, IEnumerable<Parameter> parameters, CodeWriterDelegate inner, bool isOverride = false)
        {
            if (isOverride)
            {
                _writer.WriteXmlDocumentationInheritDoc();
            }
            foreach (var parameter in parameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }

            const string cancellationTokenParameter = "cancellationToken";
            _writer.WriteXmlDocumentationParameter(cancellationTokenParameter, @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

            _writer.Append($"public {(isAsync ? "async " : string.Empty)}{(isOverride ? "override " : string.Empty)}{returnType} {CreateMethodName(syncMethodName, isAsync)}(");
            foreach (var parameter in parameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Append($"{typeof(CancellationToken)} {cancellationTokenParameter} = default)");
            using var _ = _writer.Scope();
            WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{syncMethodName}"), ClientDiagnosticsField, writer =>
            {
                _writer.WriteParameterNullChecks(parameters.ToList());
                inner(_writer);
            });
        }

        /// <summary>
        /// Builds the mapping between resource operations in Container class and that in RestOperations class.
        /// For example `DedicatedHostRestClient.CreateOrUpdate()`
        /// | resourceGroupName      | hostGroupName    | hostName | parameters |
        /// | ---------------------- | ---------------- | -------- | ---------- |
        /// | "Id.ResourceGroupName" | "Id.Parent.Name" | hostName | parameters |
        /// </summary>
        /// <param name="method">Represents a method in RestOperations class.</param>
        private IEnumerable<ParameterMapping> BuildParameterMapping(RestClientMethod method)
        {
            var parameterMapping = new List<ParameterMapping>();
            var dotParent = string.Empty;
            var parentNameStack = new Stack<string>();

            // loop through parameters of REST client method, map the leading string-like parameters to
            // Id.ResourceGroupName, Id.Name, Id.Parent.Name...
            // special case: type is enum and you can convert string to it (model-as-string), we should handle it as string
            // special case 2: in paging scenarios, `nextLink` needs to be handled specially, so here we just ignore it
            foreach (var parameter in method.Parameters)
            {
                bool passThru = true;
                string valueExpression = string.Empty;
                if (string.Equals(parameter.Name, "nextLink", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }
                else if (IsStringLike(parameter.Type) && IsMandatory(parameter))
                {
                    passThru = false;
                    if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                    {
                        valueExpression = "Id.ResourceGroupName";
                    }
                    else
                    {
                        // container.Id is the ID of parent resource, so the first name should just be `Id.Name`
                        parentNameStack.Push($"Id{dotParent}.Name");
                        dotParent += ".Parent";
                    }
                }
                else
                {
                    passThru = true;
                }
                parameterMapping.Add(new ParameterMapping(parameter, passThru, valueExpression));
            }

            // if the method needs resource name (typically all non-list methods), we should make it pass-thru
            // 1. make last string-like parameter (typically the resource name) pass-through from container method
            // 2. ignoring optional parameters such as `expand`
            if (!method.Name.StartsWith("List", StringComparison.InvariantCultureIgnoreCase))
            {
                var lastString = parameterMapping.LastOrDefault(parameter => IsStringLike(parameter.Parameter.Type) && IsMandatory(parameter.Parameter));
                if (lastString?.Parameter != null && !lastString.Parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    lastString.IsPassThru = true;
                    parentNameStack.Pop();
                }
            }

            // set the arguments for name parameters reversely: Id.Parent.Name, Id.Parent.Parent.Name, ...
            foreach (var parameter in parameterMapping)
            {
                if (IsMandatory(parameter.Parameter) && !parameter.IsPassThru && string.IsNullOrEmpty(parameter.ValueExpression))
                {
                    parameter.ValueExpression = parentNameStack.Pop();
                }
            }

            return parameterMapping;
        }

        private bool IsMandatory(Parameter parameter) => parameter.DefaultValue is null;

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a container method or an expression.
        /// </summary>
        private class ParameterMapping
        {
            /// <summary>
            /// The parameter object in <see cref="RestClientMethod"/>.
            /// </summary>
            public Parameter Parameter;
            /// <summary>
            /// Should the parameter be passed through from the method in container class?
            /// </summary>
            public bool IsPassThru;
            /// <summary>
            /// if not pass-through, this is the value to pass in <see cref="RestClientMethod"/>.
            /// </summary>
            public string ValueExpression;

            public ParameterMapping(Parameter parameter, bool isPassThru, string valueExpression)
            {
                Parameter = parameter;
                IsPassThru = isPassThru;
                ValueExpression = valueExpression;
            }
        }

        /// <summary>
        /// Is the input type string or an Enum that is modeled as string.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>Is the input type string or an Enum that is modeled as string.</returns>
        private bool IsStringLike(CSharp.Generation.Types.CSharpType type)
        {
            return type.Equals(typeof(string)) || type.Implementation is EnumType enumType && enumType.BaseType.Equals(typeof(string));
        }

        private void WriteContainerProperties()
        {
            var resourceType = _resourceContainer.GetValidResourceValue();

            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            if (!resourceType.Contains(".ResourceType"))
            {
                resourceType = $"\"{resourceType}\"";
            }

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
            _writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => {resourceType};");
        }

        private void WriteGetVariants(RestClientMethod method)
        {
            var parameterMapping = BuildParameterMapping(method);
            // some Get() contains extra non-name parameters which if added to method signature,
            // would break the inheritance to ResourceContainerBase
            // e.g. `expand` when getting image in compute RP
            parameterMapping = parameterMapping.Where(mapping => IsMandatory(mapping.Parameter));

            var methodName = "Get";
            var scopeName = methodName;

            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(parameter =>
            {
                if (IsStringLike(parameter.Parameter.Type))
                {
                    // for string-like parameters, we shall write them as string as base class
                    return new Parameter(
                        parameter.Parameter.Name,
                        parameter.Parameter.Description,
                        new CSharp.Generation.Types.CSharpType(typeof(string)),
                        parameter.Parameter.DefaultValue,
                        parameter.Parameter.ValidateNotNull,
                        parameter.Parameter.IsApiVersionParameter
                    );
                }
                else
                {
                    return parameter.Parameter;
                }
            });

            _writer.Line();
            WriteContainerMethodScope(false, $"{typeof(Response)}<{_resource.Type.Name}>", "Get", passThruParameters, writer =>
            {
                _writer.Append($"var response = {RestClientField}.{method.Name}(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken);");
                _writer.Line($"return {typeof(Response)}.FromValue(new {_resource.Type}({_parentProperty}, response.Value), response.GetRawResponse());");
            }, isOverride: true);

            _writer.Line();
            WriteContainerMethodScope(true, $"{typeof(Task)}<{typeof(Response)}<{_resource.Type.Name}>>", "Get", passThruParameters, writer =>
            {
                _writer.Append($"var response = await {RestClientField}.{method.Name}Async(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                _writer.Line($"return {typeof(Response)}.FromValue(new {_resource.Type}({_parentProperty}, response.Value), response.GetRawResponse());");
            }, isOverride: true);
        }

        private void WriteListVariants()
        {
            WriteList(async: false);
            WriteList(async: true);
            WriteListAsGenericResource(async: false);
            WriteListAsGenericResource(async: true);
        }

        private void WriteList(bool async)
        {
            // if we find a proper *list* method that supports *paging*,
            // we should generate paging logic (PageableHelpers.CreateEnumerable)
            // else we just call ListAsGenericResource to get the list then call Get on every resource
            PagingMethod list = FindListPagingMethod();

            var methodName = CreateMethodName("List", async);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of <see cref=\"{_resource.Type.Name}\" /> for this resource group.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            string returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{_resource.Type.Name}\" /> that may take multiple service requests to iterate over.";
            _writer.WriteXmlDocumentation("returns", returnText);
            var returnType = async
                ? new CSharpType(typeof(AsyncPageable<>), _resource.Type)
                : new CSharpType(typeof(Pageable<>), _resource.Type);
            var asyncText = async ? "Async" : string.Empty;
            using (_writer.Scope($"public {returnType} {methodName}(int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                if (list != null)
                {
                    WriteContainerPagingOperation(list, async);
                }
                else
                {
                    _writer.Line($"var results = ListAsGenericResource{asyncText}(null, top, cancellationToken);");
                    _writer.Append($"return new PhWrapping{asyncText}Pageable<GenericResource, {_resource.Type}>(");
                    _writer.Line($"results, genericResource => new {_resourceOperation.Type}(genericResource, genericResource.Id as {_resourceOperation.ResourceIdentifierType}).Get().Value);");
                }
            }
        }

            private PagingMethod FindListPagingMethod()
        {
            return _resourceContainer.PagingMethods.FirstOrDefault(m => m.Name.Equals("ListByResourceGroup", StringComparison.InvariantCultureIgnoreCase))
                ?? _resourceContainer.PagingMethods.FirstOrDefault(m => m.Name.Equals("List", StringComparison.InvariantCultureIgnoreCase))
                ?? _resourceContainer.PagingMethods.FirstOrDefault(m => m.Name.StartsWith("List", StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Write paging method using `PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunction)` pattern.
        /// </summary>
        /// <param name="pagingMethod">Paging method that contains rest methods.</param>
        /// <param name="async">Should the method be written sync or async.</param>
        private void WriteContainerPagingOperation(PagingMethod pagingMethod, bool async)
        {
            var parameters = pagingMethod.Method.Parameters;

            var pagedResourceType = new CSharpType(typeof(Page<>), _resource.Type);
            var returnType = async ? new CSharpType(typeof(Task<>), pagedResourceType) : pagedResourceType;

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            var asyncText = async ? "async" : string.Empty;
            var awaitText = async ? "await" : string.Empty;
            var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
            using (_writer.Scope($"{asyncText} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(_writer, pagingMethod.Diagnostics, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"var response = {awaitText} {RestClientField}.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                    foreach (var parameter in BuildParameterMapping(pagingMethod.Method).Where(p => IsMandatory(p.Parameter)))
                    {
                        writer.Append($"{parameter.ValueExpression}, ");
                    }

                    writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");

                    this._writer.UseNamespace("System.Linq");
                    // need the Select() for converting XXXResourceData to XXXResource
                    writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}.Select(value => new {_resource.Type}({_parentProperty}, value)), {continuationTokenText}, response.GetRawResponse());");
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (_writer.Scope($"{asyncText} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(_writer, pagingMethod.Diagnostics, ClientDiagnosticsField, writer =>
                    {
                        writer.Append($"var response = {awaitText} {RestClientField}.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(nextLink, ");
                        foreach (var parameter in BuildParameterMapping(pagingMethod.NextPageMethod).Where(p => IsMandatory(p.Parameter)))
                        {
                            writer.Append($"{parameter.ValueExpression}, ");
                        }
                        writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");
                        writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}.Select(value => new {_resource.Type}({_parentProperty}, value)), {continuationTokenText}, response.GetRawResponse());");
                    });
                }
            }
            _writer.Line($"return {typeof(PageableHelpers)}.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void WriteListAsGenericResource(bool async)
        {
            const string syncMethodName = "ListAsGenericResource";
            var methodName = CreateMethodName(syncMethodName, async);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {_resource.Type.Name} for this resource group represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"{(async ? "An async" : "A")} collection of resource that may take multiple service requests to iterate over.");
            CSharpType returnType = new CSharpType(async ? typeof(AsyncPageable<>) : typeof(Pageable<>), typeof(GenericResource));
            using (_writer.Scope($"public {returnType} {methodName}(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{syncMethodName}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    string asyncText = async ? "Async" : string.Empty;
                    _writer.Line($"return {typeof(ResourceListOperations)}.ListAtContext{asyncText}({_parentProperty} as {typeof(ResourceGroupOperations)}, filters, top, cancellationToken);");
                });
            }
        }

        private void WriteListAsGenericResourceAsync()
        {
            var methodName = CreateMethodName("ListAsGenericResource", true);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {_resource.Type.Name} for this resource group represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"An async collection of resource that may take multiple service requests to iterate over.");
            using (_writer.Scope($"public {typeof(AsyncPageable<GenericResource>)} {methodName}(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{"ListAsGenericResource"}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    _writer.Line($"return {typeof(ResourceListOperations)}.ListAtContextAsync({_parentProperty} as {typeof(ResourceGroupOperations)}, filters, top, cancellationToken);");
                });
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{_resourceContainer.ResourceIdentifierType}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
        }
    }
}
