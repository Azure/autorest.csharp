// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.MgmtTest.Models;

namespace AutoRest.CSharp.MgmtTest.TestCommon
{
    internal static class OavVariableScopeExtensions
    {
        public static string GetVariableDefaultValue(this OavVariableScope ovs, string variableKey, string defaultValue = "default")
        {
            if (ovs.Variables is not null)
            {
                if (ovs.Variables.ContainsKey(variableKey))
                {
                    var rawValue = new JsonRawValue(ovs.Variables[variableKey]);
                    if (rawValue.IsString())
                    {
                        return rawValue.AsString()!;
                    }
                    else if (rawValue.IsDictionary())
                    {
                        var dict = rawValue.AsDictionary();
                        if (dict.ContainsKey("defaultValue"))
                        {
                            return dict["defaultValue"]?.ToString() ?? defaultValue;
                        }
                    }
                }
            }
            return defaultValue;
        }
    }
}
