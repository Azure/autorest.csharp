// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Pagination
{
    /// <summary> A Class representing a PageSizeNumericModel along with the instance operations that can be performed on it. </summary>
    public class PageSizeNumericModel : PageSizeNumericModelOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "PageSizeNumericModel"/> class for mocking. </summary>
        protected PageSizeNumericModel() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PageSizeNumericModel"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PageSizeNumericModel(OperationsBase options, PageSizeNumericModelData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the PageSizeNumericModelData. </summary>
        public virtual PageSizeNumericModelData Data { get; private set; }
    }
}
