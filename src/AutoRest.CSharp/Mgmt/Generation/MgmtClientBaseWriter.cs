// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected MgmtRestClient? _restClient;
        protected override string RestClientField => "_" + RestClientVariable;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected const string BaseUriField = "BaseUri";

        /// <summary>
        /// ClassName is the name of the class which this writer is writing
        /// </summary>
        protected abstract string TypeNameOfThis { get; }

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace(typeof(Task).Namespace!);
        }

        protected void WriteFields(CodeWriter writer, RestClient restClient)
        {
            writer.Line();
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Represents the REST operations.");
            // subscriptionId might not always be needed. For example `RestOperations` does not have it.
            var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? ", Id.SubscriptionId" : "";
            writer.Line($"private {restClient.Type} {RestClientField} => new {restClient.Type}({ClientDiagnosticsField}, {PipelineProperty}{subIdIfNeeded}, {BaseUriField});");
            writer.Line();
        }

        protected void WriteContainerCtors(CodeWriter writer, Type contextArgumentType, string parentArguments)
        {
            // write protected default constructor
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

            writer.Append($"public {returnType} {CreateMethodName(methodName, async)}(");
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

        protected internal string VirtualKeyword(bool isVirtual)
        {
            return isVirtual ? "virtual" : string.Empty;
        }

        protected internal string AsyncKeyword(bool async)
        {
            return async ? "async" : string.Empty;
        }

        protected internal string AwaitKeyword(bool async)
        {
            return async ? "await" : string.Empty;
        }

        protected internal string OverrideKeyword(bool isInheritedMethod, bool isVirtual = false)
        {
            return isInheritedMethod ? "override" : VirtualKeyword(isVirtual);
        }

        /// <summary>
        /// Write paging method using `PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunction)` pattern.
        /// </summary>
        /// <param name="writer">The code writer to use.</param>
        /// <param name="pagingMethod">Paging method that contains rest methods.</param>
        /// <param name="async">Should the method be written sync or async.</param>
        /// <param name="resourceType">The reource type that is being written.</param>
        /// <param name="converter">Optional convertor for modifying the result of the rest client call.</param>
        protected void WritePagingOperationBody(CodeWriter writer, PagingMethod pagingMethod, CSharpType resourceType,
            string restClientName, Diagnostic diagnostic, string clientDiagnosticsName, FormattableString converter, bool async, List<PagingMethod>? pagingMethods = null)
        {
            var parameters = pagingMethod.Method.Parameters;

            var returnType = new CSharpType(typeof(Page<>), resourceType).WrapAsync(async);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
            using (writer.Scope($"{AsyncKeyword(async)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                {
                    WritePageFunction(writer, pagingMethod, restClientName, converter, async, false, pagingMethods);
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (writer.Scope($"{AsyncKeyword(async)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                    {
                        WritePageFunction(writer, pagingMethod, restClientName, converter, async, true, pagingMethods);
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void WritePageFunction(CodeWriter writer, PagingMethod method, string restClientName, FormattableString converter, bool async, bool isNextPageFunc, List<PagingMethod>? methods = null)
        {
            if (method.Method.Operation.IsAncestorScope() || methods == null || methods.Count < 2)
            {
                WritePageFunctionBody(writer, method, restClientName, converter, async, isNextPageFunc);
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
                            using (writer.Scope($"if (Id.ResourceType.Equals(ResourceGroupOperations.ResourceType))"))
                            {
                                WritePageFunctionBody(writer, resourceGroupMethod, restClientName, converter, async, isNextPageFunc);
                            }
                            using (writer.Scope($"else"))
                            {
                                WritePageFunctionBody(writer, resourceMethod, restClientName, converter, async, isNextPageFunc, isResourceLevel: true);
                            }
                        }
                        else
                        {
                            WritePageFunctionBody(writer, resourceGroupMethod, restClientName, converter, async, isNextPageFunc);
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
                        WritePageFunctionBody(writer, subscriptionMethod, restClientName, converter, async, isNextPageFunc);
                    }
                }

                elseStr = (!elseStr.IsNullOrEmpty() || subscriptionMethod != null) ? "else " : string.Empty;
                if (managementGroupMethod != null)
                {
                    methodDict.Remove(managementGroupMethod);
                    using (elseStr.IsNullOrEmpty() ?  null: writer.Scope($"{elseStr}"))
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
                                WritePageFunctionBody(writer, managementGroupMethod, restClientName, converter, async, isNextPageFunc);
                            }
                            using (writer.Scope($"else"))
                            {
                                WritePageFunctionBody(writer, tenantMethod, restClientName, converter, async, isNextPageFunc);
                            }
                        }
                        else
                        {
                            WritePageFunctionBody(writer, managementGroupMethod, restClientName, converter, async, isNextPageFunc);
                        }
                    }
                }
                else if (tenantMethod != null)
                {
                    methodDict.Remove(tenantMethod);
                    using (writer.Scope($"{elseStr}"))
                    {
                        WritePageFunctionBody(writer, tenantMethod, restClientName, converter, async, isNextPageFunc);
                    }
                }

                if (methodDict.Count() > 0)
                {
                    throw new Exception($"When trying to merge methods, multiple methods can be mapped to the same scope. The methods not handled: {String.Join(", ", methodDict.Select(kv => kv.Key.Name).ToList())}.");
                }
            }

        }

        private void WritePageFunctionBody(CodeWriter writer, PagingMethod pagingMethod, string restClientName, FormattableString converter, bool async, bool isNextPageFunc, bool isResourceLevel = false)
        {
            var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";

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
            writer.Append($"var response = {AwaitKeyword(async)} {restClientName}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, async)}(");
            if (isNextPageFunc)
            {
                writer.Append($"nextLink, ");
            }
            BuildAndWriteParameters(writer, pagingMethod.Method, isResourceLevel);
            writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");

            // need the Select() for converting XXXResourceData to XXXResource
            if (!string.IsNullOrEmpty(converter.ToString()))
            {
                writer.UseNamespace("System.Linq");
            }
            writer.Append($"return {typeof(Page)}.FromValues(response.Value.{itemName}");
            writer.Append($"{converter}");
            writer.Line($", {continuationTokenText}, response.GetRawResponse());");

        }

        protected void WriteArguments(CodeWriter writer, IEnumerable<ParameterMapping> mapping)
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
                        writer.Append($"{parameter.Parameter.Name}, ");
                    }
                }
                else
                {
                    writer.Append($"{parameter.ValueExpression}, ");
                }
            }
        }

        protected void BuildAndWriteParameters(CodeWriter writer, RestClientMethod method, bool isResourceLevel = false)
        {
            var parameterMappings = BuildParameterMapping(method);
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
        protected class ParameterMapping
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

        /// <summary>
        /// Builds the mapping between parameters of the rest client method and its caller.
        /// Decides which parameters should pass through, which should be evaluated with what expressions.
        /// For example `DedicatedHostRestClient.CreateOrUpdate()` <br/>
        /// | resourceGroupName      | hostGroupName    | hostName | parameters | <br/>
        /// | ---------------------- | ---------------- | -------- | ---------- | <br/>
        /// | "Id.ResourceGroupName" | "Id.Parent.Name" | hostName | parameters | <br/>
        /// </summary>
        /// <param name="method">Represents a method in RestOperations class.</param>
        protected IEnumerable<ParameterMapping> BuildParameterMapping(RestClientMethod method)
        {
            var parameterMapping = new List<ParameterMapping>();
            var dotParent = string.Empty;
            var parentNameStack = new Stack<string>();

            // loop through parameters of REST client method, map the leading string-like parameters to
            // Id.ResourceGroupName, Id.Name, Id.Parent.Name...
            // special case: type is enum and you can convert string to it (model-as-string), we should handle it as string
            // special case 2: in paging scenarios, `nextLink` needs to be handled specially, so here we just ignore it
            foreach (var parameter in method.Parameters)
            {
                bool passThru = true;
                string valueExpression = string.Empty;
                if (string.Equals(parameter.Name, "nextLink", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }
                else if (parameter.Type.IsStringLike() && IsMandatory(parameter) && (method.Name.EndsWith("NextPage") || method.PathParameters.Contains(parameter))) // in a ListNextPage method, all parameters are nonpath parameters.
                {
                    passThru = ShouldPassThrough(ref dotParent, parentNameStack, parameter, ref valueExpression);
                }
                parameterMapping.Add(new ParameterMapping(parameter, passThru, valueExpression));
            }

            MakeResourceNameParamPassThrough(method, parameterMapping, parentNameStack);
            MakeByIdParamPassThrough(method, parameterMapping, parentNameStack);

            // set the arguments for name parameters reversely: Id.Parent.Name, Id.Parent.Parent.Name, ...
            foreach (var parameter in parameterMapping)
            {
                if (IsMandatory(parameter.Parameter) && !parameter.IsPassThru && string.IsNullOrEmpty(parameter.ValueExpression))
                {
                    var parentName = parentNameStack.Pop();
                    // scope is a whole Id, remove ".Name" for it.
                    parameter.ValueExpression = parameter.Parameter.Name == "scope" ? parentName.Substring(0, parentName.LastIndexOf(".Name")) : parentName;
                }
            }

            return parameterMapping;
        }

        protected abstract void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack);

        protected virtual void MakeByIdParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            var request = method.Operation?.Requests.FirstOrDefault(r => r.Protocol.Http is HttpRequest);
            if (method.IsByIdMethod())
            {
                var firstString = parameterMapping.FirstOrDefault(parameter => parameter.Parameter.Name.Equals(method.Parameters[0].Name, StringComparison.InvariantCultureIgnoreCase));
                if (firstString?.Parameter != null)
                {
                    firstString.IsPassThru = true;
                    firstString.Parameter = firstString.Parameter with { Type = typeof(ResourceIdentifier) };
                }
            }
        }

        protected abstract bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression);

        protected bool IsMandatory(Parameter parameter) => parameter.DefaultValue is null;

        protected void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, string methodName, Diagnostic diagnostic, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, bool async, string? restClientName = null)
        {
            RestClientMethod restClientMethod = clientMethod.RestClientMethod;
            (var bodyType, bool isListFunction, bool wasResourceData) = restClientMethod.GetBodyTypeForList(operationGroup, context);
            var responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);
            responseType = responseType.WrapAsync(async);

            writer.WriteXmlDocumentationSummary($"{restClientMethod.Description}");

            var nonPathParameters = restClientMethod.NonPathParameters;
            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(nonPathParameters);

            writer.Append($"{restClientMethod.Accessibility} virtual {AsyncKeyword(async)} {responseType} {CreateMethodName(methodName, async)}(");

            foreach (Parameter parameter in nonPathParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(nonPathParameters);
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"var response = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{restClientName ?? RestClientField}.{CreateMethodName(restClientMethod.Name, async)}(");
                    BuildAndWriteParameters(writer, restClientMethod);
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Line($";");

                    if (isListFunction)
                    {
                        // first we need to validate that is this function listing this resource itself, or list something else
                        var elementType = bodyType!.Arguments.First();
                        if (context.Library.TryGetArmResource(operationGroup, out var resource)
                            && resource.Type.EqualsByName(elementType))
                        {
                            writer.UseNamespace("System.Linq");

                            var converter = $".Select(data => new {context.Library.GetArmResource(operationGroup).Declaration.Name}({ContextProperty}, data)).ToArray()";
                            writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value{converter} as {bodyType}, response.GetRawResponse())");
                        }
                        else
                        {
                            writer.Append($"return {typeof(Response)}.FromValue(response.Value.Value, response.GetRawResponse())");
                        }
                    }
                    else
                    {
                        context.Library.TryGetArmResource(operationGroup, out var resource);
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

        // This method returns an array of path and non-path parameters name
        // TODO: this method has some bugs for methods in MgmtListMethods and is no longer used, we should consistently use BuildParameterMapping().
        protected string[] GetParametersName(RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var paramNames = GetPathParametersName(clientMethod, operationGroup, context).ToList();
            var nonPathParams = clientMethod.NonPathParameters;
            foreach (Parameter parameter in nonPathParams)
            {
                paramNames.Add(parameter.Name);
            }

            return paramNames.ToArray();
        }

        protected string[] GetPathParametersName(RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            List<string> paramNameList = new List<string>();
            var pathParamsLength = clientMethod.PathParameters.Count;
            if (pathParamsLength > 0)
            {
                if (pathParamsLength > 1)
                {
                    paramNameList.Add("Id.Name");
                    pathParamsLength--;
                }
                BuildPathParameterNames(paramNameList, pathParamsLength, "Id", operationGroup, context, clientMethod);
                paramNameList.Reverse();
            }

            return paramNameList.ToArray();
        }



        private static bool IsTerminalState(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            return operationGroup.ParentOperationGroup(context) == null;
        }

        // This method builds the path parameters names
        private void BuildPathParameterNames(List<string> paramNames, int paramLength, string name, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, RestClientMethod clientMethod)
        {
            if (IsTerminalState(operationGroup, context) && paramLength == 1)
            {
                paramNames.Add(GetParentValue(operationGroup, context, name, clientMethod));
                paramLength--;
            }
            else if (paramLength == 1)
            {
                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
                if (parentOperationGroup != null)
                    BuildPathParameterNames(paramNames, paramLength, name, parentOperationGroup, context, clientMethod);
                else
                    BuildPathParameterNames(paramNames, paramLength, name, operationGroup, context, clientMethod);
            }
            else
            {
                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
                name = $"{name}.Parent";
                paramNames.Add($"{name}.Name");
                paramLength--;

                if (parentOperationGroup != null)
                    BuildPathParameterNames(paramNames, paramLength, name, parentOperationGroup, context, clientMethod);
                else
                    BuildPathParameterNames(paramNames, paramLength, name, operationGroup, context, clientMethod);
            }
        }

        public string GetParentValue(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, string name, RestClientMethod clientMethod)
        {
            if (operationGroup.IsTupleResource(context))
            {
                return $"{name}.Parent.Name";
            }
            var parentResourceType = operationGroup.ParentResourceType(context.Configuration.MgmtConfiguration);

            switch (parentResourceType)
            {
                case ResourceTypeBuilder.ResourceGroups:
                    return "Id.ResourceGroupName";
                case ResourceTypeBuilder.Subscriptions:
                    return "Id.SubscriptionId";
                case ResourceTypeBuilder.Locations:
                    return "Id.Location";
                case ResourceTypeBuilder.ManagementGroups:
                    return $"{name}.Parent.Name";
                case ResourceTypeBuilder.Tenant:
                    // There are multiple cases when parent resource type is tenant:
                    // 1. Tenant resource.
                    // 2. Scope resource. The clientMethod may have a path starting with /{scope} or a path at any specific scope (tenant/management group/subscription/resource group) or a /{resourceId} path.
                    // 3. Extension resource in the same operation group. The clientMethod may have a path at any scope (tenant/management group/subscription/resource group).
                    if (clientMethod.IsByIdMethod())
                    {
                        return $"{name}"; // For /{resourceId} operations, there is only 1 parameter and name will always be "Id".
                    }
                    if (clientMethod.Operation?.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpReq && httpReq.Path.StartsWith("/{scope}"))
                    {
                        return $"{name}.Parent";
                    }
                    else if (clientMethod.Operation?.IsParentTenant() == true) // If the operation is a main resource directly under tenant, there is only 1 parameter and returns "Id.name".
                    {
                        return $"{name}.Name";
                    }
                    else
                    {
                        return $"{name}.Parent.Name";
                    }
                default:
                    throw new Exception($"{operationGroup.Key} parent is not valid: {parentResourceType}.");
            }
        }

        protected CSharpType GetLROObjectType(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
        {
            return clientMethod.Operation!.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;
        }

        protected CSharpType? GetLROReturnType(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context)
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

        protected MgmtLongRunningOperation AsMgmtOperation(LongRunningOperation operation)
        {
            var mgmtOperation = operation as MgmtLongRunningOperation;
            Debug.Assert(mgmtOperation != null);
            return mgmtOperation;
        }

        protected void WriteFirstLROMethod(CodeWriter writer, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async,
            bool isVirtual, string? methodName = null)
        {
            Debug.Assert(clientMethod.Operation != null);

            methodName = methodName ?? clientMethod.Name;

            writer.Line();
            writer.WriteXmlDocumentationSummary($"{clientMethod.Description}");

            var parameterMapping = BuildParameterMapping(clientMethod);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            foreach (var parameter in passThruParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(passThruParameters.ToArray());

            CSharpType? returnType = GetLROReturnType(clientMethod, context);
            CSharpType responseType = returnType != null ?
                new CSharpType(typeof(Response<>), returnType) :
                typeof(Response);
            responseType = responseType.WrapAsync(async);

            writer.Append($"public {AsyncKeyword(async)} {VirtualKeyword(isVirtual)} {responseType} {CreateMethodName(methodName, async)}(");
            foreach (var parameter in passThruParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(passThruParameters.ToArray());

                Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var operation = new CodeWriterDeclaration("operation");
                    writer.Append($"var {operation:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{CreateMethodName($"Start{methodName}", async)}(");
                    WriteArguments(writer, parameterMapping.Where(p => p.IsPassThru));
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

        protected void WriteStartLROMethod(CodeWriter writer, RestClientMethod method, BuildContext<MgmtOutputLibrary> context, bool async,
            bool isVirtual = false, string? methodName = null, List<RestClientMethod>? methods = null)
        {
            Debug.Assert(method.Operation != null);

            methodName = methodName ?? method.Name;

            writer.Line();
            writer.WriteXmlDocumentationSummary($"{method.Description}");

            var parameterMapping = BuildParameterMapping(method);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            foreach (var parameter in passThruParameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(passThruParameters.ToArray());

            CSharpType lroObjectType = method.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(method.Operation).Type
                : context.Library.GetNonLongRunningOperation(method.Operation).Type;
            CSharpType responseType = lroObjectType.WrapAsync(async);

            writer.Append($"public {AsyncKeyword(async)} {VirtualKeyword(isVirtual)} {responseType} {CreateMethodName($"Start{methodName}", async)}(");
            foreach (var parameter in passThruParameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(passThruParameters.ToArray());

                Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.Start{methodName}", Array.Empty<DiagnosticAttribute>());
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    var response = new CodeWriterDeclaration("response");
                    response.SetActualName(response.RequestedName);
                    if (method.Operation.IsAncestorScope() || methods == null || methods.Count < 2)
                    {
                        WriteStartLROMethodBody(writer, method, lroObjectType, context, response, parameterMapping, async);
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
                                    using (writer.Scope($"if (Id.ResourceType.Equals(ResourceGroupOperations.ResourceType))"))
                                    {
                                        WriteStartLROMethodBody(writer, resourceGroupMethod, lroObjectType, context, response, BuildParameterMapping(resourceGroupMethod), async);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteStartLROMethodBody(writer, resourceGroupMethod, lroObjectType, context, response, BuildParameterMapping(resourceGroupMethod), async, isResourceLevel: true);
                                    }
                                }
                                else
                                {
                                    WriteStartLROMethodBody(writer, resourceGroupMethod, lroObjectType, context, response, BuildParameterMapping(resourceGroupMethod), async);
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
                                WriteStartLROMethodBody(writer, subscriptionMethod, lroObjectType, context, response, BuildParameterMapping(subscriptionMethod), async);
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
                                        WriteStartLROMethodBody(writer, managementGroupMethod, lroObjectType, context, response, BuildParameterMapping(managementGroupMethod), async);
                                    }
                                    using (writer.Scope($"else"))
                                    {
                                        WriteStartLROMethodBody(writer, tenantMethod, lroObjectType, context, response, BuildParameterMapping(tenantMethod), async);
                                    }
                                }
                                else
                                {
                                    WriteStartLROMethodBody(writer, managementGroupMethod, lroObjectType, context, response, BuildParameterMapping(managementGroupMethod), async);
                                }
                            }
                        }
                        else if (tenantMethod != null)
                        {
                            methodDict.Remove(tenantMethod);
                            using (writer.Scope($"{elseStr}"))
                            {
                                WriteStartLROMethodBody(writer, tenantMethod, lroObjectType, context, response, BuildParameterMapping(tenantMethod), async);
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

        private void WriteStartLROMethodBody(CodeWriter writer, RestClientMethod clientMethod, CSharpType lroObjectType, BuildContext<MgmtOutputLibrary> context, CodeWriterDeclaration response, IEnumerable<ParameterMapping> parameterMapping, bool async, bool isResourceLevel = false)
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
            BuildAndWriteParameters(writer, clientMethod, isResourceLevel);
            writer.Append($"cancellationToken)");

            if (async)
            {
                writer.Append($".ConfigureAwait(false)");
            }
            writer.Line($";");

            WriteStartLROResponse(writer, clientMethod, lroObjectType, context, response, parameterMapping);
        }

        protected void WriteStartLROResponse(CodeWriter writer, RestClientMethod clientMethod, CSharpType lroObjectType, BuildContext<MgmtOutputLibrary> context, CodeWriterDeclaration response, IEnumerable<ParameterMapping> parameterMapping)
        {
            Debug.Assert(clientMethod.Operation != null);

            writer.Append($"return new {lroObjectType}(");

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
            writer.Append($"{response});");
        }

    }
}
