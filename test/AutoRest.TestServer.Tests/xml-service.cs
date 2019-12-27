// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    }
}
