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

        private IReadOnlyList<InputModelType> VisitModels(Dictionary<InputType, InputType> typesCache, IReadOnlyList<InputModelType> source)
        {
            var modelCollectionsCache = new Dictionary<InputModelType, ModelCollections>();

            var sourceQueue = new Queue<InputModelType>(source);
            var sourceHashSet = new HashSet<InputModelType>(source);
            while (sourceQueue.Any())
            {
                var sourceModel = sourceQueue.Dequeue();
                var sourceNotNullable = sourceModel.GetNotNullable();
                if (typesCache.ContainsKey(sourceNotNullable))
                {
                    continue;
                }

                while (sourceModel.BaseModel is {} sourceBaseModel)
                {
                    var sourceBaseNotNullable = sourceBaseModel.GetNotNullable();
                    if (typesCache.ContainsKey(sourceBaseNotNullable))
                    {
                        break;
                    }

                    sourceQueue.Enqueue(sourceModel);
                    sourceModel = sourceBaseModel;
                }

                var targetModel = VisitModel(sourceModel, sourceModel.BaseModel is null ? null : (InputModelType?)typesCache[sourceModel.BaseModel]);

                // Skip rebuilding target model if it is the same or another model in source
                if (targetModel == sourceModel)
                {
                    typesCache[sourceNotNullable] = sourceNotNullable;
                    continue;
                }

                if (sourceHashSet.Contains(targetModel))
                {
                    typesCache[sourceNotNullable] = targetModel.GetNotNullable();
                    continue;
                }

                var collections = new ModelCollections(targetModel.Properties, targetModel.DerivedModels, targetModel.CompositionModels, new List<InputModelProperty>(), new List<InputModelType>(), new List<InputModelType>());
                modelCollectionsCache[sourceModel] = collections;

                typesCache[sourceNotNullable] = targetModel with
                {
                    IsNullable = false,
                    Properties = collections.TargetProperties,
                    DerivedModels = collections.TargetDerived,
                    CompositionModels = collections.TargetComposition
                };
            }

            var targetModels = new List<InputModelType>();
            foreach (var sourceModel in source)
            {
                if (modelCollectionsCache.TryGetValue(sourceModel, out var collections))
                {
                    var properties = collections.SourceProperties.Select(p => VisitModelProperty(p, typesCache)).ToList();
                    collections.TargetProperties.AddRange(properties);

                    var derivedModels = collections.SourceDerived.Select(m => (InputModelType)GetTargetType(m, typesCache)).Distinct().ToList();
                    collections.TargetDerived.AddRange(derivedModels);

                    var compositionModels = collections.SourceComposition.Select(m => (InputModelType)GetTargetType(m, typesCache)).Distinct().ToList();
                    collections.TargetComposition.AddRange(compositionModels);
                }

                targetModels.Add((InputModelType)typesCache[sourceModel.GetNotNullable()]);
            }

            return targetModels.Distinct().ToList();
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

        protected virtual InputModelType VisitModel(InputModelType modelType, InputModelType? visitedBaseModel)
            => Equals(visitedBaseModel, modelType.BaseModel) ? modelType : modelType with {BaseModel = visitedBaseModel};

        protected virtual InputModelProperty VisitModelProperty(InputModelProperty sourceModelProperty, IReadOnlyDictionary<InputType, InputType> typesMap)
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

        private record ModelCollections
        (
            IReadOnlyList<InputModelProperty> SourceProperties,
            IReadOnlyList<InputModelType> SourceDerived,
            IReadOnlyList<InputModelType> SourceComposition,
            List<InputModelProperty> TargetProperties,
            List<InputModelType> TargetDerived,
            List<InputModelType> TargetComposition
        );
    }
}
