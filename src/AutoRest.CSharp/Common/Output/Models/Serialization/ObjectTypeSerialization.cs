// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal class ObjectTypeSerialization
    {
        public ObjectTypeSerialization(SerializableObjectType model, JsonObjectSerialization? json, XmlObjectSerialization? xml, BicepObjectSerialization? bicep, MultipartObjectSerialization? multipart, SerializationInterfaces? interfaces = null)
        {
            Json = json;
            Xml = xml;
            Bicep = bicep;
            Multipart = multipart;

            WireFormat = Xml != null ? Serializations.XmlFormat : Multipart != null ? Serializations.MultipartFormat : Serializations.JsonFormat;

            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
            Interfaces = interfaces ?? new SerializationInterfaces(model.IncludeSerializer, model.IsStruct, modelType, json is not null, xml is not null);

            if (Configuration.UseModelReaderWriter && model.Declaration.IsAbstract && model.Discriminator is { } discriminator)
            {
                PersistableModelProxyType = discriminator.DefaultObjectType.Type;
            }
        }

        public JsonObjectSerialization? Json { get; }

        public XmlObjectSerialization? Xml { get; }

        public BicepObjectSerialization? Bicep { get; }
        public MultipartObjectSerialization? Multipart { get; }

        public bool HasSerializations => Json != null || Xml != null || Bicep != null;

        public ValueExpression WireFormat { get; }

        public SerializationInterfaces Interfaces { get; }

        public CSharpType? PersistableModelProxyType { get; }
    }
}
