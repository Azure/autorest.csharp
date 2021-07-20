// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A Class representing a TheExtensionFake along with the instance operations that can be performed on it. </summary>
    public class TheExtensionFake : TheExtensionFakeOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "TheExtensionFake"/> class for mocking. </summary>
        internal TheExtensionFake() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "TheExtensionFake"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TheExtensionFake(OperationsBase options, TheExtensionData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the TheExtensionData. </summary>
        public TheExtensionData Data { get; private set; }
    }
}
