// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class DeepSinglePropertyModel
    {
        /// <summary> Initializes a new instance of <see cref="DeepSinglePropertyModel"/>. </summary>
        public DeepSinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeepSinglePropertyModel"/>. </summary>
        /// <param name="deep"> This is a single property of string. </param>
        internal DeepSinglePropertyModel(SinglePropertyModel deep)
        {
            Deep = deep;
        }

        /// <summary> This is a single property of string. </summary>
        internal SinglePropertyModel Deep { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => Deep is null ? default : Deep.Something;
            set
            {
                if (Deep is null)
                    Deep = new SinglePropertyModel();
                Deep.Something = value;
            }
        }
    }
}
