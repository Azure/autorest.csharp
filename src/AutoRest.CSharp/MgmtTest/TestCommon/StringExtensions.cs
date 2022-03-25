// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.MgmtTest.TestCommon
{
    internal static class StringExtensions
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
            if (scenarioVariables is null)
            {
                scenarioVariables = Enumerable.Empty<string>();
            }
            foreach (var scenarioVariable in scenarioVariables)
            {
                if (src.Contains($"$({scenarioVariable})"))
                {
                    return $"${src.RefScenarioDefinedVariablesToString(scenarioVariables):L}";
                }
            }
            return $"{src:L}";
        }

        public static string MultiplyStartingSpace(this string src, int mul)
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
            if (text.Length < 2)
            {
                return text.ToLower();
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
    }
}
