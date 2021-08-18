// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Resource = AutoRest.CSharp.Mgmt.Output.Resource;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceWriter : MgmtClientBaseWriter
    {
        private CodeWriter _writer;
        private Resource _resource;
        private BuildContext<MgmtOutputLibrary> _context;
        private ResourceData _resourceData;
        private bool _inheritArmResourceBase = false;
        private bool _isITaggableResource = false;
        private bool _isDeletableResource = false;

        protected virtual Type BaseClass => typeof(ArmResource);

        protected override string ContextProperty => "this";

        protected CSharpType TypeOfThis => _resource.Type;
        protected override string TypeNameOfThis => TypeOfThis.Name;

        public ResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            _resource = resource;
            _context = context;
            _resourceData = _context.Library.GetResourceData(_resource.OperationGroup);
        }

        public void WriteResource()
        {
            var config = _context.Configuration.MgmtConfiguration;
            var isSingleton = _resource.OperationGroup.IsSingletonResource(config);
            var baseClass = typeof(ArmResource);
            WriteUsings(_writer);

            using (_writer.Namespace(TypeOfThis.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"{_resource.Description}");
                _writer.Append($"{_resource.Declaration.Accessibility} partial class {TypeNameOfThis}: ");

                _inheritArmResourceBase = _resource.GetMethod != null;
                CSharpType type = new CSharpType(baseClass);
                _writer.Append($"{type}, ");

                if (_resource.GetMethod == null && baseClass == typeof(ArmResource))
                    ErrorHelpers.ThrowError($@"Get operation is missing for '{TypeOfThis.Name}' resource under operation group '{_resource.OperationGroup.Key}'.
Check the swagger definition, and use 'operation-group-to-resource' directive to specify the correct resource if necessary.");

                CSharpType inheritType = new CSharpType(typeof(TrackedResource));
                if (_resourceData.Inherits != null && _resourceData.Inherits.Name == inheritType.Name)
                {
                    _isITaggableResource = true;
                }

                var httpMethodsMap = _resource.OperationGroup.OperationHttpMethodMapping();
                httpMethodsMap.TryGetValue(HttpMethod.Delete, out var deleteMethods);
                if (deleteMethods != null && deleteMethods.Count > 0)
                {
                    _isDeletableResource = true;
                }
                _writer.RemoveTrailingCharacter();

                using (_writer.Scope())
                {
                    WriteClientFields(_resource.RestClient, isSingleton);
                    if (!isSingleton)
                    {
                        WriteChildRestClients();
                    }
                    WriteClientCtors(isSingleton);
                    WriteClientProperties(_context.Configuration.MgmtConfiguration, isSingleton);
                    // TODO Write singleton operations
                    if (!isSingleton)
                    {
                        WriteClientMethods();
                    }
                    else
                    {
                        WriteChildSingletonGetOperationMethods();
                    }
                }
            }
        }

        private void WriteClientFields(RestClient client, bool isSingleton)
        {
            if (!isSingleton)
            {
                WriteFields(_writer, client);
            }
            _writer.Line($"private readonly {_resourceData.Type} _data;");
        }

        private void WriteChildRestClients()
        {
            foreach (var operationGroup in _resource.ChildOperations.Keys)
            {
                _writer.Append($"private {_context.Library.GetRestClient(operationGroup).Type} {GetRestClientName(operationGroup)}").LineRaw(" { get; }");
            }
        }

        private void WriteClientCtors(bool isSingleton = false)
        {
            _writer.Line();
            // write an internal default constructor
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
            if (!string.IsNullOrEmpty(baseConstructorCall) && isSingleton)
            {
                baseConstructorCall = $" : base(options, {typeof(ResourceIdentifier)}.RootResourceIdentifier)";
            }
            using (_writer.Scope($"internal {TypeOfThis.Name}({typeof(ArmResource)} options, {_resourceData.Type} resource){baseConstructorCall}"))
            {
                _writer.Line($"HasData = true;");
                _writer.Line($"_data = resource;");
                if (!isSingleton)
                {
                    _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                    var subscriptionParamString = _resource.RestClient.Parameters.Any(p => p.Name.Equals("subscriptionId")) ? ", Id.SubscriptionId" : string.Empty;
                    _writer.Line($"{RestClientField} = new {_resource.RestClient.Type}({ClientDiagnosticsField}, {PipelineProperty}{subscriptionParamString}, BaseUri);");
                    foreach (var operationGroup in _resource.ChildOperations.Keys)
                    {
                        _writer.Line($"{GetRestClientName(operationGroup)} = new {_context.Library.GetRestClient(operationGroup).Type}({ClientDiagnosticsField}, {PipelineProperty}{subscriptionParamString}, BaseUri);");
                    }
                }
            }

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{TypeOfThis.Name}\"/> class.");
            _writer.WriteXmlDocumentationParameter("options", $"The client parameters to use in these operations.");
            if (!isSingleton)
            {
                _writer.WriteXmlDocumentationParameter("id", $"The identifier of the resource that is the target of operations.");
            }
            var constructorIdParam = isSingleton ? "" : $", {_resource.ResourceIdentifierType} id";
            baseConstructorCall = isSingleton ? $"base(options, {typeof(ResourceIdentifier)}.RootResourceIdentifier)" : "base(options, id)";
            using (_writer.Scope($"internal {TypeOfThis.Name}({typeof(ArmResource)} options{constructorIdParam}) : {baseConstructorCall}"))
            {
                if (!isSingleton)
                {
                    _writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                    var subscriptionParamString = _resource.RestClient.Parameters.Any(p => p.Name.Equals("subscriptionId")) ? ", Id.SubscriptionId" : string.Empty;
                    _writer.Line($"{RestClientField} = new {_resource.RestClient.Type}({ClientDiagnosticsField}, {PipelineProperty}{subscriptionParamString}, BaseUri);");
                    foreach (var operationGroup in _resource.ChildOperations.Keys)
                    {
                        _writer.Line($"{GetRestClientName(operationGroup)} = new {_context.Library.GetRestClient(operationGroup).Type}({ClientDiagnosticsField}, {PipelineProperty}{subscriptionParamString}, BaseUri);");
                    }
                }
            }
        }

        private void WriteClientProperties(MgmtConfiguration config, bool isSingleton)
        {
            if (isSingleton)
            {
                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Gets the parent resource of this resource.");
                _writer.Line($"public {typeof(ArmResource)} Parent {{ get; }}");
            }
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");
            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{_resource.OperationGroup.ResourceType(config)}\";");
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
        }

        private void WriteClientMethods()
        {
            var clientMethodsList = new List<RestClientMethod>();

            _writer.Line();
            if (_inheritArmResourceBase && _resource.GetMethod != null)
            {
                // write inherited get method
                WriteGetMethod(_resource.GetMethod, true, _resource.GetMethods, "Get");
                WriteGetMethod(_resource.GetMethod, false, _resource.GetMethods, "Get");

                clientMethodsList.AddRange(_resource.GetMethods.Select(m => m.RestClientMethod).ToList());

                WriteListAvailableLocationsMethod(true);
                WriteListAvailableLocationsMethod(false);
            }

            if (_isDeletableResource)
            {
                var deleteMethod = _resource.RestClient.Methods.Where(m => m.IsDelete && m.Parameters.FirstOrDefault()?.Name.Equals("scope") == true).FirstOrDefault() ?? _resource.RestClient.Methods.Where(m => m.IsDelete).OrderBy(m => m.Name.Length).FirstOrDefault();
                var deleteMethods = _resource.IsScopeOrExtension ? _resource.RestClient.Methods.Where(m => m.IsDelete).ToList() : new List<RestClientMethod> { deleteMethod };
                // write delete method
                WriteFirstLROMethod(_writer, deleteMethod, _context, true, true, "Delete");
                WriteFirstLROMethod(_writer, deleteMethod, _context, false, true, "Delete");

                WriteStartLROMethod(_writer, deleteMethod, _context, true, true, "Delete", deleteMethods);
                WriteStartLROMethod(_writer, deleteMethod, _context, false, true, "Delete", deleteMethods);
                clientMethodsList.AddRange(deleteMethods);
            }

            if (_isITaggableResource)
            {
                // write update method
                WriteAddTagMethod();
                WriteSetTagsMethod();
                WriteRemoveTagMethod();
            }

            // 1. Listing myself at parent scope -> on the container named list
            // 2. Listing myself at ancestor scope -> extension method if the ancestor is not in this RP, or follow #3 by listing myself as the children of the ancestor in the operations of the ancestor
            // 3. Listing children (might be resource or not) -> on the operations

            // write rest of the methods
            var resourceContainer = _context.Library.GetResourceContainer(_resource.OperationGroup);
            foreach (var clientMethod in _resource.ResourceClientMethods)
            {
                if (!clientMethodsList.Contains(clientMethod.RestClientMethod))
                {
                    WriteClientMethod(_writer, clientMethod, clientMethod.Name, clientMethod.Diagnostics, _resource.OperationGroup, _context, true);
                    WriteClientMethod(_writer, clientMethod, clientMethod.Name, clientMethod.Diagnostics, _resource.OperationGroup, _context, false);
                }
            }

            // write paging methods
            foreach (var listMethod in _resource.ResourceListMethods)
            {
                if (listMethod.PagingMethod != null)
                {
                    WritePagingMethod(_resource.OperationGroup, listMethod.PagingMethod, listMethod.PagingMethod.Diagnostics, listMethod.PagingMethod.Name, RestClientField, false);
                    WritePagingMethod(_resource.OperationGroup, listMethod.PagingMethod, listMethod.PagingMethod.Diagnostics, listMethod.PagingMethod.Name, RestClientField, true);
                }
            }

            // write child methods
            foreach (var pair in _resource.ChildOperations)
            {
                var restClientName = GetRestClientName(pair.Key);
                foreach (var clientMethod in pair.Value.ClientMethods)
                {
                    var originalName = clientMethod.Name;
                    var methodName = originalName.EndsWith($"By{TypeOfThis.Name}") ? originalName.Substring(0, originalName.IndexOf("By")) : originalName;
                    Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WriteClientMethod(_writer, clientMethod, methodName, diagnostic, pair.Key, _context, true, restClientName);
                    WriteClientMethod(_writer, clientMethod, methodName, diagnostic, pair.Key, _context, false, restClientName);
                }
                foreach (var pagingMethod in pair.Value.PagingMethods)
                {
                    var originalName = pagingMethod.Name;
                    var methodName = originalName.EndsWith($"By{TypeOfThis.Name}") ? originalName.Substring(0, originalName.IndexOf("By")) : originalName;
                    Diagnostic diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                    WritePagingMethod(pair.Key, pagingMethod, diagnostic, methodName, GetRestClientName(pair.Key), false);
                    WritePagingMethod(pair.Key, pagingMethod, diagnostic, methodName, GetRestClientName(pair.Key), true);
                }
            }

            // write rest of the LRO methods
            var mergedMethods = new Dictionary<string, List<RestClientMethod>>();
            foreach (var clientMethod in _resource.ResourceLROMethods)
            {
                if (!clientMethodsList.Contains(clientMethod))
                {
                    if (_context.Library.TryGetMethodForMergedOperation($"{_resource.OperationGroup.Key}_{clientMethod.Name}_{clientMethod.Request.HttpMethod}", out var mergedMethodName))
                    {
                        if (mergedMethods.TryGetValue(mergedMethodName, out var methods))
                        {
                            methods.Add(clientMethod);
                        }
                        else
                        {
                            mergedMethods.Add(mergedMethodName, new List<RestClientMethod> { clientMethod });
                        }
                        continue;
                    }
                    WriteLRO(clientMethod);
                }
            }

            foreach (var kv in mergedMethods)
            {
                WriteLRO(kv.Value.OrderBy(m => m.Name.Length).First(), kv.Key, kv.Value);
            }

            foreach (var item in _context.CodeModel.OperationGroups)
            {
                if (item.ParentResourceType(_context.Configuration.MgmtConfiguration).Equals(_resource.OperationGroup.ResourceType(_context.Configuration.MgmtConfiguration))
                    && !item.IsSingletonResource(_context.Configuration.MgmtConfiguration))
                {
                    var container = _context.Library.GetResourceContainer(item);
                    if (container == null)
                        continue;
                    _writer.Line();
                    _writer.WriteXmlDocumentationSummary($"Gets a list of {container.ResourceName.ToPlural()} in the {_resource.ResourceName}.");
                    _writer.WriteXmlDocumentationReturns($"An object representing collection of {container.ResourceName.ToPlural()} and their operations over a {_resource.ResourceName}.");
                    using (_writer.Scope($"public {container.Type} Get{container.ResourceName.ToPlural()}()"))
                    {
                        _writer.Line($"return new {container.Type}(this);");
                    }
                }
            }
        }

        private void WritePagingMethod(OperationGroup operationGroup, PagingMethod pagingMethod, Diagnostic diagnostic, string clientMethodName, string restClientName, bool async)
        {
            _writer.Line();
            var nonPathParameters = pagingMethod.Method.NonPathParameters;

            _writer.WriteXmlDocumentationSummary($"{pagingMethod.Method.Description}");
            foreach (var param in nonPathParameters)
            {
                _writer.WriteXmlDocumentationParameter(param);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");

            CSharpType itemType = pagingMethod.PagingResponse.ItemType;
            FormattableString returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{itemType.Name}\" /> that may take multiple service requests to iterate over.";
            _writer.WriteXmlDocumentationReturns(returnText);

            var returnType = itemType.WrapPageable(async);

            var methodName = CreateMethodName(clientMethodName, async);
            _writer.Append($"public virtual {returnType} {methodName}(");
            foreach (var param in nonPathParameters)
            {
                _writer.WriteParameter(param);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (_writer.Scope())
            {
                WritePagingOperationBody(_writer, pagingMethod, itemType, restClientName, diagnostic,
                    ClientDiagnosticsField, $"", async);
            }
        }

        private string GetRestClientName(OperationGroup operationGroup)
        {
            return $"_{operationGroup.Key.ToVariableName()}RestClient";
        }

        private void WriteGetMethod(ClientMethod method, bool async, List<ClientMethod> methods, string? methodName = null)
        {
            methodName = methodName ?? method.Name;
            _writer.Line();
            var nonPathParameters = method.RestClientMethod.NonPathParameters;
            _writer.WriteXmlDocumentationSummary($"{method.Description}");
            foreach (Parameter parameter in nonPathParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            var responseType = TypeOfThis.WrapResponse(async);
            _writer.Append($"public {GetAsyncKeyword(async)} {GetOverride(false, true)} {responseType} {CreateMethodName($"{methodName}", async)}(");

            foreach (Parameter parameter in nonPathParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(nonPathParameters);

                WriteDiagnosticScope(_writer, method.Diagnostics, ClientDiagnosticsField, _writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    response.SetActualName(response.RequestedName);
                    if (method.RestClientMethod.Operation.IsAncestorScope() || methods.Count < 2)
                    {
                        WriteGetMethodBody(method, response, async, nonPathParameters);
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
                            using (_writer.Scope($"if (Id.TryGetResourceGroupName(out {resourceGroupNameVar}))"))
                            {
                                if (resourceMethod != null)
                                {
                                    using (_writer.Scope($"if (Id.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                                    {
                                        WriteGetMethodBody(resourceGroupMethod, response, async, resourceGroupMethod.RestClientMethod.NonPathParameters);
                                    }
                                    using (_writer.Scope($"else"))
                                    {
                                        WriteGetMethodBody(resourceMethod, response, async, resourceMethod.RestClientMethod.NonPathParameters, isResourceLevel: true);
                                    }
                                }
                                else
                                {
                                    WriteGetMethodBody(resourceGroupMethod, response, async, resourceGroupMethod.RestClientMethod.NonPathParameters);
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
                            using (_writer.Scope($"{elseStr} (Id.TryGetSubscriptionId(out _))"))
                            {
                                WriteGetMethodBody(subscriptionMethod, response, async, subscriptionMethod.RestClientMethod.NonPathParameters);
                            }
                        }

                        elseStr = (!elseStr.IsNullOrEmpty() || subscriptionMethod != null) ? "else " : string.Empty;
                        if (managementGroupMethod != null)
                        {
                            methodDict.Remove(managementGroupMethod);
                            using (elseStr.IsNullOrEmpty() ? null : _writer.Scope($"{elseStr}"))
                            {
                                if (tenantMethod != null)
                                {
                                    methodDict.Remove(tenantMethod);
                                    var parent = new CodeWriterDeclaration("parent");
                                    _writer.Line($"var {parent:D} = Id;");
                                    using (_writer.Scope($"while ({parent}.Parent != {typeof(ResourceIdentifier)}.RootResourceIdentifier)"))
                                    {
                                        _writer.Line($"{parent} = {parent}.Parent;");
                                    }
                                    using (_writer.Scope($"if (parent.ResourceType.Equals({typeof(ManagementGroup)}.ResourceType))"))
                                    {
                                        WriteGetMethodBody(managementGroupMethod, response, async, managementGroupMethod.RestClientMethod.NonPathParameters);
                                    }
                                    using (_writer.Scope($"else"))
                                    {
                                        WriteGetMethodBody(tenantMethod, response, async, tenantMethod.RestClientMethod.NonPathParameters);
                                    }
                                }
                                else
                                {
                                    WriteGetMethodBody(managementGroupMethod, response, async, managementGroupMethod.RestClientMethod.NonPathParameters);
                                }
                            }
                        }
                        else if (tenantMethod != null)
                        {
                            methodDict.Remove(tenantMethod);
                            using (_writer.Scope($"{elseStr}"))
                            {
                                WriteGetMethodBody(tenantMethod, response, async, tenantMethod.RestClientMethod.NonPathParameters);
                            }
                        }

                        if (methodDict.Count() > 0)
                        {
                            throw new Exception($"When trying to merge methods, multiple methods can be mapped to the same scope. The methods not handled: {String.Join(", ", methodDict.Select(kv => kv.Key.Name).ToList())}.");
                        }
                    }
                });
                _writer.Line();
            }
        }

        private void WriteGetMethodBody(ClientMethod clientMethod, CodeWriterDeclaration response, bool async, List<Parameter> nonPathParameters, bool isResourceLevel = false)
        {
            if (isResourceLevel)
            {
                _writer.UseNamespace("System.Collections.Generic");
                _writer.Line($"var parent = Id.Parent;");
                _writer.Line($"var parentParts = new List<string>();");
                using (_writer.Scope($"while (!parent.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                {
                    _writer.Line($"parentParts.Insert(0, $\"{{parent.ResourceType.Types[parent.ResourceType.Types.Count - 1]}}/{{parent.Name}}\");");
                    _writer.Line($"parent = parent.Parent;");
                }
                _writer.Line($"var parentResourcePath = parentParts.Count > 0 ? string.Join(\"/\", parentParts) : \"\";");
                _writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
            }
            _writer.Append($"var {response} = ");
            if (async)
            {
                _writer.Append($"await ");
            }
            _writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}( ");
            BuildAndWriteParameters(_writer, clientMethod.RestClientMethod, isResourceLevel: isResourceLevel);
            _writer.Append($"cancellationToken)");

            if (async)
            {
                _writer.Append($".ConfigureAwait(false)");
            }
            _writer.Line($";");
            WriteEndOfGet(_writer, TypeOfThis, async);
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

        private void WriteAddTagMethod()
        {
            WriteAddTag(true);
            WriteAddTag(false);
        }

        private void WriteAddTag(bool async)
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

        private void WriteSetTagsMethod()
        {
            WriteSetTags(true);
            WriteSetTags(false);
        }

        private void WriteSetTags(bool async)
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
                    _writer.Line($"TagResource.{CreateMethodName("Delete", async)}(cancellationToken){GetConfigureAwait(async)};");
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

        private void WriteRemoveTagMethod()
        {
            WriteRemoveTag(true);
            WriteRemoveTag(false);
        }

        private void WriteRemoveTag(bool async)
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
            if (async)
            {
                _writer.Append($"await ");
            }
            _writer.Line($"TagContainer.{CreateMethodName("CreateOrUpdate", async)}(originalTags.Value.Data, cancellationToken){GetConfigureAwait(async)};");
            _writer.Append($"var originalResponse = ");
            if (async)
            {
                _writer.Append($"await ");
            }
#pragma warning disable CS8602
            var pathParamNames = GetPathParametersName(_resource.GetMethod.RestClientMethod, _resource.OperationGroup, _context).ToList();
#pragma warning restore CS8602
            _writer.Append($"{RestClientField}.{CreateMethodName(_resource.GetMethod.Name, async)}( ");
            foreach (string paramNames in pathParamNames)
            {
                _writer.Append($"{paramNames:I}, ");
            }
            foreach (Parameter parameter in _resource.GetMethod.RestClientMethod.NonPathParameters)
            {
                if (parameter.ValidateNotNull)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                else
                {
                    _writer.Append($"null, ");
                }
            }
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");
            _writer.Line($"return {typeof(Response)}.FromValue(new {TypeOfThis}(this, originalResponse.Value), originalResponse.GetRawResponse());");
        }

        private void WriteLRO(RestClientMethod clientMethod, string? methodName = null, List<RestClientMethod>? clientMethods = null)
        {
            WriteFirstLROMethod(_writer, clientMethod, _context, true, true, methodName: methodName);
            WriteFirstLROMethod(_writer, clientMethod, _context, false, true, methodName: methodName);

            WriteStartLROMethod(_writer, clientMethod, _context, true, true, methodName: methodName, methods: clientMethods);
            WriteStartLROMethod(_writer, clientMethod, _context, false, true, methodName: methodName, methods: clientMethods);
        }

        private void WriteChildSingletonGetOperationMethods()
        {
            var config = _context.Configuration.MgmtConfiguration;
            foreach (var operation in _context.Library.ArmResources)
            {
                if (operation.OperationGroup.IsSingletonResource(config)
                    && operation.OperationGroup.ParentResourceType(config).Equals(_resource.OperationGroup.ResourceType(config)))
                {
                    _writer.Line($"#region Get {operation.Type.Name}s operation");

                    _writer.WriteXmlDocumentationSummary($"Gets an object representing a {operation.Type.Name} along with the instance operations that can be performed on it.");
                    _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{operation.Type.Name}\" /> object.");
                    using (_writer.Scope($"public {operation.Type} Get{operation.Type.Name}s()"))
                    {
                        _writer.Line($"return new {operation.Type.Name}(this);");
                    }
                    _writer.LineRaw("#endregion");
                    _writer.Line();
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
            var isAncestorResourceTypeTenant = _resource.OperationGroup.IsAncestorResourceTypeTenant(_context);
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
