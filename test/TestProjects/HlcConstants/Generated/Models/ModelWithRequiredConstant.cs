// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace HlcConstants.Models
{
    /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
    public partial class ModelWithRequiredConstant
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithRequiredConstant"/>. </summary>
        public ModelWithRequiredConstant()
        {
            RequiredStringConstant = StringConstant.Default;
            RequiredIntConstant = IntConstant._0;
            RequiredBooleanConstant = true;
            RequiredFloatConstant = FloatConstant._314;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithRequiredConstant"/>. </summary>
        /// <param name="requiredStringConstant"> A constant based on string, the only allowable value is default. </param>
        /// <param name="requiredIntConstant"> A constant based on integer. </param>
        /// <param name="requiredBooleanConstant"> A constant based on boolean. </param>
        /// <param name="requiredFloatConstant"> A constant based on float. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithRequiredConstant(StringConstant requiredStringConstant, IntConstant requiredIntConstant, bool requiredBooleanConstant, FloatConstant requiredFloatConstant, Dictionary<string, BinaryData> rawData)
        {
            RequiredStringConstant = requiredStringConstant;
            RequiredIntConstant = requiredIntConstant;
            RequiredBooleanConstant = requiredBooleanConstant;
            RequiredFloatConstant = requiredFloatConstant;
            _rawData = rawData;
        }

        /// <summary> A constant based on string, the only allowable value is default. </summary>
        public StringConstant RequiredStringConstant { get; }
        /// <summary> A constant based on integer. </summary>
        public IntConstant RequiredIntConstant { get; }
        /// <summary> A constant based on boolean. </summary>
        public bool RequiredBooleanConstant { get; }
        /// <summary> A constant based on float. </summary>
        public FloatConstant RequiredFloatConstant { get; }
    }
}
