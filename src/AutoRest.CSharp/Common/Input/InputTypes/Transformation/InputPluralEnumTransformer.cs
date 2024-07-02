// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Utilities;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal class InputPluralEnumTransformer
{
    public static void Transform(InputNamespace inputNamespace)
    {
        // TODO: Add items to skip this transformation
        HashSet<string> enumsToKeepPlural = new HashSet<string>() { };

        foreach (var inputEnum in inputNamespace.Enums)
        {
            if (enumsToKeepPlural.Contains(inputEnum.Name))
            {
                continue;
            }
            inputEnum.Name = inputEnum.Name.LastWordToSingular(inputIsKnownToBePlural: false);
        }
    }
}
