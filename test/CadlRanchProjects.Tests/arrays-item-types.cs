// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Arrays.ItemTypes;
using Arrays.ItemTypes.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class ArraysItemTypes : CadlRanchTestBase
    {
        [Test]
        public Task Arrays_ItemTypes_Int32Value_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetInt32ValueClient().GetInt32ValueValueAsync();
            Assert.AreEqual(1, response.Value.First());
            Assert.AreEqual(2, response.Value.Last());
        });

        [Test]
        public Task Arrays_ItemTypes_Int32Value_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetInt32ValueClient().PutAsync(RequestContent.Create(new[] { 1, 2 }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_Int64Value_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetInt64ValueClient().GetInt64ValueValueAsync();
            Assert.AreEqual(9007199254740991, response.Value.First());
            Assert.AreEqual(-9007199254740991, response.Value.Last());
        });

        [Test]
        public Task Arrays_ItemTypes_Int64Value_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetInt64ValueClient().PutAsync(RequestContent.Create(new[] { 9007199254740991, -9007199254740991 }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_BooleanValue_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetBooleanValueClient().GetBooleanValueValueAsync();
            Assert.AreEqual(true, response.Value.First());
            Assert.AreEqual(false, response.Value.Last());
        });

        [Test]
        public Task Arrays_ItemTypes_BooleanValue_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetBooleanValueClient().PutAsync(RequestContent.Create(new[] { true, false }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_StringValue_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetStringValueClient().GetStringValueValueAsync();
            Assert.AreEqual("hello", response.Value.First());
            Assert.AreEqual("", response.Value.Last());
        });

        [Test]
        public Task Arrays_ItemTypes_StringValue_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetStringValueClient().PutAsync(RequestContent.Create(new[] { "hello", "" }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_Float32Value_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetFloat32ValueClient().GetFloat32ValueValueAsync();
            Assert.AreEqual(42.42f, response.Value.First());
        });

        [Test]
        public Task Arrays_ItemTypes_Float32Value_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetFloat32ValueClient().PutAsync(RequestContent.Create(new[] { 42.42f }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_DatetimeValue_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetDatetimeValueClient().GetDatetimeValueValueAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.First());
        });

        [Test]
        public Task Arrays_ItemTypes_DatetimeValue_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetDatetimeValueClient().PutAsync(RequestContent.Create(new[] { DateTimeOffset.Parse("2022-08-26T18:38:00Z") }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_DurationValue_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetDurationValueClient().GetDurationValueValueAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.First());
        });

        [Test]
        public Task Arrays_ItemTypes_DurationValue_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetDurationValueClient().PutAsync(RequestContent.Create(new[] { XmlConvert.ToString( XmlConvert.ToTimeSpan("P123DT22H14M12.011S") )}));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_UnknownValue_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetUnknownValueClient().GetUnknownValueValueAsync();
            CollectionAssert.AreEqual(new List<object>() { 1, "hello", null }, response.Value);
        });

        [Test]
        public Task Arrays_ItemTypes_UnknownValue_put() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetUnknownValueClient().PutAsync(RequestContent.Create(new List<object>() { 1, "hello", null }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Arrays_ItemTypes_ModelValue_get() => Test(async (host) =>
        {
            var response = await new ItemTypesClient(host, null).GetModelValueClient().GetModelValueValueAsync();
            Assert.AreEqual("hello", response.Value.First().Property);
            Assert.AreEqual("world", response.Value.Last().Property);
        });

        [Test]
        public Task Arrays_ItemTypes_ModelValue_put() => Test(async (host) =>
        {
            var value1 = new
            {
                property = "hello"
            };
            var value2 = new
            {
                property = "world"
            };
            var response = await new ItemTypesClient(host, null).GetModelValueClient().PutAsync(RequestContent.Create(new[] { value1, value2 }));
            Assert.AreEqual(204, response.Status);
        });
    }
}
