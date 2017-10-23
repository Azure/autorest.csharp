// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsHeader.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for responseExistingKey operation.
    /// </summary>
    public partial class HeaderResponseExistingKeyHeaders
    {
        /// <summary>
        /// Initializes a new instance of the HeaderResponseExistingKeyHeaders
        /// class.
        /// </summary>
        public HeaderResponseExistingKeyHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets response with header value "User-Agent": "overwrite"
        /// </summary>
        [JsonProperty(PropertyName = "User-Agent")]
        public string UserAgent { get; set; }

    }
}
