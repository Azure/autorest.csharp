// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Generation.Types
{
    internal class CSharpNamespace
    {
        public CSharpNamespace(string? @base, string? category = null, string? apiVersion = null)
        {
            Base = @base;
            Category = category;
            ApiVersion = apiVersion;
        }

        public string? Base { get; }
        public string? Category { get; }
        public string? ApiVersion { get; }
        public string FullName => new[] { Base, Category, ApiVersion }.JoinIgnoreEmpty(".");
    }
}
