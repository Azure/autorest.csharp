// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using AutoRest.CSharp.Common.Input;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Output.Models
{
    internal static class OperationConfidentChecker
    {
        private static ConcurrentDictionary<InputType, bool> _cache = new();

        public static bool IsConfident(InputOperation operation)
        {
            // check parameters
            foreach (var parameter in operation.Parameters)
            {
                // skip the special parameters since some particular types are still interpreted as unions (for instance content type could have union of literal types which is actually enums)
                if (parameter.IsContentType || parameter.IsApiVersion || parameter.IsEndpoint)
                    continue;

                var isConfident = IsConfident(parameter.Type);
                if (!isConfident)
                    return false;
            }
            // check response
            foreach (var response in operation.Responses)
            {
                var isConfident = IsConfident(response.BodyType);
                if (!isConfident)
                    return false;
            }

            // if no low confident encountered on the way, this is confident, we return true.
            return true;
        }

        private static bool IsConfident(InputType? type)
        {
            if (type == null)
                return true;

            if (_cache.TryGetValue(type, out var result))
                return result;

            var visitedModels = new Dictionary<InputModelType, bool?>();
            result = WalkType(type, visitedModels);

            foreach (var (visitedType, r) in visitedModels)
            {
                Debug.Assert(r != null);
                _cache.TryAdd(visitedType, r.Value);
            }
            if (type is not InputListType or InputDictionaryType)
                _cache.TryAdd(type, result);

            return result;
        }

        private static bool WalkType(InputType type, Dictionary<InputModelType, bool?> visitedModels)
        {
            var isConfident = type switch
            {
                InputModelType modelType => WalkModelType(modelType, visitedModels),
                InputListType listType => WalkType(listType.ElementType, visitedModels),
                InputDictionaryType dictType => WalkType(dictType.KeyType, visitedModels) && WalkType(dictType.ValueType, visitedModels),
                InputLiteralType literalType => WalkLiteralType(literalType),
                InputUnionType unionType => WalkUnionType(unionType),
                _ => true
            };

            return isConfident;
        }

        private static bool WalkModelType(InputModelType type, Dictionary<InputModelType, bool?> visitedModels)
        {
            // check if the type is visited before, if so, there are two cases:
            // 1. it already has a value, true or false, we return that.
            // 2. it is being calculated right now, which means its value now is null (undefined is prohibited by the definition of the interface)
            //    in this case we return true to skip the calculation, because the calculation of `IsConfident` is trying to find if there is a false (we are using && to do that)
            if (visitedModels.TryGetValue(type, out var result))
                return result ?? true;
            visitedModels.Add(type, null);

            var isConfident = type.BaseModel != null ? WalkType(type.BaseModel, visitedModels) : true;
            foreach (var property in type.Properties)
            {
                if (!isConfident)
                    break;
                isConfident = isConfident && WalkType(property.Type, visitedModels);
            }

            // the low confident part in derived types will pollute it back to the base class - if any derived class has low confident part (like union types), we will set the base as "not confident", but other derived types are not affected.
            if (type.DiscriminatorPropertyName != null && type.DerivedModels.Count > 0)
            {
                foreach (var dm in type.DerivedModels)
                {
                    isConfident = isConfident && WalkType(dm, visitedModels);
                }

                // if one of the derived types is not confident, we should make all of them not confident
                if (!isConfident)
                {
                    foreach (var dm in type.DerivedModels)
                    {
                        visitedModels[dm] = isConfident;
                    }
                }
            }

            visitedModels[type] = isConfident;
            return isConfident;
        }

        private static bool WalkLiteralType(InputLiteralType literalType)
        {
            // a literal type is not confident, when we wrap it wiht a number-valued enum without proper names for its enum value items
            if (literalType.LiteralValueType is not InputEnumType enumType)
                return true;

            var isConfident = true;
            foreach (var value in enumType.AllowedValues)
            {
                isConfident = isConfident && SyntaxFacts.IsValidIdentifier(value.Name);
            }

            return isConfident;
        }

        private static bool WalkUnionType(InputUnionType unionType)
        {
            // the union types are always not confident.
            // if any exceptions happen in the future, we could handle it here.
            return false;
        }
    }
}
