// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest;
using NUnit.Framework;
using OpenAI;

namespace OpenAI.Tests
{
    public partial class AudioTranslationsTests
    {
        [Test]
        public void SmokeTest()
        {
            KeyCredential credential = new KeyCredential(Environment.GetEnvironmentVariable("OpenAIClient_KEY"));
            AudioTranslations client = new OpenAIClient(credential).GetAudioClient().GetAudioTranslationsClient();
            Assert.IsNotNull(client);
        }
    }
}
