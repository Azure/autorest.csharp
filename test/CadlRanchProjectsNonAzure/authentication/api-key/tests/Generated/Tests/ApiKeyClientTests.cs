// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using NUnit.Framework;

namespace Scm.Authentication.ApiKey.Tests
{
    public partial class ApiKeyClientTests
    {
        [Test]
        [Ignore("Compilation test only")]
        public void SmokeTest()
        {
            ApiKeyCredential credential = new ApiKeyCredential(Environment.GetEnvironmentVariable("ApiKeyClient_KEY"));
            ApiKeyClient client = new ApiKeyClient(credential);
            Assert.IsNotNull(client);
        }
    }
}
