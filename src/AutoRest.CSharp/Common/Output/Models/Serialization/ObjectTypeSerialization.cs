// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal record ObjectTypeSerialization
    {
        private readonly bool _includeSerializer;
        public ObjectTypeSerialization(JsonObjectSerialization? json, XmlObjectSerialization? xml, bool includeSerializer)
        {
            Json = json;
            Xml = xml;
            _includeSerializer = includeSerializer;
        }

        public JsonObjectSerialization? Json { get; init; }

        public XmlObjectSerialization? Xml { get; init; }

        private IReadOnlyList<CSharpType>? _interfaces;
        public IReadOnlyList<CSharpType> Interfaces => _interfaces ??= BuildInterfaces();

        private IReadOnlyList<CSharpType> BuildInterfaces()
        {
            if (!_includeSerializer)
                return Array.Empty<CSharpType>();

            bool hasIJsonT = false;
            bool hasIJsonObject = false;
            var interfaces = new List<CSharpType>();
            if (Json is not null)
            {
                interfaces.Add(Json.IJsonInterface);
                if (Configuration.UseModelReaderWriter)
                {
                    interfaces.Add(Json.IJsonModelTInterface);
                    hasIJsonT = true;
                    if (Json.IJsonModelObjectInterface is not null)
                    {
                        interfaces.Add(Json.IJsonModelObjectInterface);
                        hasIJsonObject = true;
                    }
                }
            }
            if (Xml is not null)
            {
                interfaces.Add(Xml.IXmlInterface);
                if (Configuration.UseModelReaderWriter)
                {
                    if (!hasIJsonT)
                    {
                        interfaces.Add(Xml.IPersistableModelTInterface);
                    }
                    if (Xml.IPersistableModelObjectInterface is not null && !hasIJsonObject)
                    {
                        interfaces.Add(Xml.IPersistableModelObjectInterface);
                    }
                }
            }
            return interfaces;
        }
    }
}
