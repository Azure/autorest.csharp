// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Accessibility_LowLevel_NoAuth.Samples
{
    public class Samples_AccessibilityClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var client = new AccessibilityClient();

            var data = "<String>";

            Response response = client.Operation(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_OperationInternal()
        {
            var client = new AccessibilityClient();

            var data = "<String>";

            Response response = client.OperationInternal(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
