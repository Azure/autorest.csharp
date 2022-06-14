// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class RenamePluralEnums
    {
        public static void Update(IEnumerable<Schema> schemas)
        {
            HashSet<string> checkedNames = new HashSet<string>();
            foreach (var schema in schemas)
            {
                if (schema is not SealedChoiceSchema && schema is not ChoiceSchema)
                    continue;
                schema.Language.Default.Name = schema.Language.Default.Name.LastWordToSingular(inputIsKnownToBePlural: false);
            }
        }
    }
}
