// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceIdentifierChooser
    {
        internal static Type GetResourceIdentifierType(this OperationGroup operationGroup, BuildContext context)
        {
            var config = context.Configuration.MgmtConfiguration;
            //Go up until we get to the operation group level that is directly under a resource group, subscription or tenant.
            while (operationGroup.ParentOperationGroup(context) != null)
            {
                operationGroup = operationGroup.ParentOperationGroup(context)!;
            }
            if (operationGroup.ParentResourceType(config) == ResourceTypeBuilder.ResourceGroups)
                return typeof(ResourceGroupResourceIdentifier);
            if (operationGroup.ParentResourceType(config) == ResourceTypeBuilder.Subscriptions)
                return typeof(SubscriptionResourceIdentifier);
            if (operationGroup.ParentResourceType(config) == ResourceTypeBuilder.Tenant)
                return typeof(TenantResourceIdentifier);

            return typeof(TenantResourceIdentifier);
        }
    }
}
