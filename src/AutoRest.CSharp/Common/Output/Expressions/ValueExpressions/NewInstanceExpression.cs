// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record NewInstanceExpression(CSharpType Type, IReadOnlyList<ValueExpression> Parameters, ObjectInitializerExpression? InitExpression = null) : ValueExpression
    {
        private const int SingleLineParameterThreshold = 6;

        public sealed override void Write(CodeWriter writer)
        {
            writer.Append($"new {Type}");
            if (Parameters.Count > 0 || InitExpression is not { Parameters.Count: > 0 })
            {
                writer.WriteArguments(Parameters, Parameters.Count < SingleLineParameterThreshold);
            }

            if (InitExpression is { Parameters.Count: > 0 })
            {
                InitExpression.Write(writer);
            }
        }
    }
}
