// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceInputModelBuilder
    {
        private readonly Compilation _compilation;
        private readonly INamedTypeSymbol _schemaNameAttribute;
        private readonly INamedTypeSymbol _schemaMemberAttribute;
        private readonly INamedTypeSymbol _clientAttribute;

        private SourceInputModelBuilder(Compilation compilation)
        {
            _compilation = compilation;
            _schemaNameAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenSchemaAttribute).FullName!)!;
            _schemaMemberAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenSchemaMemberAttribute).FullName!)!;
            _clientAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenClientAttribute).FullName!)!;
        }

        public static SourceInputModel Build(Compilation compilation)
        {
            return new SourceInputModelBuilder(compilation).BuildInternal();
        }

        private SourceInputModel BuildInternal()
        {
            var assembly = _compilation.Assembly;

            var definedSchemas = new List<ModelTypeMapping>();
            var definedClients = new List<ClientTypeMapping>();

            foreach (IModuleSymbol module in assembly.Modules)
            {
                foreach (var type in GetSymbols(module.GlobalNamespace))
                {
                    if (type is INamedTypeSymbol namedTypeSymbol)
                    {
                        if (TryGetName(type, _schemaNameAttribute, out var schemaName))
                        {
                            List<SourceMemberMapping> memberMappings = new List<SourceMemberMapping>();
                            foreach (var member in GetMembers(namedTypeSymbol))
                            {
                                if (TryGetName(member, _schemaMemberAttribute, out var schemaMemberName))
                                {
                                    memberMappings.Add(new SourceMemberMapping(schemaMemberName, member));
                                }
                            }

                            definedSchemas.Add(new ModelTypeMapping(schemaName, namedTypeSymbol, memberMappings.ToArray()));
                        }

                        if (TryGetName(type, _clientAttribute, out var operationName))
                        {
                            definedClients.Add(new ClientTypeMapping(operationName, namedTypeSymbol));
                        }
                    }
                }
            }

            return new SourceInputModel(
                definedSchemas.ToArray(),
                definedClients.ToArray());
        }

        private IEnumerable<ISymbol> GetMembers(INamedTypeSymbol? typeSymbol)
        {
            while (typeSymbol != null)
            {
                foreach (var symbol in typeSymbol.GetMembers())
                {
                    yield return symbol;
                }

                typeSymbol = typeSymbol.BaseType;
            }
        }

        private bool TryGetName(ISymbol symbol, INamedTypeSymbol attributeType, [NotNullWhen(true)] out string? name)
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
