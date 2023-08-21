// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal static class OperationConfidentChecker
    {
        private static ConcurrentDictionary<InputType, ConvenienceMethodConfidentLevel> _cache = new();

        public static ConvenienceMethodConfidentLevel GetConfidentLevel(InputOperation operation, TypeFactory typeFactory)
        {
            var confidentLevel = ConvenienceMethodConfidentLevel.Confident;
            // check parameters
            // skip the special parameters since some particular types are still interpreted as unions (for instance content type could have union of literal types which is actually enums)
            foreach (var parameter in operation.Parameters.Where(p => !p.IsContentType && !p.IsApiVersion && !p.IsEndpoint))
            {
                var level = GetConfidentLevel(parameter.Type, typeFactory);
                if (level > confidentLevel)
                    confidentLevel = level;

                // escape when the level has been raised to highest
                if (confidentLevel == ConvenienceMethodConfidentLevel.Removal)
                    return confidentLevel;
            }
            // check response
            foreach (var response in operation.Responses)
            {
                var level = GetConfidentLevel(response.BodyType, typeFactory);
                if (level > confidentLevel)
                    confidentLevel = level;

                // escape when the level has been raised to highest
                if (confidentLevel == ConvenienceMethodConfidentLevel.Removal)
                    return confidentLevel;
            }

            // if no low confident encountered on the way, this is confident, we return true.
            return confidentLevel;
        }

        private static ConvenienceMethodConfidentLevel GetConfidentLevel(InputType? type, TypeFactory typeFactory)
        {
            if (type == null)
                return ConvenienceMethodConfidentLevel.Confident;

            if (_cache.TryGetValue(type, out var result))
                return result;

            var visitedModels = new Dictionary<InputModelType, ConvenienceMethodConfidentLevel?>();
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

        private static ConvenienceMethodConfidentLevel WalkType(InputType type, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidentLevel?> visitedModels)
        {
            if (_cache.TryGetValue(type, out var isConfident))
                return isConfident;

            isConfident = type switch
            {
                InputModelType modelType => WalkModelType(modelType, typeFactory, visitedModels),
                InputListType listType => WalkListType(listType, typeFactory, visitedModels),
                InputDictionaryType dictType => WalkDictionaryType(dictType, typeFactory, visitedModels),
                InputLiteralType literalType => WalkLiteralType(literalType, typeFactory),
                InputUnionType unionType => WalkUnionType(unionType),
                _ => ConvenienceMethodConfidentLevel.Confident
            };

            return isConfident;
        }

        private static ConvenienceMethodConfidentLevel WalkModelType(InputModelType type, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidentLevel?> visitedModels)
        {
            // check if the type is visited before, if so, there are two cases:
            // 1. it already has a value, true or false, we return that.
            // 2. it is being calculated right now, which means its value now is null (undefined is prohibited by the definition of the interface)
            //    in this case we return true to skip the calculation, because the calculation of `IsConfident` is trying to find if there is a false (we are using && to do that)
            if (visitedModels.TryGetValue(type, out var result))
                return result ?? ConvenienceMethodConfidentLevel.Confident;
            visitedModels.Add(type, null);

            var confidentLevel = ConvenienceMethodConfidentLevel.Confident;
            var model = typeFactory.CreateType(type);
            if (IsUnreasonableName(model.Name))
            {
                confidentLevel = ConvenienceMethodConfidentLevel.Removal;
            }

            if (type.BaseModel != null)
            {
                confidentLevel = WalkType(type.BaseModel, typeFactory, visitedModels);
            }

            foreach (var property in type.Properties)
            {
                if (confidentLevel == ConvenienceMethodConfidentLevel.Removal)
                    break;
                var propertyLevel = WalkType(property.Type, typeFactory, visitedModels);
                if (propertyLevel > confidentLevel)
                    confidentLevel = propertyLevel;
            }

            // the low confident part in derived types will impact the base class - if any derived class has low confident part (like union types), we will set the base as "not confident", and other derived types must be not confident as well
            if (type.DerivedModels.Count > 0)
            {
                foreach (var dm in type.DerivedModels)
                {
                    var dmLevel = WalkType(dm, typeFactory, visitedModels);
                    if (dmLevel > confidentLevel)
                        confidentLevel = dmLevel;
                }

                // if one of the derived types is not confident, we should make all of them not confident
                if (confidentLevel != ConvenienceMethodConfidentLevel.Confident)
                {
                    foreach (var dm in type.DerivedModels)
                    {
                        visitedModels[dm] = confidentLevel;
                    }
                }
            }

            visitedModels[type] = confidentLevel;
            return confidentLevel;
        }

        private static ConvenienceMethodConfidentLevel WalkListType(InputListType listType, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidentLevel?> visitedModels)
            => WalkType(listType.ElementType, typeFactory, visitedModels);

        private static ConvenienceMethodConfidentLevel WalkDictionaryType(InputDictionaryType dictType, TypeFactory typeFactory, Dictionary<InputModelType, ConvenienceMethodConfidentLevel?> visitedModels)
        {
            var keyLevel = WalkType(dictType.KeyType, typeFactory, visitedModels);

            var valueLevel = WalkType(dictType.ValueType, typeFactory, visitedModels);

            return keyLevel > valueLevel ? keyLevel : valueLevel;
        }

        private static ConvenienceMethodConfidentLevel WalkLiteralType(InputLiteralType literalType, TypeFactory typeFactory)
        {
            // a literal type is not confident, when we wrap it wiht a number-valued enum without proper names for its enum value items
            if (literalType.LiteralValueType is not InputEnumType enumType)
                return ConvenienceMethodConfidentLevel.Confident;

            var isConfident = true;
            var csharpType = typeFactory.CreateType(enumType);
            if (csharpType is { IsFrameworkType: false, Implementation: EnumType @enum })
            {
                foreach (var value in @enum.Values)
                {
                    // this checks if the enum value is properly named. Numbers like `1` or `3.14` will return false, which is considered as "not properly named" thus not confident.
                    if (IsUnreasonableName(value.Declaration.Name))
                    {
                        isConfident = false;
                        break;
                    }
                }
            }

            return isConfident ? ConvenienceMethodConfidentLevel.Confident : ConvenienceMethodConfidentLevel.Internal;
        }

        private static ConvenienceMethodConfidentLevel WalkUnionType(InputUnionType unionType)
        {
            // the union types are always not confident.
            // if any exceptions happen in the future, we could handle it here.
            return ConvenienceMethodConfidentLevel.Internal;
        }

        private static bool IsUnreasonableName(string name) => name.StartsWith('_');
    }

    internal enum ConvenienceMethodConfidentLevel : int
    {
        Confident = 0,
        Internal = 1,
        Removal = 2
    }
}
