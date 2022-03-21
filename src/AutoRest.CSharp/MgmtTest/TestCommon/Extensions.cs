// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using System.Reflection.Metadata.Ecma335;
using AutoRest.CSharp.MgmtTest.Models;

namespace AutoRest.CSharp.MgmtTest.TestCommon
{
    internal static class Extensions
    {
        public static string RefScenarioDefinedVariablesToString(this string src, IEnumerable<string> scenarioVariables)
        {
            StringBuilder stringBuilder = new StringBuilder(src);
            stringBuilder = stringBuilder.Replace(@"{", @"{{").Replace(@"}", @"}}");
            foreach (var scenarioVariable in scenarioVariables)
            {
                stringBuilder.Replace($"$({scenarioVariable})", $"{{{scenarioVariable}}}");
            }
            return stringBuilder.ToString();
        }

        public static FormattableString? RefScenarioDefinedVariables(this string src, IEnumerable<string>? scenarioVariables)
        {
            if (src is null)
            {
                return null;
            }
            if (scenarioVariables is null)
            {
                return $"{src:L}";
            }
            return $"{src.RefScenarioDefinedVariablesToString(scenarioVariables):L}";
        }

        public static string MultipleStartingSpace(this string src, int mul)
        {
            var lines = src.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                var space = lines[i].TakeWhile(Char.IsWhiteSpace).Count();
                lines[i] = $"{new string(' ', space * mul)}{lines[i].TrimStart()}";
            }
            return String.Join('\n', lines);
        }

        public static string ToSnakeCase(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (text.Length < 2)
            {
                return text;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(text[0]));
            for (int i = 1; i < text.Length; ++i)
            {
                char c = text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

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

        public static bool IsCollectionOperation(this Operation operation, [MaybeNullWhen(false)] out ResourceCollection collection, [MaybeNullWhen(false)] out MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out MgmtRestOperation restOperation)
        {
            collection = null;
            clientOperation = null;
            restOperation = null;
            foreach (var c in MgmtContext.Library.ResourceCollections)
            {
                foreach (var co in c.AllOperations)
                {
                    foreach (var ro in co)
                    {
                        if (ro.Operation == operation)
                        {
                            collection = c;
                            clientOperation = co;
                            restOperation = ro;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsResourceOperation(this Operation operation, [MaybeNullWhen(false)] out Resource resource, [MaybeNullWhen(false)] out MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out MgmtRestOperation restOperation)
        {
            resource = null;
            clientOperation = null;
            restOperation = null;
            foreach (var r in MgmtContext.Library.ArmResources)
            {
                foreach (var co in r.AllOperations)
                {
                    foreach (var ro in co)
                    {
                        if (ro.Operation == operation)
                        {
                            resource = r;
                            clientOperation = co;
                            restOperation = ro;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsSubscriptionOperation(this Operation operation, [MaybeNullWhen(false)] out MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out MgmtRestOperation restOperation)
        {
            clientOperation = null;
            restOperation = null;
            foreach (var co in MgmtContext.Library.SubscriptionExtensions.ClientOperations)
            {
                foreach (var ro in co)
                {
                    if (ro.Operation == operation)
                    {
                        clientOperation = co;
                        restOperation = ro;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
