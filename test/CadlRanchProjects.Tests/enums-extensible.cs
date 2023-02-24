// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Enums.Extensible;
using Enums.Extensible.Models;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class EnumsExtensibleTests : CadlRanchTestBase
    {
        [Test]
        public Task Enums_Extensible_String_getKnownValue() => Test(async (host) =>
        {
            Response response = await new ExtensibleClient(host, null).GetKnownValueAsync();
            JsonData result = JsonData.FromBytes(response.Content.ToMemory());
            Assert.AreEqual(DaysOfWeekExtensibleEnum.Monday, new DaysOfWeekExtensibleEnum((string)result));
        });

        [Test]
        public Task Enums_Extensible_String_putKnownValue() => Test(async (host) =>
        {
            Response response = await new ExtensibleClient(host, null).GetUnknownValueAsync();
            JsonData result = JsonData.FromBytes(response.Content.ToMemory());
            Assert.AreEqual(new DaysOfWeekExtensibleEnum("Weekend"), new DaysOfWeekExtensibleEnum((string)result));
        });

        [Test]
        public Task Enums_Extensible_String_getUnknownValue() => Test(async (host) =>
        {
            Response response = await new ExtensibleClient(host, null).PutKnownValueAsync(RequestContent.Create(new JsonData(DaysOfWeekExtensibleEnum.Monday.ToString())));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Enums_Extensible_String_putUnknownValue() => Test(async (host) =>
        {
            Response response = await new ExtensibleClient(host, null).PutUnknownValueAsync(RequestContent.Create(new JsonData(new DaysOfWeekExtensibleEnum("Weekend").ToString())));
            Assert.AreEqual(204, response.Status);
        });
    }
}
