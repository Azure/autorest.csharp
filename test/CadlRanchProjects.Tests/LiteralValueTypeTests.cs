// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using CadlFirstTest.Models;
using CadlFirstTest;
using System.Threading.Tasks;

namespace CadlRanchProjects.Tests
{
    /// <summary>
    ///  E2E tests for literal value types.
    /// </summary>
    public class LiteralValueTypeTests : CadlRanchMockApiTestBase
    {
        [Test]
        public async Task LiteralModelProperties() => await Test(async (host) =>
        {
            Thing result = await new CadlFirstTestClient(host).CreateLiteralAsync(new Thing("test", "test", "abc"));
            Assert.AreEqual(result.Name, "literal");
            Assert.AreEqual(result.RequiredUnion, "union");
            Assert.AreEqual(result.RequiredBadDescription, "def");
            // the following are stick to literal value, despite the mock server returns different value
            Assert.AreEqual(result.RequiredLiteralString, "accept");
            Assert.AreEqual(result.RequiredLiteralInt, 123);
            Assert.AreEqual(result.RequiredLiteralDouble, 1.23);
            Assert.AreEqual(result.RequiredLiteralBool, false);
            Assert.AreEqual(result.OptionalLiteralString, "reject");
            Assert.AreEqual(result.OptionalLiteralInt, 456);
            Assert.AreEqual(result.OptionalLiteralDouble, 4.56);
            Assert.AreEqual(result.OptionalLiteralBool, true);
        });

    }

}
