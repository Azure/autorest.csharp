// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Models;
using NUnit.Framework;
using ResourceData = AutoRest.CSharp.Mgmt.Output.ResourceData;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal class BicepObjectSerialization
    {
        public BicepObjectSerialization(string name, SerializableObjectType model)
        {
            Type = model.Type;

            if (model.EnumerateHierarchy().Any(m => m is ResourceData))
            {
                // For ResourceData models, properties directly on the model are nested under "Properties". All inherited properties
                // are inlined.
                foreach (var property in model.Properties)
                {
                    NestedProperties.Add(new BicepPropertySerialization(property, CreateBicepSerialization(property)));
                }

                foreach (var property in model.EnumerateHierarchy().Skip(1).SelectMany(o => o.Properties))
                {
                    Properties.Add(new BicepPropertySerialization(property, CreateBicepSerialization(property)));
                }
            }
            else
            {
                foreach (var property in model.EnumerateHierarchy().SelectMany(o => o.Properties))
                {
                    Properties.Add(new BicepPropertySerialization(property, CreateBicepSerialization(property)));
                }
            }
            Name = name;

            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
            IPersistableModelTInterface = new CSharpType(typeof(IPersistableModel<>), modelType);
            // we only need this interface when the model is a struct
            IPersistableModelObjectInterface = model.IsStruct ? (CSharpType)typeof(IPersistableModel<object>) : null;
        }

        private static BicepSerialization CreateBicepSerialization(ObjectTypeProperty property)
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

            return bicepSerialization;
        }

        public IList<BicepPropertySerialization> NestedProperties { get; } = new List<BicepPropertySerialization>();

        public IList<BicepPropertySerialization> Properties { get; } = new List<BicepPropertySerialization>();

        public string Name { get; }
        public CSharpType Type { get; }

        public CSharpType IPersistableModelTInterface { get; }

        public CSharpType? IPersistableModelObjectInterface { get; }
    }
}
