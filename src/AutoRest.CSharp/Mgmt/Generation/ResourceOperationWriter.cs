﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using System.Text.RegularExpressions;
using Azure;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceOperationWriter : ClientWriter
    {
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

                RestClientMethod? getMethod = GetMethod(resourceOperation, resourceData);

                if (getMethod != null)
                {
                    _inheritResourceOperationsBase = true;
                    CSharpType[] arguments = { resourceOperation.ResourceIdentifierType, resource.Type };
                    CSharpType type = new CSharpType(baseClass, arguments);
                    writer.Append($"{type}, ");
                }
                else
                {
                    throw new Exception($"Get operation is missing for {resource.Type.Name} resource.");
                }

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
                        WriteClientFields(writer, resourceOperation.RestClient);
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
                    writer.Line($"{PipelineField} = Pipeline;");
                    var subscriptionValue = "Id.SubscriptionId";
                    if (resourceOperation.ResourceIdentifierType == typeof(TenantResourceIdentifier))
                    {
                        subscriptionValue = "subscriptionId";
                        writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
                    }
                    writer.Line($"this.RestClient = new {resourceOperation.RestClient.Type}({ClientDiagnosticsField}, {PipelineField}, {subscriptionValue}, BaseUri);");
                }
            }
        }

        private void WriteClientProperties(CodeWriter writer, ResourceOperation resourceOperation, MgmtConfiguration config)
        {
            writer.Line();
            writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{resourceOperation.OperationGroup.ResourceType(config)}\";");
            if (_inheritResourceOperationsBase)
            {
                writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => ResourceType;");
                if (resourceOperation.ResourceIdentifierType == typeof(ResourceIdentifier))
                {
                    writer.Line($"public new {typeof(ResourceGroupResourceIdentifier)} Id => base.Id as {typeof(ResourceGroupResourceIdentifier)};");
                }
            }
        }

        private void WriteClientMethods(CodeWriter writer, ResourceOperation resourceOperation, Resource resource, ResourceData resourceData, BuildContext<MgmtOutputLibrary> context)
        {
            var clientMethodsList = new List<RestClientMethod>();

            writer.Line();
            RestClientMethod? method = GetMethod(resourceOperation, resourceData);
            if (_inheritResourceOperationsBase && method != null)
            {
                ClientMethod getMethod = resourceOperation.Methods.Where(m => m.RestClientMethod == method).FirstOrDefault();
                // write inherited get method
                WriteGetMethod(writer, getMethod, resource, context, true, true);
                WriteGetMethod(writer, getMethod, resource, context, true, false);

                var nonPathParameters = GetNonPathParameters(getMethod.RestClientMethod);
                if (nonPathParameters.Length > 0)
                {
                    // write get method
                    WriteGetMethod(writer, getMethod, resource, context, false, true);
                    WriteGetMethod(writer, getMethod, resource, context, false, false);
                }
                clientMethodsList.Add(getMethod.RestClientMethod);

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

                RestClientMethod updateMethod;
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
                    throw new Exception($"Please update the swagger for {resource.Type.Name} to add the update operation.");
                }

                // write update method
                WriteAddTagMethod(writer, resourceOperation, updateMethod, context);
                WriteSetTagsMethod(writer, resourceOperation, updateMethod, context);
                WriteRemoveTagMethod(writer, resourceOperation, updateMethod, context);
                clientMethodsList.Add(updateMethod);
            }

            // write rest of the methods
            foreach (var clientMethod in resourceOperation.Methods)
            {
                if (!clientMethodsList.Contains(clientMethod.RestClientMethod) && clientMethod.RestClientMethod.Request.HttpMethod != RequestMethod.Put)
                {
                    WriteClientMethod(writer, clientMethod, resourceOperation, context, true);
                    WriteClientMethod(writer, clientMethod, resourceOperation, context, false);
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
                    writer.Append($"RestClient.{CreateMethodName(clientMethod.Name, async)}( ");
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
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P: System.Threading.CancellationToken.None\" />.");
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
            writer.WriteXmlDocumentationInheritDoc();

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
            writer.WriteXmlDocumentationInheritDoc();

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
            writer.WriteXmlDocumentationInheritDoc();

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
            writer.WriteXmlDocumentationInheritDoc();

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
            writer.WriteXmlDocumentationInheritDoc();

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
            writer.WriteXmlDocumentationInheritDoc();

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

            writer.Append($"RestClient.{CreateMethodName(clientMethod.Name, async)}( ");
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
                    writer.Append($"RestClient.{CreateMethodName(clientMethod.Name, async)}( ");
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
                writer.Append($"{ClientDiagnosticsField}, {PipelineField}, RestClient.{RequestWriterHelpers.CreateRequestMethodName(clientMethod.Name)}(");
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

        private void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            CSharpType? bodyType = clientMethod.RestClientMethod.ReturnType;
            CSharpType responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);

            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            Parameter[] nonPathParameters = GetNonPathParameters(clientMethod.RestClientMethod);
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(nonPathParameters);

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"{clientMethod.Accessibility} virtual {asyncText} {responseType} {methodName}(");

            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(nonPathParameters);
                WriteDiagnosticScope(writer, clientMethod.Diagnostics, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"return (");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    var parameterNames = GetParametersName(clientMethod.RestClientMethod, resourceOperation.OperationGroup, context);
                    writer.Append($"RestClient.{CreateMethodName(clientMethod.RestClientMethod.Name, async)}(");
                    foreach (var parameter in parameterNames)
                    {
                        writer.Append($"{parameter:I}, ");
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Append($")");

                    if (bodyType == null && clientMethod.RestClientMethod.HeaderModel != null)
                    {
                        writer.Append($".GetRawResponse()");
                    }

                    writer.Line($";");
                });
            }

            writer.Line();
        }

        private Parameter[] GetNonPathParameters(RestClientMethod clientMethod)
        {
            var pathParameters = GetPathParameters(clientMethod);

            List<Parameter> nonPathParameters = new List<Parameter>();
            foreach (Parameter parameter in clientMethod.Parameters)
            {
                if (!pathParameters.Contains(parameter))
                {
                    nonPathParameters.Add(parameter);
                }
            }

            return nonPathParameters.ToArray();
        }

        private Parameter[] GetPathParameters(RestClientMethod clientMethod)
        {
            var pathParameters = clientMethod.Request.PathSegments.Where(m => m.Value.IsConstant == false && m.IsRaw == false);
            List<Parameter> pathParametersList = new List<Parameter>();
            foreach (var parameter in clientMethod.Parameters)
            {
                if (pathParameters.Any(p => p.Value.Reference.Type.Name == parameter.Type.Name &&
                p.Value.Reference.Name == parameter.Name))
                {
                    pathParametersList.Add(parameter);
                }
            }

            return pathParametersList.ToArray();
        }

        // This method returns an array of path and non-path parameters name
        private string[] GetParametersName(RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var paramNames = GetPathParametersName(clientMethod, operationGroup, context).ToList();
            var nonPathParams = GetNonPathParameters(clientMethod);
            foreach (Parameter parameter in nonPathParams)
            {
                paramNames.Add(parameter.Name);
            }

            return paramNames.ToArray();
        }

        private string[] GetPathParametersName(RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            List<string> paramNameList = new List<string>();
            var pathParamsLength = GetPathParameters(clientMethod).Length;
            if (pathParamsLength > 0)
            {
                var isTenantParent = IsTenantParent(operationGroup, context);
                if (pathParamsLength > 1 && !isTenantParent)
                {
                    paramNameList.Add("Id.Name");
                    pathParamsLength--;
                }

                BuildPathParameterNames(paramNameList, pathParamsLength, "Id", operationGroup, context);

                if (!isTenantParent)
                    paramNameList.Reverse();
            }

            return paramNameList.ToArray();
        }

        // This method builds the path parameters names
        private void BuildPathParameterNames(List<string> paramNames, int paramLength, string name, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            if (IsTerminalState(operationGroup, context) && paramLength == 1)
            {
                paramNames.Add(GetParentValue(operationGroup, context));
                paramLength--;
            }
            else if (paramLength == 1)
            {
                var parentOperationGroup = ParentOperationGroup(operationGroup, context);
                if (parentOperationGroup != null)
                    BuildPathParameterNames(paramNames, paramLength, name, parentOperationGroup, context);
                else
                    BuildPathParameterNames(paramNames, paramLength, name, operationGroup, context);
            }
            else
            {
                name = $"{name}.Parent";
                paramNames.Add($"{name}.Name");
                paramLength--;

                var parentOperationGroup = ParentOperationGroup(operationGroup, context);
                if (parentOperationGroup != null)
                    BuildPathParameterNames(paramNames, paramLength, name, parentOperationGroup, context);
                else
                    BuildPathParameterNames(paramNames, paramLength, name, operationGroup, context);
            }
        }

        private bool IsTenantParent(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            while (!IsTerminalState(operationGroup, context))
            {
                var operationGroupTest = ParentOperationGroup(operationGroup, context);
                if (operationGroupTest != null)
                    operationGroup = operationGroupTest;
            }

            return TenantDetection.IsTenantResource(operationGroup, context.Configuration.MgmtConfiguration);
        }

        private static OperationGroup? ParentOperationGroup(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var config = context.Configuration.MgmtConfiguration;
            var parentResourceType = operationGroup.ParentResourceType(config);
            OperationGroup? parentOperationGroup = null;

            foreach (var opGroup in context.CodeModel.OperationGroups)
            {
                if (opGroup.ResourceType(context.Configuration.MgmtConfiguration).Equals(parentResourceType))
                {
                    parentOperationGroup = opGroup;
                    break;
                }
            }

            return parentOperationGroup;
        }

        private static bool IsTerminalState(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            return ParentOperationGroup(operationGroup, context) == null;
        }

        public string GetParentValue(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var parentResourceType = operationGroup.ParentResourceType(context.Configuration.MgmtConfiguration);

            switch (parentResourceType)
            {
                case ResourceTypeBuilder.ResourceGroups:
                    return "Id.ResourceGroupName";
                case ResourceTypeBuilder.Subscriptions:
                    return "Id.SubscriptionId";
                case ResourceTypeBuilder.Locations:
                    return "Id.Location";
                case ResourceTypeBuilder.Tenant:
                    return "Id.Name";
                default:
                    throw new Exception($"{operationGroup.Key} parent is not valid: {parentResourceType}.");
            }
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
