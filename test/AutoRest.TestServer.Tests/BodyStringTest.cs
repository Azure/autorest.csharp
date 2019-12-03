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
        public async Task GetMbcs()
        {
            await using var server = TestServerSession.Start("string_mbcs");

            var result = StringOperations.GetMbcsAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€", result.Value);
        }

        [Test]
        public async Task PutMbcs()
        {
            await using var server = TestServerSession.Start("string_mbcs");

            var result = StringOperations.PutMbcsAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }

        [Test]
        [Ignore("Deserializer fails")]
        public async Task GetNull()
        {
            await using var server = TestServerSession.Start("string_null");

            var result = StringOperations.GetNullAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(null, result.Value);
        }

        [Test]
        public async Task PutNull()
        {
            await using var server = TestServerSession.Start("string_null");

            var result = StringOperations.PutNullAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }

        [Test]
        public async Task GetEmpty()
        {
            await using var server = TestServerSession.Start("string_empty");

            var result = StringOperations.GetEmptyAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual("", result.Value);
        }

        [Test]
        public async Task PutEmpty()
        {
            await using var server = TestServerSession.Start("string_empty");

            var result = StringOperations.PutEmptyAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }

        [Test]
        public async Task GetWhitespace()
        {
            await using var server = TestServerSession.Start("string_whitespace");

            var result = StringOperations.GetWhitespaceAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual("    Now is the time for all good men to come to the aid of their country    ", result.Value);
        }

        [Test]
        public async Task PutWhitespace()
        {
            await using var server = TestServerSession.Start("string_whitespace");

            var result = StringOperations.PutWhitespaceAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }

        [Test]
        [Ignore("Deserializer fails")]
        public async Task GetNotProvided()
        {
            await using var server = TestServerSession.Start("string_notprovided");

            var result = StringOperations.GetNotProvidedAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual("", result.Value);
        }
    }
}
