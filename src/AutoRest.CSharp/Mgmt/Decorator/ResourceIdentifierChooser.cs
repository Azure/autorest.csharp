// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceIdentifierChooser
    {
        internal static Type GetResourceIdentifierType(this OperationGroup operationGroup, MgmtObjectType mgmtObjectType, BuildContext context)
        {
            var config = context.Configuration.MgmtConfiguration;
            //Go up until we get to the operation group level that is directly under a resource group, subscription or tenant.
            while (operationGroup.ParentOperationGroup(context) != null)
            {
                operationGroup = operationGroup.ParentOperationGroup(context)!;
            }
            if (operationGroup.ParentResourceType(config) == ResourceTypeBuilder.Subscriptions)
                return typeof(SubscriptionResourceIdentifier);
            else if (operationGroup.IsTenantResource(config))
                return typeof(TenantResourceIdentifier);
            else
                return typeof(ResourceGroupResourceIdentifier);
        }
    }
}
