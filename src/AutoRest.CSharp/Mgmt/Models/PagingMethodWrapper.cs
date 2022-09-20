// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class PagingMethodWrapper
    {
        public PagingMethodWrapper(PagingMethod pagingMethod)
        {
            Method = pagingMethod.Method;
            NextPageMethod = pagingMethod.NextPageMethod;
            NextLinkName = pagingMethod.PagingResponse.NextLinkProperty?.Declaration.Name;
            ItemName = pagingMethod.PagingResponse.ItemProperty.Declaration.Name;
            ItemType = pagingMethod.PagingResponse.ItemType;
        }

        public PagingMethodWrapper(RestClientMethod method)
        {
            Method = method;
            NextPageMethod = null;
            NextLinkName = null;
            if (method.IsListMethod(out var itemType, out var valuePropertyName))
            {
                ItemName = valuePropertyName;
                ItemType = itemType;
            }
            else
            {
                throw new InvalidOperationException($"Method {method.Name} with path {method.Operation.Path} is not a list method");
            }
        }

        public CSharpType ItemType { get; }

        /// <summary>
        /// This is the underlying <see cref="RestClientMethod"/> of this paging method
        /// </summary>
        public RestClientMethod Method { get; }

        /// <summary>
        /// This is the REST method for getting next page if there is one
        /// </summary>
        public RestClientMethod? NextPageMethod { get; }

        /// <summary>
        /// This is the property name in the response body, usually the value of this is `Value`
        /// </summary>
        public string ItemName { get; }

        /// <summary>
        /// This is the name of the nextLink property if there is one.
        /// </summary>
        public string? NextLinkName { get; }
    }
}
