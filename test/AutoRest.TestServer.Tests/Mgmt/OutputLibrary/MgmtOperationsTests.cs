// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Reflection;
using MgmtOperations;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtOperationsTests : OutputLibraryTestBase
    {
        public MgmtOperationsTests() : base("MgmtOperations") { }

        private protected override Assembly GetAssembly() => typeof(AvailabilitySetChildResource).Assembly;
    }
}
