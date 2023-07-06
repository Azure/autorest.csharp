// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record IndexerExpression(ValueExpression? Inner, ValueExpression Index) : ValueExpression;
}
