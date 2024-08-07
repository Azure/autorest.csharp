﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record NewArrayExpression(CSharpType? Type, ArrayInitializerExpression? Items = null, ValueExpression? Size = null) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Size is not null)
            {
                if (Type is null)
                {
                    writer.AppendRaw("new[");
                }
                else
                {
                    writer.Append($"new {Type}[");
                }

                Size.Write(writer);
                writer.AppendRaw("]");
                return;
            }

            if (Items is { Elements.Count: > 0 })
            {
                if (Type is null)
                {
                    writer.AppendRaw("new[]");
                }
                else
                {
                    writer.Append($"new {Type}[]");
                }

                Items.Write(writer);
            }
            else if (Type is null)
            {
                writer.AppendRaw("new[]{}");
            }
            else
            {
                writer.Append($"Array.Empty<{Type}>()");
            }
        }
    }
}
