// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.System
{
    internal partial class SystemExtensibleSnippets
    {
        private class SystemArgumentSnippets : ArgumentSnippets
        {
            public override MethodBodyStatement AssertNotNull(ValueExpression variable)
                => new InvokeStaticMethodStatement(typeof(ClientUtilities), nameof(ClientUtilities.AssertNotNull), variable, Nameof(variable));

            public override MethodBodyStatement AssertNotNullOrEmpty(ValueExpression variable)
                => new InvokeStaticMethodStatement(typeof(ClientUtilities), nameof(ClientUtilities.AssertNotNullOrEmpty), variable, Nameof(variable));
        }
    }
}
