// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_formdata_urlencoded;
using body_formdata_urlencoded.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyFormdataUrlEncodedTests : TestServerTestBase
    {
        public BodyFormdataUrlEncodedTests(TestServerVersion version) : base(version, "formsdataurlencoded") { }

        private static MemoryStream MakeStream(string text)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(text));
        }

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task UpdatePetWithForm() => Test(async (host, pipeline) =>
        {
            var client = new FormdataurlencodedClient(ClientDiagnostics, pipeline, host);

            var output = await client.UpdatePetWithFormAsync(1, PostContentSchemaPetType.Dog, "meat", 42, "Fido");
            Console.WriteLine(output.ToString());
        });
    }
}
