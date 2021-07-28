// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Input;
using NUnit.Framework;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtParamOrderingTests : OutputLibraryTestBase
    {
        public MgmtParamOrderingTests() : base("MgmtParamOrdering") { }

        [Test]
        public void TestParentComputer()
        {
            var result = Generate("MgmtParamOrdering").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                if (operations.Key.Equals("VirtualMachineExtensionImages"))
                    Assert.AreEqual("subscriptions", operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                else if (operations.Key.Equals("AvailabilitySets"))
                    Assert.AreEqual("resourceGroups", operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                else if (operations.Key.Equals("DedicatedHosts"))
                    Assert.AreEqual("Microsoft.Compute/hostGroups", operations.ParentResourceType(context.Configuration.MgmtConfiguration));
            }
        }

        [TestCase("DedicatedHosts", "CreateOrUpdate", new[] { "subscriptionId", "resourceGroupName", "hostGroupName", "hostName"})]
        [TestCase("DedicatedHosts", "Get", new[] { "subscriptionId", "resourceGroupName", "hostGroupName", "hostName" })]
        [TestCase("DedicatedHosts", "Delete", new[] { "subscriptionId", "resourceGroupName", "hostGroupName", "hostName" })]
        [TestCase("DedicatedHostGroups", "CreateOrUpdate", new[] { "subscriptionId", "resourceGroupName", "hostGroupName" })]
        [TestCase("DedicatedHostGroups", "Get", new[] { "subscriptionId", "resourceGroupName", "hostGroupName" })]
        [TestCase("DedicatedHostGroups", "Delete", new[] { "subscriptionId", "resourceGroupName", "hostGroupName" })]
        [TestCase("AvailabilitySets", "CreateOrUpdate", new[] { "subscriptionId", "resourceGroupName", "availabilitySetName" })]
        [TestCase("AvailabilitySets", "Get", new[] { "subscriptionId", "resourceGroupName", "availabilitySetName" })]
        [TestCase("AvailabilitySets", "Delete", new[] { "subscriptionId", "resourceGroupName", "availabilitySetName" })]
        public void ValidateOperationParameterList(string operationGroupName, string methodName, string[] parameterList)
        {
            var result = Generate("MgmtParamOrdering").Result;
            var model = result.Model;

            var method = model.OperationGroups.Single(p => p.Key.Equals(operationGroupName))
                .Operations.Single(o => o.CSharpName().Equals(methodName));

            Assert.IsTrue(parameterList.SequenceEqual(method.Parameters.Where(p => p.In == ParameterLocation.Path).Select(p => p.CSharpName())));
        }
    }
}
