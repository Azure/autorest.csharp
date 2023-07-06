// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ArmResourceExpression(ValueExpression Untyped) : TypedValueExpression(typeof(ArmResource), Untyped)
    {
        public ResourceIdentifierExpression Id { get; } = new(new MemberExpression(Untyped, nameof(ArmResource.Id)));
        public ResourceIdentifierExpression Name { get; } = new(new MemberExpression(Untyped, "Name"));
    }
}
