// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputOperationPaging
{
    public InputOperationPaging(InputNextLink? nextLink, InputContinuationToken? continuationToken, IReadOnlyList<string> itemPropertySegments)
    {
        NextLink = nextLink ?? new();
        ContinuationToken = continuationToken;
        ItemPropertySegments = itemPropertySegments;
    }

    public InputNextLink NextLink { get; init; }
    public InputContinuationToken? ContinuationToken { get; init; }
    public IReadOnlyList<string> ItemPropertySegments { get; init; }

    public InputOperationPaging() : this(null, null, Array.Empty<string>()) { }

    // obsolete, for swagger input only
    public InputOperationPaging(string? nextLinkName, string? itemName, InputOperation? nextLinkOperation, bool selfNextLink)
        : this(null, null, Array.Empty<string>())
    {
        NextLink = BuildNextLink(nextLinkName, nextLinkOperation);
        ItemPropertySegments = itemName != null ? [itemName] : [];
        SelfNextLink = selfNextLink;
    }

    private static InputNextLink BuildNextLink(string? nextLinkName, InputOperation? nextLinkOperation)
    {
        string[]? nextLinkSegments = nextLinkName != null ? [nextLinkName] : null;
        return new InputNextLink(nextLinkOperation, nextLinkSegments ?? [], InputResponseLocation.Body);
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

internal record InputNextLink(InputOperation? Operation, IReadOnlyList<string> ResponseSegments, InputResponseLocation ResponseLocation)
{
    public InputNextLink() : this(null, Array.Empty<string>(), InputResponseLocation.None) { }

    public InputOperation? Operation { get; internal set; } = Operation;
}

internal record InputContinuationToken(InputParameter Parameter, IReadOnlyList<string> ResponseSegments, InputResponseLocation ResponseLocation)
{
    public InputContinuationToken() : this(new InputParameter(), Array.Empty<string>(), InputResponseLocation.None) { }
}

internal enum InputResponseLocation
{
    None,
    Header,
    Body
}
