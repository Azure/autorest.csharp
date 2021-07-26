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

        protected void WriteList(CodeWriter writer, bool async, CSharpType resourceType, PagingMethod listMethod, string name, FormattableString converter)
        {
            // if we find a proper *list* method that supports *paging*,
            // we should generate paging logic (PageableHelpers.CreateEnumerable)
            // else we just call ListAsGenericResource to get the list then call Get on every resource

            var methodName = CreateMethodName(name, async);
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

            writer.Append($"public {returnType} {methodName}(");
            foreach (var param in nonPathDomainParameters)
            {
                writer.WriteParameter(param);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WritePagingOperationBody(writer, listMethod, resourceType, RestClientField, listMethod.Diagnostics, ClientDiagnosticsField, converter, async);
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
            string restClientName, Diagnostic diagnostic, string clientDiagnosticsName, FormattableString converter, bool async)
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
                    writer.Append($"var response = {AwaitKeyword(async)} {restClientName}.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                    BuildAndWriteParameters(writer, pagingMethod.Method);
                    writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");

                    // need the Select() for converting XXXResourceData to XXXResource
                    if (!string.IsNullOrEmpty(converter.ToString()))
                    {
                        writer.UseNamespace("System.Linq");
                    }
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
                using (writer.Scope($"{AsyncKeyword(async)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, clientDiagnosticsName, writer =>
                    {
                        writer.Append($"var response = {AwaitKeyword(async)} {restClientName}.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(nextLink, ");
                        BuildAndWriteParameters(writer, pagingMethod.Method);
                        writer.Line($"cancellationToken: cancellationToken){configureAwaitText};");
                        writer.Append($"return {typeof(Page)}.FromValues(response.Value.{itemName}");
                        writer.Append($"{converter}");
                        writer.Line($", {continuationTokenText}, response.GetRawResponse());");
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
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

        protected void BuildAndWriteParameters(CodeWriter writer, RestClientMethod method)
        {
            WriteArguments(writer, BuildParameterMapping(method));
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

        protected abstract void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack);

        protected abstract bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression);

        protected bool IsMandatory(Parameter parameter) => parameter.DefaultValue is null;

        protected void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, Diagnostic diagnostic, OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, bool async, string? restClientName = null)
        {
            RestClientMethod restClientMethod = clientMethod.RestClientMethod;
            (var bodyType, bool isListFunction) = restClientMethod.GetBodyTypeForList(operationGroup, context);
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

            var methodName = CreateMethodName(clientMethod.Name, async); // note clientMethod.Name not restClientMethod.Name
            writer.Append($"{restClientMethod.Accessibility} virtual {AsyncKeyword(async)} {responseType} {methodName}(");

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

                    var parameterNames = GetParametersName(restClientMethod, operationGroup, context);
                    writer.Append($"{restClientName ?? RestClientField}.{CreateMethodName(restClientMethod.Name, async)}(");
                    // TODO -- we need to change this to BuildAndWriteParameters(writer, clientMethod) to make it be able to handle more cases
                    // but directly replace the following logic by this function is causing issues
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
                        writer.Append($"return response");
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
                var isAncestorTenant = operationGroup.IsAncestorTenant(context);
                if (pathParamsLength > 1 && !isAncestorTenant)
                {
                    paramNameList.Add("Id.Name");
                    pathParamsLength--;
                }

                BuildPathParameterNames(paramNameList, pathParamsLength, "Id", operationGroup, context);

                if (!isAncestorTenant)
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

        protected void WriteStartLROMethod(CodeWriter writer, RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool async,
            bool isVirtual = false, string? methodName = null)
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

            CSharpType lroObjectType = clientMethod.Operation.IsLongRunning
                ? context.Library.GetLongRunningOperation(clientMethod.Operation).Type
                : context.Library.GetNonLongRunningOperation(clientMethod.Operation).Type;
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
                    writer.Append($"var {response:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }
                    writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.Name, async)}( ");
                    WriteArguments(writer, parameterMapping);
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }
                    writer.Line($";");

                    WriteStartLROResponse(writer, clientMethod, lroObjectType, context, response, parameterMapping);
                });
                writer.Line();
            }
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
                if (nonLongRunningOperation.ResultType != null)
                {
                    writer.Append($"{ContextProperty}, ");
                }
            }
            writer.Append($"{response});");
        }

    }
}
