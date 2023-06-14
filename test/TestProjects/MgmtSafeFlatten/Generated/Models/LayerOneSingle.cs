// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerOneSingle. </summary>
    internal partial class LayerOneSingle
    {
        /// <summary> Initializes a new instance of LayerOneSingle. </summary>
        public LayerOneSingle()
        {
        }

        /// <summary> Initializes a new instance of LayerOneSingle. </summary>
        /// <param name="layerTwo"> The second single value prop. </param>
        internal LayerOneSingle(LayerTwoSingle layerTwo)
        {
            LayerTwo = layerTwo;
        }

        /// <summary> The second single value prop. </summary>
        internal LayerTwoSingle LayerTwo { get; set; }
        /// <summary> MyProp description. </summary>
        public string LayerTwoMyProp
        {
            get => LayerTwo is null ? default : LayerTwo.MyProp;
            set
            {
                if (LayerTwo is null)
                    LayerTwo = new LayerTwoSingle();
                LayerTwo.MyProp = value;
            }
        }
    }
}
