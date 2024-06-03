// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputTypeUsageProvider
    {
        private readonly InputNamespace _inputNamespace;
        private readonly Lazy<Dictionary<InputType, InputModelTypeUsage>> _usages;

        public InputTypeUsageProvider(InputNamespace inputNamespace)
        {
            _inputNamespace = inputNamespace;
            _usages = new Lazy<Dictionary<InputType, InputModelTypeUsage>>(EnsureUsages);
        }

        private Dictionary<InputType, InputModelTypeUsage> EnsureUsages()
        {
            var usages = new Dictionary<InputType, InputModelTypeUsage>();
            foreach (var operationGroup in _inputNamespace.Clients)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var operationResponse in operation.Responses)
                    {
                        var paging = operation.Paging;
                        if (paging != null && operationResponse.BodyType is InputModelType inputModel)
                        {
                            Apply(usages, operationResponse.BodyType, InputModelTypeUsage.Output);
                            foreach (var property in inputModel.Properties)
                            {
                                var itemName = paging.ItemName ?? "value";
                                if (property.SerializedName == itemName)
                                {
                                    Apply(usages, property.Type, InputModelTypeUsage.Output);
                                }
                            }
                        }
                        else if (operationResponse.BodyType != null)
                        {
                            Apply(usages, operationResponse.BodyType, InputModelTypeUsage.Output);
                        }
                    }

                    //foreach (var operationResponse in operation.Exceptions)
                    //{
                    //    Apply(usages, operationResponse.ResponseSchema, SchemaTypeUsage.Error | SchemaTypeUsage.Output);
                    //}

                    foreach (var parameter in operation.Parameters)
                    {
                        ApplyParameterSchema(usages, parameter);
                    }
                }
            }

            return usages;
        }

        private void ApplyParameterSchema(Dictionary<InputType, InputModelTypeUsage> usages, InputParameter parameter)
        {
            //if (parameter.Flattened == true)
            //{
            //    Apply(usages, parameter.Schema, SchemaTypeUsage.FlattenedParameters | SchemaTypeUsage.Input, recurse: false);
            //}
            //else
            //{
            //    Apply(usages, parameter.Schema, SchemaTypeUsage.Model | SchemaTypeUsage.Input);
            //}
            Apply(usages, parameter.Type, InputModelTypeUsage.Input);
        }

        private void Apply(Dictionary<InputType, InputModelTypeUsage> usages, InputType inputType, InputModelTypeUsage usage, bool recurse = true)
        {
            if (inputType == null)
            {
                return;
            }

            usages.TryGetValue(inputType, out var currentUsage);

            var newUsage = currentUsage | usage;
            if (newUsage == currentUsage)
            {
                return;
            }

            usages[inputType] = newUsage;

            if (!recurse)
            {
                return;
            }

            if (inputType is InputModelType inputModel)
            {
                // TODO: this should only apply children
                foreach (var parent in inputModel.GetAllBaseModels())
                {
                    Apply(usages, parent, usage);
                }

                foreach (var property in inputModel.Properties)
                {
                    var propertyUsage = usage;

                    if (property.IsReadOnly)
                    {
                        propertyUsage &= ~InputModelTypeUsage.Input;
                    }

                    Apply(usages, property.Type, propertyUsage);
                }
            }
            else if (inputType is InputDictionaryType dictionarySchema)
            {
                Apply(usages, dictionarySchema.KeyType, usage);
            }
            else if (inputType is InputListType arraySchema)
            {
                Apply(usages, arraySchema.ElementType, usage);
            }
            //else if (inputType is InputConstant constantSchmea)
            //{
            //    // the value type of a ConstantSchema might be an choice (transformed in class AutoRest.CSharp.Mgmt.Decorator.Transformer.ConstantSchemaTransformer
            //    Apply(usages, constantSchmea.ValueType, usage);
            //}
        }

        public InputModelTypeUsage GetUsage(InputType inputType)
        {
            _usages.Value.TryGetValue(inputType, out var usage);
            return usage;
        }
    }
}
