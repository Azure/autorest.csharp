// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace TypeSchemaMapping.Models
{
    /// <summary> The PublicModelWithInternalProperty. </summary>
    public partial class PublicModelWithInternalProperty
    {
        /// <summary> Initializes a new instance of PublicModelWithInternalProperty. </summary>
        internal PublicModelWithInternalProperty()
        {
        }

        /// <summary> Initializes a new instance of PublicModelWithInternalProperty. </summary>
        /// <param name="stringPropertyJson"></param>
        /// <param name="publicProperty"></param>
        internal PublicModelWithInternalProperty(JsonElement stringPropertyJson, string publicProperty)
        {
            StringPropertyJson = stringPropertyJson;
            PublicProperty = publicProperty;
        }
        /// <summary> Gets the public property. </summary>
        public string PublicProperty { get; }
    }
}
