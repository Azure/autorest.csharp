// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AzureCompositeModelClient.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Datetimerfc1123WrapperInner
    {
        /// <summary>
        /// Initializes a new instance of the Datetimerfc1123WrapperInner
        /// class.
        /// </summary>
        public Datetimerfc1123WrapperInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Datetimerfc1123WrapperInner
        /// class.
        /// </summary>
        public Datetimerfc1123WrapperInner(System.DateTime? field = default(System.DateTime?), System.DateTime? now = default(System.DateTime?))
        {
            Field = field;
            Now = now;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "field")]
        public System.DateTime? Field { get; set; }

        /// <summary>
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "now")]
        public System.DateTime? Now { get; set; }

    }
}
