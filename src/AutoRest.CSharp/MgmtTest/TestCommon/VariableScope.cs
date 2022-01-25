// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal class VariableScope
    {
        public HashSet<string> variableNames = new HashSet<string>();

        public string useVariableName(string variableName)
        {
            if (Utilities.StringExtensions.IsCSharpKeyword(variableName))
            {
                variableName = $"@{variableName}";
            }
            if (!variableNames.Contains(variableName))
            {
                variableNames.Add(variableName);
                return variableName;
            }

            for (int i = 2; true; i++)
            {
                var newName = $"{variableName}{i}";
                if (!variableNames.Contains(newName))
                {
                    variableNames.Add(newName);
                    return newName;
                }
            }
            throw new Exception($"Can't find a valid variable name start with {variableName}");
        }

        public void clearVariableNames()
        {
            variableNames = new HashSet<string>();
        }
    }
}
