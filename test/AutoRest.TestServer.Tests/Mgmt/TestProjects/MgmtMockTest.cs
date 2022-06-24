using System;
using System.Collections.Generic;
using MgmtMockTest;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtMockTest : TestProjectTests
    {
        public MgmtMockTest() : base("MgmtMockTest", "src") { }

        protected override HashSet<Type> ListExceptionCollections { get; } = new HashSet<Type>() { typeof(DeletedManagedHsmCollection), typeof(DeletedVaultCollection) };
    }
}
