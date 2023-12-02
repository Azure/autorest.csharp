// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MultipleInputFiles.Models
{
    /// <summary> . </summary>
    public partial class TestModel
    {
        /// <summary> Initializes a new instance of <see cref="TestModel"/>. </summary>
        public TestModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TestModel"/>. </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        internal TestModel(string code, string status)
        {
            Code = code;
            Status = status;
        }

        /// <summary> Gets or sets the code. </summary>
        public string Code { get; set; }
        /// <summary> Gets or sets the status. </summary>
        public string Status { get; set; }
    }
}
