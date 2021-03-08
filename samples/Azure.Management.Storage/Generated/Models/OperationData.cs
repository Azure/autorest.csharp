// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Management.Storage.Models
{
    /// <summary> A class representing the Operation data model. </summary>
    public partial class OperationData
    {
        /// <summary> Operation name: {provider}/{resource}/{operation}. </summary>
        public string Name { get; }
        /// <summary> Display metadata associated with the operation. </summary>
        public OperationDisplay Display { get; }
        /// <summary> The origin of operations. </summary>
        public string Origin { get; }
        /// <summary> One property of operation, include metric specifications. </summary>
        public ServiceSpecification ServiceSpecification { get; }
    }
}
