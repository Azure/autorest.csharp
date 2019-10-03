using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using AutoRest.CSharp.V3.Common.Utilities;
using AutoRest.CSharp.V3.PipelineModels.Generated;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Utilities;

namespace AutoRest.CSharp.V3.PipelineModels
{
    internal static class CodeModelDeserializer
    {
        private static DeserializerBuilder RegisterTagMapping(this DeserializerBuilder deserializerBuilder, IEnumerable<KeyValuePair<string, Type>> mapping)
        {
            foreach (var (tagName, tagType) in mapping)
            {
                deserializerBuilder.WithTagMapping(tagName, tagType);
            }
            return deserializerBuilder;
        }

        //private static DeserializerBuilder WithTypeConverter(this DeserializerBuilder deserializerBuilder, IEnumerable<IYamlTypeConverter> converters)
        //{
        //    foreach (var converter in converters)
        //    {
        //        deserializerBuilder.WithTypeConverter(converter);
        //    }
        //    return deserializerBuilder;
        //}

        private static KeyValuePair<string, Type> CreateTagPair<T>() => typeof(T).CreateTagPair();
        private static KeyValuePair<string, Type> CreateTagPair(this Type type) => new KeyValuePair<string, Type>($"!{type.Name}", type);

        // From: https://github.com/Azure/perks/blob/57a85fe6e26629ee6b420753d3b6b4f1db4b2719/codemodel/model/yaml-schema.ts#L28-L97
        //private static readonly IEnumerable<KeyValuePair<string, Type>> TagMap = new[]
        //{
        //    CreateTagPair<HttpModel>(),
        //    CreateTagPair<HttpParameter>(),
        //    CreateTagPair<HttpStreamRequest>(),
        //    CreateTagPair<HttpMultipartRequest>(),
        //    CreateTagPair<HttpResponse>(),
        //    CreateTagPair<HttpStreamResponse>(),
        //    CreateTagPair<HttpWithBodyRequest>(),
        //    CreateTagPair<HttpRequest>(),
        //    CreateTagPair<SchemaResponse>(),
        //    CreateTagPair<StreamResponse>(),
        //    CreateTagPair<Response>(),
        //    CreateTagPair<Parameter>(),
        //    CreateTagPair<Property>(),
        //    CreateTagPair<Value>(),
        //    CreateTagPair<Operation>(),
        //    CreateTagPair<ParameterGroupSchema>(),
        //    CreateTagPair<FlagSchema>(),
        //    CreateTagPair<FlagValue>(),
        //    CreateTagPair<NumberSchema>(),
        //    CreateTagPair<StringSchema>(),
        //    CreateTagPair<ArraySchema>(),
        //    CreateTagPair<ObjectSchema>(),
        //    CreateTagPair<ChoiceValue>(),
        //    CreateTagPair<ConstantValue>(),
        //    CreateTagPair<ChoiceSchema>(),
        //    CreateTagPair<SealedChoiceSchema>(),
        //    CreateTagPair<ConstantSchema>(),
        //    CreateTagPair<BooleanSchema>(),
        //    CreateTagPair<ODataQuerySchema>(),
        //    CreateTagPair<CredentialSchema>(),
        //    CreateTagPair<UriSchema>(),
        //    CreateTagPair<UuidSchema>(),
        //    CreateTagPair<DurationSchema>(),
        //    CreateTagPair<DateTimeSchema>(),
        //    CreateTagPair<DateSchema>(),
        //    CreateTagPair<CharSchema>(),
        //    CreateTagPair<ByteArraySchema>(),
        //    CreateTagPair<UnixTimeSchema>(),
        //    CreateTagPair<DictionarySchema>(),
        //    CreateTagPair<AndSchema>(),
        //    CreateTagPair<OrSchema>(),
        //    CreateTagPair<XorSchema>(),
        //    CreateTagPair<Schema>(),
        //    CreateTagPair<CodeModel>(),
        //    CreateTagPair<Request>(),
        //    CreateTagPair<Schemas>(),
        //    CreateTagPair<Discriminator>(),
        //    CreateTagPair<ExternalDocumentation>(),
        //    CreateTagPair<Contact>(),
        //    CreateTagPair<Info>(),
        //    CreateTagPair<License>(),
        //    CreateTagPair<Metadata>(),
        //    CreateTagPair<OperationGroup>(),
        //    CreateTagPair<APIKeySecurityScheme>(),
        //    CreateTagPair<BearerHTTPSecurityScheme>(),
        //    CreateTagPair<ImplicitOAuthFlow>(),
        //    CreateTagPair<NonBearerHTTPSecurityScheme>(),
        //    CreateTagPair<OAuth2SecurityScheme>(),
        //    CreateTagPair<OAuthFlows>(),
        //    CreateTagPair<OpenIdConnectSecurityScheme>(),
        //    CreateTagPair<PasswordOAuthFlow>(),
        //    CreateTagPair<AuthorizationCodeOAuthFlow>(),
        //    CreateTagPair<ClientCredentialsFlow>(),
        //    CreateTagPair<HttpServer>(),
        //    CreateTagPair<ServerVariable>(),
        //    CreateTagPair<Languages>(),
        //    CreateTagPair<Protocols>(),
        //    CreateTagPair<ApiVersion>()
        //};

        private static readonly IEnumerable<Type> GeneratedTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "AutoRest.CSharp.V3.PipelineModels.Generated").ToArray();

        //private static readonly IEnumerable<Type> GeneratedClasses = GeneratedTypes.Where(t => t.IsClass);
        //private static readonly IEnumerable<Type> GeneratedEnums = GeneratedTypes.Where(t => t.IsEnum);

        private static readonly IEnumerable<KeyValuePair<string, Type>> TagMap = GeneratedTypes.Where(t => t.IsClass).Select(CreateTagPair);

        private class YamlStringEnumConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type.IsEnum;

            public object ReadYaml(IParser parser, Type type)
            {
                //parser.Expect<MappingStart>();

                var parsedEnum = parser.Expect<Scalar>();
                var serializableValues = type.GetMembers()
                    .Select(m => new KeyValuePair<string, MemberInfo>(m.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault(), m))
                    .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);
                if (!serializableValues.ContainsKey(parsedEnum.Value))
                {
                    throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
                }

                //parser.Expect<MappingEnd>();

                return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
            }

            //private static void ReadColumns(IParser parser, DataTable table)
            //{
            //    var columns = parser.Expect<Scalar>();
            //    if (columns.Value != "columns")
            //    {
            //        throw new YamlException(columns.Start, columns.End,
            //                                "Expected a scalar named 'columns'");
            //    }

            //    parser.Expect<MappingStart>();
            //    while (parser.Allow<MappingEnd>() == null)
            //    {
            //        var columnName = parser.Expect<Scalar>();
            //        var typeName = parser.Expect<Scalar>();

            //        table.Columns.Add(columnName.Value, Type.GetType(typeName.Value));
            //    }
            //}

            //private static void ReadRows(IParser parser, DataTable table)
            //{
            //    var columns = parser.Expect<Scalar>();
            //    if (columns.Value != "rows")
            //    {
            //        throw new YamlException(columns.Start, columns.End,
            //                                "Expected a scalar named 'rows'");
            //    }

            //    parser.Expect<SequenceStart>();
            //    while (parser.Allow<SequenceEnd>() == null)
            //    {
            //        var row = table.NewRow();

            //        var columnIndex = 0;
            //        parser.Expect<SequenceStart>();
            //        while (parser.Allow<SequenceEnd>() == null)
            //        {
            //            var value = parser.Expect<Scalar>();
            //            var columnType = table.Columns[columnIndex].DataType;
            //            row[columnIndex] = TypeConverter.ChangeType(value.Value, columnType);
            //            ++columnIndex;
            //        }

            //        table.Rows.Add(row);
            //    }
            //}

            public void WriteYaml(IEmitter emitter, object value, Type type)
            {
                //emitter.Emit(new MappingStart());

                emitter.Emit(new Scalar(value.ToString()));

                //emitter.Emit(new MappingEnd());
            }

            //private static void EmitColumns(IEmitter emitter, DataTable table)
            //{
            //    emitter.Emit(new Scalar("columns"));
            //    emitter.Emit(new MappingStart(null, null, true, MappingStyle.Block));
            //    foreach (DataColumn column in table.Columns)
            //    {
            //        emitter.Emit(new Scalar(column.ColumnName));
            //        emitter.Emit(new Scalar(column.DataType.AssemblyQualifiedName));
            //    }
            //    emitter.Emit(new MappingEnd());
            //}

            //private static void EmitRows(IEmitter emitter, DataTable table)
            //{
            //    emitter.Emit(new Scalar("rows"));
            //    emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));

            //    foreach (DataRow row in table.Rows)
            //    {
            //        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Flow));
            //        foreach (var item in row.ItemArray)
            //        {
            //            var value = TypeConverter.ChangeType<string>(item);
            //            emitter.Emit(new Scalar(value));
            //        }
            //        emitter.Emit(new SequenceEnd());
            //    }

            //    emitter.Emit(new SequenceEnd());
            //}
        }

        private static IDeserializer _deserializer;
        private static IDeserializer Deserializer => _deserializer ??= new DeserializerBuilder().RegisterTagMapping(TagMap).WithTypeConverter(new YamlStringEnumConverter()).Build();

        public static CodeModel CreateCodeModel(string yaml) => Deserializer.Deserialize<CodeModel>(yaml);

        public static Dictionary<string, PropertyInfo> GetDeserializableProperties(this Type type) => type.GetProperties()
            .Select(p => new KeyValuePair<string, PropertyInfo>(p.GetCustomAttributes<YamlMemberAttribute>(true).Select(yma => yma.Alias).FirstOrDefault(), p))
            .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);

        // Only allows deserialization of properties that are primitives or type Dictionary<object, object>. Does not support properties that are custom classes.
        public static object DeserializeDictionary(this PropertyInfo info, object value)
        {
            if (!(value is Dictionary<object, object>)) return TypeConverter.ChangeType(value, info.PropertyType);

            var type = info.PropertyType;
            var properties = type.GetDeserializableProperties();
            var property = Activator.CreateInstance(type);
            var matchedProperties = ((Dictionary<object, object>)value).Where(e => properties.ContainsKey(e.Key.ToString()));
            foreach (var (propKey, propValue) in matchedProperties)
            {
                var innerInfo = properties[propKey.ToString()];
                innerInfo.SetValue(property, innerInfo.DeserializeDictionary(propValue));
            }
            return property;
        }
    }
}
