// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the mode of in-guest patching to IaaS virtual machine.&lt;br /&gt;&lt;br /&gt; Possible values are:&lt;br /&gt;&lt;br /&gt; **Manual** - You  control the application of patches to a virtual machine. You do this by applying patches manually inside the VM. In this mode, automatic updates are disabled; the property WindowsConfiguration.enableAutomaticUpdates must be false&lt;br /&gt;&lt;br /&gt; **AutomaticByOS** - The virtual machine will automatically be updated by the OS. The property WindowsConfiguration.enableAutomaticUpdates must be true. &lt;br /&gt;&lt;br /&gt; ** AutomaticByPlatform** - the virtual machine will automatically updated by the platform. The properties provisionVMAgent and WindowsConfiguration.enableAutomaticUpdates must be true
    /// Serialized Name: InGuestPatchMode
    /// </summary>
    public readonly partial struct InGuestPatchMode : IEquatable<InGuestPatchMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InGuestPatchMode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InGuestPatchMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ManualValue = "Manual";
        private const string AutomaticByOSValue = "AutomaticByOS";
        private const string AutomaticByPlatformValue = "AutomaticByPlatform";

        /// <summary>
        /// Manual
        /// Serialized Name: InGuestPatchMode.Manual
        /// </summary>
        public static InGuestPatchMode Manual { get; } = new InGuestPatchMode(ManualValue);
        /// <summary>
        /// AutomaticByOS
        /// Serialized Name: InGuestPatchMode.AutomaticByOS
        /// </summary>
        public static InGuestPatchMode AutomaticByOS { get; } = new InGuestPatchMode(AutomaticByOSValue);
        /// <summary>
        /// AutomaticByPlatform
        /// Serialized Name: InGuestPatchMode.AutomaticByPlatform
        /// </summary>
        public static InGuestPatchMode AutomaticByPlatform { get; } = new InGuestPatchMode(AutomaticByPlatformValue);
        /// <summary> Determines if two <see cref="InGuestPatchMode"/> values are the same. </summary>
        public static bool operator ==(InGuestPatchMode left, InGuestPatchMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InGuestPatchMode"/> values are not the same. </summary>
        public static bool operator !=(InGuestPatchMode left, InGuestPatchMode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InGuestPatchMode"/>. </summary>
        public static implicit operator InGuestPatchMode(string value) => new InGuestPatchMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InGuestPatchMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InGuestPatchMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
