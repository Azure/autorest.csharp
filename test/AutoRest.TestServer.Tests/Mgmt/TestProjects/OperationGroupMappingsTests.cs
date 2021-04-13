// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            var type = typeof(AvailabilitySet);
            var assembly = type.Assembly;
            Assert.Null(assembly.GetType("AvailabilitySets"));
            Assert.Null(assembly.GetType("AvailabilitySetsData"));
            Assert.Null(assembly.GetType("AvailabilitySetsOperations"));
            Assert.Null(assembly.GetType("AvailabilitySetsContainer"));
        }
    }
}
