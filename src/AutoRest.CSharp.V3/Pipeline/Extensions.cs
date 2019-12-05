// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.Pipeline.Generated;
using Azure.Core;

namespace AutoRest.CSharp.V3.Pipeline
{
    internal static class Extensions
    {
        public static Type? ToFrameworkCSharpType(this AllSchemaTypes schemaType) => schemaType switch
        {
            AllSchemaTypes.Any => null,
            AllSchemaTypes.Array => null,
            AllSchemaTypes.Boolean => typeof(bool),
            AllSchemaTypes.ByteArray => null,
            AllSchemaTypes.Char => typeof(char),
            AllSchemaTypes.Choice => null,
            AllSchemaTypes.Constant => null,
            AllSchemaTypes.Credential => null,
            AllSchemaTypes.Date => typeof(DateTime),
            AllSchemaTypes.DateTime => typeof(DateTime),
            AllSchemaTypes.Dictionary => null,
            AllSchemaTypes.Duration => typeof(TimeSpan),
            AllSchemaTypes.Flag => null,
            AllSchemaTypes.Integer => typeof(int),
            AllSchemaTypes.Not => null,
            AllSchemaTypes.Number => typeof(double),
            AllSchemaTypes.Object => null,
            AllSchemaTypes.OdataQuery => typeof(string),
            AllSchemaTypes.Or => null,
            AllSchemaTypes.Group => null,
            AllSchemaTypes.SealedChoice => null,
            AllSchemaTypes.String => typeof(string),
            AllSchemaTypes.Unixtime => typeof(DateTime),
            AllSchemaTypes.Uri => typeof(Uri),
            AllSchemaTypes.Uuid => typeof(string),
            AllSchemaTypes.Xor => null,
            _ => null
        };

        public static RequestMethod? ToCoreRequestMethod(this HttpMethod method) => method switch
        {
            HttpMethod.Delete => RequestMethod.Delete,
            HttpMethod.Get => RequestMethod.Get,
            HttpMethod.Head => RequestMethod.Head,
            HttpMethod.Options => (RequestMethod?)null,
            HttpMethod.Patch => RequestMethod.Patch,
            HttpMethod.Post => RequestMethod.Post,
            HttpMethod.Put => RequestMethod.Put,
            HttpMethod.Trace => null,
            _ => null
        };

        //TODO: Do this by AllSchemaTypes so things like Date versus DateTime can be serialized properly.
        private static readonly Dictionary<Type, Func<string, string?, bool, bool, bool, bool, string?>> TypeSerializers = new Dictionary<Type, Func<string, string?, bool, bool, bool, bool, string?>>
        {
            { typeof(bool), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteBooleanValue({vn}{(n ? ".Value" : String.Empty)});" : $"writer.WriteBoolean({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? ".Value" : String.Empty)});" },
            { typeof(char), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteStringValue({vn});" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn});" },
            { typeof(int), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteNumberValue({vn}{(n ? ".Value" : String.Empty)});" : $"writer.WriteNumber({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? ".Value" : String.Empty)});" },
            { typeof(double), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteNumberValue({vn}{(n ? ".Value" : String.Empty)});" : $"writer.WriteNumber({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? ".Value" : String.Empty)});" },
            { typeof(string), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteStringValue({vn});" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn});" },
            { typeof(byte[]), (vn, sn, n, a, q, ipn) => null },
            { typeof(DateTime), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteStringValue({vn}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}.ToString());" },
            { typeof(TimeSpan), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteStringValue({vn}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}.ToString());" },
            { typeof(Uri), (vn, sn, n, a, q, ipn) => a || !ipn ? $"writer.WriteStringValue({vn}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}.ToString());" }
        };

        //TODO: Figure out the rest of these.
        private static readonly Dictionary<Type, Func<string, string?>> TypeDeserializers = new Dictionary<Type, Func<string, string?>>
        {
            { typeof(bool), n => $"{n}.GetBoolean()" },
            { typeof(char), n => $"{n}.GetString()" },
            { typeof(int), n => $"{n}.GetInt32()" },
            { typeof(double), n => $"{n}.GetDouble()" },
            { typeof(string), n => $"{n}.GetString()" },
            { typeof(DateTime), n => $"{n}.GetDateTime()" },
            { typeof(TimeSpan), n => $"TimeSpan.Parse({n}.GetString())" },
            { typeof(Uri), n => null } //TODO: Figure out how to get the Uri type here, so we can do 'new Uri(GetString())'
        };

        private static void WriteSerializeClientObject(WriterBase writer, string name, bool isNullable)
        {
            writer.Append(name);
            writer.Append(isNullable ? "?" : string.Empty);
            writer.Line(".Serialize(writer);");
        }

        private static void WriteSerializeClientEnum(WriterBase writer, string name, bool isNullable, bool isStringBased)
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

        private static void WriteSerializeSchemaTypeReference(WriterBase writer, SchemaTypeReference type, TypeFactory typeFactory, string name)
        {
            switch (typeFactory.ResolveReference(type))
            {
                case ClientObject _:
                    WriteSerializeClientObject(writer, name, type.IsNullable);
                    return;
                case ClientEnum clientEnum:
                    WriteSerializeClientEnum(writer, name, type.IsNullable, clientEnum.IsStringBased);
                    return;
                default:
                    writer.Line("// Serialization of this type is not supported");
                    return;
            }
        }

        private static void WriteSerializeBinaryTypeReference(WriterBase writer, string name)
        {
            writer.Append("writer.WriteBase64StringValue(");
            writer.Append(name);
            writer.Line(");");
        }

        private static void WriteSerializeDefault(WriterBase writer, ClientTypeReference type, TypeFactory typeFactory, string name, string serializedName, bool asArray = false, bool quotedSerializedName = true, bool includePropertyName = true)
        {
            var frameworkType = typeFactory.CreateType(type)?.FrameworkType ?? typeof(void);
            writer.Line(TypeSerializers[frameworkType](name, serializedName, type.IsNullable, asArray, quotedSerializedName, false) ?? "writer.WriteNullValue();");
        }

        public static void ToSerializeCall(this WriterBase writer, ClientTypeReference type, TypeFactory typeFactory, string name, string serializedName, bool asArray = false, bool quotedSerializedName = true, bool includePropertyName = true)
        {
            if (includePropertyName)
            {
                writer.Append("writer.WritePropertyName(\"");
                writer.Append(serializedName);
                writer.Line("\");");
            }

            switch (type)
            {
                case SchemaTypeReference schemaTypeReference:
                    WriteSerializeSchemaTypeReference(writer, schemaTypeReference, typeFactory, name);
                    return;
                case BinaryTypeReference _:
                    WriteSerializeBinaryTypeReference(writer, name);
                    return;
                default:
                    WriteSerializeDefault(writer, type, typeFactory, name, serializedName, asArray, quotedSerializedName, includePropertyName);
                    return;
            }
        }

        private static void WriteDeserializeClientObject(WriterBase writer, CSharpType cSharpType, string name)
        {
            writer.Append(writer.Type(cSharpType));
            writer.Append(".Deserialize(");
            writer.Append(name);
            writer.Append(")");
        }

        private static void WriteDeserializeClientEnum(WriterBase writer, CSharpType cSharpType, string name, bool isStringBased)
        {
            if (isStringBased)
            {
                writer.Append("new ");
                writer.Append(writer.Type(cSharpType));
                writer.Append("(");
                writer.Append(name);
                writer.Append(".GetString())");
                return;
            }

            writer.Append(name);
            writer.Append(".GetString().To");
            writer.Append(writer.Type(cSharpType));
            writer.Append("()");
        }

        private static void WriteDeserializeSchemaTypeReference(WriterBase writer, CSharpType cSharpType, SchemaTypeReference type, TypeFactory typeFactory, string name)
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

        private static void WriteDeserializeBinaryTypeReference(WriterBase writer, string name)
        {
            writer.Append(name);
            writer.Append(".GetBytesFromBase64()");
        }

        private static void WriteDeserializeDefault(WriterBase writer, CSharpType cSharpType, string name)
        {
            var frameworkType = cSharpType?.FrameworkType ?? typeof(void);
            writer.Append(TypeDeserializers[frameworkType](name) ?? "null");
        }

        public static void ToDeserializeCall(this WriterBase writer, ClientTypeReference type, TypeFactory typeFactory, string name, string typeText, string typeName)
        {
            CSharpType cSharpType = typeFactory.CreateType(type).WithNullable(false);
            switch (type)
            {
                case SchemaTypeReference schemaTypeReference:
                    WriteDeserializeSchemaTypeReference(writer, cSharpType, schemaTypeReference, typeFactory, name);
                    return;
                case BinaryTypeReference _:
                    WriteDeserializeBinaryTypeReference(writer, name);
                    return;
                default:
                    WriteDeserializeDefault(writer, cSharpType, name);
                    return;
            }
        }

        public static string ToValueString(this ClientConstant schema)
        {
            var value = schema.Value;
            return $"{((value is string || value == null) ? $"\"{value}\"" : value)}";
        }
    }
}
