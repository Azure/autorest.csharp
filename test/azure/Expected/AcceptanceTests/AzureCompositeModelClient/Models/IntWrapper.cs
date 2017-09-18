// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class IntWrapper
    {
        /// <summary>
        /// Initializes a new instance of the IntWrapper class.
        /// </summary>
        public IntWrapper()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IntWrapper class.
        /// </summary>
        public IntWrapper(int? field1 = default(int?), int? field2 = default(int?))
        {
            Field1 = field1;
            Field2 = field2;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "field1")]
        public int? Field1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "field2")]
        public int? Field2 { get; set; }

    }
}
