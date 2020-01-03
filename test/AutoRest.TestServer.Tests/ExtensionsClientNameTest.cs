// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using extension_client_name;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ExtensionsClientNameTest
    {
        [Test]
        public void ParametersAreRenamed()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(AllOperations), "OriginalOperationAsync");
            // TODO: Add more tests here
            TypeAsserts.HasParameter(method, "renamedBodyParameter");
        }
    }
}
