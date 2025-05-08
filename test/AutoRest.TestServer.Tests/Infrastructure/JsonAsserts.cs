using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    internal static class JsonAsserts
    {
        public static void AssertWireSerialization<T>(string expected, IJsonModel<T> serializable)
        {
            var text = ModelReaderWriter.Write(serializable);

            Assert.AreEqual(expected, text.ToString());
        }

        public static void AssertWireSerialization(string expected, object serializable)
        {
            var text = ModelReaderWriter.Write(serializable);

            Assert.AreEqual(expected, text.ToString());
        }

        public static JsonElement AssertWireSerializes<T>(IJsonModel<T> serializable)
        {
            var data = ModelReaderWriter.Write(serializable);

            return JsonDocument.Parse(data).RootElement;
        }
    }
}
