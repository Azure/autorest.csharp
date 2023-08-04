// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input
{
    internal record InputModelType(string Name, string? Namespace, string? Accessibility, string? Deprecated, string? Description, InputModelTypeUsage Usage, IReadOnlyList<InputModelProperty> Properties, InputModelType? BaseModel, IReadOnlyList<InputModelType> DerivedModels, string? DiscriminatorValue, string? DiscriminatorPropertyName, InputDictionaryType? InheritedDictionaryType, InputModelTypeSerializationFormat SerializationFormat = InputModelTypeSerializationFormat.Json)
        : InputType(Name)
    {
        /// <summary>
        /// Indicates if this model is the Unknown derived version of a model with discriminator
        /// </summary>
        public bool IsUnknownDiscriminatorModel { get; init; } = false;
        /// <summary>
        /// Indicates if this model is a property bag
        /// </summary>
        public bool IsPropertyBag { get; init; } = false;

        public IEnumerable<InputModelType> GetSelfAndBaseModels() => EnumerateBase(this);

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
