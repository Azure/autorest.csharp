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
    internal readonly struct ResponseClassifierType : IEquatable<ResponseClassifierType>
    {
        public string Name { get; }
        private readonly StatusCodes[] _statusCodes;

        public ResponseClassifierType(IOrderedEnumerable<StatusCodes> statusCodes)
        {
            _statusCodes = statusCodes.ToArray();
            Name = nameof(ResponseClassifier) + string.Join("", _statusCodes.Select(c => c.Code?.ToString() ?? $"{c.Family * 100}To{(c.Family + 1) * 100}"));
        }

        public bool Equals(ResponseClassifierType other) => Name == other.Name;

        public override bool Equals(object? obj) => obj is ResponseClassifierType other && Equals(other);

        public override int GetHashCode() => Name.GetHashCode();

        internal void Deconstruct(out string name, out StatusCodes[] statusCodes)
        {
            name = Name;
            statusCodes = _statusCodes;
        }
    }
}
