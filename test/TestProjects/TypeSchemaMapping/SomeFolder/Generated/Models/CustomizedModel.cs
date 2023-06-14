// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using NamespaceForEnums;

namespace CustomNamespace
{
    /// <summary> The Model. </summary>
    internal partial class CustomizedModel
    {

        /// <summary> Initializes a new instance of CustomizedModel. </summary>
        /// <param name="propertyRenamedAndTypeChanged"> . </param>
        /// <param name="field"> . </param>
        /// <param name="customizedFancyField"> Fruit. </param>
        /// <param name="daysOfWeek"> Day of week. </param>
        internal CustomizedModel(int? propertyRenamedAndTypeChanged, string field, CustomFruitEnum customizedFancyField, CustomDaysOfWeek daysOfWeek)
        {
            PropertyRenamedAndTypeChanged = propertyRenamedAndTypeChanged;
            _field = field;
            CustomizedFancyField = customizedFancyField;
            DaysOfWeek = daysOfWeek;
        }
    }
}
