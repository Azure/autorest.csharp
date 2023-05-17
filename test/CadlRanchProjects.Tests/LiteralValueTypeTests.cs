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
            Thing result = await new TypeSpecFirstTestClient(host).CreateLiteralAsync(new Thing("test", "test", "abc")
            {
                OptionalLiteralString = ThingOptionalLiteralString.Reject,
                OptionalLiteralInt = ThingOptionalLiteralInt._456,
                OptionalLiteralDouble = ThingOptionalLiteralDouble._456,
                OptionalLiteralBool = true,
            });
            Assert.AreEqual("literal", result.Name);
            Assert.AreEqual("union", result.RequiredUnion);
            Assert.AreEqual("def", result.RequiredBadDescription);
            // the type of the following properties are literal types, but if the server returns different value (for instance there is a service update but the SDK does not update, they are actually no longer literal types)
            // but nevertheless, the SDK should still be able to get the new values
            Assert.AreEqual(new ThingRequiredLiteralString("reject"), result.RequiredLiteralString);
            Assert.AreEqual(new ThingRequiredLiteralInt(12345), result.RequiredLiteralInt);
            Assert.AreEqual(new ThingRequiredLiteralDouble(123.45f), result.RequiredLiteralDouble);
            Assert.AreEqual(true, result.RequiredLiteralBool);
            Assert.AreEqual(new ThingOptionalLiteralString("accept"), result.OptionalLiteralString);
            Assert.AreEqual(new ThingOptionalLiteralInt(12345), result.OptionalLiteralInt);
            Assert.AreEqual(new ThingOptionalLiteralDouble(123.45f), result.OptionalLiteralDouble);
            Assert.AreEqual(false, result.OptionalLiteralBool);
        });
    }
}
