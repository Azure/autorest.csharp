// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using azure_parameter_grouping;
using azure_parameter_grouping.Models;
using body_integer;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ParameterGroupingTests : TestServerTestBase
    {
        public ParameterGroupingTests(TestServerVersion version) : base(version, "azureParameterGrouping") { }

        [Test]
        public Task PostParameterGroupingMultipleParameterGroups() => TestStatus(async (host, pipeline) =>
        {
            return await new ParameterGroupingClient(ClientDiagnostics, pipeline, host).PostMultiParamGroupsAsync(
                new FirstParameterGroup("header", 21),
                new ParameterGroupingPostMultiParamGroupsSecondParamGroup("header2", 42)
            );
        });

        [Test]
        public Task PostParameterGroupingOptionalParameters() => TestStatus(async (host, pipeline) =>
        {
            return await new ParameterGroupingClient(ClientDiagnostics, pipeline, host).PostOptionalAsync(
                new ParameterGroupingPostOptionalParameters("header", 21)
            );
        });

        [Test]
        public Task PostParameterGroupingRequiredParameters() => TestStatus(async (host, pipeline) =>
        {
            return await new ParameterGroupingClient(ClientDiagnostics, pipeline, host).PostRequiredAsync(
                new ParameterGroupingPostRequiredParameters("header", 21, "path", 1234)
            );
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task PostParameterGroupingSharedParameterGroupObject() => TestStatus(async (host, pipeline) =>
        {
            return await new ParameterGroupingClient(ClientDiagnostics, pipeline, host).PostSharedParameterGroupObjectAsync(
                new FirstParameterGroup("header", null)
            );
        });

    }
}
