// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using FirstTestTypeSpec;

namespace Azure.Core.Tests
{
    public class XmlWriterRequestContentTests
    {
        [Test]
        public void DisposeDoesNotThrow()
        {
            var writer = new XmlWriterRequestContent();
            writer.Dispose();
        }
    }
}
