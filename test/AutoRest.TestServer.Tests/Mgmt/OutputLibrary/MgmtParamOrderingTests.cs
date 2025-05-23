// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using MgmtParamOrdering;
using NUnit.Framework;
using static AutoRest.TestServer.Tests.Infrastructure.TestServerTestBase;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtParamOrderingTests : OutputLibraryTestBase
    {
        public MgmtParamOrderingTests() : base("MgmtParamOrdering") { }

        [TestCase("VirtualMachineExtensionImageResource", "SubscriptionResourceExtensions")]
        [TestCase("AvailabilitySetResource", "ResourceGroupResourceExtensions")]
        [TestCase("DedicatedHostResource", "DedicatedHostGroupResource")]
        public void TestParent(string resourceName, string parentName)
        {
            var resource = MgmtContext.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.IsNotNull(resource);
            var parents = resource.GetParents();
            Assert.IsTrue(parents.Any(r => r.Type.Name == parentName));
        }

        [TestCase("DedicatedHosts", "CreateOrUpdate", new[] { "subscriptionId", "resourceGroupName", "hostGroupName", "hostName" })]
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
            var method = MgmtContext.InputNamespace.AllClients.Single(p => p.Key.Equals(operationGroupName))
                .Operations.Single(o => o.CSharpName().Equals(methodName));

            Assert.IsTrue(parameterList.SequenceEqual(method.Parameters.Where(p => p.Location == CSharp.Common.Input.RequestLocation.Path).Select(p => p.CSharpName())));
        }

        [TestCase(typeof(VirtualMachineScaleSetCollection), "CreateOrUpdate", true, new[] { "vmScaleSetName", "data", "quick" }, new[] { true, true, false })]
        [TestCase(typeof(VirtualMachineScaleSetCollection), "Get", false, new[]{ "vmScaleSetName", "expand"}, new[] { true, false })]
        [TestCase(typeof(VirtualMachineScaleSetResource), "Update", true, new[]{ "patch"}, new[] { true })]
        [TestCase(typeof(VirtualMachineScaleSetResource), "Delete", true, new[]{ "forceDeletion"}, new[] { true })]
        [TestCase(typeof(VirtualMachineScaleSetResource), "Get", false, new[]{ "expand"}, new[] { false })]
        [TestCase(typeof(VirtualMachineScaleSetResource), "Deallocate", true, new[]{ "vmInstanceIds", "expand" }, new[] { false, false })]
        [TestCase(typeof(VirtualMachineScaleSetResource), "DeleteInstances", true, new[]{ "vmInstanceIds", "forceDeletion"}, new[] { true, false })]
        [TestCase(typeof(VirtualMachineScaleSetResource), "GetInstanceView", false, new[]{ "filter", "expand" }, new[] { true, false })]
        public void ValidateOperationMethodParameterList(Type type, string methodName, bool isLro, string[] parameterNames, bool[] isRequiredParameters)
        {
            var method = type.GetMethod(methodName);
            Assert.IsNotNull(method, $"Method {methodName} not found in type {type.Name}");
            var parameters = method.GetParameters();
            Assert.That(parameters, Has.Length.EqualTo(parameterNames.Length + (isLro ? 2 : 1))); // need to exclude "waitUntil" and "cancellationToken"

            var customParameters = parameters.SkipLast(1);// skip "cancellationToken"
            if (isLro)
            {
                customParameters = customParameters.Skip(1);// skip "waitUntil"
            }
            Assert.AreEqual(parameterNames, customParameters.Select(p => p.Name).ToArray());
            Assert.AreEqual(isRequiredParameters, customParameters.Select(p => !p.HasDefaultValue).ToArray());
        }

        [TestCase("AvailabilitySetsRestOperations", "Update", false, new[] { "subscriptionId", "resourceGroupName", "availabilitySetName", "patch" }, new[] { true, true, true, true })]
        public void ValidateOperationMethodParameterList(string typeName, string methodName, bool isLro, string[] parameterNames, bool[] isRequiredParameters)
            => ValidateOperationMethodParameterList(FindType(Assembly, typeName), methodName, isLro, parameterNames, isRequiredParameters);
    }
}
