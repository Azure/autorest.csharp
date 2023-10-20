// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class MergeDerivedModelsVisitor : InputNamespaceVisitor
    {
        private readonly IReadOnlyDictionary<InputModelType, InputModelType> _modelsToReplace;
        private readonly HashSet<InputModelType> _baseModelsToUpdate;

        private MergeDerivedModelsVisitor(IReadOnlyDictionary<InputModelType, InputModelType> modelsToReplace)
        {
            _modelsToReplace = modelsToReplace;
            _baseModelsToUpdate = modelsToReplace.Keys.Select(k => k.BaseModel!).Distinct().ToHashSet();
        }

        public static InputNamespace Visit(InputNamespace rootNamespace)
        {
            if (rootNamespace.Models.All(static m => m.BaseModel is not {} bm || bm.DerivedModels.Contains(m)))
            {
                return rootNamespace;
            }

            Debugger.Launch();
            var modelsToReplace = rootNamespace.Models
                .Where(static m => m.BaseModel is { } bm && !bm.DerivedModels.Contains(m))
                .ToDictionary(GetMatchingModelToReplace, static m => m);

            rootNamespace = rootNamespace with { Models = rootNamespace.Models.Concat(modelsToReplace.Keys).ToList() };
            return new MergeDerivedModelsVisitor(modelsToReplace).VisitNamespace(rootNamespace);
        }

        private static InputModelType GetMatchingModelToReplace(InputModelType model)
            => model.BaseModel!.DerivedModels.First(dm => dm.Name == model.Name && dm.Namespace == model.Namespace);

        protected override InputModelType VisitModel(InputModelType modelType, InputModelType? visitedBaseModel)
        {
            if (_modelsToReplace.TryGetValue(modelType, out var replacement))
            {
                return base.VisitModel(replacement, visitedBaseModel);
            }

            if (!_baseModelsToUpdate.Contains(modelType))
            {
                return base.VisitModel(modelType, visitedBaseModel);
            }

            var derivedModels = modelType.DerivedModels.Select(m => _modelsToReplace.TryGetValue(m, out var rm) ? rm : m).ToList();
            return base.VisitModel(modelType with { DerivedModels = derivedModels }, visitedBaseModel);

        }
    }
}
