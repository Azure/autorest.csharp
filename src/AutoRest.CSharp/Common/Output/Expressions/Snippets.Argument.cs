// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        internal class Argument
        {
            public static MethodBodyStatement AssertNotNull(ValueExpression variable)
            {
                return ArgumentProvider.Instance.AssertNotNull(variable);
            }

            public static MethodBodyStatement AssertNotNullOrEmpty(ValueExpression variable)
            {
                return ArgumentProvider.Instance.AssertNotNullOrEmpty(variable);
            }

            public static MethodBodyStatement AssertNotNullOrWhiteSpace(ValueExpression variable)
            {
                return ArgumentProvider.Instance.AssertNotNullOrWhiteSpace(variable);
            }

            public static MethodBodyStatement ValidateParameter(Parameter parameter)
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
