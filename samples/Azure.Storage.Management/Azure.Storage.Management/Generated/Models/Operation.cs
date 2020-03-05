// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Storage REST API operation definition. </summary>
    public partial class Operation
    {
        /// <summary> Operation name: {provider}/{resource}/{operation}. </summary>
        public string Name { get; set; }
        /// <summary> Display metadata associated with the operation. </summary>
        public OperationDisplay Display { get; set; }
        /// <summary> The origin of operations. </summary>
        public string Origin { get; set; }
        /// <summary> One property of operation, include metric specifications. </summary>
        public ServiceSpecification ServiceSpecification { get; set; }
    }
}
