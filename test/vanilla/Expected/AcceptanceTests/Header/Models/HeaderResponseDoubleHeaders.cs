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
    /// Defines headers for responseDouble operation.
    /// </summary>
    public partial class HeaderResponseDoubleHeaders
    {
        /// <summary>
        /// Initializes a new instance of the HeaderResponseDoubleHeaders
        /// class.
        /// </summary>
        public HeaderResponseDoubleHeaders()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HeaderResponseDoubleHeaders
        /// class.
        /// </summary>
        /// <param name="value">response with header value "value": 7e120 or
        /// -3.0</param>
        public HeaderResponseDoubleHeaders(double? value = default(double?))
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets response with header value "value": 7e120 or -3.0
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double? Value { get; set; }

    }
}
