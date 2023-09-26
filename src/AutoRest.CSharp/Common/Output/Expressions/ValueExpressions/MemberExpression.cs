// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record MemberExpression(ValueExpression? Inner, string MemberName) : ValueExpression;
    internal record TypedMemberExpression(ValueExpression? Inner, string MemberName, CSharpType MemberType) : TypedValueExpression(MemberType, new MemberExpression(Inner, MemberName));
}
