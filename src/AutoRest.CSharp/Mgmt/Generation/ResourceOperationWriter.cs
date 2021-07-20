// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter : MgmtClientBaseWriter
    {
        private CodeWriter _writer;
        private ResourceOperation _resourceOperation;
        private BuildContext<MgmtOutputLibrary> _context;
        private bool _inheritResourceOperationsBase = false;
        private bool _isITaggableResource = false;
        private bool _isDeletableResource = false;

        protected virtual Type BaseClass => typeof(ResourceOperationsBase);

        protected override string ContextProperty => "this";

        protected CSharpType TypeOfThis => _resourceOperation.Type;
        protected override string TypeNameOfThis => TypeOfThis.Name;

        public ResourceOperationWriter(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            _resourceOperation = resourceOperation;
            _context = context;
        }

        public void WriteClient()
        {
            var config = _context.Configuration.MgmtConfiguration;
            var isSingleton = _resourceOperation.OperationGroup.IsSingletonResource(config);
            var baseClass = isSingleton ? typeof(SingletonOperationsBase) : typeof(ResourceOperationsBase);

            WriteUsings(_writer);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary(_resourceOperation.Description);

                var operationGroup = _resourceOperation.OperationGroup;
                var resource = _context.Library.GetArmResource(operationGroup);
                var resourceData = _context.Library.GetResourceData(operationGroup);
                _writer.Append($"{_resourceOperation.Declaration.Accessibility} partial class {TypeNameOfThis}: ");

                _inheritResourceOperationsBase = _resourceOperation.GetMethod != null;
                CSharpType[] arguments = { _resourceOperation.ResourceIdentifierType, resource.Type };
                CSharpType type = new CSharpType(baseClass, arguments);
                _writer.Append($"{type}, ");

                if (_resourceOperation.GetMethod == null && baseClass == typeof(ResourceOperationsBase))
                    ErrorHelpers.ThrowError($@"Get operation is missing for '{resource.Type.Name}' resource under operation group '{operationGroup.Key}'.
Check the swagger definition, and use 'operation-group-to-resource' directive to specify the correct resource if necessary.");

                CSharpType inheritType = new CSharpType(typeof(TrackedResource<>), _resourceOperation.ResourceIdentifierType);
                if (resourceData.Inherits != null && resourceData.Inherits.Name == inheritType.Name)
                {
                    _isITaggableResource = true;
                }

                var httpMethodsMap = _resourceOperation.OperationGroup.OperationHttpMethodMapping();
                httpMethodsMap.TryGetValue(HttpMethod.Delete, out var deleteMethods);
                if (deleteMethods != null && deleteMethods.Count > 0)
                {
                    _isDeletableResource = true;
                }
                _writer.RemoveTrailingCharacter();

                using (_writer.Scope())
                {
                    if (!isSingleton)
                    {
                        WriteClientFields(_writer, _resourceOperation.RestClient, false);
                        WriteChildRestClients(_writer, _resourceOperation, _context);
                    }
                    WriteClientCtors(_writer, _resourceOperation, _context, isSingleton);
                    WriteClientProperties(_writer, _resourceOperation, _context.Configuration.MgmtConfiguration);
                    // TODO Write singleton operations
                    if (!isSingleton)
                    {
                        WriteClientMethods(_writer, _resourceOperation, resource, resourceData, _context);
                    }
                    else
                    {
                        WriteChildSingletonGetOperationMethods(_writer, _resourceOperation, _context);
                    }
                }
            }
        }

        private void WriteChildRestClients(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            foreach (var operationGroup in resourceOperation.ChildOperations.Keys)
            {
                writer.Append($"private {context.Library.GetRestClient(operationGroup).Type} {GetRestClientName(operationGroup)}").LineRaw(" { get; }");
            }
        }

        private RestClientMethod? GetMethod(ResourceOperation resourceOperation, ResourceData resourceData)
        {
            var getMethods = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Get);
            var getMethodWithResourceDataResponse = getMethods.Where(m => m.Responses[0].ResponseBody?.Type.Name == resourceData.Type.Name);
            RestClientMethod? getMethod = null;
            if (getMethodWithResourceDataResponse != null && getMethodWithResourceDataResponse.Count() > 0)
            {
                getMethod = getMethodWithResourceDataResponse.First();
            }
            return getMethod;
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool isSingleton = false)
        {
            var typeOfThis = resourceOperation.Type.Name;
            var constructorIdParam = isSingleton ? "" : $", {resourceOperation.ResourceIdentifierType} id";

            writer.Line();
            // write an internal default constructor
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class for mocking.");
            using (writer.Scope($"protected {typeOfThis}()"))
            { }

            // write "resource + id" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            if (!isSingleton)
            {
                writer.WriteXmlDocumentationParameter("id", "The identifier of the resource that is the target of operations.");
            }
            var baseConstructorCall = isSingleton ? "base(options)" : "base(options, id)";
            using (writer.Scope($"protected internal {typeOfThis}({typeof(OperationsBase)} options{constructorIdParam}) : {baseConstructorCall}"))
            {
                if (!isSingleton)
                {
                    writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                    var subscriptionValue = (resourceOperation.ResourceIdentifierType == typeof(TenantResourceIdentifier)) ? string.Empty : "Id.SubscriptionId, ";
                    writer.Line($"{RestClientField} = new {resourceOperation.RestClient.Type}({ClientDiagnosticsField}, {PipelineProperty}, {subscriptionValue}BaseUri);");
                    foreach (var operationGroup in resourceOperation.ChildOperations.Keys)
                    {
                        writer.Line($"{GetRestClientName(operationGroup)} = new {context.Library.GetRestClient(operationGroup).Type}({ClientDiagnosticsField}, {PipelineProperty}, {subscriptionValue}BaseUri);");
                    }
                }
            }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation, MgmtConfiguration config)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");
            writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{resourceOperation.OperationGroup.ResourceType(config)}\";");
            writer.WriteXmlDocumentationSummary($"Gets the valid resource type for the operations");
            writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => ResourceType;");
        }

        private void WriteClientMethods(CodeWriter writer, ResourceOperation resourceOperation, Resource resource, ResourceData resourceData, BuildContext<MgmtOutputLibrary> context)
        {
            var clientMethodsList = new List<RestClientMethod>();

            writer.Line();
            if (_inheritResourceOperationsBase && resourceOperation.GetMethod != null)
            {
                // write inherited get method
                WriteGetMethod(writer, resourceOperation.GetMethod, resource, context, true, true);
                WriteGetMethod(writer, resourceOperation.GetMethod, resource, context, true, false);

                var nonPathParameters = resourceOperation.GetMethod.RestClientMethod.NonPathParameters;
                if (nonPathParameters.Count > 0)
                {
                    // write get method
                    WriteGetMethod(writer, resourceOperation.GetMethod, resource, context, false, true);
                    WriteGetMethod(writer, resourceOperation.GetMethod, resource, context, false, false);
                }
                clientMethodsList.Add(resourceOperation.GetMethod.RestClientMethod);

                WriteListAvailableLocationsMethod(writer, true);
                WriteListAvailableLocationsMethod(writer, false);
            }

            if (_isDeletableResource)
            {
                var deleteMethod = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Delete).FirstOrDefault();
                // write delete method
                WriteFirstLROMethod(writer, deleteMethod, context, true);
                WriteFirstLROMethod(writer, deleteMethod, context, false);

                WriteStartLROMethod(writer, deleteMethod, context, true);
                WriteStartLROMethod(writer, deleteMethod, context, false);
                clientMethodsList.Add(deleteMethod);
            }

            if (_isITaggableResource)
            {
                var updateMethods = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Patch);
                if (updateMethods == null || updateMethods.Count() == 0)
                {
                    updateMethods = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Put);
                    // TODO -- not all the PUT operations can be used for update tags
                }

                RestClientMethod? updateMethod = null;
                if (updateMethods != null && updateMethods.Count() == 1)
                {
                    updateMethod = updateMethods.FirstOrDefault();
                }
                else if (updateMethods != null && updateMethods.Count() > 1)
                {
                    updateMethod = updateMethods.Where(m => m.Name == "Update").FirstOrDefault();
                }
                else
                {
                    if (!resourceOperation.OperationGroup.IsTupleResource(context))
                        throw new Exception($"Please update the swagger for {resource.Type.Name} to add the update operation.");
                }

                if (updateMethod != null)
                {
                    // write update method
                    WriteAddTagMethod(writer, resourceOperation, updateMethod, context);
                    WriteSetTagsMethod(writer, resourceOperation, updateMethod, context);
                    WriteRemoveTagMethod(writer, resourceOperation, updateMethod, context);
                    clientMethodsList.Add(updateMethod);
                }
            }

            // 1. Listing myself at parent scope -> on the container named list
            // 2. Listing myself at ancestor scope -> extension method if the ancestor is not in this RP, or follow #3 by listing myself as the children of the ancestor in the operations of the ancestor
            // 3. Listing children (might be resource or not) -> on the operations

            // write rest of the methods
            var resourceContainer = context.Library.GetResourceContainer(resourceOperation.OperationGroup);
            foreach (var clientMethod in resourceOperation.ResourceOperationsClientMethods)
            {
                if (!clientMethodsList.Contains(clientMethod.RestClientMethod))
                {
                    WriteClientMethod(writer, clientMethod, clientMethod.Diagnostics, resourceOperation.OperationGroup, context, true);
                    WriteClientMethod(writer, clientMethod, clientMethod.Diagnostics, resourceOperation.OperationGroup, context, false);
                }
            }

            // write paging methods
            foreach (var listMethod in resourceOperation.ResourceOperationsListMethods)
            {
                if (listMethod.PagingMethod != null)
                {
                    WritePagingMethod(writer, resourceOperation.OperationGroup, false, listMethod.PagingMethod, RestClientField);
                    WritePagingMethod(writer, resourceOperation.OperationGroup, true, listMethod.PagingMethod, RestClientField);
                }
            }

            // write child methods
            foreach (var pair in resourceOperation.ChildOperations)
            {
                var restClientName = GetRestClientName(pair.Key);
                foreach (var clientMethod in pair.Value.ClientMethods)
                {
                    WriteClientMethod(writer, clientMethod, clientMethod.Diagnostics, pair.Key, context, true, restClientName);
                    WriteClientMethod(writer, clientMethod, clientMethod.Diagnostics, pair.Key, context, false, restClientName);
                }
                foreach (var pagingMethod in pair.Value.PagingMethods)
                {
                    WritePagingMethod(writer, pair.Key, false, pagingMethod, GetRestClientName(pair.Key));
                    WritePagingMethod(writer, pair.Key, true, pagingMethod, GetRestClientName(pair.Key));
                }
            }

            // write rest of the LRO methods
            foreach (var clientMethod in resourceOperation.ResourceOperationsLROMethods)
            {
                if (!clientMethodsList.Contains(clientMethod))
                {
                    WriteLRO(writer, clientMethod, resourceOperation, context);
                }
            }

            foreach (var item in context.CodeModel.OperationGroups)
            {
                if (item.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(resourceOperation.OperationGroup.ResourceType(context.Configuration.MgmtConfiguration))
                    && !item.IsSingletonResource(context.Configuration.MgmtConfiguration))
                {
                    var container = context.Library.GetResourceContainer(item);
                    if (container == null)
                        continue;
                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Gets a list of {container.ResourceName.ToPlural()} in the {resourceOperation.ResourceName}.");
                    writer.WriteXmlDocumentationReturns($"An object representing collection of {container.ResourceName.ToPlural()} and their operations over a {resourceOperation.ResourceName}.");
                    using (writer.Scope($"public {container.Type} Get{container.ResourceName.ToPlural()}()"))
                    {
                        writer.Line($"return new {container.Type}(this);");
                    }
                }
            }
        }

        private void WritePagingMethod(CodeWriter writer, OperationGroup operationGroup, bool async, PagingMethod pagingMethod, string restClientName)
        {
            writer.Line();
            var nonPathParameters = pagingMethod.Method.NonPathParameters;

            writer.WriteXmlDocumentationSummary(pagingMethod.Method.Description);
            foreach (var param in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(param);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            CSharpType itemType = pagingMethod.PagingResponse.ItemType;
            string returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{itemType.Name}\" /> that may take multiple service requests to iterate over.";
            writer.WriteXmlDocumentationReturns(returnText);

            var returnType = itemType.WrapPageable(async);

            var methodName = CreateMethodName(pagingMethod.Name, async);
            writer.Append($"public {returnType} {methodName}(");
            foreach (var param in nonPathParameters)
            {
                writer.WriteParameter(param);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WritePagingOperationBody(writer, pagingMethod, itemType, restClientName, pagingMethod.Diagnostics,
                    ClientDiagnosticsField, $"", async);
            }
        }

        private string GetRestClientName(OperationGroup operationGroup)
        {
            return $"_{operationGroup.Key.ToVariableName()}RestClient";
        }

        private void WriteGetMethod(CodeWriter writer, ClientMethod clientMethod, Resource resource, BuildContext<MgmtOutputLibrary> context, bool isInheritedMethod, bool async)
        {
            writer.Line();
            var nonPathParameters = clientMethod.RestClientMethod.NonPathParameters;
            if (isInheritedMethod)
            {
                writer.WriteXmlDocumentationInheritDoc();
            }
            else
            {
                writer.WriteXmlDocumentationSummary(clientMethod.Description);
                foreach (Parameter parameter in nonPathParameters)
                {
                    writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
                }
                writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            }
            var responseType = resource.Type.WrapAsyncResponse(async);
            writer.Append($"public {AsyncKeyword(async)} {OverrideKeyword(isInheritedMethod)} {responseType} {CreateMethodName("Get", async)}(");

            if (!isInheritedMethod)
            {
                foreach (Parameter parameter in nonPathParameters)
                {
                    writer.Append($"{parameter.Type} {parameter.Name}, ");
                }
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(nonPathParameters);

                WriteDiagnosticScope(writer, clientMethod.Diagnostics, ClientDiagnosticsField, writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    writer.Append($"var {response:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    var pathParamNames = GetPathParametersName(clientMethod.RestClientMethod, resource.OperationGroup, context).ToList();
                    writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}( ");
                    foreach (string paramNames in pathParamNames)
                    {
                        writer.Append($"{paramNames:I}, ");
                    }
                    foreach (Parameter parameter in nonPathParameters)
                    {
                        if (isInheritedMethod)
                        {
                            if (parameter.DefaultValue != null)
                            {
                                if (TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue))
                                {
                                    writer.WriteConstant(parameter.DefaultValue.Value);
                                    writer.Append($", ");
                                }
                                else
                                {
                                    writer.Append($"null, ");
                                }
                            }
                        }
                        else
                        {
                            writer.Append($"{parameter.Name}, ");
                        }
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Line($"return {typeof(Response)}.FromValue(new {resource.Type}(this, response.Value), response.GetRawResponse());");
                });
                writer.Line();
            }
        }

        private void WriteListAvailableLocationsMethod(CodeWriter writer, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("A collection of locations that may take multiple service requests to iterate over.");

            var responseType = new CSharpType(typeof(IEnumerable<Location>)).WrapAsync(async);

            using (writer.Scope($"public {AsyncKeyword(async)} {responseType} {CreateMethodName("ListAvailableLocations", async)}({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"return {AwaitKeyword(async)} {CreateMethodName("ListAvailableLocations", async)}(ResourceType, cancellationToken)");
                if (async)
                {
                    writer.Append($".ConfigureAwait(false)");
                }
                writer.Append($";");
            }
        }

        private void WriteAddTagMethod(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            WriteAddTag(writer, resourceOperation, clientMethod, context, true);
            WriteAddTag(writer, resourceOperation, clientMethod, context, false);
        }

        private void WriteAddTag(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary("Add a tag to the current resource.");
            writer.WriteXmlDocumentationParameter("key", "The key for the tag.");
            writer.WriteXmlDocumentationParameter("value", "The value for the tag.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tag added.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            var responseType = resource.Type.WrapAsyncResponse(async);

            writer.Append($"public {AsyncKeyword(async)} {responseType} {CreateMethodName("AddTag", async)}(string key, string value, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                using (writer.Scope($"if (string.IsNullOrWhiteSpace(key))"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}($\"{{nameof(key)}} provided cannot be null or a whitespace.\", nameof(key));");
                }
                writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.AddTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"var originalTags = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"TagResourceOperations.{CreateMethodName("Get", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Line($"originalTags.Value.Data.Properties.TagsValue[key] = value;");
                    WriteTaggableCommonMethod(writer, resource, resourceOperation, context, async);
                });
                writer.Line();
            }
        }

        private void WriteSetTagsMethod(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            WriteSetTags(writer, resourceOperation, clientMethod, context, true);
            WriteSetTags(writer, resourceOperation, clientMethod, context, false);
        }

        private void WriteSetTags(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary("Replace the tags on the resource with the given set.");
            writer.WriteXmlDocumentationParameter("tags", "The set of tags to use as replacement.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tags replaced.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            var responseType = resource.Type.WrapAsyncResponse(async);

            writer.Append($"public {AsyncKeyword(async)} {responseType} {CreateMethodName("SetTags", async)}({typeof(IDictionary<string, string>)} tags, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                using (writer.Scope($"if (tags == null)"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}($\"{{nameof(tags)}} provided cannot be null.\", nameof(tags));");
                }
                writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.SetTags", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"TagResourceOperations.{CreateMethodName("Delete", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Append($"var originalTags  = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"TagResourceOperations.{CreateMethodName("Get", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Line($"originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);");
                    WriteTaggableCommonMethod(writer, resource, resourceOperation, context, async);
                });
                writer.Line();
            }
        }

        private void WriteRemoveTagMethod(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            WriteRemoveTag(writer, resourceOperation, clientMethod, context, true);
            WriteRemoveTag(writer, resourceOperation, clientMethod, context, false);
        }

        private void WriteRemoveTag(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary("Removes a tag by key from the resource.");
            writer.WriteXmlDocumentationParameter("key", "The key of the tag to remove.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tag removed.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            var responseType = resource.Type.WrapAsyncResponse(async);

            writer.Append($"public {AsyncKeyword(async)} {responseType} {CreateMethodName("RemoveTag", async)}(string key, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                using (writer.Scope($"if (string.IsNullOrWhiteSpace(key))"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}($\"{{nameof(key)}} provided cannot be null or a whitespace.\", nameof(key));");
                }
                writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.RemoveTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"var originalTags = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"TagResourceOperations.{CreateMethodName("Get", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Line($"originalTags.Value.Data.Properties.TagsValue.Remove(key);");
                    WriteTaggableCommonMethod(writer, resource, resourceOperation, context, async);
                });
                writer.Line();
            }
        }

        private void WriteTaggableCommonMethod(CodeWriter writer, Resource resource, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            if (async)
            {
                writer.Append($"await ");
            }
            writer.Append($"TagContainer.{CreateMethodName("CreateOrUpdate", async)}(originalTags.Value.Data, cancellationToken)");
            if (async)
            {
                writer.Append($".ConfigureAwait(false)");
            }
            writer.Line($";");
            writer.Append($"var originalResponse = ");
            if (async)
            {
                writer.Append($"await ");
            }
#pragma warning disable CS8602
            var pathParamNames = GetPathParametersName(resourceOperation.GetMethod.RestClientMethod, resource.OperationGroup, context).ToList();
#pragma warning restore CS8602
            writer.Append($"{RestClientField}.{CreateMethodName(resourceOperation.GetMethod.Name, async)}( ");
            foreach (string paramNames in pathParamNames)
            {
                writer.Append($"{paramNames:I}, ");
            }
            foreach (Parameter parameter in resourceOperation.GetMethod.RestClientMethod.NonPathParameters)
            {
                if (parameter.ValidateNotNull)
                {
                    writer.Append($"{parameter.Name}, ");
                }
                else
                {
                    writer.Append($"null, ");
                }
            }
            writer.Append($"cancellationToken)");

            if (async)
            {
                writer.Append($".ConfigureAwait(false)");
            }
            writer.Line($";");
            writer.Line($"return {typeof(Response)}.FromValue(new {resource.Type}(this, originalResponse.Value), originalResponse.GetRawResponse());");
        }

        private void WriteLRO(CodeWriter writer, RestClientMethod clientMethod, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            WriteFirstLROMethod(writer, clientMethod, context, true);
            WriteFirstLROMethod(writer, clientMethod, context, false);

            WriteStartLROMethod(writer, clientMethod, context, true);
            WriteStartLROMethod(writer, clientMethod, context, false);
        }

        private void WriteChildSingletonGetOperationMethods(CodeWriter writer, ResourceOperation currentOperation, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            foreach (var operation in context.Library.ResourceOperations)
            {
                if (operation.OperationGroup.IsSingletonResource(config)
                    && operation.OperationGroup.ParentResourceType(config).Equals(currentOperation.OperationGroup.ResourceType(config)))
                {
                    writer.Line($"#region Get {operation.Type.Name}s operation");

                    writer.WriteXmlDocumentationSummary($"Gets an object representing a {operation.Type.Name} along with the instance operations that can be performed on it.");
                    writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{operation.Type.Name}\" /> object.");
                    using (writer.Scope($"public {operation.Type} Get{operation.Type.Name}s()"))
                    {
                        writer.Line($"return new {operation.Type.Name}(this);");
                    }
                    writer.LineRaw("#endregion");
                    writer.Line();
                }
            }
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // operations.Id is the ID of the resource itself, therefore we do not need to make the resource name pass through
        }

        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            bool passThru = false;
            if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
            {
                valueExpression = "Id.ResourceGroupName";
            }
            else if (string.Equals(parameter.Name, "subscriptionId", StringComparison.InvariantCultureIgnoreCase))
            {
                valueExpression = "Id.SubscriptionId";
            }
            else
            {
                parentNameStack.Push($"Id{dotParent}.Name");
                dotParent += ".Parent";
            }

            return passThru;
        }
    }
}
