// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal record ModelReaderWriterContextExpression(ValueExpression Untyped) : TypedValueExpression<ModelReaderWriterContext>(Untyped)
    {
        public static readonly ValueExpression Default = new MemberExpression(new MemberExpression(null, ModelReaderWriterContextWriter.Name), "Default");
    }
}
