// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CommonSingleWordModels
    {
        private static readonly HashSet<string> _schemasToChange = new HashSet<string>()
        {
            "Sku",
            "Plan",
            "Usage"
        };

        public static void Update(IEnumerable<Schema> allSchemas)
        {
            foreach (var schema in allSchemas)
            {
                if (_schemasToChange.Contains(schema.Name))
                    schema.Language.Default.Name = MgmtContext.Context.DefaultNamespace.Split('.').Last() + schema.Name;
            }
        }
    }
}
