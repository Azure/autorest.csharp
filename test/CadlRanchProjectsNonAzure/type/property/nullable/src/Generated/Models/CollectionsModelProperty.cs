// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Scm._Type.Property.Nullable.Models
{
    /// <summary> Model with collection models properties. </summary>
    public partial class CollectionsModelProperty
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        internal CollectionsModelProperty(string requiredProperty, IEnumerable<InnerModel> nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty?.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CollectionsModelProperty(string requiredProperty, IReadOnlyList<InnerModel> nullableProperty, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/> for deserialization. </summary>
        internal CollectionsModelProperty()
        {
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary> Property. </summary>
        public IReadOnlyList<InnerModel> NullableProperty { get; }
    }
}
