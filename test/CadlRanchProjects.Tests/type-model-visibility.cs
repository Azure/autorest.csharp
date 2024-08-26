// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using _Type.Model.Visibility;
using _Type.Model.Visibility.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
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
            var createProp = new List<string>
            {
                "foo", "bar"
            };
            var updateProp = new List<int> { 1, 2 };
            var response = await new VisibilityClient(host, null).HeadModelAsync(new HeadVisibilityModel(123, createProp, updateProp, true));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task Model_GetModelWithQueryTest() => Test(async (host) =>
        {
            var response = await new VisibilityClient(host, null).GetModelWithQueryAsync(123);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.ReadProp);
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
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Model_PatchModelTest() => Test(async (host) =>
        {
            var value = new
            {
                updateProp = new[] { 1, 2 }
            };
            var response = await new VisibilityClient(host, null).PatchModelAsync(RequestContent.Create(value));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Model_PostModelTest() => Test(async (host) =>
        {
            var createProp = new List<string>
            {
                "foo", "bar"
            };
            var response = await new VisibilityClient(host, null).PostModelAsync(new CreateModel(createProp));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Model_DeleteModelTest() => Test(async (host) =>
        {
            var response = await new VisibilityClient(host, null).DeleteModelAsync(new DeleteModel(true));
            Assert.AreEqual(204, response.Status);
        });

        public static PropertyInfo HasProperty(Type type, string name, BindingFlags bindingFlags)
        {
            var parameterInfo = type.GetProperties(bindingFlags).FirstOrDefault(p => p.Name == name);
            Assert.NotNull(parameterInfo, $"Property '{name}' is not found");
            return parameterInfo;
        }

        [Test]
        public void ReadOnlyPropertiesAreReadOnly()
        {
            var property = HasProperty(typeof(VisibilityModel), "ReadProp", BindingFlags.Public | BindingFlags.Instance);
            var listProperty = HasProperty(typeof(ReadOnlyModel), "OptionalNullableIntList", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(property.SetMethod);
            Assert.Null(listProperty.SetMethod);
            Assert.AreEqual(typeof(IReadOnlyList<int>), listProperty.PropertyType);
        }
    }
}
