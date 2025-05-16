// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumType(string Name, string CrossLanguageDefinitionId, string? Accessibility, string? Deprecated, string? Summary, string? Doc, InputModelTypeUsage Usage, InputPrimitiveType ValueType, IReadOnlyList<InputEnumTypeValue> Values, bool IsExtensible)
    : InputType(Name)
{
    public string CrossLanguageDefinitionId { get; private set; } = CrossLanguageDefinitionId;
    public string? Accessibility { get; private set; } = Accessibility;
    public string? Deprecated { get; private set; } = Deprecated;
    public string? Summary { get; private set; } = Summary;
    public string? Doc { get; private set; } = Doc;
    public InputModelTypeUsage Usage { get; private set; } = Usage;
    public InputPrimitiveType ValueType { get; private set; } = ValueType;
    public IReadOnlyList<InputEnumTypeValue> Values { get; private set; } = Values;
    public bool IsExtensible { get; private set; } = IsExtensible;

    /// <summary>
    /// This method should only be called in deserialization
    /// </summary>
    /// <param name="name"></param>
    /// <param name="crossLanguageDefinitionId"></param>
    /// <param name="accessibility"></param>
    /// <param name="deprecated"></param>
    /// <param name="summary"></param>
    /// <param name="doc"></param>
    /// <param name="usage"></param>
    /// <param name="valueType"></param>
    /// <param name="values"></param>
    /// <param name="isExtensible"></param>
    internal void Update(string name, string crossLanguageDefinitionId, string? accessibility, string? deprecated, string? summary, string? doc, InputModelTypeUsage usage, InputPrimitiveType valueType, IReadOnlyList<InputEnumTypeValue> values, bool isExtensible)
    {
        Name = name;
        CrossLanguageDefinitionId = crossLanguageDefinitionId;
        Accessibility = accessibility;
        Deprecated = deprecated;
        Summary = summary;
        Doc = doc;
        Usage = usage;
        ValueType = valueType;
        Values = values;
        IsExtensible = isExtensible;
    }
}
