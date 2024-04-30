// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record RawRequestUriBuilderExpression(ValueExpression Untyped) : TypedValueExpression<RawRequestUriBuilder>(Untyped)
    {
        public MethodBodyStatement Reset(ValueExpression uri) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.Reset), uri);

        public MethodBodyStatement AppendRaw(string value, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.AppendRaw), Literal(value), Bool(escape));
        public MethodBodyStatement AppendRaw(ValueExpression value, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.AppendRaw), value, Bool(escape));

        public MethodBodyStatement AppendPath(string value, bool escape) => AppendPath(Literal(value), Bool(escape));
        public MethodBodyStatement AppendPath(ValueExpression value, bool escape) => AppendPath(value, Bool(escape));
        public MethodBodyStatement AppendPath(ValueExpression value, ValueExpression escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RequestUriBuilder.AppendPath), value, escape);
        public MethodBodyStatement AppendPath(ValueExpression value, string format, bool escape)
            => RequestUriBuilderExtensionsProvider.Instance.AppendPath(this, value, format, escape);

        public MethodBodyStatement AppendPath(ValueExpression value, SerializationFormat format, bool escape)
            => format.ToFormatSpecifier() is { } formatSpecifier
                ? AppendPath(value, formatSpecifier, escape)
                : AppendPath(value, escape);

        public MethodBodyStatement AppendRawNextLink(ValueExpression nextLink, bool escape) => new InvokeInstanceMethodStatement(Untyped, nameof(RawRequestUriBuilder.AppendRawNextLink), nextLink, Bool(escape));

        public MethodBodyStatement AppendQuery(ValueExpression name, ValueExpression value, ValueExpression escape)
            => new InvokeInstanceMethodStatement(this, nameof(RequestUriBuilder.AppendQuery), name, value, escape);
        public MethodBodyStatement AppendQuery(string name, ValueExpression value, bool escape)
            => RequestUriBuilderExtensionsProvider.Instance.AppendQuery(this, Literal(name), value, Bool(escape));
        public MethodBodyStatement AppendQuery(string name, ValueExpression value, string format, bool escape)
            => RequestUriBuilderExtensionsProvider.Instance.AppendQuery(this, Literal(name), value, Literal(format), Bool(escape));
        public MethodBodyStatement AppendQuery(string name, ValueExpression value, SerializationFormat format, bool escape)
            => format.ToFormatSpecifier() is { } formatSpecifier
                ? AppendQuery(name, value, formatSpecifier, escape)
                : AppendQuery(name, value, escape);

        public MethodBodyStatement AppendQueryDelimited(string name, ValueExpression value, string delimiter, bool escape)
            => RequestUriBuilderExtensionsProvider.Instance.AppendQueryDelimited(this, Literal(name), value, Literal(delimiter), Bool(escape));
        public MethodBodyStatement AppendQueryDelimited(string name, ValueExpression value, string delimiter, string format, bool escape)
            => RequestUriBuilderExtensionsProvider.Instance.AppendQueryDelimited(this, Literal(name), value, Literal(delimiter), Literal(format), Bool(escape));
        public MethodBodyStatement AppendQueryDelimited(string name, ValueExpression value, string delimiter, SerializationFormat format, bool escape)
            => format.ToFormatSpecifier() is { } formatSpecifier
                ? AppendQueryDelimited(name, value, delimiter, formatSpecifier, escape)
                : AppendQueryDelimited(name, value, delimiter, escape);
    }
}
