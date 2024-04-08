// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal record SerializationInterfaces : IEnumerable<CSharpType>
    {
        public SerializationInterfaces(bool includeSerializer, bool isStruct, CSharpType modelType, bool hasJson, bool hasXml)
        {
            // TODO -- includeSerializer could be removed after the use-model-reader-writer configuration is removed because it is always true
            if (includeSerializer)
            {
                if (hasJson)
                {
                    if (Configuration.IsBranded)
                    {
                        IJsonInterface = typeof(IUtf8JsonSerializable);
                    }
                    if (Configuration.UseModelReaderWriter)
                    {
                        IJsonModelTInterface = new CSharpType(typeof(IJsonModel<>), modelType);
                        IPersistableModelTInterface = new CSharpType(typeof(IPersistableModel<>), modelType);
                        // we only need this interface when the model is a struct
                        IJsonModelObjectInterface = isStruct ? (CSharpType)typeof(IJsonModel<object>) : null;
                        IPersistableModelObjectInterface = isStruct ? (CSharpType)typeof(IPersistableModel<object>) : null;
                    }
                }
                if (hasXml)
                {
                    IXmlInterface = Configuration.ApiTypes.IXmlSerializableType;
                    if (Configuration.UseModelReaderWriter)
                    {
                        IPersistableModelTInterface = new CSharpType(typeof(IPersistableModel<>), modelType);
                        IPersistableModelObjectInterface = isStruct ? (CSharpType)typeof(IPersistableModel<object>) : null;
                    }
                }
            }
        }

        public CSharpType? IJsonInterface { get; init; }

        public CSharpType? IXmlInterface { get; init; }

        public CSharpType? IJsonModelTInterface { get; init; }

        public CSharpType? IJsonModelObjectInterface { get; init; }

        public CSharpType? IPersistableModelTInterface { get; init; }

        public CSharpType? IPersistableModelObjectInterface { get; init; }

        private IReadOnlyList<CSharpType>? _interfaces;
        private IReadOnlyList<CSharpType> Interfaces => _interfaces ??= BuildInterfaces();

        private IReadOnlyList<CSharpType> BuildInterfaces()
        {
            bool hasIJsonT = false;
            bool hasIJsonObject = false;
            var interfaces = new List<CSharpType>();
            if (IJsonInterface is not null)
            {
                interfaces.Add(IJsonInterface);
            }
            if (IJsonModelTInterface is not null)
            {
                interfaces.Add(IJsonModelTInterface);
                hasIJsonT = true;
            }
            if (IJsonModelObjectInterface is not null)
            {
                interfaces.Add(IJsonModelObjectInterface);
                hasIJsonObject = true;
            }
            if (IXmlInterface is not null)
            {
                interfaces.Add(IXmlInterface);
            }
            if (!hasIJsonT && IPersistableModelTInterface is not null)
            {
                interfaces.Add(IPersistableModelTInterface);
            }
            if (!hasIJsonObject && IPersistableModelObjectInterface is not null)
            {
                interfaces.Add(IPersistableModelObjectInterface);
            }
            return interfaces;
        }

        IEnumerator<CSharpType> IEnumerable<CSharpType>.GetEnumerator()
        {
            return Interfaces.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Interfaces.GetEnumerator();
        }
    }
}
