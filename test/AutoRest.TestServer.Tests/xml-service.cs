// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using xml_service;

namespace AutoRest.TestServer.Tests
{
    public class XmlTests : TestServerTestBase
    {
        public XmlTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetSimpleAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetSimpleAsync();
            var value = result.Value;

            Assert.AreEqual("Yours Truly", value.Author);
            Assert.AreEqual("Date of publication", value.Date);
            Assert.AreEqual("Sample Slide Show", value.Title);

            var slides = value.Slides.ToArray();
            Assert.AreEqual(2, slides.Length);

            Assert.AreEqual("Wake up to WonderWidgets!", slides[0].Title);
            Assert.AreEqual("all", slides[0].Type);
            Assert.AreEqual(0, slides[0].Items.Count);

            Assert.AreEqual("Overview", slides[1].Title);
            Assert.AreEqual("all", slides[1].Type);

            var items = slides[1].Items.ToArray();
            Assert.AreEqual("Why WonderWidgets are great", items[0]);
            Assert.AreEqual("", items[1]);
            Assert.AreEqual("Who buys WonderWidgets", items[2]);
        }, true);

        [Test]
        public Task GetComplexTypeRefNoMetaAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetComplexTypeRefNoMetaAsync();
            var value = result.Value;

            Assert.AreEqual("else", value.Something);
            Assert.AreEqual("myid", value.RefToModel.ID);
        }, true);

        [Test]
        public Task GetComplexTypeRefWithMetaAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetComplexTypeRefWithMetaAsync();
            var value = result.Value;

            Assert.AreEqual("else", value.Something);
            Assert.AreEqual("myid", value.RefToModel.ID);
        }, true);

        [Test]
        public Task GetServicePropertiesAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetServicePropertiesAsync();
            var value = result.Value;

            Assert.AreEqual("1.0", value.Logging.Version);
            Assert.AreEqual(true, value.Logging.Delete);
            Assert.AreEqual(false, value.Logging.Read);
            Assert.AreEqual(true, value.Logging.Write);
            Assert.AreEqual(7, value.Logging.RetentionPolicy.Days);
            Assert.AreEqual(true, value.Logging.RetentionPolicy.Enabled);

            Assert.AreEqual("1.0", value.HourMetrics.Version);
            Assert.AreEqual(true, value.HourMetrics.Enabled);
            Assert.AreEqual(false, value.HourMetrics.IncludeAPIs);
            Assert.AreEqual(7, value.HourMetrics.RetentionPolicy.Days);
            Assert.AreEqual(true, value.HourMetrics.RetentionPolicy.Enabled);

            Assert.AreEqual("1.0", value.MinuteMetrics.Version);
            Assert.AreEqual(true, value.MinuteMetrics.Enabled);
            Assert.AreEqual(true, value.MinuteMetrics.IncludeAPIs);
            Assert.AreEqual(7, value.MinuteMetrics.RetentionPolicy.Days);
            Assert.AreEqual(true, value.MinuteMetrics.RetentionPolicy.Enabled);
        }, true);
    }
}
