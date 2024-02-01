// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal class BicepObjectSerialization
    {
        public BicepObjectSerialization(string name, SerializableObjectType model)
        {
            Type = model.Type;
            var enumeration = model.EnumerateHierarchy().SelectMany(o => o.Properties);
            var properties = new List<BicepPropertySerialization>();
            foreach (var property in enumeration)
            {
                BicepSerialization bicepSerialization;

                if (property.SchemaProperty != null)
                {
                    bicepSerialization = SerializationBuilder.BuildBicepSerialization(
                        property.SchemaProperty.Schema,
                        property.Declaration.Type,
                        false);
                }
                else if (property.InputModelProperty != null)
                {
                    bicepSerialization = SerializationBuilder.BuildBicepSerialization(property.InputModelProperty!.Type,
                        property.Declaration.Type, false, property.SerializationFormat);
                }
                else if (property.Declaration.Name == "AdditionalProperties")
                {
                    bicepSerialization = SerializationBuilder.BuildBicepSerialization(
                        new DictionarySchema(),
                        property.Declaration.Type,
                        false);
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Unexpected property with no SchemaProperty or InputModelProperty: {property.Declaration.Name}");
                }

                properties.Add(
                    new BicepPropertySerialization(
                        property,
                        bicepSerialization));
            }
            Properties = properties;
            Name = name;

            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
            IPersistableModelTInterface = new CSharpType(typeof(IPersistableModel<>), modelType);
            // we only need this interface when the model is a struct
            IPersistableModelObjectInterface = model.IsStruct ? (CSharpType)typeof(IPersistableModel<object>) : null;
        }

        public IReadOnlyList<BicepPropertySerialization> Properties { get; }

        public string Name { get; }
        public CSharpType Type { get; }

        /// The interface IPersistableModel{T}
        /// </summary>
        public CSharpType IPersistableModelTInterface { get; }
        /// <summary>
        /// The interface IPersistableModel{object}
        /// </summary>
        public CSharpType? IPersistableModelObjectInterface { get; }
    }
}
