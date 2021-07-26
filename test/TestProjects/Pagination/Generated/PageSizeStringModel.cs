// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Pagination
{
    /// <summary> A Class representing a PageSizeStringModel along with the instance operations that can be performed on it. </summary>
    public class PageSizeStringModel : PageSizeStringModelOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "PageSizeStringModel"/> class for mocking. </summary>
        protected PageSizeStringModel() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PageSizeStringModel"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PageSizeStringModel(OperationsBase options, PageSizeStringModelData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the PageSizeStringModelData. </summary>
        public virtual PageSizeStringModelData Data { get; private set; }
    }
}
