// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input
{
    internal record InputModelType(string Name, string? Namespace, string? Accessibility, string? Deprecated, string? Description, InputModelTypeUsage Usage, IReadOnlyList<InputModelProperty> Properties, InputModelType? BaseModel, IReadOnlyList<InputModelType> DerivedModels, string? DiscriminatorValue, string? DiscriminatorPropertyName, bool IsNullable)
        : InputType(Name, IsNullable)
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

        public IEnumerable<InputModelType> GetAllBaseModels() => EnumerateBase(BaseModel);

        public IReadOnlyList<InputModelType> GetAllDerivedModels()
        {
            var list = new List<InputModelType>(DerivedModels);
            for (var i = 0; i < list.Count; i++)
            {
                list.AddRange(list[i].DerivedModels);
            }

            return list;
        }

        private static IEnumerable<InputModelType> EnumerateBase(InputModelType? model)
        {
            while (model != null)
            {
                yield return model;
                model = model.BaseModel;
            }
        }

        internal InputModelType Update(string newName, InputModelTypeUsage usage)
        {
            return new InputModelType(
                newName,
                Namespace,
                Accessibility,
                Deprecated,
                Description,
                usage,
                Properties,
                BaseModel,
                DerivedModels,
                DiscriminatorValue,
                DiscriminatorPropertyName,
                IsNullable);
        }

        internal InputModelType ReplaceProperty(InputModelProperty property, InputType inputType)
        {
            return new InputModelType(
                Name,
                Namespace,
                Accessibility,
                Deprecated,
                Description,
                Usage,
                GetNewProperties(property, inputType),
                BaseModel,
                DerivedModels,
                DiscriminatorValue,
                DiscriminatorPropertyName,
                IsNullable);
        }

        private IReadOnlyList<InputModelProperty> GetNewProperties(InputModelProperty property, InputType inputType)
        {
            List<InputModelProperty> properties = new List<InputModelProperty>();
            foreach (var myProperty in Properties)
            {
                if (myProperty.Equals(property))
                {
                    properties.Add(new InputModelProperty(
                        myProperty.Name,
                        myProperty.SerializedName,
                        myProperty.Description,
                        myProperty.Type.GetCollectionEquivalent(inputType),
                        myProperty.IsRequired,
                        myProperty.IsReadOnly,
                        myProperty.IsDiscriminator));
                }
                else
                {
                    properties.Add(myProperty);
                }
            }
            return properties;
        }

        public bool Equals(InputType other, bool handleCollections)
        {
            if (!handleCollections)
                return Equals(other);

            switch (other)
            {
                case InputDictionaryType otherDictionary:
                    return Equals(otherDictionary.ValueType);
                case InputListType otherList:
                    return Equals(otherList.ElementType);
                default:
                    return Equals(other);
            }
        }

        internal InputModelProperty? GetProperty(InputModelType key)
        {
            foreach (var property in Properties)
            {
                if (key.Equals(property.Type, true))
                    return property;
            }
            return null;
        }
    }
}
