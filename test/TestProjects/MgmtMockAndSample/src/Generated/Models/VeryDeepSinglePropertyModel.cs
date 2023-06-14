// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class VeryDeepSinglePropertyModel
    {
        /// <summary> Initializes a new instance of VeryDeepSinglePropertyModel. </summary>
        public VeryDeepSinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of VeryDeepSinglePropertyModel. </summary>
        /// <param name="very"> This is a single property of string. </param>
        internal VeryDeepSinglePropertyModel(DeepSinglePropertyModel very)
        {
            Very = very;
        }

        /// <summary> This is a single property of string. </summary>
        internal DeepSinglePropertyModel Very { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => Very is null ? default : Very.DeepSomething;
            set
            {
                if (Very is null)
                    Very = new DeepSinglePropertyModel();
                Very.DeepSomething = value;
            }
        }
    }
}
