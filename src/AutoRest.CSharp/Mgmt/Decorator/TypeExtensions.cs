// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Is the type a string or an Enum that is modeled as string.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>Is the type a string or an Enum that is modeled as string.</returns>
        public static bool IsStringLike(this CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                return type.Equals(typeof(string));
            }
            else
            {
                return type.Implementation is EnumType enumType && enumType.BaseType.Equals(typeof(string)) && enumType.IsExtendable;
            };
        }

        /// <summary>
        /// Check whether two CSharpType instances equal or not
        /// This is not the same as left.Equals(right) because this function only checks the names
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool EqualsByName(this CSharpType left, CSharpType right)
        {
            if (left.Name != right.Name)
                return false;

            if (left.Arguments.Length != right.Arguments.Length)
                return false;

            for (int i = 0; i < left.Arguments.Length; i++)
            {
                if (left.Arguments[i].Name != right.Arguments[i].Name)
                    return false;
            }

            return true;
        }

        public static CSharpType WrapPageable(this CSharpType type, bool isAsync)
        {
            return isAsync ? new CSharpType(typeof(AsyncPageable<>), type) : new CSharpType(typeof(Pageable<>), type);
        }

        public static CSharpType WrapPageable(this Type type, bool isAsync)
        {
            return isAsync ? new CSharpType(typeof(AsyncPageable<>), new CSharpType(type)) : new CSharpType(typeof(Pageable<>), new CSharpType(type));
        }

        public static CSharpType WrapAsync(this CSharpType type, bool isAsync)
        {
            return isAsync ? new CSharpType(typeof(Task<>), type) : type;
        }

        public static CSharpType WrapAsync(this Type type, bool isAsync)
        {
            return new CSharpType(type).WrapAsync(isAsync);
        }

        public static CSharpType WrapResponse(this CSharpType type, bool isAsync)
        {
            var response = new CSharpType(typeof(Response<>), type);
            return isAsync ? new CSharpType(typeof(Task<>), response) : response;
        }

        public static CSharpType WrapResponse(this Type type, bool isAsync)
        {
            var response = new CSharpType(typeof(Response<>), new CSharpType(type));
            return isAsync ? new CSharpType(typeof(Task<>), response) : response;
        }

        public static bool IsResourceDataType(this CSharpType type, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = null;
            if (type.IsFrameworkType)
                return false;

            if (context.Library.TryGetTypeProvider(type.Name, out var provider))
            {
                data = provider as ResourceData;
                return data != null;
            }
            return false;
        }
    }
}
