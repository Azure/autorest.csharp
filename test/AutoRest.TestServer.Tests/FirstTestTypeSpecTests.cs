// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class FirstTestTypeSpecTests
    {
        [Test]
        public void ModelForUnionShouldBePublic()
        {
            // ModelForUnion is not used anywhere in the public API, as a property type or parameter type or field type or any other approach of being part of public API.
            // but this model is used in description of `RoundTripModel.UnionList` property, as part of the xml doc
            // for the purpose of documentation, and for the convenience of our generated library users to use the BinaryData type, we need to keep this type public despite it is not publicly used on APIs.
            Assert.IsTrue(typeof(ModelForUnion).IsPublic);
        }
    }
}
