using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.V3.Common.Utilities;
//using SharpYaml.Serialization;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.V3.PipelineModels
{
    internal static class CodeModelDeserializer
    {
        //private static SerializerSettings RegisterTagMapping(this SerializerSettings serializerSettings, IEnumerable<KeyValuePair<string, Type>> mapping)
        //{
        //    foreach (var (tagName, tagType) in mapping)
        //    {
        //        serializerSettings.RegisterTagMapping(tagName, tagType);
        //    }
        //    return serializerSettings;
        //}

        public static Dictionary<string, PropertyInfo> GetAvailableProperties(Type type) => type.GetProperties()
            .Select(p => new KeyValuePair<string, PropertyInfo>(p.GetCustomAttributes<YamlMemberAttribute>(true).Select(yma => yma.Alias).FirstOrDefault(), p))
            .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);

        // Only allows deserialization of properties of Dictionary<object, object> or primitives. Does not support properties that are classes.
        public static object ConvertFromDictionary(PropertyInfo propertyInfo, object propertyValue)
        {
            if (!(propertyValue is Dictionary<object, object>)) return Convert.ChangeType(propertyValue, propertyInfo.PropertyType);

            var propertyType = propertyInfo.PropertyType;
            var availableProperties = GetAvailableProperties(propertyType);
            var property = Activator.CreateInstance(propertyType);
            var matchedPairs = ((Dictionary<object, object>)propertyValue).Where(e => availableProperties.ContainsKey(e.Key.ToString()));
            foreach (var (key, value) in matchedPairs)
            {
                var innerInfo = availableProperties[key.ToString()];
                innerInfo.SetValue(property, ConvertFromDictionary(innerInfo, value));
            }
            return property;
        }

        private static DeserializerBuilder RegisterTagMapping(this DeserializerBuilder deserializerBuilder, IEnumerable<KeyValuePair<string, Type>> mapping)
        {
            foreach (var (tagName, tagType) in mapping)
            {
                deserializerBuilder.WithTagMapping(tagName, tagType);
            }
            return deserializerBuilder;
        }

        private static KeyValuePair<string, Type> CreateTagPair<T>() => new KeyValuePair<string, Type>($"!{typeof(T).Name}", typeof(T));

        // From: https://github.com/Azure/perks/blob/57a85fe6e26629ee6b420753d3b6b4f1db4b2719/codemodel/model/yaml-schema.ts#L28-L97
        private static readonly IEnumerable<KeyValuePair<string, Type>> TagMap = new[]
        {
            CreateTagPair<HttpModel>(),
            CreateTagPair<HttpParameter>(),
            CreateTagPair<HttpStreamRequest>(),
            CreateTagPair<HttpMultipartRequest>(),
            CreateTagPair<HttpResponse>(),
            CreateTagPair<HttpStreamResponse>(),
            CreateTagPair<HttpWithBodyRequest>(),
            CreateTagPair<HttpRequest>(),
            CreateTagPair<SchemaResponse>(),
            CreateTagPair<StreamResponse>(),
            CreateTagPair<Response>(),
            CreateTagPair<Parameter>(),
            CreateTagPair<Property>(),
            CreateTagPair<Value>(),
            CreateTagPair<Operation>(),
            CreateTagPair<ParameterGroupSchema>(),
            CreateTagPair<FlagSchema>(),
            CreateTagPair<FlagValue>(),
            CreateTagPair<NumberSchema>(),
            CreateTagPair<StringSchema>(),
            CreateTagPair<ArraySchema>(),
            CreateTagPair<ObjectSchema>(),
            CreateTagPair<ChoiceValue>(),
            CreateTagPair<ConstantValue>(),
            CreateTagPair<ChoiceSchema>(),
            CreateTagPair<SealedChoiceSchema>(),
            CreateTagPair<ConstantSchema>(),
            CreateTagPair<BooleanSchema>(),
            CreateTagPair<ODataQuerySchema>(),
            CreateTagPair<CredentialSchema>(),
            CreateTagPair<UriSchema>(),
            CreateTagPair<UuidSchema>(),
            CreateTagPair<DurationSchema>(),
            CreateTagPair<DateTimeSchema>(),
            CreateTagPair<DateSchema>(),
            CreateTagPair<CharSchema>(),
            CreateTagPair<ByteArraySchema>(),
            CreateTagPair<UnixTimeSchema>(),
            CreateTagPair<DictionarySchema>(),
            CreateTagPair<AndSchema>(),
            CreateTagPair<OrSchema>(),
            CreateTagPair<XorSchema>(),
            CreateTagPair<Schema>(),
            CreateTagPair<CodeModel>(),
            CreateTagPair<Request>(),
            CreateTagPair<Schemas>(),
            CreateTagPair<Discriminator>(),
            CreateTagPair<ExternalDocumentation>(),
            CreateTagPair<Contact>(),
            CreateTagPair<Info>(),
            CreateTagPair<License>(),
            CreateTagPair<Metadata>(),
            CreateTagPair<OperationGroup>(),
            CreateTagPair<APIKeySecurityScheme>(),
            CreateTagPair<BearerHTTPSecurityScheme>(),
            CreateTagPair<ImplicitOAuthFlow>(),
            CreateTagPair<NonBearerHTTPSecurityScheme>(),
            CreateTagPair<OAuth2SecurityScheme>(),
            CreateTagPair<OAuthFlows>(),
            CreateTagPair<OpenIdConnectSecurityScheme>(),
            CreateTagPair<PasswordOAuthFlow>(),
            CreateTagPair<AuthorizationCodeOAuthFlow>(),
            CreateTagPair<ClientCredentialsFlow>(),
            CreateTagPair<HttpServer>(),
            CreateTagPair<ServerVariable>(),
            CreateTagPair<Languages>(),
            //new KeyValuePair<string, Type>("!Languages", typeof(LanguagesOfSchemaMetadata)),
            CreateTagPair<Protocols>(),
            CreateTagPair<ApiVersion>()
            //CreateTagPair<Primitives>()
        };

        //private static SerializerSettings _serializerSettings;
        //private static SerializerSettings SerializerSettings => _serializerSettings ??= new SerializerSettings().RegisterTagMapping(TagMap);

        private static DeserializerBuilder _deserializerBuilder;
        private static DeserializerBuilder DeserializerBuilder => _deserializerBuilder ??= new DeserializerBuilder().RegisterTagMapping(TagMap);

        public static CodeModel CreateCodeModel(string yaml)
        {
            //var db = new DeserializerBuilder();
            //db.
            var deserializer = DeserializerBuilder.Build();
            return deserializer.Deserialize<CodeModel>(yaml);
            //var serializer = new Serializer(SerializerSettings);
            //return serializer.Deserialize<CodeModel>(yaml);
        }
    }
}
