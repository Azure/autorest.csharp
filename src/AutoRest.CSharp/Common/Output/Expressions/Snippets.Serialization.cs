// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.ClientModel;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class Serializations
        {
            private static readonly ValueExpression jsonFormat = new TypeReference(typeof(ModelReaderWriterFormat)).Property(nameof(ModelReaderWriterFormat.Json));

            public static MethodBodyStatement WrapInCheckIsJson(PropertySerialization serialization, ValueExpression format, MethodBodyStatement statement)
            {
                if (!serialization.ShouldExcludeInWireSerialization)
                {
                    return statement;
                }

                return new IfStatement(Equal(format, jsonFormat))
                {
                    statement
                };
            }
        }
    }
}
