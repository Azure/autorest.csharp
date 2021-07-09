// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.ResourceManager.Core;

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
    internal class ResourceContainerWriter : MgmtClientBaseWriter
    {
        private const string _parentProperty = "Parent";
        private CodeWriter _writer;
        private ResourceContainer _resourceContainer;
        private ResourceData _resourceData;
        private Resource _resource;
        private ResourceOperation _resourceOperation;
        private BuildContext<MgmtOutputLibrary> _context;

        protected override string ContextProperty => "Parent";

        public ResourceContainerWriter(CodeWriter writer, ResourceContainer resourceContainer, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            _resourceContainer = resourceContainer;
            var operationGroup = resourceContainer.OperationGroup;
            _resourceData = context.Library.GetResourceData(operationGroup);
            _restClient = context.Library.GetRestClient(operationGroup);
            _resource = context.Library.GetArmResource(operationGroup);
            _resourceOperation = context.Library.GetResourceOperation(operationGroup);
            _context = context;
        }

        public void WriteContainer()
        {
            WriteUsings(_writer);

            var cs = _resourceContainer.Type;
            var @namespace = cs.Namespace;
            using (_writer.Namespace(@namespace))
            {
                _writer.WriteXmlDocumentationSummary(_resourceContainer.Description);
                string baseClass = GetBaseType();
                using (_writer.Scope($"{_resourceContainer.Declaration.Accessibility} partial class {cs.Name:D} : {baseClass}"))
                {
                    WriteContainerCtors(_writer, _resourceContainer.Type.Name, "ResourceOperationsBase", "parent");
                    WriteFields(_writer, _restClient!);
                    WriteIdProperty();
                    WriteContainerProperties(_writer, _resourceContainer.GetValidResourceValue());
                    WriteResourceOperations();
                    WriteRemainingMethods();
                    WriteBuilders();
                }
            }
        }

        private void WriteRemainingMethods()
        {
            _writer.Line();
            foreach (var restMethod in _resourceContainer.RemainingMethods)
            {
                WriteClientMethod(_writer, restMethod, _resourceContainer.GetDiagnostic(restMethod.RestClientMethod), _resourceContainer.OperationGroup, _context, true);
                WriteClientMethod(_writer, restMethod, _resourceContainer.GetDiagnostic(restMethod.RestClientMethod), _resourceContainer.OperationGroup, _context, false);
            }
        }

        protected virtual string GetBaseType()
        {
            return _resourceContainer.GetMethod != null
                ? $"ResourceContainerBase<{_resourceContainer.ResourceIdentifierType}, {_resource.Type.Name}, {_resourceData.Type.Name}>"
                : $"ContainerBase";
        }

        private void WriteIdProperty()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Typed Resource Identifier for the container.");
            var idType = _resourceContainer.OperationGroup.GetResourceIdentifierType(_context);
            _writer.Line($"public new {idType} Id => base.Id as {idType};");
        }

        private void WriteResourceOperations()
        {
            _writer.Line();
            _writer.LineRaw($"// Container level operations.");

            if (_resourceContainer.PutMethod != null)
            {
                WriteCreateOrUpdateVariants(_resourceContainer.PutMethod);
            }

            if (_resourceContainer.GetMethod != null)
            {
                WriteGetVariants(_resourceContainer.GetMethod.RestClientMethod);
                WriteTryGetVariants(_resourceContainer.GetMethod.RestClientMethod);
                WriteDoesExistVariants(_resourceContainer.GetMethod.RestClientMethod);
            }

            WriteListVariants();
        }

        private void WriteDoesExistVariants(RestClientMethod getMethod)
        {
            var parameterMapping = BuildParameterMapping(getMethod);

            var methodName = "Get";
            var scopeName = methodName;

            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");
            WriteContainerMethodScope(false, $"bool", "DoesExist", passThruParameters, writer =>
            {
                _writer.Append($"return TryGet(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw(parameter.Name);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken) != null;");
            }, isOverride: false);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");
            WriteContainerMethodScope(true, $"{typeof(Task)}<bool>", "DoesExist", passThruParameters, writer =>
            {
                _writer.Append($"return await TryGetAsync(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw(parameter.Name);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false) != null;");
            }, isOverride: false);
        }

        private void WriteTryGetVariants(RestClientMethod getMethod)
        {
            var parameterMapping = BuildParameterMapping(getMethod);

            var methodName = "Get";
            var scopeName = methodName;

            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");
            WriteContainerMethodScope(false, $"{_resource.Type.Name}", "TryGet", passThruParameters, writer =>
            {
                _writer.Append($"return Get(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw(parameter.Name);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken).Value;");
            }, isOverride: false, catch404: true);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");
            WriteContainerMethodScope(true, $"{typeof(Task)}<{_resource.Type.Name}>", "TryGet", passThruParameters, writer =>
            {
                _writer.Append($"return await GetAsync(");
                foreach (var parameter in passThruParameters)
                {
                    _writer.AppendRaw(parameter.Name);
                    _writer.AppendRaw(", ");
                }
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
            }, isOverride: false, catch404: true);
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
                _writer.Line($"cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);");
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
                _writer.Line($"return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);");
            });

            var isLongRunning = restClientMethod.Operation.IsLongRunning;
            CSharpType lroObjectType = isLongRunning
                ? _context.Library.GetLongRunningOperation(restClientMethod.Operation).Type
                : _context.Library.GetNonLongRunningOperation(restClientMethod.Operation).Type;

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"The operation to create or update a {_resource.Type.Name}. Please note some properties can be set only during creation.");
            WriteContainerMethodScope(false, $"{lroObjectType.Name}", "StartCreateOrUpdate", passThruParameters, writer =>
            {
                _writer.Append($"var originalResponse = {RestClientField}.{restClientMethod.Name}(");
                WriteArguments(writer, parameterMapping);
                _writer.Line($"cancellationToken: cancellationToken);");
                if (isLongRunning)
                {
                    _writer.Append($"return new {lroObjectType}(");
                    _writer.Append($"{_parentProperty}, {ClientDiagnosticsField}, {PipelineProperty}, {RestClientField}.Create{restClientMethod.Name}Request(");
                    WriteArguments(writer, parameterMapping);
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
                WriteArguments(writer, parameterMapping);
                _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                if (isLongRunning)
                {
                    _writer.Append($"return new {lroObjectType}(");
                    _writer.Append($"{_parentProperty}, {ClientDiagnosticsField}, {PipelineProperty}, {RestClientField}.Create{restClientMethod.Name}Request(");
                    WriteArguments(writer, parameterMapping);
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
        private void WriteContainerMethodScope(bool isAsync, FormattableString returnType, string syncMethodName, IEnumerable<Parameter> parameters, CodeWriterDelegate inner, bool isOverride = false, bool catch404 = false)
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
            _writer.WriteXmlDocumentationParameter(cancellationTokenParameter, @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""CancellationToken.None"" />.");

            _writer.Append($"public {(isAsync ? "async " : string.Empty)}{(isOverride ? "override " : "virtual ")}{returnType} {CreateMethodName(syncMethodName, isAsync)}(");
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
            }, catch404);
        }

        private void WriteGetVariants(RestClientMethod method)
        {
            var parameterMapping = BuildParameterMapping(method);

            var methodName = "Get";
            var scopeName = methodName;

            IEnumerable<Parameter> passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets details for this resource from the service.");
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
            }, isOverride: false);

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets details for this resource from the service.");
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
            }, isOverride: false);
        }

        private void WriteListVariants()
        {
            if (_resourceContainer.ListMethod != null)
            {
                WriteList(_writer, false, _resource.Type, _resourceContainer.ListMethod, $".Select(value => new {_resource.Type.Name}({_parentProperty}, value))");
                WriteList(_writer, true, _resource.Type, _resourceContainer.ListMethod, $".Select(value => new {_resource.Type.Name}({_parentProperty}, value))");
            }

            WriteListAsGenericResource(async: false);
            WriteListAsGenericResource(async: true);
        }

        private void WriteListAsGenericResource(bool async)
        {
            const string syncMethodName = "ListAsGenericResource";
            var methodName = CreateMethodName(syncMethodName, async);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {_resource.Type.Name} for this resource group represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("expand", "Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"{(async ? "An async" : "A")} collection of resource that may take multiple service requests to iterate over.");
            CSharpType returnType = new CSharpType(async ? typeof(AsyncPageable<>) : typeof(Pageable<>), typeof(GenericResourceExpanded));
            using (_writer.Scope($"public {returnType} {methodName}(string nameFilter, string expand = null, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{syncMethodName}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("ListAtContext", async)}({_parentProperty} as {typeof(ResourceGroupOperations)}, filters, expand, top, cancellationToken);");
                });
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{_resourceContainer.ResourceIdentifierType.Name}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
        }
    }
}
