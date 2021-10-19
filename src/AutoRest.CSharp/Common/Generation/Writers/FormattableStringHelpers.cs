// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class FormattableStringHelpers
    {
        public static FormattableString GetLiteralsFormattable(this ICollection<Parameter> parameters)
            => GetLiteralsFormattable(parameters.Select(p => p.Name), parameters.Count);

        public static FormattableString GetLiteralsFormattable(this ICollection<Reference> references)
            => GetLiteralsFormattable(references.Select(p => p.Name), references.Count);

        public static FormattableString GetLiteralsFormattable(this ICollection<string> literals)
            => GetLiteralsFormattable(literals, literals.Count);

        public static FormattableString GetLiteralsFormattable(this IEnumerable<string> literals, int count)
            => count switch
            {
                0 => $"",
                1 => $"{literals.First():L}",
                _ => FormattableStringFactory.Create(GetNamesForMethodCallFormat(count, 'L'), literals.ToArray<object>())
            };

        public static FormattableString GetIdentifiersFormattable(this ICollection<Parameter> parameters)
            => GetIdentifiersFormattable(parameters.Select(p => p.Name), parameters.Count);

        public static FormattableString GetIdentifiersFormattable(this ICollection<Reference> references)
            => GetIdentifiersFormattable(references.Select(p => p.Name), references.Count);

        public static FormattableString GetIdentifiersFormattable(this ICollection<string> identifiers)
            => GetIdentifiersFormattable(identifiers, identifiers.Count);

        public static FormattableString GetIdentifiersFormattable(this IEnumerable<string> identifiers, int count)
            => count switch
            {
                0 => $"",
                1 => $"{identifiers.First():I}",
                _ => FormattableStringFactory.Create(GetNamesForMethodCallFormat(count, 'I'), identifiers.ToArray<object>())
            };

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
