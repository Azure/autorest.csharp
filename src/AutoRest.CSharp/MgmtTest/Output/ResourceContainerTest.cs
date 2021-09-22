// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.MgmtTest.Output
{
    internal class ResourceContainerTest
    {
        public BuildContext<MgmtOutputLibrary> _context;
        public ResourceContainer _resourceContainer;

        public ResourceContainerTest(ResourceContainer resourceContainer, BuildContext<MgmtOutputLibrary> context)
        {
            _context = context;
            _resourceContainer = resourceContainer;
        }
    }
}
