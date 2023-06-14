// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the url redirect action. </summary>
    public partial class UrlRedirectActionParameters
    {
        /// <summary> Initializes a new instance of UrlRedirectActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="redirectType"> The redirect type the rule will use when redirecting traffic. </param>
        public UrlRedirectActionParameters(UrlRedirectActionParametersTypeName typeName, RedirectType redirectType)
        {
            TypeName = typeName;
            RedirectType = redirectType;
        }

        /// <summary> Initializes a new instance of UrlRedirectActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="redirectType"> The redirect type the rule will use when redirecting traffic. </param>
        /// <param name="destinationProtocol"> Protocol to use for the redirect. The default value is MatchRequest. </param>
        /// <param name="customPath"> The full path to redirect. Path cannot be empty and must start with /. Leave empty to use the incoming path as destination path. </param>
        /// <param name="customHostname"> Host to redirect. Leave empty to use the incoming host as the destination host. </param>
        /// <param name="customQueryString"> The set of query strings to be placed in the redirect URL. Setting this value would replace any existing query string; leave empty to preserve the incoming query string. Query string must be in &lt;key&gt;=&lt;value&gt; format. ? and &amp; will be added automatically so do not include them. </param>
        /// <param name="customFragment"> Fragment to add to the redirect URL. Fragment is the part of the URL that comes after #. Do not include the #. </param>
        internal UrlRedirectActionParameters(UrlRedirectActionParametersTypeName typeName, RedirectType redirectType, DestinationProtocol? destinationProtocol, string customPath, string customHostname, string customQueryString, string customFragment)
        {
            TypeName = typeName;
            RedirectType = redirectType;
            DestinationProtocol = destinationProtocol;
            CustomPath = customPath;
            CustomHostname = customHostname;
            CustomQueryString = customQueryString;
            CustomFragment = customFragment;
        }

        /// <summary> Gets or sets the type name. </summary>
        public UrlRedirectActionParametersTypeName TypeName { get; set; }
        /// <summary> The redirect type the rule will use when redirecting traffic. </summary>
        public RedirectType RedirectType { get; set; }
        /// <summary> Protocol to use for the redirect. The default value is MatchRequest. </summary>
        public DestinationProtocol? DestinationProtocol { get; set; }
        /// <summary> The full path to redirect. Path cannot be empty and must start with /. Leave empty to use the incoming path as destination path. </summary>
        public string CustomPath { get; set; }
        /// <summary> Host to redirect. Leave empty to use the incoming host as the destination host. </summary>
        public string CustomHostname { get; set; }
        /// <summary> The set of query strings to be placed in the redirect URL. Setting this value would replace any existing query string; leave empty to preserve the incoming query string. Query string must be in &lt;key&gt;=&lt;value&gt; format. ? and &amp; will be added automatically so do not include them. </summary>
        public string CustomQueryString { get; set; }
        /// <summary> Fragment to add to the redirect URL. Fragment is the part of the URL that comes after #. Do not include the #. </summary>
        public string CustomFragment { get; set; }
    }
}
