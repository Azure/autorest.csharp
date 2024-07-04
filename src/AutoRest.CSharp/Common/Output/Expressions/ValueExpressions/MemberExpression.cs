﻿// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record MemberExpression(ValueExpression? Inner, string MemberName) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            if (Inner is not null)
            {
                Inner.Write(writer);
                writer.AppendRaw(".");
            }
            writer.AppendRaw(MemberName);
        }
    }
}
