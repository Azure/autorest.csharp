// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using body_string;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringTest : TestServerTestBase
    {
        [Test]
        public Task GetMbcs() => Test("string_mbcs", async host =>
        {
            var result = await StringOperations.GetMbcsAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€", result.Value);
        });

        [Test]
        public Task PutMbcs() => Test("string_mbcs", async host =>
        {
            var result = await StringOperations.PutMbcsAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetNull() => Test("string_null", async host =>
        {
            var result = await StringOperations.GetNullAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual(null, result.Value);
        });

        [Test]
        public Task PutNull() => Test("string_null", async host =>
        {
            var result = await StringOperations.PutNullAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetEmpty() => Test("string_empty", async host =>
        {
            var result = await StringOperations.GetEmptyAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual("", result.Value);
        });

        [Test]
        public Task PutEmpty() => Test("string_empty", async host =>
        {
            var result = await StringOperations.PutEmptyAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetWhitespace() => Test("string_whitespace", async host =>
        {
            var result = await StringOperations.GetWhitespaceAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual("    Now is the time for all good men to come to the aid of their country    ", result.Value);
        });

        [Test]
        public Task PutWhitespace() => Test("string_whitespace", async host =>
        {
            var result = await StringOperations.PutWhitespaceAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetNotProvided() => Test("string_notprovided", async host =>
        {
            var result = await StringOperations.GetNotProvidedAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual("", result.Value);
        });
    }
}
