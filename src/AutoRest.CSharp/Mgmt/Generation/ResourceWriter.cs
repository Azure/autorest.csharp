// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Output.Models;
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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;

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

        protected override string ArmClientReference => "ArmClient";

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
                if (_resourceData.Inherits != null && (_resourceData.Inherits.Name == inheritType.Name || _resourceData.Inherits.Name == "TrackedResourceExtended")) // TODO: use type.Name after upgrading resourcemanager version
                {
                    _isITaggableResource = true;
                }

                using (_writer.Scope())
                {
                    WriteStaticMethods();
                    WriteFields();
                    WriteCtors();
                    WriteProperties();
                    WriteMethods();

                    // write children
                    WriteChildResourceEntries();
                }
            }
        }

        private void WriteStaticMethods()
        {
            WriteCreateResourceIdentifierMethods();
            _writer.Line();
        }

        private void WriteCreateResourceIdentifierMethods()
        {
            // Right now, `RequestPaths` contains only one path. But in the future when we start to support multiple context path per resource,
            // we should implement the logic to avoid overload conflicts (e.g. /{A}/{B}/{C} v.s. /{D}/{E}/{F}, both context path contains 3 parameters).
            foreach (var requestPath in _resource.RequestPaths)
            {
                if (requestPath.Count == 0)
                    continue;
                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Generate the resource identifier of a <see cref=\"{TypeOfThis}\"/> instance.");
                var parameterList = string.Join(", ", requestPath.Where(segment => segment.IsReference).Select(segment => $"string {segment.ReferenceName}"));
                using (_writer.Scope($"public static {typeof(Azure.Core.ResourceIdentifier)} CreateResourceIdentifier({parameterList})"))
                {
                    // Storage has inconsistent definitions:
                    // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L58
                    // - https://github.com/Azure/azure-rest-api-specs/blob/719b74f77b92eb1ec3814be6c4488bcf6b651733/specification/storage/resource-manager/Microsoft.Storage/stable/2021-04-01/blob.json#L146
                    // so here we have to use `Seqment.BuildSerializedSegments` instead of `RequestPath.SerializedPath` which could be from `RestClientMethod.Operation.GetHttpPath`
                    // If first segment is "{var}", then we should not add leading "/". Instead, we should let callers to specify, e.g. "{scope}/providers/Microsoft.Resources/..." v.s. "/subscriptions/{subscriptionId}/..."
                    _writer.Line($"var resourceId = $\"{Segment.BuildSerializedSegments(requestPath, requestPath.First().IsConstant)}\";");
                    _writer.Line($"return new {typeof(Azure.Core.ResourceIdentifier)}(resourceId);");
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
            var mockingConstructor = new MethodSignature(
                name: TypeOfThis.Name,
                description: $"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class for mocking.",
                modifiers: "protected",
                parameters: new Parameter[0]);
            _writer.WriteMethodDocumentation(mockingConstructor);
            using (_writer.WriteMethodDeclaration(mockingConstructor))
            { }

            _writer.Line();
            // write "resource + ResourceData" constructor
            var resourceDataConstructor = new MethodSignature(
                name: TypeOfThis.Name,
                description: $"Initializes a new instance of the <see cref = \"{TypeOfThis.Name}\"/> class.",
                modifiers: "internal",
                parameters: new[] { Resource.ArmClientParameter, _resource.ResourceDataParameter },
                baseMethod: new MethodSignature(
                    name: TypeOfThis.Name,
                    description: null,
                    modifiers: "protected",
                    parameters: new[]
                    {
                        Resource.ArmClientParameter,
                        new ParameterInvocation(Resource.ResourceIdentifierParameter, _resource.ResourceDataIdExpression(w => w.Append($"{_resource.ResourceDataParameter.Name}")))
                    }),
                useBaseKeyword: false);
            _writer.WriteMethodDocumentation(resourceDataConstructor);
            using (_writer.WriteMethodDeclaration(resourceDataConstructor))
            {
                _writer.Line($"HasData = true;");
                _writer.Line($"_data = {_resource.ResourceDataParameter.Name};");
            }

            _writer.Line();
            // write "armClient + id" constructor
            var clientOptionsConstructor = new MethodSignature(
                name: TypeOfThis.Name,
                description: $"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class.",
                modifiers: "internal",
                parameters: new[] { Resource.ArmClientParameter, Resource.ResourceIdentifierParameter },
                baseMethod: new MethodSignature(
                    name: TypeOfThis.Name,
                    description: null,
                    modifiers: "protected",
                    parameters: new[] { Resource.ArmClientParameter, Resource.ResourceIdentifierParameter })
                );

            _writer.WriteMethodDocumentation(clientOptionsConstructor);
            using (_writer.WriteMethodDeclaration(clientOptionsConstructor))
            {
                string ctorString = ConstructClientDiagnostic(_writer, "ResourceType.Namespace", DiagnosticOptionsProperty);
                _writer.Line($"{ClientDiagnosticsField} = {ctorString};");
                WriteRestClientAssignments();
                WriteDebugValidate(_writer);
            }
        }

        protected void WriteRestClientAssignments()
        {
            WriteRestClientConstructionForResource(_resource, This.RestClients, ", Id.SubscriptionId", ClientDiagnosticsField, DiagnosticOptionsProperty, "ArmClient", PipelineProperty, BaseUriField, "new ", false);
        }

        protected virtual void WriteProperties()
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{_resource.ResourceType}\";");
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

            _writer.Line();
            WriteStaticValidate($"ResourceType", _writer);
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

            // write all the methods that should belong to this resource
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

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
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

        protected override Resource? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation, out _))
                return null;

            return _resource;
        }

        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation clientOperation, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = _resourceData;
            return data.Type.Equals(type);
        }

        private void WriteListAvailableLocationsMethod(bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            _writer.WriteXmlDocumentationReturns($"A collection of locations that may take multiple service requests to iterate over.");

            var responseType = new CSharpType(typeof(IEnumerable<AzureLocation>)).WrapAsync(async);

            using (_writer.Scope($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("GetAvailableLocations", async)}({typeof(CancellationToken)} cancellationToken = default)"))
            {
                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.GetAvailableLocations", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField))
                {
                    _writer.Line($"return {GetAwait(async)} {CreateMethodName("ListAvailableLocations", async)}(ResourceType, cancellationToken){GetConfigureAwait(async)};");
                }
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
                _writer.WriteVariableNullOrEmptyCheck("key");
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
                    _writer.Line($"throw new {typeof(ArgumentNullException)}(nameof(tags), $\"{{nameof(tags)}} provided cannot be null.\");");
                }
                _writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.SetTags", Array.Empty<DiagnosticAttribute>());
                using (WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField))
                {
                    if (async)
                    {
                        _writer.Append($"await ");
                    }
                    _writer.Line($"TagResource.{CreateMethodName("Delete", async)}(true, cancellationToken: cancellationToken){GetConfigureAwait(async)};");
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
                _writer.WriteVariableNullOrEmptyCheck("key");
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

            BuildParameters(_resource.GetOperation!, out var operationMappings, out var parameterMappings, out _);

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

        private void WriteTaggableCommonMethodBranch(MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            _writer.Append($"var originalResponse = {GetAwait(async)} ");
            _writer.Append($"{GetRestFieldName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMappings, true);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            CodeWriterDelegate dataExpression = w => w.Append($"originalResponse.Value");

            if (_resource.ResourceData.ShouldSetResourceIdentifier)
                _writer.Line($"{dataExpression}.Id = {CreateResourceIdentifierExpression(_resource, operation.RequestPath, parameterMappings, dataExpression)};");

            var newInstanceExpression = _resource.NewInstanceExpression(new[]
            {
                new ParameterInvocation(_resource.ResourceParameter, w => w.Append($"ArmClient")),
                new ParameterInvocation(_resource.ResourceDataParameter, dataExpression),
            });
            _writer.Line($"return {typeof(Response)}.FromValue({newInstanceExpression}, originalResponse.GetRawResponse());");
        }

        protected override void WriteResourceCollectionEntry(Resource resource)
        {
            var collection = resource.ResourceCollection;
            if (collection == null)
                throw new InvalidOperationException($"We are about to write a {resource.Type.Name} resource entry in {_resource.Type.Name} resource, but it does not have a collection, this cannot happen");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets a collection of {resource.Type.Name.LastWordToPlural()} in the {_resource.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"An object representing collection of {resource.Type.Name.LastWordToPlural()} and their operations over a {_resource.Type.Name}.");
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

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it in the {_resource.Type.Name}.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type}\" /> object.");
            using (_writer.Scope($"public {GetVirtual(true)} {resource.Type.Name} Get{resource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {resource.Type.Name}(ArmClient, new {typeof(Azure.Core.ResourceIdentifier)}(Id.ToString() + \"/{singletonResourceIdSuffix}\"));");
            }
        }
    }
}
