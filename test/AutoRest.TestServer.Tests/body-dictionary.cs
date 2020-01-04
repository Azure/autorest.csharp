// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_dictionary;
using body_dictionary.Models.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyDictionary : TestServerTestBase
    {
        public BodyDictionary(TestServerVersion version) : base(version, "dictionary") { }

        [Test]
        public Task GetDictionaryArrayEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayEmptyAsync();
            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryArrayItemEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayItemEmptyAsync();
            CollectionAssert.AreEqual(new Dictionary<string, ICollection<string>>
            {
                { "0", new[] { "1", "2", "3" } },
                { "1", new string[] { } },
                { "2", new[] { "7", "8", "9" } }
            }, result.Value);
        });

        [Test]
        [Ignore("Null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryArrayItemNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayItemNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, ICollection<string>>
            {
                { "0", new[] { "1", "2", "3" } },
                { "1", null },
                { "2", new[] { "7", "8", "9" } }
            }, result.Value);
        });

        [Test]
        [Ignore("Null responses: https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetDictionaryArrayNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayNullAsync();
            Assert.IsNull(result.Value);
        });

        [Test]
        public Task GetDictionaryArrayValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayValidAsync();
            CollectionAssert.AreEqual(new Dictionary<string, ICollection<string>>
            {
                { "0", new[] { "1", "2", "3" } },
                { "1", new[] { "4", "5", "6" } },
                { "2", new[] { "7", "8", "9" } }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryBase64Url() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetBase64UrlAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                //https://stackoverflow.com/a/50525594/294804
                { "0", Convert.FromBase64String("YSBzdHJpbmcgdGhhdCBnZXRzIGVuY29kZWQgd2l0aCBiYXNlNjR1cmw=") },
                { "1", Convert.FromBase64String("dGVzdCBzdHJpbmc=") },
                { "2", Convert.FromBase64String("TG9yZW0gaXBzdW0=") }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryBooleanValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetBooleanTfftAsync();
            CollectionAssert.AreEqual(new Dictionary<string, bool>
            {
                { "0", true },
                { "1", false },
                { "2", false },
                { "3", true }
            }, result.Value);
        });

        [Test]
        [Ignore("Null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryBooleanWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetBooleanInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, bool?>
            {
                { "0", true },
                { "1", null },
                { "2", false }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryBooleanWithString() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetBooleanInvalidStringAsync());
        });

        [Test]
        public Task GetDictionaryByteValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteValidAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 255, 255, 255, 250 } },
                { "1", new byte[] { 1, 2, 3 } },
                { "2", new byte[] { 37, 41, 67 } }
            }, result.Value);
        });

        [Test]
        [Ignore("Null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryByteWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryComplexEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetComplexEmptyAsync();
            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryComplexItemEmpty() => Test(async (host, pipeline) =>
        {
            var value = new Dictionary<string, Widget>
            {
                { "0", new Widget { Integer = 1, String = "2" } },
                { "1", new Widget() },
                { "2", new Widget { Integer = 5, String = "6" } }
            };
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetComplexItemEmptyAsync();
            CollectionAssert.AreEqual(value.Keys, result.Value.Keys);
            Assert.AreEqual(value["0"].Integer, result.Value["0"].Integer);
            Assert.AreEqual(value["0"].String, result.Value["0"].String);
            Assert.AreEqual(value["1"].Integer, result.Value["1"].Integer);
            Assert.AreEqual(value["1"].String, result.Value["1"].String);
            Assert.AreEqual(value["2"].Integer, result.Value["2"].Integer);
            Assert.AreEqual(value["2"].String, result.Value["2"].String);
        });

        [Test]
        [Ignore("Null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryComplexItemNull() => Test(async (host, pipeline) =>
        {
            var value = new Dictionary<string, Widget>
            {
                { "0", new Widget { Integer = 1, String = "2" } },
                { "1", null },
                { "2", new Widget { Integer = 5, String = "6" } }
            };
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetComplexItemNullAsync();
            CollectionAssert.AreEqual(value.Keys, result.Value.Keys);
            Assert.AreEqual(value["0"].Integer, result.Value["0"].Integer);
            Assert.AreEqual(value["0"].String, result.Value["0"].String);
            Assert.IsNull(result.Value["1"]);
            Assert.AreEqual(value["2"].Integer, result.Value["2"].Integer);
            Assert.AreEqual(value["2"].String, result.Value["2"].String);
        });

        [Test]
        [Ignore("Null responses: https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetDictionaryComplexNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetComplexNullAsync();
            Assert.IsNull(result.Value);
        });

        [Test]
        public Task GetDictionaryComplexValid() => Test(async (host, pipeline) =>
        {
            var value = new Dictionary<string, Widget>
            {
                { "0", new Widget { Integer = 1, String = "2" } },
                { "1", new Widget { Integer = 3, String = "4" } },
                { "2", new Widget { Integer = 5, String = "6" } }
            };
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetComplexValidAsync();
            CollectionAssert.AreEqual(value.Keys, result.Value.Keys);
            Assert.AreEqual(value["0"].Integer, result.Value["0"].Integer);
            Assert.AreEqual(value["0"].String, result.Value["0"].String);
            Assert.AreEqual(value["1"].Integer, result.Value["1"].Integer);
            Assert.AreEqual(value["1"].String, result.Value["1"].String);
            Assert.AreEqual(value["2"].Integer, result.Value["2"].Integer);
            Assert.AreEqual(value["2"].String, result.Value["2"].String);
        });

        [Test]
        public Task GetDictionaryDateTimeRfc1123Valid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateTimeRfc1123ValidAsync();
            CollectionAssert.AreEqual(new Dictionary<string, DateTimeOffset>
            {
                { "0", DateTimeOffset.Parse("Fri, 01 Dec 2000 00:00:01 GMT") },
                { "1", DateTimeOffset.Parse("Wed, 02 Jan 1980 00:11:35 GMT") },
                { "2", DateTimeOffset.Parse("Wed, 12 Oct 1492 10:15:01 GMT") }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDateTimeValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateTimeValidAsync();
            CollectionAssert.AreEqual(new Dictionary<string, DateTimeOffset>
            {
                { "0", DateTimeOffset.Parse("2000-12-01t00:00:01z") },
                { "1", DateTimeOffset.Parse("1980-01-02T00:11:35+01:00") },
                { "2", DateTimeOffset.Parse("1492-10-12T10:15:01-08:00") }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDateTimeWithInvalidChars() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateTimeInvalidCharsAsync());
        });

        [Test]
        [Ignore("Null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryDateTimeWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateTimeInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, DateTimeOffset?>
            {
                { "0", DateTimeOffset.Parse("2000-12-01t00:00:01z") },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDateValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateValidAsync();
            CollectionAssert.AreEqual(new Dictionary<string, DateTimeOffset>
            {
                { "0", DateTimeOffset.Parse("2000-12-01") },
                { "1", DateTimeOffset.Parse("1980-01-02") },
                { "2", DateTimeOffset.Parse("1492-10-12") }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDateWithInvalidChars() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateInvalidCharsAsync());
        });

        [Test]
        [Ignore("Null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryDateWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDateInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, DateTimeOffset?>
            {
                { "0", DateTimeOffset.Parse("2012-01-01") },
                { "1", null },
                { "2", DateTimeOffset.Parse("1776-07-04") }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDictionaryEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDictionaryEmptyAsync();
            CollectionAssert.IsEmpty(result.Value);
        });

        [Test]
        //TODO: Passes but has a bug: https://github.com/Azure/autorest.modelerfour/issues/106
        public Task GetDictionaryDictionaryItemEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDictionaryItemEmptyAsync();
            CollectionAssert.AreEqual(new Dictionary<string, Dictionary<string, string>>
            {
                { "0", new Dictionary<string, string> { { "1", "one" }, { "2", "two" }, { "3", "three" } } },
                { "1", new Dictionary<string, string>() },
                { "2", new Dictionary<string, string> { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } } }
            }, result.Value);
        });

        [Test]
        [Ignore("Passes because of this bug: https://github.com/Azure/autorest.modelerfour/issues/106, but should fail because of null collection items: https://github.com/Azure/autorest.csharp/issues/366")]
        public Task GetDictionaryDictionaryItemNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDictionaryItemNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, Dictionary<string, string>>
            {
                { "0", new Dictionary<string, string> { { "1", "one" }, { "2", "two" }, { "3", "three" } } },
                { "1", null },
                { "2", new Dictionary<string, string> { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } } }
            }, result.Value);
        });

        [Test]
        [Ignore("Null responses: https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetDictionaryDictionaryNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDictionaryNullAsync();
            Assert.IsNull(result.Value);
        });

        [Test]
        //TODO: Passes but has a bug: https://github.com/Azure/autorest.modelerfour/issues/106
        public Task GetDictionaryDictionaryValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetDictionaryValidAsync();
            CollectionAssert.AreEqual(new Dictionary<string, Dictionary<string, string>>
            {
                { "0", new Dictionary<string, string> { { "1", "one" }, { "2", "two" }, { "3", "three" } } },
                { "1", new Dictionary<string, string> { { "4", "four" }, { "5", "five" }, { "6", "six" } } },
                { "2", new Dictionary<string, string> { { "7", "seven" }, { "8", "eight" }, { "9", "nine" } } }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDoubleValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDoubleWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDoubleWithString() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryDurationValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryFloatValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryFloatWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryFloatWithString() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryIntegerValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryIntegerWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryIntegerWithString() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryInvalid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryKeyEmptyString() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryLongValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryLongWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryLongWithString() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryNullkey() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryNullValue() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryStringValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryStringWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task GetDictionaryStringWithNumber() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetByteInvalidNullAsync();
            CollectionAssert.AreEqual(new Dictionary<string, byte[]>
            {
                { "0", new byte[] { 171, 172, 173 } },
                { "1", null }
            }, result.Value);
        });

        [Test]
        public Task PutDictionaryArrayValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryBooleanValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryByteValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryComplexValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryDateTimeValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryDateValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryDictionaryValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryDoubleValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryDurationValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryEmpty() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryFloatValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryIntegerValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryLongValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDictionaryStringValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });
    }
}
