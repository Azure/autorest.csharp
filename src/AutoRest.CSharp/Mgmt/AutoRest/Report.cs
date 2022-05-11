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
