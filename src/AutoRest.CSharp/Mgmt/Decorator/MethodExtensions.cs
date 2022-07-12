// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Return true if this operation is a list method. Also returns the itemType of what this operation is listing of.
        /// This function will return true in the following circumstances:
        /// 1. This operation is a paging method.
        /// 2. This operation is not a paging method, but the return value is a collection type (IReadOnlyList)
        /// 3. This operation is not a paging method and the return value is not a collection type, but it has similar structure as paging method (has a value property, and value property is a collection)
        /// </summary>
        /// <param name="method"></param>
        /// <param name="itemType">The type of the item in the collection</param>
        /// <returns></returns>
        public static bool IsListMethod(this RestClientMethod method, [MaybeNullWhen(false)] out CSharpType itemType)
        {
            if (method.ReturnType != null)
            {
                return method.ReturnType.IsListMethod(out itemType);
            }

            itemType = null;
            return false;
        }
    }
}
