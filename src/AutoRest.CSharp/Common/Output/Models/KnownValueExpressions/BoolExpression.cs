// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record BoolExpression(ValueExpression Untyped) : TypedValueExpression(typeof(bool), Untyped)
    {
    }

    internal sealed record EnumerableExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Dictionary<,>), Untyped)
    {
    }

    internal sealed record DictionaryExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Dictionary<,>), Untyped)
    {
    }

    internal sealed record KeyValuePairExpression(ValueExpression Untyped) : TypedValueExpression(typeof(KeyValuePair<,>), Untyped)
    {
        public ValueExpression Key => new MemberReference(Untyped, nameof(KeyValuePair<string, string>.Key));
        public ValueExpression Value => new MemberReference(Untyped, nameof(KeyValuePair<string, string>.Value));
    }
}
