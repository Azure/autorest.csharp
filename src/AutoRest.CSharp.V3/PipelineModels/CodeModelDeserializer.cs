using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.V3.Common.Utilities;
using YamlDotNet.Serialization;

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
            CreateTagPair<Protocols>(),
            CreateTagPair<ApiVersion>()
        };

        private static IDeserializer _deserializer;
        private static IDeserializer Deserializer => _deserializer ??= new DeserializerBuilder().RegisterTagMapping(TagMap).Build();

        public static CodeModel CreateCodeModel(string yaml) => Deserializer.Deserialize<CodeModel>(yaml);

        public static Dictionary<string, PropertyInfo> GetDeserializableProperties(this Type type) => type.GetProperties()
            .Select(p => new KeyValuePair<string, PropertyInfo>(p.GetCustomAttributes<YamlMemberAttribute>(true).Select(yma => yma.Alias).FirstOrDefault(), p))
            .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);

        // Only allows deserialization of properties that are primitives or type Dictionary<object, object>. Does not support properties that are custom classes.
        public static object DeserializeDictionary(this PropertyInfo info, object value)
        {
            if (!(value is Dictionary<object, object>)) return Convert.ChangeType(value, info.PropertyType);

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
