// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtOptionalConstant.Models
{
    /// <summary> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </summary>
    public partial class ModelWithOptionalConstant
    {
        /// <summary> Initializes a new instance of ModelWithOptionalConstant. </summary>
        public ModelWithOptionalConstant()
        {
        }

        /// <summary> Initializes a new instance of ModelWithOptionalConstant. </summary>
        /// <param name="optionalStringConstant"> A constant based on string, the only allowable value is default. </param>
        /// <param name="optionalIntConstant"> A constant based on integer. </param>
        /// <param name="optionalFloatConstant"> A constant based on float. </param>
        /// <param name="settingName"> Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon. </param>
        internal ModelWithOptionalConstant(StringConstant? optionalStringConstant, IntConstant? optionalIntConstant, FloatConstant? optionalFloatConstant, SettingName? settingName)
        {
            OptionalStringConstant = optionalStringConstant;
            OptionalIntConstant = optionalIntConstant;
            OptionalFloatConstant = optionalFloatConstant;
            SettingName = settingName;
        }

        /// <summary> A constant based on string, the only allowable value is default. </summary>
        public StringConstant? OptionalStringConstant { get; set; }
        /// <summary> A constant based on integer. </summary>
        public IntConstant? OptionalIntConstant { get; set; }
        /// <summary> A constant based on float. </summary>
        public FloatConstant? OptionalFloatConstant { get; set; }
        /// <summary> Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon. </summary>
        public SettingName? SettingName { get; set; }
    }
}
