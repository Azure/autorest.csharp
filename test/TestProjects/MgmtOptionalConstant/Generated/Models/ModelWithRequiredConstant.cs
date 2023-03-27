// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtOptionalConstant.Models
{
    /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
    public partial class ModelWithRequiredConstant
    {
        /// <summary> Initializes a new instance of ModelWithRequiredConstant. </summary>
        public ModelWithRequiredConstant()
        {
            RequiredStringConstant = StringConstant.Default;
            RequiredIntConstant = IntConstant._0;
        }

        /// <summary> Initializes a new instance of ModelWithRequiredConstant. </summary>
        /// <param name="requiredStringConstant"> A constant based on string, the only allowable value is default. </param>
        /// <param name="requiredIntConstant"> A constant based on integer. </param>
        /// <param name="protocol"> Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**. </param>
        internal ModelWithRequiredConstant(StringConstant requiredStringConstant, IntConstant requiredIntConstant, ProtocolType? protocol)
        {
            RequiredStringConstant = requiredStringConstant;
            RequiredIntConstant = requiredIntConstant;
            Protocol = protocol;
        }

        /// <summary> A constant based on string, the only allowable value is default. </summary>
        public StringConstant RequiredStringConstant { get; set; }
        /// <summary> A constant based on integer. </summary>
        public IntConstant RequiredIntConstant { get; set; }
        /// <summary> Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**. </summary>
        public ProtocolType? Protocol { get; set; }
    }
}
