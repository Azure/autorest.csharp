// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ClientModel;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record BinaryContentExpression(ValueExpression Untyped) : TypedValueExpression<BinaryContent>(Untyped)
    {
        public static BinaryContentExpression Create(ValueExpression serializable) => new(InvokeStatic(nameof(BinaryContent.Create), serializable));

        public static BinaryContentExpression Create(ValueExpression serializable, ModelReaderWriterOptionsExpression options, CSharpType? typeArgument = null) => new(new InvokeStaticMethodExpression(typeof(BinaryContent), nameof(BinaryContent.Create), new[] { serializable, options }, TypeArguments: typeArgument != null ? new[] { typeArgument } : null));
    }
}
