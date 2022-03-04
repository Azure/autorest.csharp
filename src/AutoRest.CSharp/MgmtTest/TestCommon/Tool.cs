// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal static class Tool
    {
        public static FormattableString? RefScenariDefinedVariables(this string? src, IEnumerable<string>? scenarioVariables)
        {
            if (src is null)
            {
                return null;
            }
            if (scenarioVariables is null)
            {
                return $"{src:L}";
            }

            StringBuilder stringBuilder = new StringBuilder(src);
            stringBuilder = stringBuilder.Replace(@"{", @"{{").Replace(@"}", @"}}");
            foreach (var scenarioVariable in scenarioVariables)
            {
                stringBuilder.Replace($"$({scenarioVariable})", $"{{{scenarioVariable}}}");
            }
            return $"${stringBuilder.ToString():L}";
        }

        public static string ToJsonString(this JsonDocument jdoc)
        {
            using (var stream = new MemoryStream())
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                jdoc.WriteTo(writer);
                writer.Flush();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
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
    }
}
