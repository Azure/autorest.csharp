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
    internal sealed record RequestHeadersExpression(ValueExpression Untyped) : TypedValueExpression<RequestHeaders>(Untyped)
    {
        public MethodBodyStatement Add(ValueExpression name, ValueExpression value)
            => new InvokeInstanceMethodStatement(Untyped, nameof(RequestHeaders.Add), new[] { name, value }, false);
        public MethodBodyStatement Add(ValueExpression name, ValueExpression value, ValueExpression format)
            => RequestHeaderExtensionsProvider.Instance.Add(Untyped, name, value, format);

        public MethodBodyStatement Add(ValueExpression conditions)
            => RequestHeaderExtensionsProvider.Instance.Add(Untyped, conditions);
        public MethodBodyStatement Add(ValueExpression conditions, SerializationFormat format)
            => RequestHeaderExtensionsProvider.Instance.Add(Untyped, conditions, Literal(format.ToFormatSpecifier()));

        public MethodBodyStatement Add(string name, ValueExpression value)
            => RequestHeaderExtensionsProvider.Instance.Add(Untyped, Literal(name), value);
        public MethodBodyStatement Add(string name, ValueExpression value, string format)
            => RequestHeaderExtensionsProvider.Instance.Add(Untyped, Literal(name), value, Literal(format));
        public MethodBodyStatement Add(string name, ValueExpression value, SerializationFormat format)
            => format.ToFormatSpecifier() is { } formatSpecifier
                ? Add(name, value, formatSpecifier)
                : Add(name, value);

        public MethodBodyStatement AddDelimited(string name, ValueExpression value, string delimiter)
            => RequestHeaderExtensionsProvider.Instance.AddDelimited(Untyped, Literal(name), value, Literal(delimiter));
        public MethodBodyStatement AddDelimited(string name, ValueExpression value, string delimiter, string format)
            => RequestHeaderExtensionsProvider.Instance.AddDelimited(Untyped, Literal(name), value, Literal(delimiter), Literal(format));
        public MethodBodyStatement AddDelimited(string name, ValueExpression value, string delimiter, SerializationFormat format)
            => format.ToFormatSpecifier() is { } formatSpecifier
                ? AddDelimited(name, value, delimiter, formatSpecifier)
                : AddDelimited(name, value, delimiter);
    }
}
