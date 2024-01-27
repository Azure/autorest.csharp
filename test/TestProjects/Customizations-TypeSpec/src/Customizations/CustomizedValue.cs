// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CustomizationsInTsp.Models
{
    /// <summary>
    /// A simple self-created class to represent a union type
    /// </summary>
    public partial class CustomizedValue
    {
        private readonly object _value;

        /// <summary>
        /// Construct a value from string
        /// </summary>
        /// <param name="value"></param>
        public CustomizedValue(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Construct a value from int
        /// </summary>
        /// <param name="value"></param>
        public CustomizedValue(int value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets if the value is string
        /// </summary>
        public bool IsString => _value is string;

        /// <summary>
        /// Gets if the value is int
        /// </summary>
        public bool IsInt => _value is int;

        /// <summary>
        /// Gets the string value, returns null if the containing value is not string
        /// </summary>
        public string StringValue => _value as string;

        /// <summary>
        /// Gets the int value, returns default value (0) if the containing value is not int
        /// </summary>
        public int IntValue => _value is int ? (int)_value : default;
    }
}
