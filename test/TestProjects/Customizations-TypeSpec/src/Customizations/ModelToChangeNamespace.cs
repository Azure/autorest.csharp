// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace CustomizationsInTsp.Models
{
    [CodeGenModel("ModelToChangeNamespace")]
    public partial class ModelToChangeNamespace
    {
        /// <summary>
        /// Read-write property that will be changed to readonly.
        /// </summary>
        public bool? PropertyReadWriteToReadOnly { get; }
    }
}
