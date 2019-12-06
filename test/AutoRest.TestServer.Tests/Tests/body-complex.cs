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

        //[Test]
        //[Ignore("InProgress")]
        //public Task UrlPathsStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AdditionalPropertiesTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AdditionalPropertiesSubclass() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AdditionalPropertiesTypeObject() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AdditionalPropertiesTypeString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AdditionalPropertiesInProperties() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AdditionalPropertiesInPropertiesWithAPTypeString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayBooleanValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayBooleanValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayBooleanWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayBooleanWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayIntegerValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayIntegerValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayIntegerWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayIntegerWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayLongValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayLongValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayLongWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayLongWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayFloatValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayFloatValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayFloatWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayFloatWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDoubleValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayDoubleValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDoubleWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDoubleWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayStringValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayStringValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayStringEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayStringEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayStringWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayStringWithNumber() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateWithInvalidChars() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateTimeWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateTimeWithInvalidChars() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDurationValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayDurationValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayUuidValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayUuidWithInvalidChars() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayUuidValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayByteValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayByteValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayByteWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayArrayNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayArrayEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayArrayItemNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayArrayItemEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayArrayValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayArrayValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayComplexNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayComplexEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayComplexItemNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayComplexItemEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayComplexValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayComplexValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDictionaryNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDictionaryEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDictionaryItemNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDictionaryItemEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayDictionaryValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutArrayDictionaryValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetBoolTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutBoolTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetBoolFalse() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutBoolFalse() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetBoolInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetBoolNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetByteNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetByteEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetByteNonAscii() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutByteNonAscii() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetByteInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateOverflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateUnderflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateMax() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDateMax() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDateMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeOverflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeUnderflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDateTimeMaxUtc() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMaxUtcLowercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMaxUtcUppercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMaxLocalPositiveOffsetLowercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMaxLocalPositiveOffsetUppercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMaxLocalNegativeOffsetLowercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMaxLocalNegativeOffsetUppercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMinUtc() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDateTimeMinUtc() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMinLocalPositiveOffset() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeMinLocalNegativeOffset() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123Null() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123Invalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123Overflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123Underflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123MinUtc() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDateTimeRfc1123Max() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123MaxUtcLowercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDateTimeRfc1123MaxUtcUppercase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetIntegerNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetIntegerInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetIntegerOverflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetIntegerUnderflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetLongOverflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetLongUnderflow() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutIntegerMax() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutLongMax() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutIntegerMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutLongMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetNumberNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetFloatInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDoubleInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetFloatBigScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutFloatBigScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDoubleBigScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDoubleBigScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDoubleBigPositiveDecimal() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDoubleBigPositiveDecimal() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDoubleBigNegativeDecimal() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDoubleBigNegativeDecimal() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetFloatSmallScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutFloatSmallScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDoubleSmallScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDoubleSmallScientificNotation() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutStringNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringMultiByteCharacters() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutStringMultiByteCharacters() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringWithLeadingAndTrailingWhitespace() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutStringWithLeadingAndTrailingWhitespace() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringNotProvided() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetEnumNotExpandable() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutEnumNotExpandable() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

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

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsBoolFalse() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsBoolTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsIntPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsIntNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsLongPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsLongNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsFloatPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsFloatNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsDoublePositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsByteEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesBoolNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesIntPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesIntNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesIntNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesLongPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesLongNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesLongNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesFloatNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesStringNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesEnumNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesByteNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDateNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayMultiNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayMultiEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayMultiValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathItemGetAll() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathItemGetGlobalNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathItemGetGlobalAndLocalNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathItemGetPathItemAndLocalNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryNullValue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryNullkey() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryKeyEmptyString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryBooleanValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryBooleanWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryBooleanWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryIntegerValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryIntegerWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryIntegerWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryLongValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryLongWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryLongWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryFloatValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryFloatWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryFloatWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDoubleValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDoubleWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDoubleWithString() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryStringValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryStringWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryStringWithNumber() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateWithInvalidChars() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateTimeWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateTimeWithInvalidChars() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDurationValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryByteValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryByteWithNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryBooleanValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryIntegerValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryLongValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryFloatValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryDoubleValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryStringValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryDurationValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryByteValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryComplexNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryComplexEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryComplexItemNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryComplexItemEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryComplexValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryComplexValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryArrayNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryArrayEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryArrayItemNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryArrayItemEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryArrayValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryArrayValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDictionaryNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDictionaryEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDictionaryItemNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDictionaryItemEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryDictionaryValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDictionaryDictionaryValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutDurationPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDurationNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDurationInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDurationPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterExistingKey() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseExistingKey() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseProtectedKey() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterIntegerPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterIntegerNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterLongPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterLongNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterFloatPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterFloatNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDoublePositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDoubleNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterBoolTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterBoolFalse() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterStringValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterStringNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDateMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDateTimeMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterBytesValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterDurationValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseIntegerPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseIntegerNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseLongPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseLongNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseFloatPositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseFloatNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDoublePositive() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDoubleNegative() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseBoolTrue() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseBoolFalse() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseStringValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseStringNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseStringEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderParameterEnumNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseEnumValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseEnumNull() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDateValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDateMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDateTimeValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDateTimeMin() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseBytesValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HeaderResponseDurationValid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task FormdataStreamUploadFile() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task StreamUploadFile() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ConstantsInPath() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ConstantsInBody() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task CustomBaseUri() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task CustomBaseUriMoreOptions() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetModelFlattenArray() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutModelFlattenArray() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetModelFlattenDictionary() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutModelFlattenDictionary() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetModelFlattenResourceCollection() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutModelFlattenResourceCollection() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutModelFlattenCustomBase() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PostModelFlattenCustomParameter() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutModelFlattenCustomGroupedParameter() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringBase64Encoded() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringBase64UrlEncoded() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutStringBase64UrlEncoded() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetStringNullBase64UrlEncoding() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetArrayBase64Url() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetDictionaryBase64Url() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetUnixTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetInvalidUnixTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetNullUnixTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutUnixTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ExpectedEnum() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task UnexpectedEnum() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AllowedValueEnum() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task RoundTripEnum() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetEnumReferenced() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutEnumReferenced() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetEnumReferencedConstant() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task PutEnumReferencedConstant() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ExpectedNoErrors() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ExpectedPetSadError() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ExpectedPetHungryError() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task IntError() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task StringError() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task AnimalNotFoundError() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task LinkNotFoundError() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComplexPolymorphismDotSyntax() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComposedWithDiscriminator() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task GetComposedWithoutDiscriminator() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalImplicitQuery() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalImplicitHeader() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalImplicitBody() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalIntegerParameter() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalIntegerProperty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalIntegerHeader() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalStringParameter() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalStringProperty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalStringHeader() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalClassParameter() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalClassProperty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalArrayParameter() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalArrayProperty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalArrayHeader() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task OptionalGlobalQuery() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task FileStreamNonempty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task FileStreamVeryLarge() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task FileStreamEmpty() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess200Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess200Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess200Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess200Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess200Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess200Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess201Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess201Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess202Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess202Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess202Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess202Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess204Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess404Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess204Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess204Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess204Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpSuccess204Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect300Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect300Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect301Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect301Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect302Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect302Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect302Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect303Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect307Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect307Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect307Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect307Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect307Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRedirect307Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry408Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry500Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry500Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry502Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry503Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry503Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry504Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpRetry504Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure400Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure400Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure400Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure400Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure400Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure400Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure401Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure402Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure403Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure404Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure405Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure406Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure407Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure409Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure410Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure411Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure412Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure413Put() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure414Patch() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure415Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure416Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure417Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpClientFailure429Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpServerFailure501Head() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpServerFailure501Get() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpServerFailure505Post() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task HttpServerFailure505Delete() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioA200MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioA204MatchingNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioA201DefaultNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioA202DefaultNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioA400DefaultModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioB200MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioB201MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioB400DefaultModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioC200MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioC201MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioC404MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioC400DefaultModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioD202MatchingNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioD204MatchingNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioD400DefaultModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioE202MatchingInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioE204MatchingNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioE400DefaultNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioE400DefaultInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioF200DefaultModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioF200DefaultNone() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioF400DefaultModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioF400DefaultNone() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioG200DefaultInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioG200DefaultNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioG400DefaultInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioG400DefaultNoModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH200MatchingNone() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH200MatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH200MatchingInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH400NonMatchingNone() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH400NonMatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH400NonMatchingInvalid() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioH202NonMatchingModel() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioEmptyErrorBody() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task ResponsesScenarioNoModelErrorBody() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task JsonInputInXMLSwagger() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);

        [Test]
        [Ignore("InProgress")]
        public Task JsonOutputInXMLSwagger() => TestStatus(async (host, pipeline) => await new Task<Response>(() => throw new Exception())/*await TestClass.TestMethodAsync(ClientDiagnostics, pipeline, host)*/);


        public override IEnumerable<string> AdditionalKnownScenarios { get; } = new[] {
            "AdditionalPropertiesTrue",
            "AdditionalPropertiesSubclass",
            "AdditionalPropertiesTypeObject",
            "AdditionalPropertiesTypeString",
            "AdditionalPropertiesInProperties",
            "AdditionalPropertiesInPropertiesWithAPTypeString",
            "GetArrayNull",
            "GetArrayEmpty",
            "PutArrayEmpty",
            "GetArrayInvalid",
            "GetArrayBooleanValid",
            "PutArrayBooleanValid",
            "GetArrayBooleanWithNull",
            "GetArrayBooleanWithString",
            "GetArrayIntegerValid",
            "PutArrayIntegerValid",
            "GetArrayIntegerWithNull",
            "GetArrayIntegerWithString",
            "GetArrayLongValid",
            "PutArrayLongValid",
            "GetArrayLongWithNull",
            "GetArrayLongWithString",
            "GetArrayFloatValid",
            "PutArrayFloatValid",
            "GetArrayFloatWithNull",
            "GetArrayFloatWithString",
            "GetArrayDoubleValid",
            "PutArrayDoubleValid",
            "GetArrayDoubleWithNull",
            "GetArrayDoubleWithString",
            "GetArrayStringValid",
            "PutArrayStringValid",
            "GetArrayEnumValid",
            "PutArrayEnumValid",
            "GetArrayStringEnumValid",
            "PutArrayStringEnumValid",
            "GetArrayStringWithNull",
            "GetArrayStringWithNumber",
            "GetArrayDateValid",
            "PutArrayDateValid",
            "GetArrayDateWithNull",
            "GetArrayDateWithInvalidChars",
            "GetArrayDateTimeValid",
            "PutArrayDateTimeValid",
            "GetArrayDateTimeWithNull",
            "GetArrayDateTimeWithInvalidChars",
            "GetArrayDateTimeRfc1123Valid",
            "PutArrayDateTimeRfc1123Valid",
            "GetArrayDurationValid",
            "PutArrayDurationValid",
            "GetArrayUuidValid",
            "GetArrayUuidWithInvalidChars",
            "PutArrayUuidValid",
            "GetArrayByteValid",
            "PutArrayByteValid",
            "GetArrayByteWithNull",
            "GetArrayArrayNull",
            "GetArrayArrayEmpty",
            "GetArrayArrayItemNull",
            "GetArrayArrayItemEmpty",
            "GetArrayArrayValid",
            "PutArrayArrayValid",
            "GetArrayComplexNull",
            "GetArrayComplexEmpty",
            "GetArrayComplexItemNull",
            "GetArrayComplexItemEmpty",
            "GetArrayComplexValid",
            "PutArrayComplexValid",
            "GetArrayDictionaryNull",
            "GetArrayDictionaryEmpty",
            "GetArrayDictionaryItemNull",
            "GetArrayDictionaryItemEmpty",
            "GetArrayDictionaryValid",
            "PutArrayDictionaryValid",
            "GetBoolTrue",
            "PutBoolTrue",
            "GetBoolFalse",
            "PutBoolFalse",
            "GetBoolInvalid",
            "GetBoolNull",
            "GetByteNull",
            "GetByteEmpty",
            "GetByteNonAscii",
            "PutByteNonAscii",
            "GetByteInvalid",
            "GetDateNull",
            "GetDateInvalid",
            "GetDateOverflow",
            "GetDateUnderflow",
            "GetDateMax",
            "PutDateMax",
            "GetDateMin",
            "PutDateMin",
            "GetDateTimeNull",
            "GetDateTimeInvalid",
            "GetDateTimeOverflow",
            "GetDateTimeUnderflow",
            "PutDateTimeMaxUtc",
            "GetDateTimeMaxUtcLowercase",
            "GetDateTimeMaxUtcUppercase",
            "GetDateTimeMaxLocalPositiveOffsetLowercase",
            "GetDateTimeMaxLocalPositiveOffsetUppercase",
            "GetDateTimeMaxLocalNegativeOffsetLowercase",
            "GetDateTimeMaxLocalNegativeOffsetUppercase",
            "GetDateTimeMinUtc",
            "PutDateTimeMinUtc",
            "GetDateTimeMinLocalPositiveOffset",
            "GetDateTimeMinLocalNegativeOffset",
            "GetDateTimeRfc1123Null",
            "GetDateTimeRfc1123Invalid",
            "GetDateTimeRfc1123Overflow",
            "GetDateTimeRfc1123Underflow",
            "GetDateTimeRfc1123MinUtc",
            "PutDateTimeRfc1123Max",
            "PutDateTimeRfc1123Min",
            "GetDateTimeRfc1123MaxUtcLowercase",
            "GetDateTimeRfc1123MaxUtcUppercase",
            "GetIntegerNull",
            "GetIntegerInvalid",
            "GetIntegerOverflow",
            "GetIntegerUnderflow",
            "GetLongOverflow",
            "GetLongUnderflow",
            "PutIntegerMax",
            "PutLongMax",
            "PutIntegerMin",
            "PutLongMin",
            "GetNumberNull",
            "GetFloatInvalid",
            "GetDoubleInvalid",
            "GetFloatBigScientificNotation",
            "PutFloatBigScientificNotation",
            "GetDoubleBigScientificNotation",
            "PutDoubleBigScientificNotation",
            "GetDoubleBigPositiveDecimal",
            "PutDoubleBigPositiveDecimal",
            "GetDoubleBigNegativeDecimal",
            "PutDoubleBigNegativeDecimal",
            "GetFloatSmallScientificNotation",
            "PutFloatSmallScientificNotation",
            "GetDoubleSmallScientificNotation",
            "PutDoubleSmallScientificNotation",
            "GetStringNull",
            "PutStringNull",
            "GetStringEmpty",
            "PutStringEmpty",
            "GetStringMultiByteCharacters",
            "PutStringMultiByteCharacters",
            "GetStringWithLeadingAndTrailingWhitespace",
            "PutStringWithLeadingAndTrailingWhitespace",
            "GetStringNotProvided",
            "GetEnumNotExpandable",
            "PutEnumNotExpandable",
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
            "PutComplexReadOnlyPropertyValid",
            "UrlPathsBoolFalse",
            "UrlPathsBoolTrue",
            "UrlPathsIntPositive",
            "UrlPathsIntNegative",
            "UrlPathsLongPositive",
            "UrlPathsLongNegative",
            "UrlPathsFloatPositive",
            "UrlPathsFloatNegative",
            "UrlPathsDoublePositive",
            "UrlPathsDoubleNegative",
            "UrlPathsStringUrlEncoded",
            "UrlPathsStringEmpty",
            "UrlPathsEnumValid",
            "UrlPathsByteMultiByte",
            "UrlPathsByteEmpty",
            "UrlPathsDateValid",
            "UrlPathsDateTimeValid",
            "UrlQueriesBoolFalse",
            "UrlQueriesBoolTrue",
            "UrlQueriesBoolNull",
            "UrlQueriesIntPositive",
            "UrlQueriesIntNegative",
            "UrlQueriesIntNull",
            "UrlQueriesLongPositive",
            "UrlQueriesLongNegative",
            "UrlQueriesLongNull",
            "UrlQueriesFloatPositive",
            "UrlQueriesFloatNegative",
            "UrlQueriesFloatNull",
            "UrlQueriesDoublePositive",
            "UrlQueriesDoubleNegative",
            "UrlQueriesDoubleNull",
            "UrlQueriesStringUrlEncoded",
            "UrlQueriesStringEmpty",
            "UrlQueriesStringNull",
            "UrlQueriesEnumValid",
            "UrlQueriesEnumNull",
            "UrlQueriesByteMultiByte",
            "UrlQueriesByteEmpty",
            "UrlQueriesByteNull",
            "UrlQueriesDateValid",
            "UrlQueriesDateNull",
            "UrlQueriesDateTimeValid",
            "UrlQueriesDateTimeNull",
            "UrlQueriesArrayCsvNull",
            "UrlQueriesArrayCsvEmpty",
            "UrlQueriesArrayCsvValid",
            "UrlQueriesArrayMultiNull",
            "UrlQueriesArrayMultiEmpty",
            "UrlQueriesArrayMultiValid",
            "UrlQueriesArraySsvValid",
            "UrlQueriesArrayPipesValid",
            "UrlQueriesArrayTsvValid",
            "UrlPathItemGetAll",
            "UrlPathItemGetGlobalNull",
            "UrlPathItemGetGlobalAndLocalNull",
            "UrlPathItemGetPathItemAndLocalNull",
            "PutDictionaryEmpty",
            "GetDictionaryNull",
            "GetDictionaryEmpty",
            "GetDictionaryInvalid",
            "GetDictionaryNullValue",
            "GetDictionaryNullkey",
            "GetDictionaryKeyEmptyString",
            "GetDictionaryBooleanValid",
            "GetDictionaryBooleanWithNull",
            "GetDictionaryBooleanWithString",
            "GetDictionaryIntegerValid",
            "GetDictionaryIntegerWithNull",
            "GetDictionaryIntegerWithString",
            "GetDictionaryLongValid",
            "GetDictionaryLongWithNull",
            "GetDictionaryLongWithString",
            "GetDictionaryFloatValid",
            "GetDictionaryFloatWithNull",
            "GetDictionaryFloatWithString",
            "GetDictionaryDoubleValid",
            "GetDictionaryDoubleWithNull",
            "GetDictionaryDoubleWithString",
            "GetDictionaryStringValid",
            "GetDictionaryStringWithNull",
            "GetDictionaryStringWithNumber",
            "GetDictionaryDateValid",
            "GetDictionaryDateWithNull",
            "GetDictionaryDateWithInvalidChars",
            "GetDictionaryDateTimeValid",
            "GetDictionaryDateTimeWithNull",
            "GetDictionaryDateTimeWithInvalidChars",
            "GetDictionaryDateTimeRfc1123Valid",
            "GetDictionaryDurationValid",
            "GetDictionaryByteValid",
            "GetDictionaryByteWithNull",
            "PutDictionaryBooleanValid",
            "PutDictionaryIntegerValid",
            "PutDictionaryLongValid",
            "PutDictionaryFloatValid",
            "PutDictionaryDoubleValid",
            "PutDictionaryStringValid",
            "PutDictionaryDateValid",
            "PutDictionaryDateTimeValid",
            "PutDictionaryDateTimeRfc1123Valid",
            "PutDictionaryDurationValid",
            "PutDictionaryByteValid",
            "GetDictionaryComplexNull",
            "GetDictionaryComplexEmpty",
            "GetDictionaryComplexItemNull",
            "GetDictionaryComplexItemEmpty",
            "GetDictionaryComplexValid",
            "PutDictionaryComplexValid",
            "GetDictionaryArrayNull",
            "GetDictionaryArrayEmpty",
            "GetDictionaryArrayItemNull",
            "GetDictionaryArrayItemEmpty",
            "GetDictionaryArrayValid",
            "PutDictionaryArrayValid",
            "GetDictionaryDictionaryNull",
            "GetDictionaryDictionaryEmpty",
            "GetDictionaryDictionaryItemNull",
            "GetDictionaryDictionaryItemEmpty",
            "GetDictionaryDictionaryValid",
            "PutDictionaryDictionaryValid",
            "PutDurationPositive",
            "GetDurationNull",
            "GetDurationInvalid",
            "GetDurationPositive",
            "HeaderParameterExistingKey",
            "HeaderResponseExistingKey",
            "HeaderResponseProtectedKey",
            "HeaderParameterIntegerPositive",
            "HeaderParameterIntegerNegative",
            "HeaderParameterLongPositive",
            "HeaderParameterLongNegative",
            "HeaderParameterFloatPositive",
            "HeaderParameterFloatNegative",
            "HeaderParameterDoublePositive",
            "HeaderParameterDoubleNegative",
            "HeaderParameterBoolTrue",
            "HeaderParameterBoolFalse",
            "HeaderParameterStringValid",
            "HeaderParameterStringNull",
            "HeaderParameterStringEmpty",
            "HeaderParameterDateValid",
            "HeaderParameterDateMin",
            "HeaderParameterDateTimeValid",
            "HeaderParameterDateTimeMin",
            "HeaderParameterDateTimeRfc1123Valid",
            "HeaderParameterDateTimeRfc1123Min",
            "HeaderParameterBytesValid",
            "HeaderParameterDurationValid",
            "HeaderResponseIntegerPositive",
            "HeaderResponseIntegerNegative",
            "HeaderResponseLongPositive",
            "HeaderResponseLongNegative",
            "HeaderResponseFloatPositive",
            "HeaderResponseFloatNegative",
            "HeaderResponseDoublePositive",
            "HeaderResponseDoubleNegative",
            "HeaderResponseBoolTrue",
            "HeaderResponseBoolFalse",
            "HeaderResponseStringValid",
            "HeaderResponseStringNull",
            "HeaderResponseStringEmpty",
            "HeaderParameterEnumValid",
            "HeaderParameterEnumNull",
            "HeaderResponseEnumValid",
            "HeaderResponseEnumNull",
            "HeaderResponseDateValid",
            "HeaderResponseDateMin",
            "HeaderResponseDateTimeValid",
            "HeaderResponseDateTimeMin",
            "HeaderResponseDateTimeRfc1123Valid",
            "HeaderResponseDateTimeRfc1123Min",
            "HeaderResponseBytesValid",
            "HeaderResponseDurationValid",
            "FormdataStreamUploadFile",
            "StreamUploadFile",
            "ConstantsInPath",
            "ConstantsInBody",
            "CustomBaseUri",
            "CustomBaseUriMoreOptions",
            "GetModelFlattenArray",
            "PutModelFlattenArray",
            "GetModelFlattenDictionary",
            "PutModelFlattenDictionary",
            "GetModelFlattenResourceCollection",
            "PutModelFlattenResourceCollection",
            "PutModelFlattenCustomBase",
            "PostModelFlattenCustomParameter",
            "PutModelFlattenCustomGroupedParameter",
            "GetStringBase64Encoded",
            "GetStringBase64UrlEncoded",
            "PutStringBase64UrlEncoded",
            "GetStringNullBase64UrlEncoding",
            "GetArrayBase64Url",
            "GetDictionaryBase64Url",
            "UrlPathsStringBase64Url",
            "UrlPathsArrayCSVInPath",
            "GetUnixTime",
            "GetInvalidUnixTime",
            "GetNullUnixTime",
            "PutUnixTime",
            "UrlPathsIntUnixTime",
            "ExpectedEnum",
            "UnexpectedEnum",
            "AllowedValueEnum",
            "RoundTripEnum",
            "GetEnumReferenced",
            "PutEnumReferenced",
            "GetEnumReferencedConstant",
            "PutEnumReferencedConstant",
            "ExpectedNoErrors",
            "ExpectedPetSadError",
            "ExpectedPetHungryError",
            "IntError",
            "StringError",
            "AnimalNotFoundError",
            "LinkNotFoundError",
            "GetComplexPolymorphismDotSyntax",
            "GetComposedWithDiscriminator",
            "GetComposedWithoutDiscriminator",
            "OptionalImplicitQuery",
            "OptionalImplicitHeader",
            "OptionalImplicitBody",
            "OptionalIntegerParameter",
            "OptionalIntegerProperty",
            "OptionalIntegerHeader",
            "OptionalStringParameter",
            "OptionalStringProperty",
            "OptionalStringHeader",
            "OptionalClassParameter",
            "OptionalClassProperty",
            "OptionalArrayParameter",
            "OptionalArrayProperty",
            "OptionalArrayHeader",
            "OptionalGlobalQuery",
            "FileStreamNonempty",
            "FileStreamVeryLarge",
            "FileStreamEmpty",
            "HttpSuccess200Head",
            "HttpSuccess200Get",
            "HttpSuccess200Put",
            "HttpSuccess200Post",
            "HttpSuccess200Patch",
            "HttpSuccess200Delete",
            "HttpSuccess201Put",
            "HttpSuccess201Post",
            "HttpSuccess202Put",
            "HttpSuccess202Post",
            "HttpSuccess202Patch",
            "HttpSuccess202Delete",
            "HttpSuccess204Head",
            "HttpSuccess404Head",
            "HttpSuccess204Put",
            "HttpSuccess204Post",
            "HttpSuccess204Patch",
            "HttpSuccess204Delete",
            "HttpRedirect300Head",
            "HttpRedirect300Get",
            "HttpRedirect301Put",
            "HttpRedirect301Get",
            "HttpRedirect302Head",
            "HttpRedirect302Get",
            "HttpRedirect302Patch",
            "HttpRedirect303Post",
            "HttpRedirect307Head",
            "HttpRedirect307Get",
            "HttpRedirect307Put",
            "HttpRedirect307Post",
            "HttpRedirect307Patch",
            "HttpRedirect307Delete",
            "HttpRetry408Head",
            "HttpRetry500Put",
            "HttpRetry500Patch",
            "HttpRetry502Get",
            "HttpRetry503Post",
            "HttpRetry503Delete",
            "HttpRetry504Put",
            "HttpRetry504Patch",
            "HttpClientFailure400Head",
            "HttpClientFailure400Get",
            "HttpClientFailure400Put",
            "HttpClientFailure400Post",
            "HttpClientFailure400Patch",
            "HttpClientFailure400Delete",
            "HttpClientFailure401Head",
            "HttpClientFailure402Get",
            "HttpClientFailure403Get",
            "HttpClientFailure404Put",
            "HttpClientFailure405Patch",
            "HttpClientFailure406Post",
            "HttpClientFailure407Delete",
            "HttpClientFailure409Put",
            "HttpClientFailure410Head",
            "HttpClientFailure411Get",
            "HttpClientFailure412Get",
            "HttpClientFailure413Put",
            "HttpClientFailure414Patch",
            "HttpClientFailure415Post",
            "HttpClientFailure416Get",
            "HttpClientFailure417Delete",
            "HttpClientFailure429Head",
            "HttpServerFailure501Head",
            "HttpServerFailure501Get",
            "HttpServerFailure505Post",
            "HttpServerFailure505Delete",
            "ResponsesScenarioA200MatchingModel",
            "ResponsesScenarioA204MatchingNoModel",
            "ResponsesScenarioA201DefaultNoModel",
            "ResponsesScenarioA202DefaultNoModel",
            "ResponsesScenarioA400DefaultModel",
            "ResponsesScenarioB200MatchingModel",
            "ResponsesScenarioB201MatchingModel",
            "ResponsesScenarioB400DefaultModel",
            "ResponsesScenarioC200MatchingModel",
            "ResponsesScenarioC201MatchingModel",
            "ResponsesScenarioC404MatchingModel",
            "ResponsesScenarioC400DefaultModel",
            "ResponsesScenarioD202MatchingNoModel",
            "ResponsesScenarioD204MatchingNoModel",
            "ResponsesScenarioD400DefaultModel",
            "ResponsesScenarioE202MatchingInvalid",
            "ResponsesScenarioE204MatchingNoModel",
            "ResponsesScenarioE400DefaultNoModel",
            "ResponsesScenarioE400DefaultInvalid",
            "ResponsesScenarioF200DefaultModel",
            "ResponsesScenarioF200DefaultNone",
            "ResponsesScenarioF400DefaultModel",
            "ResponsesScenarioF400DefaultNone",
            "ResponsesScenarioG200DefaultInvalid",
            "ResponsesScenarioG200DefaultNoModel",
            "ResponsesScenarioG400DefaultInvalid",
            "ResponsesScenarioG400DefaultNoModel",
            "ResponsesScenarioH200MatchingNone",
            "ResponsesScenarioH200MatchingModel",
            "ResponsesScenarioH200MatchingInvalid",
            "ResponsesScenarioH400NonMatchingNone",
            "ResponsesScenarioH400NonMatchingModel",
            "ResponsesScenarioH400NonMatchingInvalid",
            "ResponsesScenarioH202NonMatchingModel",
            "ResponsesScenarioEmptyErrorBody",
            "ResponsesScenarioNoModelErrorBody",
            "JsonInputInXMLSwagger",
            "JsonOutputInXMLSwagger",
        };
    }
}
