// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    /// <summary>
    /// Since we changed quite a few names of the schemas inside the code model after the modeler parses the model,
    /// it is very possible that in the schemas, there are schemas with the same name.
    /// These scheams with the same name must be resolved, otherwise we will get ArgumentException when adding schemas to the `LookupDictionary`.
    /// </summary>
    internal static class DuplicateSchemaResolver
    {
        public static void ResolveDuplicates(InputNamespace inputNamespace)
        {
            // step 1: categorize the schema by their names
            var modelNameDict = new Dictionary<string, HashSet<InputModelType>>();
            var enumNameDict = new Dictionary<string, HashSet<InputEnumType>>();
            foreach (var model in inputNamespace.Models)
            {
                modelNameDict.AddInList(model.Name, model);
            }

            // for simplicity, if any duplciated InputModelType, we just throw exception. We should never use this to combine models - maybe we could add the support in the future? If needed.
            var duplicatedModels = modelNameDict.Values.Where(l => l.Count > 1);
            if (duplicatedModels.Any())
                throw new InvalidOperationException($"There are duplicated models and there is at least 2 models naming `{duplicatedModels.First().First().Name}`, this is not allowed (for now)");

            foreach (var enumType in inputNamespace.Enums)
            {
                enumNameDict.AddInList(enumType.Name, enumType);
            }

            // step 2: collapse the schemas with the same name
            foreach (var schemas in enumNameDict.Values.Where(l => l.Count > 1))
            {
                CollapseMultipleSchemas(schemas, inputNamespace);
            }
        }

        private static void CollapseMultipleSchemas(HashSet<InputEnumType> models, InputNamespace inputNamespace)
        {
            // now all things in the list should be Choices or SealedChoices
            var collapsedEnum = CollapseChoices(models);
            // now we need to update everything which is referencing the schemas in the list to the new schema
            ReplaceSchemas(models, collapsedEnum, inputNamespace);
        }

        private static void ReplaceSchemas(HashSet<InputEnumType> enums, InputEnumType replaceEnum, InputNamespace inputNamespace)
        {
            // remove the things that should be replaced by the replaceSchmea
            foreach (var inputEnum in enums)
            {
                if (inputEnum == replaceEnum)
                    continue;

                inputNamespace.Enums.Remove(inputEnum);
            }

            // we have to iterate everything on the code model
            foreach (var model in inputNamespace.Models)
            {
                foreach (var property in model.Properties)
                {
                    if (enums.Contains(property.Type))
                        property.Type = replaceEnum;
                }
            }

            // we also have to iterate all operations
            foreach (var client in inputNamespace.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    foreach (var operationResponse in operation.Responses)
                    {
                        ReplaceResponseSchema(enums, operationResponse, replaceEnum);
                    }

                    foreach (var parameter in operation.Parameters)
                    {
                        ReplaceRequestParamSchema(enums, parameter, replaceEnum);
                    }
                }
            }
        }

        private static void ReplaceResponseSchema(HashSet<InputEnumType> schemas, OperationResponse? response, InputEnumType replaceEnum)
        {
            if (response is null || response?.BodyType is null)
                return;
            if (response.BodyType.GetImplementType() is InputEnumType responseType)
            {
                if (schemas.Contains(responseType.GetImplementType()))
                    response.BodyType = response.BodyType.SetImplementType(replaceEnum);
            }
        }

        private static void ReplaceRequestParamSchema(HashSet<InputEnumType> eunms, InputParameter parameter, InputEnumType replaceEnum)
        {
            if (parameter.Type.GetImplementType() is InputEnumType)
                if (eunms.Contains(parameter.Type.GetImplementType()))
                    parameter.Type = parameter.Type.SetImplementType(replaceEnum);
        }

        private static InputEnumType CollapseChoices(IEnumerable<InputEnumType> enums)
        {
            var choiceValuesList = enums.Select(x => x.Values.Select(v => v.GetValueString()).OrderBy(v => v));
            // determine if the choices in this list are the same
            var deduplicated = choiceValuesList.ToHashSet(new CollectionComparer());
            if (deduplicated.Count == 1)
            {
                // this means all the choices in the in-coming list are the same
                return enums.First();
            }

            // otherwise throw exception to say we have unresolvable duplicated InputEnumType after our renaming
            var listStrings = deduplicated.Select(list => $"[{string.Join(", ", list)}]");
            throw new InvalidOperationException($"We have unresolvable duplicated enums. These are: {string.Join(", ", listStrings)}");
        }

        private struct CollectionComparer : IEqualityComparer<IOrderedEnumerable<string>>
        {
            public bool Equals([AllowNull] IOrderedEnumerable<string> x, [AllowNull] IOrderedEnumerable<string> y)
            {
                if (x == null && y == null)
                    return true;
                if (x == null || y == null)
                    return false;
                return x.SequenceEqual(y);
            }

            public int GetHashCode([DisallowNull] IOrderedEnumerable<string> obj)
            {
                return string.Join("", obj).GetHashCode();
            }
        }
    }
}
