// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using ResourceType = AutoRest.CSharp.Mgmt.Models.ResourceType;

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
    internal class ResourceContainerWriter : ResourceWriter
    {
        private ResourceContainer _resourceContainer;

        protected override Type BaseClass => typeof(ArmContainer);

        protected override string ContextProperty => "Parent";

        protected override MgmtTypeProvider This => _resourceContainer;

        protected override string BranchIdVariableName => "Id";

        public ResourceContainerWriter(CodeWriter writer, ResourceContainer resourceContainer, BuildContext<MgmtOutputLibrary> context)
            : base(writer, resourceContainer.Resource, context)
        {
            _resourceContainer = resourceContainer;
        }

        public override void Write()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resourceContainer.Description}");
                _writer.Line($"{_resourceContainer.Declaration.Accessibility} partial class {TypeNameOfThis} : {BaseClass}");
                using (_writer.Scope())
                {
                    WriteFields();
                    WriteCtors();
                    // TODO: this is a workaround to allow resource container to accept multiple parent resource types
                    // Eventually we can change ValidResourceType to become ValidResourceTypes and rewrite the base Validate().
                    WriteValidate();
                    WriteProperties();
                    WriteMethods();

                    WriteBuilders();
                }
            }
        }

        protected override void WriteFields()
        {
            WriteFields(_writer, _resourceContainer.RestClients);
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
            using (_writer.Scope($"internal {TypeNameOfThis}({typeof(ArmResource)} parent) : base(parent)"))
            {
                _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                WriteRestClientAssignments();
            }
        }

        private void WriteValidate()
        {
            var allPossibleTypes = _resourceContainer.ResourceTypes.SelectMany(p => p.Value).Distinct();
            if (allPossibleTypes.Count() == 1)
                return;
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Verify that the input resource Id is a valid container for this type.");
            _writer.WriteXmlDocumentationParameter("identifier", $"The input resource Id to check.");
            _writer.Line($"protected override void ValidateResourceType(ResourceIdentifier identifier)");
            using (_writer.Scope())
            {
            }
        }

        protected override void WriteProperties()
        {
            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            //if (!resourceType.Contains(".ResourceType"))
            //{
            //    resourceType = $"\"{resourceType}\"";
            //}

            var allPossibleTypes = _resourceContainer.ResourceTypes.SelectMany(p => p.Value).Distinct();

            FormattableString validResourceType;
            if (allPossibleTypes.Count() == 1)
                validResourceType = GetResourceTypeExpression(allPossibleTypes.First());
            else
                validResourceType = $"{typeof(ResourceIdentifier)}.RootResourceIdentifier.ResourceType";
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
            _writer.Line($"protected override {typeof(Azure.ResourceManager.ResourceType)} ValidResourceType => {validResourceType};");
        }

        protected override void WriteMethods()
        {
            _writer.Line();
            _writer.LineRaw($"// Container level operations.");

            if (_resourceContainer.CreateOperation != null)
            {
                WriteCreateOrUpdateMethod(_resourceContainer.CreateOperation, false);
                WriteCreateOrUpdateMethod(_resourceContainer.CreateOperation, true);
            }

            if (_resourceContainer.GetOperation != null)
            {
                WriteGetMethod(_resourceContainer.GetOperation, false);
                WriteGetMethod(_resourceContainer.GetOperation, true);
                WriteGetIfExists(_resourceContainer.GetOperation, false);
                WriteGetIfExists(_resourceContainer.GetOperation, true);
                WriteCheckIfExists(_resourceContainer.GetOperation, false);
                WriteCheckIfExists(_resourceContainer.GetOperation, true);
            }

            // TODO: Add back code with refactored base method as in WriteCreateOrUpdateVariants
            // if (_resourceContainer.PutByIdMethod != null)
            // {
            //     WriteCreateByIdVariants(_resourceContainer.PutByIdMethod);
            // }

            // if (_resourceContainer.GetByIdMethod?.RestClientMethod != null && _resourceContainer.GetMethod?.RestClientMethod != _resourceContainer.GetByIdMethod.RestClientMethod)
            // {
            //     WriteGetByIdVariants(_resourceContainer.GetByIdMethod.RestClientMethod);
            // }

            // write all the methods that should belong to this resouce container
            foreach (var clientOperation in _resourceContainer.ClientOperations)
            {
                WriteMethod(clientOperation, false);
                WriteMethod(clientOperation, true);
            }

            var parents = _resource.Parent(Context);
            if (parents.Contains(Context.Library.ResourceGroupExtensions) || parents.Contains(Context.Library.SubscriptionExtensions))
            {
                WriteListAsGenericResource(false);
                WriteListAsGenericResource(true);
            }
        }

        private void WriteCheckIfExists(MgmtClientOperation clientOperation, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Tries to get details for this resource from the service.");

            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            WriteContainerMethodScope(typeof(bool).WrapResponse(async), "CheckIfExists", methodParameters, writer =>
            {
                WriteCheckIfExistsBody(methodParameters, async);
            }, async, isOverride: false);
        }

        private void WriteCheckIfExistsBody(IEnumerable<Parameter> passThruParameters, bool async)
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

            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            WriteContainerMethodScope(_resource.Type.WrapResponse(async), "GetIfExists", methodParameters, writer =>
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
            writer.Line($"\t? Response.FromValue<{_resource.Type.Name}>(null, response.GetRawResponse())");
            writer.Line($"\t: Response.FromValue(new {_resource.Type.Name}(this, response.Value), response.GetRawResponse());");
        }

        /// <summary>
        /// Write some scaffolding for container operation methods.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="methodName">Method name in its sync form.</param>
        /// <param name="methodParameters">The "pass-through" parameters, must not contain cancellationToken.</param>
        /// <param name="inner">Main logic of the method writer.</param>
        /// <param name="async"></param>
        /// <param name="isOverride"></param>
        /// <param name="catch404"></param>
        private void WriteContainerMethodScope(CSharpType returnType, string methodName, IReadOnlyList<Parameter> methodParameters,
            CodeWriterDelegate inner, bool async, bool isOverride = false, bool catch404 = false)
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
                using (WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{methodName}"), ClientDiagnosticsField, catch404))
                {
                    inner(_writer);
                }
            }
        }

        private void WriteListAsGenericResource(bool async)
        {
            const string syncMethodName = "GetAllAsGenericResources";
            var listScope = _resource.Parent(Context).Contains(Context.Library.ResourceGroupExtensions) ? "resource group" : "subscription";
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
                using (WriteDiagnosticScope(_writer, new Diagnostic($"{_resourceContainer.Type.Name}.{syncMethodName}"), ClientDiagnosticsField))
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resource.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    if (listScope.Equals("resource group"))
                    {
                        _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}({ContextProperty} as {typeof(ResourceGroup)}, filters, expand, top, cancellationToken);");
                    }
                    else
                    {
                        _writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}({ContextProperty} as {typeof(Subscription)}, filters, expand, top, cancellationToken);");
                    }
                }
            }
        }

        private void WriteBuilders()
        {
            _writer.Line();
            _writer.Line($"// Builders.");
            _writer.LineRaw($"// public ArmBuilder<{typeof(ResourceIdentifier)}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
        }
    }
}
