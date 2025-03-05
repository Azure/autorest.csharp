// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record OperationPaging(NextLink? NextLink, ContinuationToken? ContinuationToken, IReadOnlyList<string> ItemPropertySegments)
{
    private string? nextLinkName;
    private string? itemName;
    private InputOperation? nextLinkOperation;
    private bool selfNextLink;

    public OperationPaging() : this(null, null, Array.Empty<string>()) { }

    // obsolete, for swagger input only
    public OperationPaging(string? NextLinkName, string? ItemName, InputOperation? NextLinkOperation, bool SelfNextLink)
        : this(null, null, Array.Empty<string>())
    {
        nextLinkName = NextLinkName;
        itemName = ItemName;
        nextLinkOperation = NextLinkOperation;
        selfNextLink = SelfNextLink;
    }

    public string? NextLinkName => nextLinkName ??= (NextLink?.ResponseSegments.Count > 0 ? NextLink.ResponseSegments[0] : null);

    public string? ItemName => itemName ??= (ItemPropertySegments.Count > 0 ? ItemPropertySegments[0] : null);

    public InputOperation? NextLinkOperation
    {
        get
        {
            return nextLinkOperation ??= NextLink?.Operation;
        }
        set
        {
            nextLinkOperation = value;
        }
    }

    public bool SelfNextLink => selfNextLink;
}

internal record NextLink(InputOperation? Operation, IReadOnlyList<string> ResponseSegments, ResponseLocation ResponseLocation)
{
    public NextLink() : this(null, Array.Empty<string>(), ResponseLocation.None) { }
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
