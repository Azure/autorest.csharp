// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record RawRequestUriBuilderExpression(ValueExpression Untyped) : TypedValueExpression(typeof(RawRequestUriBuilder), Untyped)
    {
        public static RawRequestUriBuilderExpression New() => new(Snippets.New(typeof(RawRequestUriBuilder)));

        public MethodBodyStatement Reset(ValueExpression uri) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.Reset), uri);
        public MethodBodyStatement AppendRaw(string value, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.AppendRaw), Literal(value), Bool(escape));
        public MethodBodyStatement AppendRaw(ValueExpression value, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.AppendRaw), value, Bool(escape));
        public MethodBodyStatement AppendPath(string value, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RequestUriBuilder.AppendPath), Literal(value), Bool(escape));
        public MethodBodyStatement AppendPath(ValueExpression value, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RequestUriBuilder.AppendPath), value, Bool(escape));
        public MethodBodyStatement AppendPath(ValueExpression value, string format, bool escape)
            => new InvokeStaticMethodStatement(typeof(RequestUriBuilderExtensions), nameof(RequestUriBuilderExtensions.AppendPath), new[]{Untyped, value, Literal(format), Bool(escape)}, CallAsExtension: true);

        public MethodBodyStatement AppendRawNextLink(string nextLink, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.AppendRawNextLink), Bool(escape));
    }
}
