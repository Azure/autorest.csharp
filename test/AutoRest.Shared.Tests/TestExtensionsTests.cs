// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NUnit.Framework;
// using AutoRest.CSharp.MgmtTest.TestCommon;

namespace Azure.Core.Tests
{
    public class TestExtensionsTests
    {
        [Test]
        public void DisposeDoesNotThrow()
        {
            var writer = new XmlWriterContent();
            writer.Dispose();
        }
    }
}
