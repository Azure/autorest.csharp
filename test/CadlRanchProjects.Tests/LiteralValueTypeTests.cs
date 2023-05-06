// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using TypeSpecFirstTest.Models;
using TypeSpecFirstTest;
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
            Thing result = await new TypeSpecFirstTestClient(host).CreateLiteralAsync(new Thing("test", "test", "abc"));
            Assert.AreEqual("literal", result.Name);
            Assert.AreEqual("union", result.RequiredUnion);
            Assert.AreEqual("def", result.RequiredBadDescription);
            // the type of the following properties are literal types, but if the server returns different value (for instance there is a service update but the SDK does not update, they are actually no longer literal types)
            // but nevertheless, the SDK should still be able to get the new values
            Assert.AreEqual("reject", result.RequiredLiteralString);
            Assert.AreEqual(12345, result.RequiredLiteralInt);
            Assert.AreEqual(123.45, result.RequiredLiteralDouble);
            Assert.AreEqual(true, result.RequiredLiteralBool);
            Assert.AreEqual("accept", result.OptionalLiteralString);
            Assert.AreEqual(12345, result.OptionalLiteralInt);
            Assert.AreEqual(123.45, result.OptionalLiteralDouble);
            Assert.AreEqual(false, result.OptionalLiteralBool);
        });

    }

}
