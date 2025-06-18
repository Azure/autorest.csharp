// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal record ModelReaderWriterOptionsExpression(ValueExpression Untyped) : TypedValueExpression<ModelReaderWriterOptions>(Untyped)
    {
        public static readonly ModelReaderWriterOptionsExpression Wire = ModelSerializationExtensionsProvider.Instance.WireOptions;

        public static readonly ModelReaderWriterOptionsExpression Json = new(new MemberExpression(typeof(ModelReaderWriterOptions), "Json"));

        public static ValueExpression UsingSystemAssignedUserAssignedV3(ModelReaderWriterOptionsExpression? options)
        {
            if (options == Json)
            {
                return New.Instance(typeof(ModelReaderWriterOptions), Literal("J|v3"));
            }

            return New.Instance(typeof(ModelReaderWriterOptions), Literal("W|v3"));
        }

        public ValueExpression Format => new MemberExpression(this, nameof(ModelReaderWriterOptions.Format));
    }
}
