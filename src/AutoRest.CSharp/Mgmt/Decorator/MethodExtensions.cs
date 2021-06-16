// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Get the body type of a ClientMethod
        /// </summary>
        /// <param name="clientMethod">the ClientMethod</param>
        /// <returns>the body type of the ClientMethod</returns>
        public static CSharpType? BodyType(this ClientMethod clientMethod)
        {
            return clientMethod.RestClientMethod.ReturnType;
        }

        /// <summary>
        /// Get the proper return type of the ClientMethod considering the async status
        /// </summary>
        /// <param name="clientMethod">the ClientMethod</param>
        /// <param name="async">Is this method async?</param>
        /// <returns>the response type of the ClientMethod</returns>
        public static CSharpType ResponseType(this ClientMethod clientMethod, bool async)
        {
            var bodyType = clientMethod.BodyType();
            var responseType = bodyType != null ? new CSharpType(typeof(Response<>), bodyType) : typeof(Response);
            return responseType.WrapAsync(async);
        }

        /// <summary>
        /// Get the proper return type of the PagingMethod considering the async status
        /// </summary>
        /// <param name="pagingMethod">the PagingMethod</param>
        /// <param name="async">Is this method async?</param>
        /// <returns>the response type of the PagingMethod</returns>
        public static CSharpType ResponseType(this PagingMethod pagingMethod, bool async)
        {
            var pageType = pagingMethod.PagingResponse.ItemType;
            return pageType.WrapPageable(async);
        }
    }
}
