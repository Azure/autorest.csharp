// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OperationGroupMappings;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class OperationGroupMappingsTests : TestProjectTests
    {
        public OperationGroupMappingsTests() : base("OperationGroupMappings") { }

        [Test]
        public void NewResourceTypesExist()
        {
            var type = typeof(AvailabilitySet);
            Assert.NotNull(type);
            type = typeof(AvailabilitySetData);
            Assert.NotNull(type);
            type = typeof(AvailabilitySetOperations);
            Assert.NotNull(type);
            type = typeof(AvailabilitySetContainer);
            Assert.NotNull(type);
        }

        [Test]
        public void OldResourceTypesDoNotExist()
        {
            Assert.Null(GetType("AvailabilitySets"));
            Assert.Null(GetType("AvailabilitySetsData"));
            Assert.Null(GetType("AvailabilitySetsOperations"));
            Assert.Null(GetType("AvailabilitySetsContainer"));
        }

        [Test]
        public void ValidateNonResource()
        {
            Assert.Null(GetType("UsageData"));
            Assert.Null(GetType("UsageOperations"));
            Assert.Null(GetType("UsageContainer"));

            Assert.NotNull(GetType("Usage"));
            Assert.NotNull(GetType("UsageRestOperations"));
        }

        [Test]
        public void ValidateUsageCtors()
        {
            Type usage = typeof(Usage);
            Assert.AreEqual(2, usage.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Length);
            foreach (var ctor in usage.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                var parameters = ctor.GetParameters();
                if (parameters.Length == 3)
                {
                    Assert.AreEqual("currentValue", parameters[0].Name);
                    Assert.AreEqual(typeof(int), parameters[0].ParameterType);
                    Assert.AreEqual("limit", parameters[1].Name);
                    Assert.AreEqual(typeof(long), parameters[1].ParameterType);
                    Assert.AreEqual("name", parameters[2].Name);
                    Assert.AreEqual(typeof(UsageName), parameters[2].ParameterType);
                }
                else
                {
                    Assert.AreEqual("unit", parameters[0].Name);
                    Assert.AreEqual(typeof(string), parameters[0].ParameterType);
                    Assert.AreEqual("currentValue", parameters[1].Name);
                    Assert.AreEqual(typeof(int), parameters[1].ParameterType);
                    Assert.AreEqual("limit", parameters[2].Name);
                    Assert.AreEqual(typeof(long), parameters[2].ParameterType);
                    Assert.AreEqual("name", parameters[3].Name);
                    Assert.AreEqual(typeof(UsageName), parameters[3].ParameterType);
                }
            }
        }
    }
}
