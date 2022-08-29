// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using srv_driven2_cadl;

namespace CadlRanchProjects.Tests
{
    public class srv_driven_2 : srv_driven_1
    {
        [Test]
        [Description("Test for v2 client HEAD request that adds an optional query parameter from v1 which has no query parameters")]
        public Task DpgAddOptionalInput_NoParams_V2() => Test(async (host) => await DpgAddOptionalInput_NoParams(host), new[] { TestServerType.CadlRanch });

        internal override async Task DpgAddOptionalInput_NoParams(Uri host)
        {
            // compatible with dpg_initial
            await base.DpgAddOptionalInput_NoParams(host);

            // test new cases in dpg_update1
            var result3 = await new ParamsClient(host, null).HeadNoParamsAsync("newParam");
            Assert.IsEmpty(result3.Content.ToArray());
            Assert.AreEqual(200, result3.Status);
            Assert.AreEqual(123, result3.Headers.ContentLength);

            var result4 = await new ParamsClient(host, null).HeadNoParamsAsync("newParam", new Azure.RequestContext());
            Assert.IsEmpty(result4.Content.ToArray());
            Assert.AreEqual(200, result4.Status);
            Assert.AreEqual(123, result4.Headers.ContentLength);
        }

        [Test]
        [Description("Test for v2 client GET request that adds an optional query parameter from v1 which has one required query parameter")]
        public Task DpgAddOptionalInput_V2() => Test(async (host) => await DpgAddOptionalInput(host), new[] { TestServerType.CadlRanch });

        internal override async Task DpgAddOptionalInput(Uri host)
        {
            // compatible with dpg_initial
            await base.DpgAddOptionalInput(host);

            // test new cases in dpg_update1
            var result4 = await new ParamsClient(host, null).GetRequiredAsync("param", "newParam");
            var responseBody4 = JsonData.FromBytes(result4.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody4["message"]);

            var result5 = await new ParamsClient(host, null).GetRequiredAsync("param", "newParam", default);
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);

            var result6 = await new ParamsClient(host, null).GetRequiredAsync("param", context: default, newParameter: "newParam");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);
        }

        [Test]
        [Description("Test for v2 client PUT request that adds an optional query parameter from v1 which has one required query parameter and one optional parameter")]
        public Task DpgAddOptionalInput_RequiredOptionalParam_V2() => Test(async (host) => await DpgAddOptionalInput_RequiredOptionalParam(host), new[] { TestServerType.CadlRanch });

        internal override async Task DpgAddOptionalInput_RequiredOptionalParam(Uri host)
        {
            // compatible with dpg_initial
            await base.DpgAddOptionalInput_RequiredOptionalParam(host);

            // test new cases in dpg_update1
            var result5 = await new ParamsClient(host, null).PutRequiredOptionalAsync("requiredParam", newParameter: "newParam");
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);

            var result6 = await new ParamsClient(host, null).PutRequiredOptionalAsync("requiredParam", "optionalParam", "newParam");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);

            var result7 = await new ParamsClient(host, null).PutRequiredOptionalAsync("requiredParam", "optionalParam", "newParam", new Azure.RequestContext());
            var responseBody7 = JsonData.FromBytes(result7.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody7["message"]);

            var result8 = await new ParamsClient(host, null).PutRequiredOptionalAsync("requiredParam", newParameter: "newParam", context: new Azure.RequestContext());
            var responseBody8 = JsonData.FromBytes(result8.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody8["message"]);
        }

        [Test]
        [Description("Test for v2 client GET request that adds an optional query parameter from v1 which has one optional query parameter")]
        public Task DpgAddOptionalInput_OptionalParam_V2() => Test(async (host) => await DpgAddOptionalInput_OptionalParam(host), new[] { TestServerType.CadlRanch });

        internal override async Task DpgAddOptionalInput_OptionalParam(Uri host)
        {
            // compatible with dpg_initial
            await base.DpgAddOptionalInput_OptionalParam(host);

            // test new cases in dpg_update1
            var result5 = await new ParamsClient(host, null).GetOptionalAsync(newParameter: "newParam");
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);

            var result6 = await new ParamsClient(host, null).GetOptionalAsync("optionalParam", "newParam");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);

            var result7 = await new ParamsClient(host, null).GetOptionalAsync("optionalParam", "newParam", new Azure.RequestContext());
            var responseBody7 = JsonData.FromBytes(result7.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody7["message"]);

            var result8 = await new ParamsClient(host, null).GetOptionalAsync(newParameter: "newParam", context: new Azure.RequestContext());
            var responseBody8 = JsonData.FromBytes(result8.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody8["message"]);
        }

        [Test]
        [Description("Test for v2 client Delete request that is newly added in an existing path")]
        public Task DpgAddNewOperation_V2() => Test(async (host) =>
        {
            var result = await new ParamsClient( host, null).DeleteParametersAsync();
            Assert.AreEqual(204, result.Status);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        [Description("Test for v2 client GET request that is newly added in a new path")]
        public Task DpgAddNewPath_V2() => Test(async (host) =>
        {
            var result = await new ParamsClient(host, null).GetNewOperationAsync();
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
        }, new[] { TestServerType.CadlRanch });
    }
}
