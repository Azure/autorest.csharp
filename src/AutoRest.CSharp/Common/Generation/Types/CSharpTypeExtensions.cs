// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Generation.Types
{
    internal static class CSharpTypeExtensions
    {
        public static bool IsString(this CSharpType type)
            => type.IsFrameworkType && type.FrameworkType == typeof(string);
    }
}
