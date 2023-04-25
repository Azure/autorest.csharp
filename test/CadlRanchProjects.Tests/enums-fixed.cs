using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Enums.Fixed;
using Enums.Fixed.Models;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class EnumsFixedTests : CadlRanchTestBase
    {
        [Test]
        public Task Enums_Fixed_String_getKnownValue() => Test(async (host) =>
        {
            var response = await new FixedClient(host, null).GetKnownValueAsync();
            Assert.AreEqual(DaysOfWeekEnum.Monday, (DaysOfWeekEnum)response);
        });

        [Test]
        public Task Enums_Fixed_String_putKnownValue() => Test(async (host) =>
        {
            var response = await new FixedClient(host, null).PutKnownValueAsync(DaysOfWeekEnum.Monday);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Enums_Fixed_String_putUnknownValue() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(() => new FixedClient(host, null).PutUnknownValueAsync(BinaryData.FromObjectAsJson("Weekend")));
            Assert.AreEqual(500, exception.Status);
            return Task.CompletedTask;
        });
    }
}
