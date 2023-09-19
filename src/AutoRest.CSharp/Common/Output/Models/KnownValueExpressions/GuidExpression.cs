// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record GuidExpression(ValueExpression Untyped) : TypedValueExpression<Guid>(Untyped)
    {
        public static GuidExpression NewGuid() => new(InvokeStatic(nameof(Guid.NewGuid)));
        public static GuidExpression Parse(string input) => new(InvokeStatic(nameof(Guid.Parse), Literal(input)));
    }
}
