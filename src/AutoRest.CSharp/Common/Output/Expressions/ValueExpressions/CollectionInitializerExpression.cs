// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record CollectionInitializerExpression(params ValueExpression[] Items) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            writer.AppendRaw("{ ");
            foreach (var item in Items)
            {
                item.Write(writer);
                writer.AppendRaw(",");
            }

            writer.RemoveTrailingComma();
            writer.AppendRaw(" }");
        }
    }
}
