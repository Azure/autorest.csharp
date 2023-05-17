// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestUriBuilderExtensionsTests
    {
        [TestCase(null, null, "null")]
        [TestCase("str", null, "str")]
        [TestCase(true, null, "true")]
        [TestCase(false, null, "false")]
        [TestCase(42, null, "42")]
        [TestCase(-42, null, "-42")]
        [TestCase(3.14f, null, "3.14")]
        [TestCase(-3.14f, null, "-3.14")]
        [TestCase(3.14, null, "3.14")]
        [TestCase(-3.14, null, "-3.14")]
        [TestCase(299792458L, null, "299792458")]
        [TestCase(-299792458L, null, "-299792458")]
        [TestCase(new byte[] { 1, 2, 3 }, "D", "AQID")]
        [TestCase(new byte[] { 4, 5, 6 }, "U", "BAUG")]
        [TestCase(new string[] { "a", "b" }, null, "a,b")]
        [TestCaseSource(nameof(DateTimeOffsetCases))]
        [TestCaseSource(nameof(TimeSpanCases))]
        [TestCaseSource(nameof(GuidCases))]
        public void ValidateConvertToString(object? value, string? format, string expected)
        {
            var result = RequestUriBuilderExtensions.ConvertToString(value, format);

            Assert.AreEqual(expected, result);
        }

        private static readonly object[] DateTimeOffsetCases = new object[]
        {
            new object[] { new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, default), "O", "2020-05-04T03:02:01.1230000Z" },
            new object[] { new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, new TimeSpan(1, 0, 0)), "O", "2020-05-04T02:02:01.1230000Z" },
            new object[] { new DateTimeOffset(3155378975999999999, default), "O", "9999-12-31T23:59:59.9999999Z" },
            new object[] { new DateTimeOffset(3155378975999999999, new TimeSpan(1, 0, 0)), "O", "9999-12-31T22:59:59.9999999Z" },
            new object[] { new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, default), "o", "2020-05-04T03:02:01.1230000Z" },
            new object[] { new DateTimeOffset(2020, 05, 04, 0,0,0,0, default), "D","2020-05-04" },
            new object[] { new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, default), "U","1588561321" },
            new object[] { new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, default), "R", "Mon, 04 May 2020 03:02:01 GMT" },
            new object[] { new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, new TimeSpan(1, 0, 0)), "R", "Mon, 04 May 2020 02:02:01 GMT" },
        };

        private static readonly object[] TimeSpanCases = new object[]
        {
            new object[] { new TimeSpan(1, 2, 59, 59), "P", "P1DT2H59M59S" },
            new object[] { new TimeSpan(1, 2, 59, 59), null, "P1DT2H59M59S" },
            new object[] { new TimeSpan(1, 2, 59, 59, 500), "c", "1.02:59:59.5000000" }
        };

        private static readonly object[] GuidCases = new object[]
        {
            new object[] { Guid.Parse("11111111-1111-1111-1111-111112111111"), null, "11111111-1111-1111-1111-111112111111" }
        };
    }
}
