// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.CodeAnalysis;
using Azure.Core;

namespace AutoRest.CSharp.Input.Source
{
    public class CodeGenAttributes
    {
        public CodeGenAttributes(Compilation compilation)
        {
            CodeGenSuppressAttribute = GetSymbol(compilation, typeof(CodeGenSuppressAttribute));
            CodeGenMemberAttribute = GetSymbol(compilation, typeof(CodeGenMemberAttribute));
            CodeGenTypeAttribute = GetSymbol(compilation, typeof(CodeGenTypeAttribute));
            CodeGenModelAttribute = GetSymbol(compilation, typeof(CodeGenModelAttribute));
            CodeGenClientAttribute = GetSymbol(compilation, typeof(CodeGenClientAttribute));
            CodeGenMemberSerializationAttribute = GetSymbol(compilation, typeof(CodeGenMemberSerializationAttribute));
            CodeGenMemberSerializationHooksAttribute = GetSymbol(compilation, typeof(CodeGenMemberSerializationHooksAttribute));
            CodeGenMemberSkipSerializationAttribute = GetSymbol(compilation, typeof(CodeGenMemberSkipSerializationAttribute));
        }

        public INamedTypeSymbol CodeGenSuppressAttribute { get; }

        public INamedTypeSymbol CodeGenMemberAttribute { get; }

        public INamedTypeSymbol CodeGenTypeAttribute { get; }

        public INamedTypeSymbol CodeGenModelAttribute { get; }

        public INamedTypeSymbol CodeGenClientAttribute { get; }

        public INamedTypeSymbol CodeGenMemberSerializationAttribute { get; }

        public INamedTypeSymbol CodeGenMemberSerializationHooksAttribute { get; }

        public INamedTypeSymbol CodeGenMemberSkipSerializationAttribute { get; }

        private static INamedTypeSymbol GetSymbol(Compilation compilation, Type type) => compilation.GetTypeByMetadataName(type.FullName!) ?? throw new InvalidOperationException($"cannot load symbol of attribute {type}");
    }
}
