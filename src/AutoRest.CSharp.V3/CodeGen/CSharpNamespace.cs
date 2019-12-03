// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class CSharpNamespace
    {
        public CSharpNamespace(string? @base, string? category = null, string? apiVersion = null)
        {
            Base = @base;
            Category = category;
            ApiVersion = apiVersion;
        }

        public string? Base { get; set; }

        public string? Category { get; set; }

        public string? ApiVersion { get; set; }

        public string FullName => new[] { Base, Category, ApiVersion }.JoinIgnoreEmpty(".");
    }
}
