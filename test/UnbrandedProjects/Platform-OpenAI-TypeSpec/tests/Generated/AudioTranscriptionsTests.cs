// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest;
using NUnit.Framework;
using OpenAI;

namespace OpenAI.Tests
{
    public partial class AudioTranscriptionsTests
    {
        [Test]
        public void SmokeTest()
        {
            KeyCredential credential = new KeyCredential(Environment.GetEnvironmentVariable("OpenAIClient_KEY"));
            AudioTranscriptions client = new OpenAIClient(credential).GetAudioClient().GetAudioTranscriptionsClient();
            Assert.IsNotNull(client);
        }
    }
}
