// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource collection.
    /// A resource collection should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceCollectionWriter : ResourceWriter
    {
        private ResourceCollection _resourceCollection;

        protected override Type BaseClass => typeof(ArmCollection);

        protected override string ContextProperty => "Parent";

        protected override MgmtTypeProvider This => _resourceCollection;

        protected override string BranchIdVariableName => "Id";

        private MgmtClientOperation? _getAllOperation;

        public ResourceCollectionWriter(CodeWriter writer, ResourceCollection resourceCollection, BuildContext<MgmtOutputLibrary> context)
            : base(writer, resourceCollection.Resource, context)
        {
            _resourceCollection = resourceCollection;
            _getAllOperation = _resourceCollection.GetAllOperation;
        }

        public override void Write()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resourceCollection.Description}");
                _writer.Append($"{_resourceCollection.Declaration.Accessibility} partial class {TypeNameOfThis} : {BaseClass}");
                if (_getAllOperation != null)
                {
                    _writer.Append($", {new CSharpType(typeof(IEnumerable<>), _resource.Type)}, {new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)}");
                }
                using (_writer.Scope())
                {
                    WriteFields();
                    WriteCtors();
                    WriteProperties();
                    WriteMethods();

                    WriteBuilders();
                }
            }
        }

        protected override void WriteFields()
        {
            WriteFields(_writer, _resourceCollection.RestClients);

            foreach (var reference in _resourceCollection.ExtraConstructorParameters)
            {
                _writer.Line($"private readonly {reference.Type} {_resourceCollection.GetFieldName(reference)};");
            }
        }

        protected override void WriteCtors()
        {
            _writer.Line();
            // write protected default constructor
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{TypeNameOfThis}\"/> class for mocking.");
            using (_writer.Scope($"protected {TypeNameOfThis}()"))
            { }

            // write "parent resource" constructor
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of {TypeNameOfThis} class.");
            _writer.WriteXmlDocumentationParameter("parent", $"The resource representing the parent resource.");
            _writer.WriteXmlDocumentationParameters(_resourceCollection.ExtraConstructorParameters);
            _writer.Append($"internal {TypeNameOfThis}({typeof(ArmResource)} parent, ");
            foreach (var reference in _resourceCollection.ExtraConstructorParameters)
            {
                _writer.Append($"{reference.Type} {reference.Name}, ");
            }
            _writer.RemoveTrailingComma();
            _writer.Line($") : base(parent)");
            using (_writer.Scope())
            {
                _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                WriteRestClientAssignments();
                foreach (var reference in _resourceCollection.ExtraConstructorParameters)
                {
                    _writer.Line($"{_resourceCollection.GetFieldName(reference)} = {reference.Name};");
                }
                WriteDebugValidate(_writer);
            }
        }

        protected override void WriteProperties()
        {
            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            //if (!resourceType.Contains(".ResourceType"))
            //{
            //    resourceType = $"\"{resourceType}\"";
            //}

            var allPossibleTypes = _resourceCollection.ResourceTypes.SelectMany(p => p.Value).Distinct();

            FormattableString validResourceType = allPossibleTypes.Count() == 1
                ? validResourceType = GetResourceTypeExpression(allPossibleTypes.First())
                : validResourceType = $"{typeof(Azure.Core.ResourceIdentifier)}.Root.ResourceType";
            _writer.Line();

            WriteStaticValidate(allPossibleTypes.Count() != 1, validResourceType, _writer);
        }

        protected override void WriteMethods()
        {
            _writer.Line();
            _writer.LineRaw($"// Collection level operations.");

            if (_resourceCollection.CreateOperation != null)
            {
                WriteCreateOrUpdateMethod(_resourceCollection.CreateOperation, false);
                WriteCreateOrUpdateMethod(_resourceCollection.CreateOperation, true);
            }

            if (_resourceCollection.GetOperation != null)
            {
                WriteGetMethod(_resourceCollection.GetOperation, false);
                WriteGetMethod(_resourceCollection.GetOperation, true);
                WriteGetIfExists(_resourceCollection.GetOperation, false);
                WriteGetIfExists(_resourceCollection.GetOperation, true);
                WriteExists(_resourceCollection.GetOperation, false);
                WriteExists(_resourceCollection.GetOperation, true);
            }

            // write all the methods that should belong to this resouce collection
            foreach (var clientOperation in _resourceCollection.ClientOperations)
            {
                WriteMethod(clientOperation, false);
                WriteMethod(clientOperation, true);
            }

            var validResourceTypes = _resourceCollection.ResourceTypes.SelectMany(p => p.Value).Distinct();
            var resourceType = validResourceTypes.First();
            if (validResourceTypes.Count() == 1 && (resourceType == ResourceTypeSegment.ResourceGroup || resourceType == ResourceTypeSegment.Subscription))
            {
                WriteListAsGenericResource(resourceType, false);
                WriteListAsGenericResource(resourceType, true);
            }

            WriteEnumerableImpl(_writer);
        }

        protected override void BuildParameters(MgmtClientOperation clientOperation, out Dictionary<RequestPath, MgmtRestOperation> operationMappings, out Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, out IReadOnlyList<Parameter> methodParameters)
        {
            // get the corresponding MgmtClientOperation mapping
            operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName).Concat(_resourceCollection.ExtraContextualParameterMapping));
            // build parameter mapping
            parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
        }

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            return branch.GetResourceType(Config);
        }

        private void WriteExists(MgmtClientOperation clientOperation, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");

            BuildParameters(clientOperation, out var operationMappings, out _, out var methodParameters);
            WriteCollectionMethodScope(typeof(bool).WrapResponse(async), "Exists", methodParameters, writer =>
            {
                WriteExistsBody(methodParameters, async);
            }, async, isOverride: false);
        }

        private void WriteExistsBody(IEnumerable<Parameter> passThruParameters, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} {CreateMethodName("GetIfExists", async)}(");
            foreach (var parameter in passThruParameters)
            {
                _writer.AppendRaw(parameter.Name);
                _writer.AppendRaw(", ");
            }
            _writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return Response.FromValue(response.Value != null, response.GetRawResponse());");
        }

        private void WriteGetIfExists(MgmtClientOperation clientOperation, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");

            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            WriteCollectionMethodScope(_resource.Type.WrapResponse(async), "GetIfExists", methodParameters, writer =>
            {
                WriteGetMethodBody(writer, operationMappings, parameterMappings, async);
            }, async, isOverride: false);
        }

        private void WriteGetMethodBody(CodeWriter writer, IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // we need to write multiple branches for a normal method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteGetMethodBranch(writer, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteGetMethodBranch(CodeWriter writer, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            writer.Append($"var response = {GetAwait(async)} ");
            writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(async)};");

            writer.Line($"return response.Value == null");
            writer.Line($"\t? {typeof(Response)}.FromValue<{_resource.Type.Name}>(null, response.GetRawResponse())");
            writer.Line($"\t: {typeof(Response)}.FromValue(new {_resource.Type.Name}(this, response.Value), response.GetRawResponse());");
        }

        /// <summary>
        /// Write some scaffolding for collection operation methods.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="methodName">Method name in its sync form.</param>
        /// <param name="methodParameters">The "pass-through" parameters, must not contain cancellationToken.</param>
        /// <param name="inner">Main logic of the method writer.</param>
        /// <param name="async"></param>
        /// <param name="isOverride"></param>
        private void WriteCollectionMethodScope(CSharpType returnType, string methodName, IReadOnlyList<Parameter> methodParameters,
            CodeWriterDelegate inner, bool async, bool isOverride = false)
        {
            methodName = CreateMethodName(methodName, async);

            if (isOverride)
                _writer.WriteXmlDocumentationInheritDoc();
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);

            _writer.Append($"public {GetAsyncKeyword(async)} {GetOverride(isOverride, true)} {returnType} {methodName}(");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Append($"{typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);
                using (WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceCollection.Type.Name}.{methodName}"), ClientDiagnosticsField))
                {
                    inner(_writer);
                }
            }
        }

        private void WriteListAsGenericResource(ResourceTypeSegment resourceType, bool async)
        {
            const string syncMethodName = "GetAllAsGenericResources";
            var listScope = resourceType == ResourceTypeSegment.ResourceGroup ? "resource group" : "subscription";
            var methodName = CreateMethodName(syncMethodName, async);
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of <see cref=\"{_resource.Type}\" /> for this {listScope} represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("nameFilter", $"The filter used in this operation.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentation("returns", $"{(async ? "An async" : "A")} collection of resource that may take multiple service requests to iterate over.");
            CSharpType returnType = typeof(GenericResource).WrapPageable(async);
            using (_writer.Scope($"public {GetVirtual(true)} {returnType} {methodName}(string nameFilter, string expand = null, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                using (WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceCollection.Type.Name}.{syncMethodName}"), ClientDiagnosticsField))
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    if (resourceType == ResourceTypeSegment.ResourceGroup)
                    {
                        _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}({ContextProperty} as {typeof(ResourceGroup)}, filters, expand, top, cancellationToken);");
                    }
                    else
                    {
                        // this must be ResourceType.Subscription
                        _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}({ContextProperty} as {typeof(Subscription)}, filters, expand, top, cancellationToken);");
                    }
                }
            }
        }

        private void WriteEnumerableImpl(CodeWriter writer)
        {
            if (_getAllOperation == null)
                return;

            // if this collection has a GetAll function, we could have all kinds of IEnumerable implemented since we have wrapped non-pageable list functions to pageable
            _writer.Line();
            _writer.Line($"{new CSharpType(typeof(IEnumerator<>), _resource.Type)} {new CSharpType(typeof(IEnumerable<>), _resource.Type)}.GetEnumerator()");
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

            _writer.Line();
            _writer.Line($"{new CSharpType(typeof(IAsyncEnumerator<>), _resource.Type)} {new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)}.GetAsyncEnumerator({typeof(CancellationToken)} cancellationToken)");
            using (_writer.Scope())
            {
                _writer.Line($"return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);");
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{typeof(Azure.Core.ResourceIdentifier)}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
        }
    }
}
