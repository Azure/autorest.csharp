// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal record BodyRequestPart(string? NameInRequest, TypedValueExpression Value, TypedValueExpression ConvertedValue, MethodBodyStatement? Conversion, bool SkipNullCheck);
}
