// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Output.Models.Responses;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.Responses
{
    internal record ResponseClassifierType(string Name, StatusCodes[] StatusCodes)
    {
        public ResponseClassifierType(IOrderedEnumerable<StatusCodes> statusCodes) : this(ComposeName(statusCodes), statusCodes.ToArray())
        {
        }

        public virtual bool Equals(ResponseClassifierType? other) => (other == null ? false : Name == other.Name);

        public override int GetHashCode() => Name.GetHashCode();

        private static string ComposeName(IOrderedEnumerable<StatusCodes> statusCodes) => nameof(ResponseClassifier) + string.Join("", statusCodes.Select(c => c.Code?.ToString() ?? $"{c.Family * 100}To{(c.Family + 1) * 100}"));
    }
}
