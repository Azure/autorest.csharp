// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtNoTypeReplacement;

namespace MgmtNoTypeReplacement.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    internal partial class MgmtNoTypeReplacementArmClientMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtNoTypeReplacementArmClientMockingExtension"/> class for mocking. </summary>
        protected MgmtNoTypeReplacementArmClientMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtNoTypeReplacementArmClientMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtNoTypeReplacementArmClientMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MgmtNoTypeReplacementArmClientMockingExtension(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="NoTypeReplacementModel1Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NoTypeReplacementModel1Resource.CreateResourceIdentifier" /> to create a <see cref="NoTypeReplacementModel1Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NoTypeReplacementModel1Resource" /> object. </returns>
        public virtual NoTypeReplacementModel1Resource GetNoTypeReplacementModel1Resource(ResourceIdentifier id)
        {
            NoTypeReplacementModel1Resource.ValidateResourceId(id);
            return new NoTypeReplacementModel1Resource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NoTypeReplacementModel2Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NoTypeReplacementModel2Resource.CreateResourceIdentifier" /> to create a <see cref="NoTypeReplacementModel2Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NoTypeReplacementModel2Resource" /> object. </returns>
        public virtual NoTypeReplacementModel2Resource GetNoTypeReplacementModel2Resource(ResourceIdentifier id)
        {
            NoTypeReplacementModel2Resource.ValidateResourceId(id);
            return new NoTypeReplacementModel2Resource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NoTypeReplacementModel3Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NoTypeReplacementModel3Resource.CreateResourceIdentifier" /> to create a <see cref="NoTypeReplacementModel3Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NoTypeReplacementModel3Resource" /> object. </returns>
        public virtual NoTypeReplacementModel3Resource GetNoTypeReplacementModel3Resource(ResourceIdentifier id)
        {
            NoTypeReplacementModel3Resource.ValidateResourceId(id);
            return new NoTypeReplacementModel3Resource(Client, id);
        }
    }
}
