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
        public Task PutComplexBasicValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.Magenta
            };
            return await BasicOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
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
        public Task GetComplexBasicEmpty() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/299")]
        public Task GetComplexBasicNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetComplexBasicNull() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/300")]
        public Task GetComplexBasicInvalid() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetInvalidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        public Task PutComplexPrimitiveInteger() => TestStatus(async (host, pipeline) =>
        {
            var value = new IntWrapper
            {
                Field1 = -1,
                Field2 = 2
            };
            return await PrimitiveOperations.PutIntAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/301")]
        public Task PutComplexPrimitiveLong() => TestStatus(async (host, pipeline) =>
        {
            var value = new LongWrapper
            {
                //Field1 = 1099511627775,
                //Field2 = -999511627788
            };
            return await PrimitiveOperations.PutLongAsync(ClientDiagnostics, pipeline, value, host);
        });

        // TODO: Passes, but has a bug: https://github.com/Azure/autorest.csharp/issues/301
        [Test]
        public Task PutComplexPrimitiveFloat() => TestStatus(async (host, pipeline) =>
        {
            var value = new FloatWrapper
            {
                Field1 = 1.05,
                Field2 = -0.003
            };
            return await PrimitiveOperations.PutFloatAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task PutComplexPrimitiveDouble() => TestStatus(async (host, pipeline) =>
        {
            var value = new DoubleWrapper
            {
                Field1 = 3e-100,
                Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose = -0.000000000000000000000000000000000000000000000000000000005
            };
            return await PrimitiveOperations.PutDoubleAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task PutComplexPrimitiveBool() => TestStatus(async (host, pipeline) =>
        {
            var value = new BooleanWrapper
            {
                FieldTrue = true,
                FieldFalse = false
            };
            return await PrimitiveOperations.PutBoolAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task PutComplexPrimitiveString() => TestStatus(async (host, pipeline) =>
        {
            var value = new StringWrapper
            {
                Field = "goodrequest",
                Empty = string.Empty,
                NullProperty = null
            };
            return await PrimitiveOperations.PutStringAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/302")]
        public Task PutComplexPrimitiveDate() => TestStatus(async (host, pipeline) =>
        {
            var value = new DateWrapper
            {
                Field = DateTime.Parse("0001-01-01"),
                Leap = DateTime.Parse("2016-02-29")
            };
            return await PrimitiveOperations.PutDateAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/303")]
        public Task PutComplexPrimitiveDateTime() => TestStatus(async (host, pipeline) =>
        {
            var value = new DatetimeWrapper
            {
                Field = DateTime.Parse("0001-01-01T12:00:00-04:00"),
                Now = DateTime.Parse("2015-05-18T11:38:00-08:00")
            };
            return await PrimitiveOperations.PutDateTimeAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/304")]
        public Task PutComplexPrimitiveDateTimeRfc1123() => TestStatus(async (host, pipeline) =>
        {
            var value = new Datetimerfc1123Wrapper
            {
                Field = DateTime.Parse("Mon, 01 Jan 0001 12:00:00 GMT"),
                Now = DateTime.Parse("Mon, 18 May 2015 11:38:00 GMT")
            };
            return await PrimitiveOperations.PutDateTimeRfc1123Async(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/305")]
        public Task PutComplexPrimitiveDuration() => TestStatus(async (host, pipeline) =>
        {
            var value = new DurationWrapper
            {
                Field = TimeSpan.Parse("P123DT22H14M12.011S")
            };
            return await PrimitiveOperations.PutDurationAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task PutComplexPrimitiveByte() => TestStatus(async (host, pipeline) =>
        {
            var value = new ByteWrapper
            {
                //https://github.com/dotnet/csharplang/issues/1058
                Field = new[] { (byte)0xFF, (byte)0xFE, (byte)0xFD, (byte)0xFC, (byte)0x00, (byte)0xFA, (byte)0xF9, (byte)0xF8, (byte)0xF7, (byte)0xF6 }
            };
            return await PrimitiveOperations.PutByteAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveInteger() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveLong() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveFloat() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDouble() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveBool() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveString() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDate() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDateTime() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDateTimeRfc1123() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveDuration() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPrimitiveByte() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexArrayValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexArrayEmpty() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexArrayValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexArrayEmpty() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexArrayNotProvided() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexDictionaryValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexDictionaryEmpty() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryEmpty() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryNull() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexDictionaryNotProvided() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexInheritanceValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexInheritanceValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphismValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphismValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphismComplicated() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphismComplicated() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphismNoDiscriminator() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexPolymorphicRecursiveValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphicRecursiveValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutComplexReadOnlyPropertyValid() => Test(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

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
