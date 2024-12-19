// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Common.Utilities
{
    internal class DocHelpers
    {
        public static string? GetDescription(string? summary, string? doc)
            => (summary, doc) switch
            {
                (null or "", null or "") => null,
                (string s, null or "") => s,
                _ => doc
            };
    }
}
