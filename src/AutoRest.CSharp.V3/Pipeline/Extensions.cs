// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using Azure.Core;

namespace AutoRest.CSharp.V3.Pipeline
{
    internal static class Extensions
    {
        public static readonly Type[] GeneratedTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == typeof(CodeModel).Namespace).ToArray();

        private static readonly PropertyInfo[] SchemaCollectionProperties = typeof(Schemas).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(pi => pi.PropertyType.IsGenericType
                         && pi.PropertyType.IsInterface
                         && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                         && (pi.PropertyType.GenericTypeArguments.First().IsSubclassOf(typeof(Schema))
                            || pi.PropertyType.GenericTypeArguments.First() == typeof(Schema)))
            .ToArray();
        public static Schema[] GetAllSchemaNodes(this Schemas schemasNode) => SchemaCollectionProperties
                .Select(pi => pi.GetValue(schemasNode))
                .Where(c => c != null)
                .SelectMany(c => ((IEnumerable)c!).Cast<Schema>())
                .ToArray();

        // Cache the CSharpType so they become references in the YAML.
        private static readonly Dictionary<Type, CSharpType> CSharpTypes = new Dictionary<Type, CSharpType>
        {
            { typeof(bool), new CSharpType { FrameworkType = typeof(bool) } },
            { typeof(char), new CSharpType { FrameworkType = typeof(char) } },
            { typeof(int), new CSharpType { FrameworkType = typeof(int) } },
            { typeof(double), new CSharpType { FrameworkType = typeof(double) } },
            { typeof(string), new CSharpType { FrameworkType = typeof(string) } },
            { typeof(byte[]), new CSharpType { FrameworkType = typeof(byte[]) } },
            { typeof(DateTime), new CSharpType { FrameworkType = typeof(DateTime) } },
            { typeof(TimeSpan), new CSharpType { FrameworkType = typeof(TimeSpan) } },
            { typeof(Uri), new CSharpType { FrameworkType = typeof(Uri) } }
        };

        public static CSharpType? ToFrameworkCSharpType(this AllSchemaTypes schemaType) => schemaType switch
        {
            AllSchemaTypes.Any => null,
            AllSchemaTypes.Array => null,
            AllSchemaTypes.Boolean => CSharpTypes[typeof(bool)],
            AllSchemaTypes.ByteArray => CSharpTypes[typeof(byte[])],
            AllSchemaTypes.Char => CSharpTypes[typeof(char)],
            AllSchemaTypes.Choice => null,
            AllSchemaTypes.Constant => null,
            AllSchemaTypes.Credential => null,
            AllSchemaTypes.Date => CSharpTypes[typeof(DateTime)],
            AllSchemaTypes.DateTime => CSharpTypes[typeof(DateTime)],
            AllSchemaTypes.Dictionary => null,
            AllSchemaTypes.Duration => CSharpTypes[typeof(TimeSpan)],
            AllSchemaTypes.Flag => null,
            AllSchemaTypes.Integer => CSharpTypes[typeof(int)],
            AllSchemaTypes.Not => null,
            AllSchemaTypes.Number => CSharpTypes[typeof(double)],
            AllSchemaTypes.Object => null,
            AllSchemaTypes.OdataQuery => CSharpTypes[typeof(string)],
            AllSchemaTypes.Or => null,
            AllSchemaTypes.Group => null,
            AllSchemaTypes.SealedChoice => null,
            AllSchemaTypes.String => CSharpTypes[typeof(string)],
            AllSchemaTypes.Unixtime => CSharpTypes[typeof(DateTime)],
            AllSchemaTypes.Uri => CSharpTypes[typeof(Uri)],
            AllSchemaTypes.Uuid => CSharpTypes[typeof(string)],
            AllSchemaTypes.Xor => null,
            _ => null
        };

        public static RequestMethod? ToCoreRequestMethod(this HttpMethod method) => method switch
        {
            HttpMethod.Delete => (RequestMethod?)RequestMethod.Delete,
            HttpMethod.Get => RequestMethod.Get,
            HttpMethod.Head => RequestMethod.Head,
            HttpMethod.Options => null,
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

        private static readonly Dictionary<Type, Func<string, string?, bool, bool, bool, bool, string?>> SchemaSerializers = new Dictionary<Type, Func<string, string?, bool, bool, bool, bool, string?>>
        {
            { typeof(ObjectSchema), (vn, sn, n, a, q, ipn) => $"{vn}{(n ? "?" : String.Empty)}.Serialize(writer, {(ipn ? "true" : "false")});" },
            { typeof(SealedChoiceSchema), (vn, sn, n, a, q, ipn) => a ? $"writer.WriteStringValue({vn}{(n ? "?" : String.Empty)}.ToSerialString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? "?" : String.Empty)}.ToSerialString());" },
            { typeof(ChoiceSchema), (vn, sn, n, a, q, ipn) => a ? $"writer.WriteStringValue({vn}{(n ? "?" : String.Empty)}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? "?" : String.Empty)}.ToString());" },
            { typeof(ByteArraySchema), (vn, sn, n, a, q, ipn) => a ? $"writer.WriteBase64StringValue({vn});" : $"writer.WriteBase64String({(q ? $"\"{sn}\"" : sn)}, {vn});" }
        };

        public static string? ToSerializeCall(this Schema schema, TypeFactory typeFactory, string name, string serializedName, bool isNullable, bool asArray = false, bool quotedSerializedName = true, bool includePropertyName = true)
        {
            var schemaType = schema.GetType();
            var frameworkType = typeFactory.CreateType(schema)?.FrameworkType ?? typeof(void);
            return SchemaSerializers.ContainsKey(schemaType)
                ? SchemaSerializers[schemaType](name, serializedName, isNullable, asArray, quotedSerializedName, includePropertyName)
                : (TypeSerializers.ContainsKey(frameworkType) ? TypeSerializers[frameworkType](name, serializedName, isNullable, asArray, quotedSerializedName, includePropertyName) : null);
        }

        //TODO: Figure out the rest of these.
        private static readonly Dictionary<Type, Func<string, string?>> TypeDeserializers = new Dictionary<Type, Func<string, string?>>
        {
            { typeof(bool), n => $"{n}.GetBoolean()" },
            { typeof(char), n => $"{n}.GetString()" },
            { typeof(int), n => $"{n}.GetInt32()" },
            { typeof(double), n => $"{n}.GetDouble()" },
            { typeof(string), n => $"{n}.GetString()" },
            { typeof(byte[]), n => null },
            { typeof(DateTime), n => $"{n}.GetDateTime()" },
            { typeof(TimeSpan), n => null },
            { typeof(Uri), n => null } //TODO: Figure out how to get the Uri type here, so we can do 'new Uri(GetString())'
        };

        private static readonly Dictionary<Type, Func<string, string, string, string?>> SchemaDeserializers = new Dictionary<Type, Func<string, string, string, string?>>
        {
            { typeof(ObjectSchema), (n, tt, tn) => $"{tt}.Deserialize({n})" },
            { typeof(SealedChoiceSchema), (n, tt, tn) => $"{n}.GetString().To{tn}()" },
            { typeof(ChoiceSchema), (n, tt, tn) => $"new {tt}({n}.GetString())" },
            { typeof(ByteArraySchema), (n, tt, tn) => $"{n}.GetBytesFromBase64()" }
        };

        public static string? ToDeserializeCall(this Schema schema, TypeFactory typeFactory, string name, string typeText, string typeName)
        {
            var schemaType = schema.GetType();
            var frameworkType = typeFactory.CreateType(schema)?.FrameworkType ?? typeof(void);
            return SchemaDeserializers.ContainsKey(schemaType)
                ? SchemaDeserializers[schemaType](name, typeText, typeName)
                : (TypeDeserializers.ContainsKey(frameworkType) ? TypeDeserializers[frameworkType](name) : null);
        }

        public static string ToValueString(this ConstantSchema schema)
        {
            var value = schema.Value.Value;
            return $"{((value is string || value == null) ? $"\"{value}\"" : value)}";
        }
    }
}
