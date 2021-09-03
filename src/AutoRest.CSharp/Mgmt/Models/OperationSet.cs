// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal struct OperationSet : IReadOnlyList<RestClientMethod>
    {
        public RequestPath RequestPath { get; }
        public IReadOnlyList<RestClientMethod> RestClientMethods { get; }

        public int Count => RestClientMethods.Count;

        public RestClientMethod this[int index] => RestClientMethods[index];

        public OperationSet(RequestPath requestPath, IReadOnlyList<RestClientMethod> restClientMethods)
        {
            RequestPath = requestPath;
            RestClientMethods = restClientMethods;
        }

        public IEnumerator<RestClientMethod> GetEnumerator() => RestClientMethods.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => RestClientMethods.GetEnumerator();

        public override string? ToString()
        {
            return RequestPath.ToString();
        }
    }
}
