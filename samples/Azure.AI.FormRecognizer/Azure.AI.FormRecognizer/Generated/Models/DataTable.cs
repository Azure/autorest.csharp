// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted table contained in a page. </summary>
    public partial class DataTable
    {
        /// <summary> Initializes a new instance of DataTable. </summary>
        /// <param name="rows"> Number of rows. </param>
        /// <param name="columns"> Number of columns. </param>
        /// <param name="cells"> List of cells contained in the table. </param>
        internal DataTable(int rows, int columns, IReadOnlyList<DataTableCell> cells)
        {
            Rows = rows;
            Columns = columns;
            Cells = cells;
        }

        /// <summary> Number of rows. </summary>
        public int Rows { get; }
        /// <summary> Number of columns. </summary>
        public int Columns { get; }
        /// <summary> List of cells contained in the table. </summary>
        public IReadOnlyList<DataTableCell> Cells { get; }
    }
}
