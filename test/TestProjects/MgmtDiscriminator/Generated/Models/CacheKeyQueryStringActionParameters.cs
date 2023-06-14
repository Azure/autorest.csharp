// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the cache-key query string action. </summary>
    public partial class CacheKeyQueryStringActionParameters
    {
        /// <summary> Initializes a new instance of CacheKeyQueryStringActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="queryStringBehavior"> Caching behavior for the requests. </param>
        public CacheKeyQueryStringActionParameters(CacheKeyQueryStringActionParametersTypeName typeName, QueryStringBehavior queryStringBehavior)
        {
            TypeName = typeName;
            QueryStringBehavior = queryStringBehavior;
        }

        /// <summary> Initializes a new instance of CacheKeyQueryStringActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="queryStringBehavior"> Caching behavior for the requests. </param>
        /// <param name="queryParameters"> query parameters to include or exclude (comma separated). </param>
        internal CacheKeyQueryStringActionParameters(CacheKeyQueryStringActionParametersTypeName typeName, QueryStringBehavior queryStringBehavior, string queryParameters)
        {
            TypeName = typeName;
            QueryStringBehavior = queryStringBehavior;
            QueryParameters = queryParameters;
        }

        /// <summary> Gets or sets the type name. </summary>
        public CacheKeyQueryStringActionParametersTypeName TypeName { get; set; }
        /// <summary> Caching behavior for the requests. </summary>
        public QueryStringBehavior QueryStringBehavior { get; set; }
        /// <summary> query parameters to include or exclude (comma separated). </summary>
        public string QueryParameters { get; set; }
    }
}
