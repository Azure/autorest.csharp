using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm._Type.Model.Visibility;
using Scm._Type.Model.Visibility.Models;
using System.ClientModel;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class type_model_visibility : CadlRanchNonAzureTestBase
    {
        public class TypeModelVisibilityTests : CadlRanchTestBase
        {
            [Test]
            public Task Models_ReadOnlyRoundTrip() => Test(async (host) =>
            {
                var response = await new VisibilityClient(host, null).PutReadOnlyModelAsync(new ReadOnlyModel());
                Assert.AreEqual(3, response.Value.OptionalNullableIntList.Count);
                Assert.AreEqual(1, response.Value.OptionalNullableIntList[0]);
                Assert.AreEqual(2, response.Value.OptionalNullableIntList[1]);
                Assert.AreEqual(3, response.Value.OptionalNullableIntList[2]);
                Assert.AreEqual("value1", response.Value.OptionalStringRecord["k1"]);
                Assert.AreEqual("value2", response.Value.OptionalStringRecord["k2"]);
            });

            [Test]
            public Task Model_HeadModelTest() => Test(async (host) =>
            {
                var response = await new VisibilityClient(host, null).HeadModelAsync(new QueryModel(123));
                Assert.AreEqual(200, response.GetRawResponse().Status);
            });

            [Test]
            public Task Model_GetModelTest() => Test(async (host) =>
            {
                var response = await new VisibilityClient(host, null).GetModelAsync(new QueryModel(123));
                Assert.AreEqual(200, response.GetRawResponse().Status);
                Assert.AreEqual("abc", response.Value.ReadProp);
            });

            [Test]
            public Task Model_PutModelTest() => Test(async (host) =>
            {
                var createProp = new List<string>
            {
                "foo", "bar"
            };
                var updateProp = new List<int> { 1, 2 };
                var response = await new VisibilityClient(host, null).PutModelAsync(new VisibilityModel(createProp, updateProp));
                Assert.AreEqual(204, response.GetRawResponse().Status);
            });

            [Test]
            public Task Model_PatchModelTest() => Test(async (host) =>
            {
                var value = new
                {
                    updateProp = new[] { 1, 2 }
                };
                var response = await new VisibilityClient(host, null).PatchModelAsync(BinaryContent.Create(BinaryData.FromObjectAsJson(value)));
                Assert.AreEqual(204, response.GetRawResponse().Status);
            });

            [Test]
            public Task Model_PostModelTest() => Test(async (host) =>
            {
                var createProp = new List<string>
            {
                "foo", "bar"
            };
                var response = await new VisibilityClient(host, null).PostModelAsync(new CreateModel(createProp));
                Assert.AreEqual(204, response.GetRawResponse().Status);
            });

            [Test]
            public Task Model_DeleteModelTest() => Test(async (host) =>
            {
                var response = await new VisibilityClient(host, null).DeleteModelAsync(new DeleteModel(true));
                Assert.AreEqual(204, response.GetRawResponse().Status);
            });
        }
    }
}
