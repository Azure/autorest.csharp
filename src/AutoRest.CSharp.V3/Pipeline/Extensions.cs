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
            AllSchemaTypes.Boolean => typeof(bool),
            AllSchemaTypes.ByteArray => null,
            AllSchemaTypes.Char => typeof(char),
            AllSchemaTypes.Date => typeof(DateTimeOffset),
            AllSchemaTypes.DateTime => typeof(DateTimeOffset),
            AllSchemaTypes.Duration => typeof(TimeSpan),
            AllSchemaTypes.OdataQuery => typeof(string),
            AllSchemaTypes.String => typeof(string),
            AllSchemaTypes.Unixtime => typeof(DateTimeOffset),
            AllSchemaTypes.Uri => typeof(Uri),
            AllSchemaTypes.Uuid => typeof(string),
            _ => null
        };

        public static FrameworkTypeReferenceFormat ToFrameworkTypeReferenceFormat(this Schema schema) => schema switch
        {
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTime => FrameworkTypeReferenceFormat.DateTimeISO8601,
            DateSchema _ => FrameworkTypeReferenceFormat.Date,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTimeRfc1123 => FrameworkTypeReferenceFormat.DateTimeRFC1123,
            _ => FrameworkTypeReferenceFormat.Default,
        };

        public static Type ToFrameworkType(this NumberSchema schema) => schema.Type switch
        {
            AllSchemaTypes.Number => schema.Precision switch
            {
                32 => typeof(float),
                128 => typeof(decimal),
                _ => typeof(double)
            },
            // Assumes AllSchemaTypes.Integer
            _ => schema.Precision switch
            {
                16 => typeof(short),
                64 => typeof(long),
                _ => typeof(int)
            }
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

        private static readonly Func<string, bool, FrameworkTypeReferenceFormat, string?> NumberSerializer =
            (vn, nu, f) => $"writer.WriteNumberValue({vn}{(nu ? ".Value" : string.Empty)});";
        private static Func<string, bool, FrameworkTypeReferenceFormat, string?> StringSerializer(bool includeToString = false) =>
            (vn, nu, f) => $"writer.WriteStringValue({vn}{(includeToString ? ".ToString()" : string.Empty)});";

        private static string? ToFormatSpecifier(this FrameworkTypeReferenceFormat format) => format switch
        {
            FrameworkTypeReferenceFormat.DateTimeRFC1123 => "R",
            FrameworkTypeReferenceFormat.DateTimeISO8601 => "yyyy-MM-ddTHH:mm:ssZ",
            FrameworkTypeReferenceFormat.Date => "yyyy-MM-dd",
            _ => null
        };

        private static readonly Func<string, bool, FrameworkTypeReferenceFormat, string?> DateTimeSerializer = (vn, nu, f) =>
        {
            var format = f.ToFormatSpecifier();
            return $"writer.WriteStringValue({vn}{(nu ? ".Value" : string.Empty)}.ToString({(format != null ? $"\"{format}\"" : string.Empty)}));";
        };

        //TODO: Do this by AllSchemaTypes so things like Date versus DateTime can be serialized properly.
        private static readonly Dictionary<Type, Func<string, bool, FrameworkTypeReferenceFormat, string?>> TypeSerializers = new Dictionary<Type, Func<string, bool, FrameworkTypeReferenceFormat, string?>>
        {
            { typeof(bool), (vn, nu, f) => $"writer.WriteBooleanValue({vn}{(nu ? ".Value" : string.Empty)});" },
            { typeof(char), StringSerializer() },
            { typeof(short), NumberSerializer },
            { typeof(int), NumberSerializer },
            { typeof(long), NumberSerializer },
            { typeof(float), NumberSerializer },
            { typeof(double), NumberSerializer },
            { typeof(decimal), NumberSerializer },
            { typeof(string), StringSerializer() },
            { typeof(byte[]), (vn, nu, f) => null },
            { typeof(DateTimeOffset), DateTimeSerializer },
            { typeof(TimeSpan), StringSerializer(true) },
            { typeof(Uri), StringSerializer(true) }
        };

        //TODO: Figure out the rest of these.
        private static readonly Dictionary<Type, Func<string, string?>> TypeDeserializers = new Dictionary<Type, Func<string, string?>>
        {
            { typeof(bool), n => $"{n}.GetBoolean()" },
            { typeof(char), n => $"{n}.GetString()" },
            { typeof(short), n => $"{n}.GetInt16()" },
            { typeof(int), n => $"{n}.GetInt32()" },
            { typeof(long), n => $"{n}.GetInt64()" },
            { typeof(float), n => $"{n}.GetSingle()" },
            { typeof(double), n => $"{n}.GetDouble()" },
            { typeof(decimal), n => $"{n}.GetDecimal()" },
            { typeof(string), n => $"{n}.GetString()" },
            { typeof(DateTimeOffset), n => $"{n}.GetDateTimeOffset()" },
            { typeof(TimeSpan), n => $"TimeSpan.Parse({n}.GetString())" },
            { typeof(Uri), n => null } //TODO: Figure out how to get the Uri type here, so we can do 'new Uri(GetString())'
        };

        private static void WriteSerializeClientObject(CodeWriter writer, string name, bool isNullable)
        {
            writer.Append(name);
            writer.Append(isNullable ? "?" : string.Empty);
            writer.Line(".Serialize(writer);");
        }

        private static void WriteSerializeClientEnum(CodeWriter writer, string name, bool isNullable, bool isStringBased)
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

        private static void WriteSerializeSchemaTypeReference(CodeWriter writer, SchemaTypeReference type, TypeFactory typeFactory, string name)
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

        private static void WriteSerializeBinaryTypeReference(CodeWriter writer, string name)
        {
            writer.Append("writer.WriteBase64StringValue(");
            writer.Append(name);
            writer.Line(");");
        }

        private static void WriteSerializeDefault(CodeWriter writer, ClientTypeReference type, TypeFactory typeFactory, string name)
        {
            var frameworkType = typeFactory.CreateType(type)?.FrameworkType ?? typeof(void);
            var format = (type as FrameworkTypeReference)?.Format ?? FrameworkTypeReferenceFormat.Default;
            writer.Line(TypeSerializers[frameworkType](name, type.IsNullable, format) ?? "writer.WriteNullValue();");
        }

        public static void ToSerializeCall(this CodeWriter writer, ClientTypeReference type, TypeFactory typeFactory, string name, string serializedName, bool includePropertyName = true, bool quoteSerializedName = true)
        {
            if (includePropertyName)
            {
                writer.Append("writer.WritePropertyName(");
                if (quoteSerializedName)
                {
                    writer.Append("\"");
                }
                writer.Append(serializedName);
                if (quoteSerializedName)
                {
                    writer.Append("\"");
                }
                writer.Line(");");
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
                    WriteSerializeDefault(writer, type, typeFactory, name);
                    return;
            }
        }

        private static void WriteDeserializeClientObject(CodeWriter writer, CSharpType cSharpType, string name)
        {
            writer.AppendType(cSharpType);
            writer.Append(".Deserialize(");
            writer.Append(name);
            writer.Append(")");
        }

        private static void WriteDeserializeClientEnum(CodeWriter writer, CSharpType cSharpType, string name, bool isStringBased)
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

        private static void WriteDeserializeSchemaTypeReference(CodeWriter writer, CSharpType cSharpType, SchemaTypeReference type, TypeFactory typeFactory, string name)
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

        private static void WriteDeserializeBinaryTypeReference(CodeWriter writer, string name)
        {
            writer.Append(name);
            writer.Append(".GetBytesFromBase64()");
        }

        private static void WriteDeserializeDefault(CodeWriter writer, CSharpType cSharpType, string name)
        {
            var frameworkType = cSharpType?.FrameworkType ?? typeof(void);
            writer.Append(TypeDeserializers[frameworkType](name) ?? "null");
        }

        public static void ToDeserializeCall(this CodeWriter writer, ClientTypeReference type, TypeFactory typeFactory, string name, string typeText, string typeName)
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
