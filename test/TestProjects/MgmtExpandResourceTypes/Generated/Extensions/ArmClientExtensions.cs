// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;

namespace MgmtExpandResourceTypes
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region DnsZoneA
        /// <summary> Gets an object representing a DnsZoneA along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneA" /> object. </returns>
        public static DnsZoneA GetDnsZoneA(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneA(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneAAAA
        /// <summary> Gets an object representing a DnsZoneAAAA along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneAAAA" /> object. </returns>
        public static DnsZoneAAAA GetDnsZoneAAAA(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneAAAA(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneCAA
        /// <summary> Gets an object representing a DnsZoneCAA along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneCAA" /> object. </returns>
        public static DnsZoneCAA GetDnsZoneCAA(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneCAA(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneCNAME
        /// <summary> Gets an object representing a DnsZoneCNAME along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneCNAME" /> object. </returns>
        public static DnsZoneCNAME GetDnsZoneCNAME(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneCNAME(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneMX
        /// <summary> Gets an object representing a DnsZoneMX along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneMX" /> object. </returns>
        public static DnsZoneMX GetDnsZoneMX(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneMX(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneN
        /// <summary> Gets an object representing a DnsZoneN along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneN" /> object. </returns>
        public static DnsZoneN GetDnsZoneN(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneN(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZonePTR
        /// <summary> Gets an object representing a DnsZonePTR along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZonePTR" /> object. </returns>
        public static DnsZonePTR GetDnsZonePTR(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZonePTR(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneSOA
        /// <summary> Gets an object representing a DnsZoneSOA along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneSOA" /> object. </returns>
        public static DnsZoneSOA GetDnsZoneSOA(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneSOA(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneSRV
        /// <summary> Gets an object representing a DnsZoneSRV along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneSRV" /> object. </returns>
        public static DnsZoneSRV GetDnsZoneSRV(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneSRV(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region DnsZoneTXT
        /// <summary> Gets an object representing a DnsZoneTXT along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DnsZoneTXT" /> object. </returns>
        public static DnsZoneTXT GetDnsZoneTXT(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new DnsZoneTXT(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region Zone
        /// <summary> Gets an object representing a Zone along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Zone" /> object. </returns>
        public static Zone GetZone(this ArmClient armClient, ResourceIdentifier id)
        {
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new Zone(clientOptions, credential, uri, pipeline, id));
        }
        #endregion
    }
}
