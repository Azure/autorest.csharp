// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtKeyvault : OutputLibraryTestBase
    {
        public MgmtKeyvault() : base("MgmtKeyvault", "src") { }
    }
}
