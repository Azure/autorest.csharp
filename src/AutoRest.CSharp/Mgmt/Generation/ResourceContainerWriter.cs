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
        private const string RestClient = "_restClient";
        private CodeWriter _writer;
        private ResourceContainer _resourceContainer;
        private ResourceData _resourceData;
        private MgmtRestClient _restClient;
        private Resource _resource;
        private ResourceOperation _resourceOperation;

        public ResourceContainerWriter(CodeWriter writer, ResourceContainer resourceContainer, AutoRest.MgmtOutputLibrary library)
        {
            _writer = writer;
            _resourceContainer = resourceContainer;
            var operationGroup = resourceContainer.OperationGroup;
            _resourceData = library.GetResourceData(operationGroup);
            _restClient = library.GetRestClient(operationGroup);
            _resource = library.GetArmResource(operationGroup);
            _resourceOperation = library.GetResourceOperation(operationGroup);
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
                string baseClass = FindRestClientMethodByName(new string[] { "Get" }, out _)
                    ? $"ResourceContainerBase<{_resourceContainer.ResourceIdentifierType}, {_resource.Type.Name}, {_resourceData.Type.Name}>"
                    : $"ContainerBase<{_resourceContainer.ResourceIdentifierType}, {_resource.Type.Name}>";
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
            var parent = "parent";
            _writer.WriteXmlDocumentationParameter(parent, "The resource representing the parent resource.");
            using (_writer.Scope($"internal {typeOfThis}({typeof(ResourceOperationsBase)} {parent}) : base({parent})"))
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
            _writer.Line($"private {_restClient.Type} {RestClient} => new {_restClient.Type}({ClientDiagnosticsField}, {PipelineField}{subIdIfNeeded});");
        }

        private void WriteIdProperty()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Typed Resource Identifier for the container.");
            _writer.LineRaw("// todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.");
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
            if (FindRestClientMethodByName(new string[] { "Get" }, out restClientMethod))
            {
                WriteGetVariants(restClientMethod);
            }
            else
            {
                // WriteGetVariantsThatThrow();
            }

            WriteListVariants();
        }

        private bool FindRestClientMethodByHttpMethod(RequestMethod httpMethod, out RestClientMethod restMethod)
        {
            restMethod = _restClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(httpMethod));
            return restMethod != null;
        }
        private bool FindRestClientMethodByName(IEnumerable<string> nameOptions, out RestClientMethod restMethod)
        {
            restMethod = _restClient.Methods.FirstOrDefault(method => nameOptions.Any(option => string.Equals(method.Name, option, StringComparison.InvariantCultureIgnoreCase)));
            return restMethod != null;
        }

        private void WriteCreateOrUpdateVariants(RestClientMethod restClientMethod)
        {
            // hack: should add a IsLongRunning property to method?
            var isLongRunning = restClientMethod.Responses.All(response => response.ResponseBody == null);
            var parameterMapping = BuildParameterMapping(restClientMethod);
            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            // todo: should not write inheritdoc
            WriteContainerMethodScope(false, $"{typeof(ArmResponse)}<{_resource.Type.Name}>", "CreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"return StartCreateOrUpdate(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw($"{parameter.Name}, ");
                }
                _writer.Line($"cancellationToken: cancellationToken).WaitForCompletion() as {typeof(ArmResponse)}<{_resource.Type}>;");
            });

            WriteContainerMethodScope(true, $"{typeof(Task)}<{typeof(ArmResponse)}<{_resource.Type.Name}>>", "CreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var operation = await StartCreateOrUpdateAsync(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw($"{parameter.Name}, ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                _writer.Line($"return operation.WaitForCompletion() as {typeof(ArmResponse)}<{_resource.Type}>;");
            });

            WriteContainerMethodScope(false, $"ArmOperation<{_resource.Type.Name}>", "StartCreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var originalResponse = {RestClient}.{restClientMethod.Name}(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken);");
                if (isLongRunning)
                {
                    _writer.Line($"var operation = new {_resource.Type}{restClientMethod.Name}Operation(");
                    _writer.Line($"{ClientDiagnosticsField}, {PipelineField}, {RestClient}.Create{restClientMethod.Name}Request(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Line($").Request,");
                    _writer.Line($"originalResponse);");
                    _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"operation,");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
                else
                {
                    _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"originalResponse,");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");

                }
            });

            WriteContainerMethodScope(true, $"{typeof(Task)}<ArmOperation<{_resource.Type.Name}>>", "StartCreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var originalResponse = await {RestClient}.{restClientMethod.Name}Async(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                if (isLongRunning)
                {
                    _writer.Line($"var operation = new {_resource.Type}{restClientMethod.Name}Operation(");
                    _writer.Line($"{ClientDiagnosticsField}, {PipelineField}, {RestClient}.Create{restClientMethod.Name}Request(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Line($").Request,");
                    _writer.Line($"originalResponse);");
                    _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"operation,");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
                else
                {
                    _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"originalResponse,");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
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
            _writer.Line();
            _writer.WriteXmlDocumentationInheritDoc();
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
        /// For example, how to map the parameters of
        /// `DedicatedHostContainer.CreateOrUpdate(string hostName, DedicatedHostData parameters) to
        /// `DedicatedHostsRestOperations.CreateOrUpdate(string resourceGroupName, string hostGroupName, string hostName, DedicatedHostData parameters)
        /// </summary>
        /// <param name="method">Represents a method in RestOperations class.</param>
        /// <returns>
        /// A list of tuples containing
        /// - Parameter: the reference to the parameter object in RestClientMethod
        /// - IsPassThru: should the parameter be passed through from the method in container class
        /// - ValueExpression: if not pass-through, this is the value to pass in RestClientMethod
        /// </returns>
        private IEnumerable<(Parameter Parameter, bool IsPassThru, string ValueExpression)> BuildParameterMapping(RestClientMethod method)
        {
            var parameterMapping = new List<(Parameter Parameter, bool IsPassThru, string ValueExpression)>();
            var dotParent = "";

            // loop through parameters in REST call, map the leading string-like parameters to
            // Id.ResourceGroupName, Id.ResourceGroupName.Parent.Name, Id.ResourceGroupName.Parent.Parent.Name...
            // corner case: type is enum and you can convert string to it (model-as-string), we handle it as string
            foreach (var parameter in method.Parameters)
            {
                bool passThru = true;
                string valueExpression = string.Empty;
                if (IsStringLike(parameter.Type))
                {
                    passThru = false;
                    if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                    {
                        valueExpression = "Id.ResourceGroupName";
                    }
                    else
                    {
                        valueExpression = $"Id{dotParent}.Name";
                        dotParent += ".Parent";
                    }
                }
                else
                {
                    passThru = true;
                }
                parameterMapping.Add((parameter, passThru, valueExpression));
            }
            // make last string-like parameter (typically the resource name) pass-through from container method
            // ignoring optional parameters such as `expand`
            var lastString = parameterMapping.LastOrDefault(parameter => IsStringLike(parameter.Parameter.Type) && parameter.Parameter.DefaultValue is null);
            if (lastString.Parameter != null && !lastString.Parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
            {
                var index = parameterMapping.IndexOf(lastString);
                parameterMapping[index] = (lastString.Parameter, true, string.Empty);
                // Tuple types are value types; tuple elements are public fields. That makes tuples mutable value types.
            }
            return parameterMapping;
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

            _writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
            _writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => {resourceType};");
        }

        private void WriteGetVariants(RestClientMethod method)
        {
            var parameterMapping = BuildParameterMapping(method);
            // some Get() contains extra non-name parameters which if added to method signature,
            // would break the inheritance to ResourceContainerBase
            // e.g. `expand` when getting image in compute RP
            parameterMapping = parameterMapping.Where(mapping => mapping.Parameter.DefaultValue is null);

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

            WriteContainerMethodScope(false, $"{typeof(ArmResponse)}<{_resource.Type.Name}>", "Get", passThruParameters, writer =>
            {
                _writer.Line($"return new PhArmResponse<{_resource.Type}, {_resourceData.Type}>(");
                _writer.Append($"{RestClient}.Get(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken),");
                _writer.Line($"data => new {_resource.Type}(Parent, data));");
            }, isOverride: true);

            WriteContainerMethodScope(true, $"{typeof(Task)}<{typeof(ArmResponse)}<{_resource.Type.Name}>>", "Get", passThruParameters, writer =>
            {
                _writer.Line($"return new PhArmResponse<{_resource.Type}, {_resourceData.Type}>(");
                _writer.Append($"await {RestClient}.GetAsync(");
                foreach (var parameter in parameterMapping)
                {
                    _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken),");
                _writer.Line($"data => new {_resource.Type}(Parent, data));");
            }, isOverride: true);
        }

        private void WriteListVariants()
        {
            WriteListAsGenericResource();
            WriteListAsGenericResourceAsync();
            WriteList();
            WriteListAsync();
        }

        private void WriteList()
        {
            var methodName = "List";
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of <see cref=\"{_resource.Type.Name}\" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
            _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"A collection of <see cref=\"{_resource.Type.Name}\" /> that may take multiple service requests to iterate over.");
            using (_writer.Scope($"public Pageable<{_resource.Type}> {methodName}(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{methodName}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var results = ListAsGenericResource(nameFilter, top, cancellationToken);");
                    _writer.Line($"return new PhWrappingPageable<GenericResource, {_resource.Type}>(results, genericResource => new {_resourceOperation.Type}(genericResource).Get().Value);");
                });
            }
        }

        private void WriteListAsync()
        {
            var methodName = CreateMethodName("List", true);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of <see cref=\"{_resource.Type.Name}\" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
            _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"An async collection of <see cref=\"{_resource.Type.Name}\" /> that may take multiple service requests to iterate over.");
            using (_writer.Scope($"public AsyncPageable<{_resource.Type}> {methodName}(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{"List"}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);");
                    _writer.Line($"return new PhWrappingAsyncPageable<GenericResource, {_resource.Type}>(results, genericResource => new {_resourceOperation.Type}(genericResource).Get().Value);");
                });
            }
        }

        private void WriteListAsGenericResource()
        {
            var methodName = "ListAsGenericResource";
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {_resource.Type.Name} for this resource group represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"A collection of resource that may take multiple service requests to iterate over.");
            using (_writer.Scope($"public {typeof(Pageable<GenericResource>)} {methodName}(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{methodName}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    // todo: do not hard code ResourceGroupOperations
                    _writer.Line($"return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);");
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
                    // todo: do not hard code ResourceGroupOperations
                    _writer.Line($"return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);");
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