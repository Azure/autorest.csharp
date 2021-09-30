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

        protected virtual Type BaseClass => typeof(ArmResource);

        protected override string ContextProperty => "this";

        protected override TypeProvider This => _resource;
        protected override CSharpType TypeOfThis => _resource.Type;
        private bool IsSingleton => _resource.IsSingleton;

        public ResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context) : base(writer, context)
        {
            _resource = resource;
            _resourceData = resource.ResourceData;
        }

        public override void Write()
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
                _writer.Line($"{GetRestClientVariableName(client)} = new {client.Type.Name}({ClientDiagnosticsField}, {PipelineProperty}, {ClientOptionsProperty}{subscriptionParamString}, {BaseUriField});");
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

            // write delete method
            WriteDeleteMethod(_resource.DeleteOperation, true);
            WriteDeleteMethod(_resource.DeleteOperation, false);

            if (_isITaggableResource)
            {
                WriteAddTagMethod(true);
                WriteAddTagMethod(false);
                WriteSetTagsMethod(true);
                WriteSetTagsMethod(false);
                WriteRemoveTagMethod(true);
                WriteRemoveTagMethod(false);
            }

            // write update method
            WriteUpdateMethod(_resource.UpdateOperation, true);
            WriteUpdateMethod(_resource.UpdateOperation, false);

            // write post method
            WritePostMethod(_resource.PostOperation, true);
            WritePostMethod(_resource.PostOperation, false);

            // 1. Listing myself at parent scope -> on the container named list
            // 2. Listing myself at ancestor scope -> extension method if the ancestor is not in this RP, or follow #3 by listing myself as the children of the ancestor in the operations of the ancestor
            // 3. Listing children (might be resource or not) -> on the operations

            // write all the methods that should belong to this resouce
            foreach (var clientOperation in _resource.ClientOperations)
            {
                WriteMethod(clientOperation, clientOperation.Name, true);
                WriteMethod(clientOperation, clientOperation.Name, false);
            }

            // TODO -- what does this used for?
            //foreach (var kv in mergedMethods)
            //{
            //    WriteLRO(kv.Value.OrderBy(m => m.Name.Length).First(), kv.Key, kv.Value);
            //}
        }

        protected void WriteGetMethod(MgmtClientOperation operation, bool async)
        {
            WriteNormalMethod(operation, "Get", async, shouldThrowExceptionWhenNull: true);
        }

        protected void WriteDeleteMethod(MgmtClientOperation? operation, bool async)
        {
            if (operation == null)
                return;
            WriteLROMethod(operation, "Delete", async);
        }

        private void WriteUpdateMethod(MgmtClientOperation? operation, bool async)
        {
            if (operation == null)
                return;
            WriteMethod(operation, "Update", async);
        }

        private void WritePostMethod(MgmtClientOperation? operation, bool async)
        {
            if (operation == null)
                return;
            WriteMethod(operation, operation.Name, async);
        }

        protected override CSharpType? WrapResourceDataType(CSharpType? returnType)
        {
            if (IsResourceDataType(returnType))
                return _resource.Type;

            return returnType;
        }

        protected override bool IsResourceDataType(CSharpType? returnType)
        {
            return _resourceData.Type.Equals(returnType);
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
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
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
            _writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName("Get", async)}( ");
            WriteArguments(_writer, parameterMapping, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return {typeof(Response)}.FromValue(new {TypeOfThis}(this, originalResponse.Value), originalResponse.GetRawResponse());");
        }

        protected override void WriteChildResourceEntries()
        {
            foreach (var resource in Context.Library.ArmResources)
            {
                var parents = resource.Parent(Context);
                if (!parents.Contains(This))
                    continue;

                _writer.Line();
                _writer.Line($"#region {resource.ResourceName}");
                if (resource.IsSingleton)
                    WriteSingletonResourceEntry(resource, resource.SingletonResourceIdSuffix!);
                else
                    WriteResourceContainerEntry(resource);
                _writer.Line($"#endregion");
            }
        }

        private void WriteResourceContainerEntry(Resource resource)
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

        private void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {_resource.ResourceName}.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            using (_writer.Scope($"public {resource.Type} Get{resource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {resource.Type.Name}(this, Id + \"/{singletonResourceIdSuffix}\");");
            }
        }
    }
}
