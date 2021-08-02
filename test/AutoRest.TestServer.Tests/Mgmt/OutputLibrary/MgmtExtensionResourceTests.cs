// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtExtensionResourceTests : OutputLibraryTestBase
    {
        public MgmtExtensionResourceTests() : base("MgmtExtensionResource") { }

        [Test]
        public void TestExtensionResource()
        {
            var result = Generate("MgmtExtensionResource").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                if (operations.Key.Equals("PolicyDefinitions"))
                {
                    Assert.IsTrue(operations.IsExtensionResource(context.Configuration.MgmtConfiguration));
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Tenant));
                    Assert.IsTrue(operations.IsAncestorResourceTypeTenant(context));
                    Assert.IsFalse(operations.IsAncestorTenant(context));
                    Assert.IsFalse(operations.IsTenantResource(context.Configuration.MgmtConfiguration));
                    foreach (var operation in operations.Operations)
                    {
                        if (operation.Language.Default.Name.Equals("CreateOrUpdate") || operation.Language.Default.Name.Equals("List"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Subscriptions));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Subscriptions));
                        }
                        else if (operation.Language.Default.Name.Equals("GetBuiltIn") || operation.Language.Default.Name.Equals("ListBuiltIn"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.Tenant));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.Tenant));
                        }
                        else if (operation.Language.Default.Name.Equals("GetAtManagementGroup") || operation.Language.Default.Name.Equals("DeleteAtManagementGroup"))
                        {
                            Assert.IsTrue(operation.ParentResourceType().Equals(ResourceTypeBuilder.ManagementGroups));
                            Assert.IsTrue(operation.AncestorResourceType().Equals(ResourceTypeBuilder.ManagementGroups));
                        }
                    }
                }
            }
        }
    }
}
