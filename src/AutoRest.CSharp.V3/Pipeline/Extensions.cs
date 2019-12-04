// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.V3.ClientModel;
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

        public static void ToSerializeCall(this WriterBase writer, ClientTypeReference type, TypeFactory typeFactory, string name, string serializedName, bool asArray = false, bool quotedSerializedName = true, bool includePropertyName = true)
        {
            if (includePropertyName)
            {
                writer.Append("writer.WritePropertyName(");
                writer.Append("\"");
                writer.Append(serializedName);
                writer.Append("\"");
                writer.Append(");");
                writer.Line();
            }

            if (type is SchemaTypeReference schemaTypeReference)
            {
                var implementationType = typeFactory.ResolveReference(schemaTypeReference);

                if (implementationType is ClientObject)
                {
                    writer.Append(name);
                    if (type.IsNullable)
                    {
                        writer.Append("?");
                    }
                    writer.Append(".Serialize(writer);");
                    writer.Line();
                    return;
                }

                writer.Append("writer.WriteStringValue(");
                switch (implementationType)
                {
                    case ClientEnum e when e.IsStringBased:
                        writer.Append(name);
                        writer.Append(".ToString()");
                        break;
                    case ClientEnum e when !e.IsStringBased:
                        writer.Append(name);
                        if (type.IsNullable)
                        {
                            writer.Append(".Value");
                        }
                        writer.Append(".ToSerialString()");
                        break;
                }
                writer.Append(");");
                writer.Line();
            }
            else if (type is BinaryTypeReference)
            {
                writer.Append("writer.WriteBase64StringValue(");
                writer.Append(name);
                writer.Append(");");
                writer.Line();
            }
            else
            {
                var frameworkType = typeFactory.CreateType(type)?.FrameworkType ?? typeof(void);
                writer.Line(TypeSerializers[frameworkType](name, serializedName, type.IsNullable, asArray, quotedSerializedName, false) ?? "writer.WriteNullValue();");
            }
        }

        public static void ToDeserializeCall(this WriterBase writer, ClientTypeReference type, TypeFactory typeFactory, string name, string typeText, string typeName)
        {
            CSharpType cSharpType = typeFactory.CreateType(type).WithNullable(false);
            if (type is SchemaTypeReference schemaTypeReference)
            {
                var implementationType = typeFactory.ResolveReference(schemaTypeReference);

                switch (implementationType)
                {
                    case ClientObject _:
                        writer.Append(writer.Type(cSharpType));
                        writer.Append($".Deserialize({name})");
                        return;
                    case ClientEnum e when e.IsStringBased:
                        writer.Append($"new ");
                        writer.Append(writer.Type(cSharpType));
                        writer.Append($"({name}.GetString())");
                        return;
                    case ClientEnum e when !e.IsStringBased:
                        writer.Append($"{name}");
                        writer.Append(".GetString().To");
                        writer.Append(writer.Type(cSharpType));
                        writer.Append("()");
                        return;
                }
            }
            else if (type is BinaryTypeReference)
            {
                writer.Append($"{name}");
                writer.Append(".GetBytesFromBase64()");
            }
            else
            {
                var frameworkType = cSharpType?.FrameworkType ?? typeof(void);
                writer.Append(TypeDeserializers[frameworkType](name) ?? "null");
            }
        }

        public static string ToValueString(this ClientConstant schema)
        {
            var value = schema.Value;
            return $"{((value is string || value == null) ? $"\"{value}\"" : value)}";
        }
    }
}
