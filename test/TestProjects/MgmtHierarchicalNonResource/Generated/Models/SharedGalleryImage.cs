// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using MgmtHierarchicalNonResource;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> Specifies information about the gallery image definition that you want to create or update. </summary>
    public partial class SharedGalleryImage : PirSharedGalleryResource
    {
        /// <summary> Initializes a new instance of <see cref="SharedGalleryImage"/>. </summary>
        internal SharedGalleryImage()
        {
            Features = new ChangeTrackingList<GalleryImageFeature>();
        }

        /// <summary> Initializes a new instance of <see cref="SharedGalleryImage"/>. </summary>
        /// <param name="name"> Resource name. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="uniqueId"> The unique id of this shared gallery. </param>
        /// <param name="osType"> This property allows you to specify the type of the OS that is included in the disk when creating a VM from a managed image. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**. </param>
        /// <param name="osState"> This property allows the user to specify whether the virtual machines created under this image are 'Generalized' or 'Specialized'. </param>
        /// <param name="endOfLifeOn"> The end of life date of the gallery image definition. This property can be used for decommissioning purposes. This property is updatable. </param>
        /// <param name="identifier"> This is the gallery image definition identifier. </param>
        /// <param name="recommended"> The properties describe the recommended machine configuration for this Image Definition. These properties are updatable. </param>
        /// <param name="disallowed"> Describes the disallowed disk types. </param>
        /// <param name="hyperVGeneration"> The hypervisor generation of the Virtual Machine. Applicable to OS disks only. </param>
        /// <param name="features"> A list of gallery image features. </param>
        /// <param name="purchasePlan"> Describes the gallery image definition purchase plan. This is used by marketplace images. </param>
        internal SharedGalleryImage(string name, string location, string uniqueId, OperatingSystemType? osType, OperatingSystemStateType? osState, DateTimeOffset? endOfLifeOn, GalleryImageIdentifier identifier, RecommendedMachineConfiguration recommended, Disallowed disallowed, HyperVGeneration? hyperVGeneration, IReadOnlyList<GalleryImageFeature> features, ImagePurchasePlan purchasePlan) : base(name, location, uniqueId)
        {
            OsType = osType;
            OsState = osState;
            EndOfLifeOn = endOfLifeOn;
            Identifier = identifier;
            Recommended = recommended;
            Disallowed = disallowed;
            HyperVGeneration = hyperVGeneration;
            Features = features;
            PurchasePlan = purchasePlan;
        }

        /// <summary> This property allows you to specify the type of the OS that is included in the disk when creating a VM from a managed image. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**. </summary>
        public OperatingSystemType? OsType { get; }
        /// <summary> This property allows the user to specify whether the virtual machines created under this image are 'Generalized' or 'Specialized'. </summary>
        public OperatingSystemStateType? OsState { get; }
        /// <summary> The end of life date of the gallery image definition. This property can be used for decommissioning purposes. This property is updatable. </summary>
        public DateTimeOffset? EndOfLifeOn { get; }
        /// <summary> This is the gallery image definition identifier. </summary>
        public GalleryImageIdentifier Identifier { get; }
        /// <summary> The properties describe the recommended machine configuration for this Image Definition. These properties are updatable. </summary>
        public RecommendedMachineConfiguration Recommended { get; }
        /// <summary> Describes the disallowed disk types. </summary>
        internal Disallowed Disallowed { get; }
        /// <summary> A list of disk types. </summary>
        public IReadOnlyList<string> DisallowedDiskTypes
        {
            get => Disallowed?.DiskTypes;
        }

        /// <summary> The hypervisor generation of the Virtual Machine. Applicable to OS disks only. </summary>
        public HyperVGeneration? HyperVGeneration { get; }
        /// <summary> A list of gallery image features. </summary>
        public IReadOnlyList<GalleryImageFeature> Features { get; }
        /// <summary> Describes the gallery image definition purchase plan. This is used by marketplace images. </summary>
        public ImagePurchasePlan PurchasePlan { get; }
    }
}
