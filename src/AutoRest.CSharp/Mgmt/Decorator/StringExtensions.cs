// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class StringExtensions
    {
        private static HashSet<char> _vowels = new HashSet<char>(new char[] { 'a', 'e', 'i', 'o', 'u' });

        /// <summary>
        /// This function changes a resource name to its plural form. If it has the same plural and singular form, it will add "All" prefix before the resource name.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string ResourceNameToPlural(this string resourceName)
        {
            var pluralResourceName = resourceName.LastWordToPlural(false);
            var singularResourceName = resourceName.LastWordToSingular(false);
            return pluralResourceName != singularResourceName ?
                pluralResourceName :
                $"All{pluralResourceName}";
        }

        public static bool StartsWithVowel(this string resourceName)
        {
            return !string.IsNullOrEmpty(resourceName) && _vowels.Contains(char.ToLower(resourceName[0]));
        }
    }
}
