// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Payload.JsonMergePatch.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class PayloadJsonMergePatchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.BaseModel"/>. </summary>
        /// <param name="requiredValue"></param>
        /// <param name="optionalValue"></param>
        /// <param name="kind"></param>
        /// <returns> A new <see cref="Models.BaseModel"/> instance for mocking. </returns>
        public static BaseModel BaseModel(BinaryData requiredValue = null, BinaryData optionalValue = null, string kind = null)
        {
            return new UnknownBaseModel(requiredValue, optionalValue, kind, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.IntValueModel"/>. </summary>
        /// <param name="requiredValue"></param>
        /// <param name="optionalValue"></param>
        /// <param name="requiredIntValue"></param>
        /// <param name="optionalIntValue"></param>
        /// <returns> A new <see cref="Models.IntValueModel"/> instance for mocking. </returns>
        public static IntValueModel IntValueModel(BinaryData requiredValue = null, BinaryData optionalValue = null, int requiredIntValue = default, int? optionalIntValue = null)
        {
            return new IntValueModel(requiredValue, optionalValue, "intValue", serializedAdditionalRawData: null, requiredIntValue, optionalIntValue);
        }

        /// <summary> Initializes a new instance of <see cref="Models.StringValueModel"/>. </summary>
        /// <param name="requiredValue"></param>
        /// <param name="optionalValue"></param>
        /// <param name="requiredStringValue"></param>
        /// <param name="optionalStringValue"></param>
        /// <returns> A new <see cref="Models.StringValueModel"/> instance for mocking. </returns>
        public static StringValueModel StringValueModel(BinaryData requiredValue = null, BinaryData optionalValue = null, string requiredStringValue = null, string optionalStringValue = null)
        {
            return new StringValueModel(requiredValue, optionalValue, "string", serializedAdditionalRawData: null, requiredStringValue, optionalStringValue);
        }
    }
}
