// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace AutoRest.CSharp
{
    internal class CommandLineOptions
    {
        [Option(longName: "standalone", Required = false, Default = null, HelpText = "Path to the solution directory.")]
        public string? BasePath { get; set; }

        [Option(shortName: 'c', longName: "configuration", Required = false, Default = null, HelpText = "Path to the configuration file.")]
        public string? ConfigurationPath { get; set; }

        [Option(longName: "new-project", Required = false, Default = false, HelpText = "Generate a new solution folder project and project files.")]
        public bool IsNewProject { get; set; }

        [Option(longName: "debug", Required = false, Default = false, Hidden = true, HelpText = "Attempt to attach the debugger on execute.")]
        public bool ShouldDebug { get; set; }

        [Option(longName: "server", Required = false, Default = null, HelpText = "Server argument.")]
        public string? Server { get; set; }
    }
}
