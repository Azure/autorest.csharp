﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using MgmtPartialResource;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtPartialResourceTests : OutputLibraryTestBase
    {
        public MgmtPartialResourceTests() : base("MgmtPartialResource")
        {
        }

        private protected override Assembly GetAssembly() => typeof(ConfigurationProfileAssignmentResource).Assembly;
    }
}
