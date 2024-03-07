// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record WhereExpression(CSharpType Type, IReadOnlyList<ValueExpression> Constraints) : ValueExpression
    {
        public WhereExpression(CSharpType type, ValueExpression constraint) : this(type, new[] { constraint }) { }

        public WhereExpression And(ValueExpression constraint) => new(Type, new List<ValueExpression>(Constraints) { constraint });
    }
}
