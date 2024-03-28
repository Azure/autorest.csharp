// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record ParameterReference(Parameter Parameter) : TypedValueExpression(Parameter.Type, new UntypedParameterReference(Parameter))
    {
        private record UntypedParameterReference(Parameter Parameter) : ValueExpression
        {
            public override void Write(CodeWriter writer)
            {
                writer.AppendRawIf("ref ", Parameter.IsRef);
                writer.Append($"{Parameter.Name:I}");
            }
        }
    }
}
