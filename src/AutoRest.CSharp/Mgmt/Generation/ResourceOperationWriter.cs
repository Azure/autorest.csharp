﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
using Azure.ResourceManager;
using Core = Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

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

        protected virtual Type BaseClass => typeof(Core.ResourceOperations);

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
            var baseClass = isSingleton ? typeof(Core.SingletonOperations) : typeof(Core.ResourceOperations);

            WriteUsings(_writer);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resourceOperation.Description}");

                var operationGroup = _resourceOperation.OperationGroup;
                var resource = _context.Library.GetArmResource(operationGroup);
                var resourceData = _context.Library.GetResourceData(operationGroup);
                _writer.Append($"{_resourceOperation.Declaration.Accessibility} partial class {TypeNameOfThis}: ");

                _inheritResourceOperationsBase = _resourceOperation.GetMethod != null;
                CSharpType type = new CSharpType(baseClass);
                _writer.Append($"{type}, ");

                if (_resourceOperation.GetMethod == null && baseClass == typeof(Core.ResourceOperations))
                    ErrorHelpers.ThrowError($@"Get operation is missing for '{resource.Type.Name}' resource under operation group '{operationGroup.Key}'.
Check the swagger definition, and use 'operation-group-to-resource' directive to specify the correct resource if necessary.");

                CSharpType inheritType = new CSharpType(typeof(TrackedResource));
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
            writer.WriteXmlDocumentationParameter("options", $"The client parameters to use in these operations.");
            if (!isSingleton)
            {
                writer.WriteXmlDocumentationParameter("id", $"The identifier of the resource that is the target of operations.");
            }
            var baseConstructorCall = isSingleton ? "base(options)" : "base(options, id)";
            using (writer.Scope($"protected internal {typeOfThis}({typeof(Core.ResourceOperations)} options{constructorIdParam}) : {baseConstructorCall}"))
            {
                if (!isSingleton)
                {
                    writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                    var subscriptionParamString = resourceOperation.RestClient.Parameters.Any(p => p.Name.Equals("subscriptionId")) ? ", Id.SubscriptionId" : string.Empty;
                    writer.Line($"{RestClientField} = new {resourceOperation.RestClient.Type}({ClientDiagnosticsField}, {PipelineProperty}{subscriptionParamString}, BaseUri);");
                    foreach (var operationGroup in resourceOperation.ChildOperations.Keys)
                    {
                        writer.Line($"{GetRestClientName(operationGroup)} = new {context.Library.GetRestClient(operationGroup).Type}({ClientDiagnosticsField}, {PipelineProperty}{subscriptionParamString}, BaseUri);");
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

        private void WriteClientMethods(CodeWriter writer, ResourceOperation resourceOperation, Output.Resource resource, ResourceData resourceData, BuildContext<MgmtOutputLibrary> context)
        {
            var clientMethodsList = new List<RestClientMethod>();

            writer.Line();
            if (_inheritResourceOperationsBase && resourceOperation.GetMethod != null)
            {
                // write inherited get method
                WriteGetMethod(writer, resourceOperation.GetMethod, resource, context, true, resourceOperation.GetMethods, "Get");
                WriteGetMethod(writer, resourceOperation.GetMethod, resource, context, false, resourceOperation.GetMethods, "Get");

                clientMethodsList.AddRange(resourceOperation.GetMethods.Select(m => m.RestClientMethod).ToList());

                WriteListAvailableLocationsMethod(writer, true);
                WriteListAvailableLocationsMethod(writer, false);
            }

            if (_isDeletableResource)
            {
                var deleteMethod = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Delete && m.Parameters.FirstOrDefault()?.Name.Equals("scope") == true).FirstOrDefault() ?? resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Delete).OrderBy(m => m.Name.Length).FirstOrDefault();
                var deleteMethods = resourceOperation.IsScopeOrExtension ? resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Delete).ToList() : new List<RestClientMethod>{deleteMethod};
                // write delete method
                WriteFirstLROMethod(writer, deleteMethod, context, true, true, "Delete");
                WriteFirstLROMethod(writer, deleteMethod, context, false, true, "Delete");

                WriteStartLROMethod(writer, deleteMethod, context, true, true, "Delete", deleteMethods);
                WriteStartLROMethod(writer, deleteMethod, context, false, true, "Delete", deleteMethods);
                clientMethodsList.AddRange(deleteMethods);
            }

            if (_isITaggableResource)
            {
                // write update method
                WriteAddTagMethod(writer, resourceOperation, context);
                WriteSetTagsMethod(writer, resourceOperation, context);
                WriteRemoveTagMethod(writer, resourceOperation, context);
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
                    WriteClientMethod(writer, clientMethod, clientMethod.Name, clientMethod.Diagnostics, resourceOperation.OperationGroup, context, true);
                    WriteClientMethod(writer, clientMethod, clientMethod.Name, clientMethod.Diagnostics, resourceOperation.OperationGroup, context, false);
                }
            }

            // write paging methods
            foreach (var listMethod in resourceOperation.ResourceOperationsListMethods)
            {
                if (listMethod.PagingMethod != null)
                {
                    WritePagingMethod(writer, resourceOperation.OperationGroup, listMethod.PagingMethod, listMethod.PagingMethod.Diagnostics, listMethod.PagingMethod.Name, RestClientField, false);
                    WritePagingMethod(writer, resourceOperation.OperationGroup, listMethod.PagingMethod, listMethod.PagingMethod.Diagnostics, listMethod.PagingMethod.Name, RestClientField, true);
                }
            }

            // write child methods
            foreach (var pair in resourceOperation.ChildOperations)
            {
                var restClientName = GetRestClientName(pair.Key);
                foreach (var clientMethod in pair.Value.ClientMethods)
                {
                    var originalName = clientMethod.Name;
                    var methodName = originalName.EndsWith($"By{_resourceOperation.Resource.Type.Name}") ? originalName.Substring(0, originalName.IndexOf("By")) : originalName;
                    Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientMethod(writer, clientMethod, methodName, diagnostic, pair.Key, context, true, restClientName);
                    WriteClientMethod(writer, clientMethod, methodName, diagnostic, pair.Key, context, false, restClientName);
                }
                foreach (var pagingMethod in pair.Value.PagingMethods)
                {
                    var originalName = pagingMethod.Name;
                    var methodName = originalName.EndsWith($"By{_resourceOperation.Resource.Type.Name}") ? originalName.Substring(0, originalName.IndexOf("By")) : originalName;
                    Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WritePagingMethod(writer, pair.Key, pagingMethod, diagnostic, methodName, GetRestClientName(pair.Key), false);
                    WritePagingMethod(writer, pair.Key, pagingMethod, diagnostic, methodName, GetRestClientName(pair.Key), true);
                }
            }

            // write rest of the LRO methods
            var mergedMethods = new Dictionary<string, List<RestClientMethod>>();
            foreach (var clientMethod in resourceOperation.ResourceOperationsLROMethods)
            {
                if (!clientMethodsList.Contains(clientMethod))
                {
                    if (_context.Library.TryGetMethodForMergedOperation($"{_resourceOperation.OperationGroup.Key}_{clientMethod.Name}_{clientMethod.Request.HttpMethod}", out var mergedMethodName))
                    {
                        if (mergedMethods.TryGetValue(mergedMethodName, out var methods))
                        {
                            methods.Add(clientMethod);
                        }
                        else
                        {
                            mergedMethods.Add(mergedMethodName, new List<RestClientMethod>{clientMethod});
                        }
                        continue;
                    }
                    WriteLRO(writer, clientMethod, resourceOperation, context);
                }
            }

            foreach ( var kv in mergedMethods)
            {
                WriteLRO(writer, kv.Value.OrderBy(m => m.Name.Length).First(), resourceOperation, context, kv.Key, kv.Value);
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

        private void WritePagingMethod(CodeWriter writer, OperationGroup operationGroup, PagingMethod pagingMethod, Diagnostic diagnostic, string clientMethodName, string restClientName, bool async)
        {
            writer.Line();
            var nonPathParameters = pagingMethod.Method.NonPathParameters;

            writer.WriteXmlDocumentationSummary($"{pagingMethod.Method.Description}");
            foreach (var param in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(param);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");

            CSharpType itemType = pagingMethod.PagingResponse.ItemType;
            FormattableString returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{itemType.Name}\" /> that may take multiple service requests to iterate over.";
            writer.WriteXmlDocumentationReturns(returnText);

            var returnType = itemType.WrapPageable(async);

            var methodName = CreateMethodName(clientMethodName, async);
            writer.Append($"public virtual {returnType} {methodName}(");
            foreach (var param in nonPathParameters)
            {
                writer.WriteParameter(param);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WritePagingOperationBody(writer, pagingMethod, itemType, restClientName, diagnostic,
                    ClientDiagnosticsField, $"", async);
            }
        }

        private string GetRestClientName(OperationGroup operationGroup)
        {
            return $"_{operationGroup.Key.ToVariableName()}RestClient";
        }

        private void WriteGetMethod(CodeWriter writer, ClientMethod method, Output.Resource resource, BuildContext<MgmtOutputLibrary> context, bool async, List<ClientMethod> methods, string? methodName = null)
        {
            methodName = methodName ?? method.Name;
            writer.Line();
            var nonPathParameters = method.RestClientMethod.NonPathParameters;
            writer.WriteXmlDocumentationSummary($"{method.Description}");
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            var responseType = resource.Type.WrapResponse(async);
            writer.Append($"public {GetAsyncKeyword(async)} {GetOverride(false, true)} {responseType} {CreateMethodName($"{methodName}", async)}(");

            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(nonPathParameters);

                WriteDiagnosticScope(writer, method.Diagnostics, ClientDiagnosticsField, writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    response.SetActualName(response.RequestedName);
                    if (method.RestClientMethod.Operation.IsAncestorScope() || methods.Count < 2)
                    {
                        WriteGetMethodBody(writer, method, resource, context, response, async, nonPathParameters);
                    }
                    else
                    {
                        var methodDict = methods.ToDictionary(m => m, m => m.RestClientMethod.Operation.AncestorResourceType());
                        // There could be methods at resource group scope and at resource scope, both with ResourceGroups AncestorResourceType.
                        ClientMethod? resourceMethod = null;
                        var resourceGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ResourceGroups).Key;
                        var resourceGroupMethodsCount = methodDict.Count(kv => kv.Value == ResourceTypeBuilder.ResourceGroups);
                        if (resourceGroupMethodsCount > 1)
                        {
                            // The parent resource type of a resource method is always resourceGroupsResources
                            resourceMethod = methodDict.FirstOrDefault(kv => kv.Key.RestClientMethod.Operation.ParentResourceType() == ResourceTypeBuilder.ResourceGroupResources).Key;
                            if (resourceMethod != null)
                            {
                                methodDict.Remove(resourceMethod);
                                resourceGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ResourceGroups).Key;
                            }
                        }
                        if (resourceGroupMethod != null)
                        {
                            methodDict.Remove(resourceGroupMethod);
                            var resourceGroupNameVar = resourceMethod == null ? "_" : "var resourceGroupName";
                            using (writer.Scope($"if (Id.TryGetResourceGroupName(out {resourceGroupNameVar}))"))
                            {
                                if (resourceMethod != null)
                                {
                                    using (writer.Scope($"if (Id.ResourceType.Equals(ResourceGroupOperations.ResourceType))"))
                                    {
                                        WriteGetMethodBody(writer, resourceGroupMethod, resource, context, response, async, resourceGroupMethod.RestClientMethod.NonPathParameters);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteGetMethodBody(writer, resourceMethod, resource, context, response, async, resourceMethod.RestClientMethod.NonPathParameters, isResourceLevel: true);
                                    }
                                }
                                else
                                {
                                    WriteGetMethodBody(writer, resourceGroupMethod, resource, context, response, async, resourceGroupMethod.RestClientMethod.NonPathParameters);
                                }
                            }
                        } // No else clause with the assumption that resourceMethod only exists when resourceGroupMethod exists.
                        var managementGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ManagementGroups).Key;
                        var tenantMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.Tenant).Key;
                        var elseStr = resourceGroupMethod != null ? (managementGroupMethod == null && tenantMethod == null ? "else" : "else if") : "if";
                        var subscriptionMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.Subscriptions).Key;
                        if (subscriptionMethod != null)
                        {
                            methodDict.Remove(subscriptionMethod);
                            using (writer.Scope($"{elseStr} (Id.TryGetSubscriptionId(out _))"))
                            {
                                WriteGetMethodBody(writer, subscriptionMethod, resource, context, response, async, subscriptionMethod.RestClientMethod.NonPathParameters);
                            }
                        }

                        elseStr = (!elseStr.IsNullOrEmpty() || subscriptionMethod != null) ? "else " : string.Empty;
                        if (managementGroupMethod != null)
                        {
                            methodDict.Remove(managementGroupMethod);
                            using (elseStr.IsNullOrEmpty() ? null : writer.Scope($"{elseStr}"))
                            {
                                if (tenantMethod != null)
                                {
                                    methodDict.Remove(tenantMethod);
                                    var parent = new CodeWriterDeclaration("parent");
                                    writer.Line($"var {parent:D} = Id;");
                                    using (writer.Scope($"while ({parent}.Parent != ResourceIdentifier.RootResourceIdentifier)"))
                                    {
                                        writer.Line($"{parent} = {parent}.Parent;");
                                    }
                                    writer.UseNamespace("Azure.ResourceManager.Management");
                                    using (writer.Scope($"if (parent.ResourceType.Equals(ManagementGroupOperations.ResourceType))"))
                                    {
                                        WriteGetMethodBody(writer, managementGroupMethod, resource, context, response, async, managementGroupMethod.RestClientMethod.NonPathParameters);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteGetMethodBody(writer, tenantMethod, resource, context, response, async, tenantMethod.RestClientMethod.NonPathParameters);
                                    }
                                }
                                else
                                {
                                    WriteGetMethodBody(writer, managementGroupMethod, resource, context, response, async, managementGroupMethod.RestClientMethod.NonPathParameters);
                                }
                            }
                        }
                        else if (tenantMethod != null)
                        {
                            methodDict.Remove(tenantMethod);
                            using (writer.Scope($"{elseStr}"))
                            {
                                WriteGetMethodBody(writer, tenantMethod, resource, context, response, async, tenantMethod.RestClientMethod.NonPathParameters);
                            }
                        }

                        if (methodDict.Count() > 0)
                        {
                            throw new Exception($"When trying to merge methods, multiple methods can be mapped to the same scope. The methods not handled: {String.Join(", ", methodDict.Select(kv => kv.Key.Name).ToList())}.");
                        }
                    }
                });
                writer.Line();
            }
        }

        private void WriteGetMethodBody(CodeWriter writer, ClientMethod clientMethod, Output.Resource resource, BuildContext<MgmtOutputLibrary> context, CodeWriterDeclaration response, bool async, List<Parameter> nonPathParameters, bool isResourceLevel = false)
        {
            if (isResourceLevel)
            {
                writer.UseNamespace("System.Collections.Generic");
                writer.Line($"var parent = Id.Parent;");
                writer.Line($"var parentParts = new List<string>();");
                using (writer.Scope($"while (!parent.ResourceType.Equals(ResourceGroupOperations.ResourceType))"))
                {
                    writer.Line($"parentParts.Insert(0, $\"{{parent.ResourceType.Types[parent.ResourceType.Types.Count - 1]}}/{{parent.Name}}\");");
                    writer.Line($"parent = parent.Parent;");
                }
                writer.Line($"var parentResourcePath = parentParts.Count > 0 ? string.Join(\"/\", parentParts) : \"\";");
                writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
            }
            writer.Append($"var {response} = ");
            if (async)
            {
                writer.Append($"await ");
            }
            writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}( ");
            BuildAndWriteParameters(writer, clientMethod.RestClientMethod, isResourceLevel: isResourceLevel);
            writer.Append($"cancellationToken)");

            if (async)
            {
                writer.Append($".ConfigureAwait(false)");
            }
            writer.Line($";");
            WriteEndOfGet(writer, resource.Type, async);
        }

        private void WriteListAvailableLocationsMethod(CodeWriter writer, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Lists all available geo-locations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns($"A collection of locations that may take multiple service requests to iterate over.");

            var responseType = new CSharpType(typeof(IEnumerable<Location>)).WrapAsync(async);

            using (writer.Scope($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("GetAvailableLocations", async)}({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"return {GetAwait(async)} {CreateMethodName("ListAvailableLocations", async)}(ResourceType, cancellationToken){GetConfigureAwait(async)};");
            }
        }

        private void WriteAddTagMethod(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            WriteAddTag(writer, resourceOperation, context, true);
            WriteAddTag(writer, resourceOperation, context, false);
        }

        private void WriteAddTag(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Add a tag to the current resource.");
            writer.WriteXmlDocumentationParameter("key", $"The key for the tag.");
            writer.WriteXmlDocumentationParameter("value", $"The value for the tag.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns($"The updated resource with the tag added.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            var responseType = resource.Type.WrapResponse(async);

            writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("AddTag", async)}(string key, string value, {typeof(CancellationToken)} cancellationToken = default)");
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
                    writer.Line($"TagResourceOperations.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    writer.Line($"originalTags.Value.Data.Properties.TagsValue[key] = value;");
                    WriteTaggableCommonMethod(writer, resource, resourceOperation, context, async);
                });
                writer.Line();
            }
        }

        private void WriteSetTagsMethod(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            WriteSetTags(writer, resourceOperation, context, true);
            WriteSetTags(writer, resourceOperation, context, false);
        }

        private void WriteSetTags(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Replace the tags on the resource with the given set.");
            writer.WriteXmlDocumentationParameter("tags", $"The set of tags to use as replacement.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns($"The updated resource with the tags replaced.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            var responseType = resource.Type.WrapResponse(async);

            writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("SetTags", async)}({typeof(IDictionary<string, string>)} tags, {typeof(CancellationToken)} cancellationToken = default)");
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
                    writer.Line($"TagResourceOperations.{CreateMethodName("Delete", async)}(cancellationToken){GetConfigureAwait(async)};");
                    writer.Append($"var originalTags  = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Line($"TagResourceOperations.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    writer.Line($"originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);");
                    WriteTaggableCommonMethod(writer, resource, resourceOperation, context, async);
                });
                writer.Line();
            }
        }

        private void WriteRemoveTagMethod(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            WriteRemoveTag(writer, resourceOperation, context, true);
            WriteRemoveTag(writer, resourceOperation, context, false);
        }

        private void WriteRemoveTag(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Removes a tag by key from the resource.");
            writer.WriteXmlDocumentationParameter("key", $"The key of the tag to remove.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns($"The updated resource with the tag removed.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            var responseType = resource.Type.WrapResponse(async);

            writer.Append($"public {GetAsyncKeyword(async)} {GetVirtual(true)} {responseType} {CreateMethodName("RemoveTag", async)}(string key, {typeof(CancellationToken)} cancellationToken = default)");
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
                    writer.Line($"TagResourceOperations.{CreateMethodName("Get", async)}(cancellationToken){GetConfigureAwait(async)};");
                    writer.Line($"originalTags.Value.Data.Properties.TagsValue.Remove(key);");
                    WriteTaggableCommonMethod(writer, resource, resourceOperation, context, async);
                });
                writer.Line();
            }
        }

        private void WriteTaggableCommonMethod(CodeWriter writer, Output.Resource resource, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            if (async)
            {
                writer.Append($"await ");
            }
            writer.Line($"TagContainer.{CreateMethodName("CreateOrUpdate", async)}(originalTags.Value.Data, cancellationToken){GetConfigureAwait(async)};");
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
            writer.Line($"cancellationToken){GetConfigureAwait(async)};");
            writer.Line($"return {typeof(Response)}.FromValue(new {resource.Type}(this, originalResponse.Value), originalResponse.GetRawResponse());");
        }

        private void WriteLRO(CodeWriter writer, RestClientMethod clientMethod, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, string? methodName = null, List<RestClientMethod>? clientMethods = null)
        {
            WriteFirstLROMethod(writer, clientMethod, context, true, true, methodName: methodName);
            WriteFirstLROMethod(writer, clientMethod, context, false, true, methodName: methodName);

            WriteStartLROMethod(writer, clientMethod, context, true, true, methodName: methodName, methods: clientMethods);
            WriteStartLROMethod(writer, clientMethod, context, false, true, methodName: methodName, methods: clientMethods);
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
            var isAncestorResourceTypeTenant = _resourceOperation.OperationGroup.IsAncestorResourceTypeTenant(_context);
            if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase) && !isAncestorResourceTypeTenant)
            {
                valueExpression = "Id.ResourceGroupName";
            }
            else if (string.Equals(parameter.Name, "subscriptionId", StringComparison.InvariantCultureIgnoreCase) && !isAncestorResourceTypeTenant)
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
