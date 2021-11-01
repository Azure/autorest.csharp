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
        /// <returns></returns>
        public static bool IsListMethod(this MgmtRestOperation operation, [MaybeNullWhen(false)] out CSharpType itemType)
        {
            return IsListMethod(operation.Method, out itemType);
        }

        public static bool IsListMethod(this RestClientMethod method, [MaybeNullWhen(false)] out CSharpType itemType)
        {
            itemType = null;
            var returnType = method.ReturnType;
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
            return clientOperation.First().IsListMethod(out itemType);
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
            return restOperation.Operation.Language.Default.Paging != null;
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
