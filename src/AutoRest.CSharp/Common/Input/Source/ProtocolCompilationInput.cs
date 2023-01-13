// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ProtocolCompilationInput: CompilationInput
    {
        private readonly List<IMethodSymbol> _methodSet = new List<IMethodSymbol>();

        public ProtocolCompilationInput(Compilation compilation)
            : base(compilation) { }//, type => type.Name.EndsWith("Client"), method => method.Parameters.Length > 0 && method.Parameters.Last().Name == "context") { }

        public override void FilterSymbols()
        {
            foreach (IModuleSymbol module in _compilation.Assembly.Modules)
            {
                foreach (var type in SourceInputHelper.GetSymbols(module.GlobalNamespace))
                {
                    if (type is INamedTypeSymbol typeSymbol && isClient(typeSymbol))
                    {
                        foreach (var member in typeSymbol.GetMembers())
                        {
                            if (member is IMethodSymbol methodSymbol && isProtocolMethod(methodSymbol))
                            {
                                _methodSet.Add(methodSymbol);
                            }
                        }
                    }
                }
            }
        }

        public IMethodSymbol? FindSymbol(string namespaceName, string clientName, string methodName, IEnumerable<string> parameters)
        {
            var methods = _methodSet.Where(m =>
                m.ContainingNamespace.ToString() == namespaceName &&
                m.ContainingType.Name == clientName &&
                m.Name == methodName).ToArray();
            if (methods.Length == 0)
            {
                return null;
            }
            else if (methods.Length == 1)
            {
                return methods.First();
            }
            else
            {
                foreach (var method in methods)
                {
                    var existingParameters = method.Parameters;
                    var parametersCount = parameters.Count();
                    if (existingParameters.Length - 1 != parametersCount)
                    {
                        continue;
                    }

                    int index = 0;
                    foreach (var parameter in parameters)
                    {
                        // It would be better to compare the types.
                        if (parameter != existingParameters[index].Name)
                        {
                            break;
                        }
                        ++index;
                    }

                    if (index == parametersCount)
                    {
                        return method;
                    }
                }
                return null;
            }
        }

        private bool isClient(INamedTypeSymbol type) => type.Name.EndsWith("Client");
        private bool isProtocolMethod(IMethodSymbol method) => method.Parameters.Length > 0 && method.Parameters.Last().Name == "context";
    }
}
