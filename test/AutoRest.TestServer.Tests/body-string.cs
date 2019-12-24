// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_string;
using body_string.Models.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringTest : TestServerTestBase
    {
        public BodyStringTest(TestServerVersion version) : base(version, "string") { }

        [Test]
        public Task GetStringMultiByteCharacters() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetMbcsAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€", result.Value);
        });

        [Test]
        [Ignore("deserializer fails")]
        public Task GetStringNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("", result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetStringNullBase64UrlEncoding() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetNullBase64UrlEncodedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(new byte[] { }, result.Value);
        });

        [Test]
        public Task GetStringBase64Encoded() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetBase64EncodedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52}, result.Value);
        });

        [Test]
        public Task GetStringBase64UrlEncoded() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetBase64UrlEncodedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52, 117, 114, 108 }, result.Value);
        });

        [Test]
        public Task PutStringBase64UrlEncoded() => TestStatus(async (host, pipeline) =>
            await StringOperations.PutBase64UrlEncodedAsync(ClientDiagnostics, pipeline, new byte[] { 97, 32, 115, 116, 114, 105, 110, 103, 32, 116, 104, 97, 116, 32, 103, 101, 116, 115, 32, 101, 110, 99, 111, 100, 101, 100, 32, 119, 105, 116, 104, 32, 98, 97, 115, 101, 54, 52, 117, 114, 108 }, host));

        [Test]
        public Task PutStringMultiByteCharacters() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.PutMbcsAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetStringNull() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V1, "returns 400")]
        public Task string_null1() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.PutNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetStringEmpty() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("", result.Value);
        });

        [Test]
        public Task PutStringEmpty() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.PutEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V1, "Test server aborts the connection")]
        public Task PutStringNull() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.PutNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetStringWithLeadingAndTrailingWhitespace() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetWhitespaceAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("    Now is the time for all good men to come to the aid of their country    ", result.Value);
        });

        [Test]
        public Task PutStringWithLeadingAndTrailingWhitespace() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.PutWhitespaceAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        [Ignore("Deserializer fails")]
        public Task GetNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await StringOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("", result.Value);
        });

        [Test]
        public Task GetEnumReferenced() => Test(async (host, pipeline) =>
        {
            var result = await EnumOperations.GetReferencedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(Colors.RedColor, result.Value);
        });

        [Test]
        public Task GetEnumReferencedConstant() => Test(async (host, pipeline) =>
        {
            var result = await EnumOperations.GetReferencedConstantAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("Sample String", result.Value.Field1);
        });

        [Test]
        public Task GetEnumNotExpandable() => Test(async (host, pipeline) =>
        {
            var result = await EnumOperations.GetNotExpandableAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(Colors.RedColor, result.Value);
        });

        [Test]
        public Task PutEnumReferenced() => TestStatus(async (host, pipeline) =>
            await EnumOperations.PutReferencedAsync(ClientDiagnostics, pipeline, Colors.RedColor, host));

        [Test]
        public Task PutEnumReferencedConstant() => TestStatus(async (host, pipeline) =>
            await EnumOperations.PutReferencedConstantAsync(ClientDiagnostics, pipeline, new RefColorConstant(), host));

        [Test]
        public Task PutEnumNotExpandable() => TestStatus(async (host, pipeline) =>
            await EnumOperations.PutNotExpandableAsync(ClientDiagnostics, pipeline, Colors.RedColor, host));
    }
}
