// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal abstract class NonPagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        protected NonPagingOperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args)
            : base(args)
        {
        }

        protected override MethodSignature? BuildCreateNextPageMessageSignature(IReadOnlyList<Parameter> createMessageParameters) => null;

        protected override MethodBodyStatement? BuildCreateNextPageMessageMethodBody(CreateMessageMethodBuilder builder, MethodSignature methodSignature) => null;

        protected override Method? BuildLegacyNextPageConvenienceMethod(IReadOnlyList<Parameter> parameters, Method? createRequestMethod, bool async) => null;
    }
}
