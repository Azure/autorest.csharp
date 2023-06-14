// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the Url Signing action. </summary>
    public partial class UrlSigningActionParameters
    {
        /// <summary> Initializes a new instance of UrlSigningActionParameters. </summary>
        /// <param name="typeName"></param>
        public UrlSigningActionParameters(UrlSigningActionParametersTypeName typeName)
        {
            TypeName = typeName;
            ParameterNameOverride = new ChangeTrackingList<UrlSigningParamIdentifier>();
        }

        /// <summary> Initializes a new instance of UrlSigningActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="algorithm"> Algorithm to use for URL signing. </param>
        /// <param name="parameterNameOverride"> Defines which query string parameters in the url to be considered for expires, key id etc. </param>
        internal UrlSigningActionParameters(UrlSigningActionParametersTypeName typeName, Algorithm? algorithm, IList<UrlSigningParamIdentifier> parameterNameOverride)
        {
            TypeName = typeName;
            Algorithm = algorithm;
            ParameterNameOverride = parameterNameOverride;
        }

        /// <summary> Gets or sets the type name. </summary>
        public UrlSigningActionParametersTypeName TypeName { get; set; }
        /// <summary> Algorithm to use for URL signing. </summary>
        public Algorithm? Algorithm { get; set; }
        /// <summary> Defines which query string parameters in the url to be considered for expires, key id etc. </summary>
        public IList<UrlSigningParamIdentifier> ParameterNameOverride { get; }
    }
}
