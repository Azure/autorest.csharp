// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class Where
        {
            public static WhereExpression NotNull(CSharpType type) => new WhereExpression(type, new KeywordExpression("notnull", null));
            public static WhereExpression Struct(CSharpType type) => new WhereExpression(type, new KeywordExpression("struct", null));
            public static WhereExpression Class(CSharpType type) => new WhereExpression(type, new KeywordExpression("class", null));
        }
    }
}
