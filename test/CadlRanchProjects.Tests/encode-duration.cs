using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Encode.Duration;
using Encode.Duration.Models;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class EncodeDurationTests : CadlRanchTestBase
    {
        [Test]
        public Task Encode_Duration_Property_Default() => Test(async (host) =>
        {
            var data = new
            {
                value = "P40D",
            };
            Response response = await new DurationClient(host, null).GetPropertyClient().DefaultAsync(RequestContent.Create(data));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("P40D", result.GetProperty("value").ToString());
        });

        [Test]
        public Task Encode_Duration_Property_Default_Convenience() => Test(async (host) =>
        {
            var body = new DefaultDurationProperty(new TimeSpan(40, 0, 0, 0));
            Response<DefaultDurationProperty> response = await new DurationClient(host, null).GetPropertyClient().DefaultAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [Test]
        public Task Encode_Duration_Property_ISO8601() => Test(async (host) =>
        {
            var data = new
            {
                value = "P40D",
            };
            Response response = await new DurationClient(host, null).GetPropertyClient().Iso8601Async(RequestContent.Create(data));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("P40D", result.GetProperty("value").ToString());
        });

        [Test]
        public Task Encode_Duration_Property_ISO8601_Convenience() => Test(async (host) =>
        {
            var body = new ISO8601DurationProperty(new TimeSpan(40, 0, 0, 0));
            Response<ISO8601DurationProperty> response = await new DurationClient(host, null).GetPropertyClient().Iso8601Async(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [Test]
        public Task Encode_Duration_Property_FloatSeconds() => Test(async (host) =>
        {
            var data = new
            {
                value = 35.621,
            };
            Response response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsAsync(RequestContent.Create(data));
            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("35.621", result.GetProperty("value").ToString());
        });

        [Test]
        public Task Encode_Duration_Property_FloatSeconds_Convenience() => Test(async (host) =>
        {
            var body = new FloatSecondsDurationProperty(TimeSpan.FromSeconds(35.621));
            Response<FloatSecondsDurationProperty> response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [Test]
        public Task Encode_Duration_Query_Default() => Test(async (host) =>
        {
            var input = new TimeSpan(40, 0, 0, 0);
            Response response = await new DurationClient(host, null).GetQueryClient().DefaultAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Encode_Duration_Query_ISO8601() => Test(async (host) =>
        {
            var input = new TimeSpan(40, 0, 0, 0);
            var response = await new DurationClient(host, null).GetQueryClient().Iso8601Async(input);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Encode_Duration_Query_Int32Seconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(36);
            var response = await new DurationClient(host, null).GetQueryClient().Int32SecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Encode_Duration_Query_FloatSeconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(35.621);
            var response = await new DurationClient(host, null).GetQueryClient().FloatSecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });
    }
}
