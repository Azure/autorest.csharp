// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AdditionalProperties.Models
{
    using Fixtures.AdditionalProperties;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class WithUntypedDictionary
    {
        /// <summary>
        /// Initializes a new instance of the WithUntypedDictionary class.
        /// </summary>
        public WithUntypedDictionary()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WithUntypedDictionary class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        public WithUntypedDictionary(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string abc = default(string))
        {
            AdditionalProperties = additionalProperties;
            Abc = abc;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unmatched properties from the message are deserialized
        /// this collection
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abc")]
        public string Abc { get; set; }

    }
}
