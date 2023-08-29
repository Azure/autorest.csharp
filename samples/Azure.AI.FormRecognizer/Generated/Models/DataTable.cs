// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted table contained in a page. </summary>
    public partial class DataTable
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.DataTable
        ///
        /// </summary>
        /// <param name="rows"> Number of rows. </param>
        /// <param name="columns"> Number of columns. </param>
        /// <param name="cells"> List of cells contained in the table. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cells"/> is null. </exception>
        internal DataTable(int rows, int columns, IEnumerable<DataTableCell> cells)
        {
            Argument.AssertNotNull(cells, nameof(cells));

            Rows = rows;
            Columns = columns;
            Cells = cells.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.DataTable
        ///
        /// </summary>
        /// <param name="rows"> Number of rows. </param>
        /// <param name="columns"> Number of columns. </param>
        /// <param name="cells"> List of cells contained in the table. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DataTable(int rows, int columns, IReadOnlyList<DataTableCell> cells, Dictionary<string, BinaryData> rawData)
        {
            Rows = rows;
            Columns = columns;
            Cells = cells;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DataTable"/> for deserialization. </summary>
        internal DataTable()
        {
        }

        /// <summary> Number of rows. </summary>
        public int Rows { get; }
        /// <summary> Number of columns. </summary>
        public int Columns { get; }
        /// <summary> List of cells contained in the table. </summary>
        public IReadOnlyList<DataTableCell> Cells { get; }
    }
}
