// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record DictionaryInitializerExpression(IReadOnlyList<(ValueExpression Key, ValueExpression Value)>? Values = null) : InitializerExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Values is not { Count: > 0 })
            {
                writer.AppendRaw("{}");
                return;
            }

            writer.Line();
            writer.LineRaw("{");
            foreach (var (key, value) in Values)
            {
                writer.AppendRaw("[");
                key.Write(writer);
                writer.AppendRaw("] = ");
                value.Write(writer);
                writer.LineRaw(",");
            }

            writer.RemoveTrailingComma();
            writer.Line();
            writer.AppendRaw("}");
        }
    }
}
