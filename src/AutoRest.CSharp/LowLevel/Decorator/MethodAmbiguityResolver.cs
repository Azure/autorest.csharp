// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.LowLevel.Decorator
{
    internal static class MethodAmbiguityResolver
    {
        /// <summary>
        /// Resolve ambiguous methods between DPG client and existing client codes.
        /// </summary>
        /// <param name="clientMethods">Client methods belonging to a DPG client.</param>
        /// <param name="clientNamespace">Namespace of the DPG client.</param>
        /// <param name="clientName">Name of the DPG client.</param>
        /// <param name="sourceInputModel">Roslyn source model for existing client codes.</param>
        /// <returns>An array of LowLwevelClientMethod which have been resolved to avoid ambiguity with existing client codes.</returns>
        internal static LowLevelClientMethod[] ResolveClientMethods(LowLevelClientMethod[] clientMethods, string clientNamespace, string clientName, SourceInputModel sourceInputModel)
        {
            var clientSourceModel = sourceInputModel.FindForType(clientNamespace, clientName);
            if (clientSourceModel != null)
            {
                var newClientMethods = new LowLevelClientMethod[clientMethods.Length];
                for (int i = 0; i < clientMethods.Length; i++)
                {
                    newClientMethods[i] = ResolveClientMethod(clientMethods[i], clientSourceModel);
                }
                return newClientMethods;
            }

            return clientMethods;
        }

        /// <summary>
        /// Reslove ambiguity between a DPG client method and client methods under the client with the same name as DPG client in existing codes.
        /// </summary>
        /// <param name="clientMethod">Client method belonging  to a DPG client.</param>
        /// <param name="clientSourceModel">Roslyn model for a client with the same name of DPG client in existing codes.</param>
        /// <returns>A LowLevelClientMethod which have been resolved to avoid ambiguity with the methods in the given client in existing codes.</returns>
        private static LowLevelClientMethod ResolveClientMethod(LowLevelClientMethod clientMethod, INamedTypeSymbol clientSourceModel)
        {
            IEnumerable<IMethodSymbol> clientMethodSourceModels = GetPublicMethodsFromSourceModelByName(clientMethod.Signature.Name, clientSourceModel);
            if (clientMethodSourceModels.Any())
            {
                return ResolveClientMethod(clientMethod, clientMethodSourceModels);
            }
            return clientMethod;
        }

        private static IEnumerable<IMethodSymbol> GetPublicMethodsFromSourceModelByName(string methodName, INamedTypeSymbol clientSourceModel)
        {
            return clientSourceModel.GetMembers().Where(s => s.Kind == SymbolKind.Method &&
                s.Name == methodName && s.DeclaredAccessibility == Accessibility.Public).Select(s => (IMethodSymbol)s);
        }

        /// <summary>
        /// Resolve ambiguity between a DPG client method and a client method in existing codes.
        /// </summary>
        /// <param name="clientMethod">Client method beloning to a DPG client.</param>
        /// <param name="clientMethodSourceModels">Roslyn model for a client method with the same name and the same parent client in existing codes.</param>
        /// <returns>A LowLevelClientMethod which have been resolved to avoid ambiguity with the given method in existing codes.</returns>
        private static LowLevelClientMethod ResolveClientMethod(LowLevelClientMethod clientMethod, IEnumerable<IMethodSymbol> clientMethodSourceModels)
        {
            bool ambiguityFound = false;
            foreach (var clientMethodSourceModel in clientMethodSourceModels)
            {
                if (IsAmbiguousMethod(clientMethod, clientMethodSourceModel))
                {
                    // if two methods are identical, that means there should be some customization codes and we leave them to users to resolve
                    if (IsMethodSignatureSame(clientMethod, clientMethodSourceModel))
                    {
                        return clientMethod;
                    }
                    ambiguityFound = true;
                }
            };

            if (ambiguityFound)
            {
                return clientMethod.CloneWithAllParametersRequired();
            }
            return clientMethod;
        }

        /// <summary>
        /// Check if a client method is ambiguous with the method in source model.
        /// Two methods are considered as ambiguous when:
        /// - both has the same number of required parameters
        /// - for each required parameter, either they should be the same type in source model.
        /// </summary>
        /// <param name="clientMethod"></param>
        /// <param name="methodSymbol"></param>
        /// <returns></returns>
        private static bool IsAmbiguousMethod(LowLevelClientMethod clientMethod, IMethodSymbol methodSymbol)
        {
            var clientMethodRequiredParameters = clientMethod.Signature.Parameters.Where(p => !p.IsOptionalInSignature).ToList();
            var requiredParameterSymbols = methodSymbol.Parameters.Where(p => !p.HasExplicitDefaultValue).ToList();
            if (clientMethodRequiredParameters.Count != requiredParameterSymbols.Count)
            {
                return false;
            }

            for (int i = 0; i < clientMethodRequiredParameters.Count; i++)
            {
                if (!IsParameterTypeAndDefaultValueSame(clientMethodRequiredParameters[i], requiredParameterSymbols[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check if a clientMethod has the same paramters as a method from source model has.
        /// Both methods should:
        /// - have the same number of parameters
        /// - each parameter has the same type
        /// - each parameter has the same default value (e.g. optional or required)
        /// </summary>
        /// <param name="clientMethod"></param>
        /// <param name="clientMethodSourceModel"></param>
        /// <returns></returns>
        private static bool IsMethodSignatureSame(LowLevelClientMethod clientMethod, IMethodSymbol clientMethodSourceModel)
        {
            if (clientMethod.Signature.Parameters.Count != clientMethodSourceModel.Parameters.Length)
            {
                return false;
            }
            for (int i = 0; i < clientMethod.Signature.Parameters.Count; i++)
            {
                if (!IsParameterTypeAndDefaultValueSame(clientMethod.Signature.Parameters[i], clientMethodSourceModel.Parameters[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsParameterTypeAndDefaultValueSame(Parameter parameter, IParameterSymbol parameterSourceModel)
        {
            if (!IsSameType(parameter.Type, parameterSourceModel.Type))
            {
                return false;
            }
            if (parameter.IsOptionalInSignature != parameterSourceModel.HasExplicitDefaultValue)
            {
                return false;
            }

            return true;
        }

        private static bool IsSameType(CSharpType csharpType, ITypeSymbol typeSourceModel)
        {
            return ((csharpType.Namespace == typeSourceModel.ContainingNamespace.Name) &&
                    (csharpType.Name == typeSourceModel.Name));
        }
    }
}
