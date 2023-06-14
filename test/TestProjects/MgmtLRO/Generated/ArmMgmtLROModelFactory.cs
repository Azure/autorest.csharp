// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtLRO;

namespace MgmtLRO.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtLROModelFactory
    {
        /// <summary> Initializes a new instance of FakeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> The instance view of a resource. </param>
        /// <returns> A new <see cref="MgmtLRO.FakeData"/> instance for mocking. </returns>
        public static FakeData FakeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, FakeProperties properties = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FakeData(id, name, resourceType, systemData, tags, location, properties);
        }

        /// <summary> Initializes a new instance of FakePostResult. </summary>
        /// <param name="fakePostResultBar"></param>
        /// <returns> A new <see cref="Models.FakePostResult"/> instance for mocking. </returns>
        public static FakePostResult FakePostResult(string fakePostResultBar = null)
        {
            return new FakePostResult(fakePostResultBar != null ? new FakePostResultProperties(fakePostResultBar) : null);
        }

        /// <summary> Initializes a new instance of BarData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="barBuzz"> The instance view of a resource. </param>
        /// <returns> A new <see cref="MgmtLRO.BarData"/> instance for mocking. </returns>
        public static BarData BarData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, Guid? barBuzz = null)
        {
            tags ??= new Dictionary<string, string>();

            return new BarData(id, name, resourceType, systemData, tags, location, barBuzz != null ? new BarProperties(barBuzz) : null);
        }
    }
}
