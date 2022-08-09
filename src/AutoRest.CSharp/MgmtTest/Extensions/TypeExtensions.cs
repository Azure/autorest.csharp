// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.MgmtTest.Extensions
{
    internal static class TypeExtensions
    {
        public static bool IsResourceType(this CSharpType type, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (type.IsFrameworkType)
                return false;

            resource = type.Implementation as Resource;
            return resource != null && resource is not ResourceCollection;
        }

        public static bool IsResourceCollectionType(this CSharpType type, [MaybeNullWhen(false)] out ResourceCollection collection)
        {
            collection = null;
            if (type.IsFrameworkType)
                return false;

            collection = type.Implementation as ResourceCollection;
            return collection != null;
        }
    }
}
