// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal record ObjectTypeSerialization
    {
        public ObjectTypeSerialization(SerializableObjectType model, JsonObjectSerialization? json, XmlObjectSerialization? xml)
        {
            Json = json;
            Xml = xml;

            WireFormat = Xml != null ? Serializations.XmlFormat : Serializations.JsonFormat;

            // select interface model type here
            var modelType = model.IsUnknownDerivedType && model.Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : model.Type;
            Interfaces = new SerializationInterfaces(model.IncludeSerializer, model.IsStruct, modelType, json is not null, xml is not null);

            if (Configuration.UseModelReaderWriter && model.Declaration.IsAbstract && model.Discriminator is { } discriminator)
            {
                PersistableModelProxyType = discriminator.DefaultObjectType.Type;
            }
        }

        public JsonObjectSerialization? Json { get; }

        public XmlObjectSerialization? Xml { get; }

        public ValueExpression WireFormat { get; }

        public SerializationInterfaces Interfaces { get; }

        public CSharpType? PersistableModelProxyType { get; }
    }
}
