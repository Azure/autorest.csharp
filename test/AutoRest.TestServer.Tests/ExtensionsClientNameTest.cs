// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using extension_client_name;
using extension_client_name.Models;
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
            TypeAsserts.HasParameter(method, "renamedPathParameter");
            TypeAsserts.HasParameter(method, "renamedQueryParameter");
        }

        [Test]
        public void PropertiesAreRenamed()
        {
            TypeAsserts.HasProperty(typeof(OriginalSchema), "RenamedProperty");
            TypeAsserts.HasProperty(typeof(OriginalSchema), "RenamedPropertyString");
        }
    }
}
