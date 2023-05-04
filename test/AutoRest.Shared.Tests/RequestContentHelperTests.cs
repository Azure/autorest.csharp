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
        [Test]
        public void TestGenericFromDictionary()
        {
            var content = RequestContentHelper.FromDictionary(new Dictionary<string, int>()
            {
                {"k1", 1 },
                {"k2", 2 }
            });

            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;

            var document = JsonDocument.Parse(stream);
            int count = 1;
            foreach (var property in document.RootElement.EnumerateObject())
            {
                Assert.AreEqual(count++, property.Value.GetInt32());
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
