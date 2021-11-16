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

        protected override string BranchIdVariableName => "Id.Parent";

        private bool IsSingleton => _resource.IsSingleton;

        public ResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context) : base(writer, resource, context)
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
                    throw new ErrorHelpers.ErrorException($@"Get operation is missing for '{TypeOfThis.Name}' resource under '{string.Join(", ", _resource.RequestPaths)}'.
Check the swagger definition, and use 'request-path-to-resource-name' or 'request-path-is-non-resource' directive to specify the correct resource if necessary.");

                var inheritType = new CSharpType(typeof(TrackedResource));
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
            WriteFields(_writer, This.RestClients);
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
            using (_writer.Scope($"internal {TypeOfThis.Name}({typeof(ArmResource)} options, {_resourceData.Type} resource) : base(options, resource.Id)"))
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
            foreach (var client in This.RestClients)
            {
                var subscriptionParamString = client.Parameters.Any(p => p.Name.Equals("subscriptionId")) ? ", Id.SubscriptionId" : string.Empty;
                _writer.Line($"{GetRestClientVariableName(client)} = new {client.Type.Name}({ClientDiagnosticsField}, {PipelineProperty}, {ClientOptionsProperty}{subscriptionParamString}, {BaseUriField});");
            }
        }

        protected virtual void WriteProperties()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{_resource.ResourceType}\";");
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

            if (_resource.IsSingleton)
            {
                // only write create method when this is a singleton
                WriteCreateOrUpdateMethod(_resource.CreateOperation, true);
                WriteCreateOrUpdateMethod(_resource.CreateOperation, false);
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

            // write update method
            WriteUpdateMethod(_resource.UpdateOperation, true);
            WriteUpdateMethod(_resource.UpdateOperation, false);

            // 1. Listing myself at parent scope -> on the collection named list
            // 2. Listing myself at ancestor scope -> extension method if the ancestor is not in this RP, or follow #3 by listing myself as the children of the ancestor in the operations of the ancestor
            // 3. Listing children (might be resource or not) -> on the operations

            // write all the methods that should belong to this resouce
            foreach (var clientOperation in _resource.ClientOperations)
            {
                WriteMethod(clientOperation, true);
                WriteMethod(clientOperation, false);
            }

            // TODO -- what does this used for?
            //foreach (var kv in mergedMethods)
            //{
            //    WriteLRO(kv.Value.OrderBy(m => m.Name.Length).First(), kv.Key, kv.Value);
            //}
        }

        protected override Models.ResourceType GetBranchResourceType(RequestPath branch)
        {
            return branch.ParentRequestPath(Context).GetResourceType(Config);
        }

        protected void WriteGetMethod(MgmtClientOperation operation, bool async)
        {
            WriteNormalMethod(operation, async, shouldThrowExceptionWhenNull: true);
        }

        protected void WriteCreateOrUpdateMethod(MgmtClientOperation? operation, bool async)
        {
            if (operation == null)
                return;
            WriteLROMethod(operation, async);
        }

        protected void WriteDeleteMethod(MgmtClientOperation? operation, bool async)
        {
            if (operation == null)
                return;
            WriteLROMethod(operation, async);
        }

        private void WriteUpdateMethod(MgmtClientOperation? operation, bool async)
        {
            if (operation == null)
                return;
            WriteMethod(operation, async);
        }

        protected override CSharpType? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation))
                return type;

            return _resource.Type;
        }

        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation clientOperation)
        {
            return _resourceData.Type.Equals(type);
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
                using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField))
                {
                    _writer.Append($"var originalTags = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue[key] = value;");
                    WriteTaggableCommonMethod(async);
                }
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
                using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField))
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
                }
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

                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.RemoveTag");
                using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField))
                {
                    _writer.Append($"var originalTags = ");
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    _writer.Line($"originalTags.Value.Data.Properties.TagsValue.Remove(key);");
                    WriteTaggableCommonMethod(async);
                }
                _writer.Line();
            }
        }

        private void WriteTaggableCommonMethod(bool async)
        {
            _writer.Line($"{GetAwait(async)} TagResource.{CreateMethodName("CreateOrUpdate", async)}(originalTags.Value.Data, cancellationToken: cancellationToken){GetConfigureAwait(async)};");
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = _resource.GetOperation.ToDictionary(
                clientOperation => clientOperation.ContextualPath,
                clientOperation => clientOperation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context, IdVariableName));
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
            _writer.Append($"{GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}( ");
            WriteArguments(_writer, parameterMapping, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return {typeof(Response)}.FromValue(new {TypeOfThis}(this, originalResponse.Value), originalResponse.GetRawResponse());");
        }

        protected override void WriteResourceCollectionEntry(Resource resource)
        {
            var collection = resource.ResourceCollection;
            if (collection == null)
                throw new InvalidOperationException($"We are about to write a {resource.Type.Name} resource entry in {_resource.Type.Name} resource, but it does not have a collection, this cannot happen");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets a collection of {resource.Type.Name.ToPlural()} in the {_resource.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"An object representing collection of {resource.Type.Name.ToPlural()} and their operations over a {_resource.Type.Name}.");
            using (_writer.Scope($"public {collection.Type.Name} Get{resource.Type.Name.ToPlural()}()"))
            {
                _writer.Line($"return new {collection.Type.Name}(this);");
            }
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {_resource.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type}\" /> object.");
            using (_writer.Scope($"public {resource.Type.Name} Get{resource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {resource.Type.Name}(this, Id + \"/{singletonResourceIdSuffix}\");");
            }
        }
    }
}
