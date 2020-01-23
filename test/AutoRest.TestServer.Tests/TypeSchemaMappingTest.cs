// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.TypeSchemaMapping;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class TypeSchemaMappingTest
    {
        [Test]
        public void SchemaTypesAreMappedToSchema()
        {
            TypeAsserts.HasProperty(typeof(CustomizedModel), "ModelProperty");
        }
    }
}
