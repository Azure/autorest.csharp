// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record NewDictionaryExpression(CSharpType Type, DictionaryInitializerExpression? Values = null) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.Append($"new {Type}");
            if (Values is { Values.Count: > 0 })
            {
                Values.Write(writer);
            }
            else
            {
                writer.AppendRaw("()");
            }
        }
    }
}
