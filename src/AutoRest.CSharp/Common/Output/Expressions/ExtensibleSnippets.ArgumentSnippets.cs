// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract partial class ExtensibleSnippets
    {
        internal abstract class ArgumentSnippets
        {
            public abstract MethodBodyStatement AssertNotNull(ValueExpression variable);

            public abstract MethodBodyStatement AssertNotNullOrEmpty(ValueExpression variable);

            public MethodBodyStatement ValidateParameter(Parameter parameter)
            {
                return parameter.Validation switch
                {
                    ValidationType.AssertNotNullOrEmpty => AssertNotNullOrEmpty(parameter),
                    ValidationType.AssertNotNull => AssertNotNull(parameter),
                    _ => EmptyStatement
                };
            }
        }
    }
}
