// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AcceptanceTestsLro.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class OperationResult
    {
        /// <summary>
        /// Initializes a new instance of the OperationResult class.
        /// </summary>
        public OperationResult()
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the status of the request. Possible values include:
        /// 'Succeeded', 'Failed', 'canceled', 'Accepted', 'Creating',
        /// 'Created', 'Updating', 'Updated', 'Deleting', 'Deleted', 'OK'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public OperationResultError Error { get; set; }

    }
}
