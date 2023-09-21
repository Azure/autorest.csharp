// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Output;
using Azure;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TypeExtensions
    {

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

        public static CSharpType WrapAsync(this CSharpType type, bool isAsync)
        {
            return isAsync ? new CSharpType(typeof(Task<>), type) : type;
        }

        public static CSharpType WrapResponse(this CSharpType type, bool isAsync, bool isNullable)
        {
            var response = new CSharpType(isNullable ? typeof(NullableResponse<>) : Configuration.ApiTypes.ResponseOfTType, type);
            return isAsync ? new CSharpType(typeof(Task<>), response) : response;
        }

        public static CSharpType WrapOperation(this CSharpType type, bool isAsync)
        {
            var response = new CSharpType(typeof(ArmOperation<>), type);
            return isAsync ? new CSharpType(typeof(Task<>), response) : response;
        }

        public static bool TryCastResource(this CSharpType type, [MaybeNullWhen(false)] out Resource resource)
            => type.TryCast<Resource>(out resource);

        public static bool TryCastResourceData(this CSharpType type, [MaybeNullWhen(false)] out ResourceData data)
            => type.TryCast<ResourceData>(out data);
    }
}
