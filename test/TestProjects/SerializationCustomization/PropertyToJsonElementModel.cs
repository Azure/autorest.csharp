// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace SerializationCustomization.Models
{
    public partial class PropertyToJsonElementModel
    {
        public JsonElement ArrayProperty { get; set; }
        public JsonElement ModelProperty { get; set; }
        /// <summary> Any object. </summary>
        public JsonElement ObjectProperty { get; set; }
    }
}