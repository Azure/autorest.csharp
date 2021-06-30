// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
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
                return type.Implementation is EnumType enumType && enumType.BaseType.Equals(typeof(string));
            };
        }

        public static CSharpType WrapPageable(this CSharpType type, bool async)
        {
            return async ? new CSharpType(typeof(AsyncPageable<>), type) : new CSharpType(typeof(Pageable<>), type);
        }

        public static CSharpType WrapPageable(this Type type, bool async)
        {
            return async ? new CSharpType(typeof(AsyncPageable<>), type) : new CSharpType(typeof(Pageable<>), type);
        }

        public static CSharpType WrapAsync(this CSharpType type, bool async)
        {
            return async ? new CSharpType(typeof(Task<>), type) : type;
        }

        public static CSharpType WrapResponse(this CSharpType type)
        {
            return new CSharpType(typeof(Response<>), type);
        }

        public static CSharpType WrapAsyncResponse(this CSharpType type, bool async)
        {
            var responseType = type.WrapResponse();
            return async ? new CSharpType(typeof(Task<>), responseType) : responseType;
        }
    }
}
