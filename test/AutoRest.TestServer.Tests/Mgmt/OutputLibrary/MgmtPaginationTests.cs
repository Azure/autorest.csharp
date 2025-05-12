// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using MgmtPagination;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtPaginationTests : OutputLibraryTestBase
    {
        public MgmtPaginationTests() : base("MgmtPagination") { }

        private protected override Assembly GetAssembly() => typeof(PageSizeDecimalModelResource).Assembly;
    }
}
