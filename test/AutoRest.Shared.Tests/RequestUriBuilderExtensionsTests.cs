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
        private static readonly Uri _endpoint = new Uri("http://localhost");

        [TestCase(null, true, "http://localhost/bool/true")]
        [TestCase(null, false, "http://localhost/bool/false")]
        [TestCase("fr-FR", true, "http://localhost/bool/true")]
        [TestCase("fr-FR", false, "http://localhost/bool/false")]
        public void AppendPath_BoolValue(string? culture, bool value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bool/", false);
            uri.AppendPath(value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 42, "http://localhost/int/42")]
        [TestCase(null, -42, "http://localhost/int/-42")]
        [TestCase("fr-FR", 42, "http://localhost/int/42")]
        [TestCase("fr-FR", -42, "http://localhost/int/-42")]
        public void AppendPath_IntValue(string? culture, int value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/int/", false);
            uri.AppendPath(value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 299792458, "http://localhost/long/299792458")]
        [TestCase(null, -299792458, "http://localhost/long/-299792458")]
        [TestCase("fr-FR", 299792458, "http://localhost/long/299792458")]
        [TestCase("fr-FR", -299792458, "http://localhost/long/-299792458")]
        public void AppendPath_LongValue(string? culture, long value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/long/", false);
            uri.AppendPath(value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 3.14f, "http://localhost/float/3.14")]
        [TestCase(null, -3.14f, "http://localhost/float/-3.14")]
        [TestCase("fr-FR", 3.14f, "http://localhost/float/3.14")]
        [TestCase("fr-FR", -3.14f, "http://localhost/float/-3.14")]
        public void AppendPath_FloatValue(string? culture, float value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/float/", false);
            uri.AppendPath(value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 3.14, "http://localhost/double/3.14")]
        [TestCase(null, -3.14, "http://localhost/double/-3.14")]
        [TestCase("fr-FR", 3.14, "http://localhost/double/3.14")]
        [TestCase("fr-FR", -3.14, "http://localhost/double/-3.14")]
        public void AppendPath_DoubleValue(string? culture, double value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/double/", false);
            uri.AppendPath(value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new byte[] { 1, 2, 3 }, "D", "http://localhost/bytes/AQID")]
        [TestCase(null, new byte[] { 4, 5, 6 }, "U", "http://localhost/bytes/BAUG")]
        [TestCase("fr-FR", new byte[] { 1, 2, 3 }, "D", "http://localhost/bytes/AQID")]
        [TestCase("fr-FR", new byte[] { 4, 5, 6 }, "U", "http://localhost/bytes/BAUG")]
        public void AppendPath_BytesValue(string? culture, byte[] value, string format, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bytes/", false);
            uri.AppendPath(value, format, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new[] { "hello", "world" }, "http://localhost/strings/hello%2Cworld")]
        [TestCase("fr-FR", new[] { "hello", "world" }, "http://localhost/strings/hello%2Cworld")]
        public void AppendPath_StringArrayValue(string? culture, IEnumerable<string> value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/strings/", false);
            uri.AppendPath(value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, "2021-11-18T10:11:12Z", "D", "http://localhost/datetime/2021-11-18")]
        [TestCase(null, "2022-12-19T11:12:12Z", "O", "http://localhost/datetime/2022-12-19T11%3A12%3A12.0000000Z")]
        [TestCase(null, "2022-12-19T11:12:12Z", "U", "http://localhost/datetime/1671448332")]
        [TestCase("fr-FR", "2021-11-18T10:11:12Z", "D", "http://localhost/datetime/2021-11-18")]
        [TestCase("fr-FR", "2022-12-19T11:12:12Z", "O", "http://localhost/datetime/2022-12-19T11%3A12%3A12.0000000Z")]
        [TestCase("fr-FR", "2022-12-19T11:12:12Z", "U", "http://localhost/datetime/1671448332")]
        public void AppendPath_DateTimeOffsetValue(string? culture, DateTimeOffset value, string format, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/datetime/", false);
            uri.AppendPath(value, format, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, "00:01:18", "P", "http://localhost/timespan/PT1M18S")]
        [TestCase(null, "00:01:18", "", "http://localhost/timespan/00%3A01%3A18")]
        [TestCase("fr-FR", "00:01:18", "P", "http://localhost/timespan/PT1M18S")]
        [TestCase("fr-FR", "00:01:18", "", "http://localhost/timespan/00%3A01%3A18")]
        public void AppendPath_TimeSpanValue(string? culture, TimeSpan value, string format, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/timespan/", false);
            uri.AppendPath(value, format, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, true, "http://localhost/something?bool=true")]
        [TestCase(null, false, "http://localhost/something?bool=false")]
        [TestCase("fr-FR", true, "http://localhost/something?bool=true")]
        [TestCase("fr-FR", false, "http://localhost/something?bool=false")]
        public void AppendQuery_BoolValue(string? culture, bool value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something", false);
            uri.AppendQuery("bool", value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 42, "http://localhost/something?int=42")]
        [TestCase(null, -42, "http://localhost/something?int=-42")]
        [TestCase("fr-FR", 42, "http://localhost/something?int=42")]
        [TestCase("fr-FR", -42, "http://localhost/something?int=-42")]
        public void AppendQuery_IntValue(string? culture, int value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("int", value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 299792458, "http://localhost/something?long=299792458")]
        [TestCase(null, -299792458, "http://localhost/something?long=-299792458")]
        [TestCase("fr-FR", 299792458, "http://localhost/something?long=299792458")]
        [TestCase("fr-FR", -299792458, "http://localhost/something?long=-299792458")]
        public void AppendQuery_LongValue(string? culture, long value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("long", value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 3.14f, "http://localhost/something?float=3.14")]
        [TestCase(null, -3.14f, "http://localhost/something?float=-3.14")]
        [TestCase("fr-FR", 3.14f, "http://localhost/something?float=3.14")]
        [TestCase("fr-FR", -3.14f, "http://localhost/something?float=-3.14")]
        public void AppendQuery_FloatValue(string? culture, float value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("float", value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, 3.14, "http://localhost/something?double=3.14")]
        [TestCase(null, -3.14, "http://localhost/something?double=-3.14")]
        [TestCase("fr-FR", 3.14, "http://localhost/something?double=3.14")]
        [TestCase("fr-FR", -3.14, "http://localhost/something?double=-3.14")]
        public void AppendQuery_DoubleValue(string? culture, double value, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("double", value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new byte[] { 1, 2, 3 }, "D", "http://localhost/something?bytes=AQID")]
        [TestCase(null, new byte[] { 4, 5, 6 }, "U", "http://localhost/something?bytes=BAUG")]
        [TestCase("fr-FR", new byte[] { 1, 2, 3 }, "D", "http://localhost/something?bytes=AQID")]
        [TestCase("fr-FR", new byte[] { 4, 5, 6 }, "U", "http://localhost/something?bytes=BAUG")]
        public void AppendQuery_BytesValue(string? culture, byte[] value, string format, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("bytes", value, format, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, "2021-11-18T10:11:12Z", "D", "http://localhost/something?datetime=2021-11-18")]
        [TestCase(null, "2022-12-19T11:12:12Z", "O", "http://localhost/something?datetime=2022-12-19T11%3A12%3A12.0000000Z")]
        [TestCase(null, "2022-12-19T11:12:12Z", "U", "http://localhost/something?datetime=1671448332")]
        [TestCase("fr-FR", "2021-11-18T10:11:12Z", "D", "http://localhost/something?datetime=2021-11-18")]
        [TestCase("fr-FR", "2022-12-19T11:12:12Z", "O", "http://localhost/something?datetime=2022-12-19T11%3A12%3A12.0000000Z")]
        [TestCase("fr-FR", "2022-12-19T11:12:12Z", "U", "http://localhost/something?datetime=1671448332")]
        public void AppendQuery_DateTimeOffsetValue(string? culture, string dateString, string format, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var value = DateTimeOffset.Parse(dateString);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("datetime", value, format, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, "00:01:18", "http://localhost/something?timespan=PT1M18S")]
        [TestCase("fr-FR", "00:01:18", "http://localhost/something?timespan=PT1M18S")]
        public void AppendQuery_TimeSpanValue(string? culture, string timeString, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var value = TimeSpan.Parse(timeString);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQuery("timespan", value, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new int[] { 42, -42 }, ",", "http://localhost/something?int=42%2C-42")]
        [TestCase(null, new int[] { 42, -42 }, " ", "http://localhost/something?int=42 -42")]
        [TestCase(null, new int[] { 42, -42 }, "|", "http://localhost/something?int=42|-42")]
        [TestCase("fr-FR", new int[] { 42, -42 }, ",", "http://localhost/something?int=42%2C-42")]
        [TestCase("fr-FR", new int[] { 42, -42 }, " ", "http://localhost/something?int=42 -42")]
        [TestCase("fr-FR", new int[] { 42, -42 }, "|", "http://localhost/something?int=42|-42")]
        public void AppendQueryDelimited_IntValue(string? culture, int[] value, string delimiter, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQueryDelimited("int", value, delimiter, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new long[] { 299792458, -299792458 }, ",", "http://localhost/something?long=299792458%2C-299792458")]
        [TestCase(null, new long[] { 299792458, -299792458 }, " ", "http://localhost/something?long=299792458 -299792458")]
        [TestCase(null, new long[] { 299792458, -299792458 }, "|", "http://localhost/something?long=299792458|-299792458")]
        [TestCase("fr-FR", new long[] { 299792458, -299792458 }, ",", "http://localhost/something?long=299792458%2C-299792458")]
        [TestCase("fr-FR", new long[] { 299792458, -299792458 }, " ", "http://localhost/something?long=299792458 -299792458")]
        [TestCase("fr-FR", new long[] { 299792458, -299792458 }, "|", "http://localhost/something?long=299792458|-299792458")]
        public void AppendQueryDelimited_LongValue(string? culture, long[] value, string delimiter, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQueryDelimited("long", value, delimiter, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new float[] { 3.14f, -3.14f }, ",", "http://localhost/something?float=3.14%2C-3.14")]
        [TestCase(null, new float[] { 3.14f, -3.14f }, " ", "http://localhost/something?float=3.14 -3.14")]
        [TestCase(null, new float[] { 3.14f, -3.14f }, "|", "http://localhost/something?float=3.14|-3.14")]
        [TestCase("fr-FR", new float[] { 3.14f, -3.14f }, ",", "http://localhost/something?float=3.14%2C-3.14")]
        [TestCase("fr-FR", new float[] { 3.14f, -3.14f }, " ", "http://localhost/something?float=3.14 -3.14")]
        [TestCase("fr-FR", new float[] { 3.14f, -3.14f }, "|", "http://localhost/something?float=3.14|-3.14")]
        public void AppendQueryDelimited_FloatValue(string? culture, float[] value, string delimiter, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQueryDelimited("float", value, delimiter, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }

        [TestCase(null, new double[] { 3.14, -3.14 }, ",", "http://localhost/something?double=3.14%2C-3.14")]
        [TestCase(null, new double[] { 3.14, -3.14 }, " ", "http://localhost/something?double=3.14 -3.14")]
        [TestCase(null, new double[] { 3.14, -3.14 }, "|", "http://localhost/something?double=3.14|-3.14")]
        [TestCase("fr-FR", new double[] { 3.14, -3.14 }, ",", "http://localhost/something?double=3.14%2C-3.14")]
        [TestCase("fr-FR", new double[] { 3.14, -3.14 }, " ", "http://localhost/something?double=3.14 -3.14")]
        [TestCase("fr-FR", new double[] { 3.14, -3.14 }, "|", "http://localhost/something?double=3.14|-3.14")]
        public void AppendQueryDelimited_DoubleValue(string? culture, double[] value, string delimiter, string expected)
        {
            if (culture != null)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("something");
            uri.AppendQueryDelimited("double", value, delimiter, true);

            Assert.AreEqual(expected, uri.ToUri().ToString());
        }
    }
}
