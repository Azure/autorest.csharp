// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.Azure.Fluent.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Fixtures.Azure;
    using Fixtures.Azure.Fluent;
    using Fixtures.Azure.Fluent.AcceptanceTestsAzureCompositeModelClient;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ReadonlyObjInner
    {
        /// <summary>
        /// Initializes a new instance of the ReadonlyObjInner class.
        /// </summary>
        public ReadonlyObjInner()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ReadonlyObjInner class.
        /// </summary>
        public ReadonlyObjInner(string id = default(string), int? size = default(int?))
        {
            Id = id;
            Size = size;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int? Size { get; set; }

    }
}
