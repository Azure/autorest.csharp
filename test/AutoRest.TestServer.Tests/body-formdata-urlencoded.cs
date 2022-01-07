// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Body_Formdata_Urlencoded;
using Body_Formdata_Urlencoded.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyFormdataUrlEncodedTests : TestServerTestBase
    {
        [Test]
        public Task UpdatePetWithForm() => TestStatus(async (host, pipeline) =>
            await new FormdataurlencodedClient(ClientDiagnostics, pipeline, host)
                .UpdatePetWithFormAsync(1, PetType.Dog, "meat", 42, "Fido"));
    }
}
