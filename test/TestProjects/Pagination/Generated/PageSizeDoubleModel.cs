// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Pagination
{
    /// <summary> A Class representing a PageSizeDoubleModel along with the instance operations that can be performed on it. </summary>
    public class PageSizeDoubleModel : PageSizeDoubleModelOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "PageSizeDoubleModel"/> class for mocking. </summary>
        protected PageSizeDoubleModel() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PageSizeDoubleModel"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PageSizeDoubleModel(OperationsBase options, PageSizeDoubleModelData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the PageSizeDoubleModelData. </summary>
        public virtual PageSizeDoubleModelData Data { get; private set; }
    }
}
