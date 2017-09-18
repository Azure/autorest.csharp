// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AcceptanceTestsModelFlattening.Models
{
    using Fixtures.AcceptanceTestsModelFlattening;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The product documentation.
    /// </summary>
    public partial class BaseProduct
    {
        /// <summary>
        /// Initializes a new instance of the BaseProduct class.
        /// </summary>
        public BaseProduct()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BaseProduct class.
        /// </summary>
        /// <param name="productId">Unique identifier representing a specific
        /// product for a given latitude &amp; longitude. For example, uberX in
        /// San Francisco will have a different product_id than uberX in Los
        /// Angeles.</param>
        /// <param name="description">Description of product.</param>
        public BaseProduct(string productId, string description = default(string))
        {
            ProductId = productId;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unique identifier representing a specific product for
        /// a given latitude &amp;amp; longitude. For example, uberX in San
        /// Francisco will have a different product_id than uberX in Los
        /// Angeles.
        /// </summary>
        [JsonProperty(PropertyName = "base_product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets description of product.
        /// </summary>
        [JsonProperty(PropertyName = "base_product_description")]
        public string Description { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ProductId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ProductId");
            }
        }
    }
}
