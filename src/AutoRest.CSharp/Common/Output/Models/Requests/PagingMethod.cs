// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingMethod
    {
        public PagingMethod(string createRequestMethodName, string? createNextPageRequestMethodName, string? nextLinkPropertyName, string itemPropertyName, CSharpType itemType)
        {
            CreateRequestMethodName = createRequestMethodName;
            CreateNextPageRequestMethodName = createNextPageRequestMethodName;
            NextLinkName = nextLinkPropertyName;
            ItemName = itemPropertyName;
            ItemType = itemType;
        }

        public PagingMethod(string createRequestMethodName, CSharpType itemType, string itemName)
        {
            CreateRequestMethodName = createRequestMethodName;
            CreateNextPageRequestMethodName = null;
            NextLinkName = null;
            ItemName = itemName;
            ItemType = itemType;
        }

        public string CreateRequestMethodName { get; }
        public string? CreateNextPageRequestMethodName { get; }

        public CSharpType ItemType { get; }

        /// <summary>
        /// This is the property name in the response body, usually the value of this is `Value`
        /// </summary>
        public string ItemName { get; }

        /// <summary>
        /// This is the name of the nextLink property if there is one.
        /// </summary>
        public string? NextLinkName { get; }

        /// <summary>
        /// Check whether the given parameter name is like page size
        /// </summary>
        /// <param name="name">Parameter name to check</param>
        /// <returns></returns>
        public static bool IsPageSizeName(string name)
        {
            var n = name.ToLower();
            return (n.EndsWith("pagesize") || n.EndsWith("page_size"));
        }

        public static bool IsPageSizeType(Type type) => Type.GetTypeCode(type) switch
        {
            TypeCode.Single => true,
            TypeCode.Double => true,
            TypeCode.Decimal => true,
            TypeCode.Int64 => true,
            TypeCode.Int32 => true,
            _ => false
        };

        /// <summary>
        /// Check whether the given parameter is a page size parameter
        /// </summary>
        /// <param name="p">Parameter to check</param>
        /// <returns>true if the given parameter is a page size parameter; otherwise false</returns>
        public static bool IsPageSizeParameter(Parameter p)
        {
            return IsPageSizeName(p.Name) && IsPageSizeType(p.Type.FrameworkType);
        }
    }
}
