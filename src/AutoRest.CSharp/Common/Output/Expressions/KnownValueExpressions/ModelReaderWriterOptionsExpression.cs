// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal record ModelReaderWriterOptionsExpression(ValueExpression Untyped) : TypedValueExpression<ModelReaderWriterOptions>(Untyped)
    {
        public static ModelReaderWriterOptionsExpression Wire => new(new MemberExpression(typeof(ModelReaderWriterOptions), nameof(ModelReaderWriterOptions.Wire)));

        public ValueExpression Format => new MemberExpression(this, nameof(ModelReaderWriterOptions.Format));
    }
}
