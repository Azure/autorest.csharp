// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A Class representing a Bar along with the instance operations that can be performed on it. </summary>
    public class Bar : BarOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "Bar"/> class for mocking. </summary>
        internal Bar() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Bar"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal Bar(OperationsBase options, BarData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the BarData. </summary>
        public BarData Data { get; private set; }
    }
}
