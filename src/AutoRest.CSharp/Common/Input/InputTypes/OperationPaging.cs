// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record OperationPaging
{
    public OperationPaging(NextLink? nextLink, ContinuationToken? continuationToken, IReadOnlyList<string> itemPropertySegments)
    {
        NextLink = nextLink ?? new();
        ContinuationToken = continuationToken;
        ItemPropertySegments = itemPropertySegments;
    }

    public NextLink NextLink { get; init; }
    public ContinuationToken? ContinuationToken { get; init; }
    public IReadOnlyList<string> ItemPropertySegments { get; init; }

    public OperationPaging() : this(null, null, Array.Empty<string>()) { }

    // obsolete, for swagger input only
    public OperationPaging(string? nextLinkName, string? itemName, InputOperation? nextLinkOperation, bool selfNextLink)
        : this(null, null, Array.Empty<string>())
    {
        NextLink = BuildNextLink(nextLinkName, nextLinkOperation);
        ItemPropertySegments = itemName != null ? [itemName] : [];
        SelfNextLink = selfNextLink;
    }

    private static NextLink BuildNextLink(string? nextLinkName, InputOperation? nextLinkOperation)
    {
        string[]? nextLinkSegments = nextLinkName != null ? [nextLinkName] : null;
        return new NextLink(nextLinkOperation, nextLinkSegments ?? [], ResponseLocation.Body);
    }

    public string? NextLinkName => NextLink?.ResponseSegments.Count > 0 ? NextLink.ResponseSegments[0] : null;

    public string? ItemName => ItemPropertySegments.Count > 0 ? ItemPropertySegments[0] : null;

    public InputOperation? NextLinkOperation
    {
        get
        {
            return NextLink?.Operation;
        }
        set
        {
            NextLink.Operation = value;
        }
    }

    public bool SelfNextLink { get; }
}

internal record NextLink(InputOperation? Operation, IReadOnlyList<string> ResponseSegments, ResponseLocation ResponseLocation)
{
    public NextLink() : this(null, Array.Empty<string>(), ResponseLocation.None) { }

    public InputOperation? Operation { get; internal set; } = Operation;
}

internal record ContinuationToken(InputParameter Parameter, IReadOnlyList<string> ResponseSegments, ResponseLocation ResponseLocation)
{
    public ContinuationToken() : this(new InputParameter(), Array.Empty<string>(), ResponseLocation.None) { }
}

internal enum ResponseLocation
{
    None,
    Header,
    Body
}
