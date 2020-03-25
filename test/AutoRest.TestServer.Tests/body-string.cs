// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_string;
using body_string.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringTest : TestServerTestBase
    {
        public BodyStringTest(TestServerVersion version) : base(version, "string") { }

        [Test]
        public Task GetStringMultiByteCharacters() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetMbcsAsync();
            Assert.AreEqual("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€", result.Value);
        });

        [Test]
        [Ignore("deserializer fails")]
        public Task GetStringNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetNotProvidedAsync();
            Assert.AreEqual("", result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetStringNullBase64UrlEncoding() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetNullBase64UrlEncodedAsync();
            Assert.AreEqual(new byte[] { }, result.Value);
        });

        [Test]
        public Task GetStringBase64Encoded() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetBase64EncodedAsync();
            Assert.AreEqual(new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52}, result.Value);
        });

        [Test]
        public Task GetStringBase64UrlEncoded() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetBase64UrlEncodedAsync();
            Assert.AreEqual(new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52, 117, 114, 108 }, result.Value);
        });

        [Test]
        public Task PutStringBase64UrlEncoded() => TestStatus(async (host, pipeline) =>
            await new StringClient(ClientDiagnostics, pipeline, host).PutBase64UrlEncodedAsync( new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52, 117, 114, 108 }));

        [Test]
        public Task PutStringMultiByteCharacters() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).PutMbcsAsync();
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetStringNull() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetNullAsync();
            Assert.AreEqual(null, result.Value);
        });

        [Test]
        public Task GetStringEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetEmptyAsync();
            Assert.AreEqual("", result.Value);
        });

        [Test]
        public Task PutStringEmpty() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline).PutEmptyAsync("");
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("We are sending null in a body but should be doing a null check")]
        public Task PutStringNull() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline).PutNullAsync(null);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetStringWithLeadingAndTrailingWhitespace() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetWhitespaceAsync();
            Assert.AreEqual("    Now is the time for all good men to come to the aid of their country    ", result.Value);
        });

        [Test]
        public Task PutStringWithLeadingAndTrailingWhitespace() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).PutWhitespaceAsync();
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await new StringClient(ClientDiagnostics, pipeline, host).GetNotProvidedAsync();
            Assert.AreEqual("", result.Value);
        });

        [Test]
        public Task GetEnumReferenced() => Test(async (host, pipeline) =>
        {
            var result = await new EnumClient(ClientDiagnostics, pipeline, host).GetReferencedAsync();
            Assert.AreEqual(Colors.RedColor, result.Value);
        });

        [Test]
        public Task GetEnumReferencedConstant() => Test(async (host, pipeline) =>
        {
            var result = await new EnumClient(ClientDiagnostics, pipeline, host).GetReferencedConstantAsync();
            Assert.AreEqual("Sample String", result.Value.Field1);
        });

        [Test]
        public Task GetEnumNotExpandable() => Test(async (host, pipeline) =>
        {
            var result = await new EnumClient(ClientDiagnostics, pipeline, host).GetNotExpandableAsync();
            Assert.AreEqual(Colors.RedColor, result.Value);
        });

        [Test]
        public Task PutEnumReferenced() => TestStatus(async (host, pipeline) =>
            await new EnumClient(ClientDiagnostics, pipeline, host).PutReferencedAsync( Colors.RedColor));

        [Test]
        public Task PutEnumReferencedConstant() => TestStatus(async (host, pipeline) =>
            await new EnumClient(ClientDiagnostics, pipeline, host).PutReferencedConstantAsync( new RefColorConstant()));

        [Test]
        public Task PutEnumNotExpandable() => TestStatus(async (host, pipeline) =>
            await new EnumClient(ClientDiagnostics, pipeline, host).PutNotExpandableAsync( Colors.RedColor));
    }
}
