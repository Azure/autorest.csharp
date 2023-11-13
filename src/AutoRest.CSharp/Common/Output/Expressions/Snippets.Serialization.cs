// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class Serializations
        {
            private readonly static StringExpression _wireFormat = Literal("W");
            public static StringExpression WireFormat => _wireFormat;
            private readonly static StringExpression _jsonFormat = Literal("J");
            public static StringExpression JsonFormat => _jsonFormat;
            private readonly static StringExpression _xmlFormat = Literal("X");
            public static StringExpression XmlFormat => _xmlFormat;

            public static MethodBodyStatement WrapInCheckIsJson(PropertySerialization serialization, ValueExpression format, MethodBodyStatement statement)
            {
                if (!serialization.ShouldExcludeInWireSerialization)
                {
                    return statement;
                }

                return new IfStatement(Equal(format, JsonFormat))
                {
                    statement
                };
            }
        }
    }
}
