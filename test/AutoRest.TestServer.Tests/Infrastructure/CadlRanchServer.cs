// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class CadlRanchServer : TestServerBase
    {
        public CadlRanchServer(): base(GetBaseDirectory(), $"serve {GetScenariosPath()}")
        {
        }

        internal static string GetBaseDirectory()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@azure-tools", "cadl-ranch");
        }

        internal static string GetScenariosPath()
        {
            var nodeModules = GetNodeModulesDirectory();
            return Path.Combine(nodeModules, "@azure-tools", "cadl-ranch-specs", "http");
        }
    }
}
