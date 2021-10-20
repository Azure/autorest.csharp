﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using body_array_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyArray : TestServerLowLevelTestBase
    {
        [Test]
        public Task GetArrayArrayEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetArrayEmptyAsync(new());

            var data = await ToStringArrayAsync(result.ContentStream);
            CollectionAssert.IsEmpty(data);
        });

        [Test]
        public Task GetArrayArrayItemEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetArrayItemEmptyAsync(new());

            var data = await ToStringArrayAsync(result.ContentStream);
            CollectionAssert.AreEqual(new[] { new object[] { "1", "2", "3" }, new object[] { }, new object[] { "7", "8", "9" } }, data);
        });

        [Test]
        public Task GetArrayArrayItemNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetArrayItemNullAsync(new());

            var data = await ToStringArrayAsync(result.ContentStream);
            CollectionAssert.AreEqual(new[] { new object[] { "1", "2", "3" }, null, new object[] { "7", "8", "9" } }, data);
        });

        [Test]
        public Task GetArrayArrayNull() => Test(async (host) =>
        {
            // Empty response body
            var result = await new ArrayClient(Key, host).GetArrayNullAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await ToStringArrayAsync(result.ContentStream));
        });

        [Test]
        public Task GetArrayArrayValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetArrayValidAsync(new());

            var data = await ToStringArrayAsync(result.ContentStream);
            CollectionAssert.AreEqual(new[] { new object[] { "1", "2", "3" }, new object[] { "4", "5", "6" }, new object[] { "7", "8", "9" } }, data);
        });

        [Test]
        public Task GetArrayBase64Url() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetBase64UrlAsync(new());

            var data = await ToByteArrayAsync(result.ContentStream, "U");
            CollectionAssert.AreEqual(new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52, 117, 114, 108 }, data[0]);
            CollectionAssert.AreEqual(new byte[] { 116, 101, 115, 116, 32, 115, 116, 114, 105, 110, 103 }, data[1]);
            CollectionAssert.AreEqual(new byte[] { 76, 111, 114, 101, 109, 32, 105, 112, 115, 117, 109 }, data[2]);
        });

        [Test]
        public Task GetArrayBooleanValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetBooleanTfftAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(true, (bool)responseBody[0]);
            Assert.AreEqual(false, (bool)responseBody[1]);
            Assert.AreEqual(false, (bool)responseBody[2]);
            Assert.AreEqual(true, (bool)responseBody[3]);
        });

        [Test]
        public Task GetArrayBooleanWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetBooleanInvalidNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(true, (bool)responseBody[0]);
            Assert.AreEqual(null, (string)responseBody[1]);
            Assert.AreEqual(false, (bool)responseBody[2]);
        });

        [Test]
        public Task GetArrayBooleanWithString() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetBooleanInvalidStringAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(true, (bool)responseBody[0]);
            Assert.AreEqual("boolean", (string)responseBody[1]);
            Assert.AreEqual(false, (bool)responseBody[2]);
        });

        [Test]
        public Task GetArrayByteValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetByteValidAsync(new());

            var data = await ToByteArrayAsync(result.ContentStream, "D");
            CollectionAssert.AreEqual(new[] { new[] { 255, 255, 255, 250 }, new[] { 1, 2, 3 }, new[] { 37, 41, 67 } }, data);
        });

        [Test]
        public Task GetArrayByteWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetByteInvalidNullAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<InvalidOperationException>(), async () => await ToByteArrayAsync(result.ContentStream, "D"));
        });

        [Test]
        public Task GetArrayComplexEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetComplexEmptyAsync(new());

            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.Zero(responseBody.Length);
        });

        [Test]
        public Task GetArrayComplexItemEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetComplexItemEmptyAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(3, responseBody.Length);
            Assert.AreEqual(1, (int?)responseBody[0]["integer"]);
            Assert.AreEqual("2", (string)responseBody[0]["string"]);

            Assert.Zero(responseBody[1].Properties.Count());

            Assert.AreEqual(5, (int?)responseBody[2]["integer"]);
            Assert.AreEqual("6", (string)responseBody[2]["string"]);
        });

        [Test]
        public Task GetArrayComplexItemNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetComplexItemNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(3, responseBody.Length);
            Assert.AreEqual(1, (int?)responseBody[0]["integer"]);
            Assert.AreEqual("2", (string)responseBody[0]["string"]);

            Assert.AreEqual(null, (string)responseBody[1]);

            Assert.AreEqual(5, (int?)responseBody[2]["integer"]);
            Assert.AreEqual("6", (string)responseBody[2]["string"]);
        });

        [Test]
        public Task GetArrayComplexNull() => Test(async (host) =>
        {
            // Empty response body
            var result = await new ArrayClient(Key, host).GetComplexNullAsync(new());
            Assert.IsEmpty(result.Content.ToString());
        });

        [Test]
        public Task GetArrayComplexValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetComplexValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(3, responseBody.Length);
            Assert.AreEqual(1, (int?)responseBody[0]["integer"]);
            Assert.AreEqual("2", (string)responseBody[0]["string"]);

            Assert.AreEqual(3, (int?)responseBody[1]["integer"]);
            Assert.AreEqual("4", (string)responseBody[1]["string"]);

            Assert.AreEqual(5, (int?)responseBody[2]["integer"]);
            Assert.AreEqual("6", (string)responseBody[2]["string"]);

        });

        [Test]
        public Task GetArrayDateTimeRfc1123Valid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateTimeRfc1123ValidAsync(new());
            var data = await ToDateTimeArrayAsync(result.ContentStream);

            CollectionAssert.AreEqual(new[]
            {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, data);
        });

        [Test]
        public Task GetArrayDateTimeValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateTimeValidAsync(new());
            var data = await ToDateTimeArrayAsync(result.ContentStream);

            CollectionAssert.AreEqual(new[]
            {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, data);
        });

        [Test]
        public Task GetArrayDateTimeWithInvalidChars() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateTimeInvalidCharsAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ToDateTimeArrayAsync(result.ContentStream));
        });

        [Test]
        public Task GetArrayDateTimeWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateTimeInvalidNullAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ToDateTimeArrayAsync(result.ContentStream));
        });

        [Test]
        public Task GetArrayDateValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateValidAsync(new());
            var data = await ToDateTimeArrayAsync(result.ContentStream);

            CollectionAssert.AreEqual(new[]
            {
                DateTimeOffset.Parse("2000-12-01", styles: DateTimeStyles.AssumeUniversal),
                DateTimeOffset.Parse("1980-01-02", styles: DateTimeStyles.AssumeUniversal),
                DateTimeOffset.Parse("1492-10-12", styles: DateTimeStyles.AssumeUniversal),
            }, data);
        });

        [Test]
        public Task GetArrayDateWithInvalidChars() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateInvalidCharsAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ToDateTimeArrayAsync(result.ContentStream));
        });

        [Test]
        public Task GetArrayDateWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDateInvalidNullAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ToDateTimeArrayAsync(result.ContentStream));
        });

        [Test]
        public Task GetArrayDictionaryEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDictionaryEmptyAsync(new());
            var data = await ToDictionaryAsync(result.ContentStream);

            CollectionAssert.IsEmpty(data);
        });

        [Test]
        public Task GetArrayDictionaryItemEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDictionaryItemEmptyAsync(new());

            var data = await ToDictionaryAsync(result.ContentStream);
            var values = data.ToArray();

            Assert.AreEqual(3, values.Length);

            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } }, values[0]);
            CollectionAssert.AreEqual(new Dictionary<string, string>(), values[1]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }, values[2]);
        });

        [Test]
        public Task GetArrayDictionaryItemNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDictionaryItemNullAsync(new());

            var data = await ToDictionaryAsync(result.ContentStream);
            var values = data.ToArray();

            Assert.AreEqual(3, values.Length);

            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } }, values[0]);
            CollectionAssert.AreEqual(null, values[1]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }, values[2]);
        });

        [Test]
        public Task GetArrayDictionaryNull() => Test(async (host) =>
        {
            // Empty response body
            var result = await new ArrayClient(Key, host).GetDictionaryNullAsync(new());

            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await ToDictionaryAsync(result.ContentStream));
        });

        [Test]
        public Task GetArrayDictionaryValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDictionaryValidAsync(new());

            var data = await ToDictionaryAsync(result.ContentStream);
            var values = data.ToArray();

            Assert.AreEqual(3, values.Length);

            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } }, values[0]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "4", "four" }, { "5", "five" }, { "6", "six" }, }, values[1]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }, values[2]);
        });

        [Test]
        public Task GetArrayDoubleValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDoubleValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(0, (double)responseBody[0]);
            Assert.AreEqual(-0.01, (double)responseBody[1]);
            Assert.AreEqual(-1.2e20, (double)responseBody[2]);
        });

        [Test]
        public Task GetArrayDoubleWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDoubleInvalidNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(0, (double)responseBody[0]);
            Assert.AreEqual(null, (string)responseBody[1]);
            Assert.AreEqual(-1.2e20, (double)responseBody[2]);
        });

        [Test]
        public Task GetArrayDoubleWithString() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDoubleInvalidStringAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (double)responseBody[0]);
            Assert.AreEqual("number", (string)responseBody[1]);
            Assert.AreEqual(0, (double)responseBody[2]);
        });

        [Test]
        public Task GetArrayDurationValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetDurationValidAsync(new());
            using var document = await JsonDocument.ParseAsync(result.ContentStream).ConfigureAwait(false);
            List<TimeSpan> array = new List<TimeSpan>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetTimeSpan("P"));
            }

            CollectionAssert.AreEqual(new[]
            {
                XmlConvert.ToTimeSpan("P123DT22H14M12.011S"),
                XmlConvert.ToTimeSpan("P5DT1H0M0S"),
            }, array);
        });

        [Test]
        public Task GetArrayEmpty() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetEmptyAsync(new());
            Assert.AreEqual("[]", result.Content.ToString());
        });

        [Test]
        public Task GetArrayEnumValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetEnumValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("foo1", (string)responseBody[0]);
            Assert.AreEqual("foo2", (string)responseBody[1]);
            Assert.AreEqual("foo3", (string)responseBody[2]);
        });

        [Test]
        public Task GetArrayFloatValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetFloatValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(0, (float)responseBody[0]);
            Assert.AreEqual(-0.01f, (float)responseBody[1]);
            Assert.AreEqual(-1.2e20f, (float)responseBody[2]);
        });

        [Test]
        public Task GetArrayFloatWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetFloatInvalidNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(0, (float)responseBody[0]);
            Assert.AreEqual(null, (string)responseBody[1]);
            Assert.AreEqual(-1.2e20f, (float)responseBody[2]);
        });

        [Test]
        public Task GetArrayFloatWithString() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetFloatInvalidStringAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (float)responseBody[0]);
            Assert.AreEqual("number", (string)responseBody[1]);
            Assert.AreEqual(0, (float)responseBody[2]);
        });

        [Test]
        public Task GetArrayIntegerValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetIntegerValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (int)responseBody[0]);
            Assert.AreEqual(-1, (int)responseBody[1]);
            Assert.AreEqual(3, (int)responseBody[2]);
            Assert.AreEqual(300, (int)responseBody[3]);
        });

        [Test]
        public Task GetArrayIntegerWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetIntInvalidNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (int)responseBody[0]);
            Assert.AreEqual(null, (string)responseBody[1]);
            Assert.AreEqual(0, (int)responseBody[2]);
        });

        [Test]
        public Task GetArrayIntegerWithString() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetIntInvalidStringAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (int)responseBody[0]);
            Assert.AreEqual("integer", (string)responseBody[1]);
            Assert.AreEqual(0, (int)responseBody[2]);
        });

        [Test]
        public Task GetArrayInvalid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetInvalidAsync(new());
            Assert.Throws(Is.InstanceOf<Exception>(), () => JsonData.FromBytes(result.Content.ToMemory()));
        });

        [Test]
        public Task GetArrayLongValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetLongValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (long)responseBody[0]);
            Assert.AreEqual(-1, (long)responseBody[1]);
            Assert.AreEqual(3, (long)responseBody[2]);
            Assert.AreEqual(300L, (long)responseBody[3]);
        });

        [Test]
        public Task GetArrayLongWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetLongInvalidNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (long)responseBody[0]);
            Assert.AreEqual(null, (string)responseBody[1]);
            Assert.AreEqual(0, (long)responseBody[2]);
        });

        [Test]
        public Task GetArrayLongWithString() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetLongInvalidStringAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual(1, (long)responseBody[0]);
            Assert.AreEqual("integer", (string)responseBody[1]);
            Assert.AreEqual(0, (long)responseBody[2]);
        });

        [Test]
        public Task GetArrayNull() => Test(async (host) =>
        {
            // Empty response body
            var result = await new ArrayClient(Key, host).GetNullAsync(new());

            Assert.IsEmpty(result.Content.ToString());
        });

        [Test]
        public Task GetArrayStringEnumValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetStringEnumValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("foo1", (string)responseBody[0]);
            Assert.AreEqual("foo2", (string)responseBody[1]);
            Assert.AreEqual("foo3", (string)responseBody[2]);
        });

        [Test]
        public Task GetArrayStringValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetStringValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("foo1", (string)responseBody[0]);
            Assert.AreEqual("foo2", (string)responseBody[1]);
            Assert.AreEqual("foo3", (string)responseBody[2]);
        });

        [Test]
        public Task GetArrayStringWithNull() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetStringWithNullAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("foo", (string)responseBody[0]);
            Assert.AreEqual(null, (string)responseBody[1]);
            Assert.AreEqual("foo2", (string)responseBody[2]);
        });

        [Test]
        public Task GetArrayStringWithNumber() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetStringWithInvalidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("foo", (string)responseBody[0]);
            Assert.AreEqual(123, (int)responseBody[1]);
            Assert.AreEqual("foo2", (string)responseBody[2]);
        });

        [Test]
        public Task GetArrayUuidValid() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetUuidValidAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("6dcc7237-45fe-45c4-8a6b-3a8a3f625652", (string)responseBody[0]);
            Assert.AreEqual("d1399005-30f7-40d6-8da6-dd7c89ad34db", (string)responseBody[1]);
            Assert.AreEqual("f42f6aa1-a5bc-4ddf-907e-5f915de43205", (string)responseBody[2]);
        });

        [Test]
        public Task GetArrayUuidWithInvalidChars() => Test(async (host) =>
        {
            var result = await new ArrayClient(Key, host).GetUuidInvalidCharsAsync(new());
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());

            Assert.AreEqual("6dcc7237-45fe-45c4-8a6b-3a8a3f625652", (string)responseBody[0]);
            Assert.AreEqual("foo", (string)responseBody[1]);
        });

        [Test]
        public Task PutArrayArrayValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { new[] { "1", "2", "3" }, new[] { "4", "5", "6" }, new[] { "7", "8", "9" }});
            return await new ArrayClient(Key, host).PutArrayValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayBooleanValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { true, false, false, true });
            return await new ArrayClient(Key, host).PutBooleanTfftAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayByteValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { new byte[] { 255, 255, 255, 250 }, new byte[] { 1, 2, 3 }, new byte[] { 37, 41, 67 } });
            return await new ArrayClient(Key, host).PutByteValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayComplexValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] {new Dictionary<string, object>
            {
                ["integer"] = 1,
                ["string"] = "2",
            },
            new Dictionary<string, object>
            {
                ["integer"] = 3,
                ["string"] = "4",
            },
            new Dictionary<string, object>
            {
                ["integer"] = 5,
                ["string"] = "6",
            }});
            return await new ArrayClient(Key, host).PutComplexValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayDictionaryValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[]
            {
                new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } },
                new Dictionary<string, string>() { { "4", "four" }, { "5", "five" }, { "6", "six" } },
                new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }
            });
            return await new ArrayClient(Key, host).PutDictionaryValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayDoubleValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { 0, -0.01, -1.2e20 });
            return await new ArrayClient(Key, host).PutDoubleValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayEmpty() => TestStatus(async (host) =>
        {
            var data = new JsonData(new string[] { });
            return await new ArrayClient(Key, host).PutEmptyAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayEnumValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { "foo1", "foo2", "foo3" });
            return await new ArrayClient(Key, host).PutEnumValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayFloatValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { 0, -0.01f, -1.2e20f });
            return await new ArrayClient(Key, host).PutFloatValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayIntegerValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { 1, -1, 3, 300 });
            return await new ArrayClient(Key, host).PutIntegerValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayLongValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { 1, -1, 3, 300L });
            return await new ArrayClient(Key, host).PutLongValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayStringEnumValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[]
            {
                "foo1",
                "foo2",
                "foo3"
            });
            return await new ArrayClient(Key, host).PutStringEnumValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayStringValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[] { "foo1", "foo2", "foo3" });
            return await new ArrayClient(Key, host).PutStringValidAsync(RequestContent.Create(data));
        });

        [Test]
        public Task PutArrayUuidValid() => TestStatus(async (host) =>
        {
            var data = new JsonData(new[]
            {
                Guid.Parse("6dcc7237-45fe-45c4-8a6b-3a8a3f625652"),
                Guid.Parse("d1399005-30f7-40d6-8da6-dd7c89ad34db"),
                Guid.Parse("f42f6aa1-a5bc-4ddf-907e-5f915de43205")
            });
            return await new ArrayClient(Key, host).PutUuidValidAsync(RequestContent.Create(data));
        });

        private async Task<IReadOnlyList<IDictionary<string, string>>> ToDictionaryAsync(Stream contentStream)
        {
            using var document = await JsonDocument.ParseAsync(contentStream, default).ConfigureAwait(false);
            List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
                {
                    array.Add(null);
                }
                else
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property in item.EnumerateObject())
                    {
                        dictionary.Add(property.Name, property.Value.GetString());
                    }
                    array.Add(dictionary);
                }
            }

            return array;
        }

        private async Task<IReadOnlyList<DateTimeOffset>> ToDateTimeArrayAsync(Stream contentStream)
        {
            using var document = await JsonDocument.ParseAsync(contentStream, default).ConfigureAwait(false);
            List<DateTimeOffset> array = new List<DateTimeOffset>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetDateTimeOffset("R"));
            }

            return array;
        }

        private async Task<IReadOnlyList<byte[]>> ToByteArrayAsync(Stream contentStream, string format)
        {
            using var document = await JsonDocument.ParseAsync(contentStream, default).ConfigureAwait(false);
            List<byte[]> array = new List<byte[]>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetBytesFromBase64(format));
            }

            return array;
        }

        private async Task<List<IList<string>>> ToStringArrayAsync(Stream contentStream)
        {
            using var document = await JsonDocument.ParseAsync(contentStream, default).ConfigureAwait(false);
            List<IList<string>> array = new List<IList<string>>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                if (item.ValueKind == JsonValueKind.Null)
                {
                    array.Add(null);
                }
                else
                {
                    List<string> array0 = new List<string>();
                    foreach (var item0 in item.EnumerateArray())
                    {
                        array0.Add(item0.GetString());
                    }
                    array.Add(array0);
                }
            }

            return array;
        }
    }
}
