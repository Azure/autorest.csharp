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
using static AutoRest.CSharp.V3.Pipeline.Extensions;

namespace AutoRest.CSharp.V3.Pipeline
{
    internal static class Serialization
    {
        private static KeyValuePair<string, Type> CreateTagPair(this Type type) => new KeyValuePair<string, Type>($"!{type.Name}", type);
        private static readonly IEnumerable<KeyValuePair<string, Type>> TagMap = GeneratedTypes.Where(t => t.IsClass).Select(CreateTagPair);

        private static BuilderSkeleton<TBuilder> WithTagMapping<TBuilder>(this BuilderSkeleton<TBuilder> builder, IEnumerable<KeyValuePair<string, Type>> mapping) where TBuilder : BuilderSkeleton<TBuilder>
        {
            foreach (var (tagName, tagType) in mapping)
            {
                builder.WithTagMapping(tagName, tagType);
            }
            return builder;
        }

        private static IDeserializer Deserializer => new DeserializerBuilder().WithTagMapping(TagMap).WithTypeConverter(new YamlStringEnumConverter()).Build();

        public static CodeModel DeserializeCodeModel(string yaml) => Deserializer.Deserialize<CodeModel>(yaml);

        private static ISerializer Serializer => new SerializerBuilder().WithTagMapping(TagMap).WithTypeConverter(new YamlStringEnumConverter()).ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull).Build();

        public static string Serialize(this CodeModel codeModel) => Serializer.Serialize(codeModel);

        public static Dictionary<string, PropertyInfo> GetDeserializableProperties(this Type type) => type.GetProperties()
            .Select(p => new KeyValuePair<string, PropertyInfo>(p.GetCustomAttributes<YamlMemberAttribute>(true).Select(yma => yma.Alias).FirstOrDefault() ?? String.Empty, p))
            .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);

        // Only allows deserialization of properties that are primitives or type Dictionary<object, object?>. Does not support properties that are custom classes.
        public static object? DeserializeDictionary(this PropertyInfo info, object value)
        {
            if (!(value is Dictionary<object, object?>)) return TypeConverter.ChangeType(value, info.PropertyType);

            var type = info.PropertyType;
            var properties = type.GetDeserializableProperties();
            var property = Activator.CreateInstance(type);
            var matchedProperties = ((Dictionary<object, object?>)value)
                .Select(e => (Key: e.Key?.ToString() ?? String.Empty, e.Value))
                .Where(e => properties.ContainsKey(e.Key));
            foreach (var (propKey, propValue) in matchedProperties)
            {
                var innerInfo = properties[propKey];
                innerInfo.SetValue(property, innerInfo.DeserializeDictionary(propValue));
            }
            return property;
        }

        private class YamlStringEnumConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type.IsEnum;

            private static string? GetEnumValue(MemberInfo? memberInfo) =>
                memberInfo?.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault();

            public object ReadYaml(IParser parser, Type type)
            {
                var parsedEnum = parser.Consume<Scalar>();
                var serializableValues = type.GetMembers().Select(m => (Value: GetEnumValue(m) ?? String.Empty, Info: m)).Where(pa => !pa.Value.IsNullOrEmpty()).ToDictionary(pa => pa.Value, pa => pa.Info);
                if (!serializableValues.ContainsKey(parsedEnum.Value))
                {
                    throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
                }

                return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
            }

            public void WriteYaml(IEmitter emitter, object? value, Type type)
            {
                var enumMember = type.GetMember(value?.ToString() ?? String.Empty).FirstOrDefault();
                var yamlValue = GetEnumValue(enumMember) ?? value?.ToString() ?? String.Empty;
                emitter.Emit(new Scalar(yamlValue));
            }
        }
    }
}
