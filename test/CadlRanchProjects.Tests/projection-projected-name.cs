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
    public class ProjectionProjectedNameTests : CadlRanchTestBase
    {
        [Test]
        public Task Projection_ProjectedName_Property_json() => Test(async (host) =>
        {
            Project project = new Project()
            {
                ProducedBy = "DPG",
            };
            Response response = await new ProjectedNameClient(host, null).JsonProjectionAsync(project);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Projection_ProjectedName_Property_client() => Test(async (host) =>
        {
            Project project = new Project()
            {
                CreatedBy = "DPG",
            };
            Response response = await new ProjectedNameClient(host, null).ClientProjectionAsync(project);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Projection_ProjectedName_Property_language() => Test(async (host) =>
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
