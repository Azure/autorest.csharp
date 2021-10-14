// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Return true if this operation is a list method. Also returns the itemType and a collection of <see cref="Segment"/> as the extra scope
        /// For instance, /subscriptions/{}/providers/M.F/fakes will give you an empty collection for extra scope
        /// /subscriptions/{}/providers/M.F/locations/{location}/fakes will give you a collection [locations] as extra scope
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="itemType">The type of the item in the collection</param>
        /// <param name="extraScope">A collection of segments, which represents the extra scope comparing to its contextual path.</param>
        /// <returns></returns>
        public static bool IsListMethod(this MgmtRestOperation operation, [MaybeNullWhen(false)] out CSharpType itemType, [MaybeNullWhen(false)] out IEnumerable<Segment> extraScope)
        {
            extraScope = null;
            if (IsListMethod(operation.Method, out itemType, out _))
            {
                // the contextual request path must be the parent of the request path of this operation
                // for instance we have operation path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild
                // we will get "providers/Microsoft.Fake/locations/{location}/nonResourceChild"
                // An exception happens in the scope resources. The parameterized scope might be the contextual path of an operation,
                // but it literally is not the parent of the corresponding operation.
                // Here to unify these two cases, we just trim the scope out before we compare the diff
                var diff = operation.ContextualPath.TrimScope().TrimAncestorFrom(operation.RequestPath.TrimScope());
                // remove the "providers" segment and its value
                // we will get "locations/{location}/nonResourceChild"
                extraScope = RemoveProviders(diff)
                            // remove the last segment, which is the thing that we are listing
                            // we will get "locations/{location}"
                            .SkipLast(1)
                            // we only keep the "keys" which has even index
                            // we will get "locations"
                            .Where((_, index) => index % 2 == 0);

                return true;
            }

            return false;
        }

        private static IEnumerable<Segment> RemoveProviders(IEnumerable<Segment> diff)
        {
            var index = diff.ToList().IndexOf(Segment.Providers);
            if (index < 0)
                return diff;

            // remove the providers segment and its value
            var result = new List<Segment>();
            result.AddRange(diff.Take(index));
            result.AddRange(diff.Skip(index + 2));
            return result;
        }

        public static bool IsListMethod(this RestClientMethod method, [MaybeNullWhen(false)] out CSharpType itemType, [MaybeNullWhen(false)] out CSharpType returnType)
        {
            itemType = null;
            returnType = method.ReturnType;
            if (returnType == null)
                return false;

            if (returnType.IsFrameworkType || returnType.Implementation is not SchemaObjectType)
            {
                if (returnType.FrameworkType == typeof(IReadOnlyList<>))
                {
                    itemType = returnType.Arguments[0];
                }
            }
            else
            {
                var schemaObject = (SchemaObjectType)returnType.Implementation;
                itemType = GetValueProperty(schemaObject)?.ValueType.Arguments.FirstOrDefault();
            }
            return itemType != null;
        }

        public static bool IsListMethod(this RestClientMethod method)
        {
            return IsListMethod(method, out var _, out var _);
        }


        private static ObjectTypeProperty? GetValueProperty(SchemaObjectType schemaObject)
        {
            return schemaObject.Properties.FirstOrDefault(p => p.Declaration.Name == "Value" &&
                p.Declaration.Type.IsFrameworkType && p.Declaration.Type.FrameworkType == typeof(IReadOnlyList<>));
        }

        public static bool IsPagingOperation(this MgmtClientOperation clientOperation, BuildContext<MgmtOutputLibrary> context)
        {
            return clientOperation.First().IsPagingOperation(context);
        }

        public static bool IsListOperation(this MgmtClientOperation clientOperation, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out CSharpType itemType)
        {
            return clientOperation.First().IsListMethod(out itemType, out _);
        }

        public static bool IsLongRunningOperation(this MgmtClientOperation clientOperation)
        {
            return clientOperation.First().IsLongRunningOperation();
        }

        public static bool IsLongRunningReallyLong(this MgmtClientOperation clientOperation)
        {
            return clientOperation.First().IsLongRunningReallyLong();
        }

        public static bool IsPagingOperation(this MgmtRestOperation restOperation, BuildContext<MgmtOutputLibrary> context)
        {
            return restOperation.GetPagingMethod(context) != null;
        }

        public static PagingMethod? GetPagingMethod(this MgmtRestOperation restOperation, BuildContext<MgmtOutputLibrary> context)
        {
            if (context.Library.PagingMethods.TryGetValue(restOperation.Method, out var pagingMethod))
                return pagingMethod;

            return null;
        }

        public static bool IsLongRunningOperation(this MgmtRestOperation restOperation)
        {
            return restOperation.Operation.IsLongRunning;
        }

        public static bool IsLongRunningReallyLong(this MgmtRestOperation restOperation)
        {
            return restOperation.Operation.IsLongRunningReallyLong ?? false;
        }
    }
}
