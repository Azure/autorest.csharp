// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
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
        // removed this test because these APIs are now low confident and we only have protocol method now.
        //[Test]
        //public async Task FirstTest_CreateLiteral() => await Test(async (host) =>
        //{
        //    Thing result = await new FirstTestTypeSpecClient(host).CreateLiteralAsync(new Thing("test", "test", "abc")
        //    {
        //        OptionalLiteralString = ThingOptionalLiteralString.Reject,
        //        OptionalLiteralInt = ThingOptionalLiteralInt._456,
        //        OptionalLiteralFloat = ThingOptionalLiteralFloat._456,
        //        OptionalLiteralBool = true,
        //    });
        //    Assert.AreEqual("literal", result.Name);
        //    Assert.AreEqual("union", result.RequiredUnion);
        //    Assert.AreEqual("def", result.RequiredBadDescription);
        //    // the type of the following properties are literal types, but if the server returns different value (for instance there is a service update but the SDK does not update, they are actually no longer literal types)
        //    // but nevertheless, the SDK should still be able to get the new values
        //    Assert.AreEqual(new ThingRequiredLiteralString("reject"), result.RequiredLiteralString);
        //    Assert.AreEqual(new ThingRequiredLiteralInt(12345), result.RequiredLiteralInt);
        //    Assert.AreEqual(new ThingRequiredLiteralFloat(123.45f), result.RequiredLiteralFloat);
        //    Assert.AreEqual(true, result.RequiredLiteralBool);
        //    Assert.AreEqual(new ThingOptionalLiteralString("accept"), result.OptionalLiteralString);
        //    Assert.AreEqual(new ThingOptionalLiteralInt(12345), result.OptionalLiteralInt);
        //    Assert.AreEqual(new ThingOptionalLiteralFloat(123.45f), result.OptionalLiteralFloat);
        //    Assert.AreEqual(false, result.OptionalLiteralBool);
        //});

        [Test]
        public async Task FirstTest_CreateLiteral() => await Test(async (host) =>
        {
            var data = new
            {
                name = "test",
                requiredUnion = "test",
                requiredBadDescription = "abc",
                requiredLiteralString = "accept",
                requiredLiteralInt = 123,
                requiredLiteralFloat = 1.23,
                requiredLiteralBool = false,
                optionalLiteralString = "reject",
                optionalLiteralInt = 456,
                optionalLiteralFloat = 4.56,
                optionalLiteralBool = true,
            };
            Response response = await new FirstTestTypeSpecClient(host).CreateLiteralAsync(RequestContent.Create(data));
            var result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("literal", result.GetProperty("name").GetString());
            Assert.AreEqual("union", result.GetProperty("requiredUnion").GetString());
            Assert.AreEqual("def", result.GetProperty("requiredBadDescription").GetString());
            // the type of the following properties are literal types, but if the server returns different value (for instance there is a service update but the SDK does not update, they are actually no longer literal types)
            // but nevertheless, the SDK should still be able to get the new values
            Assert.AreEqual("reject", result.GetProperty("requiredLiteralString").GetString());
            Assert.AreEqual(12345, result.GetProperty("requiredLiteralInt").GetInt32());
            Assert.AreEqual(123.45f, result.GetProperty("requiredLiteralFloat").GetSingle());
            Assert.AreEqual(true, result.GetProperty("requiredLiteralBool").GetBoolean());
            Assert.AreEqual("accept", result.GetProperty("optionalLiteralString").GetString());
            Assert.AreEqual(12345, result.GetProperty("optionalLiteralInt").GetInt32());
            Assert.AreEqual(123.45f, result.GetProperty("optionalLiteralFloat").GetSingle());
            Assert.AreEqual(false, result.GetProperty("optionalLiteralBool").GetBoolean());
        });
    }
}
