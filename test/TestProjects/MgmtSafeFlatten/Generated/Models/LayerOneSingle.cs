// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerOneSingle. </summary>
    internal partial class LayerOneSingle
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="LayerOneSingle"/>. </summary>
        public LayerOneSingle()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LayerOneSingle"/>. </summary>
        /// <param name="layerTwo"> The second single value prop. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal LayerOneSingle(LayerTwoSingle layerTwo, Dictionary<string, BinaryData> rawData)
        {
            LayerTwo = layerTwo;
            _rawData = rawData;
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
