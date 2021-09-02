// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class FormattableResourceIdentifier
    {
        private const string RootStringValue = "/";
        internal const string ProvidersKey = "providers";
        internal const string SubscriptionsKey = "subscriptions";
        internal const string LocationsKey = "locations";
        internal const string ResourceGroupsLowerKey = "resourcegroups";
        internal const string BuiltInResourceNamespace = "Microsoft.Resources";

        //public static readonly FormattableResourceIdentifier RootResourceIdentifier = new FormattableResourceIdentifier(null, "Microsoft.Resource/tenants", string.Empty);

        //internal FormattableResourceIdentifier(FormattableResourceIdentifier? parent, FormattableResourceType resourceType, string name)
        //{
        //    //TODO
        //}

        //public virtual FormattableResourceType? ResourceType { get; internal set; }

        //public static FormattableResourceIdentifier Create(string path)
        //{
        //    if (path is null)
        //        throw new ArgumentNullException(nameof(path));

        //    if (!path.StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
        //        throw new ArgumentOutOfRangeException(nameof(path), "Invalid request path");

        //    var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    if (segments.Count < 2)
        //        throw new NotImplementedException("TODO");

        //    var firstToLower = segments[0].ToLowerInvariant();
        //    if (firstToLower != SubscriptionsKey && firstToLower != ProvidersKey)
        //    {
        //        throw new NotImplementedException("TODO -- handle scope related things");
        //    }

        //    return AppendNext(RootResourceIdentifier, segments);
        //}

        //private static FormattableResourceIdentifier AppendNext(FormattableResourceIdentifier parent, List<string> segments)
        //{
        //    if (segments.Count == 0)
        //        return parent;

        //    var lowerFirstPart = segments[0].ToLowerInvariant();

        //}
    }
}
