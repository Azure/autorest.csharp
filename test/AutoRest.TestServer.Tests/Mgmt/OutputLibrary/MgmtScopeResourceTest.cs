// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;
using MgmtScopeResource;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtScopeResourceTests : OutputLibraryTestBase
    {
        public MgmtScopeResourceTests() : base("MgmtScopeResource") { }

        [Test]
        public void TestScopeResource()
        {
            var result = Generate("MgmtScopeResource").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                if (operations.Key.Equals("PolicyAssignments"))
                {
                    Assert.IsTrue(operations.IsScopeResource(context.Configuration.MgmtConfiguration));
                    Assert.IsTrue(operations.IsAncestorScope());
                    Assert.IsTrue(operations.IsExtensionResource(context.Configuration.MgmtConfiguration));
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Tenant));
                    Assert.IsTrue(operations.IsAncestorResourceTypeTenant(context));
                    Assert.IsFalse(operations.IsAncestorTenant(context));
                    Assert.IsFalse(operations.IsTenantResource(context.Configuration.MgmtConfiguration));
                    foreach (var operation in operations.Operations)
                    {
                        if (operation.Language.Default.Name.Equals("Create") || operation.Language.Default.Name.Equals("Get") || operation.Language.Default.Name.Equals("Delete"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.IsAncestorScope());
                            Assert.IsTrue(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                        else if (operation.Language.Default.Name.Equals("ListForResourceGroup"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.ResourceGroups));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.ResourceGroups));
                            Assert.IsFalse(operation.IsAncestorScope());
                            Assert.IsFalse(operation.IsParentScope());
                        }
                        else if (operation.Language.Default.Name.Equals("ListForResource"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.ResourceGroupResources));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.ResourceGroups));
                        }
                        else if (operation.Language.Default.Name.Equals("ListForManagementGroup"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.ManagementGroups));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.ManagementGroups));
                        }
                        else if (operation.Language.Default.Name.Equals("List"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Subscriptions));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Subscriptions));
                        }
                        else if (operation.Language.Default.Name.Equals("DeleteById") || operation.Language.Default.Name.Equals("CreateById"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsFalse(operation.IsAncestorScope());
                            Assert.IsFalse(operation.IsParentScope());
                        }
                    }
                }
                else if (operations.Key.Equals("Deployments"))
                {
                    Assert.IsTrue(operations.IsScopeResource(context.Configuration.MgmtConfiguration));
                    Assert.IsTrue(operations.IsAncestorScope());
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Tenant));
                    Assert.IsTrue(operations.IsAncestorResourceTypeTenant(context));
                    foreach (var operation in operations.Operations)
                    {
                        if (operation.Language.Default.Name.Equals("CreateOrUpdateAtScope") || operation.Language.Default.Name.Equals("GetAtScope") || operation.Language.Default.Name.Equals("DeleteAtScope"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.IsAncestorScope());
                            Assert.IsTrue(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                        else if (operation.Language.Default.Name.Equals("WhatIfAtTenantScope"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(DeploymentExtended.ResourceType));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsFalse(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                        else if (operation.Language.Default.Name.Equals("WhatIfAtManagementGroupScope"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals("Microsoft.Management/managementGroups/providers/Microsoft.Resources/deployments"));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.ManagementGroups));
                            Assert.IsFalse(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                        else if (operation.Language.Default.Name.Equals("WhatIfAtSubscriptionScope"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(DeploymentExtended.ResourceType));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Subscriptions));
                            Assert.IsFalse(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                        else if (operation.Language.Default.Name.Equals("WhatIf"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(DeploymentExtended.ResourceType));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.ResourceGroups));
                            Assert.IsFalse(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                    }
                }
                else if (operations.Key.Equals("DeploymentOperations"))
                {
                    Assert.IsFalse(operations.IsScopeResource(context.Configuration.MgmtConfiguration));
                    Assert.IsTrue(operations.IsAncestorScope());
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(DeploymentExtended.ResourceType));
                    Assert.IsTrue(operations.IsAncestorResourceTypeTenant(context));
                    foreach (var operation in operations.Operations)
                    {
                        if (operation.Language.Default.Name.Equals("GetAtScope") || operation.Language.Default.Name.Equals("ListAtScope"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(DeploymentExtended.ResourceType));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.IsAncestorScope());
                            Assert.IsFalse(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                    }
                }
                else if (operations.Key.Equals("ResourceLinks"))
                {
                    Assert.IsTrue(operations.IsScopeResource(context.Configuration.MgmtConfiguration));
                    Assert.IsTrue(operations.IsAncestorScope());
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Tenant));
                    Assert.IsTrue(operations.IsAncestorResourceTypeTenant(context));
                    foreach (var operation in operations.Operations)
                    {
                        if (operation.Language.Default.Name.Equals("Delete") || operation.Language.Default.Name.Equals("CreateOrUpdate") || operation.Language.Default.Name.Equals("Get"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsFalse(operation.IsAncestorScope());
                            Assert.IsFalse(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                        else if (operation.Language.Default.Name.Equals("ListAtSourceScope") )
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.IsAncestorScope());
                            Assert.IsTrue(operation.IsParentScope());
                            Assert.IsFalse(operation.IsParentTenant());
                        }
                    }
                }
            }
        }
    }
}
