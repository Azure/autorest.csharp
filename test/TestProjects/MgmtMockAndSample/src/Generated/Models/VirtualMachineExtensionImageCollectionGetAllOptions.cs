// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> The VirtualMachineExtensionImageCollectionGetAllOptions. </summary>
    public partial class VirtualMachineExtensionImageCollectionGetAllOptions
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionImageCollectionGetAllOptions. </summary>
        /// <param name="type"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        public VirtualMachineExtensionImageCollectionGetAllOptions(string type)
        {
            Argument.AssertNotNull(type, nameof(type));

            Type = type;
        }

        /// <summary> Gets the type. </summary>
        public string Type { get; }
        /// <summary> The filter to apply on the operation. </summary>
        public string Filter { get; set; }
        /// <summary> Gets or sets the top. </summary>
        public int? Top { get; set; }
        /// <summary> Gets or sets the orderby. </summary>
        public string Orderby { get; set; }
    }
}
