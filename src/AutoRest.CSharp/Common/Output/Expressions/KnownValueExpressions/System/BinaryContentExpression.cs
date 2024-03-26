// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ClientModel;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record BinaryContentExpression(ValueExpression Untyped) : TypedValueExpression<BinaryContent>(Untyped)
    {
        public static BinaryContentExpression Create(ValueExpression serializable, ModelReaderWriterOptionsExpression options) => new(InvokeStatic(nameof(BinaryContent.Create), new[] { serializable, options }));
    }
}
