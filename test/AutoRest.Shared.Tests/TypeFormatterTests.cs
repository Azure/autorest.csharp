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
            new object[] { "O", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, new TimeSpan(1, 0, 0)), "2020-05-04T03:02:01.1230000+01:00" },
            new object[] { "O", new DateTimeOffset(3155378975999999999, default), "9999-12-31T23:59:59.9999999Z" },
            new object[] { "O", new DateTimeOffset(3155378975999999999, new TimeSpan(1, 0, 0)), "9999-12-31T23:59:59.9999999+01:00" },

            new object[] { "o", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 123, default), "2020-05-04T03:02:01.1230000Z" },

            new object[] { "D", new DateTimeOffset(2020, 05, 04, 0,0,0,0, default), "2020-05-04" },

            new object[] { "U", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, default), "1588561321" },

            new object[] { "R", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, default), "Mon, 04 May 2020 03:02:01 GMT" },
            new object[] { "R", new DateTimeOffset(2020, 05, 04, 03, 02, 01, 0, new TimeSpan(1, 0, 0)), "Mon, 04 May 2020 02:02:01 GMT" },
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
    }
}
