// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Scm._Type._Enum.Extensible;
using Scm._Type._Enum.Extensible.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class TypeEnumExtensibleTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task Type_Enum_Extensible_String_getKnownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().GetKnownValueAsync();
            Assert.AreEqual(DaysOfWeekExtensibleEnum.Monday, (DaysOfWeekExtensibleEnum)response);
        });

        [Test]
        public Task Type_Enum_Extensible_String_getUnknownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().GetUnknownValueAsync();
            Assert.AreEqual(new DaysOfWeekExtensibleEnum("Weekend"), (DaysOfWeekExtensibleEnum)response);
        });

        [Test]
        public Task Type_Enum_Extensible_String_putKnownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().PutKnownValueAsync(DaysOfWeekExtensibleEnum.Monday);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Type_Enum_Extensible_String_putUnknownValue() => Test(async (host) =>
        {
            var response = await new ExtensibleClient(host, null).GetStringClient().PutUnknownValueAsync(new DaysOfWeekExtensibleEnum("Weekend"));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
