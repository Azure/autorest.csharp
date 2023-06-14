// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class SuperDeepSinglePropertyModel
    {
        /// <summary> Initializes a new instance of SuperDeepSinglePropertyModel. </summary>
        public SuperDeepSinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of SuperDeepSinglePropertyModel. </summary>
        /// <param name="super"> This is a single property of string. </param>
        internal SuperDeepSinglePropertyModel(VeryDeepSinglePropertyModel super)
        {
            Super = super;
        }

        /// <summary> This is a single property of string. </summary>
        internal VeryDeepSinglePropertyModel Super { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => Super is null ? default : Super.DeepSomething;
            set
            {
                if (Super is null)
                    Super = new VeryDeepSinglePropertyModel();
                Super.DeepSomething = value;
            }
        }
    }
}
