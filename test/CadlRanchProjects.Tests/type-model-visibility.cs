// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using _Type.Model.Visibility;
using _Type.Model.Visibility.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class TypeModelVisibilityTests : CadlRanchTestBase
    {
        [Test]
        public Task Models_ReadOnlyRoundTrip() => Test(async (host) =>
        {
            var response = await new VisibilityClient(host, null).PutReadOnlyModelAsync(new ReadOnlyModel()
            {
            });
            Assert.AreEqual(3, response.Value.RequiredNullableIntList.Count);
            Assert.AreEqual(1, response.Value.RequiredNullableIntList[0]);
            Assert.AreEqual(2, response.Value.RequiredNullableIntList[1]);
            Assert.AreEqual(3, response.Value.RequiredNullableIntList[2]);
            Assert.AreEqual("value1", response.Value.RequiredStringRecord["k1"]);
            Assert.AreEqual("value2", response.Value.RequiredStringRecord["k2"]);
        });
    }
}
