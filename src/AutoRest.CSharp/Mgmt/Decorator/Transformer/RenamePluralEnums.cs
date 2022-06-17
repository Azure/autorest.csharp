// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class RenamePluralEnums
    {
        public static void Update()
        {
            ImmutableHashSet<string> enumsToKeepPlural = Configuration.MgmtConfiguration.KeepPluralEnums.ToImmutableHashSet();

            foreach (var schema in MgmtContext.CodeModel.AllSchemas)
            {
                if (schema is not SealedChoiceSchema && schema is not ChoiceSchema)
                    continue;
                string name = schema.Language.Default.Name;
                if (enumsToKeepPlural.Contains(name))
                    continue;
                if (Configuration.MgmtConfiguration.RenameRules.ContainsKey(name.SplitByCamelCase().Last()))
                    continue;
                schema.Language.Default.Name = name.LastWordToSingular(inputIsKnownToBePlural: false);
            }
        }
    }
}
