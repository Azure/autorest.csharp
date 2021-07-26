﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

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
        private CodeWriter _writer;
        private ResourceContainer _resourceContainer;
        private ResourceData _resourceData;
        private Resource _resource;
        private ResourceOperation _resourceOperation;
        private BuildContext<MgmtOutputLibrary> _context;

        protected override string ContextProperty => "Parent";

        protected CSharpType TypeOfThis => _resourceContainer.Type;
        protected override string TypeNameOfThis => TypeOfThis.Name;

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

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resourceContainer.Description}");
                _writer.Append($"{_resourceContainer.Declaration.Accessibility} partial class {TypeNameOfThis:D} : ");
                if (_resourceContainer.GetMethod != null)
                {
                    _writer.Line($"ResourceContainerBase<{_resourceContainer.ResourceIdentifierType}, {_resource.Type}, {_resourceData.Type}>");
                }
                else
                {
                    _writer.Line($"{typeof(ContainerBase)}");
                }
                using (_writer.Scope())
                {
                    WriteContainerCtors(_writer, typeof(OperationsBase), "parent");
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

            if (_resourceContainer.CreateMethod != null)
            {
                WriteCreateOrUpdateVariants(_resourceContainer.CreateMethod);
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

        private void WriteCreateOrUpdateVariants(RestClientMethod clientMethod)
        {
            WriteFirstLROMethod(_writer, clientMethod, _context, false, true, "CreateOrUpdate");
            WriteFirstLROMethod(_writer, clientMethod, _context, true, true, "CreateOrUpdate");

            WriteStartLROMethod(_writer, clientMethod, _context, false, true, "CreateOrUpdate");
            WriteStartLROMethod(_writer, clientMethod, _context, true, true, "CreateOrUpdate");
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
            _writer.WriteXmlDocumentationParameter(cancellationTokenParameter, $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");

            _writer.Append($"public {AsyncKeyword(isAsync)} {OverrideKeyword(isOverride, true)} {returnType} {CreateMethodName(syncMethodName, isAsync)}(");
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
                _writer.Line($"return {typeof(Response)}.FromValue(new {_resource.Type}({ContextProperty}, response.Value), response.GetRawResponse());");
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
                _writer.Line($"return {typeof(Response)}.FromValue(new {_resource.Type}({ContextProperty}, response.Value), response.GetRawResponse());");
            }, isOverride: false);
        }

        private void WriteListVariants()
        {
            foreach (var listMethod in _resourceContainer.ListMethods)
            {
                if (listMethod.PagingMethod != null)
                {
                    WriteList(_writer, false, _resource.Type, listMethod.PagingMethod, "List", $".Select(value => new {_resource.Type.Name}({ContextProperty}, value))");
                    WriteList(_writer, true, _resource.Type, listMethod.PagingMethod, "List", $".Select(value => new {_resource.Type.Name}({ContextProperty}, value))");
                }

                if (listMethod.ClientMethod != null)
                {
                    _writer.Line();
                    WriteClientMethod(_writer, listMethod.ClientMethod, _resourceContainer.GetDiagnostic(listMethod.ClientMethod.RestClientMethod), _resourceContainer.OperationGroup, _context, true);
                    WriteClientMethod(_writer, listMethod.ClientMethod, _resourceContainer.GetDiagnostic(listMethod.ClientMethod.RestClientMethod), _resourceContainer.OperationGroup, _context, false);
                }
            }

            WriteListAsGenericResource(async: false);
            WriteListAsGenericResource(async: true);
        }

        private void WriteListAsGenericResource(bool async)
        {
            const string syncMethodName = "ListAsGenericResource";
            var methodName = CreateMethodName(syncMethodName, async);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of <see cref=\"{_resource.Type}\" /> for this resource group represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", $"The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"{(async ? "An async" : "A")} collection of resource that may take multiple service requests to iterate over.");
            CSharpType returnType = new CSharpType(async ? typeof(AsyncPageable<>) : typeof(Pageable<>), typeof(GenericResourceExpanded));
            using (_writer.Scope($"public {returnType} {methodName}(string nameFilter, string expand = null, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{syncMethodName}"), ClientDiagnosticsField, writer =>
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("ListAtContext", async)}({ContextProperty} as {typeof(ResourceGroupOperations)}, filters, expand, top, cancellationToken);");
                });
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{_resourceContainer.ResourceIdentifierType.Name}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // if the method needs resource name (typically all non-list methods), we should make it pass-thru by
            // making the last string-like mandatory parameter (typically the resource name) pass-through
            if (!method.Name.StartsWith("List", StringComparison.InvariantCultureIgnoreCase))
            {
                var lastString = parameterMapping.LastOrDefault(parameter => parameter.Parameter.Type.IsStringLike() && IsMandatory(parameter.Parameter));
                if (lastString?.Parameter != null && !lastString.Parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    lastString.IsPassThru = true;
                    parentNameStack.Pop();
                }
            }
        }

        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            bool passThru = false;
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

            return passThru;
        }
    }
}
