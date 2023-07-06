// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record BinaryDataExpression(ValueExpression Untyped) : TypedValueExpression(typeof(BinaryData), Untyped)
    {
        public FrameworkTypeExpression ToObjectFromJson(CSharpType responseType)
            => new(responseType, new InvokeInstanceMethodExpression(Untyped, nameof(BinaryData.ToObjectFromJson), Array.Empty<ValueExpression>(), new[]{responseType}, false));

        public static BinaryDataExpression FromStream(ResponseExpression response, bool async)
        {
            var methodName = async ? nameof(BinaryData.FromStreamAsync) : nameof(BinaryData.FromStream);
            return new BinaryDataExpression(new InvokeStaticMethodExpression(typeof(BinaryData), methodName, new[]{response.ContentStream}));
        }

        public ValueExpression ToStream() => Invoke(nameof(BinaryData.ToStream));

        public static BinaryDataExpression FromString(ValueExpression data)
            => new(new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromString), new[]{data}));
    }
}
