// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected MgmtRestClient? _restClient;
        protected override string RestClientField => "_" + RestClientVariable;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected const string BaseUriField = "BaseUri";

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace(typeof(Task).Namespace!);
            writer.UseNamespace("System.Linq");
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

        protected void WriteContainerCtors(CodeWriter writer, string typeOfThis, string contextArgumentType, string parentArguments)
        {
            // write protected default constructor
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class for mocking.");
            using (writer.Scope($"protected {typeOfThis}()"))
            { }

            // write "parent resource" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {typeOfThis} class.");
            writer.WriteXmlDocumentationParameter("parent", "The resource representing the parent resource.");
            using (writer.Scope($"internal {typeOfThis}({contextArgumentType} parent) : base({parentArguments})"))
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

        protected void WriteList(CodeWriter writer, bool async, CSharpType resourceType, PagingMethod listMethod, FormattableString converter)
        {
            // if we find a proper *list* method that supports *paging*,
            // we should generate paging logic (PageableHelpers.CreateEnumerable)
            // else we just call ListAsGenericResource to get the list then call Get on every resource

            var methodName = CreateMethodName("List", async);
            writer.Line();
            Parameter[] nonPathParameters = GetNonPathParameters(listMethod.Method);

            writer.WriteXmlDocumentationSummary(listMethod.Method.Description);
            foreach (var param in nonPathParameters)
            {
                writer.WriteXmlDocumentationParameter(param);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            string returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{resourceType.Name}\" /> that may take multiple service requests to iterate over.";
            writer.WriteXmlDocumentation("returns", returnText);

            var returnType = async
                ? new CSharpType(typeof(AsyncPageable<>), resourceType)
                : new CSharpType(typeof(Pageable<>), resourceType);
            var asyncText = async ? "Async" : string.Empty;

            writer.Append($"public {returnType} {methodName}(");
            foreach (var param in nonPathParameters)
            {
                writer.WriteParameter(param);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WritePagingOperationBody(writer, listMethod, async, resourceType, RestClientField, ClientDiagnosticsField, converter);
            }
        }

        /// <summary>
        /// Write paging method using `PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunction)` pattern.
        /// </summary>
        /// <param name="writer">The code writer to use.</param>
        /// <param name="pagingMethod">Paging method that contains rest methods.</param>
        /// <param name="async">Should the method be written sync or async.</param>
        /// <param name="resourceType">The reource type that is being written.</param>
        /// <param name="converter">Optional convertor for modifying the result of the rest client call.</param>
        protected void WritePagingOperationBody(CodeWriter writer, PagingMethod pagingMethod, bool async, CSharpType resourceType, string restClientName, string clientDiagnosticsName, FormattableString converter)
        {
            var parameters = pagingMethod.Method.Parameters;

            var pagedResourceType = new CSharpType(typeof(Page<>), resourceType);
            var returnType = async ? new CSharpType(typeof(Task<>), pagedResourceType) : pagedResourceType;

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            var asyncText = async ? "async" : string.Empty;
            var awaitText = async ? "await" : string.Empty;
            var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
            using (writer.Scope($"{asyncText} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, pagingMethod.Diagnostics, clientDiagnosticsName, writer =>
                {
                    writer.Append($"var response = {awaitText} {restClientName}.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                    BuildAndWriteParameters(writer, pagingMethod.Method);
                    writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");

                    writer.UseNamespace("System.Linq");
                    // need the Select() for converting XXXResourceData to XXXResource
                    writer.Append($"return {typeof(Page)}.FromValues(response.Value.{itemName}");
                    writer.Append($"{converter}");
                    writer.Line($", {continuationTokenText}, response.GetRawResponse());");
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (writer.Scope($"{asyncText} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, pagingMethod.Diagnostics, clientDiagnosticsName, writer =>
                    {
                        writer.Append($"var response = {awaitText} {restClientName}.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(nextLink, ");
                        BuildAndWriteParameters(writer, pagingMethod.NextPageMethod);
                        writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");
                        writer.Append($"return {typeof(Page)}.FromValues(response.Value.{itemName}");
                        writer.Append($"{converter}");
                        writer.Line($", {continuationTokenText}, response.GetRawResponse());");
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void BuildAndWriteParameters(CodeWriter writer, RestClientMethod method)
        {
            foreach (var parameter in BuildParameterMapping(method))
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
                else if (parameter.Type.IsStringLike() && IsMandatory(parameter))
                {
                    passThru = ShouldPassThrough(ref dotParent, parentNameStack, parameter, ref valueExpression);
                }
                parameterMapping.Add(new ParameterMapping(parameter, passThru, valueExpression));
            }

            MakeResourceNameParamPassThrough(method, parameterMapping, parentNameStack);

            // set the arguments for name parameters reversely: Id.Parent.Name, Id.Parent.Parent.Name, ...
            foreach (var parameter in parameterMapping)
            {
                if (IsMandatory(parameter.Parameter) && !parameter.IsPassThru && string.IsNullOrEmpty(parameter.ValueExpression))
                {
                    parameter.ValueExpression = parentNameStack.Pop();
                }
            }

            return parameterMapping;
        }

        protected virtual void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // if the method needs resource name (typically all non-list methods), we should make it pass-thru by
            // making the last string-like mandatory parameter (typically the resource name) pass-through
            if (!method.Name.StartsWith("List", StringComparison.InvariantCultureIgnoreCase))
            {
                var lastString = parameterMapping.LastOrDefault(parameter => parameter.Parameter.Type.IsStringLike() && IsMandatory(parameter.Parameter));
                if (lastString?.Parameter != null && !lastString.Parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    lastString.IsPassThru = true;
                    parentNameStack.Pop();
                }
            }
        }

        protected virtual bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            bool passThru = false;
            if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
            {
                valueExpression = "Id.ResourceGroupName";
            }
            else
            {
                // container.Id is the ID of parent resource, so the first name should just be `Id.Name`
                parentNameStack.Push($"Id{dotParent}.Name");
                dotParent += ".Parent";
            }

            return passThru;
        }

        protected bool IsMandatory(Parameter parameter) => parameter.DefaultValue is null;

        protected void WriteClientMethod(CodeWriter writer, RestClientMethod clientMethod, Diagnostic diagnostic, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, bool async)
        {
            CSharpType? bodyType = GetBodyTypeForList(clientMethod.ReturnType, operationGroup, context);
            bool isResourceList = bodyType != clientMethod.ReturnType;
            CSharpType responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);

            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            Parameter[] nonPathParameters = GetNonPathParameters(clientMethod);
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
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"var response = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    var parameterNames = GetParametersName(clientMethod, operationGroup, context);
                    writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}(");
                    foreach (var parameter in parameterNames)
                    {
                        writer.Append($"{parameter:I}, ");
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Line($";");

                    if (isResourceList)
                    {
                        writer.Append($"return Response.FromValue(response.Value.");
                        if (isResourceListResultType(clientMethod.ReturnType))
                        {
                            writer.Append($"Value.");
                        }
                        writer.Append($"Select(data => new {context.Library.GetArmResource(operationGroup).Declaration.Name}({ContextProperty}, data)), response.GetRawResponse())");
                    }
                    else
                    {
                        writer.Append($"return response");
                    }

                    if (bodyType == null && clientMethod.HeaderModel != null)
                    {
                        writer.Append($".GetRawResponse()");
                    }

                    writer.Line($";");
                });
            }

            writer.Line();
        }

        private bool isResourceListResultType(CSharpType? type)
        {
            return type != null && !type.IsFrameworkType && type.Implementation is SchemaObjectType schemaObject;
        }

        private CSharpType? GetBodyTypeForList(CSharpType? returnType, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            if (returnType == null)
                return null;

            var result = returnType;

            var resourceData = context.Library.GetResourceData(operationGroup);
            var areTypesEqual = AreTypesEqual(returnType, new CSharpType(typeof(IReadOnlyList<>), resourceData.Type));
            if (areTypesEqual)
            {
                return new CSharpType(typeof(IEnumerable<>), context.Library.GetArmResource(operationGroup).Type);
            }

            if (resourceData != null && isResourceListResultType(returnType) && returnType.Implementation is SchemaObjectType schemaObject)
            {
                var valueProperty = schemaObject.Properties.FirstOrDefault(p => p.Declaration.Name == "Value" &&
                    AreTypesEqual(p.Declaration.Type, new CSharpType(typeof(IReadOnlyList<>), resourceData.Type)));
                if (valueProperty != null)
                {
                    return new CSharpType(typeof(IEnumerable<>), context.Library.GetArmResource(operationGroup).Type);
                }
            }

            return result;
        }

        private bool AreTypesEqual(CSharpType left, CSharpType right)
        {
            if (left.Name != right.Name)
                return false;

            if (left.Arguments.Length != right.Arguments.Length)
                return false;

            for (int i = 0; i < left.Arguments.Length; i++)
            {
                if (left.Arguments[i].Name != right.Arguments[i].Name)
                    return false;
            }

            return true;
        }

        // This method returns an array of path and non-path parameters name
        protected string[] GetParametersName(RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            var paramNames = GetPathParametersName(clientMethod, operationGroup, context).ToList();
            var nonPathParams = GetNonPathParameters(clientMethod);
            foreach (Parameter parameter in nonPathParams)
            {
                paramNames.Add(parameter.Name);
            }

            return paramNames.ToArray();
        }

        protected string[] GetPathParametersName(RestClientMethod clientMethod, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            List<string> paramNameList = new List<string>();
            var pathParamsLength = GetPathParameters(clientMethod).Length;
            if (pathParamsLength > 0)
            {
                var isTenantParent = operationGroup.IsTenantParent(context);
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



        private static bool IsTerminalState(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            return operationGroup.ParentOperationGroup(context) == null;
        }

        // This method builds the path parameters names
        private void BuildPathParameterNames(List<string> paramNames, int paramLength, string name, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
        {
            if (IsTerminalState(operationGroup, context) && paramLength == 1)
            {
                if (operationGroup.IsTupleResource(context))
                {
                    name = $"{name}.Parent";
                    paramNames.Add($"{name}.Name");
                    paramLength--;
                    return;
                }
                paramNames.Add(GetParentValue(operationGroup, context));
                paramLength--;
            }
            else if (paramLength == 1)
            {
                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
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

                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
                if (parentOperationGroup != null)
                    BuildPathParameterNames(paramNames, paramLength, name, parentOperationGroup, context);
                else
                    BuildPathParameterNames(paramNames, paramLength, name, operationGroup, context);
            }
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
    }
}
