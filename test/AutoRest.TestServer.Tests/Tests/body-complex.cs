// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using body_complex;
using body_complex.Models.V20160229;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Tests
{
    public class BodyComplexTest: TestServerTestBase
    {
        public BodyComplexTest(TestServerVersion version) : base(version) { }

        [Test]
        public Task PutComplexBasicValid() => Test(async (host, pipeline) =>
        {
            var basic = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.Magenta
            };
            var result = await BasicOperations.PutValidAsync(ClientDiagnostics, pipeline, basic, host);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task GetComplexBasicValid() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("abc", result.Value.Name);
            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual(CMYKColors.YELLOW, result.Value.Color);
        });

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexBasicEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexBasicNotProvided() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexBasicNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexBasicInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveInteger() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveLong() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveFloat() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveDouble() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveBool() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveDate() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveDateTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveDateTimeRfc1123() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveDuration() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPrimitiveByte() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveInteger() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveLong() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveFloat() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDouble() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveBool() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDate() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDateTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDateTimeRfc1123() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDuration() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveByte() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexArrayValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexArrayEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexArrayValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexArrayEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexArrayNotProvided() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexDictionaryValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexDictionaryEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryNotProvided() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexInheritanceValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexInheritanceValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphismValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphismValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphismComplicated() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphismComplicated() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphismNoDiscriminator() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphicRecursiveValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphicRecursiveValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexReadOnlyPropertyValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        public override IEnumerable<string> AdditionalKnownScenarios { get; } = new[] {
            "PutComplexBasicValid",
            "GetComplexBasicValid",
            "GetComplexBasicEmpty",
            "GetComplexBasicNotProvided",
            "GetComplexBasicNull",
            "GetComplexBasicInvalid",
            "PutComplexPrimitiveInteger",
            "PutComplexPrimitiveLong",
            "PutComplexPrimitiveFloat",
            "PutComplexPrimitiveDouble",
            "PutComplexPrimitiveBool",
            "PutComplexPrimitiveString",
            "PutComplexPrimitiveDate",
            "PutComplexPrimitiveDateTime",
            "PutComplexPrimitiveDateTimeRfc1123",
            "PutComplexPrimitiveDuration",
            "PutComplexPrimitiveByte",
            "GetComplexPrimitiveInteger",
            "GetComplexPrimitiveLong",
            "GetComplexPrimitiveFloat",
            "GetComplexPrimitiveDouble",
            "GetComplexPrimitiveBool",
            "GetComplexPrimitiveString",
            "GetComplexPrimitiveDate",
            "GetComplexPrimitiveDateTime",
            "GetComplexPrimitiveDateTimeRfc1123",
            "GetComplexPrimitiveDuration",
            "GetComplexPrimitiveByte",
            "PutComplexArrayValid",
            "PutComplexArrayEmpty",
            "GetComplexArrayValid",
            "GetComplexArrayEmpty",
            "GetComplexArrayNotProvided",
            "PutComplexDictionaryValid",
            "PutComplexDictionaryEmpty",
            "GetComplexDictionaryValid",
            "GetComplexDictionaryEmpty",
            "GetComplexDictionaryNull",
            "GetComplexDictionaryNotProvided",
            "PutComplexInheritanceValid",
            "GetComplexInheritanceValid",
            "PutComplexPolymorphismValid",
            "GetComplexPolymorphismValid",
            "PutComplexPolymorphismComplicated",
            "GetComplexPolymorphismComplicated",
            "PutComplexPolymorphismNoDiscriminator",
            "PutComplexPolymorphicRecursiveValid",
            "GetComplexPolymorphicRecursiveValid",
            "PutComplexReadOnlyPropertyValid"
        };
    }
}
