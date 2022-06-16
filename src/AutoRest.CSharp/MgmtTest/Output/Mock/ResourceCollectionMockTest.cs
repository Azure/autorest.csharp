// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.TestFramework;

namespace AutoRest.CSharp.MgmtTest.Output.Mock
{
    internal class ResourceCollectionMockTest : MgmtTestTypeProvider
    {
        public ResourceCollection ResourceCollection { get; }
        public ResourceCollectionMockTest(ResourceCollection collection, List<MockTestCase> testCases) : base(collection, testCases)
        {
            ResourceCollection = collection;
        }
    }
}
