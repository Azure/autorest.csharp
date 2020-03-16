// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted cell in a table. </summary>
    public partial class DataTableCell
    {
        /// <summary> Initializes a new instance of DataTableCell. </summary>
        internal DataTableCell()
        {
        }

        /// <summary> Initializes a new instance of DataTableCell. </summary>
        /// <param name="rowIndex"> Row index of the cell. </param>
        /// <param name="columnIndex"> Column index of the cell. </param>
        /// <param name="rowSpan"> Number of rows spanned by this cell. </param>
        /// <param name="columnSpan"> Number of columns spanned by this cell. </param>
        /// <param name="text"> Text content of the cell. </param>
        /// <param name="boundingBox"> Bounding box of the cell. </param>
        /// <param name="confidence"> Confidence value. </param>
        /// <param name="elements"> When includeTextDetails is set to true, a list of references to the text elements constituting this table cell. </param>
        /// <param name="isHeader"> Is the current cell a header cell?. </param>
        /// <param name="isFooter"> Is the current cell a footer cell?. </param>
        internal DataTableCell(int rowIndex, int columnIndex, int? rowSpan, int? columnSpan, string text, IList<float> boundingBox, float confidence, IList<string> elements, bool? isHeader, bool? isFooter)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
            Text = text;
            BoundingBox = boundingBox;
            Confidence = confidence;
            Elements = elements;
            IsHeader = isHeader;
            IsFooter = isFooter;
        }

        /// <summary> Row index of the cell. </summary>
        public int RowIndex { get; set; }
        /// <summary> Column index of the cell. </summary>
        public int ColumnIndex { get; set; }
        /// <summary> Number of rows spanned by this cell. </summary>
        public int? RowSpan { get; set; }
        /// <summary> Number of columns spanned by this cell. </summary>
        public int? ColumnSpan { get; set; }
        /// <summary> Text content of the cell. </summary>
        public string Text { get; set; }
        /// <summary> Bounding box of the cell. </summary>
        public IList<float> BoundingBox { get; set; } = new List<float>();
        /// <summary> Confidence value. </summary>
        public float Confidence { get; set; }
        /// <summary> When includeTextDetails is set to true, a list of references to the text elements constituting this table cell. </summary>
        public IList<string> Elements { get; set; }
        /// <summary> Is the current cell a header cell?. </summary>
        public bool? IsHeader { get; set; }
        /// <summary> Is the current cell a footer cell?. </summary>
        public bool? IsFooter { get; set; }
    }
}
