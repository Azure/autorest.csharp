using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AutoRest.CodeModel
{
    internal static class Orderer
    {
        //https://github.com/Azure/perks/blob/8b2631ee1f4d0a66e2ab3ea24fb6e72e9bc372e7/codegen/yaml.ts#L8-L39
        private static readonly string[] Priority = {
            "$key",
            "primitives",
            "objects",
            "dictionaries",
            "compounds",
            "choices",
            "name",
            "schemas",
            "type",
            "format",
            "schema",
            "operationId",
            "path",
            "method",
            "description",
            "default"
        };
        private static readonly string[] NegativePriority = {
            "request",
            "responses",
            "exceptions",
            "callbacks",
            "http",
            "commands",
            "operations",
            "extensions",
            "details",
            "language",
            "protocol"
        };

        private enum OrderType
        {
            // Order is significant
            Incrementing = 0,
            Alpha,
            Decrementing
        }

        private static int? GetRawOrderValue(string alias) =>
            Priority.Select((n, i) => new { Name = n, Value = i }).FirstOrDefault(p => p.Name == alias)?.Value
            ?? NegativePriority.Select((n, i) => new { Name = n, Value = (i + 1) * -1 }).FirstOrDefault(p => p.Name == alias)?.Value;

        public static string AddOrderInfo(string cSharpCode)
        {
            var lines = cSharpCode.ToLines().ToArray();
            var className = String.Empty;
            var orderedProperties = lines
                .Select((l, i) => (Line: l, Index: i))
                .Where(p => p.Line.Contains("partial class") || p.Line.Contains("YamlMember"))
                // Group the lines by class name
                .GroupBy(p =>
                {
                    var match = Regex.Match(p.Line, @"partial class (\w*)");
                    return match.Success ? (className = match.Groups[1].Value) : className;
                }, p => p, (k, g) => (ClassName: k, Properties: g
                    .Where(p => p.Line.Contains("YamlMember"))
                    // Convert the property line into alias names
                    .Select(p =>
                    {
                        var match = Regex.Match(p.Line, @"YamlMember\(Alias = ""(.*)""");
                        var alias = match.Success ? match.Groups[1].Value : String.Empty;
                        return (p.Index, p.Line, Alias: alias);
                    })))
                .SelectMany(g =>
                    // Order the properties within each class
                    g.Properties
                        // Determine raw order value based on alias
                        .Select(p => (p.Index, p.Line, p.Alias, RawOrderValue: GetRawOrderValue(p.Alias)))
                        // Group the properties based on the which order type the order value belongs to
                        .GroupBy(p => p.RawOrderValue == null ? OrderType.Alpha : (p.RawOrderValue.Value < 0 ? OrderType.Decrementing : OrderType.Incrementing),
                            p => p, (k, p) => (OrderType: k, Properties: p))
                        // Sort the properties based on order type
                        .Select(o =>
                        {
                            var sorted = o.OrderType == OrderType.Incrementing ? o.Properties.OrderBy(p => p.RawOrderValue) :
                                (o.OrderType == OrderType.Decrementing ? o.Properties.OrderByDescending(p => p.RawOrderValue) : o.Properties.OrderBy(p => p.Alias));
                            return (o.OrderType, Properties: sorted);
                        })
                        // Order the groups of order types prior to flattening
                        .OrderBy(o => o.OrderType)
                        // Flatten the properties
                        .SelectMany(o => o.Properties)
                        // The indices of the properties becomes the order
                        .Select((p, i) => (p.Index, p.Line, p.Alias, Order: i))
                )
                .ToArray();

            foreach (var property in orderedProperties)
            {
                lines[property.Index] = property.Line.Replace($"\"{property.Alias}\")", $"\"{property.Alias}\", Order = {property.Order})");
            }

            return String.Join(Environment.NewLine, lines);
        }
    }
}
