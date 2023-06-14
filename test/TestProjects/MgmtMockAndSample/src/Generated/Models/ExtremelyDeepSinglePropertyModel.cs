// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class ExtremelyDeepSinglePropertyModel
    {
        /// <summary> Initializes a new instance of ExtremelyDeepSinglePropertyModel. </summary>
        public ExtremelyDeepSinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of ExtremelyDeepSinglePropertyModel. </summary>
        /// <param name="extreme"> This is a single property of string. </param>
        internal ExtremelyDeepSinglePropertyModel(SuperDeepSinglePropertyModel extreme)
        {
            Extreme = extreme;
        }

        /// <summary> This is a single property of string. </summary>
        internal SuperDeepSinglePropertyModel Extreme { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => Extreme is null ? default : Extreme.DeepSomething;
            set
            {
                if (Extreme is null)
                    Extreme = new SuperDeepSinglePropertyModel();
                Extreme.DeepSomething = value;
            }
        }
    }
}
