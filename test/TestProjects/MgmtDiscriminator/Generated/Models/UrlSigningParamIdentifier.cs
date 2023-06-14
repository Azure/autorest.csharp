// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines how to identify a parameter for a specific purpose e.g. expires. </summary>
    public partial class UrlSigningParamIdentifier
    {
        /// <summary> Initializes a new instance of UrlSigningParamIdentifier. </summary>
        /// <param name="paramIndicator"> Indicates the purpose of the parameter. </param>
        /// <param name="paramName"> Parameter name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="paramName"/> is null. </exception>
        public UrlSigningParamIdentifier(ParamIndicator paramIndicator, string paramName)
        {
            Argument.AssertNotNull(paramName, nameof(paramName));

            ParamIndicator = paramIndicator;
            ParamName = paramName;
        }

        /// <summary> Indicates the purpose of the parameter. </summary>
        public ParamIndicator ParamIndicator { get; set; }
        /// <summary> Parameter name. </summary>
        public string ParamName { get; set; }
    }
}
