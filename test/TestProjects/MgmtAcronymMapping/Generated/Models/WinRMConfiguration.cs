// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// Describes Windows Remote Management configuration of the VM
    /// Serialized Name: WinRMConfiguration
    /// </summary>
    internal partial class WinRMConfiguration
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="WinRMConfiguration"/>. </summary>
        public WinRMConfiguration()
        {
            Listeners = new ChangeTrackingList<WinRMListener>();
        }

        /// <summary> Initializes a new instance of <see cref="WinRMConfiguration"/>. </summary>
        /// <param name="listeners">
        /// The list of Windows Remote Management listeners
        /// Serialized Name: WinRMConfiguration.listeners
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal WinRMConfiguration(IList<WinRMListener> listeners, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Listeners = listeners;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The list of Windows Remote Management listeners
        /// Serialized Name: WinRMConfiguration.listeners
        /// </summary>
        public IList<WinRMListener> Listeners { get; }
    }
}
