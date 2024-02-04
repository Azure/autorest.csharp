// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    /// <summary>
    /// This type holds three portions of codes:
    ///     - current
    ///     - custom
    ///     - baseline contract
    ///     current union custom compare with baseline contract outputs the changeset, we can apply different rules with it.
    /// </summary>
    internal class BreakingChangeResolver
    {
        private readonly SignatureType _customizationType;
        private readonly SignatureType _baselineContractType;
        private IEnumerable<MethodSignature>? _generatedMethods;
        private MethodChangeset? _methodChangeset;

        /// <summary>
        /// Tracks the changeset of methods between the currently generated methods, and the methods read from the baseline contract
        /// </summary>
        /// <param name="Missing"> The methods with the same name but missing from the previous contract. </param>
        /// <param name="Updated"> The methods with the same name are updated in the current contract, and the list contains the previous method and current methods including overload ones. </param>
        private record MethodChangeset(IReadOnlyList<MethodSignature> Missing, IReadOnlyList<UpdatedMethod> Updated);

        /// <summary>
        /// Tracks how the method is updated comparing with the method from the baseline contract
        /// </summary>
        /// <param name="Current"></param>
        /// <param name="Previous"></param>
        private record UpdatedMethod(IReadOnlyList<MethodSignature> Current, MethodSignature Previous);

        public BreakingChangeResolver(TypeFactory typeFactory, SourceTypeMapping? sourceTypeMapping, SourceTypeMapping? contractTypeMapping)
        {
            _customizationType = new SignatureType(typeFactory, sourceTypeMapping);
            _baselineContractType = new SignatureType(typeFactory, contractTypeMapping);
        }

        public void Build(IEnumerable<MethodSignature> generatedMethods)
        {
            if (_generatedMethods is not null)
            {
                throw new InvalidOperationException($"{nameof(BreakingChangeResolver)} could only be built once.");
            }
            _generatedMethods = generatedMethods;
            _methodChangeset = CompareMethods(generatedMethods.Union(_customizationType.Methods, MethodSignature.ParameterAndReturnTypeEqualityComparer), _baselineContractType.Methods);
        }

        private IReadOnlyList<Method>? _overloadMethods;
        public IReadOnlyList<Method> OverloadMethods => _overloadMethods ??= EnsureOverloadMethods();

        private IReadOnlyList<Method> EnsureOverloadMethods()
        {
            var overloadMethods = new List<Method>();
            if (_methodChangeset?.Updated is not { } updated)
            {
                return Array.Empty<Method>();
            }

            foreach (var (current, previous) in updated)
            {
                if (TryGetPreviousMethodWithLessOptionalParameters(current, previous, out var currentMethodToCall, out var missingParameters))
                {
                    var overloadMethodSignature = new OverloadMethodSignature(currentMethodToCall, previous.WithParametersRequired(), missingParameters, previous.Description);
                    var previousMethodSignature = overloadMethodSignature.PreviousMethodSignature with { Attributes = new CSharpAttribute[] { new CSharpAttribute(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never)) } };
                    overloadMethods.Add(new Method(previousMethodSignature, BuildOverloadMethodBody(overloadMethodSignature)));
                }
            }
            return overloadMethods;
        }

        private MethodBodyStatement BuildOverloadMethodBody(OverloadMethodSignature overloadMethodSignature)
            => Return(new InvokeInstanceMethodExpression(null, overloadMethodSignature.MethodSignature.Name, BuildOverloadMethodParameters(overloadMethodSignature), null, overloadMethodSignature.PreviousMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Async)));

        private IReadOnlyList<ValueExpression> BuildOverloadMethodParameters(OverloadMethodSignature overloadMethodSignature)
        {
            var parameters = new List<ValueExpression>();
            var set = overloadMethodSignature.MissingParameters.ToHashSet(Parameter.TypeAndNameEqualityComparer);
            foreach (var parameter in overloadMethodSignature.MethodSignature.Parameters)
            {
                if (set.Contains(parameter))
                {
                    parameters.Add(new PositionalParameterReference(parameter.Name, Default.CastTo(parameter.Type)));
                    continue;
                }
                parameters.Add(new PositionalParameterReference(parameter));
            }
            return parameters;
        }

        private IReadOnlySet<MethodSignature>? _methodsToSkip;
        public IReadOnlySet<MethodSignature> MethodsToSkip => _methodsToSkip ??= EnsureMethodsToSkip();
        private IReadOnlySet<MethodSignature> EnsureMethodsToSkip()
        {
            if (_generatedMethods == null)
            {
                throw new InvalidOperationException($"{nameof(BreakingChangeResolver)} has not been built yet.");
            }
            return _generatedMethods.Intersect(_customizationType.Methods, MethodSignature.ParameterAndReturnTypeEqualityComparer).ToHashSet(MethodSignature.ParameterAndReturnTypeEqualityComparer);
        }

        private bool TryGetPreviousMethodWithLessOptionalParameters(IReadOnlyList<MethodSignature> currentMethods, MethodSignature previousMethod, [NotNullWhen(true)] out MethodSignature? currentMethodToCall, [NotNullWhen(true)] out IReadOnlyList<Parameter>? missingParameters)
        {
            foreach (var item in currentMethods)
            {
                if (item.Parameters.Count <= previousMethod.Parameters.Count)
                {
                    continue;
                }

                if (!CurrentContainAllPreviousParameters(previousMethod, item))
                {
                    continue;
                }

                if (previousMethod.ReturnType is null && item.ReturnType is not null)
                {
                    continue;
                }

                // We can't use CsharpType.Equals here because they could have different implementations from different versions
                if (previousMethod.ReturnType is not null && !previousMethod.ReturnType.EqualsByName(item.ReturnType))
                {
                    continue;
                }

                var parameters = item.Parameters.Except(previousMethod.Parameters, Parameter.TypeAndNameEqualityComparer);
                if (parameters.All(x => x.IsOptionalInSignature))
                {
                    missingParameters = parameters.ToList();
                    currentMethodToCall = item;
                    return true;
                }
            }
            missingParameters = null;
            currentMethodToCall = null;
            return false;
        }

        private bool CurrentContainAllPreviousParameters(MethodSignature previousMethod, MethodSignature currentMethod)
        {
            var set = currentMethod.Parameters.ToHashSet(Parameter.TypeAndNameEqualityComparer);
            foreach (var parameter in previousMethod.Parameters)
            {
                if (!set.Contains(parameter))
                {
                    return false;
                }
            }
            return true;
        }

        private static MethodChangeset? CompareMethods(IEnumerable<MethodSignature> currentMethods, IEnumerable<MethodSignature>? previousMethods)
        {
            if (previousMethods is null)
            {
                return null;
            }
            var missing = new List<MethodSignature>();
            var updated = new List<UpdatedMethod>();
            var set = currentMethods.ToHashSet(MethodSignature.ParameterAndReturnTypeEqualityComparer);
            var dict = new Dictionary<string, List<MethodSignature>>();
            foreach (var item in currentMethods)
            {
                if (!dict.TryGetValue(item.Name, out var list))
                {
                    dict.Add(item.Name, new List<MethodSignature> { item });
                }
                else
                {
                    list.Add(item);
                }
            }
            foreach (var item in previousMethods)
            {
                if (!set.Contains(item))
                {
                    if (dict.TryGetValue(item.Name, out var currentOverloadMethods))
                    {
                        updated.Add(new(currentOverloadMethods, item));
                    }
                    else
                    {
                        missing.Add(item);
                    }
                }
            }
            return new(missing, updated);
        }
    }
}
