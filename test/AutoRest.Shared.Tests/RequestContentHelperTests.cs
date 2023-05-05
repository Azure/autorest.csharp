using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestContentHelperTests
    {
        [TestCase(1, 2)]
        [TestCase("a", "b")]
        [TestCase(true, false)]
        public void TestGenericFromDictionary<T>(T expectedValue1, T expectedValue2)
        {
            var expectedDictionary = new Dictionary<string, T>()
            {
                {"k1", expectedValue1 },
                {"k2", expectedValue2 }
            };
            var content = RequestContentHelper.FromDictionary(expectedDictionary);

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 1;
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (typeof(T) == typeof(int))
                {
                    Assert.AreEqual(expectedDictionary["k" + count++], property.Value.GetInt32());
                }
                else if (typeof(T) == typeof(string))
                {
                    Assert.AreEqual(expectedDictionary["k" + count++], property.Value.GetString());
                }
                else if (typeof(T) == typeof(bool))
                {
                    Assert.AreEqual(expectedDictionary["k" + count++], property.Value.GetBoolean());
                }
            }
        }

        [Test]
        public void TestBinaryDataFromDictionary()
        {
            var expectedDictionary = new Dictionary<string, BinaryData>()
            {
                {"k1", new BinaryData(1) },
                {"k2", new BinaryData("\"hello\"") },
                {"k3", null }
            };

            var content = RequestContentHelper.FromDictionary(expectedDictionary);

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 1;
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    Assert.IsNull(expectedDictionary["k" + count++]);
                }
                else
                {
                    Assert.AreEqual(expectedDictionary["k" + count++].ToObjectFromJson(), BinaryData.FromString(property.Value.GetRawText()).ToObjectFromJson());
                }
            }
        }
    }
}
