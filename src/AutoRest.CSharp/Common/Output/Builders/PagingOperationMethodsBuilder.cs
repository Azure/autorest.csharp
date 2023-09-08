// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class PagingOperationMethodsBuilder : PagingOperationMethodsBuilderBase
    {
        private CSharpType PageItemType { get; }

        public PagingOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args, OperationPaging paging, CSharpType pageItemType)
            : base(args, paging, args.StatusCodeSwitchBuilder)
        {
            PageItemType = pageItemType;
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async)
        {
            var createRequestArguments = createMessageSignature.Parameters.Select(p => new ParameterReference(p));
            MethodBodyStatement firstPageRequestLine = DeclareFirstPageRequestLocalFunction(null, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            MethodBodyStatement? nextPageRequestLine = null;
            if (createNextPageMessageSignature is not null)
            {
                var nextPageArguments = createNextPageMessageSignature.Parameters.Select(p => new ParameterReference(p));
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, createNextPageMessageSignature.Name, nextPageArguments, out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, typeof(BinaryData), CreateScopeName(ProtocolMethodName), ItemPropertyName, NextLinkName, new RequestContextExpression(KnownParameters.RequestContext), async));

            return nextPageRequestLine is not null
                ? new[]{firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{firstPageRequestLine, returnLine};
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
        {
            var createRequestArguments = new List<ValueExpression>();
            var parameterConversions = AddPageableMethodArguments(parameters, createRequestArguments, out var requestContextVariable).AsStatement();
            var firstPageRequestLine = DeclareFirstPageRequestLocalFunction(null, CreateMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            DeclarationStatement? nextPageRequestLine = null;
            if (createNextPageMessageSignature is not null)
            {
                nextPageRequestLine = DeclareNextPageRequestLocalFunction(null, createNextPageMessageSignature.Name, createRequestArguments.Prepend(KnownParameters.NextLink), out createNextPageRequest);
            }

            var returnLine = Return(CreatePageable(createFirstPageRequest, createNextPageRequest, ClientDiagnosticsProperty, PipelineField, PageItemType, CreateScopeName(methodName), ItemPropertyName, NextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new[]{parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine}
                : new[]{parameterConversions, firstPageRequestLine, returnLine};
        }
    }
}
