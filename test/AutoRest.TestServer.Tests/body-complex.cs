﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using body_complex;
using body_complex.Models.V20160229;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyComplexTest: TestServerTestBase
    {
        [Test]
        public Task GetValid() => Test("complex_basic_valid", async (host, pipeline) =>
        {
            var result = await BasicOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("abc", result.Value.Name);
            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual(CMYKColors.YELLOW, result.Value.Color);
        });

        [Test]
        public Task PutValid() => Test("complex_basic_valid", async (host, pipeline) =>
        {
            var basic = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.Magenta
            };
            var result = await BasicOperations.PutValidAsync(ClientDiagnostics, pipeline, basic, host);
            Assert.AreEqual(200, result.Status);
        });
    }
}
