// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input
{
    internal record InputModelType(string Name, string? Namespace, string? Accessibility, string? Deprecated, string? Description, InputModelTypeUsage Usage, IReadOnlyList<InputModelProperty> Properties, InputModelType? BaseModel, IReadOnlyList<InputModelType> DerivedModels, string? DiscriminatorValue, string? DiscriminatorPropertyName, InputDictionaryType? InheritedDictionaryType, bool IsNullable, bool IsEmpty = false, string? OriginalName = default)
        : InputType(Name, IsNullable, OriginalName)
    {
        /// <summary>
        /// Indicates if this model is the Unknown derived version of a model with discriminator
        /// </summary>
        public bool IsUnknownDiscriminatorModel { get; init; } = false;
        /// <summary>
        /// Indicates if this model is a property bag
        /// </summary>
        public bool IsPropertyBag { get; init; } = false;

        public bool IsAnonymousModel { get; init; } = false;

        /// <summary>
        /// Types provided as immediate parents in spec that aren't base model
        /// </summary>
        public IReadOnlyList<InputModelType> CompositionModels { get; init; } = Array.Empty<InputModelType>();

        public IEnumerable<InputModelType> GetSelfAndBaseModels() => EnumerateBase(this);

        public InputModelType GetNotNullable() => IsNullable ? this with { IsNullable = false } : this;

        private static IEnumerable<InputModelType> EnumerateBase(InputModelType? model)
        {
            while (model != null)
            {
                yield return model;
                model = model.BaseModel;
            }
        }
    }
}
