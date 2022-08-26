// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CustomizationsInCadl
{
    /// <summary> Root RoundTrip model to reference all other types to ensure generation. </summary>
    public partial class RootModel
    {
        /// <summary> Initializes a new instance of RootModel. </summary>
        public RootModel()
        {
        }
        /// <summary> Initializes a new instance of RootModel. </summary>
        /// <param name="propertyModelToMakeInternal"></param>
        /// <param name="propertyModelToRename"></param>
        /// <param name="propertyModelToChangeNamespace"></param>
        /// <param name="propertyModelWithCustomizedProperties"></param>
        /// <param name="propertyEnumToRename"></param>
        /// <param name="propertyEnumWithValueToRename"></param>
        /// <param name="propertyEnumToBeMadeExtensible"></param>
        internal RootModel(ModelToMakeInternal propertyModelToMakeInternal, ModelToRename propertyModelToRename, ModelToChangeNamespace propertyModelToChangeNamespace, ModelWithCustomizedProperties propertyModelWithCustomizedProperties, EnumToRename? propertyEnumToRename, EnumWithValueToRename? propertyEnumWithValueToRename, EnumToBeMadeExtensible? propertyEnumToBeMadeExtensible)
        {
            PropertyModelToMakeInternal = propertyModelToMakeInternal;
            PropertyModelToRename = propertyModelToRename;
            PropertyModelToChangeNamespace = propertyModelToChangeNamespace;
            PropertyModelWithCustomizedProperties = propertyModelWithCustomizedProperties;
            PropertyEnumToRename = propertyEnumToRename;
            PropertyEnumWithValueToRename = propertyEnumWithValueToRename;
            PropertyEnumToBeMadeExtensible = propertyEnumToBeMadeExtensible;
        }

        public ModelToMakeInternal PropertyModelToMakeInternal { get; set; }

        public ModelToRename PropertyModelToRename { get; set; }

        public ModelToChangeNamespace PropertyModelToChangeNamespace { get; set; }

        public ModelWithCustomizedProperties PropertyModelWithCustomizedProperties { get; set; }

        public EnumToRename? PropertyEnumToRename { get; set; }

        public EnumWithValueToRename? PropertyEnumWithValueToRename { get; set; }

        public EnumToBeMadeExtensible? PropertyEnumToBeMadeExtensible { get; set; }
    }
}
