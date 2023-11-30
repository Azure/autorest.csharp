// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.Azure
{
    internal partial class AzureExtensibleSnippets
    {
        private class AzureArgumentSnippets : ArgumentSnippets
        {
            public override MethodBodyStatement AssertNotNull(ValueExpression variable)
                => new InvokeStaticMethodStatement(typeof(Argument), nameof(Argument.AssertNotNull), variable, Nameof(variable));

            public override MethodBodyStatement AssertNotNullOrEmpty(ValueExpression variable)
                => new InvokeStaticMethodStatement(typeof(Argument), nameof(Argument.AssertNotNullOrEmpty), variable, Nameof(variable));
        }
    }
}
