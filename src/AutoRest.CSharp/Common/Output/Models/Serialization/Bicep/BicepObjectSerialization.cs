// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal class BicepObjectSerialization
    {
        public BicepObjectSerialization(string name, ObjectType model)
        {
            Type = model.Type;
            var enumeration = model.EnumerateHierarchy().SelectMany(o => o.Properties);
            var properties = new List<BicepPropertySerialization>();
            foreach (var property in enumeration)
            {
                properties.Add(
                    new BicepPropertySerialization(
                        property,
                        // TODO figure out how to properly handle null schema e.g. AdditionalProperties properties
                        SerializationBuilder.BuildBicepSerialization(property.SchemaProperty?.Schema ?? new DictionarySchema(), property.ValueType, false)));
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
