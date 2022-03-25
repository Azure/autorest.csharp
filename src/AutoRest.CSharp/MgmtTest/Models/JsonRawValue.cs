// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal readonly struct JsonRawValue
    {
        public readonly object? RawValue;

        public JsonRawValue(object? rawValue)
        {
            RawValue = rawValue;
        }

        public bool IsNull()
        {
            return RawValue is null;
        }

        public bool IsEnumerable()
        {
            if (RawValue == null)
                return false;
            return typeof(IEnumerable<object>).IsAssignableFrom(RawValue.GetType());
        }
        public IEnumerable<object> AsEnumerable()
        {
            return RawValue is null ? Enumerable.Empty<object>() : (IEnumerable<object>)RawValue;
        }

        public bool IsString()
        {
            if (RawValue == null)
                return false;
            return RawValue is string;
        }
        public string? AsString()
        {
            return RawValue?.ToString();
        }

        public bool IsDictionary()
        {
            if (RawValue == null)
                return false;
            Type t = RawValue.GetType();
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>) || t.Name == "RecordOfStringAndAny";
        }
        public Dictionary<string, object?> AsDictionary()
        {
            var ret = new Dictionary<string, object?>();
            if (RawValue is null)
                return ret;
            if (RawValue is RecordOfStringAndAny)
            {
                return (RecordOfStringAndAny)RawValue;
            }
            foreach (KeyValuePair<object, object?> entry in (IEnumerable<KeyValuePair<object, object?>>)RawValue)
            {
                ret.Add(entry.Key.ToString()!, entry.Value);
            }
            return ret;
        }
    }
}
