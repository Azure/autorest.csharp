// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceInputModel
    {
        private readonly Compilation _compilation;
        private readonly INamedTypeSymbol _schemaNameAttribute;
        private readonly INamedTypeSymbol _clientAttribute;
        private readonly INamedTypeSymbol _schemaMemberNameAttribute;

        public SourceInputModel(Compilation compilation)
        {
            _compilation = compilation;
            _schemaNameAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenModelAttribute).FullName!)!;
            _schemaMemberNameAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenMemberAttribute).FullName!)!;
            _clientAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenClientAttribute).FullName!)!;

            var assembly = _compilation.Assembly;

            var definedSchemas = new List<ModelTypeMapping>();
            var definedClients = new List<TypeMapping>();

            foreach (IModuleSymbol module in assembly.Modules)
            {
                foreach (var type in GetSymbols(module.GlobalNamespace))
                {
                    if (type is INamedTypeSymbol namedTypeSymbol)
                    {
                        if (TryGetName(type, _schemaNameAttribute, out var schemaName))
                        {
                            var modelTypeMapping = BuildModel(schemaName, namedTypeSymbol);
                            definedSchemas.Add(modelTypeMapping);
                        }

                        if (TryGetName(type, _clientAttribute, out var operationName))
                        {
                            definedClients.Add(BuildClient(operationName, namedTypeSymbol));
                        }
                    }
                }
            }

            DefinedClientTypes = definedClients.ToArray();
            DefinedSchemaTypes = definedSchemas.ToArray();
        }

        private static TypeMapping BuildClient(string originalName, INamedTypeSymbol namedTypeSymbol)
        {
            return new TypeMapping(originalName, namedTypeSymbol);
        }

        private ModelTypeMapping BuildModel(string originalName, INamedTypeSymbol namedTypeSymbol)
        {
            return new ModelTypeMapping(_schemaMemberNameAttribute, originalName, namedTypeSymbol);
        }

        private ModelTypeMapping[] DefinedSchemaTypes { get; }
        private TypeMapping[] DefinedClientTypes { get; }

        public ModelTypeMapping? FindForModel(string ns, string name)
        {
            var mapping = DefinedSchemaTypes.SingleOrDefault(s => string.Compare(s.OriginalName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
            if (mapping == null && _compilation.GetTypeByMetadataName($"{ns}.{name}") is INamedTypeSymbol type)
            {
                mapping = BuildModel(type.Name, type);
            }

            return mapping;
        }

        public TypeMapping? FindForClient(string ns, string name)
        {
            var mapping = DefinedClientTypes.SingleOrDefault(s => string.Compare(s.OriginalName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
            if (mapping == null && _compilation.GetTypeByMetadataName($"{ns}.{name}") is INamedTypeSymbol type)
            {
                mapping = BuildClient(type.Name, type);
            }

            return mapping;
        }

        internal static bool TryGetName(ISymbol symbol, INamedTypeSymbol attributeType, [NotNullWhen(true)] out string? name)
        {
            name = null;
#pragma warning disable RS1024
            var attribute = symbol.GetAttributes().SingleOrDefault(a => a.AttributeClass.Equals(attributeType));
#pragma warning restore
            if (attribute == null)
            {
                return false;
            }

            name = attribute.ConstructorArguments[0].Value as string;
            return name != null;
        }

        private IEnumerable<ITypeSymbol> GetSymbols(INamespaceSymbol namespaceSymbol)
        {
            foreach (var childNamespaceSymbol in namespaceSymbol.GetNamespaceMembers())
            {
                foreach (var symbol in GetSymbols(childNamespaceSymbol))
                {
                    yield return symbol;
                }
            }

            foreach (INamedTypeSymbol symbol in namespaceSymbol.GetTypeMembers())
            {
                yield return symbol;
            }
        }
    }
}
