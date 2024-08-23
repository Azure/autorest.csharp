// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using _Type._Array;
using _Type._Array.Models;

namespace CadlRanchProjects.Tests
{
    public class TypeArrayTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Array_Int32Value_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt32ValueClient().GetInt32ValueAsync();
            CollectionAssert.AreEqual(new[] { 1, 2 }, response.Value);
        });

        [Test]
        public Task Type_Array_Int32Value_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt32ValueClient().PutAsync(new List<int> { 1, 2 });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_Int64Value_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt64ValueClient().GetInt64ValueAsync();
            CollectionAssert.AreEqual(new[] { 9007199254740991, -9007199254740991 }, response.Value);
        });

        [Test]
        public Task Type_Array_Int64Value_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt64ValueClient().PutAsync(new List<long> { 9007199254740991, -9007199254740991 });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_BooleanValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetBooleanValueClient().GetBooleanValueAsync();
            CollectionAssert.AreEqual(new[] { true, false }, response.Value);
        });

        [Test]
        public Task Type_Array_BooleanValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetBooleanValueClient().PutAsync(new List<bool> { true, false });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_StringValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetStringValueClient().GetStringValueAsync();
            CollectionAssert.AreEqual(new[] { "hello", "" }, response.Value);
        });

        [Test]
        public Task Type_Array_StringValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetStringValueClient().PutAsync(new List<string> { "hello", "" });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_Float32Value_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetFloat32ValueClient().GetFloat32ValueAsync();
            CollectionAssert.AreEqual(new[] { 43.125f }, response.Value);
        });

        [Test]
        public Task Type_Array_Float32Value_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetFloat32ValueClient().PutAsync(new List<float> { 43.125f });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_DatetimeValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDatetimeValueClient().GetDatetimeValueAsync();
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value[0]);
        });

        [Test]
        public Task Type_Array_DatetimeValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDatetimeValueClient().PutAsync(new List<DateTimeOffset> { DateTimeOffset.Parse("2022-08-26T18:38:00Z") });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_DurationValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDurationValueClient().GetDurationValueAsync();
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value[0]);
        });

        [Test]
        public Task Type_Array_DurationValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDurationValueClient().PutAsync(new List<TimeSpan> { XmlConvert.ToTimeSpan("P123DT22H14M12.011S") });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_UnknownValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetUnknownValueClient().GetUnknownValueAsync();
            var expected = new List<object?> { 1, "hello", null };
            var actual = response.Value.Select(item => item?.ToObjectFromJson()).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        });

        [Test]
        public Task Type_Array_UnknownValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetUnknownValueClient().PutAsync(new List<BinaryData> { new BinaryData(1), new BinaryData("\"hello\""), null });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_ModelValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetModelValueClient().GetModelValueAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual("hello", response.Value[0].Property);
            Assert.AreEqual("world", response.Value[1].Property);
        });

        [Test]
        public Task Type_Array_ModelValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetModelValueClient().PutAsync(new List<InnerModel> { new InnerModel("hello"), new InnerModel("world") });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_NullableFloatValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableFloatValueClient().GetNullableFloatValueAsync();
            CollectionAssert.AreEqual(new float?[] { 1.25f, null, 3.0f }, response.Value);
        });

        [Test]
        public Task Type_Array_NullableFloatValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableFloatValueClient().PutAsync(new List<float?> { 1.25f, null, 3.0f });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_NullableInt32Value_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableInt32ValueClient().GetNullableInt32ValueAsync();
            CollectionAssert.AreEqual(new Int32?[] { 1, null, 3 }, response.Value);
        });

        [Test]
        public Task Type_Array_NullableInt32Value_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableInt32ValueClient().PutAsync(new List<Int32?> { 1, null, 3 });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_NullableBooleanValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableBooleanValueClient().GetNullableBooleanValueAsync();
            CollectionAssert.AreEqual(new Boolean?[] { true, null, false }, response.Value);
        });

        [Test]
        public Task Type_Array_NullableBooleanValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableBooleanValueClient().PutAsync(new Boolean?[] { true, null, false });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_NullableStringValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableStringValueClient().GetNullableStringValueAsync();
            CollectionAssert.AreEqual(new String?[] { "hello", null, "world" }, response.Value);
        });

        [Test]
        public Task Type_Array_NullableStringValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableStringValueClient().PutAsync(new String?[] { "hello", null, "world" });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Array_NullableModelValue_get() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableModelValueClient().GetNullableModelValueAsync();
            Assert.AreEqual(3, response.Value.Count);
            Assert.AreEqual("hello", response.Value[0].Property);
            Assert.IsNull(response.Value[1]);
            Assert.AreEqual("world", response.Value[2].Property);
        });

        [Test]
        public Task Type_Array_NullableModelValue_put() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableModelValueClient().PutAsync(new List<InnerModel> { new InnerModel("hello"), null, new InnerModel("world") });
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public void OptionalNullableListsAreNotNullByDefault()
        {
            var inputModel = new InnerModel("nonnull");

            Assert.NotNull(inputModel.Property);
        }
    }
}
