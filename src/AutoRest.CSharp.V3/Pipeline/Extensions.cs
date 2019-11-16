using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
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

        //private static string? TypeSerializers(Type? type) => type switch
        //{
        //    typeof(bool) => ,
        //    typeof(char) => ,
        //    typeof(int) => ,
        //    typeof(double) => ,
        //    typeof(string) => ,
        //    typeof(byte[]) => ,
        //    typeof(DateTime) => ,
        //    typeof(TimeSpan) => ,
        //    typeof(Uri) => ,
        //    _ => null
        //};

        //TODO: Do this by AllSchemaTypes so things like Date versus DateTime can be serialized properly.
        private static readonly Dictionary<Type, Func<string, string?, bool, bool, bool, string?>> TypeSerializers = new Dictionary<Type, Func<string, string?, bool, bool, bool, string?>>
        {
            { typeof(bool), (vn, sn, n, a, q) => a ? $"writer.WriteBooleanValue({vn}{(n ? ".Value" : String.Empty)});" : $"writer.WriteBoolean({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? ".Value" : String.Empty)});" },
            { typeof(char), (vn, sn, n, a, q) => a ? $"writer.WriteStringValue({vn});" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn});" },
            { typeof(int), (vn, sn, n, a, q) => a ? $"writer.WriteNumberValue({vn}{(n ? ".Value" : String.Empty)});" : $"writer.WriteNumber({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? ".Value" : String.Empty)});" },
            { typeof(double), (vn, sn, n, a, q) => a ? $"writer.WriteNumberValue({vn}{(n ? ".Value" : String.Empty)});" : $"writer.WriteNumber({(q ? $"\"{sn}\"" : sn)}, {vn}{(n ? ".Value" : String.Empty)});" },
            { typeof(string), (vn, sn, n, a, q) => a ? $"writer.WriteStringValue({vn});" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn});" },
            { typeof(byte[]), (vn, sn, n, a, q) => null },
            { typeof(DateTime), (vn, sn, n, a, q) => a ? $"writer.WriteStringValue({vn}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}.ToString());" },
            { typeof(TimeSpan), (vn, sn, n, a, q) => a ? $"writer.WriteStringValue({vn}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}.ToString());" },
            { typeof(Uri), (vn, sn, n, a, q) => a ? $"writer.WriteStringValue({vn}.ToString());" : $"writer.WriteString({(q ? $"\"{sn}\"" : sn)}, {vn}.ToString());" }
        };

        public static string? ToSerializeCall(this Schema schema, string name, string serializedName, bool isNullable, bool asArray = false, bool quotedSerializedName = true)
        {
            //var (propertyCs, propertySchemaCs) = (property.Language.CSharp, property.Schema.Language.CSharp);
            //var isObject = property.Schema is ObjectSchema;
            //var hasField = isObject && (propertySchemaCs?.IsLazy ?? false) && !(property.Required ?? false);
            //var name = (asArray ? "item" : null) ?? (hasField ? $"_{propertyCs?.Name.ToVariableName()}" : null) ?? propertyCs?.Name ?? "[NO NAME]";
            //var type = propertySchemaCs?.Type?.FrameworkType ?? typeof(void);
            //var serializedName = property.Language.Default.Name;
            var type = schema.Language.CSharp?.Type?.FrameworkType ?? typeof(void);
            return schema is ObjectSchema ? $"{name}.Serialize(writer);" : (TypeSerializers.ContainsKey(type) ? TypeSerializers[type](name, serializedName, isNullable, asArray, quotedSerializedName) : null);
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
            { typeof(Uri), n => null } // Figure out how to get the Uri type here, so we can do 'new Uri(GetString())'
        };

        public static string? ToDeserializeCall(this Schema schema, string name, string typeText) //bool isNullable, bool asArray = false, bool quotedSerializedName = true)
        {
            var type = schema.Language.CSharp?.Type?.FrameworkType ?? typeof(void);
            return schema is ObjectSchema ? $"{typeText}.Deserialize({name})" : (TypeDeserializers.ContainsKey(type) ? TypeDeserializers[type](name) : null);
        }
    }
}
