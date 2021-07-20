// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;
using Pagination.Models;

namespace Pagination
{
    /// <summary> A Class representing a PageSizeDecimalModel along with the instance operations that can be performed on it. </summary>
    public class PageSizeDecimalModel : PageSizeDecimalModelOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "PageSizeDecimalModel"/> class for mocking. </summary>
        internal PageSizeDecimalModel() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PageSizeDecimalModel"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PageSizeDecimalModel(OperationsBase options, PageSizeDecimalModelData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the PageSizeDecimalModelData. </summary>
        public PageSizeDecimalModelData Data { get; private set; }
    }
}
