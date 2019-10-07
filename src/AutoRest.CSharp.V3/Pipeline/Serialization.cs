using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Utilities;

namespace AutoRest.CSharp.V3.Pipeline
{
    internal static class Serialization
    {
        private static KeyValuePair<string, Type> CreateTagPair(this Type type) => new KeyValuePair<string, Type>($"!{type.Name}", type);
        private static readonly IEnumerable<Type> GeneratedTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == typeof(CodeModel).Namespace).ToArray();
        private static readonly IEnumerable<KeyValuePair<string, Type>> TagMap = GeneratedTypes.Where(t => t.IsClass).Select(CreateTagPair);

        private static BuilderSkeleton<TBuilder> WithTagMapping<TBuilder>(this BuilderSkeleton<TBuilder> builder, IEnumerable<KeyValuePair<string, Type>> mapping) where TBuilder : BuilderSkeleton<TBuilder>
        {
            foreach (var (tagName, tagType) in mapping)
            {
                builder.WithTagMapping(tagName, tagType);
            }
            return builder;
        }

        private static IDeserializer _deserializer;
        private static IDeserializer Deserializer => _deserializer ??= new DeserializerBuilder().WithTagMapping(TagMap).WithTypeConverter(new YamlStringEnumConverter()).Build();

        public static CodeModel DeserializeCodeModel(string yaml) => Deserializer.Deserialize<CodeModel>(yaml);

        private static ISerializer _serializer;
        private static ISerializer Serializer => _serializer ??= new SerializerBuilder().WithTagMapping(TagMap).WithTypeConverter(new YamlStringEnumConverter()).ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull).Build();

        public static string Serialize(this CodeModel codeModel) => Serializer.Serialize(codeModel);

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

        private class YamlStringEnumConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type.IsEnum;

            public object ReadYaml(IParser parser, Type type)
            {
                var parsedEnum = parser.Consume<Scalar>();
                var serializableValues = type.GetMembers()
                    .Select(m => new KeyValuePair<string, MemberInfo>(m.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault(), m))
                    .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);
                if (!serializableValues.ContainsKey(parsedEnum.Value))
                {
                    throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
                }

                return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
            }

            public void WriteYaml(IEmitter emitter, object value, Type type)
            {
                var enumMember = type.GetMember(value.ToString()).FirstOrDefault();
                var yamlValue = enumMember?.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault() ?? value.ToString();
                emitter.Emit(new Scalar(yamlValue));
            }
        }
    }
}
