// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Mgmt.Models;
using System.Collections.Generic;
using System;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputAcronymTransformer
    {
        public static void Transform(InputNamespace input)
        {
            UpdateAcronyms(input.Models);
            UpdateAcronyms(input.Enums);
            // transform all the parameter names
            UpdateAcronyms(input.Clients);
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
            var result = NameTransformer.Instance.EnsureNameCase(originalName);
            inputOperation.Name = result.Name;

            // this iteration only applies to path and query parameter (maybe headers?) but not to body parameter
            foreach (var parameter in inputOperation.Parameters)
            {
                TransformInputParameter(parameter);
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
            TransformInputTypeName(inputEnum);
            TransformChoices(inputEnum, choiceValues);
        }

        private static void TransformChoices(InputEnumType inputEnum, IReadOnlyList<InputEnumTypeValue> choiceValues)
        {
            foreach (var choiceValue in choiceValues)
            {
                var originalName = choiceValue.Name;
                var tempName = originalName;
                var result = NameTransformer.Instance.EnsureNameCase(originalName);
                choiceValue.Name = result.Name;
            }
        }

        private static void TransformInputTypeName(InputType inputType)
        {
            var originalName = inputType.Name;
            var tempName = originalName;
            var result = NameTransformer.Instance.EnsureNameCase(originalName);
            inputType.Name = result.Name;
        }

        private static void TransformInputParameter(InputParameter inputParameter)
        {
            var originalName = inputParameter.Name;
            var tempName = originalName;
            var result = NameTransformer.Instance.EnsureNameCase(originalName);
            inputParameter.Name = result.Name;
        }

        private static void TransformInputModel(InputModelType inputModel)
        {
            TransformInputTypeName(inputModel);
            foreach (var property in inputModel.Properties)
            {
                TransformInputTypeName(property.Type);
                TransformInputModelProperty(property);
            }
        }

        private static void TransformInputModelProperty(InputModelProperty property)
        {
            var originalName = property.Name;
            var tempName = originalName;
            var result = NameTransformer.Instance.EnsureNameCase(originalName);
            property.Name = result.Name;
        }
    }
}
