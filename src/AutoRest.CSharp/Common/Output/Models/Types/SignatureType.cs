// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    /// <summary>
    /// The <see cref="SignatureType"/> resolves the symbol to produce the MethodSignatures on the symbol
    /// </summary>
    internal class SignatureType
    {
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<IMethodSymbol> _methodSymbols;

        public SignatureType(TypeFactory typeFactory, SourceTypeMapping? sourceTypeMapping)
        {
            _typeFactory = typeFactory;
            _methodSymbols = sourceTypeMapping?.GetMethods().ToArray() ?? Array.Empty<IMethodSymbol>();
        }

        private IReadOnlyList<MethodSignature>? _methods;
        public IReadOnlyList<MethodSignature> Methods => _methods ??= BuildMethods().ToArray();

        private IEnumerable<MethodSignature> BuildMethods()
        {
            foreach (var methodSymbol in _methodSymbols)
            {
                var method = PopulateMethodSymbol(methodSymbol);
                if (method is not null)
                    yield return method;
            }
        }

        private MethodSignature? PopulateMethodSymbol(IMethodSymbol methodSymbol)
        {
            var description = methodSymbol.GetDocumentationCommentXml();
            if (!_typeFactory.TryCreateType(methodSymbol.ReturnType, out var returnType))
            {
                // TODO: handle missing method return type from MgmtOutputLibrary
                return null;
            }

            // TODO: handle missing parameter type from MgmtOutputLibrary
            var parameters = new List<Parameter>();
            bool isParameterTypeMissing = false;
            foreach (var parameter in methodSymbol.Parameters)
            {
                var methodParameter = FromParameterSymbol(parameter);

                // If any parameter can't be created, it means the type was removed from current version
                if (methodParameter is null)
                {
                    isParameterTypeMissing = true;
                    break;
                }
                else
                {
                    parameters.Add(methodParameter);
                }
            }

            // Since we don't have the ability to create the missing types, if any parameter type is missing we can't continue to generate overload methods
            if (isParameterTypeMissing)
            {
                return null;
            }
            return new MethodSignature(methodSymbol.Name, null, $"{description}", BuilderHelpers.MapModifiers(methodSymbol), returnType, null, parameters, IsRawSummaryText: true);
        }

        private Parameter? FromParameterSymbol(IParameterSymbol parameterSymbol)
        {
            var parameterName = parameterSymbol.Name;
            if (_typeFactory.TryCreateType(parameterSymbol.Type, out var parameterType))
            {
                return new Parameter(parameterName, null, parameterType, null, ValidationType.None, null);
            }

            // If the parameter type can't be found from type factory, the type was removed from current version
            // Since we don't have the ability to create the missing types, we can't continue to generate overload methods
            return null;
        }
    }
}
