// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Output.PostProcessing;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.LowLevel.AutoRest.PostProcessing
{
    internal sealed class DpgPostProcessor : PostProcessor
    {
        protected override bool IsRootDocument(Document document)
        {
            // a document is a root document, when
            // 1. it is a custom document (not generated or shared)
            // 2. it is a client
            return GeneratedCodeWorkspace.IsCustomDocument(document) || IsClientDocument(document);
        }

        private static bool IsClientDocument(Document document)
        {
            return document.Name.EndsWith("Client.cs", StringComparison.Ordinal);
        }
    }
}
