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
            var listProperty = HasProperty(typeof(ReadOnlyModel), "RequiredNullableIntList", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(property.SetMethod);
            Assert.Null(listProperty.SetMethod);
            Assert.AreEqual(typeof(IReadOnlyList<int>), listProperty.PropertyType);
        }
    }
}
