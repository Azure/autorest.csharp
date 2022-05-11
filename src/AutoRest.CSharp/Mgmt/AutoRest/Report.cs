// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class Report
    {
        private List<ReportItem> _items;

        public bool HasError { get; internal set; } = false;

        public Report()
        {
            _items = new List<ReportItem>();
        }

        public void Add(ReportLevel level, string message)
        {
            _items.Add(new ReportItem(level, message));
            if (level == ReportLevel.Error)
                HasError = true;
        }

        public void AddInfo(string message)
        {
            Add(ReportLevel.Information, message);
        }

        public void AddChange<T>(string target, string? scope, T from, T to)
        {
            var prefix = string.IsNullOrEmpty(scope) ? string.Empty : $"[{scope}] ";
            if (from != null && !from.Equals(to))
            {
                _items.Add(new ReportItem(ReportLevel.Information, $"{prefix}{target} has been changed from {from} to {to}"));
            }
            else if (to != null && !to.Equals(from))
            {
                _items.Add(new ReportItem(ReportLevel.Information, $"{prefix}{target} has been changed from {from} to {to}"));
            }
        }

        public void AddChange<T>(string target, T from, T to)
        {
            AddChange(target, null, from, to);
        }

        public void AddError(string message)
        {
            Add(ReportLevel.Error, message);
        }

        public override string ToString()
        {
            return String.Join('\n', _items.Select(item => $"[{item.Level}] {item.Message}"));
        }
    }

    internal record ReportItem(ReportLevel Level, string Message);

    internal enum ReportLevel
    {
        Information,
        Warning,
        Error,
    }
}
