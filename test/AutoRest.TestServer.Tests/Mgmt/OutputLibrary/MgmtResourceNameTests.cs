// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Reflection;
using MgmtResourceName;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtResourceNameTests : OutputLibraryTestBase
    {
        public MgmtResourceNameTests() : base("MgmtResourceName") { }

        private protected override Assembly GetAssembly() => typeof(DisplayResource).Assembly;
    }
}
