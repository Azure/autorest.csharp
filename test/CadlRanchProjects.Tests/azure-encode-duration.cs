using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Specs_.Azure.Encode.Duration;
using _Specs_.Azure.Encode.Duration.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureEncodeDurationTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Encode_Duration() => Test(async (host) =>
        {
            var request = new DurationModel(new TimeSpan(1, 2, 59, 59, 500));
            var response = await new DurationClient(host, null).DurationConstantAsync(request);
            Assert.AreEqual(204, response.Status);
        });
    }
}
