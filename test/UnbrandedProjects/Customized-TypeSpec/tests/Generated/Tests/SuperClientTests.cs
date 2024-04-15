// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using CustomizedTypeSpec.Models;
using NUnit.Framework;

namespace CustomizedTypeSpec.Tests
{
    public partial class SuperClientTests
    {
        [Test]
        [Ignore("Compilation test only")]
        public void SmokeTest()
        {
            Uri endpoint = new Uri("https://my-service.com");
            ApiKeyCredential credential = new ApiKeyCredential(Environment.GetEnvironmentVariable("SuperClient_KEY"));
            SuperClient client = new SuperClient(endpoint, credential);
            Assert.IsNotNull(client);
        }
    }
}
