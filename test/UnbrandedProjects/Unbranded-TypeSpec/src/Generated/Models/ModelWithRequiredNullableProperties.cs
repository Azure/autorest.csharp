// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace UnbrandedTypeSpec.Models
{
    /// <summary> A model with a few required nullable properties. </summary>
    public partial class ModelWithRequiredNullableProperties
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

        /// <summary> Initializes a new instance of <see cref="ModelWithRequiredNullableProperties"/>. </summary>
        /// <param name="requiredNullablePrimitive"> required nullable primitive type. </param>
        /// <param name="requiredExtensibleEnum"> required nullable extensible enum type. </param>
        /// <param name="requiredFixedEnum"> required nullable fixed enum type. </param>
        public ModelWithRequiredNullableProperties(int? requiredNullablePrimitive, StringExtensibleEnum? requiredExtensibleEnum, StringFixedEnum? requiredFixedEnum)
        {
            RequiredNullablePrimitive = requiredNullablePrimitive;
            RequiredExtensibleEnum = requiredExtensibleEnum;
            RequiredFixedEnum = requiredFixedEnum;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithRequiredNullableProperties"/>. </summary>
        /// <param name="requiredNullablePrimitive"> required nullable primitive type. </param>
        /// <param name="requiredExtensibleEnum"> required nullable extensible enum type. </param>
        /// <param name="requiredFixedEnum"> required nullable fixed enum type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithRequiredNullableProperties(int? requiredNullablePrimitive, StringExtensibleEnum? requiredExtensibleEnum, StringFixedEnum? requiredFixedEnum, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RequiredNullablePrimitive = requiredNullablePrimitive;
            RequiredExtensibleEnum = requiredExtensibleEnum;
            RequiredFixedEnum = requiredFixedEnum;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithRequiredNullableProperties"/> for deserialization. </summary>
        internal ModelWithRequiredNullableProperties()
        {
        }

        /// <summary> required nullable primitive type. </summary>
        public int? RequiredNullablePrimitive { get; set; }
        /// <summary> required nullable extensible enum type. </summary>
        public StringExtensibleEnum? RequiredExtensibleEnum { get; set; }
        /// <summary> required nullable fixed enum type. </summary>
        public StringFixedEnum? RequiredFixedEnum { get; set; }
    }
}
