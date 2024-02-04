// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal record ModelSerialization
    {
        private readonly bool _isStruct;
        private readonly bool _includeSerializer;
        public ModelSerialization(JsonObjectSerialization? json, XmlObjectSerialization? xml, bool isStruct, bool includeSerializer)
        {
            Json = json;
            Xml = xml;
            _isStruct = isStruct;
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

            var interfaces = new List<CSharpType>();
            if (Json is not null)
            {
                interfaces.Add(Json.IJsonInterface);
                if (Configuration.UseModelReaderWriter)
                    interfaces.Add(Json.IJsonModelInterface);
            }
            if (Xml is not null)
            {
                interfaces.Add(Xml.IXmlInterface);
                if (Configuration.UseModelReaderWriter)
                    interfaces.Add(Xml.IPersistableModelTInterface);
            }
            if (_isStruct && Configuration.UseModelReaderWriter)
            {
                interfaces.Add(typeof(IPersistableModel<object>));
            }
            return interfaces;
        }
    }
}
