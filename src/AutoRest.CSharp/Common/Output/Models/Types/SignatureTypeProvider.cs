// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Humanizer;
using Microsoft.CodeAnalysis;
using MethodParameter = AutoRest.CSharp.Output.Models.Shared.Parameter;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class SignatureTypeProvider : TypeProvider
    {
        private SourceInputModel? _sourceInputModel;

        protected SignatureTypeProvider(string defaultNamespace, string defaultName, IList<MethodSignature> methods, SourceInputModel? sourceInputModel = null) : base(defaultNamespace, sourceInputModel)
        {
            DefaultName = defaultName;
            DefaultAccessibility = "public";
            Methods = methods;
            _sourceInputModel = sourceInputModel;
        }

        private SignatureTypeProvider? _customization;
        protected SignatureTypeProvider? Customization => _customization ??= CreateFromCompilation(_sourceInputModel?.Customization);

        private SignatureTypeProvider? _previousContract;
        protected SignatureTypeProvider? PreviousContract => _previousContract ??= CreateFromCompilation(_sourceInputModel?.PreviousContract);

        // TODO: store the implementation of missing methods along with declaration
        public virtual IList<MethodSignature> Methods { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; }

        public IList<(MethodSignature CurrentMethodToCall, MethodSignature PreviousMethodToAdd, IList<MethodParameter> MissingParameters)> MissingOverloadMethods
        {
            get
            {
                if (Methods != null && PreviousContract != null && PreviousContract.Methods != null)
                {
                    IList<MethodSignature> missing;
                    IList<(MethodSignature, MethodSignature, IList<MethodParameter>)> updated;
                    if (Customization != null && Customization.Methods != null)
                    {
                        (missing, updated) = CompareMethods(Methods.Union(Customization!.Methods), PreviousContract.Methods);
                    }
                    else
                    {
                        (missing, updated) = CompareMethods(Methods, PreviousContract!.Methods);
                    }
                    return updated;
                }
                return Array.Empty<(MethodSignature, MethodSignature, IList<MethodParameter>)>();
            }
        }

        protected (IList<MethodSignature> MissingMethods, IList<(MethodSignature CurrentMethodToCall, MethodSignature PreviousMethodToAdd, IList<MethodParameter> MissingParameters)> UpdatedMethods)
            CompareMethods(IEnumerable<MethodSignature> currentMethods, IEnumerable<MethodSignature> previousMethods)
        {
            var missing = new List<MethodSignature>();
            var updated = new List<(MethodSignature, MethodSignature, IList<MethodParameter>)>();
            var set = currentMethods.ToHashSet(new MethodSignatureComparer());
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
                    if (dict.TryGetValue(item.Name, out var current))
                    {
                        if (TryGetPreviousMethodWithLessOptionalParameters(current, item, out var currentMethodToCall, out var missingParameters))
                        {
                            updated.Add((currentMethodToCall, item, missingParameters));
                        }
                    }
                    else
                    {
                        missing.Add(item);
                    }
                }
            }
            return (missing, updated);
        }

        private bool TryGetPreviousMethodWithLessOptionalParameters(IList<MethodSignature> currentMethods, MethodSignature previousMethod, [NotNullWhen(true)] out MethodSignature? currentMethodToCall, [NotNullWhen(true)] out IList<MethodParameter>? missingParameters)
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

                var parameters = item.Parameters.Except(previousMethod.Parameters, new ParameterComparer());
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

        private SignatureTypeProvider? CreateFromCompilation(Compilation? compilation)
        {
            if (compilation is null)
            {
                return null;
            }
            var type = compilation.Assembly.GetTypeByMetadataName($"{DefaultNamespace}.{DefaultName}");
            if (type is null)
            {
                return null;
            }
            return new SignatureTypeProvider(DefaultNamespace, DefaultName, MethodSignature.PopulateMethods(type));
        }

        private bool CurrentContainAllPreviousParameters(MethodSignature previousMethod, MethodSignature currentMethod)
        {
            var set = currentMethod.Parameters.ToHashSet(new ParameterComparer());
            foreach (var parameter in previousMethod.Parameters)
            {
                if (!set.Contains(parameter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
