﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            var response = await new ExtensibleClient(host, null).GetKnownValueValueAsync();
            Assert.AreEqual(DaysOfWeekExtensibleEnum.Monday, (DaysOfWeekExtensibleEnum)response);
        });

        [Test]
        public Task Enums_Extensible_String_putKnownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetUnknownValueValueAsync();
            Assert.AreEqual(new DaysOfWeekExtensibleEnum("Weekend"), (DaysOfWeekExtensibleEnum)response);
        });

        [Test]
        public Task Enums_Extensible_String_getUnknownValue() => Test(async (host) =>
        {
            Response response = await new ExtensibleClient(host, null).PutKnownValueAsync(DaysOfWeekExtensibleEnum.Monday);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Enums_Extensible_String_putUnknownValue() => Test(async (host) =>
        {
            Response response = await new ExtensibleClient(host, null).PutUnknownValueAsync(new DaysOfWeekExtensibleEnum("Weekend"));
            Assert.AreEqual(204, response.Status);
        });
    }
}
