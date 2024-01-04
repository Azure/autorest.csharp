// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CustomizationsInTsp.Models
{
    /// <summary> Root RoundTrip model to reference all other types to ensure generation. </summary>
    public partial class RootModel
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

        /// <summary> Initializes a new instance of <see cref="RootModel"/>. </summary>
        public RootModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RootModel"/>. </summary>
        /// <param name="propertyExtensibleEnum"> ExtensibleEnumWithOperator. </param>
        /// <param name="propertyModelToMakeInternal"> ModelToMakeInternal. </param>
        /// <param name="propertyModelToRename"> ModelToRename. </param>
        /// <param name="propertyModelToChangeNamespace"> ModelToChangeNamespace. </param>
        /// <param name="propertyModelWithCustomizedProperties"> ModelWithCustomizedProperties. </param>
        /// <param name="propertyEnumToRename"> EnumToRename. </param>
        /// <param name="propertyEnumWithValueToRename"> EnumWithValueToRename. </param>
        /// <param name="propertyEnumToBeMadeExtensible"> EnumToBeMadeExtensible. </param>
        /// <param name="propertyModelToAddAdditionalSerializableProperty"> ModelToAddAdditionalSerializableProperty. </param>
        /// <param name="propertyToMoveToCustomization"> Enum type property to move to customization code. </param>
        /// <param name="propertyModelStruct"> ModelStruct. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RootModel(ExtensibleEnumWithOperator? propertyExtensibleEnum, ModelToMakeInternal propertyModelToMakeInternal, RenamedModel propertyModelToRename, ModelToChangeNamespace propertyModelToChangeNamespace, ModelWithCustomizedProperties propertyModelWithCustomizedProperties, RenamedEnum? propertyEnumToRename, EnumWithValueToRename? propertyEnumWithValueToRename, EnumToBeMadeExtensible? propertyEnumToBeMadeExtensible, ModelToAddAdditionalSerializableProperty propertyModelToAddAdditionalSerializableProperty, NormalEnum? propertyToMoveToCustomization, ModelStruct? propertyModelStruct, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PropertyExtensibleEnum = propertyExtensibleEnum;
            PropertyModelToMakeInternal = propertyModelToMakeInternal;
            PropertyModelToRename = propertyModelToRename;
            PropertyModelToChangeNamespace = propertyModelToChangeNamespace;
            PropertyModelWithCustomizedProperties = propertyModelWithCustomizedProperties;
            PropertyEnumToRename = propertyEnumToRename;
            PropertyEnumWithValueToRename = propertyEnumWithValueToRename;
            PropertyEnumToBeMadeExtensible = propertyEnumToBeMadeExtensible;
            PropertyModelToAddAdditionalSerializableProperty = propertyModelToAddAdditionalSerializableProperty;
            PropertyToMoveToCustomization = propertyToMoveToCustomization;
            PropertyModelStruct = propertyModelStruct;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> ExtensibleEnumWithOperator. </summary>
        public ExtensibleEnumWithOperator? PropertyExtensibleEnum { get; set; }
        /// <summary> ModelToRename. </summary>
        public RenamedModel PropertyModelToRename { get; set; }
        /// <summary> ModelToChangeNamespace. </summary>
        public ModelToChangeNamespace PropertyModelToChangeNamespace { get; set; }
        /// <summary> ModelWithCustomizedProperties. </summary>
        public ModelWithCustomizedProperties PropertyModelWithCustomizedProperties { get; set; }
        /// <summary> EnumToRename. </summary>
        public RenamedEnum? PropertyEnumToRename { get; set; }
        /// <summary> EnumWithValueToRename. </summary>
        public EnumWithValueToRename? PropertyEnumWithValueToRename { get; set; }
        /// <summary> EnumToBeMadeExtensible. </summary>
        public EnumToBeMadeExtensible? PropertyEnumToBeMadeExtensible { get; set; }
        /// <summary> ModelToAddAdditionalSerializableProperty. </summary>
        public ModelToAddAdditionalSerializableProperty PropertyModelToAddAdditionalSerializableProperty { get; set; }
        /// <summary> ModelStruct. </summary>
        public ModelStruct? PropertyModelStruct { get; set; }
    }
}
