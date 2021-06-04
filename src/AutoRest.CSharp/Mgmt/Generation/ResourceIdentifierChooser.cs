// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal static class ResourceIdentifierChooser
    {
        internal static Type GetResourceIdentifierType(this OperationGroup operation, MgmtObjectType mgmtObjectType, MgmtConfiguration config)
        {
            if (operation.ParentResourceType(config) == ResourceTypeBuilder.Subscriptions)
                return typeof(SubscriptionResourceIdentifier);
            else if (operation.IsTenantResource(config))
                return typeof(TenantResourceIdentifier);
            else
                return typeof(ResourceGroupResourceIdentifier);
        }

        private static ObjectType? GetObjectTypeBase(ObjectType obj)
        {
            return obj.Inherits != null ? obj.Inherits.Implementation as ObjectType : null;
        }
    }
}
