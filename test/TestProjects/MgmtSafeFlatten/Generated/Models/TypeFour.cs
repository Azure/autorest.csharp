// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSafeFlatten.Models
{
    /// <summary> The TypeFour. </summary>
    internal partial class TypeFour
    {
        /// <summary> Initializes a new instance of TypeFour. </summary>
        internal TypeFour()
        {
        }

        /// <summary> The details of the type. </summary>
        public string MyType { get; }
        /// <summary> The single value prop. </summary>
        internal LayerOneProperties Properties { get; }
        /// <summary> The id of layer one. </summary>
        public string LayerOneUniqueId
        {
            get => Properties?.UniqueId;
        }
    }
}
