// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using body_array;
using body_array.Models.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyArray : TestServerTestBase
    {
        public BodyArray(TestServerVersion version) : base(version, "array") { }

        [Test]
        public Task GetArrayArrayEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetArrayEmptyAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetArrayArrayItemEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetArrayItemEmptyAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { new object[] { "1", "2", "3" }, new object[] { }, new object[] { "7", "8", "9" } }, result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetArrayArrayItemNull() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetArrayItemNullAsync(ClientDiagnostics, pipeline, host);

            Assert.IsNull(result.Value.Single());
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetArrayArrayNull() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetArrayNullAsync(ClientDiagnostics, pipeline, host);

            Assert.IsNull(result.Value);
        });

        [Test]
        public Task GetArrayArrayValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetArrayValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { new object[] { "1", "2", "3" }, new object[] { "4", "5", "6" }, new object[] { "7", "8", "9" } }, result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/367")]
        public Task GetArrayBase64Url() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetBase64UrlAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { new object[] { "1", "2", "3" }, new object[] { "4", "5", "6" }, new object[] { "7", "8", "9" } }, result.Value);
        });

        [Test]
        public Task GetArrayBooleanValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetBooleanTfftAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { true, false, false, true }, result.Value);
        });

        [Test]
        public Task GetArrayBooleanWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetBooleanInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayBooleanWithString() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetBooleanInvalidStringAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayByteValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetByteValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { new[] { 255, 255, 255, 250 }, new[] { 1, 2, 3 }, new[] { 37, 41, 67 } }, result.Value);
        });

        [Test]
        public Task GetArrayByteWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetByteInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayComplexEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetComplexEmptyAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetArrayComplexItemEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetComplexItemEmptyAsync(ClientDiagnostics, pipeline, host);
            var values = result.Value.ToArray();

            Assert.AreEqual(3, values.Length);
            Assert.AreEqual(1, values[0].Integer);
            Assert.AreEqual("2", values[0].String);

            Assert.AreEqual(null, values[1].Integer);
            Assert.AreEqual(null, values[1].String);


            Assert.AreEqual(5, values[2].Integer);
            Assert.AreEqual("6", values[2].String);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetArrayComplexItemNull() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetComplexItemNullAsync(ClientDiagnostics, pipeline, host);

            var values = result.Value.ToArray();

            Assert.AreEqual(3, values.Length);
            Assert.AreEqual(1, values[0].Integer);
            Assert.AreEqual("2", values[0].String);

            Assert.AreEqual(null, values[1]);


            Assert.AreEqual(5, values[2].Integer);
            Assert.AreEqual("6", values[2].String);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetArrayComplexNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetArrayComplexValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetComplexValidAsync(ClientDiagnostics, pipeline, host);
            var values = result.Value.ToArray();

            Assert.AreEqual(3, values.Length);
            Assert.AreEqual(1, values[0].Integer);
            Assert.AreEqual("2", values[0].String);

            Assert.AreEqual(3, values[1].Integer);
            Assert.AreEqual("4", values[1].String);


            Assert.AreEqual(5, values[2].Integer);
            Assert.AreEqual("6", values[2].String);
        });

        [Test]
        public Task GetArrayDateTimeRfc1123Valid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDateTimeRfc1123ValidAsync(ClientDiagnostics, pipeline, host);
            CollectionAssert.AreEqual(new[]
            {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, result.Value);
        });

        [Test]
        public Task GetArrayDateTimeValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDateTimeValidAsync(ClientDiagnostics, pipeline, host);
            CollectionAssert.AreEqual(new[]
            {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, result.Value);
        });

        [Test]
        public Task GetArrayDateTimeWithInvalidChars() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetDateTimeInvalidCharsAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayDateTimeWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetDateTimeInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayDateValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDateValidAsync(ClientDiagnostics, pipeline, host);
            CollectionAssert.AreEqual(new[]
            {
                DateTimeOffset.Parse("2000-12-01"),
                DateTimeOffset.Parse("1980-01-02"),
                DateTimeOffset.Parse("1492-10-12"),
            }, result.Value);
        });

        [Test]
        public Task GetArrayDateWithInvalidChars() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetDateInvalidCharsAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayDateWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetDateInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayDictionaryEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDictionaryEmptyAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetArrayDictionaryItemEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDictionaryItemEmptyAsync(ClientDiagnostics, pipeline, host);

            var values = result.Value.ToArray();

            Assert.AreEqual(3, values.Length);

            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } }, values[0]);
            CollectionAssert.AreEqual(new Dictionary<string, string>(), values[1]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }, values[2]);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetArrayDictionaryItemNull() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDictionaryItemEmptyAsync(ClientDiagnostics, pipeline, host);

            var values = result.Value.ToArray();

            Assert.AreEqual(3, values.Length);

            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } }, values[0]);
            CollectionAssert.AreEqual(null, values[1]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }, values[2]);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetArrayDictionaryNull() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDictionaryNullAsync(ClientDiagnostics, pipeline, host);
        });

        [Test]
        public Task GetArrayDictionaryValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDictionaryValidAsync(ClientDiagnostics, pipeline, host);

            var values = result.Value.ToArray();

            Assert.AreEqual(3, values.Length);

            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } }, values[0]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "4", "four" }, { "5", "five" }, { "6", "six" }, }, values[1]);
            CollectionAssert.AreEqual(new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }, values[2]);
        });

        [Test]
        public Task GetArrayDoubleValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDoubleValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new double[] { 0, -0.01, -1.2e20 }, result.Value);
        });

        [Test]
        public Task GetArrayDoubleWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetDoubleInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayDoubleWithString() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetDoubleInvalidStringAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayDurationValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetDurationValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[]
            {
                XmlConvert.ToTimeSpan("P123DT22H14M12.011S"),
                XmlConvert.ToTimeSpan("P5DT1H0M0S"),
            }, result.Value);
        });

        [Test]
        public Task GetArrayEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task GetArrayEnumValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetEnumValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { FooEnum.Foo1, FooEnum.Foo2, FooEnum.Foo3 }, result.Value);
        });

        [Test]
        public Task GetArrayFloatValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetFloatValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { 0, -0.01f, -1.2e20f }, result.Value);
        });

        [Test]
        public Task GetArrayFloatWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetFloatInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayFloatWithString() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetFloatInvalidStringAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayIntegerValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetIntegerValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { 1, -1, 3, 300 }, result.Value);
        });

        [Test]
        public Task GetArrayIntegerWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetIntInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayIntegerWithString() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetIntInvalidStringAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetInvalidAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayLongValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetLongValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { 1, -1, 3, 300L }, result.Value);
        });

        [Test]
        public Task GetArrayLongWithNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetLongInvalidNullAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetArrayLongWithString() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetLongInvalidStringAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetArrayNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task GetArrayStringEnumValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetStringEnumValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { Enum0.Foo1, Enum0.Foo2, Enum0.Foo3 }, result.Value);
        });

        [Test]
        public Task GetArrayStringValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetStringValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { "foo1", "foo2", "foo3" }, result.Value);
        });

        [Test]
        public Task GetArrayStringWithNull() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetStringWithNullAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { "foo", null, "foo2" }, result.Value);
        });

        [Test]
        public Task GetArrayStringWithNumber() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetStringWithInvalidAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        //TODO: https://github.com/Azure/autorest.csharp/issues/369
        public Task GetArrayUuidValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetUuidValidAsync(ClientDiagnostics, pipeline, host);

            CollectionAssert.AreEqual(new[] { "6dcc7237-45fe-45c4-8a6b-3a8a3f625652", "d1399005-30f7-40d6-8da6-dd7c89ad34db", "f42f6aa1-a5bc-4ddf-907e-5f915de43205" }, result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/369")]
        public Task GetArrayUuidWithInvalidChars() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<Exception>(), async () => await ArrayOperations.GetUuidInvalidCharsAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task PutArrayArrayValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutArrayValidAsync(ClientDiagnostics, pipeline,
            new[] { new[] { "1", "2", "3" }, new[] { "4", "5", "6" }, new[] { "7", "8", "9" } }, host));

        [Test]
        public Task PutArrayBooleanValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutBooleanTfftAsync(ClientDiagnostics, pipeline,
            new[] { true, false, false, true }, host));

        [Test]
        public Task PutArrayByteValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutByteValidAsync(ClientDiagnostics, pipeline,
            new[] { new byte[] { 255, 255, 255, 250 }, new byte[] { 1, 2, 3 }, new byte[] { 37, 41, 67 } }, host));

        [Test]
        public Task PutArrayComplexValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutComplexValidAsync(ClientDiagnostics, pipeline,
            new[] { new Product() { Integer = 1, String = "2" }, new Product() { Integer = 3, String = "4" }, new Product() { Integer = 5, String = "6" }}, host));

        [Test]
        public Task PutArrayDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutDateTimeRfc1123ValidAsync(ClientDiagnostics, pipeline,
            new[] {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task PutArrayDateTimeValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutDateTimeValidAsync(ClientDiagnostics, pipeline,
            new[] {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, host));

        [Test]
        public Task PutArrayDateValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutDateValidAsync(ClientDiagnostics, pipeline,
            new[] {
                DateTimeOffset.Parse("2000-12-01 00:00:01+00:00"),
                DateTimeOffset.Parse("1980-01-02 00:11:35+00:00"),
                DateTimeOffset.Parse("1492-10-12 10:15:01+00:00"),
            }, host));

        [Test]
        public Task PutArrayDictionaryValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutDictionaryValidAsync(ClientDiagnostics, pipeline,
            new[]
            {
                new Dictionary<string, string>() { { "1", "one" }, { "2", "two" }, { "3", "three" } },
                new Dictionary<string, string>() { { "4", "four" }, { "5", "five" }, { "6", "six" } },
                new Dictionary<string, string>() { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } }
            }, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task PutArrayDoubleValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutDoubleValidAsync(ClientDiagnostics, pipeline,
            new[] { 0, -0.01, -1.2e20 }, host));

        [Test]
        public Task PutArrayDurationValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutDurationValidAsync(ClientDiagnostics, pipeline,
            new[] {
                XmlConvert.ToTimeSpan("P123DT22H14M12.011S"),
                XmlConvert.ToTimeSpan("P5DT1H0M0S")
            }, host));

        [Test]
        public Task PutArrayEmpty() => TestStatus(async (host, pipeline) => await ArrayOperations.PutEmptyAsync(ClientDiagnostics, pipeline,
            new string[] { }, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task PutArrayEnumValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutEnumValidAsync(ClientDiagnostics, pipeline,
            new[] { FooEnum.Foo1, FooEnum.Foo2, FooEnum.Foo3 }, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task PutArrayFloatValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutFloatValidAsync(ClientDiagnostics, pipeline,
            new[] { 0, -0.01f, -1.2e20f }, host));

        [Test]
        public Task PutArrayIntegerValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutIntegerValidAsync(ClientDiagnostics, pipeline,
            new[] { 1, -1, 3, 300 }, host));

        [Test]
        public Task PutArrayLongValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutLongValidAsync(ClientDiagnostics, pipeline,
           new[] { 1, -1, 3, 300L }, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "no match")]
        public Task PutArrayStringEnumValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutStringEnumValidAsync(ClientDiagnostics, pipeline,
           new[] { Enum0.Foo1, Enum0.Foo2, Enum0.Foo3 }, host));

        [Test]
        public Task PutArrayStringValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutStringValidAsync(ClientDiagnostics, pipeline,
           new[] { "foo1", "foo2", "foo3" }, host));

        [Test]
        public Task PutArrayUuidValid() => TestStatus(async (host, pipeline) => await ArrayOperations.PutUuidValidAsync(ClientDiagnostics, pipeline,
            new[] { "6dcc7237-45fe-45c4-8a6b-3a8a3f625652", "d1399005-30f7-40d6-8da6-dd7c89ad34db", "f42f6aa1-a5bc-4ddf-907e-5f915de43205" }, host));
    }
}
