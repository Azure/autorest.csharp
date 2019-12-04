// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using body_string;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringTest : TestServerTestBase
    {
        public BodyStringTest(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetMbcs() => Test("getStringMultiByteCharacters", async (host, pipeline) =>
        {
            var result = await StringOperations.GetMbcsAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€", result.Value);
        });

        [Test]
        public Task PutMbcs() => Test("putStringMultiByteCharacters", async (host, pipeline) =>
        {
            var result = await StringOperations.PutMbcsAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetNull() => Test("string_null", async (host, pipeline) =>
        {
            var result = await StringOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V1, "returns 400")]
        public Task PutNull() => Test("string_null", async (host, pipeline) =>
        {
            var result = await StringOperations.PutNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetEmpty() => Test("getStringEmpty", async (host, pipeline) =>
        {
            var result = await StringOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("", result.Value);
        });

        [Test]
        public Task PutEmpty() => Test("putStringEmpty", async (host, pipeline) =>
        {
            var result = await StringOperations.PutEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetWhitespace() => Test("getStringWithLeadingAndTrailingWhitespace", async (host, pipeline) =>
        {
            var result = await StringOperations.GetWhitespaceAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("    Now is the time for all good men to come to the aid of their country    ", result.Value);
        });

        [Test]
        public Task PutWhitespace() => Test("putStringWithLeadingAndTrailingWhitespace", async (host, pipeline) =>
        {
            var result = await StringOperations.PutWhitespaceAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetNotProvided() => Test("string_notprovided", async (host, pipeline) =>
        {
            var result = await StringOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("", result.Value);
        });
    }
}
