// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    public class PagingMetadata
    {
        /// <summary>
        /// This is the underlying <see cref="RestClientMethod"/> of this paging method
        /// </summary>
        public string? Method { get; set;}

        /// <summary>
        /// This is the REST method for getting next page if there is one
        /// </summary>
        public string? NextPageMethod { get; set;}

        /// <summary>
        /// This is the property name in the response body, usually the value of this is `Value`
        /// </summary>
        public string? ItemName { get; set;}

        /// <summary>
        /// This is the name of the nextLink property if there is one.
        /// </summary>
        public string? NextLinkName { get; set;}
    }
}
