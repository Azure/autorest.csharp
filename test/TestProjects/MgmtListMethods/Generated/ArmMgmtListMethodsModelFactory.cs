// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtListMethodsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeData"/> instance for mocking. </returns>
        public static FakeData FakeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeParentWithAncestorWithNonResChWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeParentWithAncestorWithNonResChWithLocData"/> instance for mocking. </returns>
        public static FakeParentWithAncestorWithNonResChWithLocData FakeParentWithAncestorWithNonResChWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeParentWithAncestorWithNonResChWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NonResourceChild"/>. </summary>
        /// <param name="name"> Name. </param>
        /// <param name="numberOfCores"> Test Desc. </param>
        /// <returns> A new <see cref="Models.NonResourceChild"/> instance for mocking. </returns>
        public static NonResourceChild NonResourceChild(string name = null, int? numberOfCores = null)
        {
            return new NonResourceChild(name, numberOfCores);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeParentWithAncestorWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeParentWithAncestorWithNonResChData"/> instance for mocking. </returns>
        public static FakeParentWithAncestorWithNonResChData FakeParentWithAncestorWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeParentWithAncestorWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeParentWithAncestorWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeParentWithAncestorWithLocData"/> instance for mocking. </returns>
        public static FakeParentWithAncestorWithLocData FakeParentWithAncestorWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeParentWithAncestorWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeParentWithAncestorData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeParentWithAncestorData"/> instance for mocking. </returns>
        public static FakeParentWithAncestorData FakeParentWithAncestorData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeParentWithAncestorData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeParentWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeParentWithNonResChData"/> instance for mocking. </returns>
        public static FakeParentWithNonResChData FakeParentWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeParentWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeParentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeParentData"/> instance for mocking. </returns>
        public static FakeParentData FakeParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeParentData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.ResGrpParentWithAncestorWithNonResChWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.ResGrpParentWithAncestorWithNonResChWithLocData"/> instance for mocking. </returns>
        public static ResGrpParentWithAncestorWithNonResChWithLocData ResGrpParentWithAncestorWithNonResChWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ResGrpParentWithAncestorWithNonResChWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.ResGrpParentWithAncestorWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.ResGrpParentWithAncestorWithNonResChData"/> instance for mocking. </returns>
        public static ResGrpParentWithAncestorWithNonResChData ResGrpParentWithAncestorWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ResGrpParentWithAncestorWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.ResGrpParentWithAncestorWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.ResGrpParentWithAncestorWithLocData"/> instance for mocking. </returns>
        public static ResGrpParentWithAncestorWithLocData ResGrpParentWithAncestorWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ResGrpParentWithAncestorWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.ResGrpParentWithAncestorData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.ResGrpParentWithAncestorData"/> instance for mocking. </returns>
        public static ResGrpParentWithAncestorData ResGrpParentWithAncestorData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ResGrpParentWithAncestorData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.ResGrpParentWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.ResGrpParentWithNonResChData"/> instance for mocking. </returns>
        public static ResGrpParentWithNonResChData ResGrpParentWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ResGrpParentWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.ResGrpParentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.ResGrpParentData"/> instance for mocking. </returns>
        public static ResGrpParentData ResGrpParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ResGrpParentData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.SubParentWithNonResChWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.SubParentWithNonResChWithLocData"/> instance for mocking. </returns>
        public static SubParentWithNonResChWithLocData SubParentWithNonResChWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SubParentWithNonResChWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.SubParentWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.SubParentWithNonResChData"/> instance for mocking. </returns>
        public static SubParentWithNonResChData SubParentWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SubParentWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.SubParentWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.SubParentWithLocData"/> instance for mocking. </returns>
        public static SubParentWithLocData SubParentWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SubParentWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.SubParentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.SubParentData"/> instance for mocking. </returns>
        public static SubParentData SubParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SubParentData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.MgmtGrpParentWithNonResChWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.MgmtGrpParentWithNonResChWithLocData"/> instance for mocking. </returns>
        public static MgmtGrpParentWithNonResChWithLocData MgmtGrpParentWithNonResChWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new MgmtGrpParentWithNonResChWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.MgmtGrpParentWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.MgmtGrpParentWithNonResChData"/> instance for mocking. </returns>
        public static MgmtGrpParentWithNonResChData MgmtGrpParentWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new MgmtGrpParentWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.MgmtGrpParentWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.MgmtGrpParentWithLocData"/> instance for mocking. </returns>
        public static MgmtGrpParentWithLocData MgmtGrpParentWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new MgmtGrpParentWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.MgmtGroupParentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.MgmtGroupParentData"/> instance for mocking. </returns>
        public static MgmtGroupParentData MgmtGroupParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new MgmtGroupParentData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.TenantTestData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.TenantTestData"/> instance for mocking. </returns>
        public static TenantTestData TenantTestData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TenantTestData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.TenantParentWithNonResChWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.TenantParentWithNonResChWithLocData"/> instance for mocking. </returns>
        public static TenantParentWithNonResChWithLocData TenantParentWithNonResChWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TenantParentWithNonResChWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.TenantParentWithNonResChData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.TenantParentWithNonResChData"/> instance for mocking. </returns>
        public static TenantParentWithNonResChData TenantParentWithNonResChData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TenantParentWithNonResChData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.TenantParentWithLocData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.TenantParentWithLocData"/> instance for mocking. </returns>
        public static TenantParentWithLocData TenantParentWithLocData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TenantParentWithLocData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.TenantParentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtListMethods.TenantParentData"/> instance for mocking. </returns>
        public static TenantParentData TenantParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TenantParentData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of <see cref="Models.UpdateWorkspaceQuotas"/>. </summary>
        /// <param name="id"> Specifies the resource ID. </param>
        /// <param name="updateWorkspaceQuotasType"> Specifies the resource type. </param>
        /// <param name="limit"> The maximum permitted quota of the resource. </param>
        /// <param name="unit"> An enum describing the unit of quota measurement. </param>
        /// <param name="status"> Status of update workspace quota. </param>
        /// <returns> A new <see cref="Models.UpdateWorkspaceQuotas"/> instance for mocking. </returns>
        public static UpdateWorkspaceQuotas UpdateWorkspaceQuotas(string id = null, string updateWorkspaceQuotasType = null, long? limit = null, QuotaUnit? unit = null, Status? status = null)
        {
            return new UpdateWorkspaceQuotas(id, updateWorkspaceQuotasType, limit, unit, status);
        }

        /// <summary> Initializes a new instance of <see cref="MgmtListMethods.FakeConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="configValue"> Value of the configuration. </param>
        /// <returns> A new <see cref="MgmtListMethods.FakeConfigurationData"/> instance for mocking. </returns>
        public static FakeConfigurationData FakeConfigurationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string configValue = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeConfigurationData(id, name, resourceType, systemData, tags, location, configValue);
        }
    }
}
