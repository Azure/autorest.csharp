// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModel
{
#pragma warning disable SA1402

    internal class ClientEnum : ClientEntity, IClientTypeProvider
    {
        public ClientEnum(string name, IEnumerable<ClientEnumValue> values)
        {
            Name = name;
            Values = new List<ClientEnumValue>(values);
        }

        public ClientEnumGenerationOptions GenerationOptions { get; } = new ClientEnumGenerationOptions();
        public string Name { get; }
        public IList<ClientEnumValue> Values { get; }
    }

    internal class ClientEntity
    {
    }

    internal class ClientEnumGenerationOptions
    {
        public bool IsStringBased { get; set; }
    }

    internal class ClientModel : ClientEntity, IClientTypeProvider
    {
        public ClientModel(string name, IEnumerable<ClientModelProperty> properties)
        {
            Name = name;
            Properties = new List<ClientModelProperty>(properties);
        }

        public string Name { get; }

        public IList<ClientModelProperty> Properties { get; }
    }

    internal class ClientModelGenerationOptions
    {
        public bool IsStruct { get; set; }
    }

    internal class FrameworkTypeReference: ClientTypeReference
    {
        public Type Type { get; }

        public FrameworkTypeReference(Type type)
        {
            Type = type;
        }
    }

    internal class ClientTypeReference
    {
    }

    internal class CollectionTypeReference : ClientTypeReference
    {
        public ClientTypeReference ItemType { get; }

        public CollectionTypeReference(ClientTypeReference itemType)
        {
            ItemType = itemType;
        }
    }

    internal class DictionaryTypeReference: ClientTypeReference
    {
        public ClientTypeReference KeyType { get; }
        public ClientTypeReference ValueType { get; }

        public DictionaryTypeReference(ClientTypeReference keyType, ClientTypeReference valueType)
        {
            KeyType = keyType;
            ValueType = valueType;
        }
    }

    internal class SchemaTypeReference: ClientTypeReference
    {
        public Schema Schema { get; }

        public SchemaTypeReference(Schema schema)
        {
            Schema = schema;
        }
    }

    internal abstract class ClientModelProperty: IClientTypeProvider
    {
        protected ClientModelProperty(string name, ClientTypeReference type, bool isMutable)
        {
            Name = name;
            Type = type;
            IsMutable = isMutable;
        }

        public string Name { get; }
        public ClientTypeReference Type { get; }
        public bool IsMutable { get; }
    }

    internal class ClientModelDataProperty : ClientModelProperty
    {
        public ClientModelDataProperty(string name, ClientTypeReference type, bool isMutable) : base(name, type, isMutable)
        {
        }
    }

    internal class ClientModelConstant : ClientModelProperty
    {
        public ClientModelConstant(string name, FrameworkTypeReference type, ClientConstant value) : base(name, type, isMutable: false)
        {
            Value = value;
        }

        public ClientConstant Value { get; }
    }

    internal class ClientEnumValue: IClientTypeProvider
    {
        public ClientEnumValue(string name, ClientConstant value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public ClientConstant Value { get; }
    }

    internal struct ClientConstant
    {
        public ClientConstant(object value)
        {
            Value = value;
        }

        public object Value { get; }
    }

    internal interface IClientTypeProvider
    {
        string Name { get; }
    }
}
