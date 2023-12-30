// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartFormDataObjectSerialization
    {
        public MultipartFormDataObjectSerialization(SerializableObjectType model, IReadOnlyList<Parameter> constructorParameters, IReadOnlyList<MultipartPropertySerialization> properties, MultipartAdditionalPropertiesSerialization? additionalProperties, ObjectTypeDiscriminator? discriminator, bool includeConverter)
        {
            Type = model.Type;
            ConstructorParameters = constructorParameters;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            Discriminator = discriminator;
            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
        }
        public CSharpType Type { get; }
        public IReadOnlyList<Parameter> ConstructorParameters { get; }
        public IReadOnlyList<MultipartPropertySerialization> Properties { get; }
        public MultipartAdditionalPropertiesSerialization? AdditionalProperties { get; }
        public ObjectTypeDiscriminator? Discriminator { get; }
    }
}
