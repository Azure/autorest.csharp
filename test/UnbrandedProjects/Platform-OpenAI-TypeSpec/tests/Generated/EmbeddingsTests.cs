// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using NUnit.Framework;
using OpenAI;

namespace OpenAI.Tests
{
    public partial class EmbeddingsTests
    {
        [Test]
        public void SmokeTest()
        {
            KeyCredential credential = new KeyCredential(Environment.GetEnvironmentVariable("OpenAIClient_KEY"));
            Embeddings client = new OpenAIClient(credential).GetEmbeddingsClient();
            Assert.IsNotNull(client);
        }
    }
}
