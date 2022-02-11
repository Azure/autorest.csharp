using System;
using System.Collections.Generic;
using System.Text;
using MgmtKeyvault;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtKeyvaultTests : TestProjectTests
    {
        public MgmtKeyvaultTests() : base("MgmtKeyvault", "src") { }

        protected override HashSet<Type> ListExceptionCollections { get; } = new HashSet<Type>() { typeof(DeletedManagedHsmCollection), typeof(DeletedVaultCollection) };
    }
}
