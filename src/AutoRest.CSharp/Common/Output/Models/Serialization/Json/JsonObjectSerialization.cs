// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net.ClientModel.Core;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonObjectSerialization
    {
        public JsonObjectSerialization(SerializableObjectType model, IReadOnlyList<Parameter> constructorParameters, IReadOnlyList<JsonPropertySerialization> properties, JsonAdditionalPropertiesSerialization? additionalProperties, ObjectTypeDiscriminator? discriminator, bool includeConverter)
        {
            Type = model.Type;
            ConstructorParameters = constructorParameters;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            Discriminator = discriminator;
            IncludeConverter = includeConverter;
            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
            IJsonModelInterface = new CSharpType(typeof(IJsonModel<>), modelType);
            IModelInterface = new CSharpType(typeof(IModel<>), modelType);
            // we only need this interface when the model is a struct
            IModelObjectInterface = model.IsStruct ? new CSharpType(typeof(IModel<>), typeof(object)) : null;
            IJsonInterface = Configuration.ApiTypes.IUtf8JsonSerializableType;
        }

        public CSharpType Type { get; }
        public IReadOnlyList<Parameter> ConstructorParameters { get; }
        public IReadOnlyList<JsonPropertySerialization> Properties { get; }
        public JsonAdditionalPropertiesSerialization? AdditionalProperties { get; }
        public ObjectTypeDiscriminator? Discriminator { get; }
        public bool IncludeConverter { get; }

        /// <summary>
        /// The interface IJsonModel{T}
        /// </summary>
        public CSharpType IJsonModelInterface { get; }
        /// <summary>
        /// The interface IModel{T}
        /// </summary>
        public CSharpType IModelInterface { get; }
        /// <summary>
        /// The interface IModel{object}. We only have this interface when this model is a struct
        /// </summary>
        public CSharpType? IModelObjectInterface { get; }
        /// <summary>
        /// The interface IUtf8JsonSerializable
        /// </summary>
        public CSharpType IJsonInterface { get; }
    }
}
