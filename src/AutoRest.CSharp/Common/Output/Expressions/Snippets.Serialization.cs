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
            public const string XmlWriteMethodName = "_Write";

            public static StringExpression WireFormat = Literal("W");
            public static StringExpression JsonFormat = Literal("J");
            public static StringExpression XmlFormat = Literal("X");

            public static MethodBodyStatement WrapInCheckNotWire(PropertySerialization serialization, ValueExpression format, MethodBodyStatement statement)
            {
                if (!serialization.ShouldExcludeInWireSerialization)
                    return statement;

                return new IfStatement(NotEqual(format, WireFormat))
                {
                    statement
                };
            }
        }
    }
}
