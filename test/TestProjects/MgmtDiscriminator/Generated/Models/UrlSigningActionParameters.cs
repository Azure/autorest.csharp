// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the Url Signing action. </summary>
    public partial class UrlSigningActionParameters
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="UrlSigningActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        public UrlSigningActionParameters(UrlSigningActionParametersTypeName typeName)
        {
            TypeName = typeName;
            ParameterNameOverride = new ChangeTrackingList<UrlSigningParamIdentifier>();
        }

        /// <summary> Initializes a new instance of <see cref="UrlSigningActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="algorithm"> Algorithm to use for URL signing. </param>
        /// <param name="parameterNameOverride"> Defines which query string parameters in the url to be considered for expires, key id etc. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UrlSigningActionParameters(UrlSigningActionParametersTypeName typeName, Algorithm? algorithm, IList<UrlSigningParamIdentifier> parameterNameOverride, Dictionary<string, BinaryData> rawData)
        {
            TypeName = typeName;
            Algorithm = algorithm;
            ParameterNameOverride = parameterNameOverride;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="UrlSigningActionParameters"/> for deserialization. </summary>
        internal UrlSigningActionParameters()
        {
        }

        /// <summary> Gets or sets the type name. </summary>
        public UrlSigningActionParametersTypeName TypeName { get; set; }
        /// <summary> Algorithm to use for URL signing. </summary>
        public Algorithm? Algorithm { get; set; }
        /// <summary> Defines which query string parameters in the url to be considered for expires, key id etc. </summary>
        public IList<UrlSigningParamIdentifier> ParameterNameOverride { get; }
    }
}
