// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            foreach (var schema in MgmtContext.CodeModel.AllSchemas)
            {
                if (schema is not SealedChoiceSchema && schema is not ChoiceSchema)
                    continue;
                if (schema.Extensions?.TryGetValue("x-ms-enum-plural", out _) ?? false)
                    continue;
                schema.Language.Default.Name = schema.Language.Default.Name.LastWordToSingular(inputIsKnownToBePlural: false);
            }
        }
    }
}
