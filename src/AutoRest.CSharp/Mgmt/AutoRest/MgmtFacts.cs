// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal static class MgmtFacts
    {
        public static List<ExtensibleResourceDetail> KnownExtensibleResources { get; }

        public static List<ExtensibleResourceDetail> StandaloneExtensibleResources { get; }
        public static IEnumerable<RequestPath> KnownParentResourcePaths { get; }

        static MgmtFacts()
        {
            KnownExtensibleResources = new()
            {
                new(typeof(ManagementGroupResource), RequestPath.ManagementGroup),
                new(typeof(ResourceGroupResource), RequestPath.ResourceGroup),
                new(typeof(SubscriptionResource), RequestPath.Subscription),
                new(typeof(TenantResource), RequestPath.Tenant),
            };
            // the known parent resource paths will exclude tenant because tenant is so general that every resource path could take the tenant as a parent (usually not direct parent though)
            KnownParentResourcePaths = KnownExtensibleResources.Select(info => info.RequestPath).Where(path => !path.Equals(RequestPath.Tenant));
            // the list of the extensible resources that are in an extension class. Those are not included will be generated as instance methods
            StandaloneExtensibleResources = Configuration.MgmtConfiguration.IsArmCore ?
                new()
                {
                    new(typeof(TenantResource), RequestPath.Tenant),
                    new(typeof(ManagementGroupResource), RequestPath.ManagementGroup),
                } :
                new()
                {
                    new(typeof(TenantResource), RequestPath.Tenant),
                    new(typeof(SubscriptionResource), RequestPath.Subscription),
                    new(typeof(ResourceGroupResource), RequestPath.ResourceGroup),
                    new(typeof(ManagementGroupResource), RequestPath.ManagementGroup),
                };
        }

        public record ExtensibleResourceDetail(Type Type, RequestPath RequestPath);
    }
}
