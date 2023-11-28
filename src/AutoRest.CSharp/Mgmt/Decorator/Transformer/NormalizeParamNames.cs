// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class NormalizeParamNames
    {
        internal static string GetNewName(string paramName, InputType inputType, IDictionary<string, HashSet<OperationSet>> dataSchemaHash, IReadOnlyDictionary<object, string> renamingMap)
        {
            var typeName = renamingMap.TryGetValue(inputType, out var newName) ? newName : inputType.Name;
            if (typeName.EndsWith("Options", StringComparison.Ordinal))
                return "options";

            if (typeName.EndsWith("Info", StringComparison.Ordinal))
                return "info";

            if (typeName.EndsWith("Details", StringComparison.Ordinal))
                return "details";

            if (typeName.EndsWith("Content", StringComparison.Ordinal))
                return "content";

            if (typeName.EndsWith("Patch", StringComparison.Ordinal))
                return "patch";

            if (typeName.EndsWith("Input", StringComparison.Ordinal))
                return "input";

            if (typeName.EndsWith("Data", StringComparison.Ordinal) || dataSchemaHash.ContainsKey(typeName))
                return "data";

            if (paramName.Equals("parameters", StringComparison.OrdinalIgnoreCase))
                return typeName.FirstCharToLowerCase();

            return paramName;
        }
    }
}
