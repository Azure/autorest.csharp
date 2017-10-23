// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("cookiecuttershark")]
    public partial class Cookiecuttershark : Shark
    {
        /// <summary>
        /// Initializes a new instance of the Cookiecuttershark class.
        /// </summary>
        public Cookiecuttershark()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Cookiecuttershark class.
        /// </summary>
        public Cookiecuttershark(double length, System.DateTime birthday)
            : base(length, birthday)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
