// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Specifies information about the image to use. You can specify information about platform images, marketplace images, or virtual machine images. This element is required when you want to use a platform image, marketplace image, or virtual machine image, but is not used in other creation operations. NOTE: Image reference publisher and offer can only be set when you create the scale set. </summary>
    public partial class ImageReference : WritableSubResource
    {
        /// <summary> Initializes a new instance of ImageReference. </summary>
        public ImageReference()
        {
        }

        /// <summary> Initializes a new instance of ImageReference. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="publisher"> The image publisher. </param>
        /// <param name="offer"> Specifies the offer of the platform image or marketplace image used to create the virtual machine. </param>
        /// <param name="sku"> The image SKU. </param>
        /// <param name="version"> Specifies the version of the platform image or marketplace image used to create the virtual machine. The allowed formats are Major.Minor.Build or &apos;latest&apos;. Major, Minor, and Build are decimal numbers. Specify &apos;latest&apos; to use the latest version of an image available at deploy time. Even if you use &apos;latest&apos;, the VM image will not automatically update after deploy time even if a new version becomes available. </param>
        /// <param name="exactVersion"> Specifies in decimal numbers, the version of platform image or marketplace image used to create the virtual machine. This readonly field differs from &apos;version&apos;, only if the value specified in &apos;version&apos; field is &apos;latest&apos;. </param>
        internal ImageReference(string id, string publisher, string offer, string sku, string version, string exactVersion) : base(id)
        {
            Publisher = publisher;
            Offer = offer;
            Sku = sku;
            Version = version;
            ExactVersion = exactVersion;
        }

        /// <summary> The image publisher. </summary>
        public string Publisher { get; set; }
        /// <summary> Specifies the offer of the platform image or marketplace image used to create the virtual machine. </summary>
        public string Offer { get; set; }
        /// <summary> The image SKU. </summary>
        public string Sku { get; set; }
        /// <summary> Specifies the version of the platform image or marketplace image used to create the virtual machine. The allowed formats are Major.Minor.Build or &apos;latest&apos;. Major, Minor, and Build are decimal numbers. Specify &apos;latest&apos; to use the latest version of an image available at deploy time. Even if you use &apos;latest&apos;, the VM image will not automatically update after deploy time even if a new version becomes available. </summary>
        public string Version { get; set; }
        /// <summary> Specifies in decimal numbers, the version of platform image or marketplace image used to create the virtual machine. This readonly field differs from &apos;version&apos;, only if the value specified in &apos;version&apos; field is &apos;latest&apos;. </summary>
        public string ExactVersion { get; }
    }
}
