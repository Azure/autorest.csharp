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
        protected const string BaseUriField = "BaseUri";

        protected CodeWriter _writer;
        protected override string RestClientField => "_" + RestClientVariable;
        protected override string RestClientAccessibility => "private";
        protected virtual string ContextProperty => "";
        protected BuildContext<MgmtOutputLibrary> Context { get; }
        protected MgmtConfiguration Config => Context.Configuration.MgmtConfiguration;

        protected abstract TypeProvider This { get; }
        protected abstract CSharpType TypeOfThis { get; }
        /// <summary>
        /// ClassName is the name of the class which this writer is writing
        /// </summary>
        protected virtual string TypeNameOfThis => TypeOfThis.Name;

        protected virtual string Accessibility => "public";

        protected MgmtClientBaseWriter(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = writer;
            Context = context;
        }

        public abstract void Write();

        protected virtual void WriteChildResourceEntries(string current)
        {
            foreach (var resource in Context.Library.ArmResources)
            {
                var parents = resource.Parent(Context);
                if (!parents.Contains(This))
                    continue;

                if (resource.IsSingleton)
                    WriteChildSingletonResourceEntry(resource, current);
                else
                    WriteChildNonSingletonResourceEntry(resource, current);
            }
        }

        private void WriteChildNonSingletonResourceEntry(Resource resource, string current)
        {
            var container = resource.ResourceContainer;
            if (container == null)
                throw new InvalidOperationException($"We are about to write a {resource.ResourceName} resource entry in {current} resource, but it does not have a container, this cannot happen");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets a list of {container.ResourceName.ToPlural()} in the {current}.");
            _writer.WriteXmlDocumentationReturns($"An object representing collection of {container.ResourceName.ToPlural()} and their operations over a {current}.");
            using (_writer.Scope($"public {container.Type} Get{container.ResourceName.ToPlural()}()"))
            {
                _writer.Line($"return new {container.Type}(this);");
            }
        }

        private void WriteChildSingletonResourceEntry(Resource singletonResource, string current)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {singletonResource.Type.Name} along with the instance operations that can be performed on it.");
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{singletonResource.Type.Name}\" /> object.");
            using (_writer.Scope($"public {singletonResource.Type} Get{singletonResource.Type.Name}()"))
            {
                // we cannot guarantee that the singleResourceSuffix can only have two segments (it has many different cases),
                // therefore instead of using the extension method of ResourceIdentifier, we are just concatting this as a string
                _writer.Line($"return new {singletonResource.Type.Name}(this, Id + \"/{singletonResource.SingletonResourceIdSuffix!}\");");
            }
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
                writer.Line($"{RestClientAccessibility} readonly {client.Type} {GetRestClientVariableName(client)};");
            }
        }

        protected virtual string GetRestClientVariableName(RestClient client)
        {
            return $"_{client.OperationGroup.Key.ToVariableName()}RestClient";
        }

        protected void WriteGetResponse(CodeWriter writer, CSharpType resourceType, bool isAsync)
        {
            writer.Line($"if (response.Value == null)");
            writer.Line($"throw {GetAwait(isAsync)} {ClientDiagnosticsField}.CreateRequestFailedException{GetAsyncSuffix(isAsync)}(response.GetRawResponse()){GetConfigureAwait(isAsync)};");
            writer.Line($"return {typeof(Response)}.FromValue(new {resourceType}({ContextProperty}, response.Value), response.GetRawResponse());");
        }

        //protected void WriteList(CodeWriter writer, bool async, CSharpType resourceType, PagingMethod listMethod, string methodName, FormattableString converter, List<PagingMethod>? listMethods = null)
        //{
        //    // if we find a proper *list* method that supports *paging*,
        //    // we should generate paging logic (PageableHelpers.CreateEnumerable)
        //    // else we just call ListAsGenericResource to get the list then call Get on every resource

        //    writer.Line();
        //    writer.WriteXmlDocumentationSummary($"{listMethod.Method.Description}");

        //    var nonPathDomainParameters = listMethod.NonPathDomainParameters;
        //    foreach (var param in nonPathDomainParameters)
        //    {
        //        writer.WriteXmlDocumentationParameter(param);
        //    }
        //    writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
        //    FormattableString returnText = $"{(async ? "An async" : "A")} collection of <see cref=\"{resourceType.Name}\" /> that may take multiple service requests to iterate over.";
        //    writer.WriteXmlDocumentation("returns", returnText);

        //    var returnType = resourceType.WrapPageable(async);

        //    writer.Append($"public {GetVirtual(true)} {returnType} {CreateMethodName(methodName, async)}(");
        //    foreach (var param in nonPathDomainParameters)
        //    {
        //        writer.WriteParameter(param);
        //    }
        //    writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

        //    using (writer.Scope())
        //    {
        //        WritePagingOperationBody(writer, listMethod, resourceType, RestClientField, new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>()), ClientDiagnosticsField, converter, async, listMethods);
        //    }
        //}

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

        protected virtual void WritePagingMethod(MgmtClientOperation clientOperation, string methodName, bool async)
        {
            _writer.Line();
            // get the corresponding MgmtClientOperation mapping
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            // build contextual parameters
            var contextualParameterMappings = operationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(Context));
            // build parameter mapping
            var parameterMappings = operationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Method.BuildParameterMapping(contextualParameterMappings[pair.Key]));
            // we have ensured the operations corresponding to different OperationSet have the same method parameters, therefore here we just need to use the first operation to get the method parameters
            var methodParameters = parameterMappings.Values.First().GetPassThroughParameters();
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");

            // TODO -- find a better way to get this type
            var itemType = clientOperation.First(restOperation => restOperation.IsPagingOperation(Context)).GetPagingMethod(Context)!.PagingResponse.ItemType;
            _writer.WriteXmlDocumentationReturns($"{(async ? "An async" : "A")} collection of <see cref=\"{itemType.Name}\" /> that may take multiple service requests to iterate over.");

            var returnType = itemType.WrapPageable(async);

            _writer.Append($"public virtual {returnType} {CreateMethodName(methodName, async)}(");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (_writer.Scope())
            {
                _writer.WriteParameterNullChecks(methodParameters);

                var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());
                WritePagingMethodBody(_writer, itemType, diagnostic, operationMappings, parameterMappings, async);
            }
        }

        protected void WritePagingMethodBody(CodeWriter writer, CSharpType itemType, Diagnostic diagnostic,
            IDictionary<RequestPath, MgmtRestOperation> operationMappings,
            IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async)
        {
            // we need to write multiple branches for a paging method
            if (operationMappings.Count == 1)
            {
                // if we only have one branch, we would not need those if-else statements
                var branch = operationMappings.Keys.First();
                WritePagingMethodBranch(writer, itemType, diagnostic, operationMappings[branch], parameterMappings[branch], async);
            }
            else
            {
                // branches go here
                throw new NotImplementedException("multi-branch GET not supported yet");
            }
        }

        protected void WritePagingMethodBranch(CodeWriter writer, CSharpType resourceType, Diagnostic diagnostic, MgmtRestOperation operation,
            IEnumerable<ParameterMapping> parameterMappings, bool async)
        {
            var pagingMethod = operation.GetPagingMethod(Context)!;
            var returnType = new CSharpType(typeof(Page<>), resourceType).WrapAsync(async);

            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;

            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";
            using (writer.Scope($"{GetAsyncKeyword(async)} {returnType} FirstPageFunc({typeof(int?)} pageSizeHint)"))
            {
                // no null-checks because all are optional
                WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                {
                    WritePageFunctionBody(writer, pagingMethod, operation, parameterMappings, async, false);
                });
            }

            var nextPageFunctionName = "null";
            if (pagingMethod.NextPageMethod != null)
            {
                nextPageFunctionName = "NextPageFunc";
                var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                using (writer.Scope($"{GetAsyncKeyword(async)} {returnType} {nextPageFunctionName}({typeof(string)} nextLink, {typeof(int?)} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
                    {
                        WritePageFunctionBody(writer, pagingMethod, operation, parameterMappings, async, true);
                    });
                }
            }
            writer.Line($"return {typeof(PageableHelpers)}.{CreateMethodName("Create", async)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
        }

        private void WritePageFunctionBody(CodeWriter writer, PagingMethod pagingMethod, MgmtRestOperation operation,
            IEnumerable<ParameterMapping> parameterMappings, bool isAsync, bool isNextPageFunc)
        {
            var nextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            var itemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            var continuationTokenText = nextLinkName != null ? $"response.Value.{nextLinkName}" : "null";

            writer.Append($"var response = {GetAwait(isAsync)} {GetRestClientVariableName(operation.RestClient)}.{CreateMethodName(isNextPageFunc ? pagingMethod.NextPageMethod!.Name : pagingMethod.Method.Name, isAsync)}({GetNextLink(isNextPageFunc)}");
            WriteArguments(writer, parameterMappings);
            writer.Line($"cancellationToken: cancellationToken){GetConfigureAwait(isAsync)};");

            // only when we are listing ourselves, we use Select to convert XXXResourceData to XXXResource
            var converter = string.Empty;
            // TODO -- implement converter
            //if (!string.IsNullOrEmpty(converter.ToString()))
            //{
            //    writer.UseNamespace("System.Linq");
            //}
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
