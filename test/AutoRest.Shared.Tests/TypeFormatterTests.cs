// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TypeFormatterTests
    {
        public static object[] DateTimeOffsetCases =
        {
            new object[] { "O", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, default), "2020-05-04T03:02:01.1230000Z" },
            new object[] { "O", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, new TimeSpan(1, 0, 0)), "2020-05-04T02:02:01.1230000Z" },
            new object[] { "O", new DateTimeOffset(3155378975999999999, default), "9999-12-31T23:59:59.9999999Z" },
            new object[] { "O", new DateTimeOffset(3155378975999999999, new TimeSpan(1, 0, 0)), "9999-12-31T22:59:59.9999999Z" },

            new object[] { "o", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, default), "2020-05-04T03:02:01.1230000Z" },

            new object[] { "D", new DateTimeOffset(2020, 05, 04, 0,0,0,0, default), "2020-05-04" },

            new object[] { "U", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, default), "1588561321" },

            new object[] { "R", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, default), "Mon, 04 May 2020 03:02:01 GMT" },
            new object[] { "R", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, new TimeSpan(1, 0, 0)), "Mon, 04 May 2020 02:02:01 GMT" },
        };

        public static object[] TimeSpanCases =
        {
            new object[] { "P", new TimeSpan(1, 2, 59, 59), "P1DT2H59M59S" },
            new object[] { "c", new TimeSpan(1, 2, 59, 59, 500), "1.02:59:59.5000000" }
        };

        [TestCaseSource(nameof(DateTimeOffsetCases))]
        public void FormatsDatesAsString(string format, DateTimeOffset date, string expected)
        {
            var formatted = TypeFormatters.ToString(date, format);
            Assert.AreEqual(expected, formatted);
            Assert.AreEqual(date, TypeFormatters.ParseDateTimeOffset(formatted, format));
        }

        [TestCaseSource(nameof(DateTimeOffsetCases))]
        public void FormatsDatesAsJson(string format, DateTimeOffset date, string expected)
        {
            using MemoryStream memoryStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                if (format == "U")
                {
                    writer.WriteNumberValue(date, format);
                }
                else
                {
                    writer.WriteStringValue(date, format);
                }
            }

            var formatted = JsonDocument.Parse(memoryStream.ToArray()).RootElement;
            Assert.AreEqual(expected, formatted.ToString());
            Assert.AreEqual(date, formatted.GetDateTimeOffset(format));
        }

        [TestCase("2020-05-04T03:02:01.1230000+08:00")]
        [TestCase("2020-05-04T03:02:01.1230000-08:00")]
        [TestCase("2020-05-04T03:02:01.1230000+00:00")]
        [TestCase("2020-05-04T03:02:01.1230000")]
        [TestCase("Mon, 04 May 2020 03:02:01 GMT")]
        [TestCase("Mon, 04 May 2020 03:02:01")]
        public void TestEqualAfterConvertingToUtc(string dateString)
        {
            string[] formats = { "O", "o" };

            foreach (string format in formats)
            {
                var originalDate = DateTimeOffset.Parse(dateString);
                var originalTimeMillis = originalDate.ToUnixTimeMilliseconds();

                var formatted = TypeFormatters.ToString(originalDate, format);
                var utcDate = DateTimeOffset.Parse(formatted);
                Assert.AreEqual(originalTimeMillis, utcDate.ToUnixTimeMilliseconds());
            }
        }

        [TestCaseSource(nameof(TimeSpanCases))]
        public void FormatsTimeSpanAsJson(string format, TimeSpan duration, string expected)
        {
            using MemoryStream memoryStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                writer.WriteStringValue(duration, format);
            }

            var formatted = JsonDocument.Parse(memoryStream.ToArray()).RootElement;
            Assert.AreEqual(expected, formatted.ToString());
            Assert.AreEqual(duration, formatted.GetTimeSpan(format));
        }
    }
}
