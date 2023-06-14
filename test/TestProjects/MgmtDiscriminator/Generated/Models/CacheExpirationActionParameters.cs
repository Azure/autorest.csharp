// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the cache expiration action. </summary>
    public partial class CacheExpirationActionParameters
    {
        /// <summary> Initializes a new instance of CacheExpirationActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="cacheBehavior"> Caching behavior for the requests. </param>
        /// <param name="cacheType"> The level at which the content needs to be cached. </param>
        public CacheExpirationActionParameters(CacheExpirationActionParametersTypeName typeName, CacheBehavior cacheBehavior, CacheType cacheType)
        {
            TypeName = typeName;
            CacheBehavior = cacheBehavior;
            CacheType = cacheType;
        }

        /// <summary> Initializes a new instance of CacheExpirationActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="cacheBehavior"> Caching behavior for the requests. </param>
        /// <param name="cacheType"> The level at which the content needs to be cached. </param>
        /// <param name="cacheDuration"> The duration for which the content needs to be cached. Allowed format is [d.]hh:mm:ss. </param>
        internal CacheExpirationActionParameters(CacheExpirationActionParametersTypeName typeName, CacheBehavior cacheBehavior, CacheType cacheType, TimeSpan? cacheDuration)
        {
            TypeName = typeName;
            CacheBehavior = cacheBehavior;
            CacheType = cacheType;
            CacheDuration = cacheDuration;
        }

        /// <summary> Gets or sets the type name. </summary>
        public CacheExpirationActionParametersTypeName TypeName { get; set; }
        /// <summary> Caching behavior for the requests. </summary>
        public CacheBehavior CacheBehavior { get; set; }
        /// <summary> The level at which the content needs to be cached. </summary>
        public CacheType CacheType { get; set; }
        /// <summary> The duration for which the content needs to be cached. Allowed format is [d.]hh:mm:ss. </summary>
        public TimeSpan? CacheDuration { get; set; }
    }
}
