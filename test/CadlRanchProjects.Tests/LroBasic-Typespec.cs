// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using LroBasicCadl;
using NUnit.Framework;
using Azure;
using LroBasicCadl.Models;
using System.Net;

namespace CadlRanchProjects.Tests
{
    /// <summary>
    /// End-to-end test cases for `lro-basic-cadl` test project.
    /// </summary>
    public class LroBasicCadlTests : CadlRanchMockApiTestBase
    {
        //[Test]
        //public Task LroBasic_CreateProject() => Test(async (host) =>
        //{
        //    Project project = new(null, "foo", "bar");
        //    var operation = await new LroBasicCadlClient(host).CreateProjectAsync(WaitUntil.Completed, project);
        //    Assert.IsTrue(operation.HasCompleted);
        //    Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
        //});

        //[Test]
        //public Task LroBasic_CreateProjectWaitForCompletion() => Test(async (host) =>
        //{
        //    Project project = new(null, "foo", "bar");
        //    var operation = await new LroBasicCadlClient(host).CreateProjectAsync(WaitUntil.Started, project);
        //    Assert.IsFalse(operation.HasCompleted);
        //    Assert.AreEqual(((int)HttpStatusCode.Accepted), operation.GetRawResponse().Status);

        //    await operation.WaitForCompletionResponseAsync();
        //    Assert.IsTrue(operation.HasCompleted);
        //    Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
        //});

        [Test]
        public Task LroBasic_UpdateProject() => Test(async (host) =>
        {
            Project project = new("123", "test", "test");
            var operation = await new LroBasicCadlClient(host).UpdateProjectAsync(WaitUntil.Started, "123", project);
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
            var result = operation.Value;
            Assert.AreEqual(project.Id, result.Id);
            Assert.AreEqual(project.Name, result.Name);
            Assert.AreEqual(project.Description, result.Description);
        });

        [Test]
        public Task LroBasic_UpdateProjectWaitForCompletion() => Test(async (host) =>
        {
            Project project = new("123", "test", "test");
            var operation = await new LroBasicCadlClient(host).UpdateProjectAsync(WaitUntil.Started, "123", project);
            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(((int)HttpStatusCode.Created), operation.GetRawResponse().Status);

            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);

            var result = operation.Value;
            Assert.AreEqual(project.Id, result.Id);
            Assert.AreEqual(project.Name, result.Name);
            Assert.AreEqual(project.Description, result.Description);
        });
    }
}
