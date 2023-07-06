// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResourceTypeExpression(ValueExpression Untyped) : TypedValueExpression(typeof(ResourceType), Untyped)
    {
        public StringExpression Namespace => new(new MemberExpression(Untyped, nameof(ResourceType.Namespace)));

        public StringExpression GetLastType() => new(new InvokeInstanceMethodExpression(Untyped, nameof(ResourceType.GetLastType)));
    }
}
