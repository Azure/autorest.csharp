// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using MgmtSubscriptionNameParameter;


namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtSubscriptionNameParameterTests : OutputLibraryTestBase
    {
        public MgmtSubscriptionNameParameterTests() : base("MgmtSubscriptionNameParameter")
        {
        }

        private protected override Assembly GetAssembly() => typeof(SBSubscriptionResource).Assembly;
    }
}
