// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.V3.Utilities;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

#pragma warning disable SA1649
#pragma warning disable SA1402
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
// ReSharper disable once CheckNamespace
namespace AutoRest.CSharp.V3.Pipeline.Generated
{

    internal partial class ObjectSchema
    {
        public ObjectSchema()
        {
            Properties = Array.Empty<Property>();
        }
    }

    internal class CSharpNamespace
    {
        public CSharpNamespace(string? @base, string? category = null, string? apiVersion = null)
        {
            Base = @base;
            Category = category;
            ApiVersion = apiVersion;
        }

        public string? Base { get; set; }

        public string? Category { get; set; }

        public string? ApiVersion { get; set; }

        public string FullName => new[] { Base, Category, ApiVersion }.JoinIgnoreEmpty(".");
    }


    internal class CSharpType
    {
        public CSharpType(Type type, params CSharpType[] arguments) : this(type, false, arguments)
        {
        }

        public CSharpType(Type type, bool isNullable, params CSharpType[] arguments)
        {
            Namespace ??= new CSharpNamespace(type.Namespace);
            Name = type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name;
            IsNullable = isNullable;
            Arguments = arguments;
            IsValueType = type.IsValueType;
            FrameworkType = type;
        }

        public CSharpType(CSharpNamespace ns, string name, bool isValueType = false, bool isNullable = false)
        {
            Name = name;
            IsValueType = isValueType;
            IsNullable = isNullable;
            Namespace = ns;
        }

        public CSharpNamespace Namespace { get; }

        public string Name { get; }
        public bool IsValueType { get; }

        public CSharpType[] Arguments { get; } = Array.Empty<CSharpType>();

        public Type? FrameworkType { get; }

        public bool IsNullable { get; }

        public CSharpType WithNullable(bool isNullable)
        {
            return FrameworkType != null ?
                new CSharpType(FrameworkType, isNullable, Arguments) :
                new CSharpType(Namespace, Name, IsValueType, isNullable);
        }

    }

    /// <summary>language metadata specific to schema instances</summary>
    internal partial class Language : IDictionary<string, object>
    {
        /// <summary>namespace of the implementation of this item</summary>
        [YamlMember(Alias = "namespace", Order = 2)]
        public string? Namespace { get; set; }

        /// <summary>if this is a child of a polymorphic class, this will have the value of the discriminator.</summary>
        [YamlMember(Alias = "discriminatorValue", Order = 3)]
        public string? DiscriminatorValue { get; set; }

        [YamlMember(Alias = "uid", Order = 4, ScalarStyle = ScalarStyle.SingleQuoted)]
        public string? Uid { get; set; }

        [YamlMember(Alias = "internal", Order = 5)]
        public bool? Internal { get; set; }

        [YamlMember(Alias = "serializedName", Order = 6)]
        public string? SerializedName { get; set; }

        [YamlIgnore]
        public IDictionary<string, object> AdditionalProperties = new Dictionary<string, object>();

        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
        private static readonly Dictionary<string, PropertyInfo> DeserializableProperties = typeof(Language).GetDeserializableProperties();

        // Workaround for mapping properties from the dictionary entries
        private void AddAndMap(string key, object value)
        {
            _dictionary.Add(key, value);

            if (DeserializableProperties.ContainsKey(key))
            {
                var propInfo = DeserializableProperties[key];
                propInfo.SetValue(this, propInfo.DeserializeDictionary(value));
                return;
            }

            AdditionalProperties.Add(key, value);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _dictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(KeyValuePair<string, object> item) => AddAndMap(item.Key, item.Value);
        public void Clear() => _dictionary.Clear();
        public bool Contains(KeyValuePair<string, object> item) => _dictionary.ContainsKey(item.Key);
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            foreach (var item in _dictionary)
            {
                array[arrayIndex++] = item;
            }
        }
        public bool Remove(KeyValuePair<string, object> item) => _dictionary.Remove(item.Key);

        public int Count => _dictionary.Count;
        public bool IsReadOnly => false;
        public void Add(string key, object value) => AddAndMap(key, value);
        public bool ContainsKey(string key) => _dictionary.ContainsKey(key);
        public bool Remove(string key) => _dictionary.Remove(key);

        public bool TryGetValue(string key, out object value)
        {
            var result = _dictionary.TryGetValue(key, out var outValue);
            value = outValue ?? String.Empty;
            return result;
        }

        public object this[string key]
        {
            get => _dictionary[key];
            set => AddAndMap(key, value);
        }

        public ICollection<string> Keys => _dictionary.Keys;
        public ICollection<object> Values => _dictionary.Values;
    }
}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
