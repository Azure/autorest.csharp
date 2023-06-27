// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
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
    internal class LroPagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private readonly OperationLongRunning _longRunning;
        private readonly CSharpType? _lroType;

        public LroPagingOperationMethodsBuilder(OperationLongRunning longRunning, OperationPaging paging, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, CSharpType? lroType, StatusCodeSwitchBuilder statusCodeSwitchBuilder, ClientPagingMethodParameters parameters)
            : base(paging, operation, restClient, fields, clientName, statusCodeSwitchBuilder, parameters)
        {
            _longRunning = longRunning;
            _lroType = lroType;
        }

        protected override bool ShouldConvenienceMethodGenerated() => false;

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                var nextPageArguments = CreateNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, CreateNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            MethodBodyStatement declareMessageLine = Declare("message", InvokeCreateRequestMethod(null), out var message);
            MethodBodyStatement returnLine = Return(CreatePageable(message, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, typeof(BinaryData), _longRunning.FinalStateVia, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, CreateMessageRequestContext, async));

            var body = nextPageRequestLine is not null
                ? new[]{nextPageRequestLine, declareMessageLine, returnLine}
                : new[]{declareMessageLine, returnLine};

            return WrapInDiagnosticScope(ProtocolMethodName, body);
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
            => throw new NotSupportedException("LRO Paging isn't supported yet!");

        protected override Method BuildLegacyConvenienceMethod(bool async)
        {
            if (_lroType is null)
            {
                throw new InvalidOperationException();
            }

            var methodName = $"Start{ProtocolMethodName}";
            var arguments = ConvenienceMethodParameters.Select(p => new ParameterReference(p)).ToList();

            var signature = CreateMethodSignature(methodName, ConvenienceModifiers, ConvenienceMethodParameters, _lroType);
            var nextLink = new CodeWriterDeclaration(KnownParameters.NextLink.Name);
            var nextPageDelegate = CreateNextPageMessageMethodName is not null
                ? new FuncExpression(new[]{null, nextLink}, InvokeCreateRequestMethod(RestClient, CreateNextPageMessageMethodName, CreateNextPageMessageMethodParameters))
                : Null;

            var body = new[]
            {
                new ParameterValidationBlock(ConvenienceMethodParameters, true),
                WrapInDiagnosticScopeLegacy(methodName,
                    Var("originalResponse", InvokeProtocolMethod(RestClient, arguments, async), out var response),
                    Return(New.Instance(_lroType, new MemberReference(null, $"_{KnownParameters.ClientDiagnostics.Name}"), PipelineField, InvokeCreateRequestMethod(RestClient).Request, response, nextPageDelegate))
                )
            };

            return new Method(signature.WithAsync(async), body);
        }
    }
}
