// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text.Json;

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
#pragma warning disable SA1402, SA1649

    internal abstract class JsonSerialization
    {
        public abstract ClientTypeReference Type { get; }
    }

    internal class JsonValueSerialization: JsonSerialization
    {
        public JsonValueSerialization(ClientTypeReference type, JsonValueSerializationKind kind, SerializationFormat format)
        {
            Type = type;
            Format = format;
            Kind = kind;
        }

        public JsonValueSerializationKind Kind { get; }
        public override ClientTypeReference Type { get; }
        public SerializationFormat Format { get; }
    }


    internal enum JsonValueSerializationKind
    {
        Object,
        DateTime,
        Number,
        String,
    }

    internal class JsonArraySerialization: JsonSerialization
    {
        public JsonArraySerialization(ClientTypeReference type, JsonSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override ClientTypeReference Type { get; }
        public JsonSerialization ValueSerialization { get; }
    }

    internal class JsonDynamicPropertiesSerialization
    {
        public JsonDynamicPropertiesSerialization(JsonSerialization valueSerialization)
        {
            ValueSerialization = valueSerialization;
        }

        public JsonSerialization ValueSerialization { get; }
    }


    internal class JsonObjectSerialization: JsonSerialization
    {
        public JsonObjectSerialization(ClientTypeReference type, JsonPropertySerialization[] properties, JsonDynamicPropertiesSerialization? additionalProperties)
        {
            Type = type;
            Properties = properties;
            AdditionalProperties = additionalProperties;
        }

        public override ClientTypeReference Type { get; }
        public JsonPropertySerialization[] Properties { get; }
        public JsonDynamicPropertiesSerialization? AdditionalProperties { get; }
    }

    internal class JsonPropertySerialization
    {
        public JsonPropertySerialization(string name, string memberName, JsonSerialization valueSerialization, ClientTypeReference type)
        {
            Name = name;
            MemberName = memberName;
            ValueSerialization = valueSerialization;
            Type = type;
        }

        public string Name { get; }
        public string MemberName { get; }
        public ClientTypeReference Type { get; }
        public JsonSerialization ValueSerialization { get; }
    }

    internal class FlatSerialization
    {
    }

    internal class FlatSerializedCollection: FlatSerialization
    {
        public FlatSerializedCollection(FlatSerialization valueSerialization, Binding valuesBinding, QuerySerializationStyle serializationStyle)
        {
            ValueSerialization = valueSerialization;
            ValuesBinding = valuesBinding;
            SerializationStyle = serializationStyle;
        }

        public FlatSerialization ValueSerialization { get; }
        public Binding ValuesBinding { get; }
        public QuerySerializationStyle SerializationStyle { get; }
    }

    internal class MemberBinding:Binding
    {
        public MemberBinding(Binding item, string member, ClientTypeReference type)
        {
            Item = item;
            Member = member;
            Type = type;
        }

        public Binding Item { get; }
        public string Member { get; }
        public override ClientTypeReference Type { get; }
    }

    internal class ParentBinding: Binding
    {
        public ParentBinding(ClientTypeReference type)
        {
            Type = type;
        }

        public override ClientTypeReference Type { get; }
    }

    internal class IdentifierBinding : Binding
    {
        public IdentifierBinding(string name, ClientTypeReference type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public override ClientTypeReference Type { get; }
    }

    internal abstract class Binding
    {
        public abstract ClientTypeReference Type { get; }
    }

    internal class ConstantBinding: Binding
    {
        public ClientConstant Value { get; }

        public ConstantBinding(ClientConstant value)
        {
            Value = value;
        }

        public override ClientTypeReference Type => Value.Type;
    }

    internal class FlatSerializedValue : FlatSerialization
    {
        public FlatSerializedValue(Binding binding, SerializationFormat format)
        {
            Format = format;
            Binding = binding;
        }

        public Binding Binding { get; }

        public SerializationFormat Format { get; }
    }
}
