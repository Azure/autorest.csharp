// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Reflection;
using MgmtMockAndSample;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtMockAndSampleTests : OutputLibraryTestBase
    {
        public MgmtMockAndSampleTests() : base("MgmtMockAndSample") { }

        private protected override Assembly GetAssembly() => typeof(DeletedVaultResource).Assembly;
    }
}
