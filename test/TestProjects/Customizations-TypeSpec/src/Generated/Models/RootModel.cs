// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CustomizationsInCadl.Models
{
    /// <summary> Root RoundTrip model to reference all other types to ensure generation. </summary>
    public partial class RootModel
    {
        /// <summary> Initializes a new instance of RootModel. </summary>
        public RootModel()
        {
        }

        /// <summary> Initializes a new instance of RootModel. </summary>
        /// <param name="propertyModelToMakeInternal"> ModelToMakeInternal. </param>
        /// <param name="propertyModelToRename"> ModelToRename. </param>
        /// <param name="propertyModelToChangeNamespace"> ModelToChangeNamespace. </param>
        /// <param name="propertyModelWithCustomizedProperties"> ModelWithCustomizedProperties. </param>
        /// <param name="propertyEnumToRename"> EnumToRename. </param>
        /// <param name="propertyEnumWithValueToRename"> EnumWithValueToRename. </param>
        /// <param name="propertyEnumToBeMadeExtensible"> EnumToBeMadeExtensible. </param>
        /// <param name="propertyModelToAddAdditionalSerializableProperty"> ModelToAddAdditionalSerializableProperty. </param>
        internal RootModel(ModelToMakeInternal propertyModelToMakeInternal, RenamedModel propertyModelToRename, ModelToChangeNamespace propertyModelToChangeNamespace, ModelWithCustomizedProperties propertyModelWithCustomizedProperties, RenamedEnum? propertyEnumToRename, EnumWithValueToRename? propertyEnumWithValueToRename, EnumToBeMadeExtensible? propertyEnumToBeMadeExtensible, ModelToAddAdditionalSerializableProperty propertyModelToAddAdditionalSerializableProperty)
        {
            PropertyModelToMakeInternal = propertyModelToMakeInternal;
            PropertyModelToRename = propertyModelToRename;
            PropertyModelToChangeNamespace = propertyModelToChangeNamespace;
            PropertyModelWithCustomizedProperties = propertyModelWithCustomizedProperties;
            PropertyEnumToRename = propertyEnumToRename;
            PropertyEnumWithValueToRename = propertyEnumWithValueToRename;
            PropertyEnumToBeMadeExtensible = propertyEnumToBeMadeExtensible;
            PropertyModelToAddAdditionalSerializableProperty = propertyModelToAddAdditionalSerializableProperty;
        }
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
    }
}
