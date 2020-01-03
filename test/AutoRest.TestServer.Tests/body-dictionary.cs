// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_dictionary;
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
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayEmptyAsync();
            Assert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryBooleanWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayEmptyAsync();
            Assert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryBooleanWithString() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayEmptyAsync();
            Assert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryByteValid() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayEmptyAsync();
            Assert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryByteWithNull() => Test(async (host, pipeline) =>
        {
            var result = await new DictionaryOperations(ClientDiagnostics, pipeline, host).GetArrayEmptyAsync();
            Assert.IsEmpty(result.Value);
        });

        [Test]
        public Task GetDictionaryComplexEmpty() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryComplexItemEmpty() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryComplexItemNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryComplexNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryComplexValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateTimeRfc1123Valid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateTimeValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateTimeWithInvalidChars() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateTimeWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateWithInvalidChars() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDateWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDictionaryEmpty() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDictionaryItemEmpty() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDictionaryItemNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDictionaryNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDictionaryValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDoubleValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDoubleWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDoubleWithString() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryDurationValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryEmpty() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryFloatValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryFloatWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryFloatWithString() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryIntegerValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryIntegerWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryIntegerWithString() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryInvalid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryKeyEmptyString() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryLongValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryLongWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryLongWithString() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryNullkey() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryNullValue() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryStringValid() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryStringWithNull() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        public Task GetDictionaryStringWithNumber() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

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
