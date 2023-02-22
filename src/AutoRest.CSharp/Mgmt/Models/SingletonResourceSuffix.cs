// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class SingletonResourceSuffix
    {
        public static SingletonResourceSuffix Parse(string[] segments)
        {
            // put the segments in pairs
            var pairs = new List<(string Key, string Value)>();
            for (int i = 0; i < segments.Length; i += 2)
            {
                pairs.Add((segments[i], segments[i + 1]));
            }

            return new SingletonResourceSuffix(pairs);
        }

        private IReadOnlyList<(string Key, string Value)> _pairs;

        private SingletonResourceSuffix(IReadOnlyList<(string Key, string Value)> pairs)
        {
            _pairs = pairs;
        }

        public FormattableString BuildResourceIdentifier(FormattableString originalId)
        {
            var list = new List<FormattableString>() { originalId };
            for (int i = 0; i < _pairs.Count; i++)
            {
                var key = _pairs[i].Key;
                var value = _pairs[i].Value;
                if (key == Segment.Providers)
                {
                    // when we have a providers, we must have a next pair
                    i++;
                    var nextKey = _pairs[i].Key;
                    var nextValue = _pairs[i].Value;
                    list.Add($"{nameof(ResourceIdentifier.AppendProviderResource)}({value:L}, {nextKey:L}, {nextValue:L})");
                }
                else
                {
                    // if not, we just call the method to append this pair
                    list.Add($"{nameof(ResourceIdentifier.AppendChildResource)}({key:L}, {value:L})");
                }
            }

            return list.Join(".");
        }
    }
}
