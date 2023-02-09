// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Models.Inheritance;
using Models.Inheritance.Models;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class ModelsInheritanceTests : CadlRanchTestBase
    {
        [Test]
        public Task PostValid() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).PostValidAsync(new Siamese("abc", 32, true));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task GetValid() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).GetValidValueAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(32, response.Value.Age);
        });

        [Test]
        public Task PutValid() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).PutValidAsync(new Siamese("def", 11, false));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("def", response.Value.Name);
            Assert.AreEqual(11, response.Value.Age);
            Assert.IsFalse(response.Value.Smart);
        });

        [Test]
        public Task GetModel() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).GetModelValueAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Age);
            Assert.IsInstanceOf<GoblinShark>(response.Value);
        });

        [Test]
        public Task PutModel() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).PutModelAsync(new GoblinShark(1));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task GetRecursiveModel() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).GetRecursiveModelValueAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(1, response.Value.Age);
            Assert.IsInstanceOf<Salmon>(response.Value);
        });

        [Ignore("fix discriminator")]
        [Test]
        public Task PutRecursiveModel() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).PutRecursiveModelAsync(new Salmon(1));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task GetMissingDiscriminator() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).GetMissingDiscriminatorValueAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotInstanceOf<Salmon>(response.Value);
            Assert.IsNotInstanceOf<Shark>(response.Value);
            Assert.AreEqual(1, response.Value.Age);
        });

        [Test]
        public Task GetWrongDiscriminator() => Test(async (host) =>
        {
            var response = await new InheritanceClient(host, null).GetWrongDiscriminatorValueAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotInstanceOf<Salmon>(response.Value);
            Assert.IsNotInstanceOf<Shark>(response.Value);
            Assert.AreEqual(1, response.Value.Age);
        });
    }
}
