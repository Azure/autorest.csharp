// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using NamespaceForEnums;

namespace CustomNamespace
{
    /// <summary> The ModelStruct. </summary>
    internal readonly partial struct RenamedModelStruct
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private readonly Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="RenamedModelStruct"/>. </summary>
        /// <param name="customizedFlattenedStringProperty"> . </param>
        /// <param name="propertyToField"> . </param>
        /// <param name="fruit"> Fruit. </param>
        /// <param name="daysOfWeek"> Day of week. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customizedFlattenedStringProperty"/> or <paramref name="propertyToField"/> is null. </exception>
        public RenamedModelStruct(string customizedFlattenedStringProperty, string propertyToField, CustomFruitEnum? fruit, CustomDaysOfWeek? daysOfWeek)
        {
            Argument.AssertNotNull(customizedFlattenedStringProperty, nameof(customizedFlattenedStringProperty));
            Argument.AssertNotNull(propertyToField, nameof(propertyToField));

            CustomizedFlattenedStringProperty = customizedFlattenedStringProperty;
            PropertyToField = propertyToField;
            Fruit = fruit;
            DaysOfWeek = daysOfWeek;
        }

        /// <summary> Initializes a new instance of <see cref="RenamedModelStruct"/>. </summary>
        /// <param name="customizedFlattenedStringProperty"> . </param>
        /// <param name="propertyToField"> . </param>
        /// <param name="fruit"> Fruit. </param>
        /// <param name="daysOfWeek"> Day of week. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RenamedModelStruct(string customizedFlattenedStringProperty, string propertyToField, CustomFruitEnum? fruit, CustomDaysOfWeek? daysOfWeek, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            CustomizedFlattenedStringProperty = customizedFlattenedStringProperty;
            PropertyToField = propertyToField;
            Fruit = fruit;
            DaysOfWeek = daysOfWeek;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary> . </summary>
        public string PropertyToField { get; }
        /// <summary> Fruit. </summary>
        public CustomFruitEnum? Fruit { get; }
        /// <summary> Day of week. </summary>
        public CustomDaysOfWeek? DaysOfWeek { get; }
    }
}
