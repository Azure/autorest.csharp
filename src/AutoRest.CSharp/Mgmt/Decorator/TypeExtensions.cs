// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Is the type a string or an Enum that is modeled as string.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>Is the type a string or an Enum that is modeled as string.</returns>
        public static bool IsStringLike(this CSharp.Generation.Types.CSharpType type)
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
    }
}
