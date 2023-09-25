﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record BinaryDataExpression(ValueExpression Untyped) : TypedValueExpression<BinaryData>(Untyped)
    {
        public FrameworkTypeExpression ToObjectFromJson(Type responseType)
            => new(responseType, new InvokeInstanceMethodExpression(Untyped, nameof(BinaryData.ToObjectFromJson), Array.Empty<ValueExpression>(), new[] { new CSharpType(responseType) }, false));

        public static BinaryDataExpression FromStream(ResponseExpression response, bool async)
        {
            var methodName = async ? nameof(BinaryData.FromStreamAsync) : nameof(BinaryData.FromStream);
            return new BinaryDataExpression(InvokeStatic(methodName, response.ContentStream, async));
        }

        public StreamExpression ToStream() => new(Invoke(nameof(BinaryData.ToStream)));

        public ValueExpression ToArray() => Invoke(nameof(BinaryData.ToArray));

        public static BinaryDataExpression FromBytes(ValueExpression data)
            => new(InvokeStatic(nameof(BinaryData.FromBytes), data));

        public static BinaryDataExpression FromObjectAsJson(ValueExpression data)
            => new(InvokeStatic(nameof(BinaryData.FromObjectAsJson), data));

        public static BinaryDataExpression FromString(ValueExpression data)
            => new(InvokeStatic(nameof(BinaryData.FromString), data));
    }
}
