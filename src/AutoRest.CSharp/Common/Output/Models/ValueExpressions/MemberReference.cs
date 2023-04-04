// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record MemberReference(ValueExpression? Inner, string MemberName) : ValueExpression;
}
