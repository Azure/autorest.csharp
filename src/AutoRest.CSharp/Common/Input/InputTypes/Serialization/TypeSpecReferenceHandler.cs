﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    /// <summary>
    /// Custom reference handler that preserves the same instance of the resolver across multiple calls of the converters Read method
    /// Required for the reference preservation to work with custom converters
    /// </summary>
    internal sealed class TypeSpecReferenceHandler : ReferenceHandler
    {
        public ReferenceResolver CurrentResolver { get; } = new TypeSpecReferenceResolver();

        public override ReferenceResolver CreateResolver() => CurrentResolver;

        private class TypeSpecReferenceResolver : ReferenceResolver
        {
            private readonly Dictionary<string, object> _referenceIdToObjectMap = new();

            public override void AddReference(string referenceId, object value)
            {
                //TODO: This is a workaround. When we resolve the duplicate schema issue https://github.com/Azure/autorest.csharp/issues/4029, we should revert it back to the original behavior.
                if (!_referenceIdToObjectMap.ContainsKey(referenceId))
                {
                    _referenceIdToObjectMap.Add(referenceId, value);
                }
            }

            public override string GetReference(object value, out bool alreadyExists)
                => throw new InvalidOperationException("JSON writing isn't supported");

            public override object ResolveReference(string referenceId)
                => _referenceIdToObjectMap.TryGetValue(referenceId, out object? value) ? value : throw new JsonException();
        }
    }
}
