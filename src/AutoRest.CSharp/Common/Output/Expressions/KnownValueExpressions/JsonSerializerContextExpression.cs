// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal class JsonSerializerContextExpression
    {
        public static readonly ValueExpression Default = new MemberExpression(new MemberExpression(null, JsonSerializerContextWriter.Name), "Default");
    }
}
