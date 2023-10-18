// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Output.Models
{
    internal static class OperationConfidenceChecker
    {
        private static ConcurrentDictionary<InputType, ConvenienceMethodConfidenceLevel> _cache = new();

        public static ConvenienceMethodConfidenceLevel GetConfidenceLevel(InputOperation operation, TypeFactory typeFactory)
        {
            var confidenceLevel = ConvenienceMethodConfidenceLevel.Confident;
            // check parameters
            // skip the special parameters since some particular types are still interpreted as unions (for instance content type could have union of literal types which is actually enums)
            foreach (var parameter in operation.Parameters.Where(p => !p.IsContentType && !p.IsApiVersion && !p.IsEndpoint))
            {
                UpdateConfidenceLevel(ref confidenceLevel, GetConfidenceLevel(parameter.Type, typeFactory));

                // escape when the level has been raised to highest
                if (confidenceLevel == ConvenienceMethodConfidenceLevel.Removal)
                    return confidenceLevel;
            }
            // check response
            foreach (var response in operation.Responses)
            {
                UpdateConfidenceLevel(ref confidenceLevel, GetConfidenceLevel(response.BodyType, typeFactory));

                // escape when the level has been raised to highest
                if (confidenceLevel == ConvenienceMethodConfidenceLevel.Removal)
                    return confidenceLevel;
            }

            // if no low confident encountered on the way, this is confident, we return true.
            return confidenceLevel;
        }

        private static void UpdateConfidenceLevel(ref ConvenienceMethodConfidenceLevel current, ConvenienceMethodConfidenceLevel level)
        {
            if (level > current)
                current = level;
        }

        private static ConvenienceMethodConfidenceLevel GetConfidenceLevel(InputType? type, TypeFactory typeFactory)
        {
            if (type == null)
                return ConvenienceMethodConfidenceLevel.Confident;

            if (_cache.TryGetValue(type, out var result))
                return result;

            var visitedModels = new Dictionary<InputModelType, ConvenienceMethodConfidenceLevel?>();
            result = WalkType(type, typeFactory, visitedModels);

            foreach (var (visitedType, r) in visitedModels)
            {
                Debug.Assert(r != null);
                _cache.TryAdd(visitedType, r.Value);
            }
            if (type is not InputListType or InputDictionaryType)
                _cache.TryAdd(type, result);

            return result;
        }

        private static ConvenienceMethodConfidenceLevel WalkType(InputType type, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidenceLevel?> visitedModels)
        {
            if (_cache.TryGetValue(type, out var isConfident))
                return isConfident;

            isConfident = type switch
            {
                InputModelType modelType => WalkModelType(modelType, typeFactory, visitedModels),
                InputListType listType => WalkListType(listType, typeFactory, visitedModels),
                InputDictionaryType dictType => WalkDictionaryType(dictType, typeFactory, visitedModels),
                InputEnumType enumType => WalkEnumType(enumType, typeFactory),
                InputUnionType unionType => WalkUnionType(unionType),
                _ => ConvenienceMethodConfidenceLevel.Confident
            };

            return isConfident;
        }

        private static ConvenienceMethodConfidenceLevel WalkModelType(InputModelType type, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidenceLevel?> visitedModels)
        {
            // check if the type is visited before, if so, there are two cases:
            // 1. it already has a value, true or false, we return that.
            // 2. it is being calculated right now, which means its value now is null (undefined is prohibited by the definition of the interface)
            //    in this case we return true to skip the calculation, because the calculation of `IsConfident` is trying to find if there is a false (we are using && to do that)
            if (visitedModels.TryGetValue(type, out var result))
                return result ?? ConvenienceMethodConfidenceLevel.Confident;
            visitedModels.Add(type, null);

            var confidenceLevel = ConvenienceMethodConfidenceLevel.Confident;
            if (type.IsAnonymousModel) // because the result of this is "Removal", we do not really need to consider customized code for it
            {
                confidenceLevel = ConvenienceMethodConfidenceLevel.Removal;
            }

            if (type.BaseModel != null)
            {
                var baseModelLevel = WalkType(type.BaseModel, typeFactory, visitedModels);
                UpdateConfidenceLevel(ref confidenceLevel, baseModelLevel);
            }

            foreach (var property in type.Properties)
            {
                if (confidenceLevel == ConvenienceMethodConfidenceLevel.Removal)
                    break;

                var propertyLevel = WalkType(property.Type, typeFactory, visitedModels);
                UpdateConfidenceLevel(ref confidenceLevel, propertyLevel);
            }

            // the low confident part in derived types will impact the base class - if any derived class has low confident part (like union types), we will set the base as "not confident", and other derived types must be not confident as well
            if (type.DerivedModels.Count > 0)
            {
                foreach (var dm in type.DerivedModels)
                {
                    var dmLevel = WalkType(dm, typeFactory, visitedModels);

                    UpdateConfidenceLevel(ref confidenceLevel, dmLevel);
                }

                // if one of the derived types is not confident, we should make all of them not confident
                if (confidenceLevel != ConvenienceMethodConfidenceLevel.Confident)
                {
                    foreach (var dm in type.DerivedModels)
                    {
                        visitedModels[dm] = confidenceLevel;
                    }
                }
            }

            visitedModels[type] = confidenceLevel;
            return confidenceLevel;
        }

        private static ConvenienceMethodConfidenceLevel WalkListType(InputListType listType, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidenceLevel?> visitedModels)
            => WalkType(listType.ElementType, typeFactory, visitedModels);

        private static ConvenienceMethodConfidenceLevel WalkDictionaryType(InputDictionaryType dictType, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidenceLevel?> visitedModels)
        {
            var confidenceLevel = ConvenienceMethodConfidenceLevel.Confident;

            var keyLevel = WalkType(dictType.KeyType, typeFactory, visitedModels);
            UpdateConfidenceLevel(ref confidenceLevel, keyLevel);

            var valueLevel = WalkType(dictType.ValueType, typeFactory, visitedModels);
            UpdateConfidenceLevel(ref confidenceLevel, valueLevel);

            return confidenceLevel;
        }

        private static ConvenienceMethodConfidenceLevel WalkEnumType(InputEnumType inputEnumType, TypeFactory typeFactory) => ConvenienceMethodConfidenceLevel.Confident;
        private static ConvenienceMethodConfidenceLevel WalkUnionType(InputUnionType unionType) => ConvenienceMethodConfidenceLevel.Confident;
    }
}
