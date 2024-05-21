// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm._Type.Model.Inheritance.Recursive;
using Scm._Type.Model.Inheritance.Recursive.Models;
using Azure.Core;
using System.Linq;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class RecursiveTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Type_Model_Inheritance_Recursive_get() => Test(async (host) =>
        {
            var response = await new RecursiveClient(host, null).GetRecursiveAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(0, response.Value.Level);
            Assert.AreEqual(2, response.Value.Extension.Count);
            Assert.AreEqual(1, response.Value.Extension[0].Level);
            Assert.AreEqual(1, response.Value.Extension[0].Extension.Count);
            Assert.AreEqual(2, response.Value.Extension[0].Extension[0].Level);
            Assert.AreEqual(1, response.Value.Extension[1].Level);
            Assert.AreEqual(0, response.Value.Extension[0].Extension[0].Extension.Count);
            Assert.IsFalse(Optional.IsCollectionDefined(response.Value.Extension[1].Extension));
        });
        [Test]
        public Task Type_Model_Inheritance_Recursive_put() => Test(async (host) =>
        {
            var data = new Extension(0);
            var extensions = data.Extension;
            Extension item1 = new Extension(1);
            item1.Extension.Add(new Extension(2));
            Extension item2 = new Extension(1);
            extensions.Add(item1);
            extensions.Add(item2);
            var response = await new RecursiveClient(host, null).PutAsync(data);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
