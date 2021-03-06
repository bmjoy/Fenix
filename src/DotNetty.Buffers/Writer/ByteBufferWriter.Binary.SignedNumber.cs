﻿namespace DotNetty.Buffers
{
    using System;
    using System.Buffers.Binary;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public ref partial struct ByteBufferWriter
    {
        /// <summary>Writes an Int16 into the <see cref="IByteBuffer"/> of bytes as big endian.</summary>
        public void WriteShort(short value)
        {
            if (BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value);
            }

            GrowAndEnsureIf(Int16ValueLength);
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int16ValueLength);
        }

        /// <summary>Writes an Int16 into the <see cref="IByteBuffer"/> of bytes as little endian.</summary>
        public void WriteShortLE(short value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value);
            }

            GrowAndEnsureIf(Int16ValueLength);
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int16ValueLength);
        }

        public void WriteMedium(int value)
        {
            GrowAndEnsureIf(Int24ValueLength);
            SetMedium(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int24ValueLength);
        }

        public void WriteMediumLE(int value)
        {
            GrowAndEnsureIf(Int24ValueLength);
            SetMediumLE(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int24ValueLength);
        }

        /// <summary>Writes an Int32 into the <see cref="IByteBuffer"/> of bytes as big endian.</summary>
        public void WriteInt(int value)
        {
            if (BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value);
            }

            GrowAndEnsureIf(Int32ValueLength);
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int32ValueLength);
        }

        /// <summary>Writes an Int32 into the <see cref="IByteBuffer"/> of bytes as little endian.</summary>
        public void WriteIntLE(int value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value);
            }

            GrowAndEnsureIf(Int32ValueLength);
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int32ValueLength);
        }

        /// <summary>Writes an Int64 into the <see cref="IByteBuffer"/> of bytes as big endian.</summary>
        public void WriteLong(long value)
        {
            if (BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value);
            }

            GrowAndEnsureIf(Int64ValueLength);
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int64ValueLength);
        }

        /// <summary>Writes an Int64 into the <see cref="IByteBuffer"/> of bytes as little endian.</summary>
        public void WriteLongLE(long value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value);
            }

            GrowAndEnsureIf(Int64ValueLength);
            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(_buffer), value);
            AdvanceCore(Int64ValueLength);
        }
    }
}
