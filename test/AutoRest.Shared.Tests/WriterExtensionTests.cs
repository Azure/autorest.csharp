// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class WriterExtensionTests
    {
        private static object[] ObjectCases =
        {
            new object[] { null },
            new object[] { new byte[] { 1, 2, 3, 4} },
            new object[] { 42 },
            new object[] { 42.0m, },
            new object[] { 42.0d },
            new object[] { 42.0f },
            new object[] { 42L },
            new object[] { "asdf" },
            new object[] { false },
            new object[] { Guid.NewGuid() },
            new object[] { new BinaryData (new byte[] { 1, 2, 3, 4}) },
            new object[] { new DateTimeOffset (2001, 1, 1, 1, 1, 1, 1, new TimeSpan ()) },
            new object[] { DateTime.Now },
            new object[] { (IEnumerable<object>)new List<object>() { 1, 2, 3, 4 } },
            new object[] { (IEnumerable<KeyValuePair<string, object>>)new List<KeyValuePair<string, object>>() {
                KeyValuePair.Create<string, object> ("a", (object)1),
                KeyValuePair.Create<string, object> ("b", (object)2),
                KeyValuePair.Create<string, object> ("c", (object)3),
                KeyValuePair.Create<string, object> ("d", (object)4),
            }},
        };

        [Test, TestCaseSource("ObjectCases")]
        public static void WriteObjectValue (object value)
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);
            writer.WriteObjectValue (value);
        }

        [Test]
        public static void WriteObjectValueJsonElement ()
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);

            string json = @"{""TablesToMove"": [{""TableName"":""TestTable""}]}";
            Dictionary<string, object> content = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            JsonElement element = (JsonElement)content["TablesToMove"];
            writer.WriteObjectValue (element);
        }

        [Test]
        public static void WriteObjectValueIUtf8JsonSerializable ()
        {
            using MemoryStream stream = new MemoryStream ();
            using Utf8JsonWriter writer = new Utf8JsonWriter (stream);

            var content = new TestSerialize ();
            writer.WriteObjectValue (content);
            Assert.True (content.didWrite);
        }

        internal class TestSerialize : IUtf8JsonSerializable
        {
            internal bool didWrite = false;

            public void Write(Utf8JsonWriter writer)
            {
                didWrite = true;
            }
        }
    }
}