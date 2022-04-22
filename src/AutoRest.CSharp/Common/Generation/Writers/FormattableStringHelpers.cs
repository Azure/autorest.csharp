// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class FormattableStringHelpers
    {
        public static FormattableString Join(this ICollection<FormattableString> fss, string separator)
            => fss.Count switch
            {
                0 => $"",
                1 => fss.First(),
                _ => FormattableStringFactory.Create(string.Join(separator, Enumerable.Range(0, fss.Count).Select(i => $"{{{i}}}")), fss.ToArray<object>())
            };

        public static FormattableString GetLiteralsFormattable(this IReadOnlyCollection<Parameter> parameters)
            => GetLiteralsFormattable(parameters.Select(p => p.Name), parameters.Count);

        public static FormattableString GetLiteralsFormattable(this IReadOnlyCollection<Reference> references)
            => GetLiteralsFormattable(references.Select(p => p.Name), references.Count);

        public static FormattableString GetLiteralsFormattable(this IReadOnlyCollection<string> literals)
            => GetLiteralsFormattable(literals, literals.Count);

        public static FormattableString GetLiteralsFormattable(this ICollection<string> literals)
            => GetLiteralsFormattable(literals, literals.Count);

        public static FormattableString GetLiteralsFormattable(this IEnumerable<string> literals, int count)
            => count switch
            {
                0 => $"",
                1 => $"{literals.First():L}",
                _ => FormattableStringFactory.Create(GetNamesForMethodCallFormat(count, 'L'), literals.ToArray<object>())
            };

        public static FormattableString GetIdentifiersFormattable(this IReadOnlyCollection<Parameter> parameters)
            => GetIdentifiersFormattable(parameters.Select(p => p.Name), parameters.Count);

        public static FormattableString GetIdentifiersFormattable(this IReadOnlyCollection<Reference> references)
            => GetIdentifiersFormattable(references.Select(p => p.Name), references.Count);

        public static FormattableString GetIdentifiersFormattable(this IReadOnlyCollection<string> identifiers)
            => GetIdentifiersFormattable(identifiers, identifiers.Count);

        public static FormattableString GetIdentifiersFormattable(this IEnumerable<string> identifiers, int count)
            => count switch
            {
                0 => $"",
                1 => $"{identifiers.First():I}",
                _ => FormattableStringFactory.Create(GetNamesForMethodCallFormat(count, 'I'), identifiers.ToArray<object>())
            };

        public static FormattableString GetConstantFormattable(this Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                return $"({constant.Type}){null:L}";
            }

            if (constant.IsNewInstanceSentinel)
            {
                return $"new {constant.Type}()";
            }

            if (!constant.Type.IsFrameworkType && constant.Value is EnumTypeValue enumTypeValue)
            {
                return $"{constant.Type}.{enumTypeValue.Declaration.Name}";
            }

            if (!constant.Type.IsFrameworkType && constant.Value is string enumValue)
            {
                return $"new {constant.Type}({enumValue:L})";
            }

            Type frameworkType = constant.Type.FrameworkType;
            if (frameworkType == typeof(DateTimeOffset))
            {
                var d = (DateTimeOffset)constant.Value;
                d = d.ToUniversalTime();
                return $"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})";
            }
            else if (frameworkType == typeof(byte[]))
            {
                var bytes = (byte[])constant.Value;
                var joinedBytes = string.Join(", ", bytes);
                return $"new byte[] {{{joinedBytes}}}";
            }
            else if (frameworkType == typeof(ResourceType))
            {
                return $"{((ResourceType)constant.Value).ToString():L}";
            }
            else
            {
                return $"{constant.Value:L}";
            }
        }

        private static string GetNamesForMethodCallFormat(int parametersCount, char format)
        {
            var sb = new StringBuilder(5 * parametersCount + 2 * (parametersCount - 1));
            sb.Append("{0:").Append(format).Append('}');
            for (var i = 1; i < parametersCount; i++)
            {
                sb.Append(", {").Append(i).Append(':').Append(format).Append('}');
            }

            return sb.ToString();
        }
    }
}
