using System;
using System.Collections.Generic;
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

        private static IEnumerable<string> GetParentPairs((string ClassName, string ParentName)[] allPairs, (string ClassName, string ParentName) pair)
        {
            yield return pair.ClassName;

            var foundPairs = allPairs.Where(p => p.ParentName == pair.ClassName).SelectMany(p => GetParentPairs(allPairs, p)).ToArray();
            foreach (var foundPair in foundPairs)
            {
                yield return foundPair;
            }

            //if (!foundPairs.Any())
            //{
            //    yield return pair.ClassName;
            //}
        }

        public static string AddOrderInfo(string cSharpCode)
        {
            var lines = cSharpCode.ToLines().ToArray();
            var namePairs = lines
                .Where(l => l.Contains("partial class"))
                .Select(l =>
                {
                    var match = Regex.Match(l, @"partial class (\w*)( : )?((?!(System))\w*)");
                    var className = match.Success ? match.Groups[1].Value : String.Empty;
                    var parentName = match.Success ? match.Groups[3].Value : String.Empty;
                    return (ClassName: className, ParentName: parentName);
                })
                .ToArray();
            var parentPairs = namePairs.Where(p => p.ParentName != String.Empty).ToArray();
            var classNameGroups = namePairs
                .Where(p => p.ParentName == String.Empty)
                .Select((p, i) => (ClassNames: GetParentPairs(parentPairs, p).ToArray(), GroupIndex: i))
                .ToArray();

            var currentClassName = String.Empty;
            var orderedProperties = lines
                .Select((l, i) => (Line: l, Index: i))
                .Where(p => p.Line.Contains("partial class") || p.Line.Contains("YamlMember"))
                // Group the lines by class name group index
                .GroupBy(p =>
                {
                    var match = Regex.Match(p.Line, @"partial class (\w*)");
                    var className = match.Success ? (currentClassName = match.Groups[1].Value) : currentClassName;
                    return classNameGroups.First(g => g.ClassNames.Contains(className)).GroupIndex;
                }, p => p, (k, g) => g
                    .Where(p => p.Line.Contains("YamlMember"))
                    // Convert the property line into alias names
                    .Select(p =>
                    {
                        var match = Regex.Match(p.Line, @"YamlMember\(Alias = ""(.*)""");
                        var alias = match.Success ? match.Groups[1].Value : String.Empty;
                        return (p.Index, p.Line, Alias: alias);
                    }))
                // Order the properties within each class
                .SelectMany(g =>
                    // Determine raw order value based on alias
                    g.Select(p => (p.Index, p.Line, p.Alias, RawOrderValue: GetRawOrderValue(p.Alias)))
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
