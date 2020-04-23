// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RawRequestUriBuilderTest
    {
        [Theory]
        [TestCase("ht|tp|://", "localhost", null, "http://localhost/")]
        [TestCase("http://|local|host", null, null, "http://localhost/")]
        [TestCase("https://|local|host", null, null, "https://localhost/")]
        [TestCase("http://|local|host", "override", null, "http://override/")]
        [TestCase("http://localhost/with|some|path", null, "/andMore", "http://localhost/withsomepath/andMore")]
        [TestCase("http://localhost|/more|/andMore|/evenMore", null, null, "http://localhost/more/andMore/evenMore")]
        [TestCase("http://localhost|/more/andMore|/evenMore/", null, null, "http://localhost/more/andMore/evenMore/")]
        [TestCase("http://localhost|/more|/andMore|?one=1", null, null, "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost|/more|/andMore?one=1", null, null, "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost/|more?one=1", null, null, "http://localhost/more?one=1")]
        [TestCase("http://localhost|/more?one=1", null, "/andMore", "http://localhost/more/andMore?one=1")]
        [TestCase("http://localhost|/more?one=1|&two=2|&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost/more?one=1&two=2|&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost/more|?one=1&two=2|&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost/more|?one=1|&two=2&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost|/more?one=1&two=2&three=3", null, null, "http://localhost/more?one=1&two=2&three=3")]
        [TestCase("http://localhost|/more?one=&two=&three=", null, null, "http://localhost/more?one=&two=&three=")]
        [TestCase("http://localhost|/more?one&two&three", null, null, "http://localhost/more?one=&two=&three=")]
        public void AppendRawWorks(string rawPart, string host, string pathPart, string expected)
        {
            var builder = new RawRequestUriBuilder();
            foreach (var c in rawPart.Split('|'))
            {
                builder.AppendRaw(c, false);
            }

            if (host != null)
            {
                builder.Host = host;
            }

            if (pathPart != null)
            {
                builder.AppendPath(pathPart, false);
            }

            Assert.AreEqual(expected, builder.ToUri().ToString());
        }
    }
}
