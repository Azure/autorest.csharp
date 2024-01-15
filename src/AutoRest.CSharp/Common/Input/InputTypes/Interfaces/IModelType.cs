// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal interface IModelType : IType
{
    string? Namespace { get; }
    string? Accessibility { get; }
    string? Deprecated { get; }
    string? Description { get; }
    InputModelTypeUsage Usage { get; }
    IReadOnlyList<IModelProperty> Properties { get; }
    IModelType? BaseModel { get; }
    IReadOnlyList<IModelType> DerivedModels { get; }
    string? DiscriminatorValue { get; }
    string? DiscriminatorPropertyName { get; }
    IDictionaryType? InheritedDictionaryType { get; }
    bool IsPropertyBag { get; }
    bool IsUnknownDiscriminatorModel { get; }

    public IEnumerable<IModelType> GetSelfAndBaseModels() => EnumerateBase(this);

    public IEnumerable<IModelType> GetAllBaseModels() => EnumerateBase(BaseModel);

    public IReadOnlyList<IModelType> GetAllDerivedModels()
    {
        var list = new List<IModelType>(DerivedModels);
        for (var i = 0; i < list.Count; i++)
        {
            list.AddRange(list[i].DerivedModels);
        }

        return list;
    }

    private static IEnumerable<IModelType> EnumerateBase(IModelType? model)
    {
        while (model != null)
        {
            yield return model;
            model = model.BaseModel;
        }
    }
}
