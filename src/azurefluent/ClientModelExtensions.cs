// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Text.RegularExpressions;
using AutoRest.Core.Model;

namespace AutoRest.CSharp.Azure.Fluent
{
    public static class ClientModelExtensions
    {
        public static bool IsResource(this IModelType type)
        {
            var compositeType = type as CompositeType;
            return (compositeType != null) &&
                   ((type.Name == "Resource") || (type.Name == "SubResource") ||
                    (type.Name == "Microsoft.Rest.Azure.Resource") || (type.Name == "Microsoft.Rest.Azure.SubResource"));
        }
    }
}