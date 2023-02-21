// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using ProjectedName;
using ProjectedName.Models;

namespace CadlRanchProjects.Tests
{
    public class ProjectionTests : CadlRanchTestBase
    {
        [Test]
        public Task ProjectedName_jsonProjection() => Test(async (host) =>
        {
            Project project = new Project()
            {
                ProducedBy = "DPG",
            };
            Response response = await new ProjectedNameClient(host, null).JsonProjectionAsync(project);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task ProjectedName_clientProjection() => Test(async (host) =>
        {
            Project project = new Project()
            {
                CreatedBy = "DPG",
            };
            Response response = await new ProjectedNameClient(host, null).ClientProjectionAsync(project);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task ProjectedName_languageProjection() => Test(async (host) =>
        {
            Project project = new Project()
            {
                MadeForCS = "customers"
            };
            Response response = await new ProjectedNameClient(host, null).LanguageProjectionAsync(project);
            Assert.AreEqual(204, response.Status);
        });
    }
}
