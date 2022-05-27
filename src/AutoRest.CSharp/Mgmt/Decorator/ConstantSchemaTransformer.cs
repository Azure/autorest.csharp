// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ConstantSchemaTransformer
    {
        public static void TransformToSealedChoice()
        {
            var constantSchemas = new HashSet<ConstantSchema>(MgmtContext.CodeModel.Schemas.Constants);
            if (!constantSchemas.Any())
                return;

            Dictionary<ConstantSchema, SealedChoiceSchema> convertedChoiceSchemas = new();

            foreach (var operation in MgmtContext.CodeModel.OperationGroups.SelectMany(og => og.Operations))
            {
                foreach (var parameter in operation.Parameters)
                {
                    if (parameter.IsRequired || parameter.Schema is not ConstantSchema constantSchema)
                        continue;

                    var sealedChoiceSchema = ComputeIfAbsent(convertedChoiceSchemas, constantSchema, ConvertToChoiceSchema);
                    parameter.Schema = sealedChoiceSchema;
                    operation.SignatureParameters.Add(parameter);
                }

                foreach (var request in operation.Requests)
                {
                    foreach (var parameter in request.Parameters)
                    {
                        if (parameter.IsRequired || parameter.Schema is not ConstantSchema constantSchema)
                            continue;

                        var sealedChoiceSchema = ComputeIfAbsent(convertedChoiceSchemas, constantSchema, ConvertToChoiceSchema);
                        parameter.Schema = sealedChoiceSchema;
                        request.SignatureParameters.Add(parameter);
                    }
                }

                foreach (var property in MgmtContext.CodeModel.Schemas.Objects.SelectMany(o => o.Properties))
                {
                    if (property.IsRequired || property.Schema is not ConstantSchema constantSchema)
                        continue;

                    var sealedChoiceSchema = ComputeIfAbsent(convertedChoiceSchemas, constantSchema, ConvertToChoiceSchema);
                    property.Schema = sealedChoiceSchema;
                }
            }

            foreach (var choiceSchema in convertedChoiceSchemas.Values)
                MgmtContext.CodeModel.Schemas.SealedChoices.Add(choiceSchema);
        }

        private static V ComputeIfAbsent<K, V>(Dictionary<K, V> dict, K key, Func<K, V> generator) where K : notnull
        {
            if (dict.TryGetValue(key, out var value))
            {
                return value;
            }
            var generated = generator(key);
            dict.Add(key, generated);
            return generated;
        }

        private static SealedChoiceSchema ConvertToChoiceSchema(ConstantSchema constantSchema)
        {
            SealedChoiceSchema sealedChoiceSchema = new();
            sealedChoiceSchema.Type = AllSchemaTypes.SealedChoice;
            sealedChoiceSchema.ChoiceType = (PrimitiveSchema)constantSchema.ValueType;
            sealedChoiceSchema.DefaultValue = constantSchema.DefaultValue;
            sealedChoiceSchema.Language = constantSchema.Language;

            ChoiceValue choice = new();
            choice.Value = constantSchema.Value.Value.ToString();
            if (constantSchema.Value.Language != null)
                choice.Language = constantSchema.Value.Language;
            else
                choice.Language = new Languages
                {
                    Default = new Language
                    {
                        Name = choice.Value
                    }
                };
            sealedChoiceSchema.Choices = new[] { choice };
            return sealedChoiceSchema;
        }
    }
}
