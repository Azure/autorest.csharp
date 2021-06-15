// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Generation.Writers;
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
        protected virtual Type BaseClass => typeof(ResourceOperationsBase);

        private bool _inheritResourceOperationsBase = false;
        private bool _isITaggableResource = false;
        private bool _isDeletableResource = false;
        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            var isSingleton = resourceOperation.OperationGroup.IsSingletonResource(config);
            var baseClass = isSingleton ? typeof(SingletonOperationsBase) : typeof(ResourceOperationsBase);
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);

                var operationGroup = resourceOperation.OperationGroup;
                var resource = context.Library.GetArmResource(operationGroup);
                var resourceData = context.Library.GetResourceData(operationGroup);
                writer.Append($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name}: ");

                _inheritResourceOperationsBase = resourceOperation.GetMethod != null;
                CSharpType[] arguments = { resourceOperation.ResourceIdentifierType, resource.Type };
                CSharpType type = new CSharpType(baseClass, arguments);
                writer.Append($"{type}, ");

                if (resourceOperation.GetMethod == null && baseClass == typeof(ResourceOperationsBase))
                    throw new Exception($"Get operation is missing for {resource.Type.Name} resource.");

                CSharpType inheritType = new CSharpType(typeof(TrackedResource<>), resourceOperation.ResourceIdentifierType);
                if (resourceData.Inherits != null && resourceData.Inherits.Name == inheritType.Name)
                {
                    _isITaggableResource = true;
                }

                var httpMethodsMap = resourceOperation.OperationGroup.OperationHttpMethodMapping();
                httpMethodsMap.TryGetValue(HttpMethod.Delete, out var deleteMethods);
                if (deleteMethods != null && deleteMethods.Count > 0)
                {
                    _isDeletableResource = true;
                }
                writer.RemoveTrailingCharacter();

                using (writer.Scope())
                {
                    if (!isSingleton)
                    {
                        WriteClientFields(writer, resourceOperation.RestClient, false);
                    }
                    WriteClientCtors(writer, resourceOperation, isSingleton);
                    WriteClientProperties(writer, resourceOperation, context.Configuration.MgmtConfiguration);
                    // TODO Write singleton operations
                    if (!isSingleton)
                    {
                        WriteClientMethods(writer, resourceOperation, resource, resourceData, context);
                    }
                    else
                    {
                        WriteChildSingletonGetOperationMethods(writer, resourceOperation, context);
                    }
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation, bool isSingleton = false)
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
            using (writer.Scope($"protected internal {typeOfThis}({typeof(ResourceOperationsBase)} options{constructorIdParam}) : {baseConstructorCall}"))
            {
                if (!isSingleton)
                {
                    writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                    var subscriptionValue = "Id.SubscriptionId";
                    if (resourceOperation.ResourceIdentifierType == typeof(TenantResourceIdentifier))
                    {
                        subscriptionValue = "subscriptionId";
                        writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
                    }
                    writer.Line($"{RestClientField} = new {resourceOperation.RestClient.Type}({ClientDiagnosticsField}, {PipelineProperty}, {subscriptionValue}, BaseUri);");
                }
            }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation, MgmtConfiguration config)
        {
            writer.Line();
            writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{resourceOperation.OperationGroup.ResourceType(config)}\";");
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

                var nonPathParameters = GetNonPathParameters(resourceOperation.GetMethod.RestClientMethod);
                if (nonPathParameters.Length > 0)
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
                WriteFirstLROMethod(writer, deleteMethod, resourceOperation, context, true);
                WriteFirstLROMethod(writer, deleteMethod, resourceOperation, context, false);

                WriteStartLROMethod(writer, deleteMethod, resourceOperation, context, true);
                WriteStartLROMethod(writer, deleteMethod, resourceOperation, context, false);
                clientMethodsList.Add(deleteMethod);
            }

            if (_isITaggableResource)
            {
                var updateMethods = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Patch);
                if (updateMethods == null || updateMethods.Count() == 0)
                {
                    updateMethods = resourceOperation.RestClient.Methods.Where(m => m.Request.HttpMethod == RequestMethod.Put);
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

            // write rest of the methods
            foreach (var clientMethod in resourceOperation.Methods)
            {
                if (!clientMethodsList.Contains(clientMethod.RestClientMethod) &&
                    clientMethod.RestClientMethod.Request.HttpMethod != RequestMethod.Put &&
                    !clientMethod.Name.StartsWith("List"))
                {
                    WriteClientMethod(writer, clientMethod.RestClientMethod, clientMethod.Diagnostics, resourceOperation.OperationGroup, context, true);
                    WriteClientMethod(writer, clientMethod.RestClientMethod, clientMethod.Diagnostics, resourceOperation.OperationGroup, context, false);
                }
            }

            // write rest of the LRO methods
            foreach (var clientMethod in resourceOperation.RestClient.Methods)
            {
                if (clientMethod.Operation != null && clientMethod.Operation.IsLongRunning &&
                    !clientMethodsList.Contains(clientMethod) && clientMethod.Request.HttpMethod != RequestMethod.Put)
                {
                    WriteLRO(writer, clientMethod, resourceOperation, context);
                }
            }

            foreach (var item in context.CodeModel.OperationGroups)
            {
                if (item.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(resourceOperation.OperationGroup.ResourceType(context.Configuration.MgmtConfiguration))
                    && !item.IsSingletonResource(context.Configuration.MgmtConfiguration))
                {
                    var container = context.Library.ResourceContainers.FirstOrDefault(x => x.ResourceName.Equals(item.Resource(context.Configuration.MgmtConfiguration)));
                    if (container == null)
                        return;
                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Gets a list of {container.ResourceName} in the {resourceOperation.ResourceName}.");
                    writer.WriteXmlDocumentationReturns($"An object representing collection of {StringExtensions.Pluralization(container.ResourceName)} and their operations over a {resourceOperation.ResourceName}.");
                    using (writer.Scope($"public {container.Type} Get{StringExtensions.Pluralization(container.ResourceName)}()"))
                    {
                        writer.Line($"return new {container.Type}(this);");
                    }
                }
            }
        }

        private void WriteGetMethod(CodeWriter writer, ClientMethod clientMethod, Resource resource, BuildContext<MgmtOutputLibrary> context, bool isInheritedMethod, bool async)
        {
            writer.Line();
            Parameter[] nonPathParameters = GetNonPathParameters(clientMethod.RestClientMethod);
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
            CSharpType responseType = new CSharpType(typeof(Azure.Response<>), resource.Type);
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;
            var asyncText = async ? "async" : string.Empty;
            var overrideText = isInheritedMethod ? "override" : string.Empty;
            writer.Append($"public {asyncText} {overrideText} {responseType} {CreateMethodName("Get", async)}(");

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
            writer.WriteXmlDocumentationReturns("A collection of location that may take multiple service requests to iterate over.");

            CSharpType responseType = new CSharpType(typeof(IEnumerable<LocationData>));
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;
            var asyncText = async ? "async" : string.Empty;
            var awaitText = async ? "await" : string.Empty;
            using (writer.Scope($"public {asyncText} {responseType} {CreateMethodName("ListAvailableLocations", async)}({typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"return {awaitText} {CreateMethodName("ListAvailableLocations", async)}(ResourceType, cancellationToken)");
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

            WriteStartAddTag(writer, resourceOperation, clientMethod, context, true);
            WriteStartAddTag(writer, resourceOperation, clientMethod, context, false);
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
            CSharpType responseType = new CSharpType(typeof(Response<>), resource.Type);
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName("AddTag", async)}(string key, string value, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.AddTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var operation = new CodeWriterDeclaration("operation");
                    writer.Append($"var {operation:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{CreateMethodName("StartAddTag", async)}(key, value, cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Append($"return ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{operation}.{CreateMethodName("WaitForCompletion", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                });
                writer.Line();
            }
        }

        private void WriteStartAddTag(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            Debug.Assert(clientMethod.Operation != null);
            writer.Line();
            writer.WriteXmlDocumentationSummary("Add a tag to the current resource.");
            writer.WriteXmlDocumentationParameter("key", "The key for the tag.");
            writer.WriteXmlDocumentationParameter("value", "The value for the tag.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tag added.");
            writer.WriteXmlDocumentation("remarks", "<see href=\"https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning\">Details on long running operation object.</see>");

            CSharpType lroObjectType = clientMethod.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;
            CSharpType responseType = async ? new CSharpType(typeof(Task<>), lroObjectType) : lroObjectType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName("StartAddTag", async)}(string key, string value, {typeof(CancellationToken)} cancellationToken = default) ");
            using (writer.Scope())
            {
                using (writer.Scope($"if (key == null)"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}(nameof(key));");
                }

                writer.Line();
                Diagnostic diagnostic = new Diagnostic($"{ resourceOperation.Type.Name}.StartAddTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var updateParameterType = GetNonPathParameters(clientMethod).FirstOrDefault().Type;
                    var resourceVar = new CodeWriterDeclaration("resource");
                    writer.Line($"var {resourceVar:D} = GetResource();");
                    var patchable = new CodeWriterDeclaration("patchable");
                    if (clientMethod.Request.HttpMethod == RequestMethod.Put)
                    {
                        writer.Line($"Id.TryGetLocation(out LocationData locationData);");
                    }
                    writer.Append($"var {patchable:D} = new {updateParameterType}(");
                    if (clientMethod.Request.HttpMethod == RequestMethod.Put)
                    {
                        writer.Append($"locationData");
                    }
                    writer.Line($");");
                    writer.Line($"{patchable}.Tags.ReplaceWith({resourceVar}.Data.Tags);");
                    writer.Line($"{patchable}.Tags[key] = value;");

                    WriteTaggableMethodRestCall(writer, resourceOperation, clientMethod, context, lroObjectType, async);
                });
                writer.Line();
            }
        }

        private void WriteSetTagsMethod(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            WriteSetTags(writer, resourceOperation, clientMethod, context, true);
            WriteSetTags(writer, resourceOperation, clientMethod, context, false);

            WriteStartSetTags(writer, resourceOperation, clientMethod, context, true);
            WriteStartSetTags(writer, resourceOperation, clientMethod, context, false);
        }

        private void WriteSetTags(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary("Replace the tags on the resource with the given set.");
            writer.WriteXmlDocumentationParameter("tags", "The set of tags to use as replacement.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tags replaced.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            CSharpType responseType = new CSharpType(typeof(Response<>), resource.Type);
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName("SetTags", async)}({typeof(IDictionary<string, string>)} tags, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.SetTags", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var operation = new CodeWriterDeclaration("operation");
                    writer.Append($"var {operation:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{CreateMethodName("StartSetTags", async)}(tags, cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Append($"return ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{operation}.{CreateMethodName("WaitForCompletion", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                });
                writer.Line();
            }
        }

        private void WriteStartSetTags(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            Debug.Assert(clientMethod.Operation != null);
            writer.Line();
            writer.WriteXmlDocumentationSummary("Replace the tags on the resource with the given set.");
            writer.WriteXmlDocumentationParameter("tags", "The set of tags to use as replacement.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tags replaced.");
            writer.WriteXmlDocumentation("remarks", "<see href=\"https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning\">Details on long running operation object.</see>");

            CSharpType lroObjectType = clientMethod.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;
            CSharpType responseType = async ? new CSharpType(typeof(Task<>), lroObjectType) : lroObjectType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName("StartSetTags", async)}({typeof(IDictionary<string, string>)} tags, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                using (writer.Scope($"if (tags == null)"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}(nameof(tags));");
                }
                writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.StartSetTags", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var updateParameterType = GetNonPathParameters(clientMethod).FirstOrDefault().Type;
                    var patchable = new CodeWriterDeclaration("patchable");
                    if (clientMethod.Request.HttpMethod == RequestMethod.Put)
                    {
                        writer.Line($"Id.TryGetLocation(out LocationData locationData);");
                    }
                    writer.Append($"var {patchable:D} = new {updateParameterType}(");
                    if (clientMethod.Request.HttpMethod == RequestMethod.Put)
                    {
                        writer.Append($"locationData");
                    }
                    writer.Line($");");
                    writer.Line($"{patchable}.Tags.ReplaceWith(tags);");

                    WriteTaggableMethodRestCall(writer, resourceOperation, clientMethod, context, lroObjectType, async);
                });
                writer.Line();
            }
        }

        private void WriteRemoveTagMethod(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            WriteRemoveTag(writer, resourceOperation, clientMethod, context, true);
            WriteRemoveTag(writer, resourceOperation, clientMethod, context, false);

            WriteStartRemoveTag(writer, resourceOperation, clientMethod, context, true);
            WriteStartRemoveTag(writer, resourceOperation, clientMethod, context, false);
        }

        private void WriteRemoveTag(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary("Removes a tag by key from the resource.");
            writer.WriteXmlDocumentationParameter("key", "The key of the tag to remove.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tag removed.");

            var resource = context.Library.GetArmResource(resourceOperation.OperationGroup);
            CSharpType responseType = new CSharpType(typeof(Response<>), resource.Type);
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName("RemoveTag", async)}(string key, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.RemoveTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var operation = new CodeWriterDeclaration("operation");
                    writer.Append($"var {operation:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{CreateMethodName("StartRemoveTag", async)}(key, cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Append($"return ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{operation}.{CreateMethodName("WaitForCompletion", async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                });
                writer.Line();
            }
        }

        private void WriteStartRemoveTag(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            Debug.Assert(clientMethod.Operation != null);
            writer.Line();
            writer.WriteXmlDocumentationSummary("Removes a tag by key from the resource.");
            writer.WriteXmlDocumentationParameter("key", "The key of the tag to remove.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"CancellationToken.None\" />.");
            writer.WriteXmlDocumentationReturns("The updated resource with the tag removed.");
            writer.WriteXmlDocumentation("remarks", "<see href=\"https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning\">Details on long running operation object.</see>");

            CSharpType lroObjectType = clientMethod.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;
            CSharpType responseType = async ? new CSharpType(typeof(Task<>), lroObjectType) : lroObjectType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName("StartRemoveTag", async)}(string key, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                using (writer.Scope($"if (key == null)"))
                {
                    writer.Line($"throw new {typeof(ArgumentNullException)}(nameof(key));");
                }
                writer.Line();

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.StartRemoveTag", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var updateParameterType = GetNonPathParameters(clientMethod).FirstOrDefault().Type;
                    var resourceVar = new CodeWriterDeclaration("resource");
                    writer.Line($"var {resourceVar:D} = GetResource();");
                    var patchable = new CodeWriterDeclaration("patchable");
                    if (clientMethod.Request.HttpMethod == RequestMethod.Put)
                    {
                        writer.Line($"Id.TryGetLocation(out LocationData locationData);");
                    }
                    writer.Append($"var {patchable:D} = new {updateParameterType}(");
                    if (clientMethod.Request.HttpMethod == RequestMethod.Put)
                    {
                        writer.Append($"locationData");
                    }
                    writer.Line($");");
                    writer.Line($"{patchable}.Tags.ReplaceWith({resourceVar}.Data.Tags);");
                    writer.Line($"{patchable}.Tags.Remove(key);");

                    WriteTaggableMethodRestCall(writer, resourceOperation, clientMethod, context, lroObjectType, async);
                });
                writer.Line();
            }
        }

        private void WriteTaggableMethodRestCall(CodeWriter writer, ResourceOperation resourceOperation, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, CSharpType lroObjectType, bool async)
        {
            var pathParamNames = GetPathParametersName(clientMethod, resourceOperation.OperationGroup, context);
            var response = new CodeWriterDeclaration("response");
            writer.Append($"var {response:D} = ");
            if (async)
            {
                writer.Append($"await ");
            }

            writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}( ");
            foreach (string paramNames in pathParamNames)
            {
                writer.Append($"{paramNames:I}, ");
            }
            writer.Append($"patchable, cancellationToken)");
            if (async)
            {
                writer.Append($".ConfigureAwait(false)");
            }
            writer.Line($";");

            var parameters = pathParamNames.ToList();
            parameters.Add("patchable");
            WriteStartLROResponse(writer, clientMethod, context, response, parameters.ToArray());
        }

        private void WriteLRO(CodeWriter writer, RestClientMethod clientMethod, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context)
        {
            WriteFirstLROMethod(writer, clientMethod, resourceOperation, context, true);
            WriteFirstLROMethod(writer, clientMethod, resourceOperation, context, false);

            WriteStartLROMethod(writer, clientMethod, resourceOperation, context, true);
            WriteStartLROMethod(writer, clientMethod, resourceOperation, context, false);
        }

        private void WriteFirstLROMethod(CodeWriter writer, RestClientMethod clientMethod, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            Debug.Assert(clientMethod.Operation != null);
            writer.Line();
            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            Parameter[] nonPathParameters = GetNonPathParameters(clientMethod);
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(nonPathParameters);

            CSharpType? returnType = GetLROReturnType(clientMethod, context);
            CSharpType responseType = returnType != null ?
                new CSharpType(typeof(Response<>), returnType) :
                typeof(Response);
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var asyncText = async ? "async" : string.Empty;

            writer.Append($"public {asyncText} {responseType} {CreateMethodName(clientMethod.Name, async)}(");
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(nonPathParameters);

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.{clientMethod.Name}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var operation = new CodeWriterDeclaration("operation");
                    writer.Append($"var {operation:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{CreateMethodName($"Start{clientMethod.Name}", async)}(");
                    foreach (Parameter parameter in nonPathParameters)
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                    writer.Append($"return ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    var waitForCompletionMethod = returnType == null && async ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
                    writer.Append($"{operation}.{CreateMethodName(waitForCompletionMethod, async)}(cancellationToken)");
                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");
                });
                writer.Line();
            }
        }

        private void WriteStartLROMethod(CodeWriter writer, RestClientMethod clientMethod, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            Debug.Assert(clientMethod.Operation != null);
            writer.Line();
            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            Parameter[] nonPathParameters = GetNonPathParameters(clientMethod);
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(nonPathParameters);

            CSharpType? returnType = GetLROReturnType(clientMethod, context);
            CSharpType lroObjectType = clientMethod.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;
            CSharpType responseType = returnType != null ?
                lroObjectType : typeof(Azure.Operation);
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {CreateMethodName($"Start{clientMethod.Name}", async)}(");
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(nonPathParameters);

                Diagnostic diagnostic = new Diagnostic($"{resourceOperation.Type.Name}.Start{clientMethod.Name}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    var parameterNames = GetParametersName(clientMethod, resourceOperation.OperationGroup, context);
                    writer.Append($"var {response:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}( ");
                    foreach (string paramNames in parameterNames)
                    {
                        writer.Append($"{paramNames:I}, ");
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");

                    WriteStartLROResponse(writer, clientMethod, context, response, parameterNames);
                });
                writer.Line();
            }
        }

        private void WriteStartLROResponse(CodeWriter writer, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, CodeWriterDeclaration response, string[] parameterNames)
        {
            Debug.Assert(clientMethod.Operation != null);

            CSharpType lroObjectType = clientMethod.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;

            writer.Append($"return new {lroObjectType}(");

            if (clientMethod.Operation.IsLongRunning)
            {
                LongRunningOperation operation = context.Library.GetLongRunningOperation(clientMethod.Operation);
                MgmtLongRunningOperation longRunningOperation = AsMgmtOperation(operation);
                if (longRunningOperation.WrapperType != null)
                {
                    writer.Append($"this, ");
                }
                writer.Append($"{ClientDiagnosticsField}, {PipelineProperty}, {RestClientField}.{RequestWriterHelpers.CreateRequestMethodName(clientMethod.Name)}(");
                foreach (string paramNames in parameterNames)
                {
                    writer.Append($"{paramNames:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Append($").Request, ");
            }
            else
            {
                NonLongRunningOperation nonLongRunningOperation = context.Library.GetNonLongRunningOperation(clientMethod.Operation);
                if (nonLongRunningOperation.ResultType != null)
                {
                    writer.Append($"this, ");
                }
            }
            writer.Append($"{response});");
        }

        private CSharpType? GetLROReturnType(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            Debug.Assert(clientMethod.Operation != null);

            CSharpType? returnType = null;
            if (clientMethod.Operation.IsLongRunning)
            {
                LongRunningOperation operation = context.Library.GetLongRunningOperation(clientMethod.Operation);
                MgmtLongRunningOperation longRunningOperation = AsMgmtOperation(operation);
                returnType = longRunningOperation.WrapperType != null ? longRunningOperation.WrapperType : longRunningOperation.ResultType;
            }
            else
            {
                NonLongRunningOperation nonLongRunningOperation = context.Library.GetNonLongRunningOperation(clientMethod.Operation);
                returnType = nonLongRunningOperation.ResultType;
            }

            return returnType;
        }

        private MgmtLongRunningOperation AsMgmtOperation(LongRunningOperation operation)
        {
            var mgmtOperation = operation as MgmtLongRunningOperation;
            Debug.Assert(mgmtOperation != null);
            return mgmtOperation;
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
    }
}
