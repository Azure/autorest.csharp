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

        public IEnumerable<InputModelType> GetSelfAndBaseModels() => EnumerateBase(this);

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

        internal static InputModelType GiveName(InputModelType model, string? newName)
        {
            if (newName is null)
                return model;

            return new InputModelType(
                newName,
                model.Namespace,
                model.Accessibility,
                model.Deprecated,
                model.Description,
                model.Usage,
                model.Properties,
                model.BaseModel,
                model.DerivedModels,
                model.DiscriminatorValue,
                model.DiscriminatorPropertyName,
                model.IsNullable);
        }

        internal InputModelType ReplaceProperty(InputModelProperty property, InputEnumType enumType)
        {
            return new InputModelType(
                Name,
                Namespace,
                Accessibility,
                Deprecated,
                Description,
                Usage,
                GetNewProperties(property, enumType),
                BaseModel,
                DerivedModels,
                DiscriminatorValue,
                DiscriminatorPropertyName,
                IsNullable);
        }

        private IReadOnlyList<InputModelProperty> GetNewProperties(InputModelProperty property, InputEnumType enumType)
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
                        enumType,
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
    }
}
