// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to MgmtListMethods. </summary>
    public static partial class MgmtListMethodsExtensions
    {
        private static ManagementGroupResourceExtensionClient GetManagementGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ManagementGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ManagementGroupResourceExtensionClient GetManagementGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ManagementGroupResourceExtensionClient(client, scope);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new SubscriptionResourceExtensionClient(client, resource.Id);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new SubscriptionResourceExtensionClient(client, scope);
            });
        }

        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new TenantResourceExtensionClient(client, resource.Id);
            });
        }

        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new TenantResourceExtensionClient(client, scope);
            });
        }
        #region FakeResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeResource.CreateResourceIdentifier" /> to create a <see cref="FakeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeResource" /> object. </returns>
        public static FakeResource GetFakeResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeResource.ValidateResourceId(id);
                return new FakeResource(client, id);
            }
            );
        }
        #endregion

        #region FakeParentWithAncestorWithNonResChWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeParentWithAncestorWithNonResChWithLocResource.CreateResourceIdentifier" /> to create a <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> object. </returns>
        public static FakeParentWithAncestorWithNonResChWithLocResource GetFakeParentWithAncestorWithNonResChWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeParentWithAncestorWithNonResChWithLocResource.ValidateResourceId(id);
                return new FakeParentWithAncestorWithNonResChWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region FakeParentWithAncestorWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeParentWithAncestorWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeParentWithAncestorWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="FakeParentWithAncestorWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeParentWithAncestorWithNonResChResource" /> object. </returns>
        public static FakeParentWithAncestorWithNonResChResource GetFakeParentWithAncestorWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeParentWithAncestorWithNonResChResource.ValidateResourceId(id);
                return new FakeParentWithAncestorWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region FakeParentWithAncestorWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeParentWithAncestorWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeParentWithAncestorWithLocResource.CreateResourceIdentifier" /> to create a <see cref="FakeParentWithAncestorWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeParentWithAncestorWithLocResource" /> object. </returns>
        public static FakeParentWithAncestorWithLocResource GetFakeParentWithAncestorWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeParentWithAncestorWithLocResource.ValidateResourceId(id);
                return new FakeParentWithAncestorWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region FakeParentWithAncestorResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeParentWithAncestorResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeParentWithAncestorResource.CreateResourceIdentifier" /> to create a <see cref="FakeParentWithAncestorResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeParentWithAncestorResource" /> object. </returns>
        public static FakeParentWithAncestorResource GetFakeParentWithAncestorResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeParentWithAncestorResource.ValidateResourceId(id);
                return new FakeParentWithAncestorResource(client, id);
            }
            );
        }
        #endregion

        #region FakeParentWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeParentWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeParentWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="FakeParentWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeParentWithNonResChResource" /> object. </returns>
        public static FakeParentWithNonResChResource GetFakeParentWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeParentWithNonResChResource.ValidateResourceId(id);
                return new FakeParentWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region FakeParentResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeParentResource.CreateResourceIdentifier" /> to create a <see cref="FakeParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeParentResource" /> object. </returns>
        public static FakeParentResource GetFakeParentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeParentResource.ValidateResourceId(id);
                return new FakeParentResource(client, id);
            }
            );
        }
        #endregion

        #region ResGrpParentWithAncestorWithNonResChWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource.CreateResourceIdentifier" /> to create a <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> object. </returns>
        public static ResGrpParentWithAncestorWithNonResChWithLocResource GetResGrpParentWithAncestorWithNonResChWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResGrpParentWithAncestorWithNonResChWithLocResource.ValidateResourceId(id);
                return new ResGrpParentWithAncestorWithNonResChWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region ResGrpParentWithAncestorWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="ResGrpParentWithAncestorWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResGrpParentWithAncestorWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="ResGrpParentWithAncestorWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResGrpParentWithAncestorWithNonResChResource" /> object. </returns>
        public static ResGrpParentWithAncestorWithNonResChResource GetResGrpParentWithAncestorWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResGrpParentWithAncestorWithNonResChResource.ValidateResourceId(id);
                return new ResGrpParentWithAncestorWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region ResGrpParentWithAncestorWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="ResGrpParentWithAncestorWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResGrpParentWithAncestorWithLocResource.CreateResourceIdentifier" /> to create a <see cref="ResGrpParentWithAncestorWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResGrpParentWithAncestorWithLocResource" /> object. </returns>
        public static ResGrpParentWithAncestorWithLocResource GetResGrpParentWithAncestorWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResGrpParentWithAncestorWithLocResource.ValidateResourceId(id);
                return new ResGrpParentWithAncestorWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region ResGrpParentWithAncestorResource
        /// <summary>
        /// Gets an object representing a <see cref="ResGrpParentWithAncestorResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResGrpParentWithAncestorResource.CreateResourceIdentifier" /> to create a <see cref="ResGrpParentWithAncestorResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResGrpParentWithAncestorResource" /> object. </returns>
        public static ResGrpParentWithAncestorResource GetResGrpParentWithAncestorResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResGrpParentWithAncestorResource.ValidateResourceId(id);
                return new ResGrpParentWithAncestorResource(client, id);
            }
            );
        }
        #endregion

        #region ResGrpParentWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="ResGrpParentWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResGrpParentWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="ResGrpParentWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResGrpParentWithNonResChResource" /> object. </returns>
        public static ResGrpParentWithNonResChResource GetResGrpParentWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResGrpParentWithNonResChResource.ValidateResourceId(id);
                return new ResGrpParentWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region ResGrpParentResource
        /// <summary>
        /// Gets an object representing a <see cref="ResGrpParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResGrpParentResource.CreateResourceIdentifier" /> to create a <see cref="ResGrpParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResGrpParentResource" /> object. </returns>
        public static ResGrpParentResource GetResGrpParentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResGrpParentResource.ValidateResourceId(id);
                return new ResGrpParentResource(client, id);
            }
            );
        }
        #endregion

        #region SubParentWithNonResChWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="SubParentWithNonResChWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubParentWithNonResChWithLocResource.CreateResourceIdentifier" /> to create a <see cref="SubParentWithNonResChWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubParentWithNonResChWithLocResource" /> object. </returns>
        public static SubParentWithNonResChWithLocResource GetSubParentWithNonResChWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubParentWithNonResChWithLocResource.ValidateResourceId(id);
                return new SubParentWithNonResChWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region SubParentWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="SubParentWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubParentWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="SubParentWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubParentWithNonResChResource" /> object. </returns>
        public static SubParentWithNonResChResource GetSubParentWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubParentWithNonResChResource.ValidateResourceId(id);
                return new SubParentWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region SubParentWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="SubParentWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubParentWithLocResource.CreateResourceIdentifier" /> to create a <see cref="SubParentWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubParentWithLocResource" /> object. </returns>
        public static SubParentWithLocResource GetSubParentWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubParentWithLocResource.ValidateResourceId(id);
                return new SubParentWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region SubParentResource
        /// <summary>
        /// Gets an object representing a <see cref="SubParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubParentResource.CreateResourceIdentifier" /> to create a <see cref="SubParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubParentResource" /> object. </returns>
        public static SubParentResource GetSubParentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubParentResource.ValidateResourceId(id);
                return new SubParentResource(client, id);
            }
            );
        }
        #endregion

        #region MgmtGrpParentWithNonResChWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="MgmtGrpParentWithNonResChWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MgmtGrpParentWithNonResChWithLocResource.CreateResourceIdentifier" /> to create a <see cref="MgmtGrpParentWithNonResChWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MgmtGrpParentWithNonResChWithLocResource" /> object. </returns>
        public static MgmtGrpParentWithNonResChWithLocResource GetMgmtGrpParentWithNonResChWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MgmtGrpParentWithNonResChWithLocResource.ValidateResourceId(id);
                return new MgmtGrpParentWithNonResChWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region MgmtGrpParentWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="MgmtGrpParentWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MgmtGrpParentWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="MgmtGrpParentWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MgmtGrpParentWithNonResChResource" /> object. </returns>
        public static MgmtGrpParentWithNonResChResource GetMgmtGrpParentWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MgmtGrpParentWithNonResChResource.ValidateResourceId(id);
                return new MgmtGrpParentWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region MgmtGrpParentWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="MgmtGrpParentWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MgmtGrpParentWithLocResource.CreateResourceIdentifier" /> to create a <see cref="MgmtGrpParentWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MgmtGrpParentWithLocResource" /> object. </returns>
        public static MgmtGrpParentWithLocResource GetMgmtGrpParentWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MgmtGrpParentWithLocResource.ValidateResourceId(id);
                return new MgmtGrpParentWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region MgmtGroupParentResource
        /// <summary>
        /// Gets an object representing a <see cref="MgmtGroupParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MgmtGroupParentResource.CreateResourceIdentifier" /> to create a <see cref="MgmtGroupParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MgmtGroupParentResource" /> object. </returns>
        public static MgmtGroupParentResource GetMgmtGroupParentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MgmtGroupParentResource.ValidateResourceId(id);
                return new MgmtGroupParentResource(client, id);
            }
            );
        }
        #endregion

        #region TenantTestResource
        /// <summary>
        /// Gets an object representing a <see cref="TenantTestResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TenantTestResource.CreateResourceIdentifier" /> to create a <see cref="TenantTestResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TenantTestResource" /> object. </returns>
        public static TenantTestResource GetTenantTestResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TenantTestResource.ValidateResourceId(id);
                return new TenantTestResource(client, id);
            }
            );
        }
        #endregion

        #region TenantParentWithNonResChWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="TenantParentWithNonResChWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TenantParentWithNonResChWithLocResource.CreateResourceIdentifier" /> to create a <see cref="TenantParentWithNonResChWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TenantParentWithNonResChWithLocResource" /> object. </returns>
        public static TenantParentWithNonResChWithLocResource GetTenantParentWithNonResChWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TenantParentWithNonResChWithLocResource.ValidateResourceId(id);
                return new TenantParentWithNonResChWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region TenantParentWithNonResChResource
        /// <summary>
        /// Gets an object representing a <see cref="TenantParentWithNonResChResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TenantParentWithNonResChResource.CreateResourceIdentifier" /> to create a <see cref="TenantParentWithNonResChResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TenantParentWithNonResChResource" /> object. </returns>
        public static TenantParentWithNonResChResource GetTenantParentWithNonResChResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TenantParentWithNonResChResource.ValidateResourceId(id);
                return new TenantParentWithNonResChResource(client, id);
            }
            );
        }
        #endregion

        #region TenantParentWithLocResource
        /// <summary>
        /// Gets an object representing a <see cref="TenantParentWithLocResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TenantParentWithLocResource.CreateResourceIdentifier" /> to create a <see cref="TenantParentWithLocResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TenantParentWithLocResource" /> object. </returns>
        public static TenantParentWithLocResource GetTenantParentWithLocResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TenantParentWithLocResource.ValidateResourceId(id);
                return new TenantParentWithLocResource(client, id);
            }
            );
        }
        #endregion

        #region TenantParentResource
        /// <summary>
        /// Gets an object representing a <see cref="TenantParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TenantParentResource.CreateResourceIdentifier" /> to create a <see cref="TenantParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TenantParentResource" /> object. </returns>
        public static TenantParentResource GetTenantParentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TenantParentResource.ValidateResourceId(id);
                return new TenantParentResource(client, id);
            }
            );
        }
        #endregion

        #region FakeConfigurationResource
        /// <summary>
        /// Gets an object representing a <see cref="FakeConfigurationResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakeConfigurationResource.CreateResourceIdentifier" /> to create a <see cref="FakeConfigurationResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakeConfigurationResource" /> object. </returns>
        public static FakeConfigurationResource GetFakeConfigurationResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakeConfigurationResource.ValidateResourceId(id);
                return new FakeConfigurationResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChWithLocResources in the ManagementGroupResource. </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChWithLocResources and their operations over a MgmtGrpParentWithNonResChWithLocResource. </returns>
        public static MgmtGrpParentWithNonResChWithLocCollection GetMgmtGrpParentWithNonResChWithLocs(this ManagementGroupResource managementGroupResource)
        {
            return GetManagementGroupResourceExtensionClient(managementGroupResource).GetMgmtGrpParentWithNonResChWithLocs();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MgmtGrpParentWithNonResChWithLocResource>> GetMgmtGrpParentWithNonResChWithLocAsync(this ManagementGroupResource managementGroupResource, string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return await managementGroupResource.GetMgmtGrpParentWithNonResChWithLocs().GetAsync(mgmtGrpParentWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MgmtGrpParentWithNonResChWithLocResource> GetMgmtGrpParentWithNonResChWithLoc(this ManagementGroupResource managementGroupResource, string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return managementGroupResource.GetMgmtGrpParentWithNonResChWithLocs().Get(mgmtGrpParentWithNonResChWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChResources in the ManagementGroupResource. </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChResources and their operations over a MgmtGrpParentWithNonResChResource. </returns>
        public static MgmtGrpParentWithNonResChCollection GetMgmtGrpParentWithNonResChes(this ManagementGroupResource managementGroupResource)
        {
            return GetManagementGroupResourceExtensionClient(managementGroupResource).GetMgmtGrpParentWithNonResChes();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MgmtGrpParentWithNonResChResource>> GetMgmtGrpParentWithNonResChAsync(this ManagementGroupResource managementGroupResource, string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await managementGroupResource.GetMgmtGrpParentWithNonResChes().GetAsync(mgmtGrpParentWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MgmtGrpParentWithNonResChResource> GetMgmtGrpParentWithNonResCh(this ManagementGroupResource managementGroupResource, string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return managementGroupResource.GetMgmtGrpParentWithNonResChes().Get(mgmtGrpParentWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of MgmtGrpParentWithLocResources in the ManagementGroupResource. </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of MgmtGrpParentWithLocResources and their operations over a MgmtGrpParentWithLocResource. </returns>
        public static MgmtGrpParentWithLocCollection GetMgmtGrpParentWithLocs(this ManagementGroupResource managementGroupResource)
        {
            return GetManagementGroupResourceExtensionClient(managementGroupResource).GetMgmtGrpParentWithLocs();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MgmtGrpParentWithLocResource>> GetMgmtGrpParentWithLocAsync(this ManagementGroupResource managementGroupResource, string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            return await managementGroupResource.GetMgmtGrpParentWithLocs().GetAsync(mgmtGrpParentWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MgmtGrpParentWithLocResource> GetMgmtGrpParentWithLoc(this ManagementGroupResource managementGroupResource, string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            return managementGroupResource.GetMgmtGrpParentWithLocs().Get(mgmtGrpParentWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of MgmtGroupParentResources in the ManagementGroupResource. </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of MgmtGroupParentResources and their operations over a MgmtGroupParentResource. </returns>
        public static MgmtGroupParentCollection GetMgmtGroupParents(this ManagementGroupResource managementGroupResource)
        {
            return GetManagementGroupResourceExtensionClient(managementGroupResource).GetMgmtGroupParents();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MgmtGroupParentResource>> GetMgmtGroupParentAsync(this ManagementGroupResource managementGroupResource, string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            return await managementGroupResource.GetMgmtGroupParents().GetAsync(mgmtGroupParentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MgmtGroupParentResource> GetMgmtGroupParent(this ManagementGroupResource managementGroupResource, string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            return managementGroupResource.GetMgmtGroupParents().Get(mgmtGroupParentName, cancellationToken);
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithNonResChWithLocResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithNonResChWithLocResources and their operations over a ResGrpParentWithAncestorWithNonResChWithLocResource. </returns>
        public static ResGrpParentWithAncestorWithNonResChWithLocCollection GetResGrpParentWithAncestorWithNonResChWithLocs(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResGrpParentWithAncestorWithNonResChWithLocs();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResGrpParentWithAncestorWithNonResChWithLocResource>> GetResGrpParentWithAncestorWithNonResChWithLocAsync(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResGrpParentWithAncestorWithNonResChWithLocs().GetAsync(resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLoc(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResGrpParentWithAncestorWithNonResChWithLocs().Get(resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithNonResChResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithNonResChResources and their operations over a ResGrpParentWithAncestorWithNonResChResource. </returns>
        public static ResGrpParentWithAncestorWithNonResChCollection GetResGrpParentWithAncestorWithNonResChes(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResGrpParentWithAncestorWithNonResChes();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResGrpParentWithAncestorWithNonResChResource>> GetResGrpParentWithAncestorWithNonResChAsync(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResGrpParentWithAncestorWithNonResChes().GetAsync(resGrpParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResGrpParentWithAncestorWithNonResChResource> GetResGrpParentWithAncestorWithNonResCh(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResGrpParentWithAncestorWithNonResChes().Get(resGrpParentWithAncestorWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithLocResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithLocResources and their operations over a ResGrpParentWithAncestorWithLocResource. </returns>
        public static ResGrpParentWithAncestorWithLocCollection GetResGrpParentWithAncestorWithLocs(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResGrpParentWithAncestorWithLocs();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs/{resGrpParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResGrpParentWithAncestorWithLocResource>> GetResGrpParentWithAncestorWithLocAsync(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResGrpParentWithAncestorWithLocs().GetAsync(resGrpParentWithAncestorWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs/{resGrpParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResGrpParentWithAncestorWithLocResource> GetResGrpParentWithAncestorWithLoc(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResGrpParentWithAncestorWithLocs().Get(resGrpParentWithAncestorWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResGrpParentWithAncestorResources and their operations over a ResGrpParentWithAncestorResource. </returns>
        public static ResGrpParentWithAncestorCollection GetResGrpParentWithAncestors(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResGrpParentWithAncestors();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestors_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResGrpParentWithAncestorResource>> GetResGrpParentWithAncestorAsync(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResGrpParentWithAncestors().GetAsync(resGrpParentWithAncestorName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestors_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResGrpParentWithAncestorResource> GetResGrpParentWithAncestor(this ResourceGroupResource resourceGroupResource, string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResGrpParentWithAncestors().Get(resGrpParentWithAncestorName, cancellationToken);
        }

        /// <summary> Gets a collection of ResGrpParentWithNonResChResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResGrpParentWithNonResChResources and their operations over a ResGrpParentWithNonResChResource. </returns>
        public static ResGrpParentWithNonResChCollection GetResGrpParentWithNonResChes(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResGrpParentWithNonResChes();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResGrpParentWithNonResChResource>> GetResGrpParentWithNonResChAsync(this ResourceGroupResource resourceGroupResource, string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResGrpParentWithNonResChes().GetAsync(resGrpParentWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResGrpParentWithNonResChResource> GetResGrpParentWithNonResCh(this ResourceGroupResource resourceGroupResource, string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResGrpParentWithNonResChes().Get(resGrpParentWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of ResGrpParentResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResGrpParentResources and their operations over a ResGrpParentResource. </returns>
        public static ResGrpParentCollection GetResGrpParents(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetResGrpParents();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResGrpParentResource>> GetResGrpParentAsync(this ResourceGroupResource resourceGroupResource, string resGrpParentName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetResGrpParents().GetAsync(resGrpParentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResGrpParentResource> GetResGrpParent(this ResourceGroupResource resourceGroupResource, string resGrpParentName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetResGrpParents().Get(resGrpParentName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of FakeResources and their operations over a FakeResource. </returns>
        public static FakeCollection GetFakes(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakes();
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<FakeResource>> GetFakeAsync(this SubscriptionResource subscriptionResource, string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetFakes().GetAsync(fakeName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<FakeResource> GetFake(this SubscriptionResource subscriptionResource, string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetFakes().Get(fakeName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of SubParentWithNonResChWithLocResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentWithNonResChWithLocResources and their operations over a SubParentWithNonResChWithLocResource. </returns>
        public static SubParentWithNonResChWithLocCollection GetSubParentWithNonResChWithLocs(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSubParentWithNonResChWithLocs();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SubParentWithNonResChWithLocResource>> GetSubParentWithNonResChWithLocAsync(this SubscriptionResource subscriptionResource, string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetSubParentWithNonResChWithLocs().GetAsync(subParentWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SubParentWithNonResChWithLocResource> GetSubParentWithNonResChWithLoc(this SubscriptionResource subscriptionResource, string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetSubParentWithNonResChWithLocs().Get(subParentWithNonResChWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of SubParentWithNonResChResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentWithNonResChResources and their operations over a SubParentWithNonResChResource. </returns>
        public static SubParentWithNonResChCollection GetSubParentWithNonResChes(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSubParentWithNonResChes();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChes/{subParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SubParentWithNonResChResource>> GetSubParentWithNonResChAsync(this SubscriptionResource subscriptionResource, string subParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetSubParentWithNonResChes().GetAsync(subParentWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChes/{subParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SubParentWithNonResChResource> GetSubParentWithNonResCh(this SubscriptionResource subscriptionResource, string subParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetSubParentWithNonResChes().Get(subParentWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of SubParentWithLocResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentWithLocResources and their operations over a SubParentWithLocResource. </returns>
        public static SubParentWithLocCollection GetSubParentWithLocs(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSubParentWithLocs();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SubParentWithLocResource>> GetSubParentWithLocAsync(this SubscriptionResource subscriptionResource, string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetSubParentWithLocs().GetAsync(subParentWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithLocs/{subParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SubParentWithLocResource> GetSubParentWithLoc(this SubscriptionResource subscriptionResource, string subParentWithLocName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetSubParentWithLocs().Get(subParentWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of SubParentResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubParentResources and their operations over a SubParentResource. </returns>
        public static SubParentCollection GetSubParents(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSubParents();
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SubParentResource>> GetSubParentAsync(this SubscriptionResource subscriptionResource, string subParentName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetSubParents().GetAsync(subParentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParents/{subParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="subParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SubParentResource> GetSubParent(this SubscriptionResource subscriptionResource, string subParentName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetSubParents().Get(subParentName, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithNonResChWithLocResource> GetFakeParentWithAncestorWithNonResourceChWithLocAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithNonResourceChWithLocAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithNonResChWithLocResource> GetFakeParentWithAncestorWithNonResourceChWithLoc(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithNonResourceChWithLoc(cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An async collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<NonResourceChild> GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocsAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocsAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> A collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<NonResourceChild> GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs(location, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithNonResChResource> GetFakeParentWithAncestorWithNonResChesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithNonResChesAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithNonResChResource> GetFakeParentWithAncestorWithNonResChes(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithNonResChes(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithLocsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocs(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithLocs(cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocsByLocationAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithLocsByLocationAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocsByLocation(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorWithLocsByLocation(location, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestors_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FakeParentWithAncestorResource> GetFakeParentWithAncestorsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestorsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestors_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FakeParentWithAncestorResource> GetFakeParentWithAncestors(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFakeParentWithAncestors(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocsAsync(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithNonResChWithLocsAsync(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocs(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithNonResChWithLocs(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithNonResChResource> GetResGrpParentWithAncestorWithNonResChesAsync(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithNonResChesAsync(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithNonResChResource> GetResGrpParentWithAncestorWithNonResChes(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithNonResChes(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithLocResource> GetResGrpParentWithAncestorWithLocsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithLocsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithLocResource> GetResGrpParentWithAncestorWithLocs(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithLocs(cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/locations/{location}/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLocAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLocAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/locations/{location}/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc(location, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestors_NonPageableListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResGrpParentWithAncestorResource> GetResGrpParentWithAncestorsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestorsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestors_NonPageableListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResGrpParentWithAncestorResource> GetResGrpParentWithAncestors(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResGrpParentWithAncestors(cancellationToken);
        }

        /// <summary>
        /// Update quota for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/updateQuotas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Quotas_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for update quota is queried. </param>
        /// <param name="content"> Quota update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="content"/> is null. </exception>
        /// <returns> An async collection of <see cref="UpdateWorkspaceQuotas" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<UpdateWorkspaceQuotas> UpdateAllQuotaAsync(this SubscriptionResource subscriptionResource, string location, QuotaUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNull(content, nameof(content));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).UpdateAllQuotaAsync(location, content, cancellationToken);
        }

        /// <summary>
        /// Update quota for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/updateQuotas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Quotas_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for update quota is queried. </param>
        /// <param name="content"> Quota update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="UpdateWorkspaceQuotas" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<UpdateWorkspaceQuotas> UpdateAllQuota(this SubscriptionResource subscriptionResource, string location, QuotaUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNull(content, nameof(content));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).UpdateAllQuota(location, content, cancellationToken);
        }

        /// <summary> Gets a collection of TenantTestResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of TenantTestResources and their operations over a TenantTestResource. </returns>
        public static TenantTestCollection GetTenantTests(this TenantResource tenantResource)
        {
            return GetTenantResourceExtensionClient(tenantResource).GetTenantTests();
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<TenantTestResource>> GetTenantTestAsync(this TenantResource tenantResource, string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await tenantResource.GetTenantTests().GetAsync(tenantTestName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<TenantTestResource> GetTenantTest(this TenantResource tenantResource, string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            return tenantResource.GetTenantTests().Get(tenantTestName, expand, cancellationToken);
        }
    }
}
