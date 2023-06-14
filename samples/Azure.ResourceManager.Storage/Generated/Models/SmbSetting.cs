// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Setting for SMB protocol. </summary>
    public partial class SmbSetting
    {
        /// <summary> Initializes a new instance of SmbSetting. </summary>
        public SmbSetting()
        {
        }

        /// <summary> Initializes a new instance of SmbSetting. </summary>
        /// <param name="multichannel"> Multichannel setting. Applies to Premium FileStorage only. </param>
        /// <param name="versions"> SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1. Should be passed as a string with delimiter ';'. </param>
        /// <param name="authenticationMethods"> SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos. Should be passed as a string with delimiter ';'. </param>
        /// <param name="kerberosTicketEncryption"> Kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256. Should be passed as a string with delimiter ';'. </param>
        /// <param name="channelEncryption"> SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM. Should be passed as a string with delimiter ';'. </param>
        internal SmbSetting(Multichannel multichannel, string versions, string authenticationMethods, string kerberosTicketEncryption, string channelEncryption)
        {
            Multichannel = multichannel;
            Versions = versions;
            AuthenticationMethods = authenticationMethods;
            KerberosTicketEncryption = kerberosTicketEncryption;
            ChannelEncryption = channelEncryption;
        }

        /// <summary> Multichannel setting. Applies to Premium FileStorage only. </summary>
        internal Multichannel Multichannel { get; set; }
        /// <summary> Indicates whether multichannel is enabled. </summary>
        public bool? MultichannelEnabled
        {
            get => Multichannel is null ? default : Multichannel.Enabled;
            set
            {
                if (Multichannel is null)
                    Multichannel = new Multichannel();
                Multichannel.Enabled = value;
            }
        }

        /// <summary> SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1. Should be passed as a string with delimiter ';'. </summary>
        public string Versions { get; set; }
        /// <summary> SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos. Should be passed as a string with delimiter ';'. </summary>
        public string AuthenticationMethods { get; set; }
        /// <summary> Kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256. Should be passed as a string with delimiter ';'. </summary>
        public string KerberosTicketEncryption { get; set; }
        /// <summary> SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM. Should be passed as a string with delimiter ';'. </summary>
        public string ChannelEncryption { get; set; }
    }
}
