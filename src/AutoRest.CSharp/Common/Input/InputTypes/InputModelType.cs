// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputModelType(string Name, string? Namespace, string? Accessibility, string? Deprecated, string? Description, InputModelTypeUsage Usage, IReadOnlyList<IModelProperty> Properties, IModelType? BaseModel, IReadOnlyList<IModelType> DerivedModels, string? DiscriminatorValue, string? DiscriminatorPropertyName, IDictionaryType? InheritedDictionaryType, bool IsNullable)
    : InputType(Name, IsNullable), IModelType
{
    /// <summary>
    /// Indicates if this model is the Unknown derived version of a model with discriminator
    /// </summary>
    public bool IsUnknownDiscriminatorModel { get; init; } = false;
    /// <summary>
    /// Indicates if this model is a property bag
    /// </summary>
    public bool IsPropertyBag { get; init; } = false;

    public IModelType? BaseModel { get; internal set; } = BaseModel;
}
