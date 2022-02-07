// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.MgmtTest.Decorator
{
    internal static class MgmtRestOperationExtensions
    {
        public static ExampleGroup? FindExampleGroup(this MgmtRestOperation restOperation, BuildContext<MgmtOutputLibrary> context)
        {
            foreach (var exampleGroup in context.CodeModel.TestModel?.MockTest.ExampleGroups ?? Enumerable.Empty<ExampleGroup>())
            {
                if (exampleGroup.Examples.Count > 0 && exampleGroup.Examples.First().Operation == restOperation.Operation)
                {
                    return exampleGroup;
                }
            }
            return null;
        }
    }
}
