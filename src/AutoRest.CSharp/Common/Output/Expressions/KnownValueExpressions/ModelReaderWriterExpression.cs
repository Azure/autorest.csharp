// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal static class ModelReaderWriterExpression
    {
        public static BinaryDataExpression Write(ValueExpression model, ModelReaderWriterOptionsExpression options)
            => new(new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write), new[] { model, options }));

        public static InvokeStaticMethodExpression Read(CSharpType modelType, ValueExpression data, ModelReaderWriterOptionsExpression options)
            => new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Read), new[] { data, options }, TypeArguments: new[] { modelType });
    }
}
