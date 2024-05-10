// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using AutoRest.TestServer.Tests.Infrastructure;
using _Type.Model.Flatten.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace _Type.Model.Flatten.Tests
{
    public class FlattenTests : CadlRanchTestBase
    {

        [Test]
        public void VerifyFlattenModel()
        {
            VerifyModelProperties(typeof(FlattenModel), new string[] { "Name", "Description", "Age" });
        }

        [Test]
        public Task PutFlattenModel() => Test(async (host) =>
        {
            FlattenModel response = await new FlattenClient(host, null).PutFlattenModelAsync(new FlattenModel("foo", "bar", 10));
            Assert.AreEqual("test", response.Name);
            Assert.AreEqual("test", response.Description);
            Assert.AreEqual(1, response.Age);
        });

        [Test]
        public void VerifyNestedFlattenModel()
        {
            VerifyModelProperties(typeof(NestedFlattenModel), new string[] { "Name", "Summary", "Description", "Age" });
        }

        [Test]
        public Task PutNestedFlattenModel() => Test(async (host) =>
        {
            NestedFlattenModel response = await new FlattenClient(host, null).PutNestedFlattenModelAsync(new NestedFlattenModel("foo", "bar", "test", 10));
            Assert.AreEqual("test", response.Name);
            Assert.AreEqual("test", response.Summary);
            Assert.AreEqual("foo", response.Description);
            Assert.AreEqual(1, response.Age);
        });

        private void VerifyModelProperties(Type modelType, string[] expectedProperties)
        {
            var propertyNames = new HashSet<string>(modelType.GetProperties().Where(p => p.GetAccessors().Any(a => a.IsPublic)).Select(p => p.Name));
            CollectionAssert.AreEquivalent(new HashSet<string>(expectedProperties), propertyNames);
        }
    }
}
