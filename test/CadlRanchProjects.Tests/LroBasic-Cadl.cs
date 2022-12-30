// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using LroBasicCadl;
using NUnit.Framework;
using Azure;
using LroBasicCadl.Models;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace CadlRanchProjects.Tests
{
    /// <summary>
    /// End-to-end test cases for `lro-basic-cadl` test project.
    /// </summary>
    public class LroBasicCadlTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task LroBasic_CreateProject() => Test(async (host) =>
        {
            Project project = new(null, "foo", "bar");
            var operation = await new LroBasicCadlClient(host).CreateProjectAsync(WaitUntil.Completed, project);
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
        });

        [Test]
        public Task LroBasic_CreateProjectWaitForCompletion() => Test(async (host) =>
        {
            Project project = new(null, "foo", "bar");
            var operation = await new LroBasicCadlClient(host).CreateProjectAsync(WaitUntil.Started, project);
            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(((int)HttpStatusCode.Created), operation.GetRawResponse().Status);

            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
        });

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

        // LRO pagination protocol method
        [Test]
        public Task LroBasic_GetLroPaginationProjects() => Test(async (host) =>
        {
            var operation = await new LroBasicCadlClient(host).GetLroPaginationProjectsAsync(WaitUntil.Started);
            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(((int)HttpStatusCode.OK), operation.GetRawResponse().Status);

            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);

            var jsonStrings = new List<string>();
            var result = operation.Value;
            await foreach (var data in result)
            {
                jsonStrings.Add(data.ToString());
            }

            Assert.AreEqual(3, jsonStrings.Count);
            Assert.AreEqual(new string[] {
                "{\"id\":\"1\",\"name\":\"name1\",\"description\":\"description1\"}",
                "{\"id\":\"2\",\"name\":\"name2\",\"description\":\"description2\"}",
                "{\"id\":\"3\",\"name\":\"name3\",\"description\":\"description3\"}"}, jsonStrings);
        });

        // LRO pagination convenience method
        [Test]
        public Task LroBasic_GetLroPaginationProjectValues() => Test(async (host) =>
        {
            var operation = await new LroBasicCadlClient(host).GetLroPaginationProjectValuesAsync(WaitUntil.Started);
            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(((int)HttpStatusCode.OK), operation.GetRawResponse().Status);

            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);

            var projects = new List<Project>();
            var result = operation.Value;
            await foreach (var project in result)
            {
                projects.Add(project);
            };

            Assert.AreEqual(3, projects.Count);
            Assert.AreEqual(new string[] { "1", "2", "3" }, projects.Select(p => p.Id).ToArray());
            Assert.AreEqual(new string[] { "name1", "name2", "name3" }, projects.Select(p => p.Name).ToArray());
            Assert.AreEqual(new string[] { "description1", "description2", "description3" }, projects.Select(p => p.Description).ToArray());
        });
    }
}
