// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerTwoSingle. </summary>
    internal partial class LayerTwoSingle
    {
        /// <summary> Initializes a new instance of LayerTwoSingle. </summary>
        public LayerTwoSingle()
        {
        }

        /// <summary> Initializes a new instance of LayerTwoSingle. </summary>
        /// <param name="myProp"> MyProp description. </param>
        internal LayerTwoSingle(string myProp)
        {
            MyProp = myProp;
        }

        /// <summary> MyProp description. </summary>
        public string MyProp { get; set; }
    }
}
