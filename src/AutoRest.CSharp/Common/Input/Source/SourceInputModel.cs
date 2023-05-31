// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class SourceInputModel
    {
        private readonly Compilation _compilation;
        private readonly CompilationInput? _existingCompilation;
        private readonly CodeGenAttributes _codeGenAttributes;
        private readonly Dictionary<string, INamedTypeSymbol> _nameMap = new Dictionary<string, INamedTypeSymbol>(StringComparer.OrdinalIgnoreCase);

        public SourceInputModel(Compilation compilation, CompilationInput? existingCompilation = null)
        {
            _compilation = compilation;
            _existingCompilation = existingCompilation;

            _codeGenAttributes = new CodeGenAttributes(compilation);

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
        }

        public IReadOnlyList<string>? GetServiceVersionOverrides()
        {
            var osvAttributeType = _compilation.GetTypeByMetadataName(typeof(CodeGenOverrideServiceVersionsAttribute).FullName!)!;
            var osvAttribute = _compilation.Assembly.GetAttributes()
                .FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, osvAttributeType));

            return osvAttribute?.ConstructorArguments[0].Values.Select(v => v.Value).OfType<string>().ToList();
        }

        public ModelTypeMapping? CreateForModel(INamedTypeSymbol? symbol)
        {
            if (symbol == null)
                return null;

            return new ModelTypeMapping(_codeGenAttributes, symbol);
        }

        internal IMethodSymbol? FindMethod(string namespaceName, string typeName, string methodName, IEnumerable<CSharpType> parameters)
        {
            return _existingCompilation?.FindMethod(namespaceName, typeName, methodName, parameters);
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
                    if (SymbolEqualityComparer.Default.Equals(attributeType, _codeGenAttributes.CodeGenClientAttribute))
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
                    if (SymbolEqualityComparer.Default.Equals(type, _codeGenAttributes.CodeGenTypeAttribute))
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
    }
}
