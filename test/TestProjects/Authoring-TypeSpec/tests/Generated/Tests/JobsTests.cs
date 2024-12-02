// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using AuthoringTypeSpec.Models;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace AuthoringTypeSpec.Tests
{
    public partial class JobsTests : AuthoringTypeSpecTestBase
    {
        public JobsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeploymentJob_GetDeploymentStatus_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response response = await client.GetDeploymentStatusAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeploymentJob_GetDeploymentStatus_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response<DeploymentJob> response = await client.GetDeploymentStatusValueAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeploymentJob_GetDeploymentStatus_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response response = await client.GetDeploymentStatusAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeploymentJob_GetDeploymentStatus_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response<DeploymentJob> response = await client.GetDeploymentStatusValueAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SwapDeploymentsJob_GetSwapDeploymentsStatus_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response response = await client.GetSwapDeploymentsStatusAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SwapDeploymentsJob_GetSwapDeploymentsStatus_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response<SwapDeploymentsJob> response = await client.GetSwapDeploymentsStatusValueAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SwapDeploymentsJob_GetSwapDeploymentsStatus_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response response = await client.GetSwapDeploymentsStatusAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SwapDeploymentsJob_GetSwapDeploymentsStatus_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            Jobs client = CreateAuthoringTypeSpecClient(endpoint).GetJobsClient(apiVersion: "2022-05-15-preview");

            Response<SwapDeploymentsJob> response = await client.GetSwapDeploymentsStatusValueAsync("<projectName>", "<deploymentName>", "<jobId>");
        }
    }
}
