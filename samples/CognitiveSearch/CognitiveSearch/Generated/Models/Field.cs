// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a field in an index definition, which describes the name, data type, and search behavior of a field. </summary>
    public partial class Field
    {
        /// <summary> The name of the field, which must be unique within the fields collection of the index or parent field. </summary>
        public string Name { get; set; }
        /// <summary> Defines the data type of a field in a search index. </summary>
        public DataType Type { get; set; }
        /// <summary> A value indicating whether the field uniquely identifies documents in the index. Exactly one top-level field in each index must be chosen as the key field and it must be of type Edm.String. Key fields can be used to look up documents directly and update or delete specific documents. Default is false for simple fields and null for complex fields. </summary>
        public bool? Key { get; set; }
        /// <summary> A value indicating whether the field can be returned in a search result. You can disable this option if you want to use a field (for example, margin) as a filter, sorting, or scoring mechanism but do not want the field to be visible to the end user. This property must be true for key fields, and it must be null for complex fields. This property can be changed on existing fields. Enabling this property does not cause any increase in index storage requirements. Default is true for simple fields and null for complex fields. </summary>
        public bool? Retrievable { get; set; }
        /// <summary> A value indicating whether the field is full-text searchable. This means it will undergo analysis such as word-breaking during indexing. If you set a searchable field to a value like &quot;sunny day&quot;, internally it will be split into the individual tokens &quot;sunny&quot; and &quot;day&quot;. This enables full-text searches for these terms. Fields of type Edm.String or Collection(Edm.String) are searchable by default. This property must be false for simple fields of other non-string data types, and it must be null for complex fields. Note: searchable fields consume extra space in your index since Azure Cognitive Search will store an additional tokenized version of the field value for full-text searches. If you want to save space in your index and you don&apos;t need a field to be included in searches, set searchable to false. </summary>
        public bool? Searchable { get; set; }
        /// <summary> A value indicating whether to enable the field to be referenced in $filter queries. filterable differs from searchable in how strings are handled. Fields of type Edm.String or Collection(Edm.String) that are filterable do not undergo word-breaking, so comparisons are for exact matches only. For example, if you set such a field f to &quot;sunny day&quot;, $filter=f eq &apos;sunny&apos; will find no matches, but $filter=f eq &apos;sunny day&apos; will. This property must be null for complex fields. Default is true for simple fields and null for complex fields. </summary>
        public bool? Filterable { get; set; }
        /// <summary> A value indicating whether to enable the field to be referenced in $orderby expressions. By default Azure Cognitive Search sorts results by score, but in many experiences users will want to sort by fields in the documents. A simple field can be sortable only if it is single-valued (it has a single value in the scope of the parent document). Simple collection fields cannot be sortable, since they are multi-valued. Simple sub-fields of complex collections are also multi-valued, and therefore cannot be sortable. This is true whether it&apos;s an immediate parent field, or an ancestor field, that&apos;s the complex collection. Complex fields cannot be sortable and the sortable property must be null for such fields. The default for sortable is true for single-valued simple fields, false for multi-valued simple fields, and null for complex fields. </summary>
        public bool? Sortable { get; set; }
        /// <summary> A value indicating whether to enable the field to be referenced in facet queries. Typically used in a presentation of search results that includes hit count by category (for example, search for digital cameras and see hits by brand, by megapixels, by price, and so on). This property must be null for complex fields. Fields of type Edm.GeographyPoint or Collection(Edm.GeographyPoint) cannot be facetable. Default is true for all other simple fields. </summary>
        public bool? Facetable { get; set; }
        /// <summary> Defines the names of all text analyzers supported by Azure Cognitive Search. </summary>
        public AnalyzerName? Analyzer { get; set; }
        /// <summary> Defines the names of all text analyzers supported by Azure Cognitive Search. </summary>
        public AnalyzerName? SearchAnalyzer { get; set; }
        /// <summary> Defines the names of all text analyzers supported by Azure Cognitive Search. </summary>
        public AnalyzerName? IndexAnalyzer { get; set; }
        /// <summary> A list of the names of synonym maps to associate with this field. This option can be used only with searchable fields. Currently only one synonym map per field is supported. Assigning a synonym map to a field ensures that query terms targeting that field are expanded at query-time using the rules in the synonym map. This attribute can be changed on existing fields. Must be null or an empty collection for complex fields. </summary>
        public ICollection<string>? SynonymMaps { get; set; }
        /// <summary> A list of sub-fields if this is a field of type Edm.ComplexType or Collection(Edm.ComplexType). Must be null or empty for simple fields. </summary>
        public ICollection<Field>? Fields { get; set; }
    }
}
