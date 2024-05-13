// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FirstTestTypeSpec;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ModelSerializationExtensionTests
    {
        private static object[] ObjectCases =
        {
            new object[] { null, "null" },
            new object[] { new byte[] { 1, 2, 3, 4}, @"""AQIDBA==""" },
            new object[] { 42, "42" },
            new object[] { 42.0m, "42.0" },
            new object[] { 42.0d, "42" },
            new object[] { 42.0f, "42" },
            new object[] { 42L, "42" },
            new object[] { "asdf", @"""asdf""" },
            new object[] { false, "false" },
            new object[] { new Guid ("c6125705-61d7-4cd6-8d6c-f7f247a7a5fa"), @"""c6125705-61d7-4cd6-8d6c-f7f247a7a5fa""" },
            new object[] { new BinaryData (new byte[] { 1, 2, 3, 4}), @"""AQIDBA==""" },
            new object[] { new DateTimeOffset (2001, 1, 1, 1, 1, 1, 1, new TimeSpan ()), @"""2001-01-01T01:01:01.0010000Z""" },
            new object[] { new DateTime (2001, 1, 1, 1, 1, 1, DateTimeKind.Utc), @"""2001-01-01T01:01:01.0000000Z""" },
            new object[] { (IEnumerable<object>)new List<object>() { 1, 2, 3, 4 }, "[1,2,3,4]" },
            new object[] { (IEnumerable<KeyValuePair<string, object>>)new List<KeyValuePair<string, object>>() {
                new KeyValuePair<string, object> ("a", (object)1),
                new KeyValuePair<string, object> ("b", (object)2),
                new KeyValuePair<string, object> ("c", (object)3),
                new KeyValuePair<string, object> ("d", (object)4),
            },
            @"{""a"":1,""b"":2,""c"":3,""d"":4}"
            },
            new object[]
            {
                new Dictionary<string, object>()
                {
                    ["a"] = 1,
                    ["b"] = 2,
                    ["c"] = 3,
                    ["d"] = 4,
                },
                @"{""a"":1,""b"":2,""c"":3,""d"":4}"
            },
        };

        [Test, TestCaseSource(nameof(ObjectCases))]
        public static void WriteObjectValue(object value, string expectedJson)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteObjectValue<object>(value);

            writer.Flush();
            Assert.AreEqual(expectedJson, System.Text.Encoding.UTF8.GetString(stream.ToArray()));
        }

        [Test]
        public static void WriteObjectValueJsonElement()
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            string json = @"{""TablesToMove"": [{""TableName"":""TestTable""}]}";
            Dictionary<string, object> content = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            JsonElement element = (JsonElement)content["TablesToMove"];
            writer.WriteObjectValue<JsonElement>(element);
            writer.Flush();

            Assert.AreEqual(@"[{""TableName"":""TestTable""}]", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
        }

        [Test]
        public static void WriteObjectValueIUtf8JsonSerializable()
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            var content = new TestSerialize();
            writer.WriteObjectValue(content);
            Assert.True(content.didWrite);
        }

        [Test]
        public static void WriteObjectValueIJsonModel()
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            var content = new TestIJsonSerialize();
            writer.WriteObjectValue(content);

            Assert.True(content.didIJsonWrite);
            Assert.IsFalse(content.didUtf8JsonWrite);
        }

        [Test]
        public static void WriteObjectValueNullIUtf8JsonSerializable()
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            TestSerialize content = null;
            writer.WriteObjectValue(content);

            writer.Flush();
            Assert.AreEqual("null", System.Text.Encoding.UTF8.GetString(stream.ToArray()));
        }

        internal class TestSerialize : IUtf8JsonSerializable
        {
            internal bool didWrite = false;

            public void Write(Utf8JsonWriter writer)
            {
                didWrite = true;
            }
        }

        internal class TestIJsonSerialize : IJsonModel<TestIJsonSerialize>, IUtf8JsonSerializable
        {
            internal bool didUtf8JsonWrite = false;
            internal bool didIJsonWrite = false;

            void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
            {
                didUtf8JsonWrite = true;
            }

            TestIJsonSerialize IJsonModel<TestIJsonSerialize>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            TestIJsonSerialize IPersistableModel<TestIJsonSerialize>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            string IPersistableModel<TestIJsonSerialize>.GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            void IJsonModel<TestIJsonSerialize>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                didIJsonWrite = true;
            }

            BinaryData IPersistableModel<TestIJsonSerialize>.Write(ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
