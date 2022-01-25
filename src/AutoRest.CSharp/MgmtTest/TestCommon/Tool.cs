// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
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

        public static void WriteAnonymousObject(CodeWriter writer, object? obj)
        {
            JsonRawValue jsonRawValue = new JsonRawValue(obj);
            if (jsonRawValue.IsDictionary())
            {
                var dict = jsonRawValue.AsDictionary();
                using (writer.Scope($"new ", newLine: false))
                {
                    foreach (var property in dict.Keys)
                    {
                        writer.Append($"{property} = ");
                        WriteAnonymousObject(writer, dict[property]);
                        writer.Line($", ");
                    }
                }
            }
            else if (jsonRawValue.IsEnumerable())
            {
                using (writer.Scope($"new object[]", newLine: false))
                {
                    foreach (var element in jsonRawValue.AsEnumerable())
                    {
                        WriteAnonymousObject(writer, element);
                        writer.Line($", ");
                    }
                }
            }
            else
            {
                if (jsonRawValue.IsString())
                {
                    writer.Append($"{jsonRawValue.AsString():L}");
                }
                else
                if (jsonRawValue.IsNull())
                {
                    writer.Append($"null");
                }
                else
                {
                    writer.Append($"{jsonRawValue.RawValue}");
                }
            }
        }
    }
}
