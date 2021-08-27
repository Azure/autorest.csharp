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
using Azure.ResourceManager;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ContextualPathDetection;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected MgmtRestClient? _restClient;
        protected override string RestClientField => "_" + RestClientVariable;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected const string BaseUriField = "BaseUri";
        protected BuildContext<MgmtOutputLibrary> Context { get; }
        protected MgmtConfiguration Configuration => Context.Configuration.MgmtConfiguration;

        /// <summary>
        /// ClassName is the name of the class which this writer is writing
        /// </summary>
        protected abstract string TypeNameOfThis { get; }

        protected MgmtClientBaseWriter(BuildContext<MgmtOutputLibrary> context)
        {
            Context = context;
        }

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace(typeof(Task).Namespace!);
        }
        protected void WriteFields(CodeWriter writer, RestClient client)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"{RestClientAccessibility} readonly {client.Type} {RestClientField};");
        }

        protected void WriteEndOfGet(CodeWriter writer, CSharpType resourcetype, bool isAsync)
        {
            writer.Line($"if (response.Value == null)");
            writer.Line($"throw {GetAwait(isAsync)} {ClientDiagnosticsField}.CreateRequestFailedException{GetAsyncSuffix(isAsync)}(response.GetRawResponse()){GetConfigureAwait(isAsync)};");
            writer.Line($"return {typeof(Response)}.FromValue(new {resourcetype}({ContextProperty}, response.Value), response.GetRawResponse());");
        }

        protected void WriteContainerCtors(CodeWriter writer, RestClient restClient, Type contextArgumentType, string parentArguments)
        {
            // write protected default constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{TypeNameOfThis}\"/> class for mocking.");
            using (writer.Scope($"protected {TypeNameOfThis}()"))
            { }

            // write "parent resource" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {TypeNameOfThis} class.");
            writer.WriteXmlDocumentationParameter("parent", $"The resource representing the parent resource.");
            using (writer.Scope($"internal {TypeNameOfThis}({contextArgumentType} parent) : base({parentArguments})"))
            {
                writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? ", Id.SubscriptionId" : "";
                writer.Line($"{RestClientField} = new {restClient.Type}({ClientDiagnosticsField}, {PipelineProperty}, {ClientOptionsProperty}{subIdIfNeeded}, {BaseUriField});");
            }
        }

        protected void WriteContainerProperties(CodeWriter writer, string resourceType)
        {
            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            if (!resourceType.Contains(".ResourceType"))
            {
                resourceType = $"\"{resourceType}\"";
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
            writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => {resourceType};");
        }

        private IEnumerable<ParameterMapping> DecorateParameterMappingsForPagingMethod(IEnumerable<ParameterMapping> parameterMappings)
        {
            var result = new List<ParameterMapping>();
            foreach (var parameter in parameterMappings)
            {
                var valueToAdd = parameter;
                if (PagingMethod.IsPageSizeName(parameter.Parameter.Name))
                {
                    // alway use the `pageSizeHint` parameter from `AsPages(pageSizeHint)`
                    if (PagingMethod.IsPageSizeType(parameter.Parameter.Type.FrameworkType))
                    {
                        valueToAdd = parameter with
                        {
                            IsPassThru = false,
                            ValueExpression = "pageSizeHint"
                        };
                    }
                    else
                    {
                        Console.Error.WriteLine($"WARNING: Parameter '{parameter.Parameter.Name}' is like a page size parameter, but it's not a numeric type. Fix it or overwrite it if necessary.");
                    }
                }
                result.Add(valueToAdd);
            }
            return result;
        }

        protected void WriteList(CodeWriter writer, bool async, CSharpType resourceType, PagingMethod listMethod, string methodName, FormattableString converter, IEnumerable<ContextualParameterMapping> contextualParameterMappings, List<PagingMethod>? listMethods = null)
        {
            // if we find a proper *list* method that supports *paging*,
            // we should generate paging logic (PageableHelpers.CreateEnumerable)
            // else we just call ListAsGenericResource to get the list then call Get on every resource

            writer.Line();
            writer.WriteXmlDocumentationSummary($"{listMethod.Method.Description}");

            var parameterMappings = DecorateParameterMappingsForPagingMethod(BuildParameterMapping(listMethod.Method, contextualParameterMappings));
            // the list method signature should exclude the pagesize parameters
            var methodParameters = GetPassThroughParameters(parameterMappings).Where(p => !PagingMethod.IsPageSizeParameter(p));
            foreach (var param in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(param);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            FormattableString returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{resourceType.Name}\" /> that may take multiple service requests to iterate over.";
            writer.WriteXmlDocumentation("returns", returnText);

            var returnType = resourceType.WrapPageable(async);

            writer.Append($"public {GetVirtual(true)} {returnType} {CreateMethodName(methodName, async)}(");
            foreach (var param in methodParameters)
            {
                writer.WriteParameter(param);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WritePagingOperationBody(writer, listMethod, resourceType, RestClientField, new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>()),
                    ClientDiagnosticsField, converter, parameterMappings, async, listMethods);
            }
        }

        protected internal string GetConfigureAwait(bool isAsync)
        {
            return isAsync ? ".ConfigureAwait(false)" : string.Empty;
        }

        protected internal string GetVirtual(bool isVirtual)
        {
            return isVirtual ? "virtual" : string.Empty;
        }

        protected internal string GetAsyncKeyword(bool isAsync)
        {
            return isAsync ? "async" : string.Empty;
        }

        protected internal string GetAsyncSuffix(bool isAsync)
        {
            return isAsync ? "Async" : string.Empty;
        }

        protected internal string GetAwait(bool isAsync)
        {
            return isAsync ? "await " : string.Empty;
        }

        protected internal string GetNextLink(bool isNextPageFunc)
        {
            return isNextPageFunc ? "nextLink, " : string.Empty;
        }

        protected internal string GetOverride(bool isInheritedMethod, bool isVirtual = false)
        {
            return isInheritedMethod ? "override" : GetVirtual(isVirtual);
        }

        /// <summary>
        /// Write paging method using `PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunction)` pattern.
        /// </summary>
        /// <param name="writer">The code writer to use.</param>
        /// <param name="pagingMethod">Paging method that contains rest methods.</param>
        /// <param name="isAsync">Should the method be written sync or async.</param>
        /// <param name="resourceType">The reource type that is being written.</param>
        /// <param name="converter">Optional convertor for modifying the result of the rest client call.</param>
        protected void WritePagingOperationBody(CodeWriter writer, PagingMethod pagingMethod, CSharpType resourceType,
            string restClientName, Diagnostic diagnostic, string clientDiagnosticsName, FormattableString converter, IEnumerable<ParameterMapping> parameterMappings,
            bool isAsync, List<PagingMethod>? pagingMethods = null)
        {
            var returnType = new CSharpType(typeof(Page<>), resourceType).WrapAsync(isAsync);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            using (writer.Scope($"{GetAsyncKeyword(isAsync)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                {
                    WritePageFunction(writer, pagingMethod, restClientName, converter, parameterMappings, isAsync, false, pagingMethods);
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                using (writer.Scope($"{GetAsyncKeyword(isAsync)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                    {
                        WritePageFunction(writer, pagingMethod, restClientName, converter, parameterMappings, isAsync, true, pagingMethods);
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", isAsync)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void WritePageFunction(CodeWriter writer, PagingMethod method, string restClientName, FormattableString converter, IEnumerable<ParameterMapping> parameterMappings, bool async, bool isNextPageFunc, List<PagingMethod>? methods = null)
        {
            if (method.Method.Operation.IsAncestorScope() || methods == null || methods.Count < 2)
            {
                WritePageFunctionBody(writer, method, restClientName, converter, parameterMappings, async, isNextPageFunc);
            }
            else
            {
                var methodDict = methods.ToDictionary(m => m, m => m.Method.Operation.AncestorResourceType());
                // There could be methods at resource group scope and at resource scope, both with ResourceGroups AncestorResourceType.
                PagingMethod? resourceMethod = null;
                var resourceGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ResourceGroups).Key;
                var resourceGroupMethodsCount = methodDict.Count(kv => kv.Value == ResourceTypeBuilder.ResourceGroups);
                if (resourceGroupMethodsCount > 1)
                {
                    // The parent resource type of a resource method is always resourceGroupsResources
                    resourceMethod = methodDict.FirstOrDefault(kv => kv.Key.Method.Operation.ParentResourceType() == ResourceTypeBuilder.ResourceGroupResources).Key;
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
                            using (writer.Scope($"if (Id.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                            {
                                WritePageFunctionBody(writer, resourceGroupMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
                            }
                            using (writer.Scope($"else"))
                            {
                                WritePageFunctionBody(writer, resourceMethod, restClientName, converter, parameterMappings, async, isNextPageFunc, isResourceLevel: true);
                            }
                        }
                        else
                        {
                            WritePageFunctionBody(writer, resourceGroupMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
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
                        WritePageFunctionBody(writer, subscriptionMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
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
                            using (writer.Scope($"while ({parent}.Parent != {typeof(ResourceIdentifier)}.RootResourceIdentifier)"))
                            {
                                writer.Line($"{parent} = {parent}.Parent;");
                            }
                            using (writer.Scope($"if (parent.ResourceType.Equals({typeof(ManagementGroup)}.ResourceType))"))
                            {
                                WritePageFunctionBody(writer, managementGroupMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
                            }
                            using (writer.Scope($"else"))
                            {
                                WritePageFunctionBody(writer, tenantMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
                            }
                        }
                        else
                        {
                            WritePageFunctionBody(writer, managementGroupMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
                        }
                    }
                }
                else if (tenantMethod != null)
                {
                    methodDict.Remove(tenantMethod);
                    using (writer.Scope($"{elseStr}"))
                    {
                        WritePageFunctionBody(writer, tenantMethod, restClientName, converter, parameterMappings, async, isNextPageFunc);
                    }
                }

                if (methodDict.Count() > 0)
                {
                    throw new Exception($"When trying to merge methods, multiple methods can be mapped to the same scope. The methods not handled: {String.Join(", ", methodDict.Select(kv => kv.Key.Name).ToList())}.");
                }
            }

        }

        private void WritePageFunctionBody(CodeWriter writer, PagingMethod pagingMethod, string restClientName, FormattableString converter, IEnumerable<ParameterMapping> parameterMappings, bool isAsync, bool isNextPageFunc, bool isResourceLevel = false)
        {
            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";

            if (isResourceLevel)
            {
                writer.UseNamespace("System.Collections.Generic");
                writer.Line($"var parent = Id.Parent;");
                writer.Line($"var parentParts = new List<string>();");
                using (writer.Scope($"while (!parent.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                {
                    writer.Line($"parentParts.Insert(0, $\"{{parent.ResourceType.Types[parent.ResourceType.Types.Count - 1]}}/{{parent.Name}}\");");
                    writer.Line($"parent = parent.Parent;");
                }
                writer.Line($"var parentResourcePath = parentParts.Count > 0 ? string.Join(\"/\", parentParts) : \"\";");
                writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
            }
            writer.Append($"var response = {GetAwait(isAsync)} {restClientName}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, isAsync)}({GetNextLink(isNextPageFunc)}");
            WriteParameters(writer, parameterMappings, isResourceLevel: isResourceLevel);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            // need the Select() for converting XXXResourceData to XXXResource
            if (!string.IsNullOrEmpty(converter.ToString()))
            {
                writer.UseNamespace("System.Linq");
            }
            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}{converter}, {continuationTokenText}, response.GetRawResponse());");
        }

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping)
        {
            foreach (var parameter in mapping)
            {
                if (parameter.IsPassThru)
                {
                    writer.Append($"{parameter.Parameter.Name}, ");
                }
                else
                {
                    writer.Append($"{parameter.ValueExpression}, ");
                }
            }
        }

        protected void WriteParameters(CodeWriter writer, IEnumerable<ParameterMapping> parameterMappings, bool isResourceLevel = false)
        {
            if (isResourceLevel)
            {
                // Parameter mapping for a path like /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}
                foreach (var paramMapping in parameterMappings)
                {
                    paramMapping.ValueExpression = paramMapping.Parameter.Name switch
                    {
                        "subscriptionId" => "subscriptionId",
                        "resourceGroupName" => "resourceGroupName",
                        "resourceProviderNamespace" => "Id.ResourceType.Namespace",
                        "parentResourcePath" => "parentResourcePath",
                        "resourceType" => "Id.ResourceType.Types[Id.ResourceType.Types.Count - 1]",
                        _ => paramMapping.ValueExpression
                    };
                }
            }
            WriteArguments(writer, parameterMappings);
        }

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a container method or an expression.
        /// </summary>
        protected record ParameterMapping
        {
            /// <summary>
            /// The parameter object in <see cref="RestClientMethod"/>.
            /// </summary>
            public Parameter Parameter;
            /// <summary>
            /// Should the parameter be passed through from the method in container class?
            /// </summary>
            public bool IsPassThru;
            /// <summary>
            /// if not pass-through, this is the value to pass in <see cref="RestClientMethod"/>.
            /// </summary>
            public string ValueExpression;

            public ParameterMapping(Parameter parameter, bool isPassThru, string valueExpression)
            {
                Parameter = parameter;
                IsPassThru = isPassThru;
                ValueExpression = valueExpression;
            }
        }

        protected IEnumerable<Parameter> GetPassThroughParameters(IEnumerable<ParameterMapping> parameterMappings)
        {
            return parameterMappings.Where(p => p.IsPassThru).Select(p => p.Parameter);
        }

        protected IEnumerable<ParameterMapping> BuildParameterMapping(RestClientMethod method, IEnumerable<ContextualParameterMapping> contextualParameterMappings)
        {
            foreach (var parameter in method.Parameters)
            {
                // Update parameter type if the method is a `ById` method
                var p = UpdateParameterTypeOfByIdMethod(method, parameter);
                // find this parameter name in the contextual parameter mappings
                // if there is one, this parameter should use the same value expression
                // if there is none of this, this parameter should be a pass through parameter
                var mapping = contextualParameterMappings.FindContextualParameterForMethod(p, method);
                if (mapping == null)
                {
                    yield return new ParameterMapping(p, true, "");
                }
                else
                {
                    yield return new ParameterMapping(p, false, mapping.ValueExpression);
                }
            }
        }

        protected Parameter UpdateParameterTypeOfByIdMethod(RestClientMethod method, Parameter parameter)
        {
            if (method.IsByIdMethod() && parameter.Name.Equals(method.Parameters[0].Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return parameter with { Type = typeof(ResourceIdentifier) };
            }

            return parameter;
        }

        protected void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, string methodName, OperationGroup operationGroup, IEnumerable<ContextualParameterMapping> contextualParameterMappings, Diagnostic diagnostic, bool isAsync, string? restClientName = null)
        {
            RestClientMethod restClientMethod = clientMethod.RestClientMethod;
            (var bodyType, bool isListFunction, bool wasResourceData) = restClientMethod.GetBodyTypeForList(operationGroup, Context);
            var responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);
            responseType = responseType.WrapAsync(isAsync);

            writer.WriteXmlDocumentationSummary($"{restClientMethod.Description}");

            var parameterMapping = BuildParameterMapping(restClientMethod, contextualParameterMappings);
            var methodParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter).ToList();
            foreach (Parameter parameter in methodParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(methodParameters);

            writer.Append($"{restClientMethod.Accessibility} {GetVirtual(true)} {GetAsyncKeyword(isAsync)} {responseType} {CreateMethodName(methodName, isAsync)}(");

            foreach (Parameter parameter in methodParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(methodParameters);
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"var response = {GetAwait(isAsync)}");
                    writer.Append($"{restClientName ?? RestClientField}.{CreateMethodName(restClientMethod.Name, isAsync)}(");
                    WriteArguments(writer, parameterMapping);
                    writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

                    if (isListFunction)
                    {
                        // first we need to validate that is this function listing this resource itself, or list something else
                        var elementType = bodyType!.Arguments.First();
                        if (Context.Library.TryGetArmResource(operationGroup, out var resource)
                            && resource.Type.EqualsByName(elementType))
                        {
                            writer.UseNamespace("System.Linq");

                            var converter = $".Select(data => new {Context.Library.GetArmResource(operationGroup).Declaration.Name}({ContextProperty}, data)).ToArray()";
                            writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value{converter} as {bodyType}, response.GetRawResponse())");
                        }
                        else
                        {
                            writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value, response.GetRawResponse())");
                        }
                    }
                    else
                    {
                        Context.Library.TryGetArmResource(operationGroup, out var resource);
                        if (wasResourceData && resource != null && bodyType != null)
                        {
                            writer.Append($"return Response.FromValue(new {bodyType}(this, response.Value), response.GetRawResponse())");
                        }
                        else
                        {
                            writer.Append($"return response");
                        }
                    }

                    if (bodyType == null && restClientMethod.HeaderModel != null)
                    {
                        writer.Append($".GetRawResponse()");
                    }

                    writer.Line($";");
                });
            }

            writer.Line();
        }

        protected CSharpType? GetLROResultType(RestClientMethod clientMethod)
        {
            Debug.Assert(clientMethod.Operation != null);

            CSharpType? returnType = null;
            if (clientMethod.Operation.IsLongRunning)
            {
                LongRunningOperation operation = Context.Library.GetLongRunningOperation(clientMethod.Operation);
                MgmtLongRunningOperation longRunningOperation = AsMgmtOperation(operation);
                returnType = longRunningOperation.WrapperType != null ? longRunningOperation.WrapperType : longRunningOperation.ResultType;
            }
            else
            {
                NonLongRunningOperation nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(clientMethod.Operation);
                returnType = nonLongRunningOperation.ResultType;
            }

            return returnType;
        }

        protected MgmtLongRunningOperation AsMgmtOperation(LongRunningOperation operation)
        {
            var mgmtOperation = operation as MgmtLongRunningOperation;
            Debug.Assert(mgmtOperation != null);
            return mgmtOperation;
        }

        protected void WriteLROMethod(CodeWriter writer, RestClientMethod method, IEnumerable<ContextualParameterMapping> contextualParameterMappings,
            bool isLongRunningReallyLong, bool isAsync, string? methodName = null, List<RestClientMethod>? methods = null)
        {
            Debug.Assert(method.Operation != null);

            bool isLRO = isLongRunningReallyLong == false;

            methodName = methodName ?? method.Name;
            methodName = isLRO ? methodName : $"Start{methodName}";

            writer.Line();
            writer.WriteXmlDocumentationSummary($"{method.Description}");

            var parameterMappings = BuildParameterMapping(method, contextualParameterMappings);
            var passThruParameters = GetPassThroughParameters(parameterMappings);

            foreach (var parameter in passThruParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(passThruParameters.ToArray());

            CSharpType lroObjectType = method.Operation.IsLongRunning
                ? Context.Library.GetLongRunningOperation(method.Operation).Type
                : Context.Library.GetNonLongRunningOperation(method.Operation).Type;
            CSharpType responseType = lroObjectType.WrapAsync(isAsync);

            writer.Append($"public {GetAsyncKeyword(isAsync)} {GetVirtual(true)} {responseType} {CreateMethodName($"{methodName}", isAsync)}(");
            foreach (var parameter in passThruParameters)
            {
                writer.WriteParameter(parameter);
            }

            var defaultWaitForCompletion = isLRO == true ? "true" : "false";
            writer.Line($"bool waitForCompletion = {defaultWaitForCompletion}, {typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(passThruParameters.ToArray());

                Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    response.SetActualName(response.RequestedName);
                    if (method.Operation.IsAncestorScope() || methods == null || methods.Count < 2)
                    {
                        WriteLROMethodBody(writer, method, lroObjectType, Context, response, parameterMappings, isAsync);
                    }
                    else
                    {
                        var methodDict = methods.ToDictionary(m => m, m => m.Operation.AncestorResourceType());
                        // There could be methods at resource group scope and at resource scope, both with ResourceGroups AncestorResourceType.
                        RestClientMethod? resourceMethod = null;
                        var resourceGroupMethod = methodDict.FirstOrDefault(kv => kv.Value == ResourceTypeBuilder.ResourceGroups).Key;
                        var resourceGroupMethodsCount = methodDict.Count(kv => kv.Value == ResourceTypeBuilder.ResourceGroups);
                        if (resourceGroupMethodsCount > 1)
                        {
                            // The parent resource type of a resource method is always resourceGroupsResources
                            resourceMethod = methodDict.FirstOrDefault(kv => kv.Key.Operation.ParentResourceType() == ResourceTypeBuilder.ResourceGroupResources).Key;
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
                                    using (writer.Scope($"if (Id.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                                    {
                                        WriteLROMethodBody(writer, resourceGroupMethod, lroObjectType, Context, response, BuildParameterMapping(resourceGroupMethod, contextualParameterMappings), isAsync);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteLROMethodBody(writer, resourceGroupMethod, lroObjectType, Context, response, BuildParameterMapping(resourceGroupMethod, contextualParameterMappings), isAsync, isResourceLevel: true);
                                    }
                                }
                                else
                                {
                                    WriteLROMethodBody(writer, resourceGroupMethod, lroObjectType, Context, response, BuildParameterMapping(resourceGroupMethod, contextualParameterMappings), isAsync);
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
                                WriteLROMethodBody(writer, subscriptionMethod, lroObjectType, Context, response, BuildParameterMapping(subscriptionMethod, contextualParameterMappings), isAsync);
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
                                    using (writer.Scope($"while ({parent}.Parent !=  {typeof(ResourceIdentifier)}.RootResourceIdentifier)"))
                                    {
                                        writer.Line($"{parent} = {parent}.Parent;");
                                    }
                                    using (writer.Scope($"if (parent.ResourceType.Equals({typeof(ManagementGroup)}.ResourceType))"))
                                    {
                                        WriteLROMethodBody(writer, managementGroupMethod, lroObjectType, Context, response, BuildParameterMapping(managementGroupMethod, contextualParameterMappings), isAsync);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteLROMethodBody(writer, tenantMethod, lroObjectType, Context, response, BuildParameterMapping(tenantMethod, contextualParameterMappings), isAsync);
                                    }
                                }
                                else
                                {
                                    WriteLROMethodBody(writer, managementGroupMethod, lroObjectType, Context, response, BuildParameterMapping(managementGroupMethod, contextualParameterMappings), isAsync);
                                }
                            }
                        }
                        else if (tenantMethod != null)
                        {
                            methodDict.Remove(tenantMethod);
                            using (writer.Scope($"{elseStr}"))
                            {
                                WriteLROMethodBody(writer, tenantMethod, lroObjectType, Context, response, BuildParameterMapping(tenantMethod, contextualParameterMappings), isAsync);
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

        private void WriteLROMethodBody(CodeWriter writer, RestClientMethod clientMethod, CSharpType lroObjectType, BuildContext<MgmtOutputLibrary> context, CodeWriterDeclaration response, IEnumerable<ParameterMapping> parameterMapping, bool isAsync, bool isResourceLevel = false)
        {
            if (isResourceLevel)
            {
                writer.UseNamespace("System.Collections.Generic");
                writer.Line($"var parent = Id.Parent;");
                writer.Line($"var parentParts = new List<string>();");
                using (writer.Scope($"while (!parent.ResourceType.Equals({typeof(ResourceGroup)}.ResourceType))"))
                {
                    writer.Line($"parentParts.Insert(0, $\"{{parent.ResourceType.Types[parent.ResourceType.Types.Count - 1]}}/{{parent.Name}}\");");
                    writer.Line($"parent = parent.Parent;");
                }
                writer.Line($"var parentResourcePath = parentParts.Count > 0 ? string.Join(\"/\", parentParts) : \"\";");
                writer.Line($"Id.TryGetSubscriptionId(out var subscriptionId);");
            }
            writer.Append($"var {response} = {GetAwait(isAsync)}");
            writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, isAsync)}( ");
            WriteParameters(writer, parameterMapping, isResourceLevel: isResourceLevel);
            writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

            WriteLROResponse(writer, clientMethod, lroObjectType, context, response, parameterMapping, isAsync);

        }

        protected void WriteLROResponse(CodeWriter writer, RestClientMethod clientMethod, CSharpType lroObjectType, BuildContext<MgmtOutputLibrary> context, CodeWriterDeclaration response, IEnumerable<ParameterMapping> parameterMapping, bool isAsync)
        {
            Debug.Assert(clientMethod.Operation != null);
            var operation = new CodeWriterDeclaration("operation");
            writer.Append($"var {operation:D} = new {lroObjectType}(");

            if (clientMethod.Operation.IsLongRunning)
            {
                var longRunningOperation = AsMgmtOperation(context.Library.GetLongRunningOperation(clientMethod.Operation));
                if (longRunningOperation.WrapperType != null)
                {
                    writer.Append($"{ContextProperty}, ");
                }
                writer.Append($"{ClientDiagnosticsField}, {PipelineProperty}, {RestClientField}.{RequestWriterHelpers.CreateRequestMethodName(clientMethod.Name)}(");
                WriteArguments(writer, parameterMapping);
                writer.RemoveTrailingComma();
                writer.Append($").Request, ");
            }
            else
            {
                var nonLongRunningOperation = context.Library.GetNonLongRunningOperation(clientMethod.Operation);
                // need to check implementation type as some delete operation uses ResourceData.
                if (nonLongRunningOperation.ResultType != null && nonLongRunningOperation.ResultType.Implementation.GetType() == typeof(Resource))
                {
                    writer.Append($"{ContextProperty}, ");
                }
            }
            writer.Line($"{response});");
            CSharpType? lroResultType = GetLROResultType(clientMethod);
            var waitForCompletionMethod = lroResultType == null && isAsync ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
            writer.Line($"if (waitForCompletion)");
            writer.Line($"{GetAwait(isAsync)} {operation}.{CreateMethodName(waitForCompletionMethod, isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
            writer.Line($"return {operation};");
        }

    }
}
