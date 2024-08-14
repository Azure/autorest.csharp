// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtTypeSpecTests : TestProjectTests
    {
        public MgmtTypeSpecTests() : base("MgmtTypeSpec") { }

        [TestCase("MgmtTypeSpecPrivateLinkResourceData", true)]
        [TestCase("ManagedServiceIdentity", false)]
        public void ValidateType(string typeName, bool isExisted)
        {
            Assert.AreEqual(isExisted, GetType(typeName) != null);
        }
    }
}
