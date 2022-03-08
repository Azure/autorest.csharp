// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using MgmtParamOrdering;
using NUnit.Framework;

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
            var resource = MgmtContext.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.IsNotNull(resource);
            var parents = resource.Parent();
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
            var method = MgmtContext.CodeModel.OperationGroups.Single(p => p.Key.Equals(operationGroupName))
                .Operations.Single(o => o.CSharpName().Equals(methodName));

            Assert.IsTrue(parameterList.SequenceEqual(method.Parameters.Where(p => p.In == HttpParameterIn.Path).Select(p => p.CSharpName())));
        }

        [TestCase(typeof(VirtualMachineScaleSetCollection), "CreateOrUpdate", true, new[] { "vmScaleSetName", "parameters", "quick" }, new[] { true, true, false })]
        [TestCase(typeof(VirtualMachineScaleSetCollection), "Get", false, new[]{ "vmScaleSetName", "expand"}, new[] { true, false })]
        [TestCase(typeof(VirtualMachineScaleSet), "Update", true, new[]{ "options"}, new[] { true })]
        [TestCase(typeof(VirtualMachineScaleSet), "Delete", true, new[]{ "forceDeletion"}, new[] { true })]
        [TestCase(typeof(VirtualMachineScaleSet), "Get", false, new[]{ "expand"}, new[] { false })]
        [TestCase(typeof(VirtualMachineScaleSet), "Deallocate", true, new[]{ "vmInstanceIDs", "expand" }, new[] { false, false })]
        [TestCase(typeof(VirtualMachineScaleSet), "DeleteInstances", true, new[]{ "vmInstanceIDs", "forceDeletion"}, new[] { true, false })]
        [TestCase(typeof(VirtualMachineScaleSet), "GetInstanceView", false, new[]{ "filter", "expand" }, new[] { true, false })]
        public void ValidateOperationMethodParameterList(Type type, string methodName, bool isLro, string[] parameterNames, bool[] isRequiredParameters)
        {
            var parameters = type.GetMethod(methodName).GetParameters();
            Assert.That(parameters, Has.Length.EqualTo(parameterNames.Length + (isLro ? 2 : 1))); // need to exclude "waitForCompletion" and "cancellationToken"

            var customParameters = parameters.SkipLast(1);// skip "cancellationToken"
            if (isLro)
            {
                customParameters = customParameters.Skip(1);// skip "waitForCompletion"
            }
            Assert.AreEqual(parameterNames, customParameters.Select(p => p.Name).ToArray());
            Assert.AreEqual(isRequiredParameters, customParameters.Select(p => !p.HasDefaultValue).ToArray());
        }
    }
}
