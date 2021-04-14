// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
