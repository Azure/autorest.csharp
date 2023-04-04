// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResourceIdentifierExpression(ValueExpression Untyped) : TypedValueExpression(typeof(ResourceIdentifier), Untyped)
    {
        public static ResourceIdentifierExpression ReferenceField(string fieldName) => new(new MemberReference(new ValueExpression(), fieldName));

        public StringExpression Name => new(new MemberReference(Untyped, nameof(ResourceIdentifier.Name)));
        public ResourceIdentifierExpression Parent => new(new MemberReference(Untyped, nameof(ResourceIdentifier.Parent)));
        public StringExpression Provider => new(new MemberReference(Untyped, nameof(ResourceIdentifier.Provider)));
        public ResourceTypeExpression ResourceType => new(new MemberReference(Untyped, nameof(ResourceIdentifier.ResourceType)));
        public StringExpression ResourceGroupName => new(new MemberReference(Untyped, nameof(ResourceIdentifier.ResourceGroupName)));
        public StringExpression SubscriptionId => new(new MemberReference(Untyped, nameof(ResourceIdentifier.SubscriptionId)));

        public StringExpression SubstringAfterProviderNamespace() => new(new InvokeStaticMethodExpression(typeof(SharedExtensions), nameof(SharedExtensions.SubstringAfterProviderNamespace), new[]{Untyped}, CallAsExtension: true));
    }
}
