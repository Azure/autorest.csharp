// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class StringExtensions
    {
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

        /// <summary>
        /// Add `Resource` suffix to a resource name if that resource doesn't end with `Resource`.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string AddResourceSuffixToResourceName(this string resourceName)
        {
            return resourceName.EndsWith("Resource") ? resourceName : resourceName + "Resource";
        }
    }
}
