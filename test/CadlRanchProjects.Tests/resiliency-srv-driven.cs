// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Resiliency.ServiceDriven;

namespace CadlRanchProjects.Tests
{
    public class resiliency_srv_driven : CadlRanchTestBase
    {
        [Test]
        public Task Service_Driven_AddOperation() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2").AddOperationAsync();
            Assert.AreEqual(204, resopnse.Status);
        });

        [Test]
        public Task Service_Driven_AddOptionalParam_FromNone_NewVersion() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2").FromNoneAsync("new");
            Assert.AreEqual(204, resopnse.Status);
        });

        [Test]
        public Task Service_Driven_AddOptionalParam_FromNone_OldVersion() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2", new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1)).FromNoneAsync();
            Assert.AreEqual(204, resopnse.Status);
        });

        [Test]
        public Task Service_Driven_AddOptionalParam_FromOneRequired_NewVersion() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2").FromOneRequiredAsync("required", "new");
            Assert.AreEqual(204, resopnse.Status);
        });

        [Test]
        public Task Service_Driven_AddOptionalParam_FromOneRequired_OldVersion() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2", new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1)).FromOneRequiredAsync("required");
            Assert.AreEqual(204, resopnse.Status);
        });

        [Test]
        public Task Service_Driven_AddOptionalParam_FromOneOptional_NewVersion() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2").FromOneOptionalAsync("optional", "new");
            Assert.AreEqual(204, resopnse.Status);
        });

        [Test]
        public Task Service_Driven_AddOptionalParam_FromOneOptional_OldVersion() => Test(async (host) =>
        {
            var resopnse = await new ResiliencyServiceDrivenClient(host, "v2", new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1)).FromOneOptionalAsync("optional");
            Assert.AreEqual(204, resopnse.Status);
        });
    }
}
