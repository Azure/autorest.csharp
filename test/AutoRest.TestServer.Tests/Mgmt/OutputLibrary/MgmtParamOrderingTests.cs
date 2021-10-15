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

        [TestCase("VirtualMachineExtensionImage", "SubscriptionExtensions")]
        [TestCase("AvailabilitySet", "ResourceGroupExtensions")]
        [TestCase("DedicatedHost", "DedicatedHostGroup")]
        public void TestParent(string resourceName, string parentName)
        {
            (_, var context) = Generate("MgmtParamOrdering").Result;

            var resource = context.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.IsNotNull(resource);
            var parents = resource.Parent(context);
            Assert.IsTrue(parents.Any(r => r.Type.Name == parentName));
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
