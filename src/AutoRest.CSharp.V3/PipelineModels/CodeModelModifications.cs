using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YamlDotNet.Serialization;
using AutoRest.CSharp.V3.Common.Utilities;

namespace AutoRest.CSharp.V3.PipelineModels
{
    /// <summary>language metadata specific to schema instances</summary>
    internal partial class Language
    {
        /// <summary>namespace of the implementation of this item</summary>
        [YamlDotNet.Serialization.YamlMember(Alias = "namespace")]
        public string Namespace { get; set; }

        /// <summary>if this is a child of a polymorphic class, this will have the value of the discriminator.</summary>
        [YamlDotNet.Serialization.YamlMember(Alias = "discriminatorValue")]
        public string DiscriminatorValue { get; set; }
    }

    //internal partial class Languages : System.Collections.Generic.Dictionary<string, object>
    internal partial class Languages : IDictionary<string, object>
    {
        //public override void OnDeserialization(object sender)
        //{
        //    base.OnDeserialization(sender);
        //    Console.Error.WriteLine($"Things: {Count}");
        //}

        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        private static readonly Dictionary<string, PropertyInfo> AvailableProperties = typeof(Languages).GetProperties()
            .Select(p => new KeyValuePair<string, PropertyInfo>(p.GetCustomAttributes<YamlMemberAttribute>(true).Select(yma => yma.Alias).FirstOrDefault(), p))
            .Where(pa => !pa.Key.IsNullOrEmpty()).ToDictionary(pa => pa.Key, pa => pa.Value);

        private void AddOrMap(string key, object value)
        {
            //if (AvailableProperties.ContainsKey(key))
            //{
            //    AvailableProperties[key].SetValue(this, value);
            //    return;
            //}

            _dictionary.Add(key, value);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _dictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(KeyValuePair<string, object> item) => AddOrMap(item.Key, item.Value);
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
        public void Add(string key, object value) => AddOrMap(key, value);
        public bool ContainsKey(string key) => _dictionary.ContainsKey(key);
        public bool Remove(string key) => _dictionary.Remove(key);
        public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);

        public object this[string key]
        {
            get => _dictionary[key];
            set => AddOrMap(key, value);
        }

        public ICollection<string> Keys => _dictionary.Keys;
        public ICollection<object> Values => _dictionary.Values;
    }

    //internal partial class Languages : IEnumerable<KeyValuePair<string, object>>
    //{
    //    private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

    //    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _dictionary.GetEnumerator();
    //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    //    //public void Add(KeyValuePair<string, object> item) => _dictionary.Add(item.Key, item.Value);
    //    //public void Clear() => _dictionary.Clear();
    //    //public bool Contains(KeyValuePair<string, object> item) => _dictionary.ContainsKey(item.Key);
    //    //public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    //    //{
    //    //    foreach (var item in _dictionary)
    //    //    {
    //    //        array[arrayIndex++] = item;
    //    //    }
    //    //}
    //    //public bool Remove(KeyValuePair<string, object> item) => _dictionary.Remove(item.Key);

    //    //public int Count => _dictionary.Count;
    //    //public bool IsReadOnly => false;
    //    //public void Add(string key, object value) => _dictionary.Add(key, value);
    //    //public bool ContainsKey(string key) => _dictionary.ContainsKey(key);
    //    //public bool Remove(string key) => _dictionary.Remove(key);
    //    //public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);

    //    //public object this[string key]
    //    //{
    //    //    get => _dictionary[key];
    //    //    set => _dictionary[key] = value;
    //    //}

    //    //public ICollection<string> Keys => _dictionary.Keys;
    //    //public ICollection<object> Values => _dictionary.Values;
    //}
}
