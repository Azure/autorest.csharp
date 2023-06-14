// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the request header action. </summary>
    public partial class HeaderActionParameters
    {
        /// <summary> Initializes a new instance of HeaderActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="headerAction"> Action to perform. </param>
        /// <param name="headerName"> Name of the header to modify. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerName"/> is null. </exception>
        public HeaderActionParameters(HeaderActionParametersTypeName typeName, HeaderAction headerAction, string headerName)
        {
            Argument.AssertNotNull(headerName, nameof(headerName));

            TypeName = typeName;
            HeaderAction = headerAction;
            HeaderName = headerName;
        }

        /// <summary> Initializes a new instance of HeaderActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="headerAction"> Action to perform. </param>
        /// <param name="headerName"> Name of the header to modify. </param>
        /// <param name="value"> Value for the specified action. </param>
        internal HeaderActionParameters(HeaderActionParametersTypeName typeName, HeaderAction headerAction, string headerName, string value)
        {
            TypeName = typeName;
            HeaderAction = headerAction;
            HeaderName = headerName;
            Value = value;
        }

        /// <summary> Gets or sets the type name. </summary>
        public HeaderActionParametersTypeName TypeName { get; set; }
        /// <summary> Action to perform. </summary>
        public HeaderAction HeaderAction { get; set; }
        /// <summary> Name of the header to modify. </summary>
        public string HeaderName { get; set; }
        /// <summary> Value for the specified action. </summary>
        public string Value { get; set; }
    }
}
