// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Mgmt.Decorator;

internal static class SchemaExtensions
{
    /// <summary>
    /// Union all the properties on myself and all the properties from my parents
    /// </summary>
    /// <param name="inputModel"></param>
    /// <returns></returns>
    internal static IEnumerable<InputModelProperty> GetAllProperties(this InputModelType inputModel)
    {
        return inputModel.GetSelfAndBaseModels().SelectMany(parentInputModelType => parentInputModelType.Properties).Concat(inputModel.Properties);
    }

    /// <summary>
    /// Union all the properties on myself and all the properties from my parents
    /// </summary>
    /// <param name="schema"></param>
    /// <returns></returns>
    internal static IEnumerable<Property> GetAllProperties(this ObjectSchema schema)
    {
        return schema.Parents!.All.OfType<ObjectSchema>().SelectMany(parentSchema => parentSchema.Properties).Concat(schema.Properties);
    }

    private static bool IsTagsProperty(InputModelProperty property)
        => property.CSharpName().Equals("Tags")
            && property.Type is InputDictionaryType dictType
            && dictType.KeyType is InputPrimitiveType inputPrimitive
            && inputPrimitive.Kind == InputTypeKind.String;

    public static bool HasTags(this InputType schema)
    {
        if (schema is not InputModelType inputModel)
        {
            return false;
        }

        var allProperties = inputModel.GetAllProperties();

        return allProperties.Any(property => IsTagsProperty(property) && !property.IsReadOnly);
    }

    public static bool IsResourceModel(this InputModelType inputModelType)
    {
        var allProperties = inputModelType.GetAllProperties();
        bool idPropertyFound = false;
        bool typePropertyFound = !Configuration.MgmtConfiguration.DoesResourceModelRequireType;
        bool namePropertyFound = !Configuration.MgmtConfiguration.DoesResourceModelRequireName;

        foreach (var property in allProperties)
        {
            // check if this property is flattened from lower level, we should only consider first level properties in this model
            // therefore if flattenedNames is not empty, this property is flattened, we skip this property
            if (property.FlattenedNames is not null && property.FlattenedNames.Any())
                continue;

            switch (property.SerializedName)
            {
                case "id":
                    if (property.Type is InputPrimitiveType inputPrimitiveType && (inputPrimitiveType.Kind == InputTypeKind.String || inputPrimitiveType.Kind == InputTypeKind.ResourceIdentifier))
                        idPropertyFound = true;
                    continue;
                case "type":
                    if (property.Type is InputPrimitiveType inputPrimitive && (inputPrimitive.Kind == InputTypeKind.ResourceType || inputPrimitive.Kind == InputTypeKind.String))
                        typePropertyFound = true;
                    continue;
                case "name":
                    if (property.Type is InputPrimitiveType primitive && primitive.Kind == InputTypeKind.String)
                        namePropertyFound = true;
                    continue;
            }
        }

        return idPropertyFound && typePropertyFound && namePropertyFound;
    }

    // TODO: we may reuse the IsResourceModel instead of creating this method, but the result for flattened properties is different as although models with matched flattened properties are not treated as Resource but they still inherit from ResourceData. We should probably consider to align the behavior before we can refactor the methods.
    internal static bool IsResourceData(this InputModelType objSchema)
    {
        return objSchema.ContainsStringProperty("id") && objSchema.ContainsStringProperty("name") && objSchema.ContainsStringProperty("type");
    }

    private static bool ContainsStringProperty(this InputModelType inputModelType, string propertyName)
    {
        return inputModelType.GetAllProperties().Any(p => p.SerializedName.Equals(propertyName, StringComparison.Ordinal) && p.Type is InputPrimitiveType inputPrimitiveType && inputPrimitiveType.Kind == InputTypeKind.String);
    }

    // TODO: we may reuse the IsResourceModel instead of creating this method, but the result for flattened properties is different as although models with matched flattened properties are not treated as Resource but they still inherit from ResourceData. We should probably consider to align the behavior before we can refactor the methods.
    internal static bool IsResourceData(this ObjectSchema objSchema)
    {
        return objSchema.ContainsStringProperty("id") && objSchema.ContainsStringProperty("name") && objSchema.ContainsStringProperty("type");
    }

    private static bool ContainsStringProperty(this ObjectSchema objSchema, string propertyName)
    {
        return objSchema.GetAllProperties().Any(p => p.SerializedName.Equals(propertyName, StringComparison.Ordinal) && p.Schema.Type == AllSchemaTypes.String);
    }

    internal static string GetOriginalName(this InputType inputType) => inputType.OriginalName ?? inputType.Name;

    internal static string GetOriginalName(this Schema schema) => schema.Language.Default.SerializedName ?? schema.Language.Default.Name;

    internal static string GetOriginalName(this RequestParameter parameter) => parameter.Language.Default.SerializedName ?? parameter.Language.Default.Name;

    internal static string GetFullSerializedName(this Schema schema) => schema.GetOriginalName();

    internal static string GetFullSerializedName(this InputType inputType) => inputType.GetOriginalName();

    internal static string GetFullSerializedName(this InputType inputType, InputEnumTypeValue choice)
    {
        return inputType switch
        {
            InputEnumType c => c.GetFullSerializedName(choice),
            _ => throw new InvalidOperationException($"Given input type is not InputEnumType: {inputType.Name}")
        };
    }

    internal static string GetFullSerializedName(this Schema schema, ChoiceValue choice)
    {
        return schema switch
        {
            ChoiceSchema c => c.GetFullSerializedName(choice),
            SealedChoiceSchema sc => sc.GetFullSerializedName(choice),
            _ => throw new InvalidOperationException("Given schema is not ChoiceSchema or SealedChoiceSchema: " + schema.Name)
        };
    }

    internal static string GetFullSerializedName(this InputEnumType inputEnum, InputEnumTypeValue choice)
    {
        if (!inputEnum.AllowedValues.Contains(choice))
            throw new InvalidOperationException($"enum value {choice.Value} doesn't belong to enum {inputEnum.Name}");
        return $"{inputEnum.Name}.{choice.Value}";
    }

    internal static string GetFullSerializedName(this ChoiceSchema schema, ChoiceValue choice)
    {
        if (!schema.Choices.Contains(choice))
            throw new InvalidOperationException($"choice value {choice.Value} doesn't belong to choice {schema.Name}");
        return $"{schema.GetFullSerializedName()}.{choice.Value}";
    }

    internal static string GetFullSerializedName(this SealedChoiceSchema schema, ChoiceValue choice)
    {
        if (!schema.Choices.Contains(choice))
            throw new InvalidOperationException($"choice value {choice.Value} doesn't belong to SealedChoice {schema.Name}");
        return $"{schema.GetFullSerializedName()}.{choice.Value}";
    }

    internal static string GetFullSerializedName(this ObjectSchema schema, Property property)
    {
        if (!schema.Properties.Contains(property))
            throw new InvalidOperationException($"property {property.SerializedName} doesn't belong to object {schema.Name}");
        string propertySerializedName;
        if (property.FlattenedNames.Count == 0)
            propertySerializedName = $"{property.SerializedName}";
        else
            propertySerializedName = string.Join(".", property.FlattenedNames);
        return $"{schema.GetFullSerializedName()}.{propertySerializedName}";
    }

    internal static string GetFullSerializedName(this InputModelType inputModel, InputModelProperty property)
    {
        if (!inputModel.Properties.Contains(property))
            throw new InvalidOperationException($"property {property.SerializedName} doesn't belong to object {inputModel.Name}");
        string propertySerializedName;
        if (property.FlattenedNames is null)
            propertySerializedName = $"{property.SerializedName}";
        else
            propertySerializedName = string.Join(".", property.FlattenedNames);
        return $"{inputModel.GetFullSerializedName()}.{propertySerializedName}";
    }
}
