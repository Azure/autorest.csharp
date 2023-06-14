// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Diagnostics information to help inspect the states of model or variable. </summary>
    public partial class DiagnosticsInfo
    {
        /// <summary> Initializes a new instance of DiagnosticsInfo. </summary>
        public DiagnosticsInfo()
        {
            VariableStates = new ChangeTrackingList<VariableState>();
        }

        /// <summary> Initializes a new instance of DiagnosticsInfo. </summary>
        /// <param name="modelState"> Model status. </param>
        /// <param name="variableStates"> Variable Status. </param>
        internal DiagnosticsInfo(ModelState modelState, IList<VariableState> variableStates)
        {
            ModelState = modelState;
            VariableStates = variableStates;
        }

        /// <summary> Model status. </summary>
        public ModelState ModelState { get; set; }
        /// <summary> Variable Status. </summary>
        public IList<VariableState> VariableStates { get; }
    }
}
