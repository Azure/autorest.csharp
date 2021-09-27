// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Operation = AutoRest.CSharp.Input.Operation;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;
using ResourceType = Azure.ResourceManager.ResourceType;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        protected Resource _resource;
        protected ResourceData _resourceData;
        private bool _isITaggableResource = false;
        private bool _isDeletableResource = false;

        protected virtual Type BaseClass => typeof(ArmResource);

        protected override string ContextProperty => "this";

        protected virtual CSharpType TypeOfThis => _resource.Type;
        protected override string TypeNameOfThis => TypeOfThis.Name;
        private bool IsSingleton => _resource.IsSingleton;

        public ResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context) : base(writer, context)
        {
            _resource = resource;
            _resourceData = resource.ResourceData;
        }

        public virtual void Write()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resource.Description}");
                _writer.Line($"{_resource.Declaration.Accessibility} partial class {TypeNameOfThis}: {BaseClass}");

                if (_resource.GetOperation == null)
                    ErrorHelpers.ThrowError($@"Get operation is missing for '{TypeOfThis.Name}' resource under '{string.Join(", ", _resource.RequestPaths)}'.
Check the swagger definition, and use 'request-path-to-resource' or 'request-path-is-non-resource' directive to specify the correct resource if necessary.");

                CSharpType inheritType = new CSharpType(typeof(TrackedResource));
                if (_resourceData.Inherits != null && _resourceData.Inherits.Name == inheritType.Name)
                {
                    _isITaggableResource = true;
                }

                if (_resource.DeleteOperation != null)
                {
                    _isDeletableResource = true;
                }

                using (_writer.Scope())
                {
                    WriteFields();
                    WriteCtors();
                    WriteProperties();
                    WriteMethods();

                    // write children
                    WriteChildResourceEntries();
                }
            }
        }

        protected virtual void WriteFields()
        {
            WriteFields(_writer, _resource.RestClients);
            _writer.Line($"private readonly {_resourceData.Type} _data;");
        }

        protected virtual void WriteCtors()
        {
            _writer.Line();
            // write protected default constructor
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{TypeOfThis}\"/> class for mocking.");
            using (_writer.Scope($"protected {TypeOfThis.Name}()"))
            { }

            // write "resource + id" constructor
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref = \"{TypeOfThis.Name}\"/> class.");
            _writer.WriteXmlDocumentationParameter("options", $"The client parameters to use in these operations.");
            _writer.WriteXmlDocumentationParameter("resource", $"The resource that is the target of operations.");
            // inherits the default constructor when it is not a resource
            var baseConstructorCall = _resourceData.IsResource() ? $" : base(options, resource.Id)" : string.Empty;
            using (_writer.Scope($"internal {TypeOfThis.Name}({typeof(ArmResource)} options, {_resourceData.Type} resource){baseConstructorCall}"))
            {
                _writer.Line($"HasData = true;");
                _writer.Line($"_data = resource;");
                if (IsSingleton)
                    _writer.Line($"Parent = options;");
                _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                WriteRestClientAssignments();
            }

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class.");
            _writer.WriteXmlDocumentationParameter("options", $"The client parameters to use in these operations.");
            _writer.WriteXmlDocumentationParameter("id", $"The identifier of the resource that is the target of operations.");
            using (_writer.Scope($"internal {TypeOfThis.Name}({typeof(ArmResource)} options, {typeof(ResourceIdentifier)} id) : base(options, id)"))
            {
                if (IsSingleton)
                    _writer.Line($"Parent = options;");
                _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                WriteRestClientAssignments();
            }

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class.");
            _writer.WriteXmlDocumentationParameter("clientOptions", $"The client options to build client context.");
            _writer.WriteXmlDocumentationParameter("credential", $"The credential to build client context.");
            _writer.WriteXmlDocumentationParameter("uri", $"The uri to build client context.");
            _writer.WriteXmlDocumentationParameter("pipeline", $"The pipeline to build client context.");
            _writer.WriteXmlDocumentationParameter("id", $"The identifier of the resource that is the target of operations.");
            using (_writer.Scope($"internal {TypeOfThis.Name}({typeof(ArmClientOptions)} clientOptions, {typeof(TokenCredential)} credential, {typeof(Uri)} uri, {typeof(HttpPipeline)} pipeline, {typeof(ResourceIdentifier)} id) : base(clientOptions, credential, uri, pipeline, id)"))
            {
                _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                WriteRestClientAssignments();
            }
        }

        protected void WriteRestClientAssignments()
        {
            // write assignment statements of the rest clients of this resource
            foreach (var client in _resource.RestClients)
            {
                var subscriptionParamString = client.Parameters.Any(p => p.Name.Equals("subscriptionId")) ? ", Id.SubscriptionId" : string.Empty;
                _writer.Line($"{GetRestClientFieldName(client)} = new {client.Type.Name}({ClientDiagnosticsField}, {PipelineProperty}, {ClientOptionsProperty}{subscriptionParamString}, {BaseUriField});");
            }
        }

        protected virtual void WriteProperties()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");
            // TODO -- what should we do if we have multiple types? or it contains variables?
            // NOTE: we are possible to test if this resource type contains variables using `IsContant` property
            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{_resource.ResourceTypes.Values.First()}\";");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the valid resource type for the operations");
            _writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => ResourceType;");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets whether or not the current instance has data.");
            _writer.Line($"public virtual bool HasData {{ get; }}");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the data representing this Feature.");
            _writer.WriteXmlDocumentationException(typeof(InvalidOperationException), $"Throws if there is no data loaded in the current instance.");
            using (_writer.Scope($"public virtual {_resourceData.Type} Data"))
            {
                using (_writer.Scope($"get"))
                {
                    _writer.Line($"if (!HasData)");
                    _writer.Line($"throw new {typeof(InvalidOperationException)}(\"The current instance does not have data, you must call Get first.\");");
                    _writer.Line($"return _data;");
                }
            }

            if (IsSingleton)
            {
                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Gets the parent resource of this resource.");
                _writer.Line($"public {typeof(ArmResource)} Parent {{ get; }}");
            }
        }

        protected virtual void WriteMethods()
        {
            _writer.Line();
            // write get method
            WriteGetMethod(_resource.GetOperation!, true);
            WriteGetMethod(_resource.GetOperation!, false);

            WriteListAvailableLocationsMethod(true);
            WriteListAvailableLocationsMethod(false);

            if (_isDeletableResource)
            {
                // write delete method
                WriteDeleteMethod(_resource.DeleteOperation!, true);
                WriteDeleteMethod(_resource.DeleteOperation!, false);
            }

            if (_isITaggableResource)
            {
                WriteAddTagMethod(true);
                WriteAddTagMethod(false);
                WriteSetTagsMethod(true);
                WriteSetTagsMethod(false);
                WriteRemoveTagMethod(true);
                WriteRemoveTagMethod(false);
            }

            // 1. Listing myself at parent scope -> on the container named list
            // 2. Listing myself at ancestor scope -> extension method if the ancestor is not in this RP, or follow #3 by listing myself as the children of the ancestor in the operations of the ancestor
            // 3. Listing children (might be resource or not) -> on the operations

            // write all the methods that should belong to this resouce
            foreach (var clientOperation in _resource.ClientOperations)
            {
                // we need to identify this operation belongs to which category: NormalMethod, LROMethod or PagingMethod
                if (clientOperation.IsLongRunningOperation())
                {
                    // this is a long-running operation
                    // TODO -- how to determine a name for this?
                    WriteLROMethod(clientOperation, clientOperation.First().Name, true);
                    WriteLROMethod(clientOperation, clientOperation.First().Name, false);
                }
                else if (clientOperation.IsPagingOperation(Context))
                {
                    // this is a paging operation
                    // TODO -- how to determine a name for this?
                    WritePagingMethod(clientOperation, clientOperation.First().Name, true);
                    WritePagingMethod(clientOperation, clientOperation.First().Name, false);
                }
                else
                {
                    // this is a normal operation
                    // TODO -- how to determine a name for this?
                    WriteNormalMethod(clientOperation, clientOperation.First().Name, true);
                    WriteNormalMethod(clientOperation, clientOperation.First().Name, false);
                }
            }

            // TODO -- what does this used for?
            //foreach (var kv in mergedMethods)
            //{
            //    WriteLRO(kv.Value.OrderBy(m => m.Name.Length).First(), kv.Key, kv.Value);
            //}
        }

        private void WriteGetMethod(MgmtClientOperation operation, bool async)
        {
            WriteNormalMethod(operation, "Get", async);
        }

        private void WriteDeleteMethod(MgmtClientOperation operation, bool async)
        {
            WriteLROMethod(operation, "Delete", async);
        }

        protected void WritePagingMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Method.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.First().Method.Description}");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");

            // TODO -- find a better way to get this type
            var itemType = clientOperation.First(restOperation => restOperation.IsPagingOperation(Context)).GetPagingMethod(Context)!.PagingResponse.ItemType;
            _writer.WriteXmlDocumentationReturns($"{(async ? "An async" : "A")} collection of <see cref=\"{itemType.Name}\" /> that may take multiple service requests to iterate over.");

            var returnType = itemType.WrapPageable(async);

            _writer.Append($"public virtual {returnType} {CreateMethodName(methodName, async)}(");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (_writer.Scope())
            {
                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WritePagingMethodBody(_writer, itemType, diagnostic, operationMappings, parameterMappings, async);
            }
        }

        private void WritePagingMethodBody(CodeWriter writer, CSharpType itemType, Diagnostic diagnostic,
            IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // we need to write multiple branches for a paging method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WritePagingMethodBranch(writer, itemType, diagnostic, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch GET not supported yet");
            }
        }

        private void WritePagingMethodBranch(CodeWriter writer, CSharpType resourceType, Diagnostic diagnostic, MgmtRestOperation operation,
            IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var pagingMethod = operation.GetPagingMethod(Context)!;
            var returnType = new CSharpType(typeof(Page<>), resourceType).WrapAsync(async);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            using (writer.Scope($"{GetAsyncKeyword(async)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    WritePageFunctionBody(writer, pagingMethod, operation, parameterMappings, async, false);
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (writer.Scope($"{GetAsyncKeyword(async)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                    {
                        WritePageFunctionBody(writer, pagingMethod, operation, parameterMappings, async, true);
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void WritePageFunctionBody(CodeWriter writer, PagingMethod pagingMethod, MgmtRestOperation operation,
            IEnumerable<ParameterMapping> parameterMappings, bool isAsync, bool isNextPageFunc)
        {
            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";

            writer.Append($"var response = {GetAwait(isAsync)} {GetRestClientFieldName(operation.RestClient)}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, isAsync)}({GetNextLink(isNextPageFunc)}");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            // only when we are listing ourselves, we use Select to convert XXXResourceData to XXXResource
            var converter = string.Empty;
            // TODO -- implement converter
            //if (!string.IsNullOrEmpty(converter.ToString()))
            //{
            //    writer.UseNamespace("System.Linq");
            //}
            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}{converter}, {continuationTokenText}, response.GetRawResponse());");
        }

        protected void WriteNormalMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Method.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.First().Method.Description}");
            foreach (Parameter parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            var responseType = TypeOfThis.WrapResponse(async);
            _writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName(methodName, async)}(");

            foreach (Parameter parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);
                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField,
                    writer => WriteNormalMethodBody(writer, operationMappings, parameterMappings, async));
                _writer.Line();
            }
        }

        private void WriteNormalMethodBody(CodeWriter writer, IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // we need to write multiple branches for a normal method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteNormalMethodBranch(writer, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteNormalMethodBranch(CodeWriter writer, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            writer.Append($"var response = {GetAwait(async)} ");
            writer.Append($"{GetRestClientFieldName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteGetResponse(writer, TypeOfThis, async);
        }


        protected void WriteLROMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Method.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();

            // we can only make this an SLRO when all of the methods are not really long
            bool isSLRO = !clientOperation.IsLongRunningReallyLong();
            methodName = isSLRO ? methodName : $"Start{methodName}";

            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.First().Method.Description}");
            foreach (Parameter parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(methodParameters);
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = GetLROObjectType(clientOperation.First().Operation, async);
            var responseType = lroObjectType.WrapAsync(async);
            _writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName(methodName, async)}(");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }

            var defaultWaitForCompletion = isSLRO ? "true" : "false";
            _writer.Line($"bool waitForCompletion = {defaultWaitForCompletion}, {typeof(CancellationToken)} cancellationToken = default)");

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField,
                    writer => WriteLROMethodBody(writer, lroObjectType, operationMappings, parameterMappings, async));
                _writer.Line();
            }
        }

        private void WriteLROMethodBody(CodeWriter writer, CSharpType lroObjectType, IDictionary<RequestPath, MgmtRestOperation> operationMapping,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // TODO -- we need to write multiple branches for a LRO operation
            if (operationMapping.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMapping.Keys.First();
                WriteLROMethodBranch(writer, lroObjectType, operationMapping[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch LRO not supported yet");
            }
        }

        private void WriteLROMethodBranch(CodeWriter writer, CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            writer.Append($"var response = {GetAwait(async)} ");
            writer.Append($"{GetRestClientFieldName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(writer, parameterMapping);
            writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(writer, lroObjectType, operation, parameterMapping, async);
        }

        private CSharpType GetLROObjectType(Operation operation, bool async)
        {
            var lroObjectType = operation.IsLongRunning
                ? Context.Library.GetLongRunningOperation(operation).Type
                : Context.Library.GetNonLongRunningOperation(operation).Type;
            return lroObjectType;
        }

        private void WriteListAvailableLocationsMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"A collection of locations that may take multiple service requests to iterate over.");

            var responseType = new CSharpType(typeof(IEnumerable<Location>)).WrapAsync(async);

            using (_writer.Scope($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("GetAvailableLocations", async)}({typeof(CancellationToken)} cancellationToken = default)"))
            {
                _writer.Line($"return {GetAwait(async)} {CreateMethodName("ListAvailableLocations", async)}(ResourceType, cancellationToken){GetConfigureAwait(async)};");
            }
        }

        private void WriteAddTagMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Add a tag to the current resource.");
            _writer.WriteXmlDocumentationParameter("key", $"The key for the tag.");
            _writer.WriteXmlDocumentationParameter("value", $"The value for the tag.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"The updated resource with the tag added.");

            var responseType = TypeOfThis.WrapResponse(async);

            _writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("AddTag", async)}(string key, string value, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                using (_writer.Scope($"if (string.IsNullOrWhiteSpace(key))"))
                {
                    _writer.Line($"throw new {typeof(ArgumentNullException)}($\"{{nameof(key)}} provided cannot be null or a whitespace.\", nameof(key));");
                }
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.AddTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField, _writer =>
                {
                    _writer.Append($"var originalTags = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue[key] = value;");
                    WriteTaggableCommonMethod(async);
                });
                _writer.Line();
            }
        }

        private void WriteSetTagsMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Replace the tags on the resource with the given set.");
            _writer.WriteXmlDocumentationParameter("tags", $"The set of tags to use as replacement.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"The updated resource with the tags replaced.");

            var responseType = TypeOfThis.WrapResponse(async);

            _writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("SetTags", async)}({typeof(IDictionary<string, string>)} tags, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                using (_writer.Scope($"if (tags == null)"))
                {
                    _writer.Line($"throw new {typeof(ArgumentNullException)}($\"{{nameof(tags)}} provided cannot be null.\", nameof(tags));");
                }
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.SetTags", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField, _writer =>
                {
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Delete", async)}(cancellationToken: cancellationToken){GetConfigureAwait(async)};");
                    _writer.Append($"var originalTags  = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);");
                    WriteTaggableCommonMethod(async);
                });
                _writer.Line();
            }
        }

        private void WriteRemoveTagMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Removes a tag by key from the resource.");
            _writer.WriteXmlDocumentationParameter("key", $"The key of the tag to remove.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"The updated resource with the tag removed.");

            var responseType = TypeOfThis.WrapResponse(async);

            _writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("RemoveTag", async)}(string key, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                using (_writer.Scope($"if (string.IsNullOrWhiteSpace(key))"))
                {
                    _writer.Line($"throw new {typeof(ArgumentNullException)}($\"{{nameof(key)}} provided cannot be null or a whitespace.\", nameof(key));");
                }
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.RemoveTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField, _writer =>
                {
                    _writer.Append($"var originalTags = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue.Remove(key);");
                    WriteTaggableCommonMethod(async);
                });
                _writer.Line();
            }
        }

        private void WriteTaggableCommonMethod(bool async)
        {
            _writer.Line($"{GetAwait(async)} TagContainer.{CreateMethodName("CreateOrUpdate", async)}(originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(async)};");
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = _resource.GetOperation.ToDictionary(
                clientOperation => clientOperation.ContextualPath,
                clientOperation => clientOperation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Method.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we need to write multiple branches for a normal method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WriteTaggableCommonMethodBranch(operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch normal method not supported yet");
            }
        }

        private void WriteTaggableCommonMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var originalResponse = {GetAwait(async)} ");
            // TODO -- we need to implement the branches here as well
            //var pathParamNames = GetPathParametersName(_resource.GetMethod!.RestClientMethod, _resource.OperationGroup, Context).ToList();
            _writer.Append($"{GetRestClientFieldName(operation.RestClient)}.{CreateMethodName("Get", async)}( ");
            WriteArguments(_writer, parameterMapping, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return {typeof(Response)}.FromValue(new {TypeOfThis}(this, originalResponse.Value), originalResponse.GetRawResponse());");
        }

        private void WriteChildResourceEntries()
        {
            foreach (var resource in Context.Library.ArmResources)
            {
                var parents = resource.Parent(Context);
                if (!parents.Contains(_resource))
                    continue;

                if (resource.IsSingleton)
                    WriteChildSingletonResourceEntry(resource);
                else
                    WriteChildNonSingletonResourceEntry(resource);
            }
        }

        private void WriteChildNonSingletonResourceEntry(Resource resource)
        {
            var container = resource.ResourceContainer;
            if (container == null)
                throw new InvalidOperationException($"We are about to write a {resource.ResourceName} resource entry in {_resource.ResourceName} resource, but it does not have a container, this cannot happen");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets a list of {container.ResourceName.ToPlural()} in the {_resource.ResourceName}.");
            _writer.WriteXmlDocumentationReturns($"An object representing collection of {container.ResourceName.ToPlural()} and their operations over a {_resource.ResourceName}.");
            using (_writer.Scope($"public {container.Type} Get{container.ResourceName.ToPlural()}()"))
            {
                _writer.Line($"return new {container.Type}(this);");
            }
        }

        private void WriteChildSingletonResourceEntry(Resource singletonResource)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {singletonResource.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{singletonResource.Type.Name}\" /> object.");
            using (_writer.Scope($"public {singletonResource.Type} Get{singletonResource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {singletonResource.Type.Name}(this, Id + \"/{singletonResource.SingletonResourceIdSuffix!}\");");
            }
        }
    }
}
