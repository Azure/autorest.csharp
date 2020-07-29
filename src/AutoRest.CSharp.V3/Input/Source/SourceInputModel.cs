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
        private readonly INamedTypeSymbol _clientAttribute;
        private readonly INamedTypeSymbol _modelAttribute;
        private readonly INamedTypeSymbol _schemaMemberNameAttribute;
        private readonly Dictionary<string, INamedTypeSymbol> _nameMap = new Dictionary<string, INamedTypeSymbol>(StringComparer.OrdinalIgnoreCase);


        public SourceInputModel(Compilation compilation)
        {
            _compilation = compilation;
            _schemaMemberNameAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenMemberAttribute).FullName!)!;
            _clientAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenTypeAttribute).FullName!)!;
            _modelAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenModelAttribute).FullName!)!;

            IAssemblySymbol assembly = _compilation.Assembly;

            foreach (IModuleSymbol module in assembly.Modules)
            {
                foreach (var type in GetSymbols(module.GlobalNamespace))
                {
                    if (type is INamedTypeSymbol namedTypeSymbol && TryGetName(type, out var schemaName))
                    {
                        _nameMap.Add(schemaName, namedTypeSymbol);
                    }
                }
            }
        }

        public ModelTypeMapping CreateForModel(INamedTypeSymbol? symbol)
        {
            return new ModelTypeMapping(_modelAttribute, _schemaMemberNameAttribute, symbol);
        }

        public INamedTypeSymbol? FindForType(string ns, string name)
        {
            var fullyQualifiedMetadataName = $"{ns}.{name}";
            if (!_nameMap.TryGetValue(name, out var type) &&
                !_nameMap.TryGetValue(fullyQualifiedMetadataName, out type))
            {
                type = _compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
            }

            return type;
        }

        private bool TryGetName(ISymbol symbol, [NotNullWhen(true)] out string? name)
        {
            name = null;

            foreach (var attribute in symbol.GetAttributes())
            {
                var type = attribute.AttributeClass;
                while (type != null)
                {
                    if (SymbolEqualityComparer.Default.Equals(type, _clientAttribute))
                    {
                        if (attribute?.ConstructorArguments.Length > 0)
                        {
                            name = attribute.ConstructorArguments[0].Value as string;
                            break;
                        }
                    }

                    type = type.BaseType;
                }
            }

            return name != null;
        }

        internal static bool TryGetName(ISymbol symbol, INamedTypeSymbol attributeType, [NotNullWhen(true)] out string? name)
        {
            name = null;

            var attribute = symbol.GetAttributes().SingleOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, attributeType));

            if (attribute?.ConstructorArguments.Length > 0)
            {
                name = attribute.ConstructorArguments[0].Value as string;
            }

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
