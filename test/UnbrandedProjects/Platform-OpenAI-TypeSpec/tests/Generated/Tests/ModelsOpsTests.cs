// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using NUnit.Framework;

namespace OpenAI.Tests
{
    public partial class ModelsOpsTests
    {
        [Test]
        [Ignore("Compilation test only")]
        public void SmokeTest()
        {
            ApiKeyCredential credential = new ApiKeyCredential(Environment.GetEnvironmentVariable("OpenAIClient_KEY"));
            ModelsOps client = new OpenAIClient(credential).GetModelsOpsClient();
            Assert.IsNotNull(client);
        }
    }
}
