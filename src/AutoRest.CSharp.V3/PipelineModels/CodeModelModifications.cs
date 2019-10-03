using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.V3.PipelineModels.Generated
{
    internal partial class CSharpLanguage
    {
    }

    /// <summary>language metadata specific to schema instances</summary>
    internal partial class Language : IDictionary<string, object>
    {
        /// <summary>namespace of the implementation of this item</summary>
        [YamlMember(Alias = "namespace")]
        public string Namespace { get; set; }

        /// <summary>if this is a child of a polymorphic class, this will have the value of the discriminator.</summary>
        [YamlMember(Alias = "discriminatorValue")]
        public string DiscriminatorValue { get; set; }

        [YamlMember(Alias = "uid")]
        public string Uid { get; set; }

        [YamlMember(Alias = "internal")]
        public bool Internal { get; set; }

        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
        private static readonly Dictionary<string, PropertyInfo> DeserializableProperties = typeof(Language).GetDeserializableProperties();

        // Workaround for mapping properties from the dictionary entries
        private void AddAndMap(string key, object value)
        {
            if (DeserializableProperties.ContainsKey(key))
            {
                var propInfo = DeserializableProperties[key];
                propInfo.SetValue(this, propInfo.DeserializeDictionary(value));
                return;
            }

            _dictionary.Add(key, value);
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
        public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);

        public object this[string key]
        {
            get => _dictionary[key];
            set => AddAndMap(key, value);
        }

        public ICollection<string> Keys => _dictionary.Keys;
        public ICollection<object> Values => _dictionary.Values;
    }
}
