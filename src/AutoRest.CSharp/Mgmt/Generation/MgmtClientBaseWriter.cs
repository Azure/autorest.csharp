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
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected CodeWriter _writer;
        protected override string RestClientField => "_" + RestClientVariable;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected const string BaseUriField = "BaseUri";
        protected BuildContext<MgmtOutputLibrary> Context { get; }
        protected MgmtConfiguration Config => Context.Configuration.MgmtConfiguration;

        /// <summary>
        /// ClassName is the name of the class which this writer is writing
        /// </summary>
        protected abstract string TypeNameOfThis { get; }

        protected MgmtClientBaseWriter(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            Context = context;
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

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace(typeof(Task).Namespace!);
        }

        protected void WriteFields(CodeWriter writer, IEnumerable<RestClient> clients)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            foreach (var client in clients)
            {
                // we might have multiple rest client field, if we combined multiple request together in one resource in case of extension resources
                writer.Line($"{RestClientAccessibility} readonly {client.Type} {GetRestClientFieldName(client)};");
            }
        }

        protected string GetRestClientFieldName(RestClient client)
        {
            return $"_{client.OperationGroup.Key.ToVariableName()}RestClient";
        }

        protected void WriteGetResponse(CodeWriter writer, CSharpType resourceType, bool isAsync)
        {
            writer.Line($"if (response.Value == null)");
            writer.Line($"throw {GetAwait(isAsync)} {ClientDiagnosticsField}.CreateRequestFailedException{GetAsyncSuffix(isAsync)}(response.GetRawResponse()){GetConfigureAwait(isAsync)};");
            writer.Line($"return {typeof(Response)}.FromValue(new {resourceType}({ContextProperty}, response.Value), response.GetRawResponse());");
        }

        protected void WriteList(CodeWriter writer, bool async, CSharpType resourceType, PagingMethod listMethod, string methodName, FormattableString converter, List<PagingMethod>? listMethods = null)
        {
            // if we find a proper *list* method that supports *paging*,
            // we should generate paging logic (PageableHelpers.CreateEnumerable)
            // else we just call ListAsGenericResource to get the list then call Get on every resource

            writer.Line();
            writer.WriteXmlDocumentationSummary($"{listMethod.Method.Description}");

            var nonPathDomainParameters = listMethod.NonPathDomainParameters;
            foreach (var param in nonPathDomainParameters)
            {
                writer.WriteXmlDocumentationParameter(param);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            FormattableString returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{resourceType.Name}\" /> that may take multiple service requests to iterate over.";
            writer.WriteXmlDocumentation("returns", returnText);

            var returnType = resourceType.WrapPageable(async);

            writer.Append($"public {GetVirtual(true)} {returnType} {CreateMethodName(methodName, async)}(");
            foreach (var param in nonPathDomainParameters)
            {
                writer.WriteParameter(param);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WritePagingOperationBody(writer, listMethod, resourceType, RestClientField, new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>()), ClientDiagnosticsField, converter, async, listMethods);
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
            string restClientName, Diagnostic diagnostic, string clientDiagnosticsName, FormattableString converter, bool isAsync, List<PagingMethod>? pagingMethods = null)
        {
            var returnType = new CSharpType(typeof(Page<>), resourceType).WrapAsync(isAsync);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            using (writer.Scope($"{GetAsyncKeyword(isAsync)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                {
                    WritePageFunction(writer, pagingMethod, restClientName, converter, isAsync, false, pagingMethods);
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (writer.Scope($"{GetAsyncKeyword(isAsync)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                    {
                        WritePageFunction(writer, pagingMethod, restClientName, converter, isAsync, true, pagingMethods);
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", isAsync)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void WritePageFunction(CodeWriter writer, PagingMethod method, string restClientName, FormattableString converter, bool async, bool isNextPageFunc, List<PagingMethod>? methods = null)
        {
            if (method.Method.Operation.IsAncestorScope() || methods == null || methods.Count < 2)
            {
                WritePageFunctionBodyOld(writer, method, restClientName, converter, async, isNextPageFunc);
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
                                WritePageFunctionBodyOld(writer, resourceGroupMethod, restClientName, converter, async, isNextPageFunc);
                            }
                            using (writer.Scope($"else"))
                            {
                                WritePageFunctionBodyOld(writer, resourceMethod, restClientName, converter, async, isNextPageFunc, isResourceLevel: true);
                            }
                        }
                        else
                        {
                            WritePageFunctionBodyOld(writer, resourceGroupMethod, restClientName, converter, async, isNextPageFunc);
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
                        WritePageFunctionBodyOld(writer, subscriptionMethod, restClientName, converter, async, isNextPageFunc);
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
                                WritePageFunctionBodyOld(writer, managementGroupMethod, restClientName, converter, async, isNextPageFunc);
                            }
                            using (writer.Scope($"else"))
                            {
                                WritePageFunctionBodyOld(writer, tenantMethod, restClientName, converter, async, isNextPageFunc);
                            }
                        }
                        else
                        {
                            WritePageFunctionBodyOld(writer, managementGroupMethod, restClientName, converter, async, isNextPageFunc);
                        }
                    }
                }
                else if (tenantMethod != null)
                {
                    methodDict.Remove(tenantMethod);
                    using (writer.Scope($"{elseStr}"))
                    {
                        WritePageFunctionBodyOld(writer, tenantMethod, restClientName, converter, async, isNextPageFunc);
                    }
                }

                if (methodDict.Count() > 0)
                {
                    throw new Exception($"When trying to merge methods, multiple methods can be mapped to the same scope. The methods not handled: {String.Join(", ", methodDict.Select(kv => kv.Key.Name).ToList())}.");
                }
            }
        }

        private void WritePageFunctionBodyOld(CodeWriter writer, PagingMethod pagingMethod, string restClientName, FormattableString converter, bool isAsync, bool isNextPageFunc, bool isResourceLevel = false)
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
            BuildAndWriteParameters(writer, pagingMethod.Method, isResourceLevel: isResourceLevel);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            // need the Select() for converting XXXResourceData to XXXResource
            if (!string.IsNullOrEmpty(converter.ToString()))
            {
                writer.UseNamespace("System.Linq");
            }
            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{itemName}{converter}, {continuationTokenText}, response.GetRawResponse());");
        }

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping, bool passNullForOptionalParameters = false)
        {
            foreach (var parameter in mapping)
            {
                if (parameter.IsPassThru)
                {
                    if (PagingMethod.IsPageSizeName(parameter.Parameter.Name))
                    {
                        // alway use the `pageSizeHint` parameter from `AsPages(pageSizeHint)`
                        if (PagingMethod.IsPageSizeType(parameter.Parameter.Type.FrameworkType))
                        {
                            writer.AppendRaw($"pageSizeHint, ");
                        }
                        else
                        {
                            Console.Error.WriteLine($"WARNING: Parameter '{parameter.Parameter.Name}' is like a page size parameter, but it's not a numeric type. Fix it or overwrite it if necessary.");
                            writer.Append($"{parameter.Parameter.Name}, ");
                        }
                    }
                    else
                    {
                        if (passNullForOptionalParameters && !parameter.Parameter.ValidateNotNull)
                            writer.Append($"null, ");
                        else
                            writer.Append($"{parameter.Parameter.Name}, ");
                    }
                }
                else
                {
                    writer.Append($"{parameter.ValueExpression}, ");
                }
            }
        }

        protected void BuildAndWriteParameters(CodeWriter writer, RestClientMethod method, IEnumerable<ParameterMapping>? parameterMappings = null, bool isResourceLevel = false)
        {
            parameterMappings = parameterMappings ?? BuildParameterMapping(method);
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

        //protected void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, string methodName, Diagnostic diagnostic, OperationGroup operationGroup, bool isAsync, string? restClientName = null)
        //{
        //    RestClientMethod restClientMethod = clientMethod.RestClientMethod;
        //    (var bodyType, bool isListFunction, bool wasResourceData) = restClientMethod.GetBodyTypeForList(operationGroup, Context);
        //    var responseType = bodyType != null ?
        //        new CSharpType(typeof(Response<>), bodyType) :
        //        typeof(Response);
        //    responseType = responseType.WrapAsync(isAsync);

        //    writer.WriteXmlDocumentationSummary($"{restClientMethod.Description}");

        //    var nonPathParameters = restClientMethod.NonPathParameters;
        //    foreach (Parameter parameter in nonPathParameters)
        //    {
        //        writer.WriteXmlDocumentationParameter(parameter);
        //    }

        //    writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
        //    writer.WriteXmlDocumentationRequiredParametersException(nonPathParameters);

        //    writer.Append($"{restClientMethod.Accessibility} {GetVirtual(true)} {GetAsyncKeyword(isAsync)} {responseType} {CreateMethodName(methodName, isAsync)}(");

        //    foreach (Parameter parameter in nonPathParameters)
        //    {
        //        writer.WriteParameter(parameter);
        //    }
        //    writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

        //    using (writer.Scope())
        //    {
        //        writer.WriteParameterNullChecks(nonPathParameters);
        //        WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
        //        {
        //            writer.Append($"var response = {GetAwait(isAsync)}");
        //            writer.Append($"{restClientName ?? RestClientField}.{CreateMethodName(restClientMethod.Name, isAsync)}(");
        //            BuildAndWriteParameters(writer, restClientMethod);
        //            writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

        //            if (isListFunction)
        //            {
        //                // first we need to validate that is this function listing this resource itself, or list something else
        //                var elementType = bodyType!.Arguments.First();
        //                if (Context.Library.TryGetArmResource(operationGroup, out var resource)
        //                    && resource.Type.EqualsByName(elementType))
        //                {
        //                    writer.UseNamespace("System.Linq");

        //                    var converter = $".Select(data => new {Context.Library.GetArmResource(operationGroup).Declaration.Name}({ContextProperty}, data)).ToArray()";
        //                    writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value{converter} as {bodyType}, response.GetRawResponse())");
        //                }
        //                else
        //                {
        //                    writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value, response.GetRawResponse())");
        //                }
        //            }
        //            else
        //            {
        //                Context.Library.TryGetArmResource(operationGroup, out var resource);
        //                if (wasResourceData && resource != null && bodyType != null)
        //                {
        //                    writer.Append($"return Response.FromValue(new {bodyType}(this, response.Value), response.GetRawResponse())");
        //                }
        //                else
        //                {
        //                    writer.Append($"return response");
        //                }
        //            }

        //            if (bodyType == null && restClientMethod.HeaderModel != null)
        //            {
        //                writer.Append($".GetRawResponse()");
        //            }

        //            writer.Line($";");
        //        });
        //    }

        //    writer.Line();
        //}

        protected CSharpType? GetLROResultType(Input.Operation operation)
        {
            CSharpType? returnType = null;
            if (operation.IsLongRunning)
            {
                LongRunningOperation lro = Context.Library.GetLongRunningOperation(operation);
                MgmtLongRunningOperation longRunningOperation = AsMgmtOperation(lro);
                returnType = longRunningOperation.WrapperType != null ? longRunningOperation.WrapperType : longRunningOperation.ResultType;
            }
            else
            {
                NonLongRunningOperation nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(operation);
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

        protected void WriteLROMethodOld(RestClientMethod method, string methodName, bool isAsync, List<RestClientMethod>? methods = null)
        {
            bool isSLRO = method.IsLongRunningReallyLong() == false;
            methodName = isSLRO ? methodName : $"Start{methodName}";

            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"{method.Description}");

            var parameterMapping = BuildParameterMapping(method);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            foreach (var parameter in passThruParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }

            _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationRequiredParametersException(passThruParameters.ToArray());

            CSharpType lroObjectType = method.Operation.IsLongRunning
                ? Context.Library.GetLongRunningOperation(method.Operation).Type
                : Context.Library.GetNonLongRunningOperation(method.Operation).Type;
            CSharpType responseType = lroObjectType.WrapAsync(isAsync);

            _writer.Append($"public {GetAsyncKeyword(isAsync)} {GetVirtual(true)} {responseType} {CreateMethodName($"{methodName}", isAsync)}(");
            foreach (var parameter in passThruParameters)
            {
                _writer.WriteParameter(parameter);
            }

            var defaultWaitForCompletion = isSLRO == true ? "true" : "false";
            _writer.Line($"bool waitForCompletion = {defaultWaitForCompletion}, {typeof(CancellationToken)} cancellationToken = default)");
            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(passThruParameters.ToArray());

                Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(_writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    response.SetActualName(response.RequestedName);
                    if (method.Operation.IsAncestorScope() || methods == null || methods.Count < 2)
                    {
                        WriteLROMethodBody(writer, method, lroObjectType, response, parameterMapping, isAsync);
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
                                        WriteLROMethodBody(writer, resourceGroupMethod, lroObjectType, response, BuildParameterMapping(resourceGroupMethod), isAsync);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteLROMethodBody(writer, resourceGroupMethod, lroObjectType, response, BuildParameterMapping(resourceGroupMethod), isAsync, isResourceLevel: true);
                                    }
                                }
                                else
                                {
                                    WriteLROMethodBody(writer, resourceGroupMethod, lroObjectType, response, BuildParameterMapping(resourceGroupMethod), isAsync);
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
                                WriteLROMethodBody(writer, subscriptionMethod, lroObjectType, response, BuildParameterMapping(subscriptionMethod), isAsync);
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
                                        WriteLROMethodBody(writer, managementGroupMethod, lroObjectType, response, BuildParameterMapping(managementGroupMethod), isAsync);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteLROMethodBody(writer, tenantMethod, lroObjectType, response, BuildParameterMapping(tenantMethod), isAsync);
                                    }
                                }
                                else
                                {
                                    WriteLROMethodBody(writer, managementGroupMethod, lroObjectType, response, BuildParameterMapping(managementGroupMethod), isAsync);
                                }
                            }
                        }
                        else if (tenantMethod != null)
                        {
                            methodDict.Remove(tenantMethod);
                            using (writer.Scope($"{elseStr}"))
                            {
                                WriteLROMethodBody(writer, tenantMethod, lroObjectType, response, BuildParameterMapping(tenantMethod), isAsync);
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

        private void WriteLROMethodBodyOld(CodeWriter writer, RestClientMethod clientMethod, CSharpType lroObjectType, CodeWriterDeclaration response, IEnumerable<ParameterMapping> parameterMapping, bool isAsync, bool isResourceLevel = false)
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
            BuildAndWriteParameters(writer, clientMethod, isResourceLevel: isResourceLevel);
            writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

            WriteLROResponse(writer, lroObjectType, clientMethod, response, parameterMapping, isAsync);

        }

        protected void WriteLROResponse(CodeWriter writer, CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            writer.Append($"var operation = new {lroObjectType}(");

            if (operation.Operation.IsLongRunning)
            {
                var longRunningOperation = AsMgmtOperation(Context.Library.GetLongRunningOperation(operation.Operation));
                if (longRunningOperation.WrapperType != null)
                {
                    writer.Append($"{ContextProperty}, ");
                }
                writer.Append($"{ClientDiagnosticsField}, {PipelineProperty}, {RestClientField}.{RequestWriterHelpers.CreateRequestMethodName(operation.Name)}(");
                WriteArguments(writer, parameterMapping);
                writer.RemoveTrailingComma();
                writer.Append($").Request, ");
            }
            else
            {
                var nonLongRunningOperation = Context.Library.GetNonLongRunningOperation(operation.Operation);
                // need to check implementation type as some delete operation uses ResourceData.
                if (nonLongRunningOperation.ResultType != null && nonLongRunningOperation.ResultType.Implementation.GetType() == typeof(Resource))
                {
                    writer.Append($"{ContextProperty}, ");
                }
            }
            writer.Line($"response);");
            CSharpType? lroResultType = GetLROResultType(operation.Operation);
            var waitForCompletionMethod = lroResultType == null && async ?
                    "WaitForCompletionResponse" :
                    "WaitForCompletion";
            writer.Line($"if (waitForCompletion)");
            writer.Line($"{GetAwait(async)} operation.{CreateMethodName(waitForCompletionMethod, async)}(cancellationToken){GetConfigureAwait(async)};");
            writer.Line($"return operation;");
        }
    }
}
