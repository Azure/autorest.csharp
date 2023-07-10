// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using FirstTestTypeSpec;
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    /// <summary>
    ///  E2E tests for literal value types.
    /// </summary>
    public class FirstTestTypeSpecTests : CadlRanchMockApiTestBase
    {
        [Test]
        public async Task FirstTest_CreateLiteral() => await Test(async (host) =>
        {
            Thing result = await new FirstTestTypeSpecClient(host).CreateLiteralAsync(new Thing("test", "test", "abc")
            {
                OptionalLiteralString = ThingOptionalLiteralString.Reject,
                OptionalLiteralInt = ThingOptionalLiteralInt._456,
                OptionalLiteralFloat = ThingOptionalLiteralFloat._456,
                OptionalLiteralBool = true,
            });
            Assert.AreEqual("literal", result.Name);
            Assert.AreEqual("union", result.RequiredUnion);
            Assert.AreEqual("def", result.RequiredBadDescription);
            // the type of the following properties are literal types, but if the server returns different value (for instance there is a service update but the SDK does not update, they are actually no longer literal types)
            // but nevertheless, the SDK should still be able to get the new values
            Assert.AreEqual(new ThingRequiredLiteralString("reject"), result.RequiredLiteralString);
            Assert.AreEqual(new ThingRequiredLiteralInt(12345), result.RequiredLiteralInt);
            Assert.AreEqual(new ThingRequiredLiteralFloat(123.45f), result.RequiredLiteralFloat);
            Assert.AreEqual(true, result.RequiredLiteralBool);
            Assert.AreEqual(new ThingOptionalLiteralString("accept"), result.OptionalLiteralString);
            Assert.AreEqual(new ThingOptionalLiteralInt(12345), result.OptionalLiteralInt);
            Assert.AreEqual(new ThingOptionalLiteralFloat(123.45f), result.OptionalLiteralFloat);
            Assert.AreEqual(false, result.OptionalLiteralBool);
        });
    }
}
