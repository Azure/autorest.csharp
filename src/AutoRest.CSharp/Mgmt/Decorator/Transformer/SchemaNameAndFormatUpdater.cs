// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Report;
using static AutoRest.CSharp.Mgmt.Decorator.Transformer.SchemaFormatByNameTransformer;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer;

internal static class SchemaNameAndFormatUpdater
{
    private const char NameFormatSeparator = '|';
    private const string EmptyName = "-";

    public static void ApplyRenameMapping(CodeModel codeModel)
    {
        var renameTargets = GetRenameAndReformatTargets().ToList();
        // apply them one by one
        foreach (var schema in codeModel.AllSchemas)
        {
            ApplyRenameTargets(schema, renameTargets);
        }

        var parameterRenameTargets = new Dictionary<string, IReadOnlyDictionary<string, RenameAndReformatTarget>>();
        foreach ((var operationId, var values) in Configuration.MgmtConfiguration.ParameterRenameMapping)
        {
            parameterRenameTargets.Add(operationId, GetParameterRenameTargets(values));
        }

        foreach (var operationGroup in codeModel.OperationGroups)
        {
            foreach (var operation in operationGroup.Operations)
            {
                if (parameterRenameTargets.TryGetValue(operation.OperationId ?? string.Empty, out var parameterTargets))
                {
                    ApplyRenameTargets(operation, parameterTargets);
                }
            }
        }
    }

    private static IEnumerable<RenameAndReformatTarget> GetRenameAndReformatTargets()
    {
        foreach ((var key, var value) in Configuration.MgmtConfiguration.RenameMapping)
        {
            yield return new RenameAndReformatTarget(TransformTypeName.RenameMapping, key, value);
        }
    }

    private static IReadOnlyDictionary<string, RenameAndReformatTarget> GetParameterRenameTargets(IReadOnlyDictionary<string, string> rawMapping)
    {
        var result = new Dictionary<string, RenameAndReformatTarget>();
        foreach ((var key, var value) in rawMapping)
        {
            result.Add(key, new RenameAndReformatTarget(TransformTypeName.ParameterRenameMapping, key, value));
        }

        return result;
    }

    private static void ApplyRenameTargets(Operation operation, IReadOnlyDictionary<string, RenameAndReformatTarget> renameTargets)
    {
        // temporarily we only support change name of the parameter
        // change the path and query parameters
        foreach (var parameter in operation.Parameters)
        {
            ApplyRenameTarget(operation, parameter, renameTargets);
        }

        // body parameter is not included above
        var bodyParameter = operation.GetBodyParameter();
        if (bodyParameter != null)
        {
            ApplyRenameTarget(operation, bodyParameter, renameTargets);
        }
    }

    private static void ApplyRenameTarget(Operation operation, RequestParameter parameter, IReadOnlyDictionary<string, RenameAndReformatTarget> renameTargets)
    {
        if (renameTargets.TryGetValue(parameter.GetOriginalName(), out var target))
        {
            // apply the rename
            string oriName = parameter.Language.Default.Name;
            parameter.Language.Default.SerializedName ??= parameter.Language.Default.Name;
            parameter.Language.Default.Name = target.NewName;
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(target.Source, target.Key, operation.OperationId!, target.Value),
                operation.GetFullSerializedName(parameter),
                "ApplyRenameParameter", oriName, parameter.Language.Default.Name);
        }
    }

    private static void ApplyRenameTargets(Schema schema, IEnumerable<RenameAndReformatTarget> renameTargets)
    {
        foreach (var target in renameTargets)
        {
            ApplyRenameTarget(schema, target);
        }
    }

    private static void ApplyRenameTarget(Schema schema, RenameAndReformatTarget renameTarget)
    {
        switch (schema)
        {
            case ChoiceSchema choiceSchema:
                ApplyChoiceSchema(choiceSchema, renameTarget);
                break;
            case SealedChoiceSchema sealedChoiceSchema:
                ApplySealedChoiceSchema(sealedChoiceSchema, renameTarget);
                break;
            case ObjectSchema objectSchema: // GroupSchema inherits from ObjectSchema, therefore this line changes both
                ApplyObjectSchema(objectSchema, renameTarget);
                break;
        }
    }

    private static void ApplyChoiceSchema(ChoiceSchema choiceSchema, RenameAndReformatTarget renameTarget)
    {
        switch (renameTarget.RenameType)
        {
            case RenameType.Type:
                ApplyToType(choiceSchema, renameTarget);
                break;
            case RenameType.Property:
                ApplyToChoiceValue(choiceSchema, choiceSchema.Choices, renameTarget);
                break;
        }
    }

    private static void ApplySealedChoiceSchema(SealedChoiceSchema sealedChoiceSchema, RenameAndReformatTarget renameTarget)
    {
        switch (renameTarget.RenameType)
        {
            case RenameType.Type:
                ApplyToType(sealedChoiceSchema, renameTarget);
                break;
            case RenameType.Property:
                ApplyToChoiceValue(sealedChoiceSchema, sealedChoiceSchema.Choices, renameTarget);
                break;
        }
    }

    private static void ApplyObjectSchema(ObjectSchema objectSchema, RenameAndReformatTarget renameTarget)
    {
        switch (renameTarget.RenameType)
        {
            case RenameType.Type:
                ApplyToType(objectSchema, renameTarget);
                break;
            case RenameType.Property:
                ApplyToProperty(objectSchema, objectSchema.Properties, renameTarget);
                break;
        }
    }

    private static void ApplyToType(Schema schema, RenameAndReformatTarget renameTarget)
    {
        if (schema.GetOriginalName() != renameTarget.TypeName)
            return;
        if (!string.IsNullOrEmpty(renameTarget.NewName))
        {
            ApplyNewName(schema.Language, renameTarget, schema.GetFullSerializedName());
        }
        // we just ignore the format information on this
    }

    private static void ApplyToChoiceValue(Schema schema, IEnumerable<ChoiceValue> choices, RenameAndReformatTarget renameTarget)
    {
        if (schema.GetOriginalName() != renameTarget.TypeName)
            return;
        var choiceValue = choices.FirstOrDefault(choice => choice.Value == renameTarget.PropertyName);
        if (choiceValue == null)
            return;
        ApplyNewName(choiceValue.Language, renameTarget, schema.GetFullSerializedName(choiceValue));
        // we just ignore the format information on this
    }

    private static void ApplyToProperty(ObjectSchema schema, IEnumerable<Property> properties, RenameAndReformatTarget renameTarget)
    {
        Debug.Assert(renameTarget.PropertyName != null);
        if (schema.GetOriginalName() != renameTarget.TypeName)
            return;
        // check if the property renaming is targeting a flattened property
        var flattenedNames = Array.Empty<string>();
        if (renameTarget.PropertyName.Contains('.'))
        {
            flattenedNames = renameTarget.PropertyName.Split('.');
        }
        var propertySerializedName = flattenedNames.LastOrDefault() ?? renameTarget.PropertyName;
        // filter the property name by the serialized name
        var filteredProperties = properties.Where(p => p.SerializedName == propertySerializedName);
        var property = filteredProperties.FirstOrDefault(p => p.FlattenedNames.SequenceEqual(flattenedNames));
        if (property == null)
            return;
        ApplyNewName(property.Language, renameTarget, schema.GetFullSerializedName(property));

        if (property.Schema is ArraySchema arraySchema)
        {
            ApplyNewFormat(arraySchema.ElementType, renameTarget, schema.GetFullSerializedName(property));
        }
        else
        {
            ApplyNewFormat(property.Schema, renameTarget, schema.GetFullSerializedName(property));
        }
    }

    public static void UpdateAcronyms(InputNamespace input)
    {
        UpdateAcronyms(input.Models);
        UpdateAcronyms(input.Enums);
        // transform all the parameter names
        UpdateAcronyms(input.Clients);
    }

    private static void ApplyNewName(Languages language, RenameAndReformatTarget rrt, string targetFullSerializedName)
    {
        string? value = rrt.NewName;
        if (value == null)
            return;
        string oriName = language.Default.Name;
        language.Default.SerializedName ??= language.Default.Name;
        language.Default.Name = value;
        MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(rrt.Source, rrt.Key, rrt.Value, targetFullSerializedName,
            "ApplyNewName", oriName, value);
    }

    private static void ApplyNewFormat(Schema schema, RenameAndReformatTarget rrt, string targetFullSerializedName)
    {
        FormatPattern? formatPattern = rrt.NewFormat;
        if (formatPattern == null)
            return;
        if (formatPattern.IsPrimitiveType)
        {
            AllSchemaTypes oriType = schema.Type;
            schema.Type = formatPattern.PrimitiveType!.Value;
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(rrt.Source, rrt.Key, rrt.Value, targetFullSerializedName,
                "ApplyNewType", oriType.ToString(), schema.Type.ToString());
        }
        else
        {
            if (schema.Extensions == null)
                schema.Extensions = new RecordOfStringAndAny();
            string? oriFormat = schema.Extensions.Format;
            schema.Extensions.Format = formatPattern.ExtensionType!;
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(rrt.Source, rrt.Key, rrt.Value, targetFullSerializedName,
                "ApplyNewFormat", oriFormat, schema.Extensions.Format);
        }
    }

    private record RenameAndReformatTarget
    {
        internal string Source { get; }
        internal string Key { get; }
        internal string Value { get; }

        internal RenameType RenameType { get; }
        internal string TypeName { get; }
        internal string? PropertyName { get; }
        internal string? NewName { get; }
        internal FormatPattern? NewFormat { get; }

        internal RenameAndReformatTarget(string source, string renameKey, string value)
        {
            this.Source = source;
            Key = renameKey;
            Value = value;
            // we do not support escape the character dot right now. In case in the future some swagger might have dot inside a property name, we need to support this. Really?
            if (renameKey.Contains('.'))
            {
                // this should be a renaming of property
                var segments = renameKey.Split('.', 2); // split at the first dot
                RenameType = RenameType.Property;
                TypeName = segments[0];
                PropertyName = segments[1];
            }
            else
            {
                // this should be a renaming of type
                RenameType = RenameType.Type;
                TypeName = renameKey;
                PropertyName = null;
            }
            if (value.Contains(NameFormatSeparator))
            {
                var segments = value.Split(NameFormatSeparator);
                if (segments.Length > 2)
                    throw new InvalidOperationException($"value for rename-mapping can only contains one |, but get `{value}`");

                NewName = IsEmptyName(segments[0]) ? null : segments[0];
                NewFormat = FormatPattern.Parse(segments[1]);
            }
            else
            {
                NewName = value;
                NewFormat = null;
            }
        }

        private static bool IsEmptyName(string name) => string.IsNullOrEmpty(name) || name == EmptyName;
    }

    private enum RenameType
    {
        Type = 0, Property = 1
    }

    public static void UpdateAcronym(InputType schema)
    {
        if (Configuration.MgmtConfiguration.AcronymMapping.Count == 0)
            return;
        TransformInputType(schema);
    }

    private static void UpdateAcronyms(IEnumerable<InputModelType> allModels)
    {
        foreach (var model in allModels)
        {
            TransformInputType(model);
        }
    }

    private static void UpdateAcronyms(IEnumerable<InputEnumType> allEnums)
    {
        foreach (var inputEnum in allEnums)
        {
            TransformInputType(inputEnum);
        }
    }

    private static void UpdateAcronyms(IEnumerable<InputClient> clients)
    {
        foreach (var client in clients)
        {
            foreach (var operation in client.Operations)
            {
                TransformOperation(operation);
            }
        }
    }

    private static void TransformOperation(InputOperation inputOperation)
    {
        var originalName = inputOperation.Name;
        var tempName = originalName;
        var result = NameTransformer.Instance.EnsureNameCase(originalName, (applyStep) =>
        {
            if (applyStep.MappingValue.RawValue is not null)
            {
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(TransformTypeName.AcronymMapping, applyStep.MappingKey, applyStep.MappingValue.RawValue, inputOperation.GetFullSerializedName(),
                    "ApplyAcronymMapping", tempName, applyStep.NewName.Name);
            }
            tempName = applyStep.NewName.Name;
        });
        inputOperation.Name = result.Name;

        // this iteration only applies to path and query parameter (maybe headers?) but not to body parameter
        foreach (var parameter in inputOperation.Parameters)
        {
            TransformInputParameter(parameter, inputOperation.GetFullSerializedName(parameter));
        }
    }

    private static void TransformInputType(InputType inputType)
    {
        switch (inputType)
        {
            case InputEnumType inputEnum:
                TransformInputEnumType(inputEnum, inputEnum.Values);
                break;
            case InputModelType inputModel:
                TransformInputModel(inputModel);
                break;
            default:
                throw new InvalidOperationException($"Unknown input type {inputType.GetType()}");
        }
    }

    private static void TransformInputEnumType(InputEnumType inputEnum, IReadOnlyList<InputEnumTypeValue> choiceValues)
    {
        TransformInputType(inputEnum, inputEnum.GetFullSerializedName());
        TransformChoices(inputEnum, choiceValues);
    }

    private static void TransformChoices(InputEnumType inputEnum, IReadOnlyList<InputEnumTypeValue> choiceValues)
    {
        foreach (var choiceValue in choiceValues)
        {
            var originalName = choiceValue.Name;
            var tempName = originalName;
            var result = NameTransformer.Instance.EnsureNameCase(originalName, (applyStep) =>
            {
                if (applyStep.MappingValue.RawValue is not null)
                {
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(TransformTypeName.AcronymMapping, applyStep.MappingKey, applyStep.MappingValue.RawValue, inputEnum.GetFullSerializedName(choiceValue),
                        "ApplyAcronymMapping", tempName, applyStep.NewName.Name);
                }
                tempName = applyStep.NewName.Name;
            });
            choiceValue.Name = result.Name;
        }
    }

    private static void TransformInputType(InputType inputType, string targetFullSerializedName)
    {
        var originalName = inputType.Name;
        var tempName = originalName;
        var result = NameTransformer.Instance.EnsureNameCase(originalName, (applyStep) =>
        {
            if (applyStep.MappingValue.RawValue is not null)
            {
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(TransformTypeName.AcronymMapping, applyStep.MappingKey, applyStep.MappingValue.RawValue, targetFullSerializedName,
                    "ApplyAcronymMapping", tempName, applyStep.NewName.Name);
            }
            tempName = applyStep.NewName.Name;
        });
        inputType.Name = result.Name;
    }

    private static void TransformInputParameter(InputParameter inputParameter, string targetFullSerializedName)
    {
        var originalName = inputParameter.Name;
        var tempName = originalName;
        var result = NameTransformer.Instance.EnsureNameCase(originalName, (applyStep) =>
        {
            if (applyStep.MappingValue.RawValue is not null)
            {
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(TransformTypeName.AcronymMapping, applyStep.MappingKey, applyStep.MappingValue.RawValue, targetFullSerializedName,
                    "ApplyAcronymMapping", tempName, applyStep.NewName.Name);
            }
            tempName = applyStep.NewName.Name;
        });
        inputParameter.Name = result.Name;
    }

    private static void TransformInputModel(InputModelType inputModel)
    {
        TransformInputType(inputModel, inputModel.GetFullSerializedName());
        foreach (var property in inputModel.Properties)
        {
            TransformInputType(property.Type, inputModel.GetFullSerializedName(property));
            TransformInputModelProperty(property, inputModel.GetFullSerializedName(property));
        }
    }

    private static void TransformInputModelProperty(InputModelProperty property, string targetFullSerializedName)
    {
        var originalName = property.Name;
        var tempName = originalName;
        var result = NameTransformer.Instance.EnsureNameCase(originalName, (applyStep) =>
        {
            if (applyStep.MappingValue.RawValue is not null)
            {
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(TransformTypeName.AcronymMapping, applyStep.MappingKey, applyStep.MappingValue.RawValue, targetFullSerializedName,
                    "ApplyAcronymMapping", tempName, applyStep.NewName.Name);
            }
            tempName = applyStep.NewName.Name;
        });
        property.Name = result.Name;
    }
}
