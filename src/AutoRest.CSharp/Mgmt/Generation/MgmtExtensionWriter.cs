// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        private MgmtExtensions This { get; }

        public MgmtExtensionWriter(MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context)
            : base(new CodeWriter(), extensions, context)
        {
            This = extensions;
            Extension = extensions;
            ExtensionOperationVariableType = extensions.ArmCoreType;
            ExtensionOperationVariableName = IsArmCore ? "this" : ExtensionOperationVariableType.Name.ToVariableName();
            ExtensionParameter = new Parameter(
                ExtensionOperationVariableName,
                $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.",
                ExtensionOperationVariableType,
                null,
                false);
        }

        public MgmtExtensions Extension { get; }

        protected virtual string ExtensionOperationVariableName { get; }

        protected Type ExtensionOperationVariableType { get; }

        protected override string BranchIdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string ContextProperty => ExtensionOperationVariableName;

        protected Parameter ExtensionParameter { get; }

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            List<Parameter> adjustedParameters = new List<Parameter>();
            if (!IsArmCore)
                adjustedParameters.Add(ExtensionParameter);
            adjustedParameters.AddRange(clientOperation.MethodParameters);
            // we need to identify this operation belongs to which category: NormalMethod, NormalListMethod, LROMethod or PagingMethod
            if (clientOperation.IsLongRunningOperation && !clientOperation.IsPagingOperation)
            {
                if (clientOperation.ReturnType is null)
                    throw new InvalidOperationException($"LRO method had null return type {clientOperation.RestClient.Type.Name}.{clientOperation.Name}");
                // this is a non-pageable long-running operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType.WrapAsync(isAsync), adjustedParameters, isAsync, false);
            }
            else if (clientOperation.IsLongRunningOperation && clientOperation.IsPagingOperation)
            {
                // this is a pageable long-running operation
                throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");
            }
            else if (clientOperation.IsPagingOperation)
            {
                // this is a paging operation
                if (clientOperation.ReturnType is null)
                    throw new InvalidOperationException($"Found null return type for {clientOperation.RestClient.Declaration.Name}.{clientOperation.Name}, original was ({clientOperation.OriginalReturnType}).");
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType.WrapPageable(isAsync), adjustedParameters, isAsync, true);
            }
            else
            {
                // this is a normal operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType.WrapAsync(isAsync), adjustedParameters, isAsync, false);
            }
        }

        private void WriteMethodSignatureWrapper(CSharpType actualItemType, string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging)
        {
            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }

            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            if (isPaging)
                _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            string asyncText = isPaging ? string.Empty : GetAsyncKeyword(isAsync);
            string thisText = methodParameters.Count > 0 && methodParameters.First().Equals(ExtensionParameter) ? "this " : string.Empty;
            _writer.Append($"public static {asyncText} {actualItemType} {CreateMethodName(methodName, isAsync)}({thisText}");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }

            _writer.RemoveTrailingComma();
            _writer.Line($")");
        }

        protected override void WritePrivateHelpers()
        {
            _writer.Line();
            string staticText = IsArmCore ? string.Empty : "static ";
            FormattableString signatureParamText = IsArmCore ? (FormattableString)$"" : (FormattableString)$"{ExtensionOperationVariableType} {ExtensionOperationVariableName}";
            using (_writer.Scope($"private {staticText}{ExtensionOperationVariableType.Name}ExtensionClient GetExtensionClient({signatureParamText})"))
            {
                using (_writer.Scope($"return {ExtensionOperationVariableName}.GetCachedClient((armClient) =>"))
                {
                    _writer.Line($"return new {ExtensionOperationVariableType.Name}ExtensionClient(armClient, {ExtensionOperationVariableName}.Id);");
                }
                _writer.Line($");");
            }
        }

        private void WriteMethodWrapperImpl(
            MgmtClientOperation clientOperation,
            string methodName,
            CSharpType itemType,
            IReadOnlyList<Parameter> methodParameters,
            bool async,
            bool isPaging)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            WriteMethodSignatureWrapper(itemType, methodName, methodParameters, async, isPaging);
            using (_writer.Scope())
            {
                WriteMethodBodyWrapper(methodName, methodParameters, async, isPaging);
            }
        }

        private void WriteMethodBodyWrapper(string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging)
        {
            string asyncText = isAsync ? "Async" : string.Empty;
            string configureAwait = isAsync & !isPaging ? ".ConfigureAwait(false)" : string.Empty;
            string awaitText = isAsync & !isPaging ? " await" : string.Empty;
            _writer.Append($"return{awaitText} GetExtensionClient({ExtensionOperationVariableName}).{methodName}{asyncText}(");

            foreach (var parameter in methodParameters.Skip(1))
            {
                _writer.Append($"{parameter.Name},");
            }

            _writer.RemoveTrailingComma();
            _writer.Line($"){configureAwait};");
        }

        protected override void WriteResourceCollectionEntry(ResourceCollection resourceCollection) => WriteGetChildEntry(resourceCollection, $"Get{resourceCollection.Resource.Type.Name.ResourceNameToPlural()}");

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceSuffix) => WriteGetChildEntry(resource, $"Get{resource.Type.Name}");

        private void WriteGetChildEntry(MgmtTypeProvider mgmtTypeProvider, string methodName)
        {
            List<Parameter> parameters = new List<Parameter>();
            if (!IsArmCore)
                parameters.Add(ExtensionParameter);
            parameters.AddRange(mgmtTypeProvider.ExtraConstructorParameters);
            WriteMethodSignatureWrapper(mgmtTypeProvider.Type, methodName, parameters, isAsync: false, isPaging: false);
            using (_writer.Scope())
            {
                WriteMethodBodyWrapper(methodName, parameters, isAsync: false, isPaging: false);
            }
        }

        protected override void WriteLROMethodBranch(CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestClientName(operation)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, GetDiagnosticName(operation), "Pipeline", operation, parameterMapping, async);
        }
    }
}
