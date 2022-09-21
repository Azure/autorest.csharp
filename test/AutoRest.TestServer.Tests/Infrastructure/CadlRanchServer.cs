﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class CadlRanchServer : TestServerBase
    {
        public CadlRanchServer(): base(GetBaseDirectory(), $"serve {GetScenariosPath()} --port 0 --coverageFile {GetCoverageFilePath()}")
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
        internal static string GetCoverageFilePath()
        {
            return Path.Combine(GetCoverageDirectory(), "cadl-ranch-coverage-csharp.json");
        }
    }
}
