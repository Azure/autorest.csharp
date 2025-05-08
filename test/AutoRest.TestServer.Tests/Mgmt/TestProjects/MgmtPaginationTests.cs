// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using MgmtPagination;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class MgmtPaginationTests : TestProjectTests
    {
        public MgmtPaginationTests() : base("MgmtPagination") { }

        private protected override Assembly GetAssembly() => typeof(PageSizeDecimalModelResource).Assembly;
    }
}
