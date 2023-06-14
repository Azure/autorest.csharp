// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the size of the virtual machine. For more information about virtual machine sizes, see [Sizes for virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-sizes?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; The available VM sizes depend on region and availability set. For a list of available sizes use these APIs:  &lt;br&gt;&lt;br&gt; [List all available virtual machine sizes in an availability set](https://docs.microsoft.com/rest/api/compute/availabilitysets/listavailablesizes) &lt;br&gt;&lt;br&gt; [List all available virtual machine sizes in a region](https://docs.microsoft.com/rest/api/compute/virtualmachinesizes/list) &lt;br&gt;&lt;br&gt; [List all available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/listavailablesizes)
    /// Serialized Name: VirtualMachineSizeTypes
    /// </summary>
    public readonly partial struct VirtualMachineSizeType : IEquatable<VirtualMachineSizeType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineSizeType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VirtualMachineSizeType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BasicA0Value = "Basic_A0";
        private const string BasicA1Value = "Basic_A1";
        private const string BasicA2Value = "Basic_A2";
        private const string BasicA3Value = "Basic_A3";
        private const string BasicA4Value = "Basic_A4";
        private const string StandardA0Value = "Standard_A0";
        private const string StandardA1Value = "Standard_A1";
        private const string StandardA2Value = "Standard_A2";
        private const string StandardA3Value = "Standard_A3";
        private const string StandardA4Value = "Standard_A4";
        private const string StandardA5Value = "Standard_A5";
        private const string StandardA6Value = "Standard_A6";
        private const string StandardA7Value = "Standard_A7";
        private const string StandardA8Value = "Standard_A8";
        private const string StandardA9Value = "Standard_A9";
        private const string StandardA10Value = "Standard_A10";
        private const string StandardA11Value = "Standard_A11";
        private const string StandardA1V2Value = "Standard_A1_v2";
        private const string StandardA2V2Value = "Standard_A2_v2";
        private const string StandardA4V2Value = "Standard_A4_v2";
        private const string StandardA8V2Value = "Standard_A8_v2";
        private const string StandardA2MV2Value = "Standard_A2m_v2";
        private const string StandardA4MV2Value = "Standard_A4m_v2";
        private const string StandardA8MV2Value = "Standard_A8m_v2";
        private const string StandardB1SValue = "Standard_B1s";
        private const string StandardB1MsValue = "Standard_B1ms";
        private const string StandardB2SValue = "Standard_B2s";
        private const string StandardB2MsValue = "Standard_B2ms";
        private const string StandardB4MsValue = "Standard_B4ms";
        private const string StandardB8MsValue = "Standard_B8ms";
        private const string StandardD1Value = "Standard_D1";
        private const string StandardD2Value = "Standard_D2";
        private const string StandardD3Value = "Standard_D3";
        private const string StandardD4Value = "Standard_D4";
        private const string StandardD11Value = "Standard_D11";
        private const string StandardD12Value = "Standard_D12";
        private const string StandardD13Value = "Standard_D13";
        private const string StandardD14Value = "Standard_D14";
        private const string StandardD1V2Value = "Standard_D1_v2";
        private const string StandardD2V2Value = "Standard_D2_v2";
        private const string StandardD3V2Value = "Standard_D3_v2";
        private const string StandardD4V2Value = "Standard_D4_v2";
        private const string StandardD5V2Value = "Standard_D5_v2";
        private const string StandardD2V3Value = "Standard_D2_v3";
        private const string StandardD4V3Value = "Standard_D4_v3";
        private const string StandardD8V3Value = "Standard_D8_v3";
        private const string StandardD16V3Value = "Standard_D16_v3";
        private const string StandardD32V3Value = "Standard_D32_v3";
        private const string StandardD64V3Value = "Standard_D64_v3";
        private const string StandardD2SV3Value = "Standard_D2s_v3";
        private const string StandardD4SV3Value = "Standard_D4s_v3";
        private const string StandardD8SV3Value = "Standard_D8s_v3";
        private const string StandardD16SV3Value = "Standard_D16s_v3";
        private const string StandardD32SV3Value = "Standard_D32s_v3";
        private const string StandardD64SV3Value = "Standard_D64s_v3";
        private const string StandardD11V2Value = "Standard_D11_v2";
        private const string StandardD12V2Value = "Standard_D12_v2";
        private const string StandardD13V2Value = "Standard_D13_v2";
        private const string StandardD14V2Value = "Standard_D14_v2";
        private const string StandardD15V2Value = "Standard_D15_v2";
        private const string StandardDS1Value = "Standard_DS1";
        private const string StandardDS2Value = "Standard_DS2";
        private const string StandardDS3Value = "Standard_DS3";
        private const string StandardDS4Value = "Standard_DS4";
        private const string StandardDS11Value = "Standard_DS11";
        private const string StandardDS12Value = "Standard_DS12";
        private const string StandardDS13Value = "Standard_DS13";
        private const string StandardDS14Value = "Standard_DS14";
        private const string StandardDS1V2Value = "Standard_DS1_v2";
        private const string StandardDS2V2Value = "Standard_DS2_v2";
        private const string StandardDS3V2Value = "Standard_DS3_v2";
        private const string StandardDS4V2Value = "Standard_DS4_v2";
        private const string StandardDS5V2Value = "Standard_DS5_v2";
        private const string StandardDS11V2Value = "Standard_DS11_v2";
        private const string StandardDS12V2Value = "Standard_DS12_v2";
        private const string StandardDS13V2Value = "Standard_DS13_v2";
        private const string StandardDS14V2Value = "Standard_DS14_v2";
        private const string StandardDS15V2Value = "Standard_DS15_v2";
        private const string StandardDS134V2Value = "Standard_DS13-4_v2";
        private const string StandardDS132V2Value = "Standard_DS13-2_v2";
        private const string StandardDS148V2Value = "Standard_DS14-8_v2";
        private const string StandardDS144V2Value = "Standard_DS14-4_v2";
        private const string StandardE2V3Value = "Standard_E2_v3";
        private const string StandardE4V3Value = "Standard_E4_v3";
        private const string StandardE8V3Value = "Standard_E8_v3";
        private const string StandardE16V3Value = "Standard_E16_v3";
        private const string StandardE32V3Value = "Standard_E32_v3";
        private const string StandardE64V3Value = "Standard_E64_v3";
        private const string StandardE2SV3Value = "Standard_E2s_v3";
        private const string StandardE4SV3Value = "Standard_E4s_v3";
        private const string StandardE8SV3Value = "Standard_E8s_v3";
        private const string StandardE16SV3Value = "Standard_E16s_v3";
        private const string StandardE32SV3Value = "Standard_E32s_v3";
        private const string StandardE64SV3Value = "Standard_E64s_v3";
        private const string StandardE3216V3Value = "Standard_E32-16_v3";
        private const string StandardE328SV3Value = "Standard_E32-8s_v3";
        private const string StandardE6432SV3Value = "Standard_E64-32s_v3";
        private const string StandardE6416SV3Value = "Standard_E64-16s_v3";
        private const string StandardF1Value = "Standard_F1";
        private const string StandardF2Value = "Standard_F2";
        private const string StandardF4Value = "Standard_F4";
        private const string StandardF8Value = "Standard_F8";
        private const string StandardF16Value = "Standard_F16";
        private const string StandardF1SValue = "Standard_F1s";
        private const string StandardF2SValue = "Standard_F2s";
        private const string StandardF4SValue = "Standard_F4s";
        private const string StandardF8SValue = "Standard_F8s";
        private const string StandardF16SValue = "Standard_F16s";
        private const string StandardF2SV2Value = "Standard_F2s_v2";
        private const string StandardF4SV2Value = "Standard_F4s_v2";
        private const string StandardF8SV2Value = "Standard_F8s_v2";
        private const string StandardF16SV2Value = "Standard_F16s_v2";
        private const string StandardF32SV2Value = "Standard_F32s_v2";
        private const string StandardF64SV2Value = "Standard_F64s_v2";
        private const string StandardF72SV2Value = "Standard_F72s_v2";
        private const string StandardG1Value = "Standard_G1";
        private const string StandardG2Value = "Standard_G2";
        private const string StandardG3Value = "Standard_G3";
        private const string StandardG4Value = "Standard_G4";
        private const string StandardG5Value = "Standard_G5";
        private const string StandardGS1Value = "Standard_GS1";
        private const string StandardGS2Value = "Standard_GS2";
        private const string StandardGS3Value = "Standard_GS3";
        private const string StandardGS4Value = "Standard_GS4";
        private const string StandardGS5Value = "Standard_GS5";
        private const string StandardGS48Value = "Standard_GS4-8";
        private const string StandardGS44Value = "Standard_GS4-4";
        private const string StandardGS516Value = "Standard_GS5-16";
        private const string StandardGS58Value = "Standard_GS5-8";
        private const string StandardH8Value = "Standard_H8";
        private const string StandardH16Value = "Standard_H16";
        private const string StandardH8MValue = "Standard_H8m";
        private const string StandardH16MValue = "Standard_H16m";
        private const string StandardH16RValue = "Standard_H16r";
        private const string StandardH16MrValue = "Standard_H16mr";
        private const string StandardL4SValue = "Standard_L4s";
        private const string StandardL8SValue = "Standard_L8s";
        private const string StandardL16SValue = "Standard_L16s";
        private const string StandardL32SValue = "Standard_L32s";
        private const string StandardM64SValue = "Standard_M64s";
        private const string StandardM64MsValue = "Standard_M64ms";
        private const string StandardM128SValue = "Standard_M128s";
        private const string StandardM128MsValue = "Standard_M128ms";
        private const string StandardM6432MsValue = "Standard_M64-32ms";
        private const string StandardM6416MsValue = "Standard_M64-16ms";
        private const string StandardM12864MsValue = "Standard_M128-64ms";
        private const string StandardM12832MsValue = "Standard_M128-32ms";
        private const string StandardNC6Value = "Standard_NC6";
        private const string StandardNC12Value = "Standard_NC12";
        private const string StandardNC24Value = "Standard_NC24";
        private const string StandardNC24RValue = "Standard_NC24r";
        private const string StandardNC6SV2Value = "Standard_NC6s_v2";
        private const string StandardNC12SV2Value = "Standard_NC12s_v2";
        private const string StandardNC24SV2Value = "Standard_NC24s_v2";
        private const string StandardNC24RsV2Value = "Standard_NC24rs_v2";
        private const string StandardNC6SV3Value = "Standard_NC6s_v3";
        private const string StandardNC12SV3Value = "Standard_NC12s_v3";
        private const string StandardNC24SV3Value = "Standard_NC24s_v3";
        private const string StandardNC24RsV3Value = "Standard_NC24rs_v3";
        private const string StandardND6SValue = "Standard_ND6s";
        private const string StandardND12SValue = "Standard_ND12s";
        private const string StandardND24SValue = "Standard_ND24s";
        private const string StandardND24RsValue = "Standard_ND24rs";
        private const string StandardNV6Value = "Standard_NV6";
        private const string StandardNV12Value = "Standard_NV12";
        private const string StandardNV24Value = "Standard_NV24";

        /// <summary>
        /// Basic_A0
        /// Serialized Name: VirtualMachineSizeTypes.Basic_A0
        /// </summary>
        public static VirtualMachineSizeType BasicA0 { get; } = new VirtualMachineSizeType(BasicA0Value);
        /// <summary>
        /// Basic_A1
        /// Serialized Name: VirtualMachineSizeTypes.Basic_A1
        /// </summary>
        public static VirtualMachineSizeType BasicA1 { get; } = new VirtualMachineSizeType(BasicA1Value);
        /// <summary>
        /// Basic_A2
        /// Serialized Name: VirtualMachineSizeTypes.Basic_A2
        /// </summary>
        public static VirtualMachineSizeType BasicA2 { get; } = new VirtualMachineSizeType(BasicA2Value);
        /// <summary>
        /// Basic_A3
        /// Serialized Name: VirtualMachineSizeTypes.Basic_A3
        /// </summary>
        public static VirtualMachineSizeType BasicA3 { get; } = new VirtualMachineSizeType(BasicA3Value);
        /// <summary>
        /// Basic_A4
        /// Serialized Name: VirtualMachineSizeTypes.Basic_A4
        /// </summary>
        public static VirtualMachineSizeType BasicA4 { get; } = new VirtualMachineSizeType(BasicA4Value);
        /// <summary>
        /// Standard_A0
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A0
        /// </summary>
        public static VirtualMachineSizeType StandardA0 { get; } = new VirtualMachineSizeType(StandardA0Value);
        /// <summary>
        /// Standard_A1
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A1
        /// </summary>
        public static VirtualMachineSizeType StandardA1 { get; } = new VirtualMachineSizeType(StandardA1Value);
        /// <summary>
        /// Standard_A2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A2
        /// </summary>
        public static VirtualMachineSizeType StandardA2 { get; } = new VirtualMachineSizeType(StandardA2Value);
        /// <summary>
        /// Standard_A3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A3
        /// </summary>
        public static VirtualMachineSizeType StandardA3 { get; } = new VirtualMachineSizeType(StandardA3Value);
        /// <summary>
        /// Standard_A4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A4
        /// </summary>
        public static VirtualMachineSizeType StandardA4 { get; } = new VirtualMachineSizeType(StandardA4Value);
        /// <summary>
        /// Standard_A5
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A5
        /// </summary>
        public static VirtualMachineSizeType StandardA5 { get; } = new VirtualMachineSizeType(StandardA5Value);
        /// <summary>
        /// Standard_A6
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A6
        /// </summary>
        public static VirtualMachineSizeType StandardA6 { get; } = new VirtualMachineSizeType(StandardA6Value);
        /// <summary>
        /// Standard_A7
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A7
        /// </summary>
        public static VirtualMachineSizeType StandardA7 { get; } = new VirtualMachineSizeType(StandardA7Value);
        /// <summary>
        /// Standard_A8
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A8
        /// </summary>
        public static VirtualMachineSizeType StandardA8 { get; } = new VirtualMachineSizeType(StandardA8Value);
        /// <summary>
        /// Standard_A9
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A9
        /// </summary>
        public static VirtualMachineSizeType StandardA9 { get; } = new VirtualMachineSizeType(StandardA9Value);
        /// <summary>
        /// Standard_A10
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A10
        /// </summary>
        public static VirtualMachineSizeType StandardA10 { get; } = new VirtualMachineSizeType(StandardA10Value);
        /// <summary>
        /// Standard_A11
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A11
        /// </summary>
        public static VirtualMachineSizeType StandardA11 { get; } = new VirtualMachineSizeType(StandardA11Value);
        /// <summary>
        /// Standard_A1_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A1_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA1V2 { get; } = new VirtualMachineSizeType(StandardA1V2Value);
        /// <summary>
        /// Standard_A2_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A2_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA2V2 { get; } = new VirtualMachineSizeType(StandardA2V2Value);
        /// <summary>
        /// Standard_A4_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A4_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA4V2 { get; } = new VirtualMachineSizeType(StandardA4V2Value);
        /// <summary>
        /// Standard_A8_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A8_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA8V2 { get; } = new VirtualMachineSizeType(StandardA8V2Value);
        /// <summary>
        /// Standard_A2m_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A2m_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA2MV2 { get; } = new VirtualMachineSizeType(StandardA2MV2Value);
        /// <summary>
        /// Standard_A4m_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A4m_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA4MV2 { get; } = new VirtualMachineSizeType(StandardA4MV2Value);
        /// <summary>
        /// Standard_A8m_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_A8m_v2
        /// </summary>
        public static VirtualMachineSizeType StandardA8MV2 { get; } = new VirtualMachineSizeType(StandardA8MV2Value);
        /// <summary>
        /// Standard_B1s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_B1s
        /// </summary>
        public static VirtualMachineSizeType StandardB1S { get; } = new VirtualMachineSizeType(StandardB1SValue);
        /// <summary>
        /// Standard_B1ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_B1ms
        /// </summary>
        public static VirtualMachineSizeType StandardB1Ms { get; } = new VirtualMachineSizeType(StandardB1MsValue);
        /// <summary>
        /// Standard_B2s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_B2s
        /// </summary>
        public static VirtualMachineSizeType StandardB2S { get; } = new VirtualMachineSizeType(StandardB2SValue);
        /// <summary>
        /// Standard_B2ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_B2ms
        /// </summary>
        public static VirtualMachineSizeType StandardB2Ms { get; } = new VirtualMachineSizeType(StandardB2MsValue);
        /// <summary>
        /// Standard_B4ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_B4ms
        /// </summary>
        public static VirtualMachineSizeType StandardB4Ms { get; } = new VirtualMachineSizeType(StandardB4MsValue);
        /// <summary>
        /// Standard_B8ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_B8ms
        /// </summary>
        public static VirtualMachineSizeType StandardB8Ms { get; } = new VirtualMachineSizeType(StandardB8MsValue);
        /// <summary>
        /// Standard_D1
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D1
        /// </summary>
        public static VirtualMachineSizeType StandardD1 { get; } = new VirtualMachineSizeType(StandardD1Value);
        /// <summary>
        /// Standard_D2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D2
        /// </summary>
        public static VirtualMachineSizeType StandardD2 { get; } = new VirtualMachineSizeType(StandardD2Value);
        /// <summary>
        /// Standard_D3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D3
        /// </summary>
        public static VirtualMachineSizeType StandardD3 { get; } = new VirtualMachineSizeType(StandardD3Value);
        /// <summary>
        /// Standard_D4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D4
        /// </summary>
        public static VirtualMachineSizeType StandardD4 { get; } = new VirtualMachineSizeType(StandardD4Value);
        /// <summary>
        /// Standard_D11
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D11
        /// </summary>
        public static VirtualMachineSizeType StandardD11 { get; } = new VirtualMachineSizeType(StandardD11Value);
        /// <summary>
        /// Standard_D12
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D12
        /// </summary>
        public static VirtualMachineSizeType StandardD12 { get; } = new VirtualMachineSizeType(StandardD12Value);
        /// <summary>
        /// Standard_D13
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D13
        /// </summary>
        public static VirtualMachineSizeType StandardD13 { get; } = new VirtualMachineSizeType(StandardD13Value);
        /// <summary>
        /// Standard_D14
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D14
        /// </summary>
        public static VirtualMachineSizeType StandardD14 { get; } = new VirtualMachineSizeType(StandardD14Value);
        /// <summary>
        /// Standard_D1_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D1_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD1V2 { get; } = new VirtualMachineSizeType(StandardD1V2Value);
        /// <summary>
        /// Standard_D2_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D2_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD2V2 { get; } = new VirtualMachineSizeType(StandardD2V2Value);
        /// <summary>
        /// Standard_D3_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D3_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD3V2 { get; } = new VirtualMachineSizeType(StandardD3V2Value);
        /// <summary>
        /// Standard_D4_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D4_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD4V2 { get; } = new VirtualMachineSizeType(StandardD4V2Value);
        /// <summary>
        /// Standard_D5_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D5_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD5V2 { get; } = new VirtualMachineSizeType(StandardD5V2Value);
        /// <summary>
        /// Standard_D2_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D2_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD2V3 { get; } = new VirtualMachineSizeType(StandardD2V3Value);
        /// <summary>
        /// Standard_D4_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D4_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD4V3 { get; } = new VirtualMachineSizeType(StandardD4V3Value);
        /// <summary>
        /// Standard_D8_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D8_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD8V3 { get; } = new VirtualMachineSizeType(StandardD8V3Value);
        /// <summary>
        /// Standard_D16_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D16_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD16V3 { get; } = new VirtualMachineSizeType(StandardD16V3Value);
        /// <summary>
        /// Standard_D32_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D32_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD32V3 { get; } = new VirtualMachineSizeType(StandardD32V3Value);
        /// <summary>
        /// Standard_D64_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D64_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD64V3 { get; } = new VirtualMachineSizeType(StandardD64V3Value);
        /// <summary>
        /// Standard_D2s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D2s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD2SV3 { get; } = new VirtualMachineSizeType(StandardD2SV3Value);
        /// <summary>
        /// Standard_D4s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D4s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD4SV3 { get; } = new VirtualMachineSizeType(StandardD4SV3Value);
        /// <summary>
        /// Standard_D8s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D8s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD8SV3 { get; } = new VirtualMachineSizeType(StandardD8SV3Value);
        /// <summary>
        /// Standard_D16s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D16s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD16SV3 { get; } = new VirtualMachineSizeType(StandardD16SV3Value);
        /// <summary>
        /// Standard_D32s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D32s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD32SV3 { get; } = new VirtualMachineSizeType(StandardD32SV3Value);
        /// <summary>
        /// Standard_D64s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D64s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardD64SV3 { get; } = new VirtualMachineSizeType(StandardD64SV3Value);
        /// <summary>
        /// Standard_D11_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D11_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD11V2 { get; } = new VirtualMachineSizeType(StandardD11V2Value);
        /// <summary>
        /// Standard_D12_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D12_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD12V2 { get; } = new VirtualMachineSizeType(StandardD12V2Value);
        /// <summary>
        /// Standard_D13_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D13_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD13V2 { get; } = new VirtualMachineSizeType(StandardD13V2Value);
        /// <summary>
        /// Standard_D14_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D14_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD14V2 { get; } = new VirtualMachineSizeType(StandardD14V2Value);
        /// <summary>
        /// Standard_D15_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_D15_v2
        /// </summary>
        public static VirtualMachineSizeType StandardD15V2 { get; } = new VirtualMachineSizeType(StandardD15V2Value);
        /// <summary>
        /// Standard_DS1
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS1
        /// </summary>
        public static VirtualMachineSizeType StandardDS1 { get; } = new VirtualMachineSizeType(StandardDS1Value);
        /// <summary>
        /// Standard_DS2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS2
        /// </summary>
        public static VirtualMachineSizeType StandardDS2 { get; } = new VirtualMachineSizeType(StandardDS2Value);
        /// <summary>
        /// Standard_DS3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS3
        /// </summary>
        public static VirtualMachineSizeType StandardDS3 { get; } = new VirtualMachineSizeType(StandardDS3Value);
        /// <summary>
        /// Standard_DS4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS4
        /// </summary>
        public static VirtualMachineSizeType StandardDS4 { get; } = new VirtualMachineSizeType(StandardDS4Value);
        /// <summary>
        /// Standard_DS11
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS11
        /// </summary>
        public static VirtualMachineSizeType StandardDS11 { get; } = new VirtualMachineSizeType(StandardDS11Value);
        /// <summary>
        /// Standard_DS12
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS12
        /// </summary>
        public static VirtualMachineSizeType StandardDS12 { get; } = new VirtualMachineSizeType(StandardDS12Value);
        /// <summary>
        /// Standard_DS13
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS13
        /// </summary>
        public static VirtualMachineSizeType StandardDS13 { get; } = new VirtualMachineSizeType(StandardDS13Value);
        /// <summary>
        /// Standard_DS14
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS14
        /// </summary>
        public static VirtualMachineSizeType StandardDS14 { get; } = new VirtualMachineSizeType(StandardDS14Value);
        /// <summary>
        /// Standard_DS1_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS1_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS1V2 { get; } = new VirtualMachineSizeType(StandardDS1V2Value);
        /// <summary>
        /// Standard_DS2_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS2_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS2V2 { get; } = new VirtualMachineSizeType(StandardDS2V2Value);
        /// <summary>
        /// Standard_DS3_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS3_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS3V2 { get; } = new VirtualMachineSizeType(StandardDS3V2Value);
        /// <summary>
        /// Standard_DS4_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS4_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS4V2 { get; } = new VirtualMachineSizeType(StandardDS4V2Value);
        /// <summary>
        /// Standard_DS5_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS5_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS5V2 { get; } = new VirtualMachineSizeType(StandardDS5V2Value);
        /// <summary>
        /// Standard_DS11_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS11_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS11V2 { get; } = new VirtualMachineSizeType(StandardDS11V2Value);
        /// <summary>
        /// Standard_DS12_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS12_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS12V2 { get; } = new VirtualMachineSizeType(StandardDS12V2Value);
        /// <summary>
        /// Standard_DS13_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS13_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS13V2 { get; } = new VirtualMachineSizeType(StandardDS13V2Value);
        /// <summary>
        /// Standard_DS14_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS14_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS14V2 { get; } = new VirtualMachineSizeType(StandardDS14V2Value);
        /// <summary>
        /// Standard_DS15_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS15_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS15V2 { get; } = new VirtualMachineSizeType(StandardDS15V2Value);
        /// <summary>
        /// Standard_DS13-4_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS13-4_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS134V2 { get; } = new VirtualMachineSizeType(StandardDS134V2Value);
        /// <summary>
        /// Standard_DS13-2_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS13-2_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS132V2 { get; } = new VirtualMachineSizeType(StandardDS132V2Value);
        /// <summary>
        /// Standard_DS14-8_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS14-8_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS148V2 { get; } = new VirtualMachineSizeType(StandardDS148V2Value);
        /// <summary>
        /// Standard_DS14-4_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_DS14-4_v2
        /// </summary>
        public static VirtualMachineSizeType StandardDS144V2 { get; } = new VirtualMachineSizeType(StandardDS144V2Value);
        /// <summary>
        /// Standard_E2_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E2_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE2V3 { get; } = new VirtualMachineSizeType(StandardE2V3Value);
        /// <summary>
        /// Standard_E4_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E4_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE4V3 { get; } = new VirtualMachineSizeType(StandardE4V3Value);
        /// <summary>
        /// Standard_E8_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E8_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE8V3 { get; } = new VirtualMachineSizeType(StandardE8V3Value);
        /// <summary>
        /// Standard_E16_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E16_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE16V3 { get; } = new VirtualMachineSizeType(StandardE16V3Value);
        /// <summary>
        /// Standard_E32_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E32_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE32V3 { get; } = new VirtualMachineSizeType(StandardE32V3Value);
        /// <summary>
        /// Standard_E64_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E64_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE64V3 { get; } = new VirtualMachineSizeType(StandardE64V3Value);
        /// <summary>
        /// Standard_E2s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E2s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE2SV3 { get; } = new VirtualMachineSizeType(StandardE2SV3Value);
        /// <summary>
        /// Standard_E4s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E4s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE4SV3 { get; } = new VirtualMachineSizeType(StandardE4SV3Value);
        /// <summary>
        /// Standard_E8s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E8s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE8SV3 { get; } = new VirtualMachineSizeType(StandardE8SV3Value);
        /// <summary>
        /// Standard_E16s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E16s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE16SV3 { get; } = new VirtualMachineSizeType(StandardE16SV3Value);
        /// <summary>
        /// Standard_E32s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E32s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE32SV3 { get; } = new VirtualMachineSizeType(StandardE32SV3Value);
        /// <summary>
        /// Standard_E64s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E64s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE64SV3 { get; } = new VirtualMachineSizeType(StandardE64SV3Value);
        /// <summary>
        /// Standard_E32-16_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E32-16_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE3216V3 { get; } = new VirtualMachineSizeType(StandardE3216V3Value);
        /// <summary>
        /// Standard_E32-8s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E32-8s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE328SV3 { get; } = new VirtualMachineSizeType(StandardE328SV3Value);
        /// <summary>
        /// Standard_E64-32s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E64-32s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE6432SV3 { get; } = new VirtualMachineSizeType(StandardE6432SV3Value);
        /// <summary>
        /// Standard_E64-16s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_E64-16s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardE6416SV3 { get; } = new VirtualMachineSizeType(StandardE6416SV3Value);
        /// <summary>
        /// Standard_F1
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F1
        /// </summary>
        public static VirtualMachineSizeType StandardF1 { get; } = new VirtualMachineSizeType(StandardF1Value);
        /// <summary>
        /// Standard_F2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F2
        /// </summary>
        public static VirtualMachineSizeType StandardF2 { get; } = new VirtualMachineSizeType(StandardF2Value);
        /// <summary>
        /// Standard_F4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F4
        /// </summary>
        public static VirtualMachineSizeType StandardF4 { get; } = new VirtualMachineSizeType(StandardF4Value);
        /// <summary>
        /// Standard_F8
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F8
        /// </summary>
        public static VirtualMachineSizeType StandardF8 { get; } = new VirtualMachineSizeType(StandardF8Value);
        /// <summary>
        /// Standard_F16
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F16
        /// </summary>
        public static VirtualMachineSizeType StandardF16 { get; } = new VirtualMachineSizeType(StandardF16Value);
        /// <summary>
        /// Standard_F1s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F1s
        /// </summary>
        public static VirtualMachineSizeType StandardF1S { get; } = new VirtualMachineSizeType(StandardF1SValue);
        /// <summary>
        /// Standard_F2s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F2s
        /// </summary>
        public static VirtualMachineSizeType StandardF2S { get; } = new VirtualMachineSizeType(StandardF2SValue);
        /// <summary>
        /// Standard_F4s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F4s
        /// </summary>
        public static VirtualMachineSizeType StandardF4S { get; } = new VirtualMachineSizeType(StandardF4SValue);
        /// <summary>
        /// Standard_F8s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F8s
        /// </summary>
        public static VirtualMachineSizeType StandardF8S { get; } = new VirtualMachineSizeType(StandardF8SValue);
        /// <summary>
        /// Standard_F16s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F16s
        /// </summary>
        public static VirtualMachineSizeType StandardF16S { get; } = new VirtualMachineSizeType(StandardF16SValue);
        /// <summary>
        /// Standard_F2s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F2s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF2SV2 { get; } = new VirtualMachineSizeType(StandardF2SV2Value);
        /// <summary>
        /// Standard_F4s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F4s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF4SV2 { get; } = new VirtualMachineSizeType(StandardF4SV2Value);
        /// <summary>
        /// Standard_F8s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F8s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF8SV2 { get; } = new VirtualMachineSizeType(StandardF8SV2Value);
        /// <summary>
        /// Standard_F16s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F16s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF16SV2 { get; } = new VirtualMachineSizeType(StandardF16SV2Value);
        /// <summary>
        /// Standard_F32s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F32s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF32SV2 { get; } = new VirtualMachineSizeType(StandardF32SV2Value);
        /// <summary>
        /// Standard_F64s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F64s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF64SV2 { get; } = new VirtualMachineSizeType(StandardF64SV2Value);
        /// <summary>
        /// Standard_F72s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_F72s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardF72SV2 { get; } = new VirtualMachineSizeType(StandardF72SV2Value);
        /// <summary>
        /// Standard_G1
        /// Serialized Name: VirtualMachineSizeTypes.Standard_G1
        /// </summary>
        public static VirtualMachineSizeType StandardG1 { get; } = new VirtualMachineSizeType(StandardG1Value);
        /// <summary>
        /// Standard_G2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_G2
        /// </summary>
        public static VirtualMachineSizeType StandardG2 { get; } = new VirtualMachineSizeType(StandardG2Value);
        /// <summary>
        /// Standard_G3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_G3
        /// </summary>
        public static VirtualMachineSizeType StandardG3 { get; } = new VirtualMachineSizeType(StandardG3Value);
        /// <summary>
        /// Standard_G4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_G4
        /// </summary>
        public static VirtualMachineSizeType StandardG4 { get; } = new VirtualMachineSizeType(StandardG4Value);
        /// <summary>
        /// Standard_G5
        /// Serialized Name: VirtualMachineSizeTypes.Standard_G5
        /// </summary>
        public static VirtualMachineSizeType StandardG5 { get; } = new VirtualMachineSizeType(StandardG5Value);
        /// <summary>
        /// Standard_GS1
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS1
        /// </summary>
        public static VirtualMachineSizeType StandardGS1 { get; } = new VirtualMachineSizeType(StandardGS1Value);
        /// <summary>
        /// Standard_GS2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS2
        /// </summary>
        public static VirtualMachineSizeType StandardGS2 { get; } = new VirtualMachineSizeType(StandardGS2Value);
        /// <summary>
        /// Standard_GS3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS3
        /// </summary>
        public static VirtualMachineSizeType StandardGS3 { get; } = new VirtualMachineSizeType(StandardGS3Value);
        /// <summary>
        /// Standard_GS4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS4
        /// </summary>
        public static VirtualMachineSizeType StandardGS4 { get; } = new VirtualMachineSizeType(StandardGS4Value);
        /// <summary>
        /// Standard_GS5
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS5
        /// </summary>
        public static VirtualMachineSizeType StandardGS5 { get; } = new VirtualMachineSizeType(StandardGS5Value);
        /// <summary>
        /// Standard_GS4-8
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS4-8
        /// </summary>
        public static VirtualMachineSizeType StandardGS48 { get; } = new VirtualMachineSizeType(StandardGS48Value);
        /// <summary>
        /// Standard_GS4-4
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS4-4
        /// </summary>
        public static VirtualMachineSizeType StandardGS44 { get; } = new VirtualMachineSizeType(StandardGS44Value);
        /// <summary>
        /// Standard_GS5-16
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS5-16
        /// </summary>
        public static VirtualMachineSizeType StandardGS516 { get; } = new VirtualMachineSizeType(StandardGS516Value);
        /// <summary>
        /// Standard_GS5-8
        /// Serialized Name: VirtualMachineSizeTypes.Standard_GS5-8
        /// </summary>
        public static VirtualMachineSizeType StandardGS58 { get; } = new VirtualMachineSizeType(StandardGS58Value);
        /// <summary>
        /// Standard_H8
        /// Serialized Name: VirtualMachineSizeTypes.Standard_H8
        /// </summary>
        public static VirtualMachineSizeType StandardH8 { get; } = new VirtualMachineSizeType(StandardH8Value);
        /// <summary>
        /// Standard_H16
        /// Serialized Name: VirtualMachineSizeTypes.Standard_H16
        /// </summary>
        public static VirtualMachineSizeType StandardH16 { get; } = new VirtualMachineSizeType(StandardH16Value);
        /// <summary>
        /// Standard_H8m
        /// Serialized Name: VirtualMachineSizeTypes.Standard_H8m
        /// </summary>
        public static VirtualMachineSizeType StandardH8M { get; } = new VirtualMachineSizeType(StandardH8MValue);
        /// <summary>
        /// Standard_H16m
        /// Serialized Name: VirtualMachineSizeTypes.Standard_H16m
        /// </summary>
        public static VirtualMachineSizeType StandardH16M { get; } = new VirtualMachineSizeType(StandardH16MValue);
        /// <summary>
        /// Standard_H16r
        /// Serialized Name: VirtualMachineSizeTypes.Standard_H16r
        /// </summary>
        public static VirtualMachineSizeType StandardH16R { get; } = new VirtualMachineSizeType(StandardH16RValue);
        /// <summary>
        /// Standard_H16mr
        /// Serialized Name: VirtualMachineSizeTypes.Standard_H16mr
        /// </summary>
        public static VirtualMachineSizeType StandardH16Mr { get; } = new VirtualMachineSizeType(StandardH16MrValue);
        /// <summary>
        /// Standard_L4s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_L4s
        /// </summary>
        public static VirtualMachineSizeType StandardL4S { get; } = new VirtualMachineSizeType(StandardL4SValue);
        /// <summary>
        /// Standard_L8s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_L8s
        /// </summary>
        public static VirtualMachineSizeType StandardL8S { get; } = new VirtualMachineSizeType(StandardL8SValue);
        /// <summary>
        /// Standard_L16s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_L16s
        /// </summary>
        public static VirtualMachineSizeType StandardL16S { get; } = new VirtualMachineSizeType(StandardL16SValue);
        /// <summary>
        /// Standard_L32s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_L32s
        /// </summary>
        public static VirtualMachineSizeType StandardL32S { get; } = new VirtualMachineSizeType(StandardL32SValue);
        /// <summary>
        /// Standard_M64s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M64s
        /// </summary>
        public static VirtualMachineSizeType StandardM64S { get; } = new VirtualMachineSizeType(StandardM64SValue);
        /// <summary>
        /// Standard_M64ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M64ms
        /// </summary>
        public static VirtualMachineSizeType StandardM64Ms { get; } = new VirtualMachineSizeType(StandardM64MsValue);
        /// <summary>
        /// Standard_M128s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M128s
        /// </summary>
        public static VirtualMachineSizeType StandardM128S { get; } = new VirtualMachineSizeType(StandardM128SValue);
        /// <summary>
        /// Standard_M128ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M128ms
        /// </summary>
        public static VirtualMachineSizeType StandardM128Ms { get; } = new VirtualMachineSizeType(StandardM128MsValue);
        /// <summary>
        /// Standard_M64-32ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M64-32ms
        /// </summary>
        public static VirtualMachineSizeType StandardM6432Ms { get; } = new VirtualMachineSizeType(StandardM6432MsValue);
        /// <summary>
        /// Standard_M64-16ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M64-16ms
        /// </summary>
        public static VirtualMachineSizeType StandardM6416Ms { get; } = new VirtualMachineSizeType(StandardM6416MsValue);
        /// <summary>
        /// Standard_M128-64ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M128-64ms
        /// </summary>
        public static VirtualMachineSizeType StandardM12864Ms { get; } = new VirtualMachineSizeType(StandardM12864MsValue);
        /// <summary>
        /// Standard_M128-32ms
        /// Serialized Name: VirtualMachineSizeTypes.Standard_M128-32ms
        /// </summary>
        public static VirtualMachineSizeType StandardM12832Ms { get; } = new VirtualMachineSizeType(StandardM12832MsValue);
        /// <summary>
        /// Standard_NC6
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC6
        /// </summary>
        public static VirtualMachineSizeType StandardNC6 { get; } = new VirtualMachineSizeType(StandardNC6Value);
        /// <summary>
        /// Standard_NC12
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC12
        /// </summary>
        public static VirtualMachineSizeType StandardNC12 { get; } = new VirtualMachineSizeType(StandardNC12Value);
        /// <summary>
        /// Standard_NC24
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC24
        /// </summary>
        public static VirtualMachineSizeType StandardNC24 { get; } = new VirtualMachineSizeType(StandardNC24Value);
        /// <summary>
        /// Standard_NC24r
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC24r
        /// </summary>
        public static VirtualMachineSizeType StandardNC24R { get; } = new VirtualMachineSizeType(StandardNC24RValue);
        /// <summary>
        /// Standard_NC6s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC6s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardNC6SV2 { get; } = new VirtualMachineSizeType(StandardNC6SV2Value);
        /// <summary>
        /// Standard_NC12s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC12s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardNC12SV2 { get; } = new VirtualMachineSizeType(StandardNC12SV2Value);
        /// <summary>
        /// Standard_NC24s_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC24s_v2
        /// </summary>
        public static VirtualMachineSizeType StandardNC24SV2 { get; } = new VirtualMachineSizeType(StandardNC24SV2Value);
        /// <summary>
        /// Standard_NC24rs_v2
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC24rs_v2
        /// </summary>
        public static VirtualMachineSizeType StandardNC24RsV2 { get; } = new VirtualMachineSizeType(StandardNC24RsV2Value);
        /// <summary>
        /// Standard_NC6s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC6s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardNC6SV3 { get; } = new VirtualMachineSizeType(StandardNC6SV3Value);
        /// <summary>
        /// Standard_NC12s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC12s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardNC12SV3 { get; } = new VirtualMachineSizeType(StandardNC12SV3Value);
        /// <summary>
        /// Standard_NC24s_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC24s_v3
        /// </summary>
        public static VirtualMachineSizeType StandardNC24SV3 { get; } = new VirtualMachineSizeType(StandardNC24SV3Value);
        /// <summary>
        /// Standard_NC24rs_v3
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NC24rs_v3
        /// </summary>
        public static VirtualMachineSizeType StandardNC24RsV3 { get; } = new VirtualMachineSizeType(StandardNC24RsV3Value);
        /// <summary>
        /// Standard_ND6s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_ND6s
        /// </summary>
        public static VirtualMachineSizeType StandardND6S { get; } = new VirtualMachineSizeType(StandardND6SValue);
        /// <summary>
        /// Standard_ND12s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_ND12s
        /// </summary>
        public static VirtualMachineSizeType StandardND12S { get; } = new VirtualMachineSizeType(StandardND12SValue);
        /// <summary>
        /// Standard_ND24s
        /// Serialized Name: VirtualMachineSizeTypes.Standard_ND24s
        /// </summary>
        public static VirtualMachineSizeType StandardND24S { get; } = new VirtualMachineSizeType(StandardND24SValue);
        /// <summary>
        /// Standard_ND24rs
        /// Serialized Name: VirtualMachineSizeTypes.Standard_ND24rs
        /// </summary>
        public static VirtualMachineSizeType StandardND24Rs { get; } = new VirtualMachineSizeType(StandardND24RsValue);
        /// <summary>
        /// Standard_NV6
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NV6
        /// </summary>
        public static VirtualMachineSizeType StandardNV6 { get; } = new VirtualMachineSizeType(StandardNV6Value);
        /// <summary>
        /// Standard_NV12
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NV12
        /// </summary>
        public static VirtualMachineSizeType StandardNV12 { get; } = new VirtualMachineSizeType(StandardNV12Value);
        /// <summary>
        /// Standard_NV24
        /// Serialized Name: VirtualMachineSizeTypes.Standard_NV24
        /// </summary>
        public static VirtualMachineSizeType StandardNV24 { get; } = new VirtualMachineSizeType(StandardNV24Value);
        /// <summary> Determines if two <see cref="VirtualMachineSizeType"/> values are the same. </summary>
        public static bool operator ==(VirtualMachineSizeType left, VirtualMachineSizeType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VirtualMachineSizeType"/> values are not the same. </summary>
        public static bool operator !=(VirtualMachineSizeType left, VirtualMachineSizeType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VirtualMachineSizeType"/>. </summary>
        public static implicit operator VirtualMachineSizeType(string value) => new VirtualMachineSizeType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VirtualMachineSizeType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VirtualMachineSizeType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
