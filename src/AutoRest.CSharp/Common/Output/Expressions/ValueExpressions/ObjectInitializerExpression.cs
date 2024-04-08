// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record ObjectInitializerExpression(IReadOnlyDictionary<string, ValueExpression>? Parameters = null, bool UseSingleLine = true) : InitializerExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Parameters is not { Count: > 0 })
            {
                writer.AppendRaw("{}");
                return;
            }

            if (UseSingleLine)
            {
                writer.AppendRaw("{");
                foreach (var (name, value) in Parameters)
                {
                    writer.Append($"{name} = ");
                    value.Write(writer);
                    writer.AppendRaw(", ");
                }

                writer.RemoveTrailingComma();
                writer.AppendRaw("}");
            }
            else
            {
                writer.Line();
                writer.LineRaw("{");
                foreach (var (name, value) in Parameters)
                {
                    writer.Append($"{name} = ");
                    value.Write(writer);
                    writer.LineRaw(",");
                }
                // Commented to minimize changes in generated code
                //writer.RemoveTrailingComma();
                //writer.Line();
                writer.AppendRaw("}");
            }
        }
    }
}
