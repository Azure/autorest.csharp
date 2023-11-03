// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal record ModelReaderWriterFormatExpression(ValueExpression Untyped) : TypedValueExpression<ModelReaderWriterFormat>(Untyped)
    {
        public static ModelReaderWriterFormatExpression Json => new(new MemberExpression(typeof(ModelReaderWriterFormat), nameof(ModelReaderWriterFormat.Json)));

        public static ModelReaderWriterFormatExpression Xml => new(new MemberExpression(typeof(ModelReaderWriterFormat), nameof(ModelReaderWriterFormat.Xml)));

        public static ModelReaderWriterFormatExpression Wire => new(new MemberExpression(typeof(ModelReaderWriterFormat), nameof(ModelReaderWriterFormat.Wire)));
    }
}
