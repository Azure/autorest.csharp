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
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class PagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private CSharpType PageItemType { get; }

        public PagingOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args, OperationPaging paging, ClientPagingMethodParameters parameters)
            : base(args, paging, args.StatusCodeSwitchBuilder, parameters)
        {
            PageItemType = args.StatusCodeSwitchBuilder.PageItemType ?? throw new InvalidOperationException($"Method {args.Operation.Name} is pageable and has to have a return value");
        }

        protected override bool ShouldConvenienceMethodGenerated() => true;

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            var createRequestArguments = CreateMessageMethodParameters.Select(p => new ParameterReference(p));
            MethodBodyStatement firstPageRequestLine = DeclareFirstPageRequestLocalFunction(null, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                var nextPageArguments = CreateNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, CreateNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, typeof(BinaryData), CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, CreateMessageRequestContext, async));

            return nextPageRequestLine is not null
                ? new[]{firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{firstPageRequestLine, returnLine};
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            var createRequestArguments = new List<ValueExpression>();
            var parameterConversions = AddPageableMethodArguments(createRequestArguments, out var requestContextVariable).AsStatement();
            var firstPageRequestLine = DeclareFirstPageRequestLocalFunction(RestClient, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            DeclarationStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(RestClient, CreateNextPageMessageMethodName, createRequestArguments.Prepend(KnownParameters.NextLink), out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, PageItemType, CreateScopeName(methodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterConversions, firstPageRequestLine, returnLine};
        }

        protected override Method BuildLegacyConvenienceMethod(bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, ConvenienceModifiers, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var body = CreateLegacyConvenienceMethodBody(async);

            return new Method(signature.WithAsync(async), body);
        }

        private MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async)
        {
            var createRequestArguments = new List<ValueExpression>();
            var parameterValidations = new ParameterValidationBlock(ConvenienceMethodParameters);
            var parameterConversions = AddPageableMethodArguments(createRequestArguments, out var requestContextVariable).AsStatement();
            var firstPageRequestLine = DeclareFirstPageRequestLocalFunction(RestClient, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            DeclarationStatement? nextPageRequestLine = null;
            if (CreateNextPageMessageMethodName is not null)
            {
                var arguments = CreateNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(RestClient, CreateNextPageMessageMethodName, arguments, out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, new MemberExpression(null, $"_{KnownParameters.ClientDiagnostics.Name}"), PipelineField, PageItemType, CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterValidations, parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterValidations, parameterConversions, firstPageRequestLine, returnLine};
        }
    }
}
