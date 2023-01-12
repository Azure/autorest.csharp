// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class SourceInputModel
    {
        private readonly Compilation _compilation;
        private readonly CompilationInput? _existingCompilation;
        private readonly INamedTypeSymbol _typeAttribute;
        private readonly INamedTypeSymbol _modelAttribute;
        private readonly INamedTypeSymbol _clientAttribute;
        private readonly INamedTypeSymbol _schemaMemberNameAttribute;
        private readonly Dictionary<string, INamedTypeSymbol> _nameMap = new Dictionary<string, INamedTypeSymbol>(StringComparer.OrdinalIgnoreCase);

        public SourceInputModel(Compilation compilation, CompilationInput? existingCompilation = null)
        {
            _compilation = compilation;
            _existingCompilation = existingCompilation;

            _schemaMemberNameAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenMemberAttribute).FullName!)!;
            _typeAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenTypeAttribute).FullName!)!;
            _modelAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenModelAttribute).FullName!)!;
            _clientAttribute = compilation.GetTypeByMetadataName(typeof(CodeGenClientAttribute).FullName!)!;

            IAssemblySymbol assembly = _compilation.Assembly;

            foreach (IModuleSymbol module in assembly.Modules)
            {
                foreach (var type in SourceInputHelper.GetSymbols(module.GlobalNamespace))
                {
                    if (type is INamedTypeSymbol namedTypeSymbol && TryGetName(type, out var schemaName))
                    {
                        _nameMap.Add(schemaName, namedTypeSymbol);
                    }
                }
            }

            if (existingCompilation != null)
            {
                existingCompilation.FilterSymbols();
            }
        }

        public IReadOnlyList<string>? GetServiceVersionOverrides()
        {
            var osvAttributeType = _compilation.GetTypeByMetadataName(typeof(CodeGenOverrideServiceVersionsAttribute).FullName!)!;
            var osvAttribute = _compilation.Assembly.GetAttributes()
                .FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, osvAttributeType));

            return osvAttribute?.ConstructorArguments[0].Values.Select(v => v.Value).OfType<string>().ToList();
        }

        public ModelTypeMapping CreateForModel(INamedTypeSymbol? symbol)
        {
            return new ModelTypeMapping(_modelAttribute, _schemaMemberNameAttribute, symbol);
        }

        public IMethodSymbol? FindProtocolMethod(string namespaceName, string clientName, string methodName, IEnumerable<string> parameters)
        {
            if (_existingCompilation is ProtocolCompilationInput protocolCompilation)
            {
                return protocolCompilation.FindSymbol(namespaceName, clientName, methodName, parameters);
            }
            return null;
        }

        public INamedTypeSymbol? FindForType(string ns, string name, bool includeArmCore = false)
        {
            var fullyQualifiedMetadataName = $"{ns}.{name}";
            if (!_nameMap.TryGetValue(name, out var type) &&
                !_nameMap.TryGetValue(fullyQualifiedMetadataName, out type))
            {
                type = includeArmCore ? _compilation.GetTypeByMetadataName(fullyQualifiedMetadataName) : _compilation.Assembly.GetTypeByMetadataName(fullyQualifiedMetadataName);
            }

            return type;
        }

        internal bool TryGetClientSourceInput(INamedTypeSymbol type, [NotNullWhen(true)] out ClientSourceInput? clientSourceInput)
        {
            foreach (var attribute in type.GetAttributes())
            {
                var attributeType = attribute.AttributeClass;
                while (attributeType != null)
                {
                    if (SymbolEqualityComparer.Default.Equals(attributeType, _clientAttribute))
                    {
                        INamedTypeSymbol? parentClientType = null;
                        foreach ((var argumentName, TypedConstant constant) in attribute.NamedArguments)
                        {
                            if (argumentName == nameof(CodeGenClientAttribute.ParentClient))
                            {
                                parentClientType = (INamedTypeSymbol?)constant.Value;
                            }
                        }

                        clientSourceInput = new ClientSourceInput(parentClientType);
                        return true;
                    }

                    attributeType = attributeType.BaseType;
                }
            }

            clientSourceInput = null;
            return false;
        }

        private bool TryGetName(ISymbol symbol, [NotNullWhen(true)] out string? name)
        {
            name = null;

            foreach (var attribute in symbol.GetAttributes())
            {
                var type = attribute.AttributeClass;
                while (type != null)
                {
                    if (SymbolEqualityComparer.Default.Equals(type, _typeAttribute))
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
    }
}
