﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Azure.Core;
using MgmtDiscriminator.Models;

namespace MgmtDiscriminator
{
    /// <summary>
    ///
    /// </summary>
    [CodeGenSerialization(nameof(LocationWithCustomSerialization), BicepSerializationValueHook = nameof(SerializeLocation))]
    public partial class DeliveryRuleData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeLocation(StringBuilder builder)
        {
            // this is the logic we would like to have for the value serialization
            builder.AppendLine($"'{AzureLocation.BrazilSouth}'");
        }

        /// <summary>
        /// The unflattened name property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("unflattened.name")]
        public string UnflattenedName
        {
            get => Unflattened is null ? default : Unflattened.Name;
            set
            {
                if (Unflattened is null)
                    Unflattened = new Unflattened();
                Unflattened.Name = value;
            }
        }
    }
}
