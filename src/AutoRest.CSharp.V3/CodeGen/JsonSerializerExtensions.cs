// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.V3.ClientModels;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal static class JsonSerializerExtensions
    {
        private static readonly Func<string, bool, SerializationFormat, string?> NumberSerializer =
            (vn, nu, f) => $"writer.WriteNumberValue({vn}{(nu ? ".Value" : string.Empty)});";
        private static Func<string, bool, SerializationFormat, string?> StringSerializer(bool includeToString = false) =>
            (vn, nu, f) => $"writer.WriteStringValue({vn}{(includeToString ? ".ToString()" : string.Empty)});";

        public static string? ToFormatSpecifier(this SerializationFormat format) => format switch
        {
            SerializationFormat.DateTime_RFC1123 => "R",
            SerializationFormat.DateTime_ISO8601 => "S",
            SerializationFormat.Date_ISO8601 => "D",
            SerializationFormat.DateTime_Unix => "U",
            SerializationFormat.Duration_ISO8601 => "P",
            _ => null
        };

        private static readonly Func<string, bool, SerializationFormat, string?> FormatSerializer = (vn, nu, f) =>
        {
            var formatSpecifier = f.ToFormatSpecifier();
            var valueText = $"{vn}{(nu ? ".Value" : string.Empty)}";
            var formatText = formatSpecifier != null ? $", \"{formatSpecifier}\"" : string.Empty;
            return $"writer.WriteStringValue({valueText}{formatText});";
        };

        //TODO: Do this by AllSchemaTypes so things like Date versus DateTime can be serialized properly.
        private static readonly Dictionary<Type, Func<string, bool, SerializationFormat, string?>> TypeSerializers = new Dictionary<Type, Func<string, bool, SerializationFormat, string?>>
        {
            { typeof(bool), (vn, nu, f) => $"writer.WriteBooleanValue({vn}{(nu ? ".Value" : string.Empty)});" },
            { typeof(object), (vn, nu, f) => $"writer.WriteObjectValue({vn});" },
            { typeof(char), StringSerializer() },
            { typeof(short), NumberSerializer },
            { typeof(int), NumberSerializer },
            { typeof(long), NumberSerializer },
            { typeof(float), NumberSerializer },
            { typeof(double), NumberSerializer },
            { typeof(decimal), NumberSerializer },
            { typeof(string), StringSerializer() },
            { typeof(byte[]), (vn, nu, f) => null },
            { typeof(DateTimeOffset), FormatSerializer },
            { typeof(TimeSpan), FormatSerializer },
            { typeof(Uri), StringSerializer(true) }
        };

        private static Func<string, SerializationFormat, string?>? FormatDeserializer(string typeName) => (n, f) =>
        {
            var formatSpecifier = f.ToFormatSpecifier();
            return formatSpecifier != null ? $"{n}.Get{typeName}(\"{formatSpecifier}\")" : null;
        };

        private static readonly Dictionary<Type, Func<string, SerializationFormat, string?>> TypeDeserializers = new Dictionary<Type, Func<string, SerializationFormat, string?>>
        {
            { typeof(object), (n, f) => $"{n}.GetObject()" },
            { typeof(bool), (n, f) => $"{n}.GetBoolean()" },
            { typeof(char), (n, f) => $"{n}.GetString()" },
            { typeof(short), (n, f) => $"{n}.GetInt16()" },
            { typeof(int), (n, f) => $"{n}.GetInt32()" },
            { typeof(long), (n, f) => $"{n}.GetInt64()" },
            { typeof(float), (n, f) => $"{n}.GetSingle()" },
            { typeof(double), (n, f) => $"{n}.GetDouble()" },
            { typeof(decimal), (n, f) => $"{n}.GetDecimal()" },
            { typeof(string), (n, f) => $"{n}.GetString()" },
            { typeof(DateTimeOffset), FormatDeserializer(nameof(DateTimeOffset)) ?? ((n, f) => $"{n}.GetDateTimeOffset()") },
            { typeof(TimeSpan), FormatDeserializer(nameof(TimeSpan)) ?? ((n, f) => $"TimeSpan.Parse({n}.GetString())") },
            { typeof(Uri), (n, f) => null } //TODO: Figure out how to get the Uri type here, so we can do 'new Uri(GetString())'
        };

        private static void WriteSerializeClientObject(CodeWriter writer, CodeWriterDelegate name, CSharpType type)
        {
            writer.AppendType(type.WithNullable(false))
                .Append("Serializer.Serialize(")
                .Append(name)
                .Append(", writer)")
                .SemicolonLine();
        }

        private static void WriteSerializeClientEnum(CodeWriter writer, CodeWriterDelegate name, bool isNullable, bool isStringBased)
        {
            writer.Append("writer.WriteStringValue(");
            writer.Append(name);
            if (!isStringBased && isNullable)
            {
                writer.Append(".Value");
            }
            writer.Append(isStringBased ? ".ToString()" : ".ToSerialString()");
            writer.Line(");");
        }

        private static void WriteSerializeSchemaTypeReference(CodeWriter writer, SchemaTypeReference type, TypeFactory typeFactory, CodeWriterDelegate name)
        {
            switch (typeFactory.ResolveReference(type))
            {
                case ClientObject _:
                    WriteSerializeClientObject(writer, name, typeFactory.CreateType(type));
                    return;
                case ClientEnum clientEnum:
                    WriteSerializeClientEnum(writer, name, type.IsNullable, clientEnum.IsStringBased);
                    return;
                default:
                    writer.Line("// Serialization of this type is not supported");
                    return;
            }
        }

        private static void WriteSerializeBinaryTypeReference(CodeWriter writer, CodeWriterDelegate name)
        {
            writer.Append("writer.WriteBase64StringValue(");
            writer.Append(name);
            writer.Line(");");
        }

        private static void WriteSerializeDefault(CodeWriter writer, ClientTypeReference type, SerializationFormat format, TypeFactory typeFactory, CodeWriterDelegate name)
        {
            var frameworkType = typeFactory.CreateType(type)?.FrameworkType ?? typeof(void);
            writer.Line(TypeSerializers[frameworkType](CodeWriter.Materialize(name), type.IsNullable, format) ?? "writer.WriteNullValue();");
        }

        public static void ToSerializeCall(this CodeWriter writer, ClientTypeReference type, SerializationFormat format, TypeFactory typeFactory, CodeWriterDelegate name, CodeWriterDelegate? serializedName = null)
        {
            // TODO: remove when serialization uses the full writer
            writer.UseNamespace(new CSharpNamespace("Azure.Core"));

            if (serializedName != null)
            {
                writer.Append("writer.WritePropertyName(");
                writer.Append(serializedName);
                writer.Line(");");
            }

            switch (type)
            {
                case CollectionTypeReference array:
                {
                    writer.Line("writer.WriteStartArray();");
                    using (writer.ForEach($"var item in {CodeWriter.Materialize(name)}"))
                    {
                        writer.ToSerializeCall(array.ItemType, format, typeFactory, w => w.Append("item"));
                    }
                    writer.Line("writer.WriteEndArray();");

                    return;
                }
                case DictionaryTypeReference dictionary:
                {
                    writer.Line("writer.WriteStartObject();");
                    using (writer.ForEach($"var item in {CodeWriter.Materialize(name)}"))
                    {
                        writer.ToSerializeCall(dictionary.ValueType, format, typeFactory, w => w.Append("item.Value"), w => w.Append("item.Key"));
                    }
                    writer.Line("writer.WriteEndObject();");

                    return;
                }
                case SchemaTypeReference schemaTypeReference:
                    WriteSerializeSchemaTypeReference(writer, schemaTypeReference, typeFactory, name);
                    return;
                case BinaryTypeReference _:
                    WriteSerializeBinaryTypeReference(writer, name);
                    return;
                default:
                    WriteSerializeDefault(writer, type, format, typeFactory, name);
                    return;
            }
        }

        private static void WriteDeserializeClientObject(CodeWriter writer, CSharpType cSharpType, CodeWriterDelegate name)
        {
            writer.AppendType(cSharpType)
                .Append("Serializer.Deserialize(")
                .Append(name)
                .Append(")");
        }

        private static void WriteDeserializeClientEnum(CodeWriter writer, CSharpType cSharpType, CodeWriterDelegate name, bool isStringBased)
        {
            if (isStringBased)
            {
                writer.Append("new ");
                writer.AppendType(cSharpType);
                writer.Append("(");
                writer.Append(name);
                writer.Append(".GetString())");
                return;
            }

            writer.Append(name);
            writer.Append(".GetString().To");
            writer.AppendType(cSharpType);
            writer.Append("()");
        }

        private static void WriteDeserializeSchemaTypeReference(CodeWriter writer, CSharpType cSharpType, SchemaTypeReference type, TypeFactory typeFactory, CodeWriterDelegate name)
        {
            switch (typeFactory.ResolveReference(type))
            {
                case ClientObject _:
                    WriteDeserializeClientObject(writer, cSharpType, name);
                    return;
                case ClientEnum clientEnum:
                    WriteDeserializeClientEnum(writer, cSharpType, name, clientEnum.IsStringBased);
                    return;
                default:
                    writer.Append("/* Deserialization of this type is not supported */");
                    return;
            }
        }

        private static void WriteDeserializeBinaryTypeReference(CodeWriter writer, CodeWriterDelegate name)
        {
            writer.Append(name);
            writer.Append(".GetBytesFromBase64()");
        }

        private static void WriteDeserializeDefault(CodeWriter writer, CSharpType cSharpType, SerializationFormat format, CodeWriterDelegate name)
        {
            var frameworkType = cSharpType?.FrameworkType ?? typeof(void);
            writer.Append(TypeDeserializers[frameworkType](CodeWriter.Materialize(name), format) ?? "null");
        }

        public static void ToDeserializeCall(this CodeWriter writer, ClientTypeReference type, SerializationFormat format, TypeFactory typeFactory, CodeWriterDelegate destination, CodeWriterDelegate element)
        {
            // TODO: remove when serialization uses the full writer
            writer.UseNamespace(new CSharpNamespace("Azure.Core"));

            switch (type)
            {
                case CollectionTypeReference array:
                {
                    using (writer.ForEach("var item in property.Value.EnumerateArray()"))
                    {
                        writer.Append(destination);
                        writer.Append(".Add(");
                        writer.ToDeserializeCall(array.ItemType, format, typeFactory, w => w.Append("item"));
                        writer.Line(");");
                    }

                    return;
                }
                case DictionaryTypeReference dictionary:
                {
                    using (writer.ForEach("var item in property.Value.EnumerateObject()"))
                    {
                        writer.Append(destination);
                        writer.Append(".Add(item.Name, ");
                        writer.ToDeserializeCall(dictionary.ValueType, format, typeFactory, w => w.Append("item.Value"));
                        writer.Line(");");
                    }

                    return;
                }
            }

            writer.Append(destination);
            writer.Append("=");
            ToDeserializeCall(writer, type, format, typeFactory, element);
            writer.SemicolonLine();
        }

        public static void ToDeserializeCall(this CodeWriter writer, ClientTypeReference type, SerializationFormat format, TypeFactory typeFactory, CodeWriterDelegate element)
        {
            CSharpType cSharpType = typeFactory.CreateType(type).WithNullable(false);

            switch (type)
            {
                case SchemaTypeReference schemaTypeReference:
                    WriteDeserializeSchemaTypeReference(writer, cSharpType, schemaTypeReference, typeFactory, element);
                    return;
                case BinaryTypeReference _:
                    WriteDeserializeBinaryTypeReference(writer, element);
                    return;
                default:
                    WriteDeserializeDefault(writer, cSharpType, format, element);
                    return;
            }
        }
    }
}
