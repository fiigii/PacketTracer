// =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
//
// AVX2.cs
//
// A class that implements intrinsic functions to provide access to Intel AVX2 instructions.
//
// =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+

using System;
using System.Runtime.CompilerServices.Intrinsics;

namespace System.Runtime.CompilerServices.Intrinsics.Intel
{
    /// <summary>
    /// Provides access to Intel AVX2 hardware instructions via intrinsics
    /// </summary>
    /// <para>
    /// AVX2 class provides access to 256-bit SIMD instructions
    /// </para>

    public static class AVX2
    {
        // __m256i _mm256_abs_epi8 (__m256i a)
        public static Vector256<byte> Abs(Vector256<sbyte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_abs_epi16 (__m256i a)
        public static Vector256<ushort> Abs(Vector256<short> value) { throw new NotImplementedException(); }
        // __m256i _mm256_abs_epi32 (__m256i a)
        public static Vector256<uint> Abs(Vector256<int> value) { throw new NotImplementedException(); }

        // __m256i _mm256_add_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> Add(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi8 (__m256i a, __m256i b)
        public static Vector256<byte> Add(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi16 (__m256i a, __m256i b)
        public static Vector256<short> Add(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi16 (__m256i a, __m256i b)
        public static Vector256<ushort> Add(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi32 (__m256i a, __m256i b)
        public static Vector256<int> Add(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi32 (__m256i a, __m256i b)
        public static Vector256<uint> Add(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi64 (__m256i a, __m256i b)
        public static Vector256<long> Add(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_add_epi64 (__m256i a, __m256i b)
        public static Vector256<ulong> Add(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }

        // __m256i _mm256_adds_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> AddSaturation(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_adds_epu8 (__m256i a, __m256i b)
        public static Vector256<byte> AddSaturation(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_adds_epi16 (__m256i a, __m256i b)
        public static Vector256<short> AddSaturation(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_adds_epu16 (__m256i a, __m256i b)
        public static Vector256<ushort> AddSaturation(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }

        // __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
        private static Vector256<sbyte> AlignRight(Vector256<sbyte> left, Vector256<sbyte> right, byte mask) { throw new NotImplementedException(); }
        public static AlignRightVector256Delegate GetAlignRightVector256Sbyte(byte mask)
        {
            return (left, right) => AlignRight(left, right, mask);
        }

        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<sbyte> And(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<byte> And(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<short> And(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<ushort> And(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<int> And(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<uint> And(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<long> And(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_and_si256 (__m256i a, __m256i b)
        public static Vector256<ulong> And(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }

        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<sbyte> AndNot(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<byte> AndNot(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<short> AndNot(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<ushort> AndNot(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<int> AndNot(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<uint> AndNot(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<long> AndNot(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_andnot_si256 (__m256i a, __m256i b)
        public static Vector256<ulong> AndNot(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }

        // __m256i _mm256_avg_epu8 (__m256i a, __m256i b)
        public static Vector256<byte> Average(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_avg_epu16 (__m256i a, __m256i b)
        public static Vector256<ushort> Average(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }

        // __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
        private static Vector128<int> Blend(Vector128<int> left, Vector128<int> right, byte control) { throw new NotImplementedException(); }
        public static BlendVector128Delegate<int> GetBlendVector128Short(byte control)
        {
            return (left, right) => Blend(left, right, control);
        }
        // __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
        private static Vector128<uint> Blend(Vector128<uint> left, Vector128<uint> right, byte control) { throw new NotImplementedException(); }
        public static BlendVector128Delegate<uint> GetBlendVector128Ushort(byte control)
        {
            return (left, right) => Blend(left, right, control);
        }
        // __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
        private static Vector256<short> Blend(Vector256<short> left, Vector256<short> right, byte control) { throw new NotImplementedException(); }
        public static BlendVector256Delegate<short> GetBlendVector256Short(byte control)
        {
            return (left, right) => Blend(left, right, control);
        }
        // __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
        private static Vector256<ushort> Blend(Vector256<ushort> left, Vector256<ushort> right, byte control) { throw new NotImplementedException(); }
        public static BlendVector256Delegate<ushort> GetBlendVector256Ushort(byte control)
        {
            return (left, right) => Blend(left, right, control);
        }
        // __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
        private static Vector256<int> Blend(Vector256<int> left, Vector256<int> right, byte control) { throw new NotImplementedException(); }
        public static BlendVector256Delegate<int> GetBlendVector256Int(byte control)
        {
            return (left, right) => Blend(left, right, control);
        }
        // __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
        private static Vector256<uint> Blend(Vector256<uint> left, Vector256<uint> right, byte control) { throw new NotImplementedException(); }
        public static BlendVector256Delegate<uint> GetBlendVector256Uint(byte control)
        {
            return (left, right) => Blend(left, right, control);
        }

        // __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
        public static Vector256<sbyte> BlendVariable(Vector256<sbyte> left, Vector256<sbyte> right, Vector256<byte> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
        public static Vector256<byte> BlendVariable(Vector256<byte> left, Vector256<byte> right, Vector256<byte> mask) { throw new NotImplementedException(); }

        // __m128i _mm_broadcastb_epi8 (__m128i a)
        // __m128i _mm_broadcastw_epi16 (__m128i a)
        // __m128i _mm_broadcastd_epi32 (__m128i a)
        // __m128i _mm_broadcastq_epi64 (__m128i a)
        // __m128 _mm_broadcastss_ps (__m128 a)
        // __m128d _mm_broadcastsd_pd (__m128d a)
        public static Vector128<T> BroadcastVector128<T>(Vector128<T> value) where T : struct { throw new NotImplementedException(); }

        // __m256i _mm256_broadcastb_epi8 (__m128i a)
        // __m256i _mm256_broadcastw_epi16 (__m128i a)
        // __m256i _mm256_broadcastd_epi32 (__m128i a)
        // __m256i _mm256_broadcastq_epi64 (__m128i a)
        // __m128 _mm_broadcastss_ps (__m128 a)
        // __m256d _mm256_broadcastsd_pd (__m128d a)
        public static Vector256<T> BroadcastVector256<T>(Vector128<T> value) where T : struct { throw new NotImplementedException(); }

        // __m256i _mm_broadcastsi128_si256 (__m128i a)
        // __m256i _mm256_broadcastsi128_si256 (__m128i a)
        public static unsafe Vector256<sbyte> BroadcastVector256(sbyte* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<byte> BroadcastVector256(byte* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<short> BroadcastVector256(short* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<ushort> BroadcastVector256(ushort* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<int> BroadcastVector256(int* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<uint> BroadcastVector256(uint* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<long> BroadcastVector256(long* mem) { throw new NotImplementedException(); }
        public static unsafe Vector256<ulong> BroadcastVector256(ulong* mem) { throw new NotImplementedException(); }

        // __m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> CompareEqual(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b)
        public static Vector256<byte> CompareEqual(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
        public static Vector256<short> CompareEqual(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
        public static Vector256<ushort> CompareEqual(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi32 (__m256i a, __m256i b)
        public static Vector256<int> CompareEqual(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi32 (__m256i a, __m256i b)
        public static Vector256<uint> CompareEqual(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
        public static Vector256<long> CompareEqual(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
        public static Vector256<ulong> CompareEqual(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }
        
        // __m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> CompareGreaterThan(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpgt_epi16 (__m256i a, __m256i b)
        public static Vector256<short> CompareGreaterThan(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b)
        public static Vector256<int> CompareGreaterThan(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b)
        public static Vector256<long> CompareGreaterThan(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }

        // __m256i _mm256_cvtepi8_epi16 (__m128i a)
        public static Vector256<short> ConvertToVector256Short(Vector256<sbyte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepu8_epi16 (__m128i a)
        public static Vector256<ushort> ConvertToVector256UShort(Vector256<byte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepi8_epi32 (__m128i a)
        public static Vector256<int> ConvertToVector256Int(Vector256<sbyte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepi16_epi32 (__m128i a)
        public static Vector256<int> ConvertToVector256Int(Vector256<short> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepu8_epi32 (__m128i a)
        public static Vector256<uint> ConvertToVector256UInt(Vector256<byte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepu16_epi32 (__m128i a)
        public static Vector256<uint> ConvertToVector256UInt(Vector256<ushort> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepi8_epi64 (__m128i a)
        public static Vector256<long> ConvertToVector256Long(Vector256<sbyte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepi16_epi64 (__m128i a)
        public static Vector256<long> ConvertToVector256Long(Vector256<short> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepi32_epi64 (__m128i a)
        public static Vector256<long> ConvertToVector256Long(Vector256<int> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepu8_epi64 (__m128i a)
        public static Vector256<ulong> ConvertToVector256ULong(Vector256<byte> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepu16_epi64 (__m128i a)
        public static Vector256<ulong> ConvertToVector256ULong(Vector256<ushort> value) { throw new NotImplementedException(); }
        // __m256i _mm256_cvtepu32_epi64 (__m128i a)
        public static Vector256<ulong> ConvertToVector256ULong(Vector256<uint> value) { throw new NotImplementedException(); }

        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<sbyte> ExtractVector128(Vector256<sbyte> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<sbyte> GetExtractVector128Sbyte(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<byte> ExtractVector128(Vector256<byte> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<byte> GetExtractVector128Byte(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<short> ExtractVector128(Vector256<short> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<short> GetExtractVector128Short(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<ushort> ExtractVector128(Vector256<ushort> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<ushort> GetExtractVector128Ushort(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<int> ExtractVector128(Vector256<int> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<int> GetExtractVector128Int(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<uint> ExtractVector128(Vector256<uint> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<uint> GetExtractVector128Uint(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<long> ExtractVector128(Vector256<long> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<long> GetExtractVector128Long(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }
        // __m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
        private static Vector128<ulong> ExtractVector128(Vector256<ulong> value, byte index) { throw new NotImplementedException(); }
        public static Extract128Vector256Delegate<ulong> GetExtractVector128Ulong(byte index)
        {
            return (value) => ExtractVector128(value, index);
        }

        // __m128i _mm_i32gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<int> GatherVector128(int* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector128IntDelegate GetGatherVector128IntIndexVector128Int(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i32gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<uint> GatherVector128(uint* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector128UintDelegate GetGatherVector128IntIndexVector128Uint(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<long> GatherVector128(long* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector128LongDelegate GetGatherVector128IntIndexVector128Long(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<ulong> GatherVector128(ulong* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector128UlongDelegate GetGatherVector128IntIndexVector128Ulong(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128 _mm_i32gather_ps (float const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<float> GatherVector128(float* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector128FloatDelegate GetGatherVector128IntIndexVector128Float(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128d _mm_i32gather_pd (double const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<double> GatherVector128(double* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector128DoubleDelegate GetGatherVector128IntIndexVector128Double(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i64gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<int> GatherVector128(int* start, Vector128<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128LongIndexVector128IntDelegate GetGatherVector128LongIndexVector128Int(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i64gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<uint> GatherVector128(uint* start, Vector128<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128LongIndexVector128UintDelegate GetGatherVector128LongIndexVector128Uint(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<long> GatherVector128(long* start, Vector128<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128LongIndexVector128LongDelegate GetGatherVector128LongIndexVector128Long(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<ulong> GatherVector128(ulong* start, Vector128<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128LongIndexVector128UlongDelegate GetGatherVector128LongIndexVector128Ulong(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128 _mm_i64gather_ps (float const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<float> GatherVector128(float* start, Vector128<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128LongIndexVector128FloatDelegate GetGatherVector128LongIndexVector128Float(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128d _mm_i64gather_pd (double const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector128<double> GatherVector128(double* start, Vector128<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128LongIndexVector128DoubleDelegate GetGatherVector128LongIndexVector128Double(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector256<int> GatherVector256(int* start, Vector256<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256IntIndexVector256IntDelegate GetGatherVector256IntIndexVector256Int(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector256<uint> GatherVector256(uint* start, Vector256<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256IntIndexVector256UintDelegate GetGatherVector256IntIndexVector256Uint(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector256<long> GatherVector256(long* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector256LongDelegate GetGatherVector128IntIndexVector256Long(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector256<ulong> GatherVector256(ulong* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector256UlongDelegate GetGatherVector128IntIndexVector256Ulong(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m256 _mm256_i32gather_ps (float const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector256<float> GatherVector256(float* start, Vector256<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256IntIndexVector256FloatDelegate GetGatherVector256IntIndexVector256Float(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m256d _mm256_i32gather_pd (double const* base_addr, __m128i vindex, const int scale)
        private static unsafe Vector256<double> GatherVector256(double* start, Vector128<int> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector128IntIndexVector256DoubleDelegate GetGatherVector128IntIndexVector256Double(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m128i _mm256_i64gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector128<int> GatherVector128(int* start, Vector256<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256LongIndexVector128IntDelegate GetGatherVector256LongIndexVector128Int(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m128i _mm256_i64gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector128<uint> GatherVector128(uint* start, Vector256<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256LongIndexVector128UintDelegate GetGatherVector256LongIndexVector256Uint(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector256<long> GatherVector256(long* start, Vector256<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256LongIndexVector256LongDelegate GetGatherVector256LongIndexVector256Long(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector256<ulong> GatherVector256(ulong* start, Vector256<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256LongIndexVector256UlongDelegate GetGatherVector256LongIndexVector256Ulong(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }
        // __m128 _mm256_i64gather_ps (float const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector128<float> GatherVector128(float* start, Vector256<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256LongIndexVector128FloatDelegate GetGatherVector256LongIndexVector128Float(byte scale)
        {
            return (start, index) => GatherVector128(start, index, scale);
        }
        // __m256d _mm256_i64gather_pd (double const* base_addr, __m256i vindex, const int scale)
        private static unsafe Vector256<double> GatherVector256(double* start, Vector256<long> index, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherVector256LongIndexVector256DoubleDelegate GetGatherVector256LongIndexVector256Double(byte scale)
        {
            return (start, index) => GatherVector256(start, index, scale);
        }

        // __m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<int> GatherMaskVector128(Vector128<int> source, int* start, Vector128<int> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector128IntDelegate GetGatherMaskVector128IntIndexVector128Int(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<uint> GatherMaskVector128(Vector128<uint> source, uint* start, Vector128<int> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector128UintDelegate GetGatherMaskVector128IntIndexVector128Uint(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i32gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<long> GatherMaskVector128(Vector128<long> source, long* start, Vector128<int> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector128LongDelegate GetGatherMaskVector128IntIndexVector128Long(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i32gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<ulong> GatherMaskVector128(Vector128<ulong> source, ulong* start, Vector128<int> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector128UlongDelegate GetGatherMaskVector128IntIndexVector128Ulong(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128 _mm_mask_i32gather_ps (__m128 src, float const* base_addr, __m128i vindex, __m128 mask, const int scale)
        private static unsafe Vector128<float> GatherMaskVector128(Vector128<float> source, float* start, Vector128<int> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector128FloatDelegate GetGatherMaskVector128IntIndexVector128Float(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128d _mm_mask_i32gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
        private static unsafe Vector128<double> GatherMaskVector128(Vector128<double> source, double* start, Vector128<int> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector128DoubleDelegate GetGatherMaskVector128IntIndexVector128Double(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<int> GatherMaskVector128(Vector128<int> source, int* start, Vector128<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128LongIndexVector128IntDelegate GetGatherMaskVector128LongIndexVector128Int(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<uint> GatherMaskVector128(Vector128<uint> source, uint* start, Vector128<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128LongIndexVector128UintDelegate GetGatherMaskVector128LongIndexVector128Uint(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i64gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<long> GatherMaskVector128(Vector128<long> source, long* start, Vector128<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128LongIndexVector128LongDelegate GetGatherMaskVector128LongIndexVector128Long(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm_mask_i64gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<ulong> GatherMaskVector128(Vector128<ulong> source, ulong* start, Vector128<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128LongIndexVector128UlongDelegate GetGatherMaskVector128LongIndexVector128Ulong(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128 _mm_mask_i64gather_ps (__m128 src, float const* base_addr, __m128i vindex, __m128 mask, const int scale)
        private static unsafe Vector128<float> GatherMaskVector128(Vector128<float> source, float* start, Vector128<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128LongIndexVector128FloatDelegate GetGatherMaskVector128LongIndexVector128Float(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128d _mm_mask_i64gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
        private static unsafe Vector128<double> GatherMaskVector128(Vector128<double> source, double* start, Vector128<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128LongIndexVector128DoubleDelegate GetGatherMaskVector128LongIndexVector128Double(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }       
        // __m256i _mm256_mask_i32gather_epi32 (__m256i src, int const* base_addr, __m256i vindex, __m256i mask, const int scale)
        private static unsafe Vector256<int> GatherMaskVector256(Vector256<int> source, int* start, Vector256<int> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256IntIndexVector256IntDelegate GetGatherMaskVector256IntIndexVector256Int(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m256i _mm256_mask_i32gather_epi32 (__m256i src, int const* base_addr, __m256i vindex, __m256i mask, const int scale)
        private static unsafe Vector256<uint> GatherMaskVector256(Vector256<uint> source, uint* start, Vector256<int> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256IntIndexVector256UintDelegate GetGatherMaskVector256IntIndexVector256Uint(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m256i _mm256_mask_i32gather_epi64 (__m256i src, __int64 const* base_addr, __m128i vindex, __m256i mask, const int scale)
        private static unsafe Vector256<long> GatherMaskVector256(Vector256<long> source, long* start, Vector128<int> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector256LongDelegate GetGatherMaskVector128IntIndexVector256Long(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m256i _mm256_mask_i32gather_epi64 (__m256i src, __int64 const* base_addr, __m128i vindex, __m256i mask, const int scale)
        private static unsafe Vector256<ulong> GatherMaskVector256(Vector256<ulong> source, ulong* start, Vector128<int> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector256UlongDelegate GetGatherMaskVector128IntIndexVector256Ulong(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m256 _mm256_mask_i32gather_ps (__m256 src, float const* base_addr, __m256i vindex, __m256 mask, const int scale)
        private static unsafe Vector256<float> GatherMaskVector256(Vector256<float> source, float* start, Vector256<int> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256IntIndexVector256FloatDelegate GetGatherMaskVector256IntIndexVector256Float(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m256d _mm256_mask_i32gather_pd (__m256d src, double const* base_addr, __m128i vindex, __m256d mask, const int scale)
        private static unsafe Vector256<double> GatherMaskVector256(Vector256<double> source, double* start, Vector128<int> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector128IntIndexVector256DoubleDelegate GetGatherMaskVector128IntIndexVector256Double(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<int> GatherMaskVector128(Vector128<int> source, int* start, Vector256<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256LongIndexVector128IntDelegate GetGatherMaskVector256LongIndexVector128Int(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale)
        private static unsafe Vector128<uint> GatherMaskVector128(Vector128<uint> source, uint* start, Vector256<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256LongIndexVector128UintDelegate GetGatherMaskVector256LongIndexVector128Uint(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m256i _mm256_mask_i64gather_epi64 (__m256i src, __int64 const* base_addr, __m256i vindex, __m256i mask, const int scale)
        private static unsafe Vector256<long> GatherMask(Vector256<long> source, long* start, Vector256<long> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256LongIndexVector256LongDelegate GetGatherMaskVector256LongIndexVector256Long(byte scale)
        {
            return (source, start, index, mask) => GatherMask(source, start, index, mask, scale);
        }
        // __m256i _mm256_mask_i64gather_epi64 (__m256i src, __int64 const* base_addr, __m256i vindex, __m256i mask, const int scale)
        private static unsafe Vector256<ulong> GatherMaskVector256(Vector256<ulong> source, ulong* start, Vector256<long> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256LongIndexVector256UlongDelegate GetGatherMaskVector256LongIndexVector256Ulong(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }
        // __m128 _mm256_mask_i64gather_ps (__m128 src, float const* base_addr, __m256i vindex, __m128 mask, const int scale)
        private static unsafe Vector128<float> GatherMaskVector128(Vector128<float> source, float* start, Vector256<long> index, Vector128<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256LongIndexVector128FloatDelegate GetGatherMaskVector256LongIndexVector128Float(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector128(source, start, index, mask, scale);
        }
        // __m256d _mm256_mask_i64gather_pd (__m256d src, double const* base_addr, __m256i vindex, __m256d mask, const int scale)
        private static unsafe Vector256<double> GatherMaskVector256(Vector256<double> source, double* start, Vector256<long> index, Vector256<byte> mask, byte scale) { throw new NotImplementedException(); }
        public static unsafe GatherMaskVector256LongIndexVector256DoubleDelegate GetGatherMaskVector256LongIndexVector256Double(byte scale)
        {
            return (source, start, index, mask) => GatherMaskVector256(source, start, index, mask, scale);
        }

        // __m256i _mm256_hadd_epi16 (__m256i a, __m256i b)
        public static Vector256<short> HorizontalAdd(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_hadd_epi32 (__m256i a, __m256i b)
        public static Vector256<int> HorizontalAdd(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }

        // __m256i _mm256_hadds_epi16 (__m256i a, __m256i b)
        public static Vector256<short> HorizontalAddSaturation(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }

        // __m256i _mm256_hsub_epi16 (__m256i a, __m256i b)
        public static Vector256<short> HorizontalSubtract(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_hsub_epi32 (__m256i a, __m256i b)
        public static Vector256<int> HorizontalSubtract(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }

        // __m256i _mm256_hsubs_epi16 (__m256i a, __m256i b)
        public static Vector256<short> HorizontalSubtractSaturation(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }

        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<sbyte> Insert(Vector256<sbyte> value, Vector128<sbyte> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<sbyte> GetInsertVector128Sbyte(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<byte> Insert(Vector256<byte> value, Vector128<byte> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<byte> GetInsertVector128Byte(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<short> Insert(Vector256<short> value, Vector128<short> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<short> GetInsertVector128Short(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<ushort> Insert(Vector256<ushort> value, Vector128<ushort> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<ushort> GetInsertVector128Ushort(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<int> Insert(Vector256<int> value, Vector128<int> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<int> GetInsertVector128Int(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<uint> Insert(Vector256<uint> value, Vector128<uint> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<uint> GetInsertVector128Uint(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<long> Insert(Vector256<long> value, Vector128<long> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<long> GetInsertVector128Long(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }
        // __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
        private static Vector256<ulong> Insert(Vector256<ulong> value, Vector128<ulong> data, byte index) { throw new NotImplementedException(); }
        public static Insert128Vector256Delegate<ulong> GetInsertVector128Ulong(byte index)
        {
            return (value, data) => Insert(value, data, index);
        }

        // __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask)
        public static unsafe Vector128<int> MaskLoad(int* mem, Vector128<uint> mask) { throw new NotImplementedException(); }
        // __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask)
        public static unsafe Vector128<uint> MaskLoad(uint* mem, Vector128<uint> mask) { throw new NotImplementedException(); }
        // __m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask)
        public static unsafe Vector128<long> MaskLoad(long* mem, Vector128<ulong> mask) { throw new NotImplementedException(); }
        // __m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask)
        public static unsafe Vector128<ulong> MaskLoad(ulong* mem, Vector128<ulong> mask) { throw new NotImplementedException(); }

        // __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask)
        public static unsafe Vector256<int> MaskLoad(int* mem, Vector256<uint> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask)
        public static unsafe Vector256<int> MaskLoad(uint* mem, Vector256<uint> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask)
        public static unsafe Vector256<long> MaskLoad(long* mem, Vector256<ulong> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask)
        public static unsafe Vector256<long> MaskLoad(ulong* mem, Vector256<ulong> mask) { throw new NotImplementedException(); }

        // void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a)
        public static unsafe void MaskStore(int* mem, Vector128<uint> mask, Vector128<int> source) { throw new NotImplementedException(); }
        // void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a)
        public static unsafe void MaskStore(uint* mem, Vector128<uint> mask, Vector128<uint> source) { throw new NotImplementedException(); }
        // void _mm_maskstore_epi64 (__int64* mem_addr, __m128i mask, __m128i a)
        public static unsafe void MaskStore(long* mem, Vector128<ulong> mask, Vector128<long> source) { throw new NotImplementedException(); }
        // void _mm_maskstore_epi64 (__int64* mem_addr, __m128i mask, __m128i a)
        public static unsafe void MaskStore(ulong* mem, Vector128<ulong> mask, Vector128<ulong> source) { throw new NotImplementedException(); }

        // void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a)
        public static unsafe void MaskStore(int* mem, Vector256<uint> mask, Vector256<int> source) { throw new NotImplementedException(); }
        // void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a)
        public static unsafe void MaskStore(uint* mem, Vector256<uint> mask, Vector256<uint> source) { throw new NotImplementedException(); }
        // void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a)
        public static unsafe void MaskStore(long* mem, Vector256<ulong> mask, Vector256<long> source) { throw new NotImplementedException(); }
        // void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a)
        public static unsafe void MaskStore(ulong* mem, Vector256<ulong> mask, Vector256<ulong> source) { throw new NotImplementedException(); }

        // __m256i _mm256_madd_epi16 (__m256i a, __m256i b)
        public static Vector256<int> MultiplyAddAdjacent(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }

        // __m256i _mm256_maddubs_epi16 (__m256i a, __m256i b)
        public static Vector256<short> MultiplyAddAdjacent(Vector256<byte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }

        // __m256i _mm256_max_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> Max(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_max_epu8 (__m256i a, __m256i b)
        public static Vector256<byte> Max(Vector256<byte> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_max_epi16 (__m256i a, __m256i b)
        public static Vector256<short> Max(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_max_epu16 (__m256i a, __m256i b)
        public static Vector256<ushort> Max(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_max_epi32 (__m256i a, __m256i b)
        public static Vector256<int> Max(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_max_epu32 (__m256i a, __m256i b)
        public static Vector256<uint> Max(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        
        // __m256i _mm256_min_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> Min(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_min_epu8 (__m256i a, __m256i b)
        public static Vector256<byte> Min(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_min_epi16 (__m256i a, __m256i b)
        public static Vector256<short> Min(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_min_epu16 (__m256i a, __m256i b)
        public static Vector256<ushort> Min(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_min_epi32 (__m256i a, __m256i b)
        public static Vector256<int> Min(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_min_epu32 (__m256i a, __m256i b)
        public static Vector256<uint> Min(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        
        // int _mm256_movemask_epi8 (__m256i a)
        public static int MoveMask(Vector256<sbyte> value) { throw new NotImplementedException(); }
        // int _mm256_movemask_epi8 (__m256i a)
        public static int MoveMask(Vector256<byte> value) { throw new NotImplementedException(); }

        // __m256i _mm256_mpsadbw_epu8 (__m256i a, __m256i b, const int imm8)
        private static Vector256<ushort> MultipleSumAbsoluteDifference(Vector256<byte> left, Vector256<byte> right, byte mask) { throw new NotImplementedException(); }
        public static MultipleSumAbsoluteDifferenceVector256Delegate GetMultipleSumAbsoluteDifferenceVector256(byte mask)
        {
            return (left, right) => MultipleSumAbsoluteDifference(left, right, mask);
        }
        
        // __m256i _mm256_mul_epi32 (__m256i a, __m256i b)
        public static Vector256<long> Multiply(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_mul_epu32 (__m256i a, __m256i b)
        public static Vector256<ulong> Multiply(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }

        // __m256i _mm256_mulhi_epi16 (__m256i a, __m256i b)
        public static Vector256<short> MultiplyHigh(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_mulhi_epu16 (__m256i a, __m256i b)
        public static Vector256<ushort> MultiplyHigh(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }

        // __m256i _mm256_mulhrs_epi16 (__m256i a, __m256i b)
        public static Vector256<short> MultiplyHighRoundScale(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }

        // __m256i _mm256_mullo_epi16 (__m256i a, __m256i b)
        public static Vector256<short> MultiplyLow(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_mullo_epu16 (__m256i a, __m256i b)
        public static Vector256<int> MultiplyLow(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }

        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<sbyte> Or(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<byte> Or(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<short> Or(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<ushort> Or(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<int> Or(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<uint> Or(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<long> Or(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_or_si256 (__m256i a, __m256i b)
        public static Vector256<ulong> Or(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }

        // __m256i _mm256_packs_epi16 (__m256i a, __m256i b)
        public static Vector256<sbyte> PackSignedSaturation(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_packs_epi32 (__m256i a, __m256i b)
        public static Vector256<short> PackSignedSaturation(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_packus_epi16 (__m256i a, __m256i b)
        public static Vector256<byte> PackUnsignedSaturation(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_packus_epi32 (__m256i a, __m256i b)
        public static Vector256<ushort> PackUnsignedSaturation(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }

        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<sbyte> Permute2x128(Vector256<sbyte> left, Vector256<sbyte> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<sbyte> GetPermute2x128Vector256Sbyte(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<byte> Permute2x128(Vector256<byte> left, Vector256<byte> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<byte> GetPermute2x128Vector256Byte(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<short> Permute2x128(Vector256<short> left, Vector256<short> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<short> GetPermute2x128Vector256Short(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<ushort> Permute2x128(Vector256<ushort> left, Vector256<ushort> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<ushort> GetPermute2x128Vector256Ushort(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<int> Permute2x128(Vector256<int> left, Vector256<int> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<int> GetPermute2x128Vector256Int(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<uint> Permute2x128(Vector256<uint> left, Vector256<uint> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<uint> GetPermute2x128Vector256Uint(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<long> Permute2x128(Vector256<long> left, Vector256<long> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<long> GetPermute2x128Vector256Long(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        // __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
        private static Vector256<ulong> Permute2x128(Vector256<ulong> left, Vector256<ulong> right, byte control) { throw new NotImplementedException(); }
        public static Permute2x128Delegate<ulong> GetPermute2x128Vector256Ulong(byte control)
        {
            return (left, right) => Permute2x128(left, right, control);
        }
        
        // __m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
        private static Vector256<long> Permute4x64(Vector256<long> value, byte control) { throw new NotImplementedException(); }
        public static Permute4x64Delegate<long> GetPermute4x64Vector256Long(byte control)
        {
            return (value) => Permute4x64(value, control);
        }
        // __m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
        private static Vector256<ulong> Permute4x64(Vector256<ulong> value, byte control) { throw new NotImplementedException(); }
        public static Permute4x64Delegate<ulong> GetPermute4x64Vector256Ulong(byte control)
        {
            return (value) => Permute4x64(value, control);
        }
        // __m256d _mm256_permute4x64_pd (__m256d a, const int imm8)
        private static Vector256<double> Permute4x64(Vector256<double> value, byte control) { throw new NotImplementedException(); }
        public static Permute4x64Delegate<double> GetPermute4x64Vector256Double(byte control)
        {
            return (value) => Permute4x64(value, control);
        }
        
        // __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
        public static Vector256<int> PermuteVar8x32(Vector256<int> left, Vector256<uint> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
        public static Vector256<uint> PermuteVar8x32(Vector256<uint> left, Vector256<uint> mask) { throw new NotImplementedException(); }
        // __m256 _mm256_permutevar8x32_ps (__m256 a, __m256i idx)
        public static Vector256<float> PermuteVar8x32(Vector256<float> left, Vector256<uint> mask) { throw new NotImplementedException(); }

        // __m256i _mm256_slli_epi16 (__m256i a, int imm8)
        private static Vector256<short> ShiftLeftLogical(Vector256<short> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<short> GetShiftLeftLogicalVector256Short(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m256i _mm256_slli_epi16 (__m256i a, int imm8)
        private static Vector256<ushort> ShiftLeftLogical(Vector256<ushort> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ushort> GetShiftLeftLogicalVector256Ushort(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m256i _mm256_slli_epi32 (__m256i a, int imm8)
        private static Vector256<int> ShiftLeftLogical(Vector256<int> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<int> GetShiftLeftLogicalVector256Int(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m256i _mm256_slli_epi32 (__m256i a, int imm8)
        private static Vector256<uint> ShiftLeftLogical(Vector256<uint> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<uint> GetShiftLeftLogicalVector256Uint(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m256i _mm256_slli_epi64 (__m256i a, int imm8)
        private static Vector256<long> ShiftLeftLogical(Vector256<long> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<long> GetShiftLeftLogicalVector256Long(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m256i _mm256_slli_epi64 (__m256i a, int imm8)
        private static Vector256<ulong> ShiftLeftLogical(Vector256<ulong> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ulong> GetShiftLeftLogicalVector256Ulong(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }

        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<sbyte> ShiftLeftLogical128BitLane(Vector256<sbyte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<sbyte> GetShiftLeftLogical128BitLaneVector256Sbyte(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<byte> ShiftLeftLogical128BitLane(Vector256<byte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<byte> GetShiftLeftLogical128BitLaneVector256Byte(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<short> ShiftLeftLogical128BitLane(Vector256<short> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<short> GetShiftLeftLogical128BitLaneVector256Short(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<ushort> ShiftLeftLogical128BitLane(Vector256<ushort> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ushort> GetShiftLeftLogical128BitLaneVector256Ushort(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<int> ShiftLeftLogical128BitLane(Vector256<int> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<int> GetShiftLeftLogical128BitLaneVector256Int(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<uint> ShiftLeftLogical128BitLane(Vector256<uint> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<uint> GetShiftLeftLogical128BitLaneVector256Uint(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<long> ShiftLeftLogical128BitLane(Vector256<long> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<long> GetShiftLeftLogical128BitLaneVector256Long(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
        private static Vector256<ulong> ShiftLeftLogical128BitLane(Vector256<ulong> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ulong> GetShiftLeftLogical128BitLaneVector256Ulong(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }

        // __m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
        public static Vector256<int> ShiftLeftLogicalVariable(Vector256<int> value, Vector256<uint> count) { throw new NotImplementedException(); }
        // __m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
        public static Vector256<uint> ShiftLeftLogicalVariable(Vector256<uint> value, Vector256<uint> count) { throw new NotImplementedException(); }
        // __m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
        public static Vector256<long> ShiftLeftLogicalVariable(Vector256<long> value, Vector256<ulong> count) { throw new NotImplementedException(); }
        // __m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
        public static Vector256<ulong> ShiftLeftLogicalVariable(Vector256<ulong> value, Vector256<ulong> count) { throw new NotImplementedException(); }
        
        // __m256i _mm256_srai_epi16 (__m256i a, int imm8)
        private static Vector256<short> ShiftRightArithmetic(Vector256<short> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<short> GetShiftRightArithmeticVector256Short(byte count)
        {
            return (value) => ShiftRightArithmetic(value, count);
        }
        // __m256i _mm256_srai_epi32 (__m256i a, int imm8)
        private static Vector256<int> ShiftRightArithmetic(Vector256<int> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<int> GetShiftRightArithmeticVector256Int(byte count)
        {
            return (value) => ShiftRightArithmetic(value, count);
        }
        
        // __m256i _mm256_srav_epi32 (__m256i a, __m256i count)
        public static Vector256<int> ShiftRightArithmeticVariable(Vector256<int> value, Vector256<uint> count) { throw new NotImplementedException(); }

        // __m256i _mm256_srli_epi16 (__m256i a, int imm8)
        private static Vector256<short> ShiftRightLogical(Vector256<short> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<short> GetShiftRightLogicalVector256Short(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m256i _mm256_srli_epi16 (__m256i a, int imm8)
        private static Vector256<ushort> ShiftRightLogical(Vector256<ushort> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ushort> GetShiftRightLogicalVector256Ushort(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m256i _mm256_srli_epi32 (__m256i a, int imm8)
        private static Vector256<int> ShiftRightLogical(Vector256<int> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<int> GetShiftRightLogicalVector256Int(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m256i _mm256_srli_epi32 (__m256i a, int imm8)
        private static Vector256<uint> ShiftRightLogical(Vector256<uint> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<uint> GetShiftRightLogicalVector256Uint(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m256i _mm256_srli_epi64 (__m256i a, int imm8)
        private static Vector256<long> ShiftRightLogical(Vector256<long> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<long> GetShiftRightLogicalVector256Long(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m256i _mm256_srli_epi64 (__m256i a, int imm8)
        private static Vector256<ulong> ShiftRightLogical(Vector256<ulong> value, byte count) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ulong> GetShiftRightLogicalVector256Ulong(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }

        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<sbyte> ShiftRightLogical128BitLane(Vector256<sbyte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<sbyte> GetShiftRightLogical128BitLaneVector256Sbyte(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<byte> ShiftRightLogical128BitLane(Vector256<byte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<byte> GetShiftRightLogical128BitLaneVector256Byte(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<short> ShiftRightLogical128BitLane(Vector256<short> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<short> GetShiftRightLogical128BitLaneVector256Short(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<ushort> ShiftRightLogical128BitLane(Vector256<ushort> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ushort> GetShiftRightLogical128BitLaneVector256Ushort(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<int> ShiftRightLogical128BitLane(Vector256<int> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<int> GetShiftRightLogical128BitLaneVector256Int(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<uint> ShiftRightLogical128BitLane(Vector256<uint> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<uint> GetShiftRightLogical128BitLaneVector256Uint(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<long> ShiftRightLogical128BitLane(Vector256<long> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<long> GetShiftRightLogical128BitLaneVector256Long(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
        private static Vector256<ulong> ShiftRightLogical128BitLane(Vector256<ulong> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector256Delegate<ulong> GetShiftRightLogical128BitLaneVector256Ulong(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        
        // __m256i _mm256_srlv_epi32 (__m256i a, __m256i count)
        public static Vector256<int> ShiftRightLogicalVariable(Vector256<int> value, Vector256<uint> count) { throw new NotImplementedException(); }
        // __m256i _mm256_srlv_epi32 (__m256i a, __m256i count)
        public static Vector256<uint> ShiftRightLogicalVariable(Vector256<uint> value, Vector256<uint> count) { throw new NotImplementedException(); }
        // __m256i _mm256_srlv_epi64 (__m256i a, __m256i count)
        public static Vector256<long> ShiftRightLogicalVariable(Vector256<long> value, Vector256<ulong> count) { throw new NotImplementedException(); }
        // __m256i _mm256_srlv_epi64 (__m256i a, __m256i count)
        public static Vector256<ulong> ShiftRightLogicalVariable(Vector256<ulong> value, Vector256<ulong> count) { throw new NotImplementedException(); }
        
        // __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> Shuffle(Vector256<sbyte> value, Vector256<byte> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
        public static Vector256<byte> Shuffle(Vector256<byte> value, Vector256<byte> mask) { throw new NotImplementedException(); }
        // __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
        private static Vector256<int> Shuffle(Vector256<int> value, byte control) { throw new NotImplementedException(); }
        public static ShuffleVector256Delegate<int> GetShuffleVector256Int(byte control)
        {
            return (value) => Shuffle(value, control);
        }
        // __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
        private static Vector256<uint> Shuffle(Vector256<uint> value, byte control) { throw new NotImplementedException(); }
        public static ShuffleVector256Delegate<uint> GetShuffleVector256Uint(byte control)
        {
            return (value) => Shuffle(value, control);
        }
 
        // __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
        private static Vector256<short> ShuffleHigh(Vector256<short> value, byte control) { throw new NotImplementedException(); }
        public static ShuffleVector256Delegate<short> GetShuffleHighVector256Short(byte control)
        {
            return (value) => ShuffleHigh(value, control);
        }
        // __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
        private static Vector256<ushort> ShuffleHigh(Vector256<ushort> value, byte control) { throw new NotImplementedException(); }
        public static ShuffleVector256Delegate<ushort> GetShuffleHighVector256Ushort(byte control)
        {
            return (value) => ShuffleHigh(value, control);
        }

        // __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
        private static Vector256<short> ShuffleLow(Vector256<short> value, byte control) { throw new NotImplementedException(); }
        public static ShuffleVector256Delegate<short> GetShuffleLowVector256Short(byte control)
        {
            return (value) => ShuffleLow(value, control);
        }
        // __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
        private static Vector256<ushort> ShuffleLow(Vector256<ushort> value, byte control) { throw new NotImplementedException(); }
        public static ShuffleVector256Delegate<ushort> GetShuffleLowVector256Ushort(byte control)
        {
            return (value) => ShuffleLow(value, control);
        }

        // __m256i _mm256_sign_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> Sign(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sign_epi16 (__m256i a, __m256i b)
        public static Vector256<short> Sign(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sign_epi32 (__m256i a, __m256i b)
        public static Vector256<int> Sign(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
    
        // __m256i _mm256_sub_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> Subtract(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi8 (__m256i a, __m256i b)
        public static Vector256<byte> Subtract(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi16 (__m256i a, __m256i b)
        public static Vector256<short> Subtract(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi16 (__m256i a, __m256i b)
        public static Vector256<ushort> Subtract(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi32 (__m256i a, __m256i b)
        public static Vector256<int> Subtract(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi32 (__m256i a, __m256i b)
        public static Vector256<uint> Subtract(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi64 (__m256i a, __m256i b)
        public static Vector256<long> Subtract(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_sub_epi64 (__m256i a, __m256i b)
        public static Vector256<ulong> Subtract(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }

        // __m256i _mm256_subs_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> SubtractSaturation(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_subs_epi16 (__m256i a, __m256i b)
        public static Vector256<short> SubtractSaturation(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_subs_epu8 (__m256i a, __m256i b)
        public static Vector256<byte> SubtractSaturation(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_subs_epu16 (__m256i a, __m256i b)
        public static Vector256<ushort> SubtractSaturation(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }

        // __m256i _mm256_sad_epu8 (__m256i a, __m256i b)
        public static Vector256<ulong> SumAbsoluteDifference(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }

        // __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> UnpackHigh(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
        public static Vector256<byte> UnpackHigh(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b)
        public static Vector256<short> UnpackHigh(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b)
        public static Vector256<ushort> UnpackHigh(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b)
        public static Vector256<int> UnpackHigh(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b)
        public static Vector256<uint> UnpackHigh(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b)
        public static Vector256<long> UnpackHigh(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b)
        public static Vector256<ulong> UnpackHigh(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }
        
        // __m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
        public static Vector256<sbyte> UnpackLow(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
        public static Vector256<byte> UnpackLow(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
        public static Vector256<short> UnpackLow(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
        public static Vector256<ushort> UnpackLow(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
        public static Vector256<int> UnpackLow(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
        public static Vector256<uint> UnpackLow(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
        public static Vector256<long> UnpackLow(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
        public static Vector256<ulong> UnpackLow(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }
        
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<sbyte> Xor(Vector256<sbyte> left, Vector256<sbyte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<byte> Xor(Vector256<byte> left, Vector256<byte> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<short> Xor(Vector256<short> left, Vector256<short> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<ushort> Xor(Vector256<ushort> left, Vector256<ushort> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<int> Xor(Vector256<int> left, Vector256<int> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<uint> Xor(Vector256<uint> left, Vector256<uint> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<long> Xor(Vector256<long> left, Vector256<long> right) { throw new NotImplementedException(); }
        // __m256i _mm256_xor_si256 (__m256i a, __m256i b)
        public static Vector256<ulong> Xor(Vector256<ulong> left, Vector256<ulong> right) { throw new NotImplementedException(); }
    }
}