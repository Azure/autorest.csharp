// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsExtensibleEnums.Models
{
    using Newtonsoft.Json;

    using System.Reflection;
    /// <summary>
    /// Defines values for DaysOfWeekExtensibleEnum.
    /// </summary>
    public sealed class DaysOfWeekExtensibleEnumConverter : JsonConverter
    {

        /// <summary>
        /// Returns if objectType can be converted to DaysOfWeekExtensibleEnum
        /// by the converter.
        /// </summary>
        public override bool CanConvert(System.Type objectType) => typeof(DaysOfWeekExtensibleEnum).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        /// <summary>
        /// Overrides ReadJson and converts token to DaysOfWeekExtensibleEnum.
        /// </summary>
        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            return (DaysOfWeekExtensibleEnum)serializer.Deserialize<string>(reader);
        }

        /// <summary>
        /// Overriding WriteJson for DaysOfWeekExtensibleEnum for
        /// serialization.
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(value.ToString());

    }
}
