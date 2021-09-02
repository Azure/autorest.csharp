// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class FormattableResourceType
    {
        //public static FormattableResourceType RootResourceType => new FormattableResourceType(string.Empty, string.Empty);

        //public FormattableResourceType(string path)
        //{
        //    if (string.IsNullOrWhiteSpace(path))
        //        throw new ArgumentException($"{nameof(path)} cannot be null or whitespace", nameof(path));

        //    Parse(path);
        //    Types = Type!.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.ParseToReferenceOrConstant()).ToArray();
        //}

        //internal FormattableResourceType(string providerNamespace, string name)
        //{
        //    Namespace = providerNamespace.ParseToReferenceOrConstant();
        //    Type = name;
        //    Types = Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.ParseToReferenceOrConstant()).ToArray();
        //}

        //public static implicit operator FormattableResourceType(string other)
        //{
        //    return new FormattableResourceType(other);
        //}

        //public static implicit operator string(FormattableResourceType other)
        //{
        //    return other.ToString() ?? string.Empty;
        //}

        //internal ReferenceOrConstant LastType => Types[Types.Count - 1];

        ///// <summary>
        ///// Gets the resource type Namespace.
        ///// </summary>
        //public ReferenceOrConstant Namespace { get; private set; }

        ///// <summary>
        ///// Gets the resource Type.
        ///// </summary>
        //public string Type { get; private set; }

        ///// <summary>
        ///// Gets the resource Types.
        ///// </summary>
        //public IReadOnlyList<ReferenceOrConstant> Types { get; } = new List<ReferenceOrConstant>();

        //private void Parse(string path)
        //{
        //    // split the path into segments
        //    var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries).ToList();

        //    // There must be at least one of the segments exists
        //    if (segments.Count < 1)
        //        throw new ArgumentOutOfRangeException(nameof(path));

        //    // if the type is just

        //    // TODO

        //}
    }
}
