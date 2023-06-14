// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Parameters.Spread.Models
{
    /// <summary> The SpreadWithMultipleParametersRequest. </summary>
    internal partial class SpreadWithMultipleParametersRequest
    {
        /// <summary> Initializes a new instance of SpreadWithMultipleParametersRequest. </summary>
        /// <param name="prop1"></param>
        /// <param name="prop2"></param>
        /// <param name="prop3"></param>
        /// <param name="prop4"></param>
        /// <param name="prop5"></param>
        /// <param name="prop6"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop1"/>, <paramref name="prop2"/>, <paramref name="prop3"/>, <paramref name="prop4"/>, <paramref name="prop5"/> or <paramref name="prop6"/> is null. </exception>
        public SpreadWithMultipleParametersRequest(string prop1, string prop2, string prop3, string prop4, string prop5, string prop6)
        {
            Argument.AssertNotNull(prop1, nameof(prop1));
            Argument.AssertNotNull(prop2, nameof(prop2));
            Argument.AssertNotNull(prop3, nameof(prop3));
            Argument.AssertNotNull(prop4, nameof(prop4));
            Argument.AssertNotNull(prop5, nameof(prop5));
            Argument.AssertNotNull(prop6, nameof(prop6));

            Prop1 = prop1;
            Prop2 = prop2;
            Prop3 = prop3;
            Prop4 = prop4;
            Prop5 = prop5;
            Prop6 = prop6;
        }

        /// <summary> Gets the prop 1. </summary>
        public string Prop1 { get; }
        /// <summary> Gets the prop 2. </summary>
        public string Prop2 { get; }
        /// <summary> Gets the prop 3. </summary>
        public string Prop3 { get; }
        /// <summary> Gets the prop 4. </summary>
        public string Prop4 { get; }
        /// <summary> Gets the prop 5. </summary>
        public string Prop5 { get; }
        /// <summary> Gets the prop 6. </summary>
        public string Prop6 { get; }
    }
}
