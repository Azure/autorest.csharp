// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputNamespaceVisitor
    {
        protected virtual InputNamespace VisitNamespace(InputNamespace inputNamespace)
        {
            var typesCache = new Dictionary<InputType, InputType>();

            var enums = VisitEnums(typesCache, inputNamespace.Enums);
            var models = VisitModels(typesCache, inputNamespace.Models);
            var clients = VisitClients(typesCache, inputNamespace.Clients);

            return inputNamespace with
            {
                Clients = clients,
                Models = models,
                Enums = enums,
            };
        }

        private IReadOnlyList<InputEnumType> VisitEnums(Dictionary<InputType, InputType> typesCache, IEnumerable<InputEnumType> source)
        {
            var targetEnums = new List<InputEnumType>();
            foreach (var sourceEnum in source)
            {
                var targetEnum = VisitEnumType(sourceEnum);
                targetEnums.Add(targetEnum);
                typesCache[sourceEnum with {IsNullable = false}] = targetEnum with {IsNullable = false};
            }
            return targetEnums;
        }

        // Models have circular dependencies between them via BaseModel, DerivedModels, and CompositionModels properties
        // Also, some of the InputModelProperty instances may reference InputModelType via Type property
        // To correctly update all the references between models, this method does the following:
        //   1. Sort models by their base models, so that models that have no base models are going first
        //   2. Iterates over models in the said order and calls `VisitModel` for each of them. Resulted models still reference source models at that point, so all references are invalid
        //   3. From the "intermediate" models collected on the previous step, create target models with correct `BaseModel` values and empty lists for DerivedModels, CompositionModels and Properties.
        //      Target model is saved into `typesCache` and added to the returned list.
        //      If `VisitModel` implementation has returned the same intermediate model for more than one source model, target model will be added only once
        //   4. After all target models are created, lists for DerivedModels and CompositionModels are filled.
        //      Also, each property is visited in `VisitModelProperty`, and if InputModelProperty.Type is a model, it must updated it to the target model from `typesCache`.
        private IReadOnlyList<InputModelType> VisitModels(Dictionary<InputType, InputType> typesCache, IReadOnlyList<InputModelType> source)
        {
            var sortedModels = OrderByBaseModel(source);
            var sourceToTargetWihOldReferences = sortedModels.ToDictionary(s => s, s => VisitModel(s).GetNotNullable());

            var targetWithOldReferencesToReferences = new Dictionary<InputModelType, ModelWithReferences>();
            var targetModels = new List<InputModelType>();
            foreach (var sourceModel in sortedModels)
            {
                var targetModelWithOldReferences = sourceToTargetWihOldReferences[sourceModel];
                if (!targetWithOldReferencesToReferences.TryGetValue(targetModelWithOldReferences, out var targetWithReferences))
                {
                    var properties = new List<InputModelProperty>();
                    var derivedModels = new List<InputModelType>();
                    var compositionModels = new List<InputModelType>();
                    var targetBaseModel = sourceModel.BaseModel is {} sourceModelBase ? targetWithOldReferencesToReferences[sourceToTargetWihOldReferences[sourceModelBase]].Target : null;
                    targetWithReferences = new ModelWithReferences
                    (
                        Target: targetModelWithOldReferences with
                        {
                            BaseModel = targetBaseModel,
                            Properties = properties,
                            DerivedModels = derivedModels,
                            CompositionModels = compositionModels
                        },
                        TargetProperties: properties,
                        TargetDerived: derivedModels,
                        TargetComposition: compositionModels
                    );

                    targetWithOldReferencesToReferences[targetModelWithOldReferences] = targetWithReferences;
                    targetModels.Add(targetWithReferences.Target);
                }

                typesCache.Add(sourceModel.GetNotNullable(), targetWithReferences.Target);
            }

            BuildReferencesBetweenModels(typesCache, targetWithOldReferencesToReferences);

            return targetModels;
        }

        private void BuildReferencesBetweenModels(IReadOnlyDictionary<InputType, InputType> typesCache, IReadOnlyDictionary<InputModelType, ModelWithReferences> targetWithOldReferencesToReferences)
        {
            foreach (var (targetModelWithOldReferences, modelWithReferences) in targetWithOldReferencesToReferences)
            {
                var properties = targetModelWithOldReferences.Properties.Select(p => VisitModelProperty(targetModelWithOldReferences, p, typesCache)).ToList();
                modelWithReferences.TargetProperties.AddRange(properties);

                var derivedModels = targetModelWithOldReferences.DerivedModels.Select(m => (InputModelType)GetTargetType(m, typesCache)).Distinct().ToList();
                modelWithReferences.TargetDerived.AddRange(derivedModels);

                var compositionModels = targetModelWithOldReferences.CompositionModels.Select(m => (InputModelType)GetTargetType(m, typesCache)).Distinct().ToList();
                modelWithReferences.TargetComposition.AddRange(compositionModels);
            }
        }

        private static IReadOnlyList<InputModelType> OrderByBaseModel(IReadOnlyList<InputModelType> source)
        {
            var sorted = new List<List<InputModelType>>();

            foreach (var model in source)
            {
                var baseModel = model.BaseModel;
                var depth = 0;
                while (baseModel is not null)
                {
                    depth++;
                    baseModel = baseModel.BaseModel;
                }

                while (sorted.Count <= depth)
                {
                    sorted.Add(new List<InputModelType>());
                }

                sorted[depth].Add(model);
            }

            return sorted.SelectMany(l => l).ToList();
        }

        private IReadOnlyList<InputClient> VisitClients(IReadOnlyDictionary<InputType, InputType> typesCache, IReadOnlyList<InputClient> sourceClients)
            => sourceClients.Select(sourceClient => VisitClient(sourceClient, typesCache)).ToList();

        private IReadOnlyList<InputOperation> VisitOperations(InputClient sourceClient, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            var operationsMap = new Dictionary<InputOperation, Func<InputOperation>>();
            foreach (var sourceOperation in sourceClient.Operations)
            {
                operationsMap.CreateAndCacheResult(sourceOperation, () => VisitOperation(sourceOperation, sourceClient, typesMap, operationsMap));
            }

            return sourceClient.Operations.Select(operation => operationsMap[operation]()).ToList();
        }

        private InputOperation VisitOperation(InputOperation sourceOperation, InputClient sourceClient, IReadOnlyDictionary<InputType, InputType> typesMap, IReadOnlyDictionary<InputOperation, Func<InputOperation>> operationsMap)
        {
            if (sourceOperation.Paging is { NextLinkOperation: { } nextLinkOperation })
            {
                var targetNextLinkOperation = operationsMap[nextLinkOperation]();
                return VisitOperation(sourceOperation, sourceClient, targetNextLinkOperation, typesMap);
            }

            return VisitOperation(sourceOperation, sourceClient, null, typesMap);
        }

        protected virtual InputClient VisitClient(InputClient sourceClient, IReadOnlyDictionary<InputType, InputType> typesMap)
            => sourceClient with
            {
                Parameters = sourceClient.Parameters.Select(p => VisitClientParameter(p, typesMap)).ToList(),
                Operations = VisitOperations(sourceClient, typesMap)
            };

        protected virtual InputOperation VisitOperation(InputOperation sourceOperation, InputClient sourceClient, InputOperation? targetNextLinkOperation, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            return sourceOperation with
            {
                Parameters = VisitOperationParameters(sourceOperation, typesMap, out var parameterMap),
                Responses = sourceOperation.Responses.Select(r => VisitOperationResponse(r, typesMap)).ToList(),
                LongRunning = VisitOperationLongRunning(sourceOperation.LongRunning, typesMap),
                Paging = sourceOperation.Paging is {} sourcePaging ? sourcePaging with {NextLinkOperation = targetNextLinkOperation} : null,
                Examples = VisitOperationParameters(sourceOperation, parameterMap)
            };
        }

        private IReadOnlyList<InputParameter> VisitOperationParameters(InputOperation sourceOperation, IReadOnlyDictionary<InputType, InputType> typesMap, out IDictionary<string, InputParameter> parameterMap)
        {
            var parameters = new List<InputParameter>();
            parameterMap = new Dictionary<string, InputParameter>();
            foreach (var sourceParameter in sourceOperation.Parameters)
            {
                var targetParameter = VisitOperationParameter(sourceParameter, sourceOperation, typesMap);
                parameters.Add(targetParameter);
                parameterMap[sourceParameter.Name] = targetParameter;
            }

            return parameters;
        }

        private IReadOnlyList<InputOperationExample> VisitOperationParameters(InputOperation operation, IDictionary<string, InputParameter> parameterMap)
        {
            var operationExamples = new List<InputOperationExample>(operation.Examples.Count);
            foreach (var operationExample in operation.Examples)
            {
                var parameterExamples = operationExample.Parameters.Select(pe => pe with { Parameter = parameterMap[pe.Parameter.Name] }).ToList();
                operationExamples.Add(operationExample with {Parameters = parameterExamples});
            }
            return operationExamples;
        }

        protected virtual InputEnumType VisitEnumType(InputEnumType enumType) => enumType;

        protected virtual InputModelType VisitModel(InputModelType modelType) => modelType;

        protected virtual InputModelProperty VisitModelProperty(InputModelType model, InputModelProperty sourceModelProperty, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            var targetType = GetTargetType(sourceModelProperty.Type, typesMap);
            return targetType.Equals(sourceModelProperty.Type) ? sourceModelProperty : sourceModelProperty with { Type = targetType };
        }

        protected virtual InputParameter VisitClientParameter(InputParameter sourceParameter, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            var targetType = GetTargetType(sourceParameter.Type, typesMap);
            return targetType.Equals(sourceParameter.Type) ? sourceParameter : sourceParameter with { Type = targetType };
        }

        protected virtual InputParameter VisitOperationParameter(InputParameter sourceParameter, InputOperation sourceOperation, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            var targetType = GetTargetType(sourceParameter.Type, typesMap);
            return targetType.Equals(sourceParameter.Type) ? sourceParameter :sourceParameter with { Type = targetType };
        }

        protected virtual OperationResponse VisitOperationResponse(OperationResponse sourceResponse, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            if (sourceResponse.BodyType is null)
            {
                return sourceResponse;
            }

            var targetBodyType = GetTargetType(sourceResponse.BodyType, typesMap);
            return targetBodyType.Equals(sourceResponse.BodyType) ? sourceResponse : sourceResponse with { BodyType = GetTargetType(sourceResponse.BodyType, typesMap) };
        }

        protected virtual OperationLongRunning? VisitOperationLongRunning(OperationLongRunning? sourceLro, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            if (sourceLro is null)
            {
                return null;
            }

            var targetResponse = VisitOperationResponse(sourceLro.FinalResponse, typesMap);
            return targetResponse.Equals(sourceLro.FinalResponse) ? sourceLro : sourceLro with { FinalResponse = targetResponse };
        }

        private static InputType GetTargetType(InputType sourceType, IReadOnlyDictionary<InputType, InputType> typesMap)
        {
            if (sourceType.IsNullable)
            {
                return GetTargetType(sourceType with { IsNullable = false }, typesMap) with { IsNullable = true };
            }

            return sourceType switch
            {
                InputDictionaryType dictionaryType => dictionaryType with
                {
                    KeyType = GetTargetType(dictionaryType.KeyType, typesMap),
                    ValueType = GetTargetType(dictionaryType.ValueType, typesMap)
                },
                InputEnumType => typesMap[sourceType],
                InputModelType => typesMap[sourceType],
                InputListType listType => listType with
                {
                    ElementType = GetTargetType(listType.ElementType, typesMap)
                },

                InputUnionType unionType => unionType with
                {
                    UnionItemTypes = unionType.UnionItemTypes.Select(t => GetTargetType(t, typesMap)).ToList()
                },
                _ => typesMap.TryGetValue(sourceType, out var targetType) ? targetType : sourceType
            };
        }

        private record ModelWithReferences
        (
            InputModelType Target,
            //IReadOnlyList<InputModelProperty> SourceProperties,
            //IReadOnlyList<InputModelType> SourceDerived,
            //IReadOnlyList<InputModelType> SourceComposition,
            List<InputModelProperty> TargetProperties,
            List<InputModelType> TargetDerived,
            List<InputModelType> TargetComposition
        );
    }
}
