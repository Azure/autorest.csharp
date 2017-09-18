// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsHttp.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class D
    {
        /// <summary>
        /// Initializes a new instance of the D class.
        /// </summary>
        public D()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the D class.
        /// </summary>
        public D(string httpStatusCode = default(string))
        {
            HttpStatusCode = httpStatusCode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "httpStatusCode")]
        public string HttpStatusCode { get; set; }

    }
}
