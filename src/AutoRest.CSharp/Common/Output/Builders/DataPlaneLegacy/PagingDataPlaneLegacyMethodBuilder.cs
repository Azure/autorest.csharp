// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class PagingDataPlaneLegacyMethodBuilder : DataPlaneLegacyMethodBuilderBase
    {
        private readonly TypedValueExpression _restClient;
        private readonly MethodSignature _convenienceMethod;
        private readonly MethodSignature _createMessageMethod;
        private readonly MethodSignature? _createNextPageMessageMethod;
        private readonly CSharpType _pageItemType;
        private string? _nextLinkName;
        private string _itemPropertyName;

        public PagingDataPlaneLegacyMethodBuilder(string clientName, ClientFields fields, TypedValueExpression restClient, MethodSignature convenienceMethod, MethodSignature createMessageMethod, MethodSignature? createNextPageMessageMethod, CSharpType pageItemType, string itemPropertyName, string? nextLinkName)
            : base(clientName, fields)
        {
            _restClient = restClient;
            _convenienceMethod = convenienceMethod;
            _createMessageMethod = createMessageMethod;
            _createNextPageMessageMethod = createNextPageMessageMethod;
            _pageItemType = pageItemType;
            _itemPropertyName = itemPropertyName;
            _nextLinkName = nextLinkName;
        }

        protected override Method BuildLegacyConvenienceMethod(bool async)
        {
            var signature = _convenienceMethod with {Modifiers = _convenienceMethod.Modifiers | MethodSignatureModifiers.Virtual, ReturnType = new CSharpType(typeof(Pageable<>), _pageItemType)};
            var body = CreateLegacyConvenienceMethodBody(signature, async);

            return new Method(signature.WithAsync(async), body);
        }

        private MethodBodyStatement CreateLegacyConvenienceMethodBody(MethodSignature signature, bool async)
        {
            var clientDiagnosticsField = new MemberExpression(null, ClientDiagnosticsField.Name);
            var cancellationTokenParameter = signature.Parameters.Contains(KnownParameters.CancellationTokenParameter)
                ? (ValueExpression)KnownParameters.CancellationTokenParameter
                : null;

            var scopeName = CreateScopeName(signature.Name);

            CodeWriterDeclaration createFirstPageRequest;
            if (_createNextPageMessageMethod is null)
            {
                return new MethodBodyStatement[]
                {
                    new ParameterValidationBlock(signature.Parameters),
                    DeclareFirstPageRequestLocalFunction(_restClient, _createMessageMethod.Name, _createMessageMethod.Parameters.Select(p => (ValueExpression)p), out createFirstPageRequest),
                    Return(CreatePageable(createFirstPageRequest, null, clientDiagnosticsField, PipelineField, _pageItemType, scopeName, _itemPropertyName, _nextLinkName, cancellationTokenParameter, async))
                };
            }

            return new MethodBodyStatement[]
            {
                new ParameterValidationBlock(signature.Parameters),
                DeclareFirstPageRequestLocalFunction(_restClient, _createMessageMethod.Name, _createMessageMethod.Parameters.Select(p => (ValueExpression)p), out createFirstPageRequest),
                DeclareNextPageRequestLocalFunction(_restClient, _createNextPageMessageMethod.Name, _createNextPageMessageMethod.Parameters.Select(p => (ValueExpression)p), out var createNextPageRequest),
                Return(CreatePageable(createFirstPageRequest, createNextPageRequest, clientDiagnosticsField, PipelineField, _pageItemType, scopeName, _itemPropertyName, _nextLinkName, cancellationTokenParameter, async))
            };
        }
    }
}
