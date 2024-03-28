// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record ArrayInitializerExpression(IReadOnlyList<ValueExpression>? Elements = null, bool IsInline = true) : InitializerExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Elements is not { Count: > 0 })
            {
                writer.AppendRaw("{}");
                return;
            }

            if (IsInline)
            {
                writer.AppendRaw("{");
                foreach (var item in Elements)
                {
                    item.Write(writer);
                    writer.AppendRaw(", ");
                }

                writer.RemoveTrailingComma();
                writer.AppendRaw("}");
            }
            else
            {
                writer.Line();
                writer.LineRaw("{");
                foreach (var item in Elements)
                {
                    item.Write(writer);
                    writer.LineRaw(",");
                }

                writer.RemoveTrailingComma();
                writer.Line();
                writer.AppendRaw("}");
            }
        }
    }
}
